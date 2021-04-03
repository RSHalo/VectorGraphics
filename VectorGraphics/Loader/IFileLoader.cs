namespace VectorGraphics.Loader
{
    interface IFileLoader
    {
        /// <summary>Whether a file was loaded during the last load request.</summary>
        bool Loaded { get; }
        
        /// <summary>The path to the file that was last loaded.</summary>
        string LoadedFilePath { get; }

        /// <summary>Loads a shape file to a canavs.</summary>
        /// <param name="canvas">The canvas to load the shapes to.</param>
        void Load(CanvasControl canvas);
    }
}
