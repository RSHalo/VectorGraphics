using DrawingProject;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DrawingProject.Drawables;
using System.Diagnostics;
using System.Drawing;

class Canvas : Panel
{
    // The drawable shapes that need to be drawn when the Canvas is painted.
    public List<IDrawable> Drawables = new List<IDrawable>();

    /// <summary>The X offset from the page co-ordinates to the world co-ordinates</summary>
    public float OffsetX { get; set; }
    /// <summary>The Y offset from the page co-ordinates to the world co-ordinates</summary>
    public float OffsetY { get; set; }

    private int mouseWheelIndent;
    public float LastZoomScale { get; private set; } = 1;
    public float ZoomScale { get; private set; } = 1;

    /// <summary>World coordinates of the mouse position before zooming.</summary>
    public PointF BeforeZoomWorld { get; private set; }
    /// <summary>World coordinates of the mouse position after zooming.</summary>
    public PointF AfterZoomWorld { get; private set; }

    /// <summary>The X amount to Translate after scaling for zoom</summary>
    public float ZoomOffsetX { get; set; }
    /// <summary>The Y amount to Translate after scaling for zoom</summary>
    public float ZoomOffsetY { get; set; }

    public Canvas()
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
        // These values will be positive when zooming in.
        float dx = BeforeZoomWorld.X - AfterZoomWorld.X;
        float dy = BeforeZoomWorld.Y - AfterZoomWorld.Y;

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
        float worldX = (screenX + OffsetX) / ZoomScale;
        float worldY = (screenY + OffsetY) / ZoomScale;

        return new PointF(worldX, worldY);
    }
}
