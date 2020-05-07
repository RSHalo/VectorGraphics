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
	class LeftRectangleResizer : RectangleResizer
	{
		public LeftRectangleResizer(IResizableRectangle shape) : base(shape)
		{
			// Set the control to be displayed in the middle of the left side of the rectangle.
			WorldX = shape.ResizableRectangle.X - (DefaultSideLength / 2f);
			WorldY = shape.ResizableRectangle.Y + (shape.ResizableRectangle.Height / 2) - (DefaultSideLength / 2f);

			_cursor = Cursors.SizeWE;
		}

		protected override void ResizeShape()
		{
			int newX = RectangleX + DxWorld;
			int newWidth = RectangleWidth - DxWorld;

			_shape.ResizableRectangle = new System.Drawing.Rectangle(newX, RectangleY, newWidth, RectangleHeight);
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
