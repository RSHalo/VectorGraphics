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
        }

        #region Radio Button events that change the tool.
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

        /// <summary>Transforms page co-ordinates to world co-ordinates and assigns them to the tool.</summary>
        private void UpdateWorldCoords(MouseEventArgs e) => Tool.UpdateWorldCoords(e);

        private void CnvsMain_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;

            graphics.SmoothingMode = SmoothingMode;
            
            // Apply the translation defined by the offset values.
            graphics.TranslateTransform(cnvsMain.OffsetX, cnvsMain.OffsetY);

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
        }

        private void CnvsMain_MouseDown(object sender, MouseEventArgs e)
        {
            Tool.MouseDown(e);
        }

        private void CnvsMain_MouseMove(object sender, MouseEventArgs e)
        {
            lblCursorPos.Text = $"X: { e.X }, Y: { e.Y }";
            UpdateWorldCoords(e);
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

        private void ChkAntiAlias_CheckedChanged(object sender, EventArgs e)
        {
            cnvsMain.Invalidate();
        }
    }
}
