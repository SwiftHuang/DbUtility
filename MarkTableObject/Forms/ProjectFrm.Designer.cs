namespace hwj.MarkTableObject.Forms
{
    partial class ProjectFrm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrjName = new hwj.UserControls.CommonControls.xTextBox();
            this.txtPrjPath = new hwj.UserControls.CommonControls.xTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBLLName = new hwj.UserControls.CommonControls.xTextBox();
            this.txtDALName = new hwj.UserControls.CommonControls.xTextBox();
            this.txtEntityName = new hwj.UserControls.CommonControls.xTextBox();
            this.txtEntityPath = new hwj.UserControls.CommonControls.xTextBox();
            this.txtDALPath = new hwj.UserControls.CommonControls.xTextBox();
            this.txtBLLPath = new hwj.UserControls.CommonControls.xTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtConnStr = new hwj.UserControls.CommonControls.xTextBox();
            this.lblDataSource = new System.Windows.Forms.Label();
            this.btnDBSet = new hwj.UserControls.CommonControls.xButton();
            this.btnSave = new hwj.UserControls.CommonControls.xButton();
            this.btnClose = new hwj.UserControls.CommonControls.xButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPrjName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPrjPath, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtBLLName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtDALName, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtEntityName, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtEntityPath, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtDALPath, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtBLLPath, 3, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(572, 125);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "项目名称:";
            // 
            // txtPrjName
            // 
            this.txtPrjName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrjName.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.SetColumnSpan(this.txtPrjName, 3);
            this.txtPrjName.Format = null;
            this.txtPrjName.Location = new System.Drawing.Point(152, 3);
            this.txtPrjName.Name = "txtPrjName";
            this.txtPrjName.OldBackColor = System.Drawing.SystemColors.Window;
            this.txtPrjName.SetValueToControl = null;
            this.txtPrjName.Size = new System.Drawing.Size(417, 21);
            this.txtPrjName.TabIndex = 1;
            this.txtPrjName.TextIsChanged = false;
            // 
            // txtPrjPath
            // 
            this.txtPrjPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrjPath.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.SetColumnSpan(this.txtPrjPath, 3);
            this.txtPrjPath.Format = null;
            this.txtPrjPath.Location = new System.Drawing.Point(152, 28);
            this.txtPrjPath.Name = "txtPrjPath";
            this.txtPrjPath.OldBackColor = System.Drawing.SystemColors.Window;
            this.txtPrjPath.SetValueToControl = null;
            this.txtPrjPath.Size = new System.Drawing.Size(417, 21);
            this.txtPrjPath.TabIndex = 1;
            this.txtPrjPath.TextIsChanged = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "逻辑层命名空间(BO):";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "数据层命名空间(DA):";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "实体层命名空间(Entity):";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "项目路径:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(376, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "保存路径:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(376, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "保存路径:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(376, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "保存路径:";
            // 
            // txtBLLName
            // 
            this.txtBLLName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBLLName.BackColor = System.Drawing.SystemColors.Window;
            this.txtBLLName.Format = null;
            this.txtBLLName.Location = new System.Drawing.Point(152, 53);
            this.txtBLLName.Name = "txtBLLName";
            this.txtBLLName.OldBackColor = System.Drawing.SystemColors.Window;
            this.txtBLLName.SetValueToControl = null;
            this.txtBLLName.Size = new System.Drawing.Size(218, 21);
            this.txtBLLName.TabIndex = 1;
            this.txtBLLName.TextIsChanged = false;
            // 
            // txtDALName
            // 
            this.txtDALName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDALName.BackColor = System.Drawing.SystemColors.Window;
            this.txtDALName.Format = null;
            this.txtDALName.Location = new System.Drawing.Point(152, 78);
            this.txtDALName.Name = "txtDALName";
            this.txtDALName.OldBackColor = System.Drawing.SystemColors.Window;
            this.txtDALName.SetValueToControl = null;
            this.txtDALName.Size = new System.Drawing.Size(218, 21);
            this.txtDALName.TabIndex = 1;
            this.txtDALName.TextIsChanged = false;
            // 
            // txtEntityName
            // 
            this.txtEntityName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEntityName.BackColor = System.Drawing.SystemColors.Window;
            this.txtEntityName.Format = null;
            this.txtEntityName.Location = new System.Drawing.Point(152, 103);
            this.txtEntityName.Name = "txtEntityName";
            this.txtEntityName.OldBackColor = System.Drawing.SystemColors.Window;
            this.txtEntityName.SetValueToControl = null;
            this.txtEntityName.Size = new System.Drawing.Size(218, 21);
            this.txtEntityName.TabIndex = 1;
            this.txtEntityName.TextIsChanged = false;
            // 
            // txtEntityPath
            // 
            this.txtEntityPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEntityPath.BackColor = System.Drawing.SystemColors.Window;
            this.txtEntityPath.Format = null;
            this.txtEntityPath.Location = new System.Drawing.Point(441, 103);
            this.txtEntityPath.Name = "txtEntityPath";
            this.txtEntityPath.OldBackColor = System.Drawing.SystemColors.Window;
            this.txtEntityPath.SetValueToControl = null;
            this.txtEntityPath.Size = new System.Drawing.Size(128, 21);
            this.txtEntityPath.TabIndex = 1;
            this.txtEntityPath.TextIsChanged = false;
            // 
            // txtDALPath
            // 
            this.txtDALPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDALPath.BackColor = System.Drawing.SystemColors.Window;
            this.txtDALPath.Format = null;
            this.txtDALPath.Location = new System.Drawing.Point(441, 78);
            this.txtDALPath.Name = "txtDALPath";
            this.txtDALPath.OldBackColor = System.Drawing.SystemColors.Window;
            this.txtDALPath.SetValueToControl = null;
            this.txtDALPath.Size = new System.Drawing.Size(128, 21);
            this.txtDALPath.TabIndex = 1;
            this.txtDALPath.TextIsChanged = false;
            // 
            // txtBLLPath
            // 
            this.txtBLLPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBLLPath.BackColor = System.Drawing.SystemColors.Window;
            this.txtBLLPath.Format = null;
            this.txtBLLPath.Location = new System.Drawing.Point(441, 53);
            this.txtBLLPath.Name = "txtBLLPath";
            this.txtBLLPath.OldBackColor = System.Drawing.SystemColors.Window;
            this.txtBLLPath.SetValueToControl = null;
            this.txtBLLPath.Size = new System.Drawing.Size(128, 21);
            this.txtBLLPath.TabIndex = 1;
            this.txtBLLPath.TextIsChanged = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(6, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(578, 150);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "项目设置";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Location = new System.Drawing.Point(6, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(578, 123);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据库设置:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtConnStr, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblDataSource, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDBSet, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(572, 103);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "数据源:";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "连接串:";
            // 
            // txtConnStr
            // 
            this.txtConnStr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConnStr.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel2.SetColumnSpan(this.txtConnStr, 2);
            this.txtConnStr.Format = null;
            this.txtConnStr.Location = new System.Drawing.Point(56, 31);
            this.txtConnStr.Multiline = true;
            this.txtConnStr.Name = "txtConnStr";
            this.txtConnStr.OldBackColor = System.Drawing.SystemColors.Window;
            this.txtConnStr.ReadOnly = true;
            this.tableLayoutPanel2.SetRowSpan(this.txtConnStr, 2);
            this.txtConnStr.SetValueToControl = null;
            this.txtConnStr.Size = new System.Drawing.Size(513, 69);
            this.txtConnStr.TabIndex = 1;
            this.txtConnStr.TextIsChanged = false;
            // 
            // lblDataSource
            // 
            this.lblDataSource.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDataSource.AutoSize = true;
            this.lblDataSource.Location = new System.Drawing.Point(56, 8);
            this.lblDataSource.Name = "lblDataSource";
            this.lblDataSource.Size = new System.Drawing.Size(71, 12);
            this.lblDataSource.TabIndex = 0;
            this.lblDataSource.Text = "数据源类型:";
            // 
            // btnDBSet
            // 
            this.btnDBSet.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDBSet.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnDBSet.Location = new System.Drawing.Point(515, 3);
            this.btnDBSet.Name = "btnDBSet";
            this.btnDBSet.Size = new System.Drawing.Size(54, 22);
            this.btnDBSet.TabIndex = 2;
            this.btnDBSet.Text = "设 置";
            this.btnDBSet.UseVisualStyleBackColor = true;
            this.btnDBSet.Click += new System.EventHandler(this.btnDBSet_Click);
            // 
            // btnSave
            // 
            this.btnSave.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnSave.Location = new System.Drawing.Point(439, 286);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保 存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnClose.Location = new System.Drawing.Point(515, 286);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "取 消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ProjectFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 314);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProjectFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ProjectFrm";
            this.Load += new System.EventHandler(this.ProjectFrm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private hwj.UserControls.CommonControls.xTextBox txtPrjName;
        private System.Windows.Forms.GroupBox groupBox1;
        private hwj.UserControls.CommonControls.xTextBox txtPrjPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private hwj.UserControls.CommonControls.xTextBox txtBLLName;
        private hwj.UserControls.CommonControls.xTextBox txtDALName;
        private hwj.UserControls.CommonControls.xTextBox txtEntityName;
        private hwj.UserControls.CommonControls.xTextBox txtEntityPath;
        private hwj.UserControls.CommonControls.xTextBox txtDALPath;
        private hwj.UserControls.CommonControls.xTextBox txtBLLPath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private hwj.UserControls.CommonControls.xTextBox txtConnStr;
        private System.Windows.Forms.Label lblDataSource;
        private hwj.UserControls.CommonControls.xButton btnDBSet;
        private hwj.UserControls.CommonControls.xButton btnSave;
        private hwj.UserControls.CommonControls.xButton btnClose;
    }
}