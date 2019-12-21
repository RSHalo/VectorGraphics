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

    public Canvas()
    {
        DoubleBuffered = true;
        SetStyle(ControlStyles.ResizeRedraw, true);
    }
}
