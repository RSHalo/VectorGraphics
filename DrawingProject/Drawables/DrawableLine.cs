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
    public class DrawableLine : IDrawable
    {
		public string Id { get; set; }
		public Pen Pen { get; set; }

        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public DrawableLine(Pen pen, Point startPoint, Point endPoint)
        {
            Pen = pen;
            StartPoint = startPoint;
            EndPoint = endPoint;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawLine(Pen, StartPoint, EndPoint);
        }

        public bool HitTest(int worldX, int worldY)
        {
            // A way to detect hits is to define a GraphicsPath that is the same path as the IDrawable and then call IsOutlineVisible with the mouse coordinates
            // as parameters. This is asking "Does the mouse position touch the outline of the GraphicsPath?". In this case, the GraphicsPath is just a line.
            var path = new GraphicsPath();
            path.AddLine(StartPoint, EndPoint);

            // Give the mouse point a pen width of 10 to make it easier to select lines. A bigger point means we don't have to be as close to the line to select it.
            return path.IsOutlineVisible(worldX, worldY, new Pen(Color.Black, 10));
        }

		public List<Resizer> GetResizers()
		{
			throw new NotImplementedException();
		}
	}
}
