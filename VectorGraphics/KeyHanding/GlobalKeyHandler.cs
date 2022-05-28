using System.Windows.Forms;
using VectorGraphics.View;

namespace VectorGraphics.KeyHanding
{
    class GlobalKeyHandler : IKeyHandler
    {
        private readonly IProgramView _view;

        public GlobalKeyHandler(IProgramView view)
        {
            _view = view;
        }

        public void HandleKeyDown(KeyEventArgs e, Keys modifierKeys)
        {
            Keys keyCode = e.KeyCode;
            if (modifierKeys.HasFlag(Keys.Control))
            {
                switch (keyCode)
                {
                    case Keys.S:
                        _view.Save();
                        break;

                    case Keys.O:
                        _view.Open();
                        break;
                }
            }
        }

        public void HandleKeyUp(KeyEventArgs e, Keys modifierKeys)
        {
            
        }
    }
}
