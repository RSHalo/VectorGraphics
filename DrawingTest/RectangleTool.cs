using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingTest
{
    class RectangleTool : Tool
    {
        // Mouse-down position
        Point _startPoint;

         // Current positiom
        Point _currentPoint;

        public override void MouseDown(MouseEventArgs e)
        {
            _currentPoint = _startPoint = e.Location;
            IsDrawing = true;
        }

        public override void MouseMoved(MouseEventArgs e)
        {
            // Started moving the rectangle again so clear the creation drawables because we need to an updates creation variable instead
            CreationDrawables.Clear();

            _currentPoint = e.Location;

            if (IsDrawing)
            {
                CreationDrawables.Add(GetRectangle());
                Canvas.Invalidate();
            }
        }

        public override void MouseUp(MouseEventArgs e)
        {
            if (IsDrawing)
            {
                IsDrawing = false;
                var rectangle = GetRectangle();

                if (rectangle.Width > 0 && rectangle.Height > 0)
                    Canvas.Drawables.Add(rectangle);

                Canvas.Invalidate();
            }
        }

        private DrawableRectangle GetRectangle()
        {
            var rectangle = new Rectangle(
                Math.Min(_startPoint.X, _currentPoint.X),
                Math.Min(_startPoint.Y, _currentPoint.Y),
                Math.Abs(_startPoint.X - _currentPoint.X),
                Math.Abs(_startPoint.Y - _currentPoint.Y));

            return new DrawableRectangle(Pens.DarkCyan, rectangle);
        }
    }
}
