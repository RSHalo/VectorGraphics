using System.Collections.Generic;
using VectorGraphics.Drawables;

namespace VectorGraphics.Saving
{
    interface IFileSaver
    {
        /// <summary>Saves drawables to the active file.</summary>
        /// <param name="drawables">The drawables to save.</param>
        void Save(IEnumerable<IDrawable> drawables);

        /// <summary>Saves drawables to a new file, selected by the user.</summary>
        /// <param name="drawables">The drawables to save.</param>
        void SaveAsNewFile(IEnumerable<IDrawable> drawables);

        /// <summary>Sets the active file path that shapes will be saved to.</summary>
        void SetActiveFilePath(string newActiveFilePath);
    }
}