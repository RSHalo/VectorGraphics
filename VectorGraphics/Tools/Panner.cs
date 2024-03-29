﻿using System.Drawing;
using System.Windows.Forms;

namespace VectorGraphics.Tools
{
    /// <summary>Pans around the world space by manipulating the Canvas' Page-to-World offset.</summary>
    class Panner : Tool
    {
        private bool isPanning = false;
        private Point lastPoint;
        private Point currentPoint;

        public Panner() : base()
        {
            Cursor = Cursors.SizeAll;
        }

        public override void MouseDown(MouseEventArgs e)
        {
            isPanning = true;
            lastPoint = currentPoint = new Point(e.X, e.Y);
        }

        public override void MouseMoved(MouseEventArgs e)
        {
            if (isPanning)
            {
                // Get the current position of the mouse and calculate how far the mouse has moved.
                // We can work in screen coords here. This is because we want to move the world by the number of pixels the mouse moves. World coords are irrelevant.
                currentPoint = new Point(e.X, e.Y);
                float distancePannedX = currentPoint.X - lastPoint.X;
                float distancePannedY = currentPoint.Y - lastPoint.Y;

                // Update the Canvas' offset so that the world appears to move according to the mouse movement.
                Canvas.OffsetX += distancePannedX;
                Canvas.OffsetY += distancePannedY;

                // Update for next time this Event Handler is called.
                lastPoint = currentPoint;

                RepaintCanvas();
            }
        }

        public override void MouseUp(MouseEventArgs e)
        {
            isPanning = false;
        }
    }
}
