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
            this.loginComboBox1 = new hwj.UserControls.Other.LoginComboBox();
            this.btnAddText = new hwj.UserControls.CommonControls.xButton();
            this.SuspendLayout();
            // 
            // loginComboBox1
            // 
            this.loginComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.loginComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.loginComboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.loginComboBox1.FileName = "LoginCBO";
            this.loginComboBox1.FormattingEnabled = true;
            this.loginComboBox1.Location = new System.Drawing.Point(497, 164);
            this.loginComboBox1.Name = "loginComboBox1";
            this.loginComboBox1.OldBackColor = System.Drawing.SystemColors.Window;
            this.loginComboBox1.Size = new System.Drawing.Size(121, 20);
            this.loginComboBox1.TabIndex = 0;
            // 
            // btnAddText
            // 
            this.btnAddText.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnAddText.Location = new System.Drawing.Point(543, 190);
            this.btnAddText.Name = "btnAddText";
            this.btnAddText.Size = new System.Drawing.Size(75, 23);
            this.btnAddText.TabIndex = 1;
            this.btnAddText.Text = "Add";
            this.btnAddText.UseVisualStyleBackColor = true;
            this.btnAddText.Click += new System.EventHandler(this.btnAddText_Click);
            // 
            // ControlsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 479);
            this.Controls.Add(this.btnAddText);
            this.Controls.Add(this.loginComboBox1);
            this.Name = "ControlsFrm";
            this.Text = "ControlsFrm";
            this.ResumeLayout(false);

        }

        #endregion

        private hwj.UserControls.Other.LoginComboBox loginComboBox1;
        private hwj.UserControls.CommonControls.xButton btnAddText;
    }
}