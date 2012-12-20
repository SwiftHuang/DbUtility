namespace hwj.MarkTableObject.Components
{
    partial class AssignEntity
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gpSQL = new System.Windows.Forms.GroupBox();
            this.txtSQL = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPrjInfo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFunName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MainTable = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chkAddTirm = new hwj.UserControls.CommonControls.xCheckBox();
            this.btnGenCode = new hwj.UserControls.CommonControls.xButton();
            this.btnFile = new hwj.UserControls.CommonControls.xButton();
            this.cboTypeList = new hwj.UserControls.CommonControls.xComboBox();
            this.gpSQL.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.MainTable.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpSQL
            // 
            this.gpSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpSQL.Controls.Add(this.txtSQL);
            this.gpSQL.Location = new System.Drawing.Point(3, 140);
            this.gpSQL.Name = "gpSQL";
            this.gpSQL.Size = new System.Drawing.Size(629, 94);
            this.gpSQL.TabIndex = 2;
            this.gpSQL.TabStop = false;
            this.gpSQL.Text = "SQL语句";
            // 
            // txtSQL
            // 
            this.txtSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSQL.Location = new System.Drawing.Point(3, 17);
            this.txtSQL.Multiline = true;
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSQL.Size = new System.Drawing.Size(623, 74);
            this.txtSQL.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cboPrjInfo, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtFunName, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkAddTirm, 4, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(623, 25);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前项目:";
            // 
            // cboPrjInfo
            // 
            this.cboPrjInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboPrjInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrjInfo.FormattingEnabled = true;
            this.cboPrjInfo.Location = new System.Drawing.Point(68, 3);
            this.cboPrjInfo.Name = "cboPrjInfo";
            this.cboPrjInfo.Size = new System.Drawing.Size(289, 20);
            this.cboPrjInfo.TabIndex = 1;
            this.cboPrjInfo.SelectedIndexChanged += new System.EventHandler(this.cboPrjInfo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "函数名:";
            // 
            // txtFunName
            // 
            this.txtFunName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFunName.Location = new System.Drawing.Point(416, 3);
            this.txtFunName.Name = "txtFunName";
            this.txtFunName.Size = new System.Drawing.Size(114, 21);
            this.txtFunName.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(629, 80);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DLL资源";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.txtFileName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGenCode, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFile, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboTypeList, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(623, 60);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtFileName
            // 
            this.txtFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFileName.Location = new System.Drawing.Point(86, 3);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(453, 21);
            this.txtFileName.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "目标类型:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "DLL文件路径:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(629, 45);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "设置";
            // 
            // MainTable
            // 
            this.MainTable.ColumnCount = 1;
            this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTable.Controls.Add(this.groupBox3, 0, 3);
            this.MainTable.Controls.Add(this.gpSQL, 0, 2);
            this.MainTable.Controls.Add(this.groupBox2, 0, 0);
            this.MainTable.Controls.Add(this.groupBox1, 0, 1);
            this.MainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTable.Location = new System.Drawing.Point(0, 0);
            this.MainTable.Name = "MainTable";
            this.MainTable.RowCount = 4;
            this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTable.Size = new System.Drawing.Size(635, 438);
            this.MainTable.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtCode);
            this.groupBox3.Location = new System.Drawing.Point(3, 240);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(629, 195);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "代码语句";
            // 
            // txtCode
            // 
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCode.Location = new System.Drawing.Point(3, 17);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCode.Size = new System.Drawing.Size(623, 175);
            this.txtCode.TabIndex = 0;
            // 
            // chkAddTirm
            // 
            this.chkAddTirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAddTirm.AutoSize = true;
            this.chkAddTirm.Checked = true;
            this.chkAddTirm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAddTirm.Location = new System.Drawing.Point(536, 4);
            this.chkAddTirm.Name = "chkAddTirm";
            this.chkAddTirm.Size = new System.Drawing.Size(84, 16);
            this.chkAddTirm.TabIndex = 4;
            this.chkAddTirm.Text = "去掉右空格";
            this.chkAddTirm.UseVisualStyleBackColor = true;
            // 
            // btnGenCode
            // 
            this.btnGenCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenCode.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnGenCode.Location = new System.Drawing.Point(545, 33);
            this.btnGenCode.Name = "btnGenCode";
            this.btnGenCode.Size = new System.Drawing.Size(75, 23);
            this.btnGenCode.TabIndex = 5;
            this.btnGenCode.Text = "生成代码";
            this.btnGenCode.UseVisualStyleBackColor = true;
            this.btnGenCode.Click += new System.EventHandler(this.btnGenCode_Click);
            // 
            // btnFile
            // 
            this.btnFile.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnFile.Location = new System.Drawing.Point(545, 3);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(75, 23);
            this.btnFile.TabIndex = 2;
            this.btnFile.Text = "选择文件";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // cboTypeList
            // 
            this.cboTypeList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTypeList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTypeList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTypeList.BackColor = System.Drawing.SystemColors.Window;
            this.cboTypeList.DisplayMember = "Name";
            this.cboTypeList.FormattingEnabled = true;
            this.cboTypeList.Location = new System.Drawing.Point(86, 35);
            this.cboTypeList.Name = "cboTypeList";
            this.cboTypeList.OldBackColor = System.Drawing.SystemColors.Window;
            this.cboTypeList.Size = new System.Drawing.Size(453, 20);
            this.cboTypeList.TabIndex = 4;
            this.cboTypeList.ValueMember = "FullName";
            // 
            // AssignEntity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainTable);
            this.Name = "AssignEntity";
            this.Size = new System.Drawing.Size(635, 438);
            this.Enter += new System.EventHandler(this.AssignEntity_Enter);
            this.gpSQL.ResumeLayout(false);
            this.gpSQL.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.MainTable.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private hwj.UserControls.CommonControls.xButton btnGenCode;
        private System.Windows.Forms.GroupBox gpSQL;
        private System.Windows.Forms.TextBox txtSQL;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPrjInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFunName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label7;
        private hwj.UserControls.CommonControls.xButton btnFile;
        private hwj.UserControls.CommonControls.xComboBox cboTypeList;
        private System.Windows.Forms.Label label4;
        private hwj.UserControls.CommonControls.xCheckBox chkAddTirm;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel MainTable;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtFileName;
    }
}
