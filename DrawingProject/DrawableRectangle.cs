using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProject
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
    }
}
