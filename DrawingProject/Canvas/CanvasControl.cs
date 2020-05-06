﻿using DrawingProject;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DrawingProject.Drawables;
using System.Diagnostics;
using System.Drawing;
using DrawingProject.Canvas;
using DrawingProject.Resizing;
using System.Linq;

public class CanvasControl : Panel
{
	/// <summary>The drawable shapes that need to be drawn when the Canvas is painted.</summary>
	public DrawableCollection Drawables = new DrawableCollection();

	// Add IDrawables to the Drawables collection
	public void AddLine(DrawableLine line) => Drawables.AddLine(line);
	public void AddRectangle(DrawableRectangle rectangle) => Drawables.AddRectangle(rectangle);
	public void AddEllipse(DrawableEllipse ellipse) => Drawables.AddEllipse(ellipse);

	/// <summary>The X offset from the page co-ordinates to the world co-ordinates.</summary>
	public float OffsetX { get; set; }
    /// <summary>The Y offset from the page co-ordinates to the world co-ordinates.</summary>
    public float OffsetY { get; set; }

    /// <summary>The scale factor which determines how zoomed in/out the view is.</summary>
    public float ZoomScale { get; private set; } = 1;
    private int mouseWheelIndent;

    /// <summary>World coordinates of the mouse position before zooming.</summary>
    public PointF BeforeZoomWorld { get; private set; }
    /// <summary>World coordinates of the mouse position after zooming.</summary>
    public PointF AfterZoomWorld { get; private set; }

    public CanvasControl()
    {
        DoubleBuffered = true;
        SetStyle(ControlStyles.ResizeRedraw, true);
        mouseWheelIndent = 0;
        ZoomScale = 1;
    }

    // May not work on non Windows 10. Haven't tested.
    // When we scale, the world coordinates under the mouse change (they move to a different part of the screen).
    // The difference between the world coordinates before and after scaling tells us how much we will need to move the world around to the get the
    // original world point back at the same screen position.
    protected override void OnMouseWheel(MouseEventArgs e)
    {
        base.OnMouseWheel(e);

        // The world coordinate under the mouse before scaling.
        BeforeZoomWorld = ScreenToWorld(e.X, e.Y);

        UpdateZoomScale(e);

        // The world coordinate under the mouse after scaling.
        AfterZoomWorld = ScreenToWorld(e.X, e.Y);

        // The X and Y changes between the two world coordinates. These represent the distances that the world needs to move to place the original world coordinate correctly.
        // These values will be negative when zooming in on the 4th Cartesian quadrant.
        float dx = AfterZoomWorld.X - BeforeZoomWorld.X;
        float dy = AfterZoomWorld.Y - BeforeZoomWorld.Y;

        // These changes need to be scaled! This is because the parameters of ScaleTransform are in pixels, and they need to be scaled to match the world coords (which have been scaled).
        dx *= ZoomScale;
        dy *= ZoomScale;

        // Add these changes to the current ZoomOffsets. This is updating the distances that TranslateTransform actually uses to move the world around.
        OffsetX += dx;
        OffsetY += dy;

        // Refresh instead of Invalidate to get synchronous updating. Prevents errors with very fast mouse wheel scrolling.
        Refresh();
    }

    /// <summary>Updates ZoomScale</summary>
    private void UpdateZoomScale(MouseEventArgs e)
    {
        if (e.Delta > 0)
            mouseWheelIndent++;
        else
            mouseWheelIndent--;

        ZoomScale = mouseWheelIndent >= 0 ? mouseWheelIndent + 1 : (1 / (-mouseWheelIndent + 1f));
    }

    /// <summary>Gets corresponding world coordinates, given screen coordinates.</summary>
    public PointF ScreenToWorld(float screenX, float screenY)
    {
        float worldX = (screenX - OffsetX) / ZoomScale;
        float worldY = (screenY - OffsetY) / ZoomScale;

        return new PointF(worldX, worldY);
    }

	/// <summary>Gets corresponding screen coordinates, given world coordinates.</summary>
	public PointF WorldToScreen(float worldX, float worldY)
	{
		float screenX = OffsetX + (worldX * ZoomScale);
		float screenY = OffsetY + (worldY * ZoomScale);

		return new PointF(screenX, screenY);
	}

	/// <summary>Resets to a blank canvas.</summary>
	public void Reset()
    {
        Drawables.Clear();

        OffsetX = 0f;
        OffsetY = 0f;

        mouseWheelIndent = 0;
        ZoomScale = 1;
    }

	/// <summary>Gets the appropriate resize controls for the newly selected shape.</summary>
	public void OnSelectedShapeChanged(object source, EventArgs e)
	{
		RemoveResizeControls();

		if (Drawables.SelectedShape == null)
			return;

		AddResizeControls();
	}

	private void AddResizeControls()
	{
		// When the selected shape changes, new resize controls are needed.
		List<ResizeControl> resizers = Drawables.SelectedShape.GetResizers();

		// Zoom scale will affect the onscreen size of the resize control. Accomodate for this here.
		int controlSideLength = (int)(ZoomScale * ResizeControl.DefaultSideLength);

		// Add ResizeControls to the canvas.
		foreach (var resizer in resizers)
		{
			var screenCoords = WorldToScreen(resizer.WorldX, resizer.WorldY);
			var screenLocation = new Point((int)screenCoords.X, (int)screenCoords.Y);

			resizer.Location = screenLocation;
			resizer.Width = controlSideLength;
			resizer.Height = controlSideLength;
			resizer.Canvas = this;

			Controls.Add(resizer);
		}
	}

	private void RemoveResizeControls()
	{
		foreach (var control in Controls.OfType<ResizeControl>())
		{
			Controls.Remove(control);
		}
	}
}