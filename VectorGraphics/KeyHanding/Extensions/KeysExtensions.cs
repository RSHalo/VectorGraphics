using System.Windows.Forms;

namespace VectorGraphics.KeyHanding.Extensions
{
    public static class KeysExtensions
    {
        public static bool IsArrowKey(this Keys keyData)
        {
            Keys keyCode = keyData & Keys.KeyCode;

            if (keyCode == Keys.Up
                || keyCode == Keys.Down
                || keyCode == Keys.Left
                || keyCode == Keys.Right)
            {
                return true;
            }
            return false;
        }
    }
}
