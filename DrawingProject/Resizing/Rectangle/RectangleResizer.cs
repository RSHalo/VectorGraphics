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
		/// <summary>The underlying DrawableRectangle that the resize control belongs to.</summary>
		protected readonly DrawableRectangle _drawnRectangle;

		/// <summary>The x coordinate of the upper left corner of the underlying DrawableRectangle.</summary>
		protected int RectangleX => _drawnRectangle.X;

		/// <summary>The y coordinate of the upper left corner of the underlying DrawableRectangle.</summary>
		protected int RectangleY => _drawnRectangle.Y;

		/// <summary>The height of the underlying DrawableRectangle.</summary>
		protected int RectangleHeight => _drawnRectangle.Height;
		
		/// <summary>The width of the underlying DrawableRectangle.</summary>
		protected int RectangleWidth => _drawnRectangle.Width;

		public RectangleResizer(DrawableRectangle drawableRectangle) : base()
		{
			_drawnRectangle = drawableRectangle;
		}
	}
}
