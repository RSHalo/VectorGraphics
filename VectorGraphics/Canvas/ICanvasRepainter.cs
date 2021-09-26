namespace VectorGraphics.Canvas
{
    /// <summary>An interface for things that cause the canvas to be repainted.</summary>
    interface ICanvasRepainter
    {
        /// <summary>Repaints the canvas.</summary>
        void RepaintCanvas();
    }
}
