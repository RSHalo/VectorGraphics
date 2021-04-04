using VectorGraphics.Drawables;
using VectorGraphics.Drawables.Resizable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VectorGraphics.Resizing.Rectangle
{
	class RightRectangleResizer : RectangleResizer
	{
		public RightRectangleResizer(IDrawableRectangle shape) : base(shape)
		{
			// Set the control to be displayed in the middle of the right side of the rectangle.
			WorldX = shape.Rectangle.X + shape.Rectangle.Width - (DefaultSideLength / 2f);
			WorldY = shape.Rectangle.Y + (shape.Rectangle.Height / 2) - (DefaultSideLength / 2f);

			_cursor = Cursors.SizeWE;
		}

		protected override void ResizeShape()
		{
			int newWidth = RectangleWidth + DxWorld;

			_shape.Rectangle = new System.Drawing.Rectangle(RectangleX, RectangleY, newWidth, RectangleHeight);
		}

		protected override void MoveControl(MouseEventArgs e)
		{
			base.MoveControl(e);

			// Only move this control horizontally.
			Left += dx;
		}

		protected override void UpdateWorldCoords()
		{
			WorldX = RectangleX + RectangleWidth - (DefaultSideLength / 2f);
			WorldY = RectangleY + (RectangleHeight / 2) - (DefaultSideLength / 2f);
		}
	}
}
