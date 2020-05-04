using DrawingProject.Resizing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProject.Drawables
{
    public interface IDrawable
    {
		string Id { get; set; }

		Pen Pen { get; set; }

		void Draw(Graphics graphics);

        /// <summary>
        /// Tests if the clicked mouse position hits the drawable shape.
        /// </summary>
        /// <param name="worldX">The world X coordiante of the clicked mouse.</param>
        /// <param name="worldY">The world Y coordiante of the clicked mouse.</param>
        /// <returns>True if hit, false otherwise.</returns>
        bool HitTest(int worldX, int worldY);

		List<Resizer> GetResizers();
    }
}
