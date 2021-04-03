using VectorGraphics.Drawables;

namespace VectorGraphics.Saving
{
    class EllipseSaver : IShapeSaver
    {
        private readonly DrawableEllipse _ellipse;

        public EllipseSaver(DrawableEllipse ellipse)
        {
            _ellipse = ellipse;
        }

        public ShapeSaveData GetSaveData()
        {
            ShapeSaveData result = new ShapeSaveData(_ellipse)
            {
                ShapeType = "Ellipse"
            };
            result.ShapeData["X"] = _ellipse.BoundingRectangle.X.ToString();
            result.ShapeData["Y"] = _ellipse.BoundingRectangle.Y.ToString();
            result.ShapeData["H"] = _ellipse.BoundingRectangle.Height.ToString();
            result.ShapeData["W"] = _ellipse.BoundingRectangle.Width.ToString();
            return result;
        }
    }
}
