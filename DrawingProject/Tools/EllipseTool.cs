﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrawingProject.Drawables;

namespace DrawingProject.Tools
{
    class EllipseTool : Tool
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

            if (!IsDrawing)
                return;

            CreationDrawable = GetEllipse();
            Canvas.Invalidate();
        }

        public override void MouseUp(MouseEventArgs e)
        {
            if (!IsDrawing)
                return;

            IsDrawing = false;

            CreationDrawable = null;

            if (startPoint != currentPoint)
            {
                var ellipse = GetEllipse(true);
                Canvas.Drawables.Add(ellipse);
            }

            Canvas.Invalidate();
        }

        private DrawableEllipse GetEllipse(bool finalResult = false)
        {
            // Get the bounding rectangle
            var rectangle = GetBoundingRectangle();

            // Make the creation shapes and the final shape different colors. Give creation shape a dashed line.
            Pen pen = finalResult ?
                                   Pens.DarkGreen :
                                   new Pen(Color.Black)
                                   {
                                       DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
                                   };

            return new DrawableEllipse(pen, rectangle);
        }

        // Create the bounding rectangle that is used to create a Drawable Ellipse.
        private Rectangle GetBoundingRectangle()
        {
            int width = startPoint.X - currentPoint.X;
            int height = startPoint.Y - currentPoint.Y;

            // Draw a circle if Control key is held. Therefore, width and length of bounding rectangle are equal, to make a square.
            if (IsControlHeld)
                width = height = Math.Max(width, height);

            return new Rectangle(
                Math.Min(startPoint.X, currentPoint.X),
                Math.Min(startPoint.Y, currentPoint.Y),
                Math.Abs(width),
                Math.Abs(height));
        }
    }
}