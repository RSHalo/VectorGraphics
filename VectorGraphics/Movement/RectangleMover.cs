using System;
using System.Drawing;
using VectorGraphics.Drawables.Resizable;

namespace VectorGraphics.Movement
{
    class RectangleMover : ShapeMover
    {
        private readonly IDrawableRectangle _drawableRectangle;

        public RectangleMover(IDrawableRectangle drawableRectangle)
        {
            _drawableRectangle = drawableRectangle;
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

        // We can define rectangle movement just by how the upper left Point moves. Therefore, we just need to provide the amount to move
        // and the point transformation. This transformation will just be a translation in the x or y direction.
        private void Move(int moveBy, Func<Point, int, Point> pointTransformation)
        {
            Rectangle currentRectangle = _drawableRectangle.Rectangle;
            Point newPoint = pointTransformation(currentRectangle.Location, moveBy);
            _drawableRectangle.Rectangle = new Rectangle(newPoint, currentRectangle.Size);
        }
    }
}
