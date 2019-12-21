using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProject.Drawables
{
    class DrawableEllipse : IDrawable
    {
        public Pen Pen { get; set; }
        private Rectangle boundingRectangle;

        public DrawableEllipse(Pen pen, Rectangle rectangle)
        {
            Pen = pen;
            boundingRectangle = rectangle;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(Pen, boundingRectangle);
        }
    }
}
