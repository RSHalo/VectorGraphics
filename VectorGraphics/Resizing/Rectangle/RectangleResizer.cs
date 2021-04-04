using VectorGraphics.Drawables;

namespace VectorGraphics.Resizing.Rectangle
{
    /// <summary>Base class for rectangle resizers. Responsible for setting the underlying IResizableRectangle that the resizers belong to. This class is abstract.</summary>
    abstract class RectangleResizer : ResizeControl
	{
		/// <summary>The underlying IResizableRectangle that the resize control belongs to.</summary>
		protected readonly IDrawableRectangle _shape;

		/// <summary>The x coordinate of the upper left corner of the underlying IResizableRectangle.</summary>
		protected int RectangleX => _shape.Rectangle.X;

		/// <summary>The y coordinate of the upper left corner of the underlying IResizableRectangle.</summary>
		protected int RectangleY => _shape.Rectangle.Y;

		/// <summary>The height of the underlying IResizableRectangle.</summary>
		protected int RectangleHeight => _shape.Rectangle.Height;

		/// <summary>The width of the underlying IResizableRectangle.</summary>
		protected int RectangleWidth => _shape.Rectangle.Width;

		public RectangleResizer(IDrawableRectangle shape) : base()
		{
			_shape = shape;
		}
	}
}
