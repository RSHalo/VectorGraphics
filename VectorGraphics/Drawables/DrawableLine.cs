using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using VectorGraphics.Movement;
using VectorGraphics.Resizing;
using VectorGraphics.Resizing.Line;
using VectorGraphics.Saving;

namespace VectorGraphics.Drawables
{
    public class DrawableLine : IDrawableLine
    {
		public string Id { get; set; }
		public Pen Pen { get; set; }

        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public IShapeSaver SaveBehaviour { get; }
        public IShapeMover MoveBehaviour { get; }

        public DrawableLine(Pen pen, Point startPoint, Point endPoint)
        {
            Pen = pen;
            StartPoint = startPoint;
            EndPoint = endPoint;
            SaveBehaviour = new LineSaver(this);
            MoveBehaviour = new LineMover(this);
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

		public List<ResizeControl> GetResizers()
		{
			// Return two line resizer controls. One for the start of the line, and one for the end of the line.
			return new List<ResizeControl>
			{
				new LineResizer(this, true),
				new LineResizer(this, false)
			};
		}
	}
}
