using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProject.Drawables
{
    class DrawableRectangle : IDrawable
    {
        private Rectangle _rectangle;

        public Pen Pen { get; set; }

        public int X => _rectangle.X;
        public int Y => _rectangle.Y;
        public int Width => _rectangle.Width;
        public int Height => _rectangle.Height;

        public DrawableRectangle(Pen pen, int x, int y, int width, int height)
        {
            Pen = pen;
            _rectangle = new Rectangle(x, y, width, height);
        }

        public DrawableRectangle(Pen pen, Rectangle rectangle)
        {
            Pen = pen;
            _rectangle = rectangle;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(Pen, _rectangle);
        }

        public bool HitTest(int worldX, int worldY)
        {
            // A small rectangle that defines where we have attempted to select.
            // NOTE: Maybe don't create this every time this function is called. Perhaps keep a single instance of the rectangle somewhere and reference it?
            var selectionRect = new Rectangle(worldX - 5, worldY - 5, 10, 10);

            var intersectionRect = Rectangle.Intersect(selectionRect, _rectangle);

            // We want to select the rectangle by just clicking the outline, not by clicking anywhere inside the rectangle. This means we don't want the intersection to be
            // completely inside the rectangle, therefore we make sure the intersection isn't the same size as the selection rectangle.
            return (!intersectionRect.IsEmpty && intersectionRect.Size != selectionRect.Size);
        }
    }
}
