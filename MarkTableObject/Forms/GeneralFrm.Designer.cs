namespace hwj.MarkTableObject.Forms
{
    partial class GeneralFrm
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
            this.btnGeneral = new hwj.UserControls.CommonControls.xButton();
            this.SuspendLayout();
            // 
            // btnGeneral
            // 
            this.btnGeneral.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnGeneral.Location = new System.Drawing.Point(549, 204);
            this.btnGeneral.Name = "btnGeneral";
            this.btnGeneral.Size = new System.Drawing.Size(75, 23);
            this.btnGeneral.TabIndex = 0;
            this.btnGeneral.Text = "生 成";
            this.btnGeneral.UseVisualStyleBackColor = true;
            this.btnGeneral.Click += new System.EventHandler(this.btnGeneral_Click);
            // 
            // GeneralFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 390);
            this.Controls.Add(this.btnGeneral);
            this.Name = "GeneralFrm";
            this.Text = "GeneralFrm";
            this.ResumeLayout(false);

        }

        #endregion

        private hwj.UserControls.CommonControls.xButton btnGeneral;
    }
}