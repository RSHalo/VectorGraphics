using VectorGraphics.Drawables;
using VectorGraphics.Drawables.Resizable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorGraphics.Resizing.Rectangle
{
	/// <summary>Base class for rectangle resizers. Responsible for setting the underlying IResizableRectangle that the resizers belong to. This class is abstract.</summary>
	abstract class RectangleResizer : ResizeControl
	{
		/// <summary>The underlying IResizableRectangle that the resize control belongs to.</summary>
		protected readonly IResizableRectangle _shape;

		/// <summary>The x coordinate of the upper left corner of the underlying IResizableRectangle.</summary>
		protected int RectangleX => _shape.ResizableRectangle.X;

		/// <summary>The y coordinate of the upper left corner of the underlying IResizableRectangle.</summary>
		protected int RectangleY => _shape.ResizableRectangle.Y;

		/// <summary>The height of the underlying IResizableRectangle.</summary>
		protected int RectangleHeight => _shape.ResizableRectangle.Height;

		/// <summary>The width of the underlying IResizableRectangle.</summary>
		protected int RectangleWidth => _shape.ResizableRectangle.Width;

		public RectangleResizer(IResizableRectangle shape) : base()
		{
			_shape = shape;
		}
	}
}
