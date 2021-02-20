using System.Windows.Forms;

namespace VectorGraphics.KeyHanding
{
    interface IKeyHandler
    {
        void HandleKeyUp(KeyEventArgs e, Keys modifierKeys);
        void HandleKeyDown(KeyEventArgs e, Keys modifierKeys);
    }
}
