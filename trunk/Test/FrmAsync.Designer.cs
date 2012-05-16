namespace Test
{
    partial class FrmAsync
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
            this.button1 = new System.Windows.Forms.Button();
            this.bwGetList = new System.ComponentModel.BackgroundWorker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.bwGetList2 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(676, 539);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bwGetList
            // 
            this.bwGetList.WorkerReportsProgress = true;
            this.bwGetList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwGetList_DoWork);
            this.bwGetList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwGetList_RunWorkerCompleted);
            this.bwGetList.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwGetList_ProgressChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(362, 521);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(389, 12);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(362, 521);
            this.textBox2.TabIndex = 2;
            // 
            // bwGetList2
            // 
            this.bwGetList2.WorkerReportsProgress = true;
            this.bwGetList2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwGetList2_DoWork);
            this.bwGetList2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwGetList2_RunWorkerCompleted);
            this.bwGetList2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwGetList2_ProgressChanged);
            // 
            // FrmAsync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 579);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "FrmAsync";
            this.Text = "FrmAsync";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker bwGetList;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.ComponentModel.BackgroundWorker bwGetList2;
    }
}