using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrawingProject.Tools;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace DrawingProject
{
    public partial class MainForm : Form
    {
        // TODO: Research 2d scene graph.

        // The tool selected by the user.
        Tool Tool = new Tool();

        // The SmoothingMode selected by the user.
        public SmoothingMode SmoothingMode
        {
            get
            {
                return chkAntiAlias.Checked ? SmoothingMode.AntiAlias : SmoothingMode.Default;
            }
        }

        public MainForm()
        {
            InitializeComponent();

            // Create a cross at the origin, for debugging.
            cnvsMain.Drawables.Add(new Drawables.DrawableLine(Pens.Black, new Point(0, -5), new Point(0, 5)));
            cnvsMain.Drawables.Add(new Drawables.DrawableLine(Pens.Black, new Point(-5, 0), new Point(5, 0)));

            // Create a cross at an arbitrary location, for debugging.
            cnvsMain.Drawables.Add(new Drawables.DrawableLine(Pens.Black, new Point(300, 270), new Point(300, 280)));
            cnvsMain.Drawables.Add(new Drawables.DrawableLine(Pens.Black, new Point(295, 275), new Point(305, 275)));

            // Create a rectangle at an arbitrary location, for debugging.
            cnvsMain.Drawables.Add(new Drawables.DrawableRectangle(Pens.Blue, 20, 30, 500, 300));
        }

        #region Event handlers for radio buttons that change the tool.
        private void RbLine_CheckedChanged(object sender, EventArgs e)
        {
            SetupTool<LineTool>();
        }

        private void RbRectangle_CheckedChanged(object sender, EventArgs e)
        {
            SetupTool<RectangleTool>();
        }

        private void RbEllipse_CheckedChanged(object sender, EventArgs e)
        {
            SetupTool<EllipseTool>();
        }

        private void RbPanner_CheckedChanged(object sender, EventArgs e)
        {
            SetupTool<Panner>();
        }
        #endregion

        #region Event handlers for key presses
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                Tool.IsControlHeld = true;
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                Tool.IsControlHeld = false;
        }
        #endregion

        #region Event handlers for other controls on the form
        private void ChkAntiAlias_CheckedChanged(object sender, EventArgs e)
        {
            cnvsMain.Invalidate();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            cnvsMain.Reset();
            cnvsMain.Invalidate();
        }
        #endregion

        #region Event handlers for mouse events
        private void CnvsMain_MouseDown(object sender, MouseEventArgs e)
        {
            Tool.MouseDown(e);
        }

        private void CnvsMain_MouseMove(object sender, MouseEventArgs e)
        {
            lblCursorPos.Text = $"Screen: X: { e.X }, Y: { e.Y }";
            lblOffset.Text = $"Offset: X: { cnvsMain.OffsetX }, Y: { cnvsMain.OffsetY }";

            Tool.UpdateWorldCoords(e);
            lblWorldPos.Text = $"World:  X: { Tool.WorldX }, Y: { Tool.WorldY }";

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
            lblOffset.ResetText();
            lblWorldPos.ResetText();
        }
        #endregion

        private T SetupTool<T>() where T : Tool, new()
        {
            // Create new instance of the specified tool and assign it's canvas.
            T tool = new T
            {
                Canvas = cnvsMain
            };

            Tool = tool;
            cnvsMain.Cursor = tool.Cursor;

            return tool;
        }

        private void CnvsMain_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;

            graphics.SmoothingMode = SmoothingMode;

            // Apply scaling defined by Canvas.ZoomScale
            graphics.ScaleTransform(cnvsMain.ZoomScale, cnvsMain.ZoomScale, MatrixOrder.Append);


            // Apply the translation defined by the offset values.
            graphics.TranslateTransform(cnvsMain.OffsetX, cnvsMain.OffsetY, MatrixOrder.Append);

            // All drawing happens when this Canvas is painted on the screen.
            // You don't just draw a line and expect it to persist. The drawing will dissapear when you minimise then maximise the form.
            // So, if we do all drawing when the containing Panel is drawn, then any time we can see our Panel, all our lines/rectangles will have been drawn too.
            // This is a very important concept. When you want to research, do a Google search like: "Drawing Paint event", "Drawing OnPaint override".

            foreach (Drawables.IDrawable drawable in cnvsMain.Drawables)
            {
                drawable.Draw(graphics);
            }

            // When you draw a shape, you may drag your mouse to construct the shape. While this happens, IsDrawing will be set to true.
            // We want to show the shape being created by the mouse moving, so we draw the Tool's "CreationDrawable" shape.
            if (Tool.IsDrawing)
                Tool.CreationDrawable?.Draw(graphics);

            lblScale.Text = $"Zoom Scale: { cnvsMain.ZoomScale.ToString() }";
        }
    }
}
