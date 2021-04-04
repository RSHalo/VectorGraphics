using System.Drawing;

namespace VectorGraphics.Drawables.Resizable
{
    interface IDrawableRectangle : IDrawable
	{
		Rectangle Rectangle { get; set; }
	}
}
