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
            this.SuspendLayout();
            // 
            // btnAddText
            // 
            this.btnAddText.AccessibleDescription = null;
            this.btnAddText.AccessibleName = null;
            resources.ApplyResources(this.btnAddText, "btnAddText");
            this.btnAddText.BackgroundImage = null;
            this.btnAddText.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnAddText.Font = null;
            this.btnAddText.Name = "btnAddText";
            this.btnAddText.UseVisualStyleBackColor = true;
            this.btnAddText.Click += new System.EventHandler(this.btnAddText_Click);
            // 
            // loginComboBox1
            // 
            this.loginComboBox1.AccessibleDescription = null;
            this.loginComboBox1.AccessibleName = null;
            resources.ApplyResources(this.loginComboBox1, "loginComboBox1");
            this.loginComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.loginComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.loginComboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.loginComboBox1.BackgroundImage = null;
            this.loginComboBox1.DefaultDisplayLastRecord = true;
            this.loginComboBox1.FileName = "LoginCBO";
            this.loginComboBox1.Font = null;
            this.loginComboBox1.FormattingEnabled = true;
            this.loginComboBox1.Name = "loginComboBox1";
            this.loginComboBox1.OldBackColor = System.Drawing.SystemColors.Window;
            // 
            // ControlsFrm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.btnAddText);
            this.Controls.Add(this.loginComboBox1);
            this.Font = null;
            this.Icon = null;
            this.Name = "ControlsFrm";
            this.ResumeLayout(false);

        }

        #endregion

        private hwj.UserControls.Other.LoginComboBox loginComboBox1;
        private hwj.UserControls.CommonControls.xButton btnAddText;
    }
}