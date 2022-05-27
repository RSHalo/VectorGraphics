﻿using System.Drawing;
using VectorGraphics.Drawables;
using VectorGraphics.Movement;
using VectorGraphics.Tools;

namespace VectorGraphics.Canvas
{
    public interface ICanvas
    {
        /// <summary>The tool selected by the user.</summary>
        Tool Tool { get; }

        /// <summary>The drawable shapes that need to be drawn when the Canvas is painted.</summary>
        DrawableCollection Drawables { get; }

        /// <summary>The X offset from the page co-ordinates to the world co-ordinates.</summary>
        float OffsetX { get; set; }
        /// <summary>The Y offset from the page co-ordinates to the world co-ordinates.</summary>
        float OffsetY { get; set; }

        /// <summary>Adds a new shape to the canvas.</summary>
        /// <param name="shape">The shape to add.</param>
        void AddShape(IDrawable shape);

        /// <summary>Delete the shapes that are currently selected.</summary>
        void DeleteSelectedShapes();

        /// <summary>Moves a shape.</summary>
        /// <param name="shape">The shape to move.</param>
        /// <param name="movementType">The <see cref="MovementType"/>.</param>
        void MoveShape(IDrawable shape, MovementType movementType);

        /// <summary>Repaints the canvas.</summary>
        void Repaint();

        /// <summary>Gets corresponding world coordinates, given screen coordinates.</summary>
        PointF ScreenToWorld(float screenX, float screenY);
    }
}