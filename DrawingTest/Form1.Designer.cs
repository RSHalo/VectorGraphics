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
            this.btnDrawLine = new System.Windows.Forms.Button();
            this.btnDrawThickLine = new System.Windows.Forms.Button();
            this.btnDrawRectangle = new System.Windows.Forms.Button();
            this.lblCursorPos = new System.Windows.Forms.Label();
            this.cnvsMain = new Canvas();
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
            // btnDrawLine
            // 
            this.btnDrawLine.Location = new System.Drawing.Point(12, 12);
            this.btnDrawLine.Name = "btnDrawLine";
            this.btnDrawLine.Size = new System.Drawing.Size(75, 23);
            this.btnDrawLine.TabIndex = 1;
            this.btnDrawLine.Text = "Draw Line";
            this.btnDrawLine.UseVisualStyleBackColor = true;
            this.btnDrawLine.Click += new System.EventHandler(this.BtnDrawLine_Click);
            // 
            // btnDrawThickLine
            // 
            this.btnDrawThickLine.Location = new System.Drawing.Point(93, 12);
            this.btnDrawThickLine.Name = "btnDrawThickLine";
            this.btnDrawThickLine.Size = new System.Drawing.Size(112, 23);
            this.btnDrawThickLine.TabIndex = 3;
            this.btnDrawThickLine.Text = "Draw Thicker Line";
            this.btnDrawThickLine.UseVisualStyleBackColor = true;
            this.btnDrawThickLine.Click += new System.EventHandler(this.BtnDrawThickLine_Click);
            // 
            // btnDrawRectangle
            // 
            this.btnDrawRectangle.Location = new System.Drawing.Point(211, 12);
            this.btnDrawRectangle.Name = "btnDrawRectangle";
            this.btnDrawRectangle.Size = new System.Drawing.Size(112, 23);
            this.btnDrawRectangle.TabIndex = 4;
            this.btnDrawRectangle.Text = "Draw Rectangle";
            this.btnDrawRectangle.UseVisualStyleBackColor = true;
            this.btnDrawRectangle.Click += new System.EventHandler(this.BtnDrawRectangle_Click);
            // 
            // lblCursorPos
            // 
            this.lblCursorPos.AutoSize = true;
            this.lblCursorPos.Location = new System.Drawing.Point(12, 506);
            this.lblCursorPos.Name = "lblCursorPos";
            this.lblCursorPos.Size = new System.Drawing.Size(0, 13);
            this.lblCursorPos.TabIndex = 5;
            // 
            // cnvsMain
            // 
            this.cnvsMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cnvsMain.Location = new System.Drawing.Point(15, 97);
            this.cnvsMain.Name = "cnvsMain";
            this.cnvsMain.Size = new System.Drawing.Size(972, 401);
            this.cnvsMain.TabIndex = 8;
            this.cnvsMain.Paint += new System.Windows.Forms.PaintEventHandler(this.CnvsMain_Paint);
            this.cnvsMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CnvsMain_MouseClick);
            this.cnvsMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CnvsMain_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 537);
            this.Controls.Add(this.cnvsMain);
            this.Controls.Add(this.lblCursorPos);
            this.Controls.Add(this.btnDrawRectangle);
            this.Controls.Add(this.btnDrawThickLine);
            this.Controls.Add(this.lblDrawing);
            this.Controls.Add(this.btnDrawLine);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDrawing;
        private System.Windows.Forms.Button btnDrawLine;
        private System.Windows.Forms.Button btnDrawThickLine;
        private System.Windows.Forms.Button btnDrawRectangle;
        private System.Windows.Forms.Label lblCursorPos;
        private Canvas cnvsMain;
    }
}

