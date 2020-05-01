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
			// Tell the Canvas what shape we hit. If no shape hit, value is null (because we are using FirstOrDefault).
			Canvas.Drawables.SelectedShape =  Canvas.Drawables.FirstOrDefault(d => d.HitTest(WorldX, WorldY));

			// Redraw canvas because we may want visual changes when a shape is selected.
            Canvas.Invalidate();
        }
    }
}
