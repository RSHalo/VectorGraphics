using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingTest
{
    class FixedLineTool : Tool
    {
        public override void Clicked(MouseEventArgs e)
        {
            var line = new DrawableLine(Pens.Green, new Point(e.X - 40, e.Y - 40), new Point(e.X + 40, e.Y + 40));
            Canvas.Drawables.Add(line);
            Canvas.Invalidate();
        }
    }
}
