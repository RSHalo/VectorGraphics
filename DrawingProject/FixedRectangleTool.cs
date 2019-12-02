using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingProject
{
    class FixedRectangleTool : Tool
    {
        public override void Clicked(MouseEventArgs e)
        {
            var rectangle = new DrawableRectangle(Pens.Black, new Rectangle(new Point(e.X - 25, e.Y - 15), new Size(50, 30)));
            Canvas.Drawables.Add(rectangle);
            Canvas.Invalidate();
        }
    }
}
