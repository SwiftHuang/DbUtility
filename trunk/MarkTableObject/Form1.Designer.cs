namespace hwj.MarkTableObject
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtConn = new System.Windows.Forms.TextBox();
            this.txtSql = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(329, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtConn
            // 
            this.txtConn.Location = new System.Drawing.Point(90, 30);
            this.txtConn.Name = "txtConn";
            this.txtConn.Size = new System.Drawing.Size(420, 21);
            this.txtConn.TabIndex = 1;
            this.txtConn.Text = "Provider=SQLOLEDB;Data Source=192.168.1.200;Password=113502;User ID=sa;Initial Ca" +
                "talog=eAccount";
            // 
            // txtSql
            // 
            this.txtSql.Location = new System.Drawing.Point(90, 57);
            this.txtSql.Name = "txtSql";
            this.txtSql.Size = new System.Drawing.Size(420, 21);
            this.txtSql.TabIndex = 2;
            this.txtSql.Text = "select * from artx";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 327);
            this.Controls.Add(this.txtSql);
            this.Controls.Add(this.txtConn);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtConn;
        private System.Windows.Forms.TextBox txtSql;
    }
}

