using VectorGraphics.Drawables;

namespace VectorGraphics.Saving
{
    class EllipseSaver : RectangleSaver
    {
        protected override string ShapeType => "Ellipse";

        public EllipseSaver(IDrawableRectangle drawableRectangle) : base(drawableRectangle)
        {
        }
    }
}
