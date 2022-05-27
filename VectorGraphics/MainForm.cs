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

        #region Event handlers for radio buttons that change the tool.
        private void RbLine_CheckedChanged(object sender, EventArgs e)
        {
            MainCanvas.SetupTool<LineTool>();
        }

        private void RbRectangle_CheckedChanged(object sender, EventArgs e)
        {
            MainCanvas.SetupTool<RectangleTool>();
        }

        private void RbEllipse_CheckedChanged(object sender, EventArgs e)
        {
            MainCanvas.SetupTool<EllipseTool>();
        }

        private void RbPanner_CheckedChanged(object sender, EventArgs e)
        {
            MainCanvas.SetupTool<Panner>();
        }

        private void RbPointer_CheckedChanged(object sender, EventArgs e)
        {
            MainCanvas.SetupTool<Pointer>();
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
            MainCanvas.SmoothingMode = chkAntiAlias.Checked ? SmoothingMode.AntiAlias: SmoothingMode.Default;
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

        #region Canvas event handlers
        private void MainCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            lblCursorPos.Text = $"Screen: X: { e.X }, Y: { e.Y }";
            lblOffset.Text = $"Offset: X: { MainCanvas.OffsetX }, Y: { MainCanvas.OffsetY }";
            lblWorldPos.Text = $"World:  X: { MainCanvas.Tool.WorldX }, Y: { MainCanvas.Tool.WorldY }";
        }

        private void MainCanvas_MouseLeave(object sender, EventArgs e)
        {
            lblCursorPos.ResetText();
            lblOffset.ResetText();
            lblWorldPos.ResetText();
        }

        private void MainCanvas_Paint(object sender, PaintEventArgs e)
        {
            UpdatePeripherals();
        }
        #endregion

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
