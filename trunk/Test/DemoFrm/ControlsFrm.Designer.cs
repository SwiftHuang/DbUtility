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
            this.xTextBox1 = new hwj.UserControls.CommonControls.xTextBox();
            this.txtTestAmtTxt = new hwj.UserControls.CommonControls.xButton();
            this.txtAmt = new hwj.UserControls.CommonControls.xTextBox();
            this.btnAddText = new hwj.UserControls.CommonControls.xButton();
            this.loginComboBox1 = new hwj.UserControls.Other.LoginComboBox();
            this.SuspendLayout();
            // 
            // xTextBox1
            // 
            this.xTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.xTextBox1.ContentType = hwj.UserControls.CommonControls.ContentType.Integer;
            this.xTextBox1.Format = "D";
            resources.ApplyResources(this.xTextBox1, "xTextBox1");
            this.xTextBox1.Name = "xTextBox1";
            this.xTextBox1.OldBackColor = System.Drawing.SystemColors.Window;
            this.xTextBox1.SetValueToControl = null;
            this.xTextBox1.TextIsChanged = false;
            // 
            // txtTestAmtTxt
            // 
            this.txtTestAmtTxt.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            resources.ApplyResources(this.txtTestAmtTxt, "txtTestAmtTxt");
            this.txtTestAmtTxt.Name = "txtTestAmtTxt";
            this.txtTestAmtTxt.UseVisualStyleBackColor = true;
            // 
            // txtAmt
            // 
            this.txtAmt.BackColor = System.Drawing.SystemColors.Window;
            this.txtAmt.ContentType = hwj.UserControls.CommonControls.ContentType.Numberic;
            this.txtAmt.Format = "N";
            this.txtAmt.IsRequired = true;
            resources.ApplyResources(this.txtAmt, "txtAmt");
            this.txtAmt.Name = "txtAmt";
            this.txtAmt.OldBackColor = System.Drawing.SystemColors.Window;
            this.txtAmt.SetValueToControl = null;
            this.txtAmt.TextIsChanged = false;
            this.txtAmt.Validating += new System.ComponentModel.CancelEventHandler(this.txtAmt_Validating);
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
            this.loginComboBox1.FileName = "";
            this.loginComboBox1.FormattingEnabled = true;
            resources.ApplyResources(this.loginComboBox1, "loginComboBox1");
            this.loginComboBox1.Name = "loginComboBox1";
            this.loginComboBox1.OldBackColor = System.Drawing.SystemColors.Window;
            // 
            // ControlsFrm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xTextBox1);
            this.Controls.Add(this.txtTestAmtTxt);
            this.Controls.Add(this.txtAmt);
            this.Controls.Add(this.btnAddText);
            this.Controls.Add(this.loginComboBox1);
            this.Name = "ControlsFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private hwj.UserControls.Other.LoginComboBox loginComboBox1;
        private hwj.UserControls.CommonControls.xButton btnAddText;
        private hwj.UserControls.CommonControls.xTextBox txtAmt;
        private hwj.UserControls.CommonControls.xButton txtTestAmtTxt;
        private hwj.UserControls.CommonControls.xTextBox xTextBox1;
    }
}