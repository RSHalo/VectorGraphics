using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorGraphics.Drawables.Resizable;
using VectorGraphics.Resizing;
using VectorGraphics.Resizing.Rectangle;

namespace VectorGraphics.Drawables
{
    public class DrawableEllipse : IDrawable, IResizableRectangle
    {
		// Visual Studio recommends that we turn ResizableRectangle into an auto property. However, I choose to keep the private backing field boundingRectangle.
		// This is because if we ever wanted to remove the resizing functionality from the DrawableEllipse, then we can remove the ResizableRectangle property, leaving all methods
		// still working in terms of boundingRectangle.
        private Rectangle boundingRectangle;

		public string Id { get; set; }
		public Pen Pen { get; set; }

		// The rectangle that ResizerControls can modify.
		public Rectangle ResizableRectangle
		{
			get { return boundingRectangle; }
			set { boundingRectangle = value; }
		}

		public DrawableEllipse(Pen pen, Rectangle rectangle)
        {
            Pen = pen;
            boundingRectangle = rectangle;
        }

		public void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(Pen, boundingRectangle);
        }

        public bool HitTest(int worldX, int worldY)
        {
            // A way to detect hits is to define a GraphicsPath that is the same path as the IDrawable and then call IsOutlineVisible with the mouse coordinates
            // as parameters. This is asking "Does the mouse position touch the outline of the GraphicsPath?". In this case, the GraphicsPath is an ellipse.
            var path = new GraphicsPath();
            path.AddEllipse(boundingRectangle);

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
