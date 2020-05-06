using DrawingProject.Drawables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProject.Resizing.Rectangle
{
	/// <summary>Base class for rectangle resizers. Responsible for setting the underlying DrawabaleRectangle that the resizers belong to. This class is abstract.</summary>
	abstract class RectangleResizer : ResizeControl
	{
		protected readonly DrawableRectangle _drawnRectangle;

		public RectangleResizer(DrawableRectangle drawableRectangle) : base()
		{
			_drawnRectangle = drawableRectangle;
		}
	}
}
