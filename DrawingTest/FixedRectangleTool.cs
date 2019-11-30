using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingTest
{
    class FixedRectangleTool : DrawingTool
    {
        public override void Clicked(MouseEventArgs e)
        {
            DrawResult = new DrawableRectangle(Pens.Black, new Rectangle(new Point(e.X - 25, e.Y - 15), new Size(50, 30)));
            OnDrawingCreated();
        }
    }
}
