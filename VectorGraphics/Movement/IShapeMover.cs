namespace VectorGraphics.Movement
{
    /// <summary>Moves shapes.</summary>
    public interface IShapeMover
    {
        /// <summary>Moves a shape.</summary>
        /// <param name="movementType">The type of movement to perform.</param>
        void MoveShape(MovementType movementType);
    }
}