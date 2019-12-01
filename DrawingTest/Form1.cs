using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingTest
{
    public partial class Form1 : Form
    {
        // TODO: Research 2d scene graph.
        // TODO: Tidy up and make some more comments and ask reddit about how to design tool behaviour.

        // The tool selected by the user.
        Tool Tool = new Tool();

        public Form1()
        {
            InitializeComponent();
        }

        #region Button Clicks
        private void RbFixedLine_CheckedChanged(object sender, EventArgs e)
        {
            Tool = new FixedLineTool
            {
                Canvas = cnvsMain
            };
        }

        private void RbFixedRectangle_CheckedChanged(object sender, EventArgs e)
        {
            Tool = new FixedRectangleTool
            {
                Canvas = cnvsMain
            };
        }

        private void RbFreeRectangle_CheckedChanged(object sender, EventArgs e)
        {
            Tool = new RectangleTool
            {
                Canvas = cnvsMain
            };
        }
        #endregion

        private void CnvsMain_Paint(object sender, PaintEventArgs e)
        {
            // All drawing happens when this Canvas is painted on the screen.
            // You don't just draw a line and expect it to persist. The drawing will dissapear when you minimise then maximise the form.
            // So, if we do all drawing when the containing Panel is drawn, then any time we can see our Panel, all our lines/rectangles will have been drawn too.
            // This is a very important concept. When you want to research, do a Google search like: "Drawing Paint event", "Drawing OnPaint override".

            foreach (IDrawable drawable in cnvsMain.Drawables)
            {
                drawable.Draw(e.Graphics);
            }

            if (Tool.IsDrawing)
                Tool.CreationDrawable?.Draw(e.Graphics);
        }

        private void CnvsMain_MouseDown(object sender, MouseEventArgs e)
        {
            Tool.MouseDown(e);
        }

        private void CnvsMain_MouseMove(object sender, MouseEventArgs e)
        {
            lblCursorPos.Text = $"X: { e.X }, Y: { e.Y }";

            Tool.MouseMoved(e);
        }

        private void CnvsMain_MouseClick(object sender, MouseEventArgs e)
        {
            Tool.Clicked(e);
        }

        private void CnvsMain_MouseUp(object sender, MouseEventArgs e)
        {
            Tool.MouseUp(e);
        }

        private void CnvsMain_MouseLeave(object sender, EventArgs e)
        {
            lblCursorPos.ResetText();
        }
    }
}
