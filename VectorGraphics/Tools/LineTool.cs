using System.Drawing;
using System.Windows.Forms;
using VectorGraphics.Drawables;

namespace VectorGraphics.Tools
{
    class LineTool : Tool
    {
        Point startPoint;
        Point currentPoint;

        public override void MouseDown(MouseEventArgs e)
        {
            IsDrawing = true;
            currentPoint = startPoint = WorldPoint;
        }

        public override void MouseMoved(MouseEventArgs e)
        {
            currentPoint = WorldPoint;

            if (IsDrawing)
            {
                CreationDrawable = GetDrawableLine();
                RepaintCanvas();
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
                DrawableLine line = GetDrawableLine(true);

                // Add final result to the Canvas.
                if (line.StartPoint != line.EndPoint)
                {
                    AddShape(line);
                }

                RepaintCanvas();
            }
        }

        // Gets the DrawableLine that is defined by the start position and the current position of the mouse.
        private DrawableLine GetDrawableLine(bool finalResult = false)
        {
            // Make the creation line and the final line different colors. Make creation line dashed.
            var pen = finalResult ?
                                  Pens.Blue :
                                  new Pen(Color.Black)
                                  {
                                      DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
                                  };

            return new DrawableLine(pen, startPoint, currentPoint);
        }
    }
}
