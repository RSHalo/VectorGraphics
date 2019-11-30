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
        // TODO: Watch Practical Polymorphism.
        // TODO: Remove sticky rectangle and replace with normal rectangle.

        DrawingTool Tool;

        Rectangle stickyRectangle = new Rectangle();
        
        // Collection of drawable shapes. This collection is iterated over when the canvas is drawn.
        readonly List<IDrawable> drawables = new List<IDrawable>
        {
            new DrawableLine(Pens.Red, new Point(10, 10), new Point(50, 50)),
            new DrawableLine(Pens.Red, new Point(100, 150), new Point(200, 200))
        };

        public Form1()
        {
            InitializeComponent();
        }

        #region Button Clicks
        private void BtnDrawLine_Click(object sender, EventArgs e)
        {
            DrawableLine line = new DrawableLine(new Pen(Color.Blue), new Point(75, 50), new Point(30, 80));
            drawables.Add(line);

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

        private void RdStickyRectangle_CheckedChanged(object sender, EventArgs e)
        {
            //Tool = new 
        }

        private void ChkFixedRectangle_CheckedChanged(object sender, EventArgs e)
        {
            Tool = new FixedRectangleTool();
            Tool.DrawingCreated += OnToolDrawingCreated;
        }

        private void ChkFixedLine_CheckedChanged(object sender, EventArgs e)
        {
            Tool = new FixedLineTool();
            Tool.DrawingCreated += OnToolDrawingCreated;
        }
        #endregion

        private void CnvsMain_Paint(object sender, PaintEventArgs e)
        {
            // All drawing happens when this Canvas is painted on the screen.
            // You don't just draw a line and expect it to persist. The drawing will dissapear when you minimise then maximise the form.
            // So, if we do all drawing when the containing Panel is drawn, then any time we can see our Panel, all our lines/rectangles will have been drawn too.
            // This is a very important concept. When you want to research, do a Google search like: "Drawing Paint event", "Drawing OnPaint override".

            foreach (IDrawable drawable in drawables)
            {
                drawable.Draw(e.Graphics);
            }
            
            e.Graphics.DrawRectangle(Pens.Red, stickyRectangle);
        }

        private void CnvsMain_MouseMove(object sender, MouseEventArgs e)
        {
            var mousePos = cnvsMain.PointToClient(Cursor.Position);

            lblCursorPos.Text = $"X: { mousePos.X }, Y: { mousePos.Y }";
            /*
            if (isStickyRectangle)
            {
                stickyRectangle.Width = mousePos.X;
                stickyRectangle.Height = mousePos.Y;

                cnvsMain.Invalidate();
            }*/
        }

        private void CnvsMain_MouseClick(object sender, MouseEventArgs e)
        {
            /*
            if (isStickyRectangle)
            {
                drawables.Add(new DrawableRectangle(Pens.Red, stickyRectangle));
                cnvsMain.Invalidate();
            }*/

            Tool.Clicked(e);
        }

        private void CnvsMain_MouseLeave(object sender, EventArgs e)
        {
            lblCursorPos.ResetText();
        }

        // This function is an event handler for when the tool raises it's OnDrawingCreated event.
        private void OnToolDrawingCreated(object sender, EventArgs e)
        {
            drawables.Add(Tool.DrawResult);
            cnvsMain.Invalidate();
        }
    }
}
