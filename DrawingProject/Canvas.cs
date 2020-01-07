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
    public PointF MouseStartZoomWorldPoint { get; private set; }
    public PointF MouseStartZoomScreenPoint { get; private set; }

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

        MouseStartZoomScreenPoint = new PointF(e.X, e.Y);

        MouseStartZoomWorldPoint = ScreenToWorld(e.X, e.Y);
        Debug.WriteLine($"Mouse World: {MouseStartZoomWorldPoint.X},{MouseStartZoomWorldPoint.Y}");

        LastZoomScale = ZoomScale;

        if (e.Delta > 0)
            mouseWheelIndent++;
        else
            mouseWheelIndent--;

        ZoomScale = mouseWheelIndent >= 0 ? mouseWheelIndent + 1 : (1 / (-mouseWheelIndent + 1f));

        Refresh();
    }

    public PointF ScreenToWorld(float screenX, float screenY)
    {
        float worldX = screenX / ZoomScale;
        float worldY = screenY / ZoomScale;

        return new PointF(worldX, worldY);
    }
}
