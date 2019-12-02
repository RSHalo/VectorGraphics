using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingProject
{
    class Tool
    {
        public Canvas Canvas { get; set; }
        public bool IsDrawing { get; protected set; }

        // The shape to be drawn while the tool is creating a final result.
        // E.g. The rectangle that moves along with the mouse when you are drawing a rectangle.
        public IDrawable CreationDrawable { get; protected set; }

        public virtual void MouseDown(MouseEventArgs e)
        {

        }

        public virtual void MouseMoved(MouseEventArgs e)
        {

        }

        public virtual void MouseUp(MouseEventArgs e)
        {

        }

        public virtual void Clicked(MouseEventArgs e)
        {

        }
    }
}
