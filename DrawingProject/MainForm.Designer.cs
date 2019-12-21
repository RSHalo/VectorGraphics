namespace DrawingProject
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
            this.lblCursorPos = new System.Windows.Forms.Label();
            this.rbRectangle = new System.Windows.Forms.RadioButton();
            this.pnlToolsContainer = new System.Windows.Forms.Panel();
            this.rbLine = new System.Windows.Forms.RadioButton();
            this.rbPanner = new System.Windows.Forms.RadioButton();
            this.lblTools = new System.Windows.Forms.Label();
            this.cnvsMain = new Canvas();
            this.pnlToolsContainer.SuspendLayout();
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
            // lblCursorPos
            // 
            this.lblCursorPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCursorPos.AutoSize = true;
            this.lblCursorPos.Location = new System.Drawing.Point(12, 506);
            this.lblCursorPos.Name = "lblCursorPos";
            this.lblCursorPos.Size = new System.Drawing.Size(0, 13);
            this.lblCursorPos.TabIndex = 5;
            // 
            // rbRectangle
            // 
            this.rbRectangle.AutoSize = true;
            this.rbRectangle.Location = new System.Drawing.Point(5, 11);
            this.rbRectangle.Name = "rbRectangle";
            this.rbRectangle.Size = new System.Drawing.Size(98, 17);
            this.rbRectangle.TabIndex = 12;
            this.rbRectangle.TabStop = true;
            this.rbRectangle.Text = "Free Rectangle";
            this.rbRectangle.UseVisualStyleBackColor = true;
            this.rbRectangle.CheckedChanged += new System.EventHandler(this.RbRectangle_CheckedChanged);
            // 
            // pnlToolsContainer
            // 
            this.pnlToolsContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlToolsContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlToolsContainer.Controls.Add(this.rbLine);
            this.pnlToolsContainer.Controls.Add(this.rbPanner);
            this.pnlToolsContainer.Controls.Add(this.rbRectangle);
            this.pnlToolsContainer.Location = new System.Drawing.Point(15, 28);
            this.pnlToolsContainer.Name = "pnlToolsContainer";
            this.pnlToolsContainer.Size = new System.Drawing.Size(972, 40);
            this.pnlToolsContainer.TabIndex = 13;
            // 
            // rbLine
            // 
            this.rbLine.AutoSize = true;
            this.rbLine.Location = new System.Drawing.Point(109, 11);
            this.rbLine.Name = "rbLine";
            this.rbLine.Size = new System.Drawing.Size(45, 17);
            this.rbLine.TabIndex = 16;
            this.rbLine.TabStop = true;
            this.rbLine.Text = "Line";
            this.rbLine.UseVisualStyleBackColor = true;
            this.rbLine.CheckedChanged += new System.EventHandler(this.RbLine_CheckedChanged);
            // 
            // rbPanner
            // 
            this.rbPanner.AutoSize = true;
            this.rbPanner.Location = new System.Drawing.Point(160, 11);
            this.rbPanner.Name = "rbPanner";
            this.rbPanner.Size = new System.Drawing.Size(44, 17);
            this.rbPanner.TabIndex = 15;
            this.rbPanner.TabStop = true;
            this.rbPanner.Text = "Pan";
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
            // cnvsMain
            // 
            this.cnvsMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cnvsMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cnvsMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.cnvsMain.Location = new System.Drawing.Point(15, 97);
            this.cnvsMain.Name = "cnvsMain";
            this.cnvsMain.OffsetX = 0F;
            this.cnvsMain.OffsetY = 0F;
            this.cnvsMain.Size = new System.Drawing.Size(972, 396);
            this.cnvsMain.TabIndex = 8;
            this.cnvsMain.Paint += new System.Windows.Forms.PaintEventHandler(this.CnvsMain_Paint);
            this.cnvsMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CnvsMain_MouseClick);
            this.cnvsMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CnvsMain_MouseDown);
            this.cnvsMain.MouseLeave += new System.EventHandler(this.CnvsMain_MouseLeave);
            this.cnvsMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CnvsMain_MouseMove);
            this.cnvsMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CnvsMain_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 537);
            this.Controls.Add(this.lblTools);
            this.Controls.Add(this.pnlToolsContainer);
            this.Controls.Add(this.cnvsMain);
            this.Controls.Add(this.lblCursorPos);
            this.Controls.Add(this.lblDrawing);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.pnlToolsContainer.ResumeLayout(false);
            this.pnlToolsContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDrawing;
        private System.Windows.Forms.Label lblCursorPos;
        private Canvas cnvsMain;
        private System.Windows.Forms.RadioButton rbRectangle;
        private System.Windows.Forms.Panel pnlToolsContainer;
        private System.Windows.Forms.Label lblTools;
        private System.Windows.Forms.RadioButton rbPanner;
        private System.Windows.Forms.RadioButton rbLine;
    }
}

