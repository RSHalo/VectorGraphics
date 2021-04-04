using System;
using System.Windows.Forms;
using VectorGraphics.Drawables;
using VectorGraphics.KeyHanding.Extensions;
using VectorGraphics.Movement;

namespace VectorGraphics.KeyHanding
{
    class CanvasKeyHandler : IKeyHandler
    {
        private readonly CanvasControl _canvas;

        public CanvasKeyHandler(CanvasControl canvas)
        {
            _canvas = canvas;
        }

        public void HandleKeyDown(KeyEventArgs e, Keys modifierKeys)
        {
            if (e.KeyData.IsArrowKey())
            {
                HandleArrowKey(e, modifierKeys);
            }
        }

        public void HandleKeyUp(KeyEventArgs e, Keys modifierKeys)
        {
            Keys keyCode = e.KeyCode;
            if (keyCode == Keys.Escape)
            {
                _canvas.Drawables.SelectedShape = null;
            }
        }

        private void HandleArrowKey(KeyEventArgs e, Keys modifierKeys)
        {
            IDrawable selectedShape = _canvas.Drawables.SelectedShape;
            if (selectedShape != null)
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

                _canvas.MoveShape(selectedShape, movementType);
            }
        }
    }
}
