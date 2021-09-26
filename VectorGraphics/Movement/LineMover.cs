using System;
using System.Drawing;
using VectorGraphics.Drawables;

namespace VectorGraphics.Movement
{
    class LineMover : ShapeMover
    {
        private readonly IDrawableLine _line;

        public LineMover(IDrawableLine line)
        {
            _line = line;
        }

        protected override void MoveDown()
        {
            Move(AbsoluteMoveUnit, MovePointY);
        }

        protected override void MoveLeft()
        {
            Move(-AbsoluteMoveUnit, MovePointX);
        }

        protected override void MoveRight()
        {
            Move(AbsoluteMoveUnit, MovePointX);
        }

        protected override void MoveUp()
        {
            Move(-AbsoluteMoveUnit, MovePointY);
        }

        private void Move(int moveBy, Func<Point, int, Point> pointTransformation)
        {
            _line.StartPoint = pointTransformation(_line.StartPoint, moveBy);
            _line.EndPoint = pointTransformation(_line.EndPoint, moveBy);
        }
    }
}
