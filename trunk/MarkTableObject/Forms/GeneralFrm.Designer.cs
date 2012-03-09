namespace hwj.MarkTableObject.Forms
{
    partial class GeneralFrm
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
            this.gpEntity = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEntityNameSpace = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEntityFileName = new System.Windows.Forms.LinkLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEntityPrefixChar = new System.Windows.Forms.TextBox();
            this.chkEntity = new System.Windows.Forms.CheckBox();
            this.chkDAL = new System.Windows.Forms.CheckBox();
            this.gpDAL = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDALNameSpace = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDALFileName = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDALPrefixChar = new System.Windows.Forms.TextBox();
            this.chkBLL = new System.Windows.Forms.CheckBox();
            this.gpBLL = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBLLNameSpace = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblBLLFileName = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBLLPrefixChar = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.chkAdd = new System.Windows.Forms.CheckBox();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.chkGetList = new System.Windows.Forms.CheckBox();
            this.chkGetPage = new System.Windows.Forms.CheckBox();
            this.chkExists = new System.Windows.Forms.CheckBox();
            this.chkGetAllList = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBLLConnection = new System.Windows.Forms.TextBox();
            this.btnCancel = new hwj.UserControls.CommonControls.xButton();
            this.btnPre = new hwj.UserControls.CommonControls.xButton();
            this.btnGeneral = new hwj.UserControls.CommonControls.xButton();
            this.cboTemplateType = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label18 = new System.Windows.Forms.Label();
            this.gpEntity.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gpDAL.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gpBLL.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpEntity
            // 
            this.gpEntity.Controls.Add(this.tableLayoutPanel1);
            this.gpEntity.Location = new System.Drawing.Point(12, 295);
            this.gpEntity.Name = "gpEntity";
            this.gpEntity.Size = new System.Drawing.Size(675, 77);
            this.gpEntity.TabIndex = 1;
            this.gpEntity.TabStop = false;
            this.gpEntity.Text = "实体设置  (鼠标双击路径,打开所在文件夹)";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtEntityNameSpace, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblEntityFileName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label10, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtEntityPrefixChar, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(669, 57);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "命名空间:";
            // 
            // txtEntityNameSpace
            // 
            this.txtEntityNameSpace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEntityNameSpace.Location = new System.Drawing.Point(80, 3);
            this.txtEntityNameSpace.Name = "txtEntityNameSpace";
            this.txtEntityNameSpace.Size = new System.Drawing.Size(441, 21);
            this.txtEntityNameSpace.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "文件夹路径:";
            // 
            // lblEntityFileName
            // 
            this.lblEntityFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEntityFileName.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblEntityFileName, 3);
            this.lblEntityFileName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblEntityFileName.Location = new System.Drawing.Point(80, 36);
            this.lblEntityFileName.Name = "lblEntityFileName";
            this.lblEntityFileName.Size = new System.Drawing.Size(586, 12);
            this.lblEntityFileName.TabIndex = 0;
            this.lblEntityFileName.TabStop = true;
            this.lblEntityFileName.Text = "--";
            this.lblEntityFileName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblBLLFileName_LinkClicked);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(527, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "前缀名称:";
            // 
            // txtEntityPrefixChar
            // 
            this.txtEntityPrefixChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEntityPrefixChar.Location = new System.Drawing.Point(592, 3);
            this.txtEntityPrefixChar.Name = "txtEntityPrefixChar";
            this.txtEntityPrefixChar.Size = new System.Drawing.Size(74, 21);
            this.txtEntityPrefixChar.TabIndex = 1;
            // 
            // chkEntity
            // 
            this.chkEntity.AutoSize = true;
            this.chkEntity.Checked = true;
            this.chkEntity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEntity.Location = new System.Drawing.Point(8, 293);
            this.chkEntity.Name = "chkEntity";
            this.chkEntity.Size = new System.Drawing.Size(72, 16);
            this.chkEntity.TabIndex = 2;
            this.chkEntity.Text = "实体设置";
            this.chkEntity.UseVisualStyleBackColor = true;
            // 
            // chkDAL
            // 
            this.chkDAL.AutoSize = true;
            this.chkDAL.Checked = true;
            this.chkDAL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDAL.Location = new System.Drawing.Point(8, 207);
            this.chkDAL.Name = "chkDAL";
            this.chkDAL.Size = new System.Drawing.Size(84, 16);
            this.chkDAL.TabIndex = 4;
            this.chkDAL.Text = "数据层设置";
            this.chkDAL.UseVisualStyleBackColor = true;
            // 
            // gpDAL
            // 
            this.gpDAL.Controls.Add(this.tableLayoutPanel2);
            this.gpDAL.Location = new System.Drawing.Point(12, 209);
            this.gpDAL.Name = "gpDAL";
            this.gpDAL.Size = new System.Drawing.Size(675, 77);
            this.gpDAL.TabIndex = 3;
            this.gpDAL.TabStop = false;
            this.gpDAL.Text = "数据层设置  (鼠标双击路径,打开所在文件夹)";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtDALNameSpace, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblDALFileName, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtDALPrefixChar, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(669, 57);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "命名空间:";
            // 
            // txtDALNameSpace
            // 
            this.txtDALNameSpace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDALNameSpace.Location = new System.Drawing.Point(80, 3);
            this.txtDALNameSpace.Name = "txtDALNameSpace";
            this.txtDALNameSpace.Size = new System.Drawing.Size(441, 21);
            this.txtDALNameSpace.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "文件夹路径:";
            // 
            // lblDALFileName
            // 
            this.lblDALFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDALFileName.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblDALFileName, 3);
            this.lblDALFileName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDALFileName.Location = new System.Drawing.Point(80, 36);
            this.lblDALFileName.Name = "lblDALFileName";
            this.lblDALFileName.Size = new System.Drawing.Size(586, 12);
            this.lblDALFileName.TabIndex = 0;
            this.lblDALFileName.TabStop = true;
            this.lblDALFileName.Text = "--";
            this.lblDALFileName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblBLLFileName_LinkClicked);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(527, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "前缀名称:";
            // 
            // txtDALPrefixChar
            // 
            this.txtDALPrefixChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDALPrefixChar.Location = new System.Drawing.Point(592, 3);
            this.txtDALPrefixChar.Name = "txtDALPrefixChar";
            this.txtDALPrefixChar.Size = new System.Drawing.Size(74, 21);
            this.txtDALPrefixChar.TabIndex = 1;
            // 
            // chkBLL
            // 
            this.chkBLL.AutoSize = true;
            this.chkBLL.Checked = true;
            this.chkBLL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBLL.Location = new System.Drawing.Point(8, 39);
            this.chkBLL.Name = "chkBLL";
            this.chkBLL.Size = new System.Drawing.Size(84, 16);
            this.chkBLL.TabIndex = 6;
            this.chkBLL.Text = "逻辑层设置";
            this.chkBLL.UseVisualStyleBackColor = true;
            // 
            // gpBLL
            // 
            this.gpBLL.Controls.Add(this.tableLayoutPanel3);
            this.gpBLL.Location = new System.Drawing.Point(12, 41);
            this.gpBLL.Name = "gpBLL";
            this.gpBLL.Size = new System.Drawing.Size(675, 159);
            this.gpBLL.TabIndex = 5;
            this.gpBLL.TabStop = false;
            this.gpBLL.Text = "逻辑层设置  (鼠标双击路径,打开所在文件夹)";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtBLLNameSpace, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblBLLFileName, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label8, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtBLLPrefixChar, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label11, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtBLLConnection, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(669, 139);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "命名空间:";
            // 
            // txtBLLNameSpace
            // 
            this.txtBLLNameSpace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBLLNameSpace.Location = new System.Drawing.Point(80, 3);
            this.txtBLLNameSpace.Name = "txtBLLNameSpace";
            this.txtBLLNameSpace.Size = new System.Drawing.Size(441, 21);
            this.txtBLLNameSpace.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "文件夹路径:";
            // 
            // lblBLLFileName
            // 
            this.lblBLLFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBLLFileName.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.lblBLLFileName, 3);
            this.lblBLLFileName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBLLFileName.Location = new System.Drawing.Point(80, 64);
            this.lblBLLFileName.Name = "lblBLLFileName";
            this.lblBLLFileName.Size = new System.Drawing.Size(586, 12);
            this.lblBLLFileName.TabIndex = 0;
            this.lblBLLFileName.TabStop = true;
            this.lblBLLFileName.Text = "--";
            this.lblBLLFileName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblBLLFileName_LinkClicked);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(527, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "前缀名称:";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "生成方法:";
            // 
            // txtBLLPrefixChar
            // 
            this.txtBLLPrefixChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBLLPrefixChar.Location = new System.Drawing.Point(592, 3);
            this.txtBLLPrefixChar.Name = "txtBLLPrefixChar";
            this.txtBLLPrefixChar.Size = new System.Drawing.Size(74, 21);
            this.txtBLLPrefixChar.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 6;
            this.tableLayoutPanel3.SetColumnSpan(this.tableLayoutPanel4, 3);
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.Controls.Add(this.chkAdd, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.chkUpdate, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.chkDelete, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.chkGetList, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.chkGetPage, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.chkExists, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.chkGetAllList, 2, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(80, 87);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(586, 49);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // chkAdd
            // 
            this.chkAdd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkAdd.AutoSize = true;
            this.chkAdd.Checked = true;
            this.chkAdd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAdd.Location = new System.Drawing.Point(3, 4);
            this.chkAdd.Name = "chkAdd";
            this.chkAdd.Size = new System.Drawing.Size(42, 16);
            this.chkAdd.TabIndex = 0;
            this.chkAdd.Text = "Add";
            this.chkAdd.UseVisualStyleBackColor = true;
            // 
            // chkUpdate
            // 
            this.chkUpdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Checked = true;
            this.chkUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdate.Location = new System.Drawing.Point(100, 4);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(60, 16);
            this.chkUpdate.TabIndex = 0;
            this.chkUpdate.Text = "Update";
            this.chkUpdate.UseVisualStyleBackColor = true;
            // 
            // chkDelete
            // 
            this.chkDelete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkDelete.AutoSize = true;
            this.chkDelete.Checked = true;
            this.chkDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDelete.Location = new System.Drawing.Point(197, 4);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(60, 16);
            this.chkDelete.TabIndex = 0;
            this.chkDelete.Text = "Delete";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // chkGetList
            // 
            this.chkGetList.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkGetList.AutoSize = true;
            this.chkGetList.Checked = true;
            this.chkGetList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGetList.Location = new System.Drawing.Point(3, 28);
            this.chkGetList.Name = "chkGetList";
            this.chkGetList.Size = new System.Drawing.Size(66, 16);
            this.chkGetList.TabIndex = 0;
            this.chkGetList.Text = "GetList";
            this.chkGetList.UseVisualStyleBackColor = true;
            // 
            // chkGetPage
            // 
            this.chkGetPage.AutoSize = true;
            this.chkGetPage.Checked = true;
            this.chkGetPage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGetPage.Location = new System.Drawing.Point(100, 27);
            this.chkGetPage.Name = "chkGetPage";
            this.chkGetPage.Size = new System.Drawing.Size(66, 16);
            this.chkGetPage.TabIndex = 0;
            this.chkGetPage.Text = "GetPage";
            this.chkGetPage.UseVisualStyleBackColor = true;
            // 
            // chkExists
            // 
            this.chkExists.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkExists.AutoSize = true;
            this.chkExists.Checked = true;
            this.chkExists.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExists.Location = new System.Drawing.Point(294, 4);
            this.chkExists.Name = "chkExists";
            this.chkExists.Size = new System.Drawing.Size(60, 16);
            this.chkExists.TabIndex = 0;
            this.chkExists.Text = "Exists";
            this.chkExists.UseVisualStyleBackColor = true;
            // 
            // chkGetAllList
            // 
            this.chkGetAllList.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkGetAllList.AutoSize = true;
            this.chkGetAllList.Location = new System.Drawing.Point(197, 28);
            this.chkGetAllList.Name = "chkGetAllList";
            this.chkGetAllList.Size = new System.Drawing.Size(84, 16);
            this.chkGetAllList.TabIndex = 0;
            this.chkGetAllList.Text = "GetAllList";
            this.chkGetAllList.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "连接变量:";
            // 
            // txtBLLConnection
            // 
            this.txtBLLConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this.txtBLLConnection, 3);
            this.txtBLLConnection.Location = new System.Drawing.Point(80, 31);
            this.txtBLLConnection.Name = "txtBLLConnection";
            this.txtBLLConnection.Size = new System.Drawing.Size(586, 21);
            this.txtBLLConnection.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnCancel.Location = new System.Drawing.Point(612, 378);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPre
            // 
            this.btnPre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPre.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnPre.Location = new System.Drawing.Point(450, 378);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(75, 23);
            this.btnPre.TabIndex = 0;
            this.btnPre.Text = "上一步";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // btnGeneral
            // 
            this.btnGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGeneral.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnGeneral.Location = new System.Drawing.Point(531, 378);
            this.btnGeneral.Name = "btnGeneral";
            this.btnGeneral.Size = new System.Drawing.Size(75, 23);
            this.btnGeneral.TabIndex = 0;
            this.btnGeneral.Text = "生 成";
            this.btnGeneral.UseVisualStyleBackColor = true;
            this.btnGeneral.Click += new System.EventHandler(this.btnGeneral_Click);
            // 
            // cboTemplateType
            // 
            this.cboTemplateType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTemplateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTemplateType.FormattingEnabled = true;
            this.cboTemplateType.Items.AddRange(new object[] {
            "一层DataAccess模板（实例化）（推荐）",
            "旧有两层模板（静态方法）"});
            this.cboTemplateType.Location = new System.Drawing.Point(80, 4);
            this.cboTemplateType.Name = "cboTemplateType";
            this.cboTemplateType.Size = new System.Drawing.Size(586, 20);
            this.cboTemplateType.TabIndex = 7;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.label18, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.cboTemplateType, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(15, 7);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(669, 28);
            this.tableLayoutPanel5.TabIndex = 8;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 8);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 12);
            this.label18.TabIndex = 9;
            this.label18.Text = "项目模板:";
            // 
            // GeneralFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 409);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Controls.Add(this.chkBLL);
            this.Controls.Add(this.gpBLL);
            this.Controls.Add(this.chkDAL);
            this.Controls.Add(this.gpDAL);
            this.Controls.Add(this.chkEntity);
            this.Controls.Add(this.gpEntity);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPre);
            this.Controls.Add(this.btnGeneral);
            this.Name = "GeneralFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "生成文件";
            this.Load += new System.EventHandler(this.GeneralFrm_Load);
            this.gpEntity.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.gpDAL.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.gpBLL.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private hwj.UserControls.CommonControls.xButton btnGeneral;
        private System.Windows.Forms.GroupBox gpEntity;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEntityNameSpace;
        private System.Windows.Forms.LinkLabel lblEntityFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkEntity;
        private System.Windows.Forms.CheckBox chkDAL;
        private System.Windows.Forms.GroupBox gpDAL;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDALNameSpace;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel lblDALFileName;
        private System.Windows.Forms.CheckBox chkBLL;
        private System.Windows.Forms.GroupBox gpBLL;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBLLNameSpace;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel lblBLLFileName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBLLPrefixChar;
        private System.Windows.Forms.TextBox txtEntityPrefixChar;
        private System.Windows.Forms.TextBox txtDALPrefixChar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.CheckBox chkAdd;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.CheckBox chkUpdate;
        private System.Windows.Forms.CheckBox chkGetList;
        private System.Windows.Forms.CheckBox chkGetPage;
        private System.Windows.Forms.CheckBox chkExists;
        private System.Windows.Forms.CheckBox chkGetAllList;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBLLConnection;
        private hwj.UserControls.CommonControls.xButton btnCancel;
        private hwj.UserControls.CommonControls.xButton btnPre;
        private System.Windows.Forms.ComboBox cboTemplateType;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label18;
    }
}