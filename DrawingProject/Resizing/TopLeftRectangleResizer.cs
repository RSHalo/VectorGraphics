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
		public IDrawable ParentShape { get; private set; }

		private DrawableRectangle _drawnRectangle;

		public TopRectangleResizer(DrawableRectangle drawableRectangle)
		{
			ParentShape = drawableRectangle;
			_drawnRectangle = drawableRectangle;

			X = drawableRectangle.X + (drawableRectangle.Width / 2f) - (DefaultSideLength / 2f);
			Y = drawableRectangle.Y - (DefaultSideLength / 2f);
		}

		public override void MouseDown(MouseEventArgs e)
		{
			IsResizing = true;
		}

		public override void MouseMoved(MouseEventArgs e)
		{
			if (!IsResizing)
				return;

			var rect1 = _drawnRectangle.Rectangle;

			var rect2 = new Rectangle(rect1.X, rect1.Y - e.Y, rect1.Width, rect1.Height + e.Y);

			_drawnRectangle.Rectangle = rect2;

			//System.Diagnostics.Debug.WriteLine("Called");
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
