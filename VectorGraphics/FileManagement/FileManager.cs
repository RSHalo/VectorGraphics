using VectorGraphics.Canvas;
using VectorGraphics.Loader;
using VectorGraphics.Saving;

namespace VectorGraphics.FileManagement
{
    /// <summary>Acts as a communication point for saving and loading.</summary>
    class FileManager
    {
        private const string FileFilter = "Shape Files(*.xml)|*.xml";

        private readonly IFileSaver _saver;
        private readonly IFileLoader _loader;
        
        /// <summary>
        /// Whether the current drawing has been saved to a file before. We track this so that a SaveFileDialog isn't shown everytime.
        /// This state is not stored directly in an IFileSaver because the IFileLoader also affects this state. Therefore, I've added this FileManager to store it.
        /// </summary>
        private bool _currentDrawingHasFile = false;

        public FileManager()
        {
            _saver = new FileSaver(FileFilter);
            _loader = new FileLoader(FileFilter);
        }

        public void Save(DrawableCollection drawables)
        {
            if (_currentDrawingHasFile)
            {
                _saver.Save(drawables);
            }
            else
            {
                _saver.SaveAsNewFile(drawables);
                _currentDrawingHasFile = true;
            }
        }

        public void Load(CanvasControl canvas)
        {
            _loader.Load(canvas);
            if (_loader.Loaded)
            {
                // Set the saver's file path so that subsequent saves will save to the file that was just loaded.
                _saver.SetActiveFilePath(_loader.LoadedFilePath);
                
                // Since we have loaded a file, we know that the current drawing now has a file.
                _currentDrawingHasFile = true;
            }
        }
    }
}
