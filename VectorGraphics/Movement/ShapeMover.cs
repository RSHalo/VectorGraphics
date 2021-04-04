using System;

namespace VectorGraphics.Movement
{
    abstract class ShapeMover : IShapeMover
    {
        public void MoveShape(MovementType movementType)
        {
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

        protected abstract void MoveUp();
        protected abstract void MoveDown();
        protected abstract void MoveLeft();
        protected abstract void MoveRight();
    }
}
