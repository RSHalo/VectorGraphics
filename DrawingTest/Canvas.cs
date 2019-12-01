using DrawingTest;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

class Canvas : Panel
{
    // Collection of drawable shapes. This collection is iterated over when the canvas is drawn.
    public List<IDrawable> Drawables = new List<IDrawable>();

    public Canvas()
    {
        DoubleBuffered = true;
        SetStyle(ControlStyles.ResizeRedraw, true);
    }
}
