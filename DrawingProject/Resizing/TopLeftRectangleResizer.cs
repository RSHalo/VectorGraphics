using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingProject.Drawables;

namespace DrawingProject.Resizing
{
	class TopLeftRectangleResizer : IResizer
	{
		public int X { get; }
		public int Y { get; }

		public IDrawable ParentShape { get; private set; }

		public TopLeftRectangleResizer(DrawableRectangle rectangle, int worldX, int worldY)
		{
			ParentShape = rectangle;
			X = worldX;
			Y = worldY;
		}

		public void Rezise()
		{
			throw new NotImplementedException();
		}
	}
}
