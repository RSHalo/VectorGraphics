using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingProject
{
    class RectangleTool : Tool
    {
        Point _startPoint;
        Point _currentPoint;

        public override void MouseDown(MouseEventArgs e)
        {
            _currentPoint = _startPoint = e.Location;
            IsDrawing = true;
        }

        public override void MouseMoved(MouseEventArgs e)
        {
            _currentPoint = e.Location;

            if (IsDrawing)
            {
                CreationDrawable = GetRectangle();
                Canvas.Invalidate();
            }
        }

        public override void MouseUp(MouseEventArgs e)
        {
            if (IsDrawing)
            {
                IsDrawing = false;

                // Mouse up means that we want to draw our final result, so we longer need creation shapes.
                CreationDrawable = null;

                // The final drawn result.
                var rectangle = GetRectangle(true);
                
                // Add final result to the Canvas.
                if (rectangle.Width > 0 && rectangle.Height > 0)
                    Canvas.Drawables.Add(rectangle);

                Canvas.Invalidate();
            }
        }

        // Gets the DrawableRectangle that is defined by the start position and the current position of the mouse.
        private DrawableRectangle GetRectangle(bool finalResult = false)
        {
            var rectangle = new Rectangle(
                Math.Min(_startPoint.X, _currentPoint.X),
                Math.Min(_startPoint.Y, _currentPoint.Y),
                Math.Abs(_startPoint.X - _currentPoint.X),
                Math.Abs(_startPoint.Y - _currentPoint.Y));

            // Make the creation shapes and the final shape different colors.
            Pen pen = finalResult ? Pens.Red : Pens.DarkCyan;

            return new DrawableRectangle(pen, rectangle);
        }
    }
}
