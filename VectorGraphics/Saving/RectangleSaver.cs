using VectorGraphics.Drawables;

namespace VectorGraphics.Saving
{
    class RectangleSaver : IShapeSaver
    {
        private readonly DrawableRectangle _rectangle;

        public RectangleSaver(DrawableRectangle rectangle)
        {
            _rectangle = rectangle;
        }

        public ShapeSaveData GetSaveData()
        {
            ShapeSaveData result = new ShapeSaveData(_rectangle)
            {
                ShapeType = "Rectangle"
            };
            result.ShapeData["X"] = _rectangle.X.ToString();
            result.ShapeData["Y"] = _rectangle.Y.ToString();
            result.ShapeData["H"] = _rectangle.Height.ToString();
            result.ShapeData["W"] = _rectangle.Width.ToString();
            return result;
        }
    }
}
