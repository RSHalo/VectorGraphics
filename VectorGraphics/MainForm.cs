using VectorGraphics.Drawables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VectorGraphics.Tools;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using VectorGraphics.Resizing;

namespace VectorGraphics
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

			// An event is published when the selected shape is changed. The canvas is subscribed to this event so that it can react accordingly.
			MainCanvas.Drawables.SelectedShapeChanged += MainCanvas.OnSelectedShapeChanged;
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

        private void RbPointer_CheckedChanged(object sender, EventArgs e)
        {
			SetupTool<Pointer>();
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
			{
				Tool.IsControlHeld = false;
			}
			else if (e.KeyCode == Keys.Delete && !Tool.IsDrawing)
			{
				// Delete the selected shape if the current tool is not drawing.
				MainCanvas.Drawables.DeleteSelectedShape();
				MainCanvas.Invalidate();
			}
        }
        #endregion

        #region Event handlers for other controls on the form
        private void ChkAntiAlias_CheckedChanged(object sender, EventArgs e)
        {
            MainCanvas.Invalidate();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            MainCanvas.Reset();
            MainCanvas.Invalidate();
        }
        #endregion

        #region Event handlers for mouse events
		private void MainCanvas_MouseDown(object sender, MouseEventArgs e)
		{
            Tool.MouseDown(e);
		}

		private void MainCanvas_MouseMove(object sender, MouseEventArgs e)
		{
			lblCursorPos.Text = $"Screen: X: { e.X }, Y: { e.Y }";
			lblOffset.Text = $"Offset: X: { MainCanvas.OffsetX }, Y: { MainCanvas.OffsetY }";

			Tool.UpdateWorldCoords(e);
			lblWorldPos.Text = $"World:  X: { Tool.WorldX }, Y: { Tool.WorldY }";

			Tool.MouseMoved(e);
		}

		private void MainCanvas_MouseClick(object sender, MouseEventArgs e)
		{
            Tool.Clicked(e);
		}

		private void MainCanvas_MouseUp(object sender, MouseEventArgs e)
		{
            Tool.MouseUp(e);
		}

		private void MainCanvas_MouseLeave(object sender, EventArgs e)
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
                Canvas = MainCanvas
            };

            Tool = tool;
            MainCanvas.Cursor = tool.Cursor;

            return tool;
        }

		private void MainCanvas_Paint(object sender, PaintEventArgs e)
		{
			var graphics = e.Graphics;

			graphics.SmoothingMode = SmoothingMode;

			// Apply scaling defined by Canvas.ZoomScale
			graphics.ScaleTransform(MainCanvas.ZoomScale, MainCanvas.ZoomScale, MatrixOrder.Append);


			// Apply the translation defined by the offset values.
			graphics.TranslateTransform(MainCanvas.OffsetX, MainCanvas.OffsetY, MatrixOrder.Append);

			// All drawing happens when this Canvas is painted on the screen.
			// You don't just draw a line and expect it to persist. The drawing will dissapear when you minimise then maximise the form.
			// So, if we do all drawing when the containing Panel is drawn, then any time we can see our Panel, all our lines/rectangles will have been drawn too.
			// This is a very important concept. When you want to research, do a Google search like: "Drawing Paint event", "Drawing OnPaint override".
			foreach (IDrawable drawable in MainCanvas.Drawables)
			{
				drawable.Draw(graphics);
			}

			// When you draw a shape, you may drag your mouse to construct the shape. While this happens, IsDrawing will be set to true.
			// We want to show the shape being created by the mouse moving, so we draw the Tool's "CreationDrawable" shape.
			if (Tool.IsDrawing)
				Tool.CreationDrawable?.Draw(graphics);

			MainCanvas.RefreshResizers();

			UpdatePeripherals();
		}

		/// <summary>Updates labels and other controls around the main canvas.</summary>
		public void UpdatePeripherals()
		{
			lblScale.Text = $"Zoom Scale: { MainCanvas.ZoomScale.ToString() }";

			if (MainCanvas.Drawables.SelectedShape == null)
			{
				lblSelectedShapeId.Text = string.Empty;
			}
			else
			{
				lblSelectedShapeId.Text = MainCanvas.Drawables.SelectedShape.Id;
			}
		}
	}
}
