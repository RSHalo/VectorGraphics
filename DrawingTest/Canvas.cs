using System;
using System.Windows.Forms;

class Canvas : Panel
{
    public Canvas()
    {
        DoubleBuffered = true;
        SetStyle(ControlStyles.ResizeRedraw, true);
    }
}
