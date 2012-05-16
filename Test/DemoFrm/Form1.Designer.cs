namespace Test.DemoFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkedListBox1 = new hwj.UserControls.CommonControls.xCheckedListBox();
            this.xTextBox2 = new hwj.UserControls.CommonControls.xTextBox();
            this.xButton1 = new hwj.UserControls.CommonControls.xButton();
            this.maskedDateTimePicker1 = new hwj.UserControls.Other.MaskedDateTimePicker();
            this.xDateTimePicker1 = new hwj.UserControls.CommonControls.xDateTimePicker();
            this.xTextBox1 = new hwj.UserControls.CommonControls.xTextBox();
            this.suggestBox1 = new hwj.UserControls.Suggest.SuggestBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(146, 157);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 5;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.checkedListBox1.Location = new System.Drawing.Point(12, 157);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 84);
            this.checkedListBox1.TabIndex = 8;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            // 
            // xTextBox2
            // 
            this.xTextBox2.BackColor = System.Drawing.SystemColors.Window;
            this.xTextBox2.Format = null;
            this.xTextBox2.Location = new System.Drawing.Point(149, 183);
            this.xTextBox2.Name = "xTextBox2";
            this.xTextBox2.OldBackColor = System.Drawing.SystemColors.Window;
            this.xTextBox2.PasswordChar = '-';
            this.xTextBox2.RequiredHandle = null;
            this.xTextBox2.SetValueToControl = null;
            this.xTextBox2.Size = new System.Drawing.Size(100, 21);
            this.xTextBox2.TabIndex = 7;
            this.xTextBox2.TextIsChanged = false;
            // 
            // xButton1
            // 
            this.xButton1.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.xButton1.Location = new System.Drawing.Point(174, 64);
            this.xButton1.Name = "xButton1";
            this.xButton1.Size = new System.Drawing.Size(75, 23);
            this.xButton1.TabIndex = 6;
            this.xButton1.Text = "xButton1";
            this.xButton1.UseVisualStyleBackColor = true;
            this.xButton1.Click += new System.EventHandler(this.xButton1_Click);
            // 
            // maskedDateTimePicker1
            // 
            this.maskedDateTimePicker1.BackColor = System.Drawing.SystemColors.Window;
            this.maskedDateTimePicker1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedDateTimePicker1.Checked = false;
            this.maskedDateTimePicker1.Format = "yyyy-MM-dd";
            this.maskedDateTimePicker1.Location = new System.Drawing.Point(89, 130);
            this.maskedDateTimePicker1.MinimumSize = new System.Drawing.Size(50, 21);
            this.maskedDateTimePicker1.Name = "maskedDateTimePicker1";
            this.maskedDateTimePicker1.SetValueToControl = null;
            this.maskedDateTimePicker1.Size = new System.Drawing.Size(90, 21);
            this.maskedDateTimePicker1.TabIndex = 4;
            this.maskedDateTimePicker1.ValueChanged += new System.EventHandler(this.maskedDateTimePicker1_ValueChanged);
            // 
            // xDateTimePicker1
            // 
            this.xDateTimePicker1.Location = new System.Drawing.Point(67, 93);
            this.xDateTimePicker1.Name = "xDateTimePicker1";
            this.xDateTimePicker1.SetValueToControl = null;
            this.xDateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.xDateTimePicker1.TabIndex = 3;
            // 
            // xTextBox1
            // 
            this.xTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.xTextBox1.ContentType = hwj.UserControls.CommonControls.ContentType.Numberic;
            this.xTextBox1.Format = "N2";
            this.xTextBox1.Location = new System.Drawing.Point(12, 22);
            this.xTextBox1.Name = "xTextBox1";
            this.xTextBox1.OldBackColor = System.Drawing.SystemColors.Window;
            this.xTextBox1.RequiredHandle = null;
            this.xTextBox1.SetValueToControl = null;
            this.xTextBox1.Size = new System.Drawing.Size(100, 21);
            this.xTextBox1.TabIndex = 2;
            this.xTextBox1.TextIsChanged = false;
            // 
            // suggestBox1
            // 
            this.suggestBox1.BackColor = System.Drawing.SystemColors.Window;
            this.suggestBox1.EmptyValue = "";
            this.suggestBox1.Image = ((System.Drawing.Image)(resources.GetObject("suggestBox1.Image")));
            this.suggestBox1.ListWidth = 0;
            this.suggestBox1.Location = new System.Drawing.Point(129, 22);
            this.suggestBox1.MaxLength = 32767;
            this.suggestBox1.MinimumSize = new System.Drawing.Size(0, 21);
            this.suggestBox1.Name = "suggestBox1";
            this.suggestBox1.OldBackColor = System.Drawing.SystemColors.Window;
            this.suggestBox1.PrimaryColumnHeaderName = null;
            this.suggestBox1.SecondColumnHeaderName = null;
            this.suggestBox1.SecondColumnMode = false;
            this.suggestBox1.SelectedItem = null;
            this.suggestBox1.SelectedText = "";
            this.suggestBox1.SelectedValue = "";
            this.suggestBox1.SetValueToControl = null;
            this.suggestBox1.Size = new System.Drawing.Size(120, 21);
            this.suggestBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.xTextBox2);
            this.Controls.Add(this.xButton1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.maskedDateTimePicker1);
            this.Controls.Add(this.xDateTimePicker1);
            this.Controls.Add(this.xTextBox1);
            this.Controls.Add(this.suggestBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private hwj.UserControls.Suggest.SuggestBox suggestBox1;
        private hwj.UserControls.CommonControls.xTextBox xTextBox1;
        private hwj.UserControls.CommonControls.xDateTimePicker xDateTimePicker1;
        private hwj.UserControls.Other.MaskedDateTimePicker maskedDateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox1;
        private hwj.UserControls.CommonControls.xButton xButton1;
        private hwj.UserControls.CommonControls.xTextBox xTextBox2;
        private hwj.UserControls.CommonControls.xCheckedListBox checkedListBox1;



    }
}