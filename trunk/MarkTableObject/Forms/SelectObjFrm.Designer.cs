namespace hwj.MarkTableObject.Forms
{
    partial class SelectObjFrm
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
            this.lstPrjObj = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstGenObj = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnNext = new hwj.UserControls.CommonControls.xButton();
            this.btnCancel = new hwj.UserControls.CommonControls.xButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpTable = new System.Windows.Forms.TabPage();
            this.tpView = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpTable.SuspendLayout();
            this.tpView.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstPrjObj
            // 
            this.lstPrjObj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPrjObj.FormattingEnabled = true;
            this.lstPrjObj.ItemHeight = 12;
            this.lstPrjObj.Location = new System.Drawing.Point(3, 17);
            this.lstPrjObj.Name = "lstPrjObj";
            this.lstPrjObj.Size = new System.Drawing.Size(311, 376);
            this.lstPrjObj.TabIndex = 0;
            this.lstPrjObj.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstPrjObj_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstPrjObj);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 402);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "表对象";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstGenObj);
            this.groupBox2.Location = new System.Drawing.Point(408, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(317, 402);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "生成对象";
            // 
            // lstGenObj
            // 
            this.lstGenObj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstGenObj.FormattingEnabled = true;
            this.lstGenObj.ItemHeight = 12;
            this.lstGenObj.Location = new System.Drawing.Point(3, 17);
            this.lstGenObj.Name = "lstGenObj";
            this.lstGenObj.Size = new System.Drawing.Size(311, 376);
            this.lstGenObj.TabIndex = 0;
            this.lstGenObj.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstGenObj_MouseDoubleClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(338, 121);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(46, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = ">>>";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(338, 160);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(46, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "<<<";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnNext.Location = new System.Drawing.Point(569, 446);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "下一步";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnCancel.Location = new System.Drawing.Point(650, 446);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpTable);
            this.tabControl1.Controls.Add(this.tpView);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(733, 440);
            this.tabControl1.TabIndex = 7;
            // 
            // tpTable
            // 
            this.tpTable.Controls.Add(this.button4);
            this.tpTable.Controls.Add(this.button3);
            this.tpTable.Controls.Add(this.groupBox1);
            this.tpTable.Controls.Add(this.groupBox2);
            this.tpTable.Location = new System.Drawing.Point(4, 22);
            this.tpTable.Name = "tpTable";
            this.tpTable.Padding = new System.Windows.Forms.Padding(3);
            this.tpTable.Size = new System.Drawing.Size(725, 414);
            this.tpTable.TabIndex = 0;
            this.tpTable.Text = "选择表";
            this.tpTable.UseVisualStyleBackColor = true;
            // 
            // tpView
            // 
            this.tpView.Controls.Add(this.groupBox4);
            this.tpView.Controls.Add(this.button1);
            this.tpView.Controls.Add(this.button2);
            this.tpView.Controls.Add(this.groupBox3);
            this.tpView.Location = new System.Drawing.Point(4, 22);
            this.tpView.Name = "tpView";
            this.tpView.Padding = new System.Windows.Forms.Padding(3);
            this.tpView.Size = new System.Drawing.Size(725, 414);
            this.tpView.TabIndex = 1;
            this.tpView.Text = "选择视图";
            this.tpView.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBox1);
            this.groupBox3.Location = new System.Drawing.Point(8, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(317, 402);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "项目对象";
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(3, 17);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(311, 376);
            this.listBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(339, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "<<<";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(339, 176);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(46, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = ">>>";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBox2);
            this.groupBox4.Location = new System.Drawing.Point(405, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(317, 402);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "生成对象";
            // 
            // listBox2
            // 
            this.listBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(3, 17);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(311, 376);
            this.listBox2.TabIndex = 0;
            // 
            // SelectObjFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 475);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnCancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(749, 513);
            this.Name = "SelectObjFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择对象";
            this.Load += new System.EventHandler(this.SelectObjFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpTable.ResumeLayout(false);
            this.tpView.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstPrjObj;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstGenObj;
        private hwj.UserControls.CommonControls.xButton btnCancel;
        private hwj.UserControls.CommonControls.xButton btnNext;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpTable;
        private System.Windows.Forms.TabPage tpView;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox listBox1;
    }
}