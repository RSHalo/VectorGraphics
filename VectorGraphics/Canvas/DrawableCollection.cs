using VectorGraphics.Drawables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorGraphics.Canvas
{
	/// <summary>Holds the collection of shapes that are to be drawn to a canvas.</summary>
	public class DrawableCollection : IEnumerable<IDrawable>
	{
		private readonly List<IDrawable> _drawables = new List<IDrawable>();

		private int _lineCount = 0;
		private int _rectangleCount = 0;
		private int _ellipseCount = 0;

		public event EventHandler SelectedShapeChanged;

		private IDrawable _selectedShape;

		public IDrawable SelectedShape
		{
			get => _selectedShape;

			set
			{
				_selectedShape = value;
				SelectedShapeChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public IEnumerator<IDrawable> GetEnumerator() => _drawables.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public void Clear()
		{
			_drawables.Clear();
			_lineCount = _rectangleCount = _ellipseCount = 0;
		}

		public void AddLine(IDrawable line)
		{
			line.Id = $"Line{ ++_lineCount }";
			AddShape(line);
		}

		public void AddRectangle(IDrawable rectangle)
		{
			rectangle.Id = $"Rectangle{ ++_rectangleCount }";
			AddShape(rectangle);
		}

		public void AddEllipse(IDrawable ellipse)
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

			// List<T>.Remove doesn't throw an exception when SelectedShape is null. I don't think I will add a null check here.
		}
	}
}
