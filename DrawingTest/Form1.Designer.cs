namespace DrawingTest
{
    partial class Form1
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
            this.rbFixedRectangle = new System.Windows.Forms.RadioButton();
            this.rbFixedLine = new System.Windows.Forms.RadioButton();
            this.rbFreeRectangle = new System.Windows.Forms.RadioButton();
            this.cnvsMain = new Canvas();
            this.pnlToolsContainer = new System.Windows.Forms.Panel();
            this.lblTools = new System.Windows.Forms.Label();
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
            this.lblCursorPos.AutoSize = true;
            this.lblCursorPos.Location = new System.Drawing.Point(12, 506);
            this.lblCursorPos.Name = "lblCursorPos";
            this.lblCursorPos.Size = new System.Drawing.Size(0, 13);
            this.lblCursorPos.TabIndex = 5;
            // 
            // rbFixedRectangle
            // 
            this.rbFixedRectangle.AutoSize = true;
            this.rbFixedRectangle.Location = new System.Drawing.Point(7, 28);
            this.rbFixedRectangle.Name = "rbFixedRectangle";
            this.rbFixedRectangle.Size = new System.Drawing.Size(102, 17);
            this.rbFixedRectangle.TabIndex = 10;
            this.rbFixedRectangle.TabStop = true;
            this.rbFixedRectangle.Text = "Fixed Rectangle";
            this.rbFixedRectangle.UseVisualStyleBackColor = true;
            this.rbFixedRectangle.CheckedChanged += new System.EventHandler(this.RbFixedRectangle_CheckedChanged);
            // 
            // rbFixedLine
            // 
            this.rbFixedLine.AutoSize = true;
            this.rbFixedLine.Location = new System.Drawing.Point(115, 28);
            this.rbFixedLine.Name = "rbFixedLine";
            this.rbFixedLine.Size = new System.Drawing.Size(73, 17);
            this.rbFixedLine.TabIndex = 11;
            this.rbFixedLine.TabStop = true;
            this.rbFixedLine.Text = "Fixed Line";
            this.rbFixedLine.UseVisualStyleBackColor = true;
            this.rbFixedLine.CheckedChanged += new System.EventHandler(this.RbFixedLine_CheckedChanged);
            // 
            // rbFreeRectangle
            // 
            this.rbFreeRectangle.AutoSize = true;
            this.rbFreeRectangle.Location = new System.Drawing.Point(195, 28);
            this.rbFreeRectangle.Name = "rbFreeRectangle";
            this.rbFreeRectangle.Size = new System.Drawing.Size(98, 17);
            this.rbFreeRectangle.TabIndex = 12;
            this.rbFreeRectangle.TabStop = true;
            this.rbFreeRectangle.Text = "Free Rectangle";
            this.rbFreeRectangle.UseVisualStyleBackColor = true;
            this.rbFreeRectangle.CheckedChanged += new System.EventHandler(this.RbFreeRectangle_CheckedChanged);
            // 
            // cnvsMain
            // 
            this.cnvsMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cnvsMain.Location = new System.Drawing.Point(15, 97);
            this.cnvsMain.Name = "cnvsMain";
            this.cnvsMain.Size = new System.Drawing.Size(972, 396);
            this.cnvsMain.TabIndex = 8;
            this.cnvsMain.Paint += new System.Windows.Forms.PaintEventHandler(this.CnvsMain_Paint);
            this.cnvsMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CnvsMain_MouseClick);
            this.cnvsMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CnvsMain_MouseDown);
            this.cnvsMain.MouseLeave += new System.EventHandler(this.CnvsMain_MouseLeave);
            this.cnvsMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CnvsMain_MouseMove);
            this.cnvsMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CnvsMain_MouseUp);
            // 
            // pnlToolsContainer
            // 
            this.pnlToolsContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlToolsContainer.Controls.Add(this.lblTools);
            this.pnlToolsContainer.Controls.Add(this.rbFreeRectangle);
            this.pnlToolsContainer.Controls.Add(this.rbFixedLine);
            this.pnlToolsContainer.Controls.Add(this.rbFixedRectangle);
            this.pnlToolsContainer.Location = new System.Drawing.Point(15, 10);
            this.pnlToolsContainer.Name = "pnlToolsContainer";
            this.pnlToolsContainer.Size = new System.Drawing.Size(972, 62);
            this.pnlToolsContainer.TabIndex = 13;
            // 
            // lblTools
            // 
            this.lblTools.AutoSize = true;
            this.lblTools.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTools.Location = new System.Drawing.Point(4, 7);
            this.lblTools.Name = "lblTools";
            this.lblTools.Size = new System.Drawing.Size(38, 13);
            this.lblTools.TabIndex = 0;
            this.lblTools.Text = "Tools";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 537);
            this.Controls.Add(this.pnlToolsContainer);
            this.Controls.Add(this.cnvsMain);
            this.Controls.Add(this.lblCursorPos);
            this.Controls.Add(this.lblDrawing);
            this.DoubleBuffered = true;
            this.Name = "Form1";
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
        private System.Windows.Forms.RadioButton rbFixedRectangle;
        private System.Windows.Forms.RadioButton rbFixedLine;
        private System.Windows.Forms.RadioButton rbFreeRectangle;
        private System.Windows.Forms.Panel pnlToolsContainer;
        private System.Windows.Forms.Label lblTools;
    }
}

