using DrawingProject.Drawables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingProject.Resizing.Rectangle
{
	class BottomRectangleResizer : RectangleResizer
	{
		public BottomRectangleResizer(DrawableRectangle drawableRectangle) : base(drawableRectangle)
		{
			// Set the control to be displayed in the middle of the bottom line of the rectangle.
			WorldX = drawableRectangle.X + (drawableRectangle.Width / 2f) - (DefaultSideLength / 2f);
			WorldY = drawableRectangle.Y + drawableRectangle.Height - (DefaultSideLength / 2f);
		}

		protected override void ResizeShape()
		{
			int rect1X = _drawnRectangle.Rectangle.X;
			int rect1Y = _drawnRectangle.Rectangle.Y;

			int newHeight = _drawnRectangle.Rectangle.Height + dy;

			_drawnRectangle.Rectangle = new System.Drawing.Rectangle(rect1X, rect1Y, _drawnRectangle.Width, newHeight);

			Canvas.Invalidate();
		}

		protected override void MoveControl(MouseEventArgs e)
		{
			base.MoveControl(e);

			// Only move this control vertically.
			Top += dy;
		}

		public override void Rezise()
		{
			throw new NotImplementedException();
		}
	}
}
