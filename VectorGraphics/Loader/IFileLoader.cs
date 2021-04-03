namespace VectorGraphics.Loader
{
    interface IFileLoader
    {
        /// <summary>Loads a shape file to a canavs.</summary>
        /// <param name="canvas">The canvas to load the shapes to.</param>
        void Load(CanvasControl canvas);
    }
}
