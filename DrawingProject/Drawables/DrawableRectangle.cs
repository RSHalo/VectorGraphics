using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingProject.Resizing;
using DrawingProject.Resizing.Rectangle;

namespace DrawingProject.Drawables
{
    public class DrawableRectangle : IDrawable
    {
        public Rectangle Rectangle;
		public string Id { get; set; }
		public Pen Pen { get; set; }

        public int X => Rectangle.X;
        public int Y => Rectangle.Y;
        public int Width => Rectangle.Width;
        public int Height => Rectangle.Height;

		public DrawableRectangle(Pen pen, int x, int y, int width, int height)
        {
            Pen = pen;
            Rectangle = new Rectangle(x, y, width, height);
        }

        public DrawableRectangle(Pen pen, Rectangle rectangle)
        {
            Pen = pen;
            Rectangle = rectangle;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(Pen, Rectangle);
        }

        public bool HitTest(int worldX, int worldY)
        {
            // A small rectangle that defines where we have attempted to select.
            // NOTE: Maybe don't create this every time this function is called. Perhaps keep a single instance of the rectangle somewhere and reference it?
            var selectionRect = new Rectangle(worldX - 5, worldY - 5, 10, 10);

            var intersectionRect = Rectangle.Intersect(selectionRect, Rectangle);

            // We want to select the rectangle by just clicking the outline, not by clicking anywhere inside the rectangle. This means we don't want the intersection to be
            // completely inside the rectangle, therefore we make sure the intersection isn't the same size as the selection rectangle.
            return (!intersectionRect.IsEmpty && intersectionRect.Size != selectionRect.Size);
        }

		public List<ResizeControl> GetResizers()
		{
			var topResizer = new TopRectangleResizer(this);
			var bottomResizer = new BottomRectangleResizer(this);
			var leftResizer = new LeftRectangleResizer(this);
			var rightResizer = new RightRectangleResizer(this);

			return new List<ResizeControl>
			{
				topResizer,
				bottomResizer,
				leftResizer,
				rightResizer
			};
		}
	}
}
