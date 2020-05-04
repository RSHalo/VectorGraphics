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
		public IDrawable ParentShape { get; private set; }

		public TopLeftRectangleResizer(DrawableRectangle rectangle)
		{
			ParentShape = rectangle;
		}

		public void Rezise()
		{
			throw new NotImplementedException();
		}
	}
}
