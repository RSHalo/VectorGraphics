using System.Drawing;

namespace VectorGraphics.Drawables
{
    public interface IDrawableLine : IDrawable
    {
        /// <summary>The line's start point.</summary>
        Point StartPoint { get; set; }

        /// <summary>The line's end point.</summary>
        Point EndPoint { get; set; }
    }
}
