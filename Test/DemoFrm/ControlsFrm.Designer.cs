namespace Test.DemoFrm
{
    partial class ControlsFrm
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
            this.bgw1 = new System.ComponentModel.BackgroundWorker();
            this.bgw2 = new System.ComponentModel.BackgroundWorker();
            this.xButton1 = new hwj.UserControls.CommonControls.xButton();
            this.emailTextBox1 = new hwj.UserControls.Other.EmailTextBox();
            this.xTextBox1 = new hwj.UserControls.CommonControls.xTextBox();
            this.SuspendLayout();
            // 
            // xButton1
            // 
            this.xButton1.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.xButton1.Location = new System.Drawing.Point(286, 31);
            this.xButton1.Name = "xButton1";
            this.xButton1.Size = new System.Drawing.Size(75, 23);
            this.xButton1.TabIndex = 2;
            this.xButton1.Text = "xButton1";
            this.xButton1.UseVisualStyleBackColor = true;
            this.xButton1.Click += new System.EventHandler(this.xButton1_Click);
            // 
            // emailTextBox1
            // 
            this.emailTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.emailTextBox1.CustomEmailSplitString = null;
            this.emailTextBox1.EmailSpliter = hwj.UserControls.Other.EmailTextBox.EmailspliterEnum.Enter;
            this.emailTextBox1.Format = null;
            this.emailTextBox1.IsRequired = true;
            this.emailTextBox1.Location = new System.Drawing.Point(43, 58);
            this.emailTextBox1.Multiline = true;
            this.emailTextBox1.Name = "emailTextBox1";
            this.emailTextBox1.OldBackColor = System.Drawing.SystemColors.Window;
            this.emailTextBox1.RequiredHandle = null;
            this.emailTextBox1.SetValueToControl = null;
            this.emailTextBox1.Size = new System.Drawing.Size(318, 78);
            this.emailTextBox1.TabIndex = 1;
            this.emailTextBox1.TextIsChanged = false;
            // 
            // xTextBox1
            // 
            this.xTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.xTextBox1.ContentType = hwj.UserControls.CommonControls.ContentType.Email;
            this.xTextBox1.Format = null;
            this.xTextBox1.IsRequired = true;
            this.xTextBox1.Location = new System.Drawing.Point(43, 31);
            this.xTextBox1.Name = "xTextBox1";
            this.xTextBox1.OldBackColor = System.Drawing.SystemColors.Window;
            this.xTextBox1.RequiredHandle = null;
            this.xTextBox1.SetValueToControl = null;
            this.xTextBox1.Size = new System.Drawing.Size(217, 21);
            this.xTextBox1.TabIndex = 0;
            this.xTextBox1.TextIsChanged = false;
            // 
            // ControlsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 385);
            this.Controls.Add(this.xButton1);
            this.Controls.Add(this.emailTextBox1);
            this.Controls.Add(this.xTextBox1);
            this.Name = "ControlsFrm";
            this.Text = "ControlsFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgw1;
        private System.ComponentModel.BackgroundWorker bgw2;
        private hwj.UserControls.CommonControls.xTextBox xTextBox1;
        private hwj.UserControls.Other.EmailTextBox emailTextBox1;
        private hwj.UserControls.CommonControls.xButton xButton1;













    }
}