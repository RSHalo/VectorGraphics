namespace VectorGraphics.Saving
{
    /// <summary>Provides data for saving shapes.</summary>
    public interface IShapeSaver
    {
        /// <summary>Returns a <see cref="ShapeSaveData"/> for saving.</summary>
        ShapeSaveData GetSaveData();
    }
}
