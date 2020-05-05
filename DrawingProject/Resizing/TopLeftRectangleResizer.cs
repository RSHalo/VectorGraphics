using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrawingProject.Drawables;

namespace DrawingProject.Resizing
{
	class TopRectangleResizer : Resizer
	{
		private DrawableRectangle _drawnRectangle;

		public TopRectangleResizer(DrawableRectangle drawableRectangle)
		{
			//ParentShape = drawableRectangle;
			_drawnRectangle = drawableRectangle;

			X = drawableRectangle.X + (drawableRectangle.Width / 2f) - (DefaultSideLength / 2f);
			Y = drawableRectangle.Y - (DefaultSideLength / 2f);
		}

		public override void MouseDown(MouseEventArgs e)
		{
			
		}

		public override void MouseMoved(MouseEventArgs e)
		{

		}

		public override void MouseUp(MouseEventArgs e)
		{
			IsResizing = false;
		}

		public override void Rezise()
		{
			throw new NotImplementedException();
		}
	}
}
