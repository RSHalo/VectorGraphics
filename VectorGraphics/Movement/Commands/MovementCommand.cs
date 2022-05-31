using VectorGraphics.Canvas;

namespace VectorGraphics.Movement.Commands
{
    /// <summary>
    /// A command to move a shape across the canvas.
    /// </summary>
    public class MoveCommand : ICanvasCommand
    {
        private readonly IShapeMover _shapeMover;
        private readonly MovementType _movementType;

        public MoveCommand(IShapeMover shapeMover, MovementType movementType)
        {
            _shapeMover = shapeMover;
            _movementType = movementType;
        }

        public void Execute()
        {
            _shapeMover.Move(_movementType);
        }

        public void Undo()
        {
            MovementType movementType = ReverseMovementType(_movementType);
            _shapeMover.Move(movementType);
        }

        private static MovementType ReverseMovementType(MovementType originalMovement)
        {
            // Find the opposite movement from the original movement.
            // This could be more elegant, perhaps by using some more enum manipulation.

            MovementType oldDirection = originalMovement & MovementType.Movement;
            MovementType newMovement = MovementType.Movement;
            switch (oldDirection)
            {
                case MovementType.Up:
                    newMovement = MovementType.Down;
                    break;

                case MovementType.Down:
                    newMovement = MovementType.Up;
                    break;

                case MovementType.Left:
                    newMovement = MovementType.Right;
                    break;

                case MovementType.Right:
                    newMovement = MovementType.Left;
                    break;
            }

            if (originalMovement.HasFlag(MovementType.SingleUnit))
            {
                newMovement |= MovementType.SingleUnit;
            }

            return newMovement;
        }
    }
}
