using VectorGraphics.Canvas;
using VectorGraphics.Drawables;

namespace VectorGraphics.Tools.Commands
{
    internal class AddShapeCommand : ICanvasCommand
    {
        private readonly ICanvas _canvas;
        private readonly IDrawable _newShape;

        public AddShapeCommand(ICanvas canvas, IDrawable newShape)
        {
            _canvas = canvas;
            _newShape = newShape;
        }

        public void Execute()
        {
            _canvas.AddShape(_newShape);
        }

        public void Undo()
        {
            _canvas.DeleteShape(_newShape);
        }
    }
}
