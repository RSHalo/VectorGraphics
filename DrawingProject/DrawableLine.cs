using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProject
{
    class DrawableLine : IDrawable
    {
        public Pen Pen { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public DrawableLine(Pen pen, Point startPoint, Point endPoint)
        {
            Pen = pen;
            StartPoint = startPoint;
            EndPoint = endPoint;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawLine(Pen, StartPoint, EndPoint);
        }
    }
}
