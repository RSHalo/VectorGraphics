using DrawingProject.Drawables;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingProject.Tools
{
    class Pointer : Tool
    {
        public override void MouseUp(MouseEventArgs e)
        {
            foreach (IDrawable shape in Canvas.Drawables)
            {
                if (shape.HitTest(WorldX, WorldY))
                    MessageBox.Show("Hit");
            }

            Canvas.Invalidate();
        }
    }
}
