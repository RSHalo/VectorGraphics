using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VectorGraphics.Canvas;
using VectorGraphics.Drawables;
using VectorGraphics.KeyHanding.Extensions;
using VectorGraphics.Movement;
using VectorGraphics.Movement.Commands;

namespace VectorGraphics.KeyHanding
{
    class CanvasKeyHandler : IKeyHandler
    {
        private readonly ICanvas _canvas;

        public CanvasKeyHandler(ICanvas canvas)
        {
            _canvas = canvas;
        }

        public void HandleKeyDown(KeyEventArgs e, Keys modifierKeys)
        {
            if (e.KeyData.IsArrowKey())
            {
                HandleArrowKey(e, modifierKeys);
            }

            if (e.KeyCode == Keys.ControlKey)
            {
                _canvas.Tool.IsControlHeld = true;
            }

            if (modifierKeys.HasFlag(Keys.Control))
            {
                switch (e.KeyCode)
                {
                    // Undo the last operation.
                    case Keys.Z:
                        _canvas.UndoCommand();
                        break;
                }
            }
        }

        public void HandleKeyUp(KeyEventArgs e, Keys modifierKeys)
        {
            Keys keyCode = e.KeyCode;
            if (keyCode == Keys.Escape)
            {
                _canvas.Drawables.UnselectAll();
            }

            if (keyCode == Keys.ControlKey)
            {
                _canvas.Tool.IsControlHeld = false;
            }
            else if (keyCode == Keys.Delete && _canvas.Tool.IsDrawing == false)
            {
                _canvas.DeleteSelectedShapes();
            }
        }

        private void HandleArrowKey(KeyEventArgs e, Keys modifierKeys)
        {
            IEnumerable<IDrawable> selectedShapes = _canvas.Drawables.SelectedShapes;
            if (selectedShapes.Any())
            {
                MovementType movementType = DetermineMovementType(e, modifierKeys);

                AggregateCommand aggregateCommand = new AggregateCommand();
                foreach (IDrawable selectedShape in selectedShapes)
                {
                    IShapeMover mover = selectedShape.MoveBehaviour;
                    MoveCommand moveCommand = new MoveCommand(mover, movementType);
                    aggregateCommand.Add(moveCommand);
                }

                _canvas.ExecuteCommand(aggregateCommand);
            }
        }

        private MovementType DetermineMovementType(KeyEventArgs e, Keys modifierKeys)
        {
            MovementType movementType;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    movementType = MovementType.Up;
                    break;

                case Keys.Down:
                    movementType = MovementType.Down;
                    break;

                case Keys.Left:
                    movementType = MovementType.Left;
                    break;

                case Keys.Right:
                    movementType = MovementType.Right;
                    break;

                default:
                    throw new Exception("Unexpected movement type.");
            }

            // If the Control key was held, then we make the unit of movement smaller, for more precise movement.
            if (modifierKeys.HasFlag(Keys.Control))
            {
                movementType |= MovementType.SingleUnit;
            }

            return movementType;
        }
    }
}
