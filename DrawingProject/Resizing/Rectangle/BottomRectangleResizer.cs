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
			int newHeight = RectangleHeight + DyWorld;

			_drawnRectangle.Rectangle = new System.Drawing.Rectangle(RectangleX, RectangleY, RectangleWidth, newHeight);

			Canvas.Invalidate();
		}

		protected override void MoveControl(MouseEventArgs e)
		{
			base.MoveControl(e);

			// Only move this control vertically.
			Top += dy;
		}

		protected override void UpdateWorldCoords()
		{
			WorldX = RectangleX + (RectangleWidth / 2f) - (DefaultSideLength / 2f);
			WorldY = RectangleY + RectangleHeight - (DefaultSideLength / 2f);
		}
	}
}
