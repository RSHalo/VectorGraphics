using System;
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
            if (e.KeyCode == Keys.ControlKey)
            {
                _view.Tool.IsControlHeld = true;
            }
        }

        public void HandleKeyUp(KeyEventArgs e, Keys modifierKeys)
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

            if (keyCode == Keys.ControlKey)
            {
                _view.Tool.IsControlHeld = false;
            }
            else if (keyCode == Keys.Delete && _view.Tool.IsDrawing == false)
            {
                _view.DeleteSelectedShape();
            }
            else if (keyCode == Keys.Escape)
            {
                _view.CancelShapeSelection();
            }
        }
    }
}
