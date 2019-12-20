using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingProject
{
    public partial class MainForm : Form
    {
        // TODO: Research 2d scene graph.

        // The tool selected by the user.
        Tool Tool = new Tool();

        public MainForm()
        {
            InitializeComponent();
        }

        #region Radio Button events that change the tool.
        private void RbFixedLine_CheckedChanged(object sender, EventArgs e)
        {
            SetupTool<FixedLineTool>();
        }

        private void RbFixedRectangle_CheckedChanged(object sender, EventArgs e)
        {
            SetupTool<FixedRectangleTool>();
        }

        private void RbFreeRectangle_CheckedChanged(object sender, EventArgs e)
        {
            SetupTool<RectangleTool>();
            // If I need to assign extra things specific to Rectangle, I can capture the returned object from SetupTool here and act on it.
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
            // Apply the translation defined by the offset values.
            e.Graphics.TranslateTransform(cnvsMain.OffsetX, cnvsMain.OffsetY);

            // All drawing happens when this Canvas is painted on the screen.
            // You don't just draw a line and expect it to persist. The drawing will dissapear when you minimise then maximise the form.
            // So, if we do all drawing when the containing Panel is drawn, then any time we can see our Panel, all our lines/rectangles will have been drawn too.
            // This is a very important concept. When you want to research, do a Google search like: "Drawing Paint event", "Drawing OnPaint override".

            foreach (IDrawable drawable in cnvsMain.Drawables)
            {
                drawable.Draw(e.Graphics);
            }

            // When you draw a shape, you may drag your mouse to construct the shape. While this happens, IsDrawing will be set to true.
            // We want to show the shape being created by the mouse moving, so we draw the Tool's "CreationDrawable" shape.
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
    }
}
