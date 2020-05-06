using DrawingProject.Drawables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingProject.Resizing.Rectangle
{
	class LeftRectangleResizer : RectangleResizer
	{
		public LeftRectangleResizer(DrawableRectangle drawableRectangle) : base(drawableRectangle)
		{
			// Set the control to be displayed in the middle of the left side of the rectangle.
			WorldX = drawableRectangle.X - (DefaultSideLength / 2f);
			WorldY = drawableRectangle.Y + (drawableRectangle.Height / 2) - (DefaultSideLength / 2f);
		}

		protected override void ResizeShape()
		{
			int currentX = _drawnRectangle.X;
			int currentY = _drawnRectangle.Y;

			int newX = currentX + dx;
			int newWidth = _drawnRectangle.Width - dx;

			_drawnRectangle.Rectangle = new System.Drawing.Rectangle(newX, currentY, newWidth, _drawnRectangle.Height);

			Canvas.Invalidate();
		}

		protected override void MoveControl(MouseEventArgs e)
		{
			base.MoveControl(e);

			// Only move this control horizontally.
			Left += dx;
		}

		protected override void UpdateWorldCoords()
		{
			WorldX = _drawnRectangle.X - (DefaultSideLength / 2f);
			WorldY = _drawnRectangle.Y + (_drawnRectangle.Height / 2) - (DefaultSideLength / 2f);
		}
	}
}
