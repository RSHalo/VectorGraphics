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


        readonly List<IDrawable> drawables = new List<IDrawable>
        {
            new DrawableLine(Pens.Red, new Point(10, 10), new Point(50, 50)),
            new DrawableLine(Pens.Red, new Point(100, 150), new Point(200, 200))
        };

        public Form1()
        {
            InitializeComponent();
        }

        Rectangle hoverRectangle = new Rectangle();

        #region Button Clicks
        private void BtnDrawLine_Click(object sender, EventArgs e)
        {
            DrawableLine line = new DrawableLine(new Pen(Color.Blue), new Point(75, 50), new Point(30, 80));
            drawables.Add(line);

            // Invalidate causes the control to be redrawn.
            // As we said before, we want the panel to be redrawn so that all of our drawings will be redrawn.
            cnvsMain.Invalidate();
        }

        private void BtnDrawThickLine_Click(object sender, EventArgs e)
        {
            DrawableLine line = new DrawableLine(new Pen(Color.Blue, 2), new Point(175, 150), new Point(130, 180));
            drawables.Add(line);

            cnvsMain.Invalidate();
        }

        private void BtnDrawRectangle_Click(object sender, EventArgs e)
        {
            DrawableRectangle rectangle = new DrawableRectangle(Pens.Coral, 105, 30, 75, 20);
            drawables.Add(rectangle);

            cnvsMain.Invalidate();
        }
        #endregion

        private void PnlDrawingSurface_MouseMove(object sender, MouseEventArgs e)
        {
            // Update the X,Y coordinates shown by the label. This is purely cosmetic.
            var mousePos = cnvsMain.PointToClient(Cursor.Position);
            lblCursorPos.Text = $"X: { mousePos.X }, Y: { mousePos.Y }";
        }

        private void PnlDrawingSurface_MouseLeave(object sender, EventArgs e)
        {
            lblCursorPos.ResetText();
        }

        private void CnvsMain_Paint(object sender, PaintEventArgs e)
        {
            // All drawing happens when this Panel is painted on the screen.
            // You don't just draw a line and expect it to persist. The drawing will dissapear when you minimise then maximise the form.
            // So, if we do all drawing when the containing Panel is drawn, then any time we can see our Panel, all our lines/rectangles will have been drawn too.
            // This is a very important concept. When you want to research, do a Google search like: "Drawing Paint event", "Drawing OnPaint override".

            foreach (IDrawable drawable in drawables)
            {
                drawable.Draw(e.Graphics);
            }
            
            e.Graphics.DrawRectangle(Pens.Red, hoverRectangle);
        }

        private void CnvsMain_MouseMove(object sender, MouseEventArgs e)
        {
            var mousePos = cnvsMain.PointToClient(Cursor.Position);
            hoverRectangle.Width = mousePos.X;
            hoverRectangle.Height = mousePos.Y;

            cnvsMain.Invalidate();
        }

        private void CnvsMain_MouseClick(object sender, MouseEventArgs e)
        {
            drawables.Add(new DrawableRectangle(Pens.Red, hoverRectangle));

            cnvsMain.Invalidate();
        }
    }
}
