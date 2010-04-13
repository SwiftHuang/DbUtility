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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlsFrm));
            this.btnAddText = new hwj.UserControls.CommonControls.xButton();
            this.loginComboBox1 = new hwj.UserControls.Other.LoginComboBox();
            this.xButton1 = new hwj.UserControls.CommonControls.xButton();
            this.SuspendLayout();
            // 
            // btnAddText
            // 
            this.btnAddText.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            resources.ApplyResources(this.btnAddText, "btnAddText");
            this.btnAddText.Name = "btnAddText";
            this.btnAddText.UseVisualStyleBackColor = true;
            this.btnAddText.Click += new System.EventHandler(this.btnAddText_Click);
            // 
            // loginComboBox1
            // 
            this.loginComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.loginComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.loginComboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.loginComboBox1.DefaultDisplayLastRecord = true;
            this.loginComboBox1.FileName = "LoginCBO";
            this.loginComboBox1.FormattingEnabled = true;
            resources.ApplyResources(this.loginComboBox1, "loginComboBox1");
            this.loginComboBox1.Name = "loginComboBox1";
            this.loginComboBox1.OldBackColor = System.Drawing.SystemColors.Window;
            // 
            // xButton1
            // 
            this.xButton1.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            resources.ApplyResources(this.xButton1, "xButton1");
            this.xButton1.Name = "xButton1";
            this.xButton1.UseVisualStyleBackColor = true;
            this.xButton1.Click += new System.EventHandler(this.xButton1_Click);
            // 
            // ControlsFrm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xButton1);
            this.Controls.Add(this.btnAddText);
            this.Controls.Add(this.loginComboBox1);
            this.Name = "ControlsFrm";
            this.ResumeLayout(false);

        }

        #endregion

        private hwj.UserControls.Other.LoginComboBox loginComboBox1;
        private hwj.UserControls.CommonControls.xButton btnAddText;
        private hwj.UserControls.CommonControls.xButton xButton1;
    }
}