using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VectorGraphics.Drawables;

namespace VectorGraphics.Canvas
{
    /// <summary>Holds the collection of shapes that are to be drawn to a canvas.</summary>
    public class DrawableCollection : IEnumerable<IDrawable>
    {
        private List<IDrawable> _drawables = new List<IDrawable>();
        private readonly List<IDrawable> _selectedShapes = new List<IDrawable>();

        private int _lineCount = 0;
        private int _rectangleCount = 0;
        private int _ellipseCount = 0;

        public event EventHandler SelectedShapeChanged;
        public IEnumerable<IDrawable> SelectedShapes => _selectedShapes;

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
            SelectSingleShape(shape);
        }

        /// <summary>Adds the shape to the currently selected shapes.</summary>
        /// <param name="shape">The shape to add to the selected.</param>
        public void SelectShape(IDrawable shape)
        {
            _selectedShapes.Add(shape);
            OnSelectedShapeChanged();
        }

        /// <summary>Un-selects all shapes, then selects the given shape.</summary>
        /// <param name="shape">The shape to select.</param>
        public void SelectSingleShape(IDrawable shape)
        {
            UnselectAll();
            SelectShape(shape);
        }

        /// <summary>Un-selects a shape.</summary>
        /// <param name="shape">The shape to un-select.</param>
        public void UnselectShape(IDrawable shape)
        {
            _selectedShapes.Remove(shape);
            OnSelectedShapeChanged();
        }

        /// <summary>Un-selects all shapes that are selected.</summary>
        public void UnselectAll()
        {
            _selectedShapes.Clear();
            OnSelectedShapeChanged();
        }

        /// <summary>Delete the selected shapes.</summary>
        public void DeleteSelectedShapes()
        {
            _drawables = _drawables.Except(_selectedShapes).ToList();
            UnselectAll();
        }

        protected virtual void OnSelectedShapeChanged()
        {
            SelectedShapeChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
