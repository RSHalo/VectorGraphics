using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorGraphics.Drawables;

namespace VectorGraphics.Saving
{
    public class ShapeSaverResult
    {
        /// <summary>The Id of the shape to save.</summary>
        public string ShapeId { get; }

        public string ShapeType { get; set; }

        /// <summary>The pen colour of the shape.</summary>
        public string Colour { get; }

        /// <summary>Attributes to save.</summary>
        public Dictionary<string, string> ShapeData { get; } = new Dictionary<string, string>();

        public ShapeSaverResult(IDrawable shape)
        {
            ShapeId = shape.Id;
            Colour = shape.Pen.Color.ToString();
        }
    }
}
