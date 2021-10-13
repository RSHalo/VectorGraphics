using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using VectorGraphics.Drawables;
using VectorGraphics.FileManagement;
using VectorGraphics.KeyHanding;
using VectorGraphics.Tools;
using VectorGraphics.View;

namespace VectorGraphics
{
    public partial class MainForm : Form, IProgramView
    {
		private readonly IKeyHandler _keyHandler;
        private readonly FileManager _fileManager;
        
        /// <summary>The tool selected by the user.</summary>
        public Tool Tool { get; private set; } = new Tool();

        /// <summary>The SmoothingMode selected by the user.</summary>
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
			_keyHandler = new GlobalKeyHandler(this);
            _fileManager = new FileManager();
		}

		public void Save()
        {
            _fileManager.Save(MainCanvas.Drawables);
        }

        public void Open()
        {
            _fileManager.Load(MainCanvas);
        }

        public void DeleteSelectedShapes()
        {
            MainCanvas.DeleteSelectedShapes();
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
			_keyHandler.HandleKeyDown(e, ModifierKeys);
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
			_keyHandler.HandleKeyUp(e, ModifierKeys);
        }
        #endregion

        #region Event handlers for other controls on the form
        private void ChkAntiAlias_CheckedChanged(object sender, EventArgs e)
        {
            MainCanvas.Repaint();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            MainCanvas.Clear();
        }

        private void BtnResetView_Click(object sender, EventArgs e)
        {
            MainCanvas.ResetView();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            _fileManager.Save(MainCanvas.Drawables);
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
            {
				Tool.CreationDrawable?.Draw(graphics);
            }

			MainCanvas.RefreshResizers();

			UpdatePeripherals();
		}

		/// <summary>Updates labels and other controls around the main canvas.</summary>
		private void UpdatePeripherals()
		{
			lblScale.Text = $"Zoom Scale: {MainCanvas.ZoomScale}";

			IEnumerable<IDrawable> selectedShapes = MainCanvas.Drawables.SelectedShapes;
			if (selectedShapes.Any())
			{
				lblSelectedShapeId.Text = string.Join(",", selectedShapes.Select(shape => shape.Id));
			}
			else
			{
				lblSelectedShapeId.Text = string.Empty;
			}
		}
    }
}
