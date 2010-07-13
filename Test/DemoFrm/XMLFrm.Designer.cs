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
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnTestTime = new hwj.UserControls.CommonControls.xButton();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnClean = new hwj.UserControls.CommonControls.xButton();
            this.SuspendLayout();
            // 
            // txtXML
            // 
            this.txtXML.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtXML.Location = new System.Drawing.Point(6, 7);
            this.txtXML.Multiline = true;
            this.txtXML.Name = "txtXML";
            this.txtXML.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtXML.Size = new System.Drawing.Size(586, 404);
            this.txtXML.TabIndex = 0;
            this.txtXML.Text = resources.GetString("txtXML.Text");
            // 
            // btnGeneral
            // 
            this.btnGeneral.Location = new System.Drawing.Point(517, 419);
            this.btnGeneral.Name = "btnGeneral";
            this.btnGeneral.Size = new System.Drawing.Size(75, 23);
            this.btnGeneral.TabIndex = 1;
            this.btnGeneral.Text = "General";
            this.btnGeneral.UseVisualStyleBackColor = true;
            this.btnGeneral.Click += new System.EventHandler(this.btnGeneral_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(603, 8);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(586, 404);
            this.txtOutput.TabIndex = 0;
            // 
            // btnTestTime
            // 
            this.btnTestTime.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnTestTime.Location = new System.Drawing.Point(436, 419);
            this.btnTestTime.Name = "btnTestTime";
            this.btnTestTime.Size = new System.Drawing.Size(75, 23);
            this.btnTestTime.TabIndex = 2;
            this.btnTestTime.Text = "Test";
            this.btnTestTime.UseVisualStyleBackColor = true;
            this.btnTestTime.Click += new System.EventHandler(this.btnTestTime_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(12, 424);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(41, 12);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "label1";
            // 
            // btnClean
            // 
            this.btnClean.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnClean.Location = new System.Drawing.Point(355, 419);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(75, 23);
            this.btnClean.TabIndex = 4;
            this.btnClean.Text = "Clean";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // XMLFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 454);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnTestTime);
            this.Controls.Add(this.btnGeneral);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtXML);
            this.Name = "XMLFrm";
            this.Text = "XMLFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtXML;
        private System.Windows.Forms.Button btnGeneral;
        private System.Windows.Forms.TextBox txtOutput;
        private hwj.UserControls.CommonControls.xButton btnTestTime;
        private System.Windows.Forms.Label lblTime;
        private hwj.UserControls.CommonControls.xButton btnClean;
    }
}