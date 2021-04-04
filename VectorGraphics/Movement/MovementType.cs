using System;

namespace VectorGraphics.Movement
{
    [Flags]
    public enum MovementType
    {
        Up = 1,
        Down = 2,
        Left = 4,
        Right = 8,

        // 15 is 1111b so it acts as a way to select the movement type without the SingleUnit bit.
        Movement = 15,
        SingleUnit = 16,
    }
}
