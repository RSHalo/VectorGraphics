using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingProject.Drawables;

namespace DrawingProject.Resizing
{
	class TopRectangleResizer : Resizer
	{
		public IDrawable ParentShape { get; private set; }

		public TopRectangleResizer(DrawableRectangle rectangle)
		{
			ParentShape = rectangle;

			X = rectangle.X + (rectangle.Width / 2f) - (DefaultSideLength / 2f);
			Y = rectangle.Y - (DefaultSideLength / 2f);
		}

		public override void Rezise()
		{
			throw new NotImplementedException();
		}
	}
}
