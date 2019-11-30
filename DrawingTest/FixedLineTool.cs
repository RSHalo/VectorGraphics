using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingTest
{
    class FixedLineTool : DrawingTool
    {
        public override void Clicked(MouseEventArgs e)
        {
            DrawResult = new DrawableLine(Pens.Green, new Point(e.X - 20, e.Y - 20), new Point(e.X + 20, e.Y + 20));
            OnDrawingCreated();
        }
    }
}
