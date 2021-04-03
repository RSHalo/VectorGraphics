﻿using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using VectorGraphics.Drawables.Resizable;
using VectorGraphics.Resizing;
using VectorGraphics.Resizing.Rectangle;
using VectorGraphics.Saving;

namespace VectorGraphics.Drawables
{
    public class DrawableEllipse : IDrawable, IResizableRectangle
    {
        private Rectangle _boundingRectangle;

		public string Id { get; set; }
		public Pen Pen { get; set; }
        public Rectangle BoundingRectangle => _boundingRectangle;

        // The rectangle that ResizerControls can modify.
        public Rectangle ResizableRectangle
		{
			get { return _boundingRectangle; }
			set { _boundingRectangle = value; }
		}

        public IShapeSaver SaveBehaviour { get; }

        public DrawableEllipse(Pen pen, Rectangle rectangle)
        {
            Pen = pen;
            _boundingRectangle = rectangle;
            SaveBehaviour = new EllipseSaver(this);
        }

		public void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(Pen, _boundingRectangle);
        }

        public bool HitTest(int worldX, int worldY)
        {
            // A way to detect hits is to define a GraphicsPath that is the same path as the IDrawable and then call IsOutlineVisible with the mouse coordinates
            // as parameters. This is asking "Does the mouse position touch the outline of the GraphicsPath?". In this case, the GraphicsPath is an ellipse.
            var path = new GraphicsPath();
            path.AddEllipse(_boundingRectangle);

            // Give the mouse point a pen width of 10 to make it easier to select lines. A bigger point means we don't have to be as close to the line to select it.
            return path.IsOutlineVisible(worldX, worldY, new Pen(Color.Black, 10));
        }

		public List<ResizeControl> GetResizers()
		{
			return new List<ResizeControl>
			{
				new TopRectangleResizer(this),
				new BottomRectangleResizer(this),
				new LeftRectangleResizer(this),
				new RightRectangleResizer(this)
			};
		}
	}
}
