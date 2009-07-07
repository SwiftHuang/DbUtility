namespace Test
{
    partial class Suggest
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
            this.suggestBox1 = new hwj.UserControls.Suggest.SuggestBox();
            this.SuspendLayout();
            // 
            // suggestBox1
            // 
            this.suggestBox1.BackColor = System.Drawing.SystemColors.Window;
            this.suggestBox1.EmptyValue = "";
            this.suggestBox1.Location = new System.Drawing.Point(252, 88);
            this.suggestBox1.MaxLength = 32767;
            this.suggestBox1.Name = "suggestBox1";
            this.suggestBox1.PrimaryColumnHeaderName = null;
            this.suggestBox1.SecondColumnHeaderName = null;
            this.suggestBox1.SecondColumnMode = false;
            this.suggestBox1.SelectedText = "";
            this.suggestBox1.SelectedValue = "";
            this.suggestBox1.Size = new System.Drawing.Size(120, 21);
            this.suggestBox1.TabIndex = 0;
            this.suggestBox1.DataBinding += new System.EventHandler(this.suggestBox1_DataBinding);
            // 
            // Suggest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 412);
            this.Controls.Add(this.suggestBox1);
            this.Name = "Suggest";
            this.Text = "Suggest";
            this.ResumeLayout(false);

        }

        #endregion

        private hwj.UserControls.Suggest.SuggestBox suggestBox1;
    }
}