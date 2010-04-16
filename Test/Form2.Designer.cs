namespace Test
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
            this.suggestBox1 = new hwj.UserControls.Suggest.SuggestBox();
            this.xButton1 = new hwj.UserControls.CommonControls.xButton();
            this.SuspendLayout();
            // 
            // suggestBox1
            // 
            this.suggestBox1.BackColor = System.Drawing.SystemColors.Window;
            this.suggestBox1.EmptyValue = "";
            this.suggestBox1.Image = ((System.Drawing.Image)(resources.GetObject("suggestBox1.Image")));
            this.suggestBox1.IsRequired = true;
            this.suggestBox1.ListWidth = 0;
            this.suggestBox1.Location = new System.Drawing.Point(81, 34);
            this.suggestBox1.MaxLength = 32767;
            this.suggestBox1.Name = "suggestBox1";
            this.suggestBox1.OldBackColor = System.Drawing.SystemColors.Window;
            this.suggestBox1.PrimaryColumnHeaderName = null;
            this.suggestBox1.SecondColumnHeaderName = null;
            this.suggestBox1.SecondColumnMode = false;
            this.suggestBox1.SelectedText = "";
            this.suggestBox1.SelectedValue = "";
            this.suggestBox1.Size = new System.Drawing.Size(120, 21);
            this.suggestBox1.TabIndex = 0;
            // 
            // xButton1
            // 
            this.xButton1.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.xButton1.Location = new System.Drawing.Point(183, 95);
            this.xButton1.Name = "xButton1";
            this.xButton1.Size = new System.Drawing.Size(75, 23);
            this.xButton1.TabIndex = 1;
            this.xButton1.Text = "xButton1";
            this.xButton1.UseVisualStyleBackColor = true;
            this.xButton1.Click += new System.EventHandler(this.xButton1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.xButton1);
            this.Controls.Add(this.suggestBox1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private hwj.UserControls.Suggest.SuggestBox suggestBox1;
        private hwj.UserControls.CommonControls.xButton xButton1;
    }
}