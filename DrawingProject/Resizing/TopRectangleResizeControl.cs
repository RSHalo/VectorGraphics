using DrawingProject.Drawables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProject.Resizing
{
	class TopRectangleResizeControl : ResizeControl
	{
		private readonly DrawableRectangle _drawnRectangle;

		public TopRectangleResizeControl(DrawableRectangle drawableRectangle) : base()
		{
			_drawnRectangle = drawableRectangle;

			WorldX = drawableRectangle.X + (drawableRectangle.Width / 2f) - (DefaultSideLength / 2f);
			WorldY = drawableRectangle.Y - (DefaultSideLength / 2f);
		}

		public override void Rezise()
		{
			throw new NotImplementedException();
		}
	}
}
