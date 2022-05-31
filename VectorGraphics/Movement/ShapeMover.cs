using System;
using System.Drawing;

namespace VectorGraphics.Movement
{
    public abstract class ShapeMover : IShapeMover
    {
        protected int AbsoluteMoveUnit { get; private set; } = 10;

        public void Move(MovementType movementType)
        {
            DetermineMoveUnit(movementType);

            movementType &= MovementType.Movement;
            switch (movementType)
            {
                case MovementType.Up:
                    MoveUp();
                    break;

                case MovementType.Down:
                    MoveDown();
                    break;

                case MovementType.Left:
                    MoveLeft();
                    break;

                case MovementType.Right:
                    MoveRight();
                    break;

                default:
                    throw new Exception("Unexpected movement type.");
            }
        }

        /// <summary>Creates a new Point by moving the given Point in the x-direction.</summary>
        /// <param name="sourcePoint">The original Point to move.</param>
        /// <param name="moveBy">The amount to the move the source Point.</param>
        /// <returns>The new Point.</returns>
        protected Point MovePointX(Point sourcePoint, int moveBy)
        {
            sourcePoint.X += moveBy;
            return sourcePoint;
        }

        /// <summary>Creates a new Point by moving the given point in the y-direction.</summary>
        /// <param name="sourcePoint">The original Point to move.</param>
        /// <param name="moveBy">The amount to the move the source Point.</param>
        /// <returns>The new Point.</returns>
        protected Point MovePointY(Point sourcePoint, int moveBy)
        {
            sourcePoint.Y += moveBy;
            return sourcePoint;
        }

        private void DetermineMoveUnit(MovementType movementType)
        {
            if (movementType.HasFlag(MovementType.SingleUnit))
            {
                AbsoluteMoveUnit = 1;
            }
            else
            {
                AbsoluteMoveUnit = 10;
            }
        }

        protected abstract void MoveUp();
        protected abstract void MoveDown();
        protected abstract void MoveLeft();
        protected abstract void MoveRight();
    }
}
