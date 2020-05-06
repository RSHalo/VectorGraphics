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
			int currentX = _drawnRectangle.X;
			int currentY = _drawnRectangle.Y;

			int newHeight = _drawnRectangle.Height + dy;

			_drawnRectangle.Rectangle = new System.Drawing.Rectangle(currentX, currentY, _drawnRectangle.Width, newHeight);

			Canvas.Invalidate();
		}

		protected override void MoveControl(MouseEventArgs e)
		{
			base.MoveControl(e);

			// Only move this control vertically.
			Top += dy;
		}

		public override void UpdateWorldLocation()
		{
			WorldX = _drawnRectangle.X + (_drawnRectangle.Width / 2f) - (DefaultSideLength / 2f);
			WorldY = _drawnRectangle.Y + _drawnRectangle.Height - (DefaultSideLength / 2f);
		}
	}
}
