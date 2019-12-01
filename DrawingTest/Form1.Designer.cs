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
            this.btnDrawRandomLine = new System.Windows.Forms.Button();
            this.btnDrawRandomRectangle = new System.Windows.Forms.Button();
            this.lblCursorPos = new System.Windows.Forms.Label();
            this.rbFixedRectangle = new System.Windows.Forms.RadioButton();
            this.cnvsMain = new Canvas();
            this.rbFixedLine = new System.Windows.Forms.RadioButton();
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
            // btnDrawRandomLine
            // 
            this.btnDrawRandomLine.Location = new System.Drawing.Point(12, 12);
            this.btnDrawRandomLine.Name = "btnDrawRandomLine";
            this.btnDrawRandomLine.Size = new System.Drawing.Size(117, 23);
            this.btnDrawRandomLine.TabIndex = 1;
            this.btnDrawRandomLine.Text = "Draw Random Line";
            this.btnDrawRandomLine.UseVisualStyleBackColor = true;
            this.btnDrawRandomLine.Click += new System.EventHandler(this.BtnDrawRandomLine_Click);
            // 
            // btnDrawRandomRectangle
            // 
            this.btnDrawRandomRectangle.Location = new System.Drawing.Point(135, 12);
            this.btnDrawRandomRectangle.Name = "btnDrawRandomRectangle";
            this.btnDrawRandomRectangle.Size = new System.Drawing.Size(148, 23);
            this.btnDrawRandomRectangle.TabIndex = 4;
            this.btnDrawRandomRectangle.Text = "Draw Random Rectangle";
            this.btnDrawRandomRectangle.UseVisualStyleBackColor = true;
            this.btnDrawRandomRectangle.Click += new System.EventHandler(this.BtnDrawRandomRectangle_Click);
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
            this.rbFixedRectangle.Location = new System.Drawing.Point(445, 18);
            this.rbFixedRectangle.Name = "rbFixedRectangle";
            this.rbFixedRectangle.Size = new System.Drawing.Size(102, 17);
            this.rbFixedRectangle.TabIndex = 10;
            this.rbFixedRectangle.TabStop = true;
            this.rbFixedRectangle.Text = "Fixed Rectangle";
            this.rbFixedRectangle.UseVisualStyleBackColor = true;
            this.rbFixedRectangle.CheckedChanged += new System.EventHandler(this.RbFixedRectangle_CheckedChanged);
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
            this.cnvsMain.MouseLeave += new System.EventHandler(this.CnvsMain_MouseLeave);
            this.cnvsMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CnvsMain_MouseMove);
            // 
            // rbFixedLine
            // 
            this.rbFixedLine.AutoSize = true;
            this.rbFixedLine.Location = new System.Drawing.Point(553, 18);
            this.rbFixedLine.Name = "rbFixedLine";
            this.rbFixedLine.Size = new System.Drawing.Size(73, 17);
            this.rbFixedLine.TabIndex = 11;
            this.rbFixedLine.TabStop = true;
            this.rbFixedLine.Text = "Fixed Line";
            this.rbFixedLine.UseVisualStyleBackColor = true;
            this.rbFixedLine.CheckedChanged += new System.EventHandler(this.RbFixedLine_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 537);
            this.Controls.Add(this.rbFixedLine);
            this.Controls.Add(this.rbFixedRectangle);
            this.Controls.Add(this.cnvsMain);
            this.Controls.Add(this.lblCursorPos);
            this.Controls.Add(this.btnDrawRandomRectangle);
            this.Controls.Add(this.lblDrawing);
            this.Controls.Add(this.btnDrawRandomLine);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDrawing;
        private System.Windows.Forms.Button btnDrawRandomLine;
        private System.Windows.Forms.Button btnDrawRandomRectangle;
        private System.Windows.Forms.Label lblCursorPos;
        private Canvas cnvsMain;
        private System.Windows.Forms.RadioButton rbFixedRectangle;
        private System.Windows.Forms.RadioButton rbFixedLine;
    }
}

