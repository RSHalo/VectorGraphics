using System.Collections.Generic;
using System.Drawing;
using VectorGraphics.Resizing;
using VectorGraphics.Saving;

namespace VectorGraphics.Drawables
{
    public interface IDrawable
    {
        /// <summary>The shapes unique Id.</summary>
		string Id { get; set; }

        /// <summary>Defines how the drawable must be saved to disk.</summary>
        IShapeSaver SaveBehaviour { get; }

		Pen Pen { get; set; }

		void Draw(Graphics graphics);

        /// <summary>
        /// Tests if the clicked mouse position hits the drawable shape.
        /// </summary>
        /// <param name="worldX">The world X coordiante of the clicked mouse.</param>
        /// <param name="worldY">The world Y coordiante of the clicked mouse.</param>
        /// <returns>True if hit, false otherwise.</returns>
        bool HitTest(int worldX, int worldY);

		List<ResizeControl> GetResizers();
    }
}
