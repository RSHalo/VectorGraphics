using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingTest.Utility
{
    static class Dimensions
    {
        static readonly Random _random = new Random();

        public static Point GetRandomPoint(int canvasWidth, int canvasHeight)
        {
            int x = _random.Next(0, canvasWidth);
            int y = _random.Next(0, canvasHeight);

            return new Point(x, y);
        }

        public static Rectangle GetRandomRectangle(int canvasWidth, int canvasHeight)
        {
            Point topLeftPoint = GetRandomPoint(canvasWidth, canvasHeight);

            int height = _random.Next(1, canvasHeight - topLeftPoint.Y);
            int width = _random.Next(1, canvasWidth - topLeftPoint.X);

            return new Rectangle(topLeftPoint, new Size(width, height));
        }
    }
}
