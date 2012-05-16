namespace Test.DemoFrm
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.button1 = new System.Windows.Forms.Button();
            this.suggestBoxView1 = new hwj.UserControls.Suggest.View.SuggestBoxView();
            this.btnDBTest = new System.Windows.Forms.Button();
            this.btnSVCDLL = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(161, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // suggestBoxView1
            // 
            this.suggestBoxView1.BackColor = System.Drawing.SystemColors.Window;
            this.suggestBoxView1.EmptyValue = "";
            this.suggestBoxView1.FilterString = null;
            this.suggestBoxView1.FirstMember = null;
            this.suggestBoxView1.Image = ((System.Drawing.Image)(resources.GetObject("suggestBoxView1.Image")));
            this.suggestBoxView1.ListWidth = 0;
            this.suggestBoxView1.Location = new System.Drawing.Point(62, 143);
            this.suggestBoxView1.MaxLength = 32767;
            this.suggestBoxView1.MinimumSize = new System.Drawing.Size(0, 21);
            this.suggestBoxView1.Name = "suggestBoxView1";
            this.suggestBoxView1.OldBackColor = System.Drawing.SystemColors.Window;
            this.suggestBoxView1.PrimaryColumnHeaderName = null;
            this.suggestBoxView1.SecondColumnHeaderName = null;
            this.suggestBoxView1.SecondColumnMode = false;
            this.suggestBoxView1.SecondMember = null;
            this.suggestBoxView1.SetValueToControl = null;
            this.suggestBoxView1.Size = new System.Drawing.Size(120, 21);
            this.suggestBoxView1.TabIndex = 1;
            this.suggestBoxView1.ValueMember = null;
            // 
            // btnDBTest
            // 
            this.btnDBTest.Location = new System.Drawing.Point(106, 88);
            this.btnDBTest.Name = "btnDBTest";
            this.btnDBTest.Size = new System.Drawing.Size(75, 23);
            this.btnDBTest.TabIndex = 2;
            this.btnDBTest.Text = "DB Test";
            this.btnDBTest.UseVisualStyleBackColor = true;
            this.btnDBTest.Click += new System.EventHandler(this.btnDBTest_Click);
            // 
            // btnSVCDLL
            // 
            this.btnSVCDLL.Location = new System.Drawing.Point(119, 187);
            this.btnSVCDLL.Name = "btnSVCDLL";
            this.btnSVCDLL.Size = new System.Drawing.Size(75, 23);
            this.btnSVCDLL.TabIndex = 3;
            this.btnSVCDLL.Text = "SVCDLL";
            this.btnSVCDLL.UseVisualStyleBackColor = true;
            this.btnSVCDLL.Click += new System.EventHandler(this.btnSVCDLL_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.btnSVCDLL);
            this.Controls.Add(this.btnDBTest);
            this.Controls.Add(this.suggestBoxView1);
            this.Controls.Add(this.button1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private hwj.UserControls.Suggest.View.SuggestBoxView suggestBoxView1;
        private System.Windows.Forms.Button btnDBTest;
        private System.Windows.Forms.Button btnSVCDLL;
    }
}