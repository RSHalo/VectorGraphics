using System.Windows.Forms;

namespace VectorGraphics.KeyHanding.Extensions
{
    public static class KeyDataExtensions
    {
        public static bool IsArrowKey(this Keys keyData)
        {
            if (keyData.HasFlag(Keys.Up)
                || keyData.HasFlag(Keys.Down)
                || keyData.HasFlag(Keys.Left)
                || keyData.HasFlag(Keys.Right))
            {
                return true;
            }
            return false;
        }
    }
}
