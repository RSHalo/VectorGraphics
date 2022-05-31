namespace VectorGraphics.Canvas
{
    public interface ICanvasCommand
    {
        void Execute();

        void Undo();
    }
}
