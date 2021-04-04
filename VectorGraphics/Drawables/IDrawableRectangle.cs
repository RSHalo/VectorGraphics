using System.Drawing;

namespace VectorGraphics.Drawables
{
    interface IDrawableRectangle : IDrawable
	{
		Rectangle Rectangle { get; set; }
	}
}
