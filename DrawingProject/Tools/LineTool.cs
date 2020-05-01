using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrawingProject.Drawables;

namespace DrawingProject.Tools
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

            if (!IsDrawing)
                return;

            CreationDrawable = GetDrawableLine();
            Canvas.Invalidate();
        }

        public override void MouseUp(MouseEventArgs e)
        {
            if (!IsDrawing)
                return;

            IsDrawing = false;

            // Mouse up means that we want to draw our final result, so we longer need creation shapes.
            CreationDrawable = null;

            // The final drawn result.
            var line = GetDrawableLine(true);

            // Add final result to the Canvas.
            if (line.StartPoint != line.EndPoint)
                Canvas.Drawables.AddLine(line);

            Canvas.Invalidate();
        }

        // Gets the DrawableRLine that is defined by the start position and the current position of the mouse.
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
