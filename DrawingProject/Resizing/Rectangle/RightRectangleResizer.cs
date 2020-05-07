using DrawingProject.Drawables;
using DrawingProject.Drawables.Resizable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingProject.Resizing.Rectangle
{
	class RightRectangleResizer : RectangleResizer
	{
		public RightRectangleResizer(IResizableRectangle shape) : base(shape)
		{
			// Set the control to be displayed in the middle of the right side of the rectangle.
			WorldX = shape.ResizableRectangle.X + shape.ResizableRectangle.Width - (DefaultSideLength / 2f);
			WorldY = shape.ResizableRectangle.Y + (shape.ResizableRectangle.Height / 2) - (DefaultSideLength / 2f);
		}

		protected override void ResizeShape()
		{
			int newWidth = RectangleWidth + DxWorld;

			_shape.ResizableRectangle = new System.Drawing.Rectangle(RectangleX, RectangleY, newWidth, RectangleHeight);
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
