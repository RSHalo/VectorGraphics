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
	class BottomRectangleResizer : RectangleResizer
	{
		public BottomRectangleResizer(IResizableRectangle shape) : base(shape)
		{
			// Set the control to be displayed in the middle of the bottom line of the rectangle.
			WorldX = shape.ResizableRectangle.X + (shape.ResizableRectangle.Width / 2f) - (DefaultSideLength / 2f);
			WorldY = shape.ResizableRectangle.Y + shape.ResizableRectangle.Height - (DefaultSideLength / 2f);
		}

		protected override void ResizeShape()
		{
			int newHeight = RectangleHeight + DyWorld;

			_shape.ResizableRectangle = new System.Drawing.Rectangle(RectangleX, RectangleY, RectangleWidth, newHeight);
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
