using DrawingProject.Drawables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProject.Canvas
{
	/// <summary>Holds the collection of shapes that are to be drawn to a canvas.</summary>
	public class DrawableCollection : IEnumerable<IDrawable>
	{
		private List<IDrawable> _drawables = new List<IDrawable>();

		private int _lineCount = 0;
		private int _rectangleCount = 0;
		private int _ellipseCount = 0;

		public IDrawable SelectedShape { get; set; }

		public IEnumerator<IDrawable> GetEnumerator() => _drawables.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public void Clear()
		{
			_drawables.Clear();

			_lineCount = _rectangleCount = _ellipseCount = 0;
		}

		public void AddLine(DrawableLine line)
		{
			line.Id = $"Line{ ++_lineCount }";
			AddShape(line);
		}

		public void AddRectangle(DrawableRectangle rectangle)
		{
			rectangle.Id = $"Rectangle{ ++_rectangleCount }";
			AddShape(rectangle);
		}

		public void AddEllipse(DrawableEllipse ellipse)
		{
			ellipse.Id = $"Ellipse{ ++_ellipseCount }";
			AddShape(ellipse);
		}

		private void AddShape(IDrawable shape)
		{
			_drawables.Add(shape);
			SelectedShape = shape;
		}

		public void DeleteSelectedShape()
		{
			_drawables.Remove(SelectedShape);
			SelectedShape = null;
		}
	}
}
