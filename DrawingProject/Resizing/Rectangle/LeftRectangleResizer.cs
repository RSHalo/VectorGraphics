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
			int newX = RectangleX + DxWorld;
			int newWidth = RectangleWidth - DxWorld;

			_drawnRectangle.Rectangle = new System.Drawing.Rectangle(newX, RectangleY, newWidth, RectangleHeight);

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
			WorldX = RectangleX - (DefaultSideLength / 2f);
			WorldY = RectangleY + (RectangleHeight / 2) - (DefaultSideLength / 2f);
		}
	}
}
