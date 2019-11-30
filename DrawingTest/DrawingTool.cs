using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingTest
{
    abstract class DrawingTool
    {
        public IDrawable DrawResult { get; protected set; }

        public event EventHandler DrawingCreated;

        public virtual void MouseMoved(MouseEventArgs e)
        {

        }

        public virtual void Clicked(MouseEventArgs e)
        {

        }

        protected virtual void OnDrawingCreated()
        {
            DrawingCreated?.Invoke(this, EventArgs.Empty);
        }
    }
}
