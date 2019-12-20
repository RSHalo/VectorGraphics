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
        Point startPoint;
        Point currentPoint;

        public override void MouseDown(MouseEventArgs e)
        {
            currentPoint = startPoint = WorldPoint;
            IsDrawing = true;
        }

        public override void MouseMoved(MouseEventArgs e)
        {
            currentPoint = WorldPoint;

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
                Math.Min(startPoint.X, currentPoint.X),
                Math.Min(startPoint.Y, currentPoint.Y),
                Math.Abs(startPoint.X - currentPoint.X),
                Math.Abs(startPoint.Y - currentPoint.Y));

            // Make the creation shapes and the final shape different colors. Give creation shape a dashed line.
            Pen pen = finalResult ?
                                   Pens.Red :
                                   new Pen(Color.DarkCyan)
                                   {
                                       DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
                                   };

            return new DrawableRectangle(pen, rectangle);
        }
    }
}
