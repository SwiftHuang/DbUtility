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
            this.btnTurnLeft = new System.Windows.Forms.Button();
            this.btnTurnRight = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpTable = new System.Windows.Forms.TabPage();
            this.tpView = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lstGenViewObj = new System.Windows.Forms.ListBox();
            this.btnTurnRightByView = new System.Windows.Forms.Button();
            this.btnTurnLeftByView = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstViewObj = new System.Windows.Forms.ListBox();
            this.btnNext = new hwj.UserControls.CommonControls.xButton();
            this.btnCancel = new hwj.UserControls.CommonControls.xButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTableCount = new System.Windows.Forms.Label();
            this.lblViewCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCleanView = new hwj.UserControls.CommonControls.xButton();
            this.btnCleanTable = new hwj.UserControls.CommonControls.xButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpTable.SuspendLayout();
            this.tpView.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstPrjObj
            // 
            this.lstPrjObj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPrjObj.FormattingEnabled = true;
            this.lstPrjObj.ItemHeight = 12;
            this.lstPrjObj.Location = new System.Drawing.Point(3, 17);
            this.lstPrjObj.Name = "lstPrjObj";
            this.lstPrjObj.Size = new System.Drawing.Size(311, 382);
            this.lstPrjObj.TabIndex = 0;
            this.lstPrjObj.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstPrjObj_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstPrjObj);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 402);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "表对象";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstGenObj);
            this.groupBox2.Location = new System.Drawing.Point(398, 3);
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
            this.lstGenObj.Size = new System.Drawing.Size(311, 382);
            this.lstGenObj.TabIndex = 0;
            this.lstGenObj.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstGenObj_MouseDoubleClick);
            // 
            // btnTurnLeft
            // 
            this.btnTurnLeft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTurnLeft.Location = new System.Drawing.Point(9, 13);
            this.btnTurnLeft.Name = "btnTurnLeft";
            this.btnTurnLeft.Size = new System.Drawing.Size(46, 23);
            this.btnTurnLeft.TabIndex = 0;
            this.btnTurnLeft.Text = ">>>";
            this.btnTurnLeft.UseVisualStyleBackColor = true;
            this.btnTurnLeft.Click += new System.EventHandler(this.btnTurnLeft_Click);
            // 
            // btnTurnRight
            // 
            this.btnTurnRight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTurnRight.Location = new System.Drawing.Point(9, 63);
            this.btnTurnRight.Name = "btnTurnRight";
            this.btnTurnRight.Size = new System.Drawing.Size(46, 23);
            this.btnTurnRight.TabIndex = 1;
            this.btnTurnRight.Text = "<<<";
            this.btnTurnRight.UseVisualStyleBackColor = true;
            this.btnTurnRight.Click += new System.EventHandler(this.btnTurnRight_Click);
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
            this.tabControl1.TabIndex = 0;
            // 
            // tpTable
            // 
            this.tpTable.Controls.Add(this.tableLayoutPanel4);
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
            this.tpView.Controls.Add(this.tableLayoutPanel2);
            this.tpView.Location = new System.Drawing.Point(4, 22);
            this.tpView.Name = "tpView";
            this.tpView.Padding = new System.Windows.Forms.Padding(3);
            this.tpView.Size = new System.Drawing.Size(725, 414);
            this.tpView.TabIndex = 1;
            this.tpView.Text = "选择视图";
            this.tpView.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lstGenViewObj);
            this.groupBox4.Location = new System.Drawing.Point(398, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(317, 402);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "生成对象";
            // 
            // lstGenViewObj
            // 
            this.lstGenViewObj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstGenViewObj.FormattingEnabled = true;
            this.lstGenViewObj.ItemHeight = 12;
            this.lstGenViewObj.Location = new System.Drawing.Point(3, 17);
            this.lstGenViewObj.Name = "lstGenViewObj";
            this.lstGenViewObj.Size = new System.Drawing.Size(311, 382);
            this.lstGenViewObj.TabIndex = 0;
            this.lstGenViewObj.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstGenViewObj_MouseDoubleClick);
            // 
            // btnTurnRightByView
            // 
            this.btnTurnRightByView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTurnRightByView.Location = new System.Drawing.Point(9, 63);
            this.btnTurnRightByView.Name = "btnTurnRightByView";
            this.btnTurnRightByView.Size = new System.Drawing.Size(46, 23);
            this.btnTurnRightByView.TabIndex = 1;
            this.btnTurnRightByView.Text = "<<<";
            this.btnTurnRightByView.UseVisualStyleBackColor = true;
            this.btnTurnRightByView.Click += new System.EventHandler(this.btnTurnRightByView_Click);
            // 
            // btnTurnLeftByView
            // 
            this.btnTurnLeftByView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTurnLeftByView.Location = new System.Drawing.Point(9, 13);
            this.btnTurnLeftByView.Name = "btnTurnLeftByView";
            this.btnTurnLeftByView.Size = new System.Drawing.Size(46, 23);
            this.btnTurnLeftByView.TabIndex = 0;
            this.btnTurnLeftByView.Text = ">>>";
            this.btnTurnLeftByView.UseVisualStyleBackColor = true;
            this.btnTurnLeftByView.Click += new System.EventHandler(this.btnTurnLeftByView_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstViewObj);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(317, 402);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "项目对象";
            // 
            // lstViewObj
            // 
            this.lstViewObj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstViewObj.FormattingEnabled = true;
            this.lstViewObj.ItemHeight = 12;
            this.lstViewObj.Location = new System.Drawing.Point(3, 17);
            this.lstViewObj.Name = "lstViewObj";
            this.lstViewObj.Size = new System.Drawing.Size(311, 382);
            this.lstViewObj.TabIndex = 0;
            this.lstViewObj.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstViewObj_MouseDoubleClick);
            // 
            // btnNext
            // 
            this.btnNext.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnNext.Location = new System.Drawing.Point(574, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "下一步";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnCancel.Location = new System.Drawing.Point(655, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnNext, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTableCount, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblViewCount, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCleanView, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCleanTable, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 446);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(733, 29);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblTableCount
            // 
            this.lblTableCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTableCount.AutoSize = true;
            this.lblTableCount.Location = new System.Drawing.Point(116, 8);
            this.lblTableCount.Name = "lblTableCount";
            this.lblTableCount.Size = new System.Drawing.Size(35, 12);
            this.lblTableCount.TabIndex = 1;
            this.lblTableCount.Text = "表:--";
            // 
            // lblViewCount
            // 
            this.lblViewCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblViewCount.AutoSize = true;
            this.lblViewCount.Location = new System.Drawing.Point(317, 8);
            this.lblViewCount.Name = "lblViewCount";
            this.lblViewCount.Size = new System.Drawing.Size(47, 12);
            this.lblViewCount.TabIndex = 3;
            this.lblViewCount.Text = "视图:--";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "当前生成对象个数:";
            // 
            // btnCleanView
            // 
            this.btnCleanView.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnCleanView.Location = new System.Drawing.Point(417, 3);
            this.btnCleanView.Name = "btnCleanView";
            this.btnCleanView.Size = new System.Drawing.Size(75, 23);
            this.btnCleanView.TabIndex = 4;
            this.btnCleanView.Text = "清空视图";
            this.btnCleanView.UseVisualStyleBackColor = true;
            this.btnCleanView.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCleanTable
            // 
            this.btnCleanTable.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnCleanTable.Location = new System.Drawing.Point(216, 3);
            this.btnCleanTable.Name = "btnCleanTable";
            this.btnCleanTable.Size = new System.Drawing.Size(75, 23);
            this.btnCleanTable.TabIndex = 2;
            this.btnCleanTable.Text = "清空表";
            this.btnCleanTable.UseVisualStyleBackColor = true;
            this.btnCleanTable.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(719, 408);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btnTurnLeftByView, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnTurnRightByView, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(327, 154);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(65, 100);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.groupBox2, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(719, 408);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.btnTurnLeft, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnTurnRight, 0, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(327, 154);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(65, 100);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // SelectObjFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 475);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tabControl1);
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
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstPrjObj;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstGenObj;
        private hwj.UserControls.CommonControls.xButton btnCancel;
        private hwj.UserControls.CommonControls.xButton btnNext;
        private System.Windows.Forms.Button btnTurnLeft;
        private System.Windows.Forms.Button btnTurnRight;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpTable;
        private System.Windows.Forms.TabPage tpView;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lstGenViewObj;
        private System.Windows.Forms.Button btnTurnRightByView;
        private System.Windows.Forms.Button btnTurnLeftByView;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstViewObj;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTableCount;
        private System.Windows.Forms.Label lblViewCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private UserControls.CommonControls.xButton btnCleanView;
        private UserControls.CommonControls.xButton btnCleanTable;
    }
}