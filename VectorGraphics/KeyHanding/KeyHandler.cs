using System.Windows.Forms;
using VectorGraphics.View;

namespace VectorGraphics.KeyHanding
{
    class KeyHandler : IKeyHandler
    {
        private readonly IProgramView _view;

        public KeyHandler(IProgramView view)
        {
            _view = view;
        }

        public void HandleKeyDown(KeyEventArgs e, Keys modifierKeys)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                _view.Tool.IsControlHeld = true;
            }
        }

        public void HandleKeyUp(KeyEventArgs e, Keys modifierKeys)
        {
            if (modifierKeys.HasFlag(Keys.Control))
            {
                switch (e.KeyCode)
                {
                    case Keys.S:
                        _view.Save();
                        break;

                    case Keys.O:
                        _view.Open();
                        break;
                }
            }

            if (e.KeyCode == Keys.ControlKey)
            {
                _view.Tool.IsControlHeld = false;
            }
            else if (e.KeyCode == Keys.Delete && _view.Tool.IsDrawing == false)
            {
                _view.DeleteSelectedShape();
            }
        }
    }
}
