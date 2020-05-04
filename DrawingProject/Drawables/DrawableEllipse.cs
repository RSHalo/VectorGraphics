using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingProject.Resizing;

namespace DrawingProject.Drawables
{
    public class DrawableEllipse : IDrawable
    {
        private Rectangle boundingRectangle;
		public string Id { get; set; }
		public Pen Pen { get; set; }

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

		public List<IResizer> GetResizers()
		{
			throw new NotImplementedException();
		}
	}
}
