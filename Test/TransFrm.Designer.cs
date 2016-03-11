namespace Test
{
    partial class TransFrm
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
            this.xButton2 = new hwj.UserControls.CommonControls.xButton();
            this.xButton1 = new hwj.UserControls.CommonControls.xButton();
            this.xButton3 = new hwj.UserControls.CommonControls.xButton();
            this.SuspendLayout();
            // 
            // xButton2
            // 
            this.xButton2.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.xButton2.Location = new System.Drawing.Point(197, 82);
            this.xButton2.Name = "xButton2";
            this.xButton2.Size = new System.Drawing.Size(75, 23);
            this.xButton2.TabIndex = 1;
            this.xButton2.Text = "xButton2";
            this.xButton2.UseVisualStyleBackColor = true;
            this.xButton2.Click += new System.EventHandler(this.xButton2_Click);
            // 
            // xButton1
            // 
            this.xButton1.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.xButton1.Location = new System.Drawing.Point(197, 27);
            this.xButton1.Name = "xButton1";
            this.xButton1.Size = new System.Drawing.Size(75, 23);
            this.xButton1.TabIndex = 0;
            this.xButton1.Text = "xButton1";
            this.xButton1.UseVisualStyleBackColor = true;
            this.xButton1.Click += new System.EventHandler(this.xButton1_Click);
            // 
            // xButton3
            // 
            this.xButton3.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.xButton3.Location = new System.Drawing.Point(197, 134);
            this.xButton3.Name = "xButton3";
            this.xButton3.Size = new System.Drawing.Size(75, 23);
            this.xButton3.TabIndex = 2;
            this.xButton3.Text = "xButton3";
            this.xButton3.UseVisualStyleBackColor = true;
            this.xButton3.Click += new System.EventHandler(this.xButton3_Click);
            // 
            // TransFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.xButton3);
            this.Controls.Add(this.xButton2);
            this.Controls.Add(this.xButton1);
            this.Name = "TransFrm";
            this.Text = "TransFrm";
            this.ResumeLayout(false);

        }

        #endregion

        private hwj.UserControls.CommonControls.xButton xButton1;
        private hwj.UserControls.CommonControls.xButton xButton2;
        private hwj.UserControls.CommonControls.xButton xButton3;
    }
}