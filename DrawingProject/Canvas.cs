using DrawingProject;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DrawingProject.Drawables;

class Canvas : Panel
{
    // The drawable shapes that need to be drawn when the Canvas is painted.
    public List<IDrawable> Drawables = new List<IDrawable>();

    /// <summary>The X offset from the page co-ordinates to the world co-ordinates</summary>
    public float OffsetX { get; set; }
    /// <summary>The Y offset from the page co-ordinates to the world co-ordinates</summary>
    public float OffsetY { get; set; }

    // Screen coords of cursor at the time the mouse was scrolled to zoom.
    public float zoomPosXBefore;
    public float zoomPosYBefore;
    public float zoomPosXAfter;
    public float zoomPosYAfter;

    private int mouseWheelIndent;
    public bool IsZoomed { get; private set; }
    public float LastZoomScale { get; private set; } = 1;
    public float ZoomScale
    {
        get
        {
            if (!IsZoomed)
                return 1;
            else
                return mouseWheelIndent >= 0 ? mouseWheelIndent + 1 : (1 / (-mouseWheelIndent + 1f));
        }
    }

    /// <summary>The X offset from the required zoomed viewport to the default zoomed viewport, assuming default zoom keeps top left constant.</summary>
    public float ZoomViewportOffsetX
    {
        get
        {
            return zoomPosXAfter - zoomPosXBefore;
        }
    }

    /// <summary>The Y offset from the required zoomed viewport to the default zoomed viewport, assuming default zoom keeps top left constant.</summary>

    public float ZoomViewportOffsetY
    {
        get
        {
            return zoomPosYAfter - zoomPosYBefore;
        }
    }

    public Canvas()
    {
        DoubleBuffered = true;
        IsZoomed = false;
        mouseWheelIndent = 0;
        SetStyle(ControlStyles.ResizeRedraw, true);
    }

    // May not work on non Windows 10. Haven't tested.
    protected override void OnMouseWheel(MouseEventArgs e)
    {
        LastZoomScale = ZoomScale;

        // Mouse coords before zoom.
        zoomPosXBefore = (e.X * LastZoomScale);
        zoomPosYBefore = (e.Y * LastZoomScale);

        base.OnMouseWheel(e);

        if (e.Delta > 0)
            mouseWheelIndent++;
        else
            mouseWheelIndent--;

        IsZoomed = (mouseWheelIndent != 0);

        // Mouse coords after zoom.
        zoomPosXAfter = (e.X * ZoomScale);
        zoomPosYAfter = (e.Y * ZoomScale);

        Invalidate();
    }
}
