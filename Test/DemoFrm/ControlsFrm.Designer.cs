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
            this.button1 = new System.Windows.Forms.Button();
            this.bgw1 = new System.ComponentModel.BackgroundWorker();
            this.bgw2 = new System.ComponentModel.BackgroundWorker();
            this.xTextBox3 = new hwj.UserControls.CommonControls.xTextBox();
            this.xTextBox2 = new hwj.UserControls.CommonControls.xTextBox();
            this.suggestBoxView1 = new hwj.UserControls.Suggest.View.SuggestBoxView();
            this.xTextBox1 = new hwj.UserControls.CommonControls.xTextBox();
            this.xLabel1 = new hwj.UserControls.CommonControls.xLabel();
            this.suggestBox1 = new hwj.UserControls.Suggest.SuggestBox();
            this.maskedDateTimePicker1 = new hwj.UserControls.Other.MaskedDateTimePicker();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(54, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bgw1
            // 
            this.bgw1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw1_DoWork);
            this.bgw1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw1_RunWorkerCompleted);
            // 
            // bgw2
            // 
            this.bgw2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw2_DoWork);
            this.bgw2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw2_RunWorkerCompleted);
            // 
            // xTextBox3
            // 
            this.xTextBox3.BackColor = System.Drawing.SystemColors.Window;
            this.xTextBox3.Format = null;
            this.xTextBox3.Location = new System.Drawing.Point(54, 298);
            this.xTextBox3.Name = "xTextBox3";
            this.xTextBox3.OldBackColor = System.Drawing.SystemColors.Window;
            this.xTextBox3.RequiredHandle = null;
            this.xTextBox3.SetValueToControl = null;
            this.xTextBox3.Size = new System.Drawing.Size(337, 21);
            this.xTextBox3.TabIndex = 7;
            this.xTextBox3.TextIsChanged = false;
            // 
            // xTextBox2
            // 
            this.xTextBox2.BackColor = System.Drawing.SystemColors.Window;
            this.xTextBox2.Format = null;
            this.xTextBox2.Location = new System.Drawing.Point(54, 271);
            this.xTextBox2.Name = "xTextBox2";
            this.xTextBox2.OldBackColor = System.Drawing.SystemColors.Window;
            this.xTextBox2.RequiredHandle = null;
            this.xTextBox2.SetValueToControl = null;
            this.xTextBox2.Size = new System.Drawing.Size(100, 21);
            this.xTextBox2.TabIndex = 6;
            this.xTextBox2.TextIsChanged = false;
            // 
            // suggestBoxView1
            // 
            this.suggestBoxView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.suggestBoxView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.suggestBoxView1.EmptyValue = "";
            this.suggestBoxView1.FilterString = null;
            this.suggestBoxView1.FirstMember = "";
            this.suggestBoxView1.Image = ((System.Drawing.Image)(resources.GetObject("suggestBoxView1.Image")));
            this.suggestBoxView1.IsRequired = true;
            this.suggestBoxView1.ListWidth = 0;
            this.suggestBoxView1.Location = new System.Drawing.Point(54, 210);
            this.suggestBoxView1.MaxLength = 32767;
            this.suggestBoxView1.MinimumSize = new System.Drawing.Size(0, 21);
            this.suggestBoxView1.Name = "suggestBoxView1";
            this.suggestBoxView1.OldBackColor = System.Drawing.SystemColors.Window;
            this.suggestBoxView1.PrimaryColumnHeaderName = null;
            this.suggestBoxView1.SecondColumnHeaderName = null;
            this.suggestBoxView1.SecondColumnMode = false;
            this.suggestBoxView1.SecondMember = "";
            this.suggestBoxView1.SetValueToControl = null;
            this.suggestBoxView1.Size = new System.Drawing.Size(278, 21);
            this.suggestBoxView1.TabIndex = 5;
            this.suggestBoxView1.ValueMember = "";
            this.suggestBoxView1.SelectedValueChanged += new System.EventHandler(this.suggestBoxView1_SelectedValueChanged);
            this.suggestBoxView1.OnSelected += new hwj.UserControls.Suggest.View.SuggestBoxView.SelectedValueHandler(this.suggestBoxView1_OnSelected);
            // 
            // xTextBox1
            // 
            this.xTextBox1.AutoSelectAll = true;
            this.xTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.xTextBox1.ContentType = hwj.UserControls.CommonControls.ContentType.Numberic;
            this.xTextBox1.Format = "N2";
            this.xTextBox1.Location = new System.Drawing.Point(291, 61);
            this.xTextBox1.Name = "xTextBox1";
            this.xTextBox1.OldBackColor = System.Drawing.SystemColors.Window;
            this.xTextBox1.RequiredHandle = null;
            this.xTextBox1.SetValueToControl = null;
            this.xTextBox1.Size = new System.Drawing.Size(100, 21);
            this.xTextBox1.TabIndex = 3;
            this.xTextBox1.Text = "0.00";
            this.xTextBox1.TextIsChanged = false;
            // 
            // xLabel1
            // 
            this.xLabel1.ClipboardEnabled = true;
            this.xLabel1.ClipboardFont = null;
            this.xLabel1.Location = new System.Drawing.Point(120, 53);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(137, 29);
            this.xLabel1.TabIndex = 2;
            this.xLabel1.Text = "xLabel1";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // suggestBox1
            // 
            this.suggestBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.suggestBox1.EmptyValue = "";
            this.suggestBox1.Image = ((System.Drawing.Image)(resources.GetObject("suggestBox1.Image")));
            this.suggestBox1.IsRequired = true;
            this.suggestBox1.ListWidth = 0;
            this.suggestBox1.Location = new System.Drawing.Point(54, 170);
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
            this.suggestBox1.Size = new System.Drawing.Size(278, 21);
            this.suggestBox1.TabIndex = 1;
            // 
            // maskedDateTimePicker1
            // 
            this.maskedDateTimePicker1.BackColor = System.Drawing.SystemColors.Window;
            this.maskedDateTimePicker1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedDateTimePicker1.Checked = false;
            this.maskedDateTimePicker1.Format = "yyyy-MM-dd";
            this.maskedDateTimePicker1.Location = new System.Drawing.Point(167, 125);
            this.maskedDateTimePicker1.MinimumSize = new System.Drawing.Size(50, 21);
            this.maskedDateTimePicker1.Name = "maskedDateTimePicker1";
            this.maskedDateTimePicker1.SetValueToControl = null;
            this.maskedDateTimePicker1.Size = new System.Drawing.Size(90, 21);
            this.maskedDateTimePicker1.TabIndex = 0;
            // 
            // ControlsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 385);
            this.Controls.Add(this.xTextBox3);
            this.Controls.Add(this.xTextBox2);
            this.Controls.Add(this.suggestBoxView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.xTextBox1);
            this.Controls.Add(this.xLabel1);
            this.Controls.Add(this.suggestBox1);
            this.Controls.Add(this.maskedDateTimePicker1);
            this.Name = "ControlsFrm";
            this.Text = "ControlsFrm";
            this.Load += new System.EventHandler(this.ControlsFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private hwj.UserControls.Other.MaskedDateTimePicker maskedDateTimePicker1;
        private hwj.UserControls.Suggest.SuggestBox suggestBox1;
        private hwj.UserControls.CommonControls.xLabel xLabel1;
        private hwj.UserControls.CommonControls.xTextBox xTextBox1;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker bgw1;
        private System.ComponentModel.BackgroundWorker bgw2;
        private hwj.UserControls.Suggest.View.SuggestBoxView suggestBoxView1;
        private hwj.UserControls.CommonControls.xTextBox xTextBox2;
        private hwj.UserControls.CommonControls.xTextBox xTextBox3;













    }
}