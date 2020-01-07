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
    public float ZoomScale
    {
        get
        {
            return mouseWheelIndent >= 0 ? mouseWheelIndent + 1 : (1 / (-mouseWheelIndent + 1f));
        }

        private set { }
    }

    public float moveAfterZoomX;
    public float moveAfterZoomY;


    public Canvas()
    {
        DoubleBuffered = true;
        SetStyle(ControlStyles.ResizeRedraw, true);
        mouseWheelIndent = 0;
        ZoomScale = 1;
    }

    // May not work on non Windows 10. Haven't tested.
    protected override void OnMouseWheel(MouseEventArgs e)
    {
        base.OnMouseWheel(e);

        LastZoomScale = ZoomScale;

        if (e.Delta > 0)
            mouseWheelIndent++;
        else
            mouseWheelIndent--;

        // Get screen coords of the point we wish to zoom about. Might need to include main offset here?
        PointF zoomPointBefore = new PointF(300 * LastZoomScale, 275 * LastZoomScale);
        PointF zoomPointAfter = new PointF(300 * ZoomScale, 275 * ZoomScale);

        // Get the translate required to keep the point at the same point on the screen.
        // Translations are done in terms of screen coordinates, that is why we calculated screen coords above.
        float dx = zoomPointAfter.X - zoomPointBefore.X;
        float dy = zoomPointAfter.Y - zoomPointBefore.Y;

        // The total translate required from the origin. The above was just the change in translate from the previous position.
        moveAfterZoomX += dx;
        moveAfterZoomY += dy;

        // Refresh() instead of Invalidate() because we want immediate updates. Very fast scrolling broke the zooming when Invalidate() was used.
        Refresh();
    }
}
