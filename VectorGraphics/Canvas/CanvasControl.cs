using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VectorGraphics.Canvas;
using VectorGraphics.Drawables;
using VectorGraphics.KeyHanding;
using VectorGraphics.Movement;
using VectorGraphics.Resizing;

public class CanvasControl : SelectablePanel
{
    private readonly IKeyHandler _keyHandler;

    /// <summary>The drawable shapes that need to be drawn when the Canvas is painted.</summary>
	public DrawableCollection Drawables = new DrawableCollection();

	/// <summary>Current ResizeControls on the canvas.</summary>
	public List<ResizeControl> Resizers = new List<ResizeControl>();

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

        _keyHandler = new CanvasKeyHandler(this);

        // An event is published when the selected shape is changed. The canvas is subscribed to this event so that it can react accordingly.
        Drawables.SelectedShapeChanged += OnSelectedShapeChanged;
    }

    public void Repaint()
    {
        Invalidate();
    }

    #region Add IDrawables to the Drawables collection
    public void AddLine(IDrawable line)
    {
        Drawables.AddLine(line);
    }

    public void AddRectangle(IDrawable rectangle)
    {
        Drawables.AddRectangle(rectangle);
    }

    public void AddEllipse(IDrawable ellipse)
    {
        Drawables.AddEllipse(ellipse);
    }
    #endregion Add IDrawables to the Drawables collection

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

    protected override void OnKeyDown(KeyEventArgs e)
    {
        _keyHandler.HandleKeyDown(e, e.Modifiers);
    }

    protected override void OnKeyUp(KeyEventArgs e)
    {
        _keyHandler.HandleKeyUp(e, e.Modifiers);
    }

    /// <summary>Updates ZoomScale.</summary>
    private void UpdateZoomScale(MouseEventArgs e)
    {
        if (e.Delta > 0)
        {
            mouseWheelIndent++;
        }
        else
        {
            mouseWheelIndent--;
        }

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

	/// <summary>Clears to a blank canvas.</summary>
	public void Clear()
    {
        Drawables.Clear();
        ResetView();
    }

    /// <summary>
    /// Resets the canvas view, ready for user drawing, by defaulting things like zoom and offset.
    /// This does not clear the canvas' drawings, use <see cref="Clear"/> for that.
    /// </summary>
    public void ResetView()
    {
        Drawables.SelectedShape = null;

        OffsetX = 0f;
        OffsetY = 0f;

        mouseWheelIndent = 0;
        ZoomScale = 1;

        Repaint();
    }

    /// <summary>Performs any required action before loading shapes from a file.</summary>
    public void PreLoad()
    {
        Clear();
    }

    public void DeleteSelectedShape()
    {
        Drawables.DeleteSelectedShape();
        Repaint();
    }

    /// <summary>Gets the appropriate resize controls for the newly selected shape.</summary>
    public void OnSelectedShapeChanged(object source, EventArgs e)
	{
		RemoveResizeControls();
		if (Drawables.SelectedShape != null)
        {
            AddResizeControls();
        }
    }

    public void MoveShape(IDrawable shape, MovementType movementType)
    {
        shape.MoveBehaviour.Move(movementType);
        Repaint();
    }
    
    public void AddResizeControls()
	{
		// When the selected shape changes, new resize controls are needed.
		Resizers = Drawables.SelectedShape.GetResizers();

		// Add ResizeControls to the canvas.
		foreach (ResizeControl resizer in Resizers)
		{
			resizer.Canvas = this;
			resizer.UpdateWorldState();
			Controls.Add(resizer);
		}
	}

    public void RemoveResizeControls()
	{
		foreach (ResizeControl control in Resizers)
		{
			Controls.Remove(control);
		}

		Resizers.Clear();
	}

	/// <summary>
	/// Updates the locations and sizes of the current resizer controls appropriately, based on the underlying IDrawable, as well as canvas offset/zoom scale.
	/// </summary>
	public void RefreshResizers()
	{
		foreach (ResizeControl resizer in Resizers)
		{
			resizer.UpdateWorldState();
		}
	}
}
