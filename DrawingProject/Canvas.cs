using DrawingProject;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

class Canvas : Panel
{
    // The drawable shapes that need to be drawn when the Canvas is painted.
    public List<IDrawable> Drawables = new List<IDrawable>();

    public Canvas()
    {
        DoubleBuffered = true;
        SetStyle(ControlStyles.ResizeRedraw, true);
    }
}
