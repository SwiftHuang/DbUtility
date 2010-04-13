namespace Test.Demo
{
    partial class XMLTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XMLTest));
            this.btnGeneral = new hwj.UserControls.CommonControls.xButton();
            this.xTextBox1 = new hwj.UserControls.CommonControls.xTextBox();
            this.SuspendLayout();
            // 
            // btnGeneral
            // 
            this.btnGeneral.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnGeneral.Location = new System.Drawing.Point(909, 433);
            this.btnGeneral.Name = "btnGeneral";
            this.btnGeneral.Size = new System.Drawing.Size(75, 23);
            this.btnGeneral.TabIndex = 1;
            this.btnGeneral.Text = "General";
            this.btnGeneral.UseVisualStyleBackColor = true;
            this.btnGeneral.Click += new System.EventHandler(this.btnGeneral_Click);
            // 
            // xTextBox1
            // 
            this.xTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.xTextBox1.Format = null;
            this.xTextBox1.Location = new System.Drawing.Point(12, 12);
            this.xTextBox1.Multiline = true;
            this.xTextBox1.Name = "xTextBox1";
            this.xTextBox1.OldBackColor = System.Drawing.SystemColors.Window;
            this.xTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.xTextBox1.SetValueToControl = null;
            this.xTextBox1.Size = new System.Drawing.Size(980, 414);
            this.xTextBox1.TabIndex = 0;
            this.xTextBox1.Text = resources.GetString("xTextBox1.Text");
            this.xTextBox1.TextIsChanged = false;
            // 
            // XMLTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 473);
            this.Controls.Add(this.btnGeneral);
            this.Controls.Add(this.xTextBox1);
            this.Name = "XMLTest";
            this.Text = "XMLTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private hwj.UserControls.CommonControls.xTextBox xTextBox1;
        private hwj.UserControls.CommonControls.xButton btnGeneral;
    }
}