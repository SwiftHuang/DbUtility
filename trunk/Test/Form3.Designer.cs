namespace Test
{
    partial class Form3
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
            this.xSplitContainer1 = new hwj.UserControls.Other.xSplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.xSplitContainer1.Panel2.SuspendLayout();
            this.xSplitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xSplitContainer1
            // 
            this.xSplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xSplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.xSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.xSplitContainer1.Name = "xSplitContainer1";
            this.xSplitContainer1.Panel1MinSize = 0;
            // 
            // xSplitContainer1.Panel2
            // 
            this.xSplitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.xSplitContainer1.Panel2MinSize = 0;
            this.xSplitContainer1.Size = new System.Drawing.Size(620, 424);
            this.xSplitContainer1.SplitterButtonBackGround = null;
            this.xSplitContainer1.SplitterButtonBackGroundHover = null;
            this.xSplitContainer1.SplitterDirection = hwj.UserControls.Other.SplitterDirection.None;
            this.xSplitContainer1.SplitterDistance = 249;
            this.xSplitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(365, 422);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(357, 397);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(357, 397);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 424);
            this.Controls.Add(this.xSplitContainer1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.xSplitContainer1.Panel2.ResumeLayout(false);
            this.xSplitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private hwj.UserControls.Other.xSplitContainer xSplitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}