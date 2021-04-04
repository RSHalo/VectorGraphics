using System;
using System.Drawing;
using VectorGraphics.Drawables;

namespace VectorGraphics.Movement
{
    class LineMover : ShapeMover
    {
        private readonly DrawableLine _line;

        public LineMover(DrawableLine line)
        {
            _line = line;
        }

        protected override void MoveDown()
        {
            throw new NotImplementedException();
        }

        protected override void MoveLeft()
        {
            throw new NotImplementedException();
        }

        protected override void MoveRight()
        {
            throw new NotImplementedException();
        }

        protected override void MoveUp()
        {
            _line.StartPoint = MoveY(_line.StartPoint, -10);
            _line.EndPoint = MoveY(_line.EndPoint, -10);
        }

        private Point MoveY(Point sourcePoint, int moveBy)
        {
            sourcePoint.Y += moveBy;
            return sourcePoint;
        }
    }
}
