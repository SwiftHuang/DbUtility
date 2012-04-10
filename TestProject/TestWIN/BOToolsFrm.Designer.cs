namespace TestWIN
{
    partial class BOToolsFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGen = new System.Windows.Forms.Button();
            this.txtWSUrl = new System.Windows.Forms.TextBox();
            this.txtMethod = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnSetData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(570, 76);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(75, 23);
            this.btnGen.TabIndex = 0;
            this.btnGen.Text = "General";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // txtWSUrl
            // 
            this.txtWSUrl.Location = new System.Drawing.Point(25, 22);
            this.txtWSUrl.Name = "txtWSUrl";
            this.txtWSUrl.Size = new System.Drawing.Size(620, 21);
            this.txtWSUrl.TabIndex = 1;
            this.txtWSUrl.Text = "http://localhost:2212/BOTools.asmx";
            // 
            // txtMethod
            // 
            this.txtMethod.Location = new System.Drawing.Point(25, 49);
            this.txtMethod.Name = "txtMethod";
            this.txtMethod.Size = new System.Drawing.Size(620, 21);
            this.txtMethod.TabIndex = 1;
            this.txtMethod.Text = "GetInvoice";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(25, 120);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(620, 251);
            this.txtResult.TabIndex = 1;
            // 
            // btnSetData
            // 
            this.btnSetData.Location = new System.Drawing.Point(489, 76);
            this.btnSetData.Name = "btnSetData";
            this.btnSetData.Size = new System.Drawing.Size(75, 23);
            this.btnSetData.TabIndex = 0;
            this.btnSetData.Text = "Set Data";
            this.btnSetData.UseVisualStyleBackColor = true;
            this.btnSetData.Click += new System.EventHandler(this.btnSetData_Click);
            // 
            // BOToolsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 395);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtMethod);
            this.Controls.Add(this.txtWSUrl);
            this.Controls.Add(this.btnSetData);
            this.Controls.Add(this.btnGen);
            this.Name = "BOToolsFrm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.TextBox txtWSUrl;
        private System.Windows.Forms.TextBox txtMethod;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnSetData;
    }
}

