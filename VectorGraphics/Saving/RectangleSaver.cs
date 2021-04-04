using System.Drawing;
using VectorGraphics.Drawables;

namespace VectorGraphics.Saving
{
    class RectangleSaver : IShapeSaver
    {
        private readonly IDrawableRectangle _drawableRectangle;
        protected virtual string ShapeType => "Rectangle";

        public RectangleSaver(IDrawableRectangle drawableRectangle)
        {
            _drawableRectangle = drawableRectangle;
        }

        public ShapeSaveData GetSaveData()
        {
            ShapeSaveData result = new ShapeSaveData(_drawableRectangle)
            {
                ShapeType = ShapeType
            };

            Rectangle rectangle = _drawableRectangle.Rectangle;
            result.ShapeData["X"] = rectangle.X.ToString();
            result.ShapeData["Y"] = rectangle.Y.ToString();
            result.ShapeData["H"] = rectangle.Height.ToString();
            result.ShapeData["W"] = rectangle.Width.ToString();
            return result;
        }
    }
}
