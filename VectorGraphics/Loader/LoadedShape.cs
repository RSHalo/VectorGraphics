using System.Collections.Generic;

namespace VectorGraphics.Loader
{
    /// <summary>Represents a shape loaded from a shape file.</summary>
    class LoadedShape
    {
        public string ShapeType { get; }
        public Dictionary<string, string> Attributes { get; }

        public LoadedShape(string shapeType, Dictionary<string, string> attributes)
        {
            ShapeType = shapeType;
            Attributes = attributes;
        }
    }
}
