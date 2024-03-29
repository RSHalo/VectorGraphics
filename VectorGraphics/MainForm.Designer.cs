﻿namespace VectorGraphics
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDrawing = new System.Windows.Forms.Label();
            this.rbRectangle = new System.Windows.Forms.RadioButton();
            this.pnlToolsContainer = new System.Windows.Forms.Panel();
            this.rbPointer = new System.Windows.Forms.RadioButton();
            this.rbEllipse = new System.Windows.Forms.RadioButton();
            this.rbLine = new System.Windows.Forms.RadioButton();
            this.rbPanner = new System.Windows.Forms.RadioButton();
            this.lblTools = new System.Windows.Forms.Label();
            this.lblSettings = new System.Windows.Forms.Label();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.chkAntiAlias = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblCursorPos = new System.Windows.Forms.Label();
            this.lblOffset = new System.Windows.Forms.Label();
            this.lblWorldPos = new System.Windows.Forms.Label();
            this.lblScale = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCoordState = new System.Windows.Forms.Label();
            this.lblSelectedShapeTitle = new System.Windows.Forms.Label();
            this.lblSelectedShapeId = new System.Windows.Forms.Label();
            this.MainCanvas = new CanvasControl();
            this.btnResetView = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlToolsContainer.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDrawing
            // 
            this.lblDrawing.AutoSize = true;
            this.lblDrawing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrawing.Location = new System.Drawing.Point(12, 81);
            this.lblDrawing.Name = "lblDrawing";
            this.lblDrawing.Size = new System.Drawing.Size(101, 13);
            this.lblDrawing.TabIndex = 2;
            this.lblDrawing.Text = "Drawing Surface";
            // 
            // rbRectangle
            // 
            this.rbRectangle.AutoSize = true;
            this.rbRectangle.Location = new System.Drawing.Point(5, 11);
            this.rbRectangle.Name = "rbRectangle";
            this.rbRectangle.Size = new System.Drawing.Size(74, 17);
            this.rbRectangle.TabIndex = 12;
            this.rbRectangle.TabStop = true;
            this.rbRectangle.Text = "Rectangle";
            this.rbRectangle.UseVisualStyleBackColor = true;
            this.rbRectangle.CheckedChanged += new System.EventHandler(this.RbRectangle_CheckedChanged);
            // 
            // pnlToolsContainer
            // 
            this.pnlToolsContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlToolsContainer.Controls.Add(this.rbPointer);
            this.pnlToolsContainer.Controls.Add(this.rbEllipse);
            this.pnlToolsContainer.Controls.Add(this.rbLine);
            this.pnlToolsContainer.Controls.Add(this.rbPanner);
            this.pnlToolsContainer.Controls.Add(this.rbRectangle);
            this.pnlToolsContainer.Location = new System.Drawing.Point(15, 28);
            this.pnlToolsContainer.Name = "pnlToolsContainer";
            this.pnlToolsContainer.Size = new System.Drawing.Size(412, 40);
            this.pnlToolsContainer.TabIndex = 13;
            this.pnlToolsContainer.TabStop = true;
            // 
            // rbPointer
            // 
            this.rbPointer.AutoSize = true;
            this.rbPointer.Location = new System.Drawing.Point(284, 11);
            this.rbPointer.Name = "rbPointer";
            this.rbPointer.Size = new System.Drawing.Size(58, 17);
            this.rbPointer.TabIndex = 16;
            this.rbPointer.TabStop = true;
            this.rbPointer.Text = "Pointer";
            this.rbPointer.UseVisualStyleBackColor = true;
            this.rbPointer.CheckedChanged += new System.EventHandler(this.RbPointer_CheckedChanged);
            // 
            // rbEllipse
            // 
            this.rbEllipse.AutoSize = true;
            this.rbEllipse.Location = new System.Drawing.Point(132, 11);
            this.rbEllipse.Name = "rbEllipse";
            this.rbEllipse.Size = new System.Drawing.Size(55, 17);
            this.rbEllipse.TabIndex = 14;
            this.rbEllipse.TabStop = true;
            this.rbEllipse.Text = "Ellipse";
            this.rbEllipse.UseVisualStyleBackColor = true;
            this.rbEllipse.CheckedChanged += new System.EventHandler(this.RbEllipse_CheckedChanged);
            // 
            // rbLine
            // 
            this.rbLine.AutoSize = true;
            this.rbLine.Location = new System.Drawing.Point(81, 11);
            this.rbLine.Name = "rbLine";
            this.rbLine.Size = new System.Drawing.Size(45, 17);
            this.rbLine.TabIndex = 13;
            this.rbLine.TabStop = true;
            this.rbLine.Text = "Line";
            this.rbLine.UseVisualStyleBackColor = true;
            this.rbLine.CheckedChanged += new System.EventHandler(this.RbLine_CheckedChanged);
            // 
            // rbPanner
            // 
            this.rbPanner.AutoSize = true;
            this.rbPanner.Location = new System.Drawing.Point(219, 11);
            this.rbPanner.Name = "rbPanner";
            this.rbPanner.Size = new System.Drawing.Size(59, 17);
            this.rbPanner.TabIndex = 15;
            this.rbPanner.TabStop = true;
            this.rbPanner.Text = "Panner";
            this.rbPanner.UseVisualStyleBackColor = true;
            this.rbPanner.CheckedChanged += new System.EventHandler(this.RbPanner_CheckedChanged);
            // 
            // lblTools
            // 
            this.lblTools.AutoSize = true;
            this.lblTools.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTools.Location = new System.Drawing.Point(13, 12);
            this.lblTools.Name = "lblTools";
            this.lblTools.Size = new System.Drawing.Size(38, 13);
            this.lblTools.TabIndex = 0;
            this.lblTools.Text = "Tools";
            // 
            // lblSettings
            // 
            this.lblSettings.AutoSize = true;
            this.lblSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettings.Location = new System.Drawing.Point(475, 12);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(53, 13);
            this.lblSettings.TabIndex = 14;
            this.lblSettings.Text = "Settings";
            // 
            // pnlSettings
            // 
            this.pnlSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSettings.Controls.Add(this.chkAntiAlias);
            this.pnlSettings.Location = new System.Drawing.Point(478, 28);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(412, 40);
            this.pnlSettings.TabIndex = 14;
            // 
            // chkAntiAlias
            // 
            this.chkAntiAlias.AutoSize = true;
            this.chkAntiAlias.Location = new System.Drawing.Point(4, 11);
            this.chkAntiAlias.Name = "chkAntiAlias";
            this.chkAntiAlias.Size = new System.Drawing.Size(69, 17);
            this.chkAntiAlias.TabIndex = 20;
            this.chkAntiAlias.TabStop = false;
            this.chkAntiAlias.Text = "Anti Alias";
            this.chkAntiAlias.UseVisualStyleBackColor = true;
            this.chkAntiAlias.CheckedChanged += new System.EventHandler(this.ChkAntiAlias_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(1140, 54);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 26;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // lblCursorPos
            // 
            this.lblCursorPos.AutoSize = true;
            this.lblCursorPos.Location = new System.Drawing.Point(8, 5);
            this.lblCursorPos.Name = "lblCursorPos";
            this.lblCursorPos.Size = new System.Drawing.Size(35, 13);
            this.lblCursorPos.TabIndex = 16;
            this.lblCursorPos.Text = "label1";
            // 
            // lblOffset
            // 
            this.lblOffset.AutoSize = true;
            this.lblOffset.Location = new System.Drawing.Point(8, 29);
            this.lblOffset.Name = "lblOffset";
            this.lblOffset.Size = new System.Drawing.Size(35, 13);
            this.lblOffset.TabIndex = 17;
            this.lblOffset.Text = "label2";
            // 
            // lblWorldPos
            // 
            this.lblWorldPos.AutoSize = true;
            this.lblWorldPos.Location = new System.Drawing.Point(8, 54);
            this.lblWorldPos.Name = "lblWorldPos";
            this.lblWorldPos.Size = new System.Drawing.Size(35, 13);
            this.lblWorldPos.TabIndex = 18;
            this.lblWorldPos.Text = "label3";
            // 
            // lblScale
            // 
            this.lblScale.AutoSize = true;
            this.lblScale.Location = new System.Drawing.Point(8, 79);
            this.lblScale.Name = "lblScale";
            this.lblScale.Size = new System.Drawing.Size(35, 13);
            this.lblScale.TabIndex = 19;
            this.lblScale.Text = "label3";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblCursorPos);
            this.panel1.Controls.Add(this.lblWorldPos);
            this.panel1.Controls.Add(this.lblScale);
            this.panel1.Controls.Add(this.lblOffset);
            this.panel1.Location = new System.Drawing.Point(16, 563);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 99);
            this.panel1.TabIndex = 20;
            // 
            // lblCoordState
            // 
            this.lblCoordState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCoordState.AutoSize = true;
            this.lblCoordState.Location = new System.Drawing.Point(16, 544);
            this.lblCoordState.Name = "lblCoordState";
            this.lblCoordState.Size = new System.Drawing.Size(123, 13);
            this.lblCoordState.TabIndex = 21;
            this.lblCoordState.Text = "Coordinate System State";
            // 
            // lblSelectedShapeTitle
            // 
            this.lblSelectedShapeTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectedShapeTitle.AutoSize = true;
            this.lblSelectedShapeTitle.Location = new System.Drawing.Point(322, 544);
            this.lblSelectedShapeTitle.Name = "lblSelectedShapeTitle";
            this.lblSelectedShapeTitle.Size = new System.Drawing.Size(89, 13);
            this.lblSelectedShapeTitle.TabIndex = 22;
            this.lblSelectedShapeTitle.Text = "Selected Shape: ";
            // 
            // lblSelectedShapeId
            // 
            this.lblSelectedShapeId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectedShapeId.AutoSize = true;
            this.lblSelectedShapeId.Location = new System.Drawing.Point(405, 544);
            this.lblSelectedShapeId.Name = "lblSelectedShapeId";
            this.lblSelectedShapeId.Size = new System.Drawing.Size(38, 13);
            this.lblSelectedShapeId.TabIndex = 23;
            this.lblSelectedShapeId.Text = "NONE";
            // 
            // MainCanvas
            // 
            this.MainCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainCanvas.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainCanvas.Location = new System.Drawing.Point(15, 97);
            this.MainCanvas.Name = "MainCanvas";
            this.MainCanvas.OffsetX = 0F;
            this.MainCanvas.OffsetY = 0F;
            this.MainCanvas.Size = new System.Drawing.Size(1200, 428);
            this.MainCanvas.TabIndex = 30;
            this.MainCanvas.TabStop = true;
            this.MainCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainCanvas_MouseMove);
            this.MainCanvas.MouseLeave += new System.EventHandler(this.MainCanvas_MouseLeave);
            this.MainCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.MainCanvas_Paint);
            this.MainCanvas.Drawables.SelectedShapeChanged += (object o, System.EventArgs e) => this.UpdatePeripherals();
            // 
            // btnResetView
            // 
            this.btnResetView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetView.Location = new System.Drawing.Point(1059, 54);
            this.btnResetView.Name = "btnResetView";
            this.btnResetView.Size = new System.Drawing.Size(75, 23);
            this.btnResetView.TabIndex = 25;
            this.btnResetView.TabStop = false;
            this.btnResetView.Text = "Reset View";
            this.btnResetView.UseVisualStyleBackColor = true;
            this.btnResetView.Click += new System.EventHandler(this.BtnResetView_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(978, 54);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 31;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 672);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnResetView);
            this.Controls.Add(this.lblSelectedShapeId);
            this.Controls.Add(this.lblSelectedShapeTitle);
            this.Controls.Add(this.lblCoordState);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.lblSettings);
            this.Controls.Add(this.lblTools);
            this.Controls.Add(this.pnlToolsContainer);
            this.Controls.Add(this.MainCanvas);
            this.Controls.Add(this.lblDrawing);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Draw Vector Graphics";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.pnlToolsContainer.ResumeLayout(false);
            this.pnlToolsContainer.PerformLayout();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDrawing;
        private CanvasControl MainCanvas;
        private System.Windows.Forms.RadioButton rbRectangle;
        private System.Windows.Forms.Panel pnlToolsContainer;
        private System.Windows.Forms.Label lblTools;
        private System.Windows.Forms.RadioButton rbPanner;
        private System.Windows.Forms.RadioButton rbLine;
        private System.Windows.Forms.Label lblSettings;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.CheckBox chkAntiAlias;
        private System.Windows.Forms.RadioButton rbEllipse;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblCursorPos;
        private System.Windows.Forms.Label lblOffset;
        private System.Windows.Forms.Label lblWorldPos;
        private System.Windows.Forms.Label lblScale;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbPointer;
		private System.Windows.Forms.Label lblCoordState;
		private System.Windows.Forms.Label lblSelectedShapeTitle;
		private System.Windows.Forms.Label lblSelectedShapeId;
        private System.Windows.Forms.Button btnResetView;
        private System.Windows.Forms.Button btnSave;
    }
}

