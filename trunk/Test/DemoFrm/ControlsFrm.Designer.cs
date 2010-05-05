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
            this.xTextBox1 = new hwj.UserControls.CommonControls.xTextBox();
            this.maskedDateTimePicker1 = new hwj.UserControls.Other.MaskedDateTimePicker();
            this.maskedDateTimePicker2 = new hwj.UserControls.Other.MaskedDateTimePicker();
            this.SuspendLayout();
            // 
            // xTextBox1
            // 
            this.xTextBox1.AutoSelectAll = true;
            this.xTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.xTextBox1.Format = null;
            this.xTextBox1.Location = new System.Drawing.Point(289, 244);
            this.xTextBox1.Name = "xTextBox1";
            this.xTextBox1.OldBackColor = System.Drawing.SystemColors.Window;
            this.xTextBox1.SetValueToControl = null;
            this.xTextBox1.Size = new System.Drawing.Size(100, 21);
            this.xTextBox1.TabIndex = 3;
            this.xTextBox1.TextIsChanged = false;
            // 
            // maskedDateTimePicker1
            // 
            this.maskedDateTimePicker1.BackColor = System.Drawing.SystemColors.Window;
            this.maskedDateTimePicker1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedDateTimePicker1.Checked = false;
            this.maskedDateTimePicker1.Format = "yyyy-M-d";
            this.maskedDateTimePicker1.Location = new System.Drawing.Point(270, 164);
            this.maskedDateTimePicker1.MinimumSize = new System.Drawing.Size(50, 21);
            this.maskedDateTimePicker1.Name = "maskedDateTimePicker1";
            this.maskedDateTimePicker1.SetValueToControl = null;
            this.maskedDateTimePicker1.Size = new System.Drawing.Size(90, 21);
            this.maskedDateTimePicker1.TabIndex = 2;
            this.maskedDateTimePicker1.Value = new System.DateTime(2010, 5, 5, 15, 54, 55, 640);
            // 
            // maskedDateTimePicker2
            // 
            this.maskedDateTimePicker2.BackColor = System.Drawing.SystemColors.Window;
            this.maskedDateTimePicker2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedDateTimePicker2.Checked = false;
            this.maskedDateTimePicker2.Format = "yyyy-M-d";
            this.maskedDateTimePicker2.Location = new System.Drawing.Point(242, 92);
            this.maskedDateTimePicker2.MinimumSize = new System.Drawing.Size(50, 21);
            this.maskedDateTimePicker2.Name = "maskedDateTimePicker2";
            this.maskedDateTimePicker2.SetValueToControl = null;
            this.maskedDateTimePicker2.Size = new System.Drawing.Size(111, 21);
            this.maskedDateTimePicker2.TabIndex = 1;
            this.maskedDateTimePicker2.Value = new System.DateTime(2010, 5, 5, 15, 54, 55, 656);
            // 
            // ControlsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 385);
            this.Controls.Add(this.xTextBox1);
            this.Controls.Add(this.maskedDateTimePicker1);
            this.Controls.Add(this.maskedDateTimePicker2);
            this.Name = "ControlsFrm";
            this.Text = "ControlsFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private hwj.UserControls.Other.MaskedDateTimePicker maskedDateTimePicker2;
        private hwj.UserControls.Other.MaskedDateTimePicker maskedDateTimePicker1;
        private hwj.UserControls.CommonControls.xTextBox xTextBox1;

    }
}