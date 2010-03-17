namespace Test.DemoFrm
{
    partial class XMLFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XMLFrm));
            this.txtXML = new System.Windows.Forms.TextBox();
            this.btnGeneral = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtXML
            // 
            this.txtXML.Location = new System.Drawing.Point(12, 12);
            this.txtXML.Multiline = true;
            this.txtXML.Name = "txtXML";
            this.txtXML.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtXML.Size = new System.Drawing.Size(680, 404);
            this.txtXML.TabIndex = 0;
            this.txtXML.Text = resources.GetString("txtXML.Text");
            // 
            // btnGeneral
            // 
            this.btnGeneral.Location = new System.Drawing.Point(617, 422);
            this.btnGeneral.Name = "btnGeneral";
            this.btnGeneral.Size = new System.Drawing.Size(75, 23);
            this.btnGeneral.TabIndex = 1;
            this.btnGeneral.Text = "General";
            this.btnGeneral.UseVisualStyleBackColor = true;
            this.btnGeneral.Click += new System.EventHandler(this.btnGeneral_Click);
            // 
            // XMLFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 454);
            this.Controls.Add(this.btnGeneral);
            this.Controls.Add(this.txtXML);
            this.Name = "XMLFrm";
            this.Text = "XMLFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtXML;
        private System.Windows.Forms.Button btnGeneral;
    }
}