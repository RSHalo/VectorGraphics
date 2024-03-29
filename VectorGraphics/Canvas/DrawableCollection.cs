﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VectorGraphics.Drawables;

namespace VectorGraphics.Canvas
{
    /// <summary>Holds the collection of shapes that are to be drawn to a canvas.</summary>
    public class DrawableCollection : IEnumerable<IDrawable>
    {
        private Dictionary<string, IDrawable> _drawables = new Dictionary<string, IDrawable>();
        private readonly List<IDrawable> _selectedShapes = new List<IDrawable>();
        private readonly Dictionary<string, int> _countsByShapeType = new Dictionary<string, int>();

        public event EventHandler SelectedShapeChanged;
        public IEnumerable<IDrawable> SelectedShapes => _selectedShapes;

        public IEnumerator<IDrawable> GetEnumerator() => _drawables.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Clear()
        {
            _drawables.Clear();
            _countsByShapeType.Clear();
        }

        public void AddShape(IDrawable shape)
        {
            int count = IncrementShapeCount(shape);
            shape.Id = shape.IdPrefix + count;
            _drawables[shape.Id] = shape;
        }

        public void DeleteShape(IDrawable shape)
        {
            _drawables.Remove(shape.Id);
            UnselectShape(shape);
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
            foreach (IDrawable shape in _selectedShapes)
            {
                _drawables.Remove(shape.Id);
            }

            UnselectAll();
        }

        protected virtual void OnSelectedShapeChanged()
        {
            SelectedShapeChanged?.Invoke(this, EventArgs.Empty);
        }

        private int IncrementShapeCount(IDrawable shape)
        {
            string key = shape.IdPrefix;
            if (_countsByShapeType.ContainsKey(key))
            {
                _countsByShapeType[key]++;
            }
            else
            {
                _countsByShapeType[key] = 1;
            }

            return _countsByShapeType[key];
        }
    }
}
