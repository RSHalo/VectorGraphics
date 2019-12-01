using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrawingTest.Utility;

namespace DrawingTest
{
    public partial class Form1 : Form
    {
        // TODO: Research 2d scene graph.

        DrawingTool Tool;

        // Collection of drawable shapes. This collection is iterated over when the canvas is drawn.
        readonly List<IDrawable> drawables = new List<IDrawable>();

        public Form1()
        {
            InitializeComponent();
        }

        #region Button Clicks
        private void BtnDrawRandomLine_Click(object sender, EventArgs e)
        {
            Point startPoint = Dimensions.GetRandomPoint(cnvsMain.Width, cnvsMain.Height);
            Point endPoint = Dimensions.GetRandomPoint(cnvsMain.Width, cnvsMain.Height);

            DrawableLine line = new DrawableLine(Pens.Blue, startPoint, endPoint);
            drawables.Add(line);

            cnvsMain.Invalidate();
        }

        private void BtnDrawRandomRectangle_Click(object sender, EventArgs e)
        {
            var rectangle = Dimensions.GetRandomRectangle(cnvsMain.Width, cnvsMain.Height);
            var drawableRectangle = new DrawableRectangle(Pens.Red, rectangle);
            drawables.Add(drawableRectangle);

            cnvsMain.Invalidate();
        }

        private void RbFixedLine_CheckedChanged(object sender, EventArgs e)
        {
            Tool = new FixedLineTool();
            Tool.DrawingCreated += OnToolDrawingCreated;
        }

        private void RbFixedRectangle_CheckedChanged(object sender, EventArgs e)
        {
            Tool = new FixedRectangleTool();
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
        }

        private void CnvsMain_MouseMove(object sender, MouseEventArgs e)
        {
            var mousePos = cnvsMain.PointToClient(Cursor.Position);

            lblCursorPos.Text = $"X: { mousePos.X }, Y: { mousePos.Y }";
        }

        private void CnvsMain_MouseClick(object sender, MouseEventArgs e)
        {
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
