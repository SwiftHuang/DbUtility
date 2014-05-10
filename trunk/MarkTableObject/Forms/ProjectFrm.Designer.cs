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
            this.cboTemplateType = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtPrjPath = new hwj.UserControls.CommonControls.xTextBox();
            this.btnPrjPath = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtEntityPath = new hwj.UserControls.CommonControls.xTextBox();
            this.btnEntityPath = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDALPath = new hwj.UserControls.CommonControls.xTextBox();
            this.btnDALPath = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBLLPath = new hwj.UserControls.CommonControls.xTextBox();
            this.btnBLLPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBLLName = new hwj.UserControls.CommonControls.xTextBox();
            this.txtDALName = new hwj.UserControls.CommonControls.xTextBox();
            this.txtEntityName = new hwj.UserControls.CommonControls.xTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBLLPrefixChar = new hwj.UserControls.CommonControls.xTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDALPrefixChar = new hwj.UserControls.CommonControls.xTextBox();
            this.txtEntityPrefixChar = new hwj.UserControls.CommonControls.xTextBox();
            this.txtPrjName = new hwj.UserControls.CommonControls.xTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtBLLConnection = new hwj.UserControls.CommonControls.xTextBox();
            this.label18 = new System.Windows.Forms.Label();
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Controls.Add(this.cboTemplateType, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtBLLName, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtDALName, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtEntityName, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.label11, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label12, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label13, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.label14, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtBLLPrefixChar, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label8, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.label15, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.label16, 3, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtDALPrefixChar, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtEntityPrefixChar, 4, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtPrjName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label17, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtBLLConnection, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label18, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(572, 255);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cboTemplateType
            // 
            this.cboTemplateType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.cboTemplateType, 4);
            this.cboTemplateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTemplateType.FormattingEnabled = true;
            this.cboTemplateType.Location = new System.Drawing.Point(68, 3);
            this.cboTemplateType.Name = "cboTemplateType";
            this.cboTemplateType.Size = new System.Drawing.Size(501, 20);
            this.cboTemplateType.TabIndex = 4;
            this.cboTemplateType.SelectedIndexChanged += new System.EventHandler(this.cboTemplateType_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel4, 4);
            this.panel4.Controls.Add(this.txtPrjPath);
            this.panel4.Controls.Add(this.btnPrjPath);
            this.panel4.Location = new System.Drawing.Point(65, 50);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(507, 25);
            this.panel4.TabIndex = 3;
            // 
            // txtPrjPath
            // 
            this.txtPrjPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrjPath.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPrjPath.Format = null;
            this.txtPrjPath.Location = new System.Drawing.Point(3, 2);
            this.txtPrjPath.Name = "txtPrjPath";
            this.txtPrjPath.OldBackColor = System.Drawing.SystemColors.Window;
            this.txtPrjPath.ReadOnly = true;
            this.txtPrjPath.RequiredHandle = null;
            this.txtPrjPath.SetValueToControl = null;
            this.txtPrjPath.Size = new System.Drawing.Size(461, 21);
            this.txtPrjPath.TabIndex = 0;
            this.txtPrjPath.TextIsChanged = false;
            this.txtPrjPath.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtPrjPath_MouseDoubleClick);
            // 
            // btnPrjPath
            // 
            this.btnPrjPath.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPrjPath.Location = new System.Drawing.Point(464, 0);
            this.btnPrjPath.Name = "btnPrjPath";
            this.btnPrjPath.Size = new System.Drawing.Size(43, 25);
            this.btnPrjPath.TabIndex = 1;
            this.btnPrjPath.Text = "浏览";
            this.btnPrjPath.UseVisualStyleBackColor = true;
            this.btnPrjPath.Click += new System.EventHandler(this.btnPrjPath_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 3);
            this.panel3.Controls.Add(this.txtEntityPath);
            this.panel3.Controls.Add(this.btnEntityPath);
            this.panel3.Location = new System.Drawing.Point(130, 227);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(442, 25);
            this.panel3.TabIndex = 26;
            // 
            // txtEntityPath
            // 
            this.txtEntityPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEntityPath.BackColor = System.Drawing.Color.Gainsboro;
            this.txtEntityPath.Format = null;
            this.txtEntityPath.Location = new System.Drawing.Point(3, 2);
            this.txtEntityPath.Name = "txtEntityPath";
            this.txtEntityPath.OldBackColor = System.Drawing.SystemColors.Window;
            this.txtEntityPath.ReadOnly = true;
            this.txtEntityPath.RequiredHandle = null;
            this.txtEntityPath.SetValueToControl = null;
            this.txtEntityPath.Size = new System.Drawing.Size(396, 21);
            this.txtEntityPath.TabIndex = 0;
            this.txtEntityPath.TextIsChanged = false;
            this.txtEntityPath.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtPrjPath_MouseDoubleClick);
            // 
            // btnEntityPath
            // 
            this.btnEntityPath.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEntityPath.Location = new System.Drawing.Point(399, 0);
            this.btnEntityPath.Name = "btnEntityPath";
            this.btnEntityPath.Size = new System.Drawing.Size(43, 25);
            this.btnEntityPath.TabIndex = 1;
            this.btnEntityPath.Text = "浏览";
            this.btnEntityPath.UseVisualStyleBackColor = true;
            this.btnEntityPath.Click += new System.EventHandler(this.btnEntityPath_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 3);
            this.panel2.Controls.Add(this.txtDALPath);
            this.panel2.Controls.Add(this.btnDALPath);
            this.panel2.Location = new System.Drawing.Point(130, 175);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(442, 25);
            this.panel2.TabIndex = 19;
            // 
            // txtDALPath
            // 
            this.txtDALPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDALPath.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDALPath.Format = null;
            this.txtDALPath.Location = new System.Drawing.Point(3, 2);
            this.txtDALPath.Name = "txtDALPath";
            this.txtDALPath.OldBackColor = System.Drawing.SystemColors.Window;
            this.txtDALPath.ReadOnly = true;
            this.txtDALPath.RequiredHandle = null;
            this.txtDALPath.SetValueToControl = null;
            this.txtDALPath.Size = new System.Drawing.Size(396, 21);
            this.txtDALPath.TabIndex = 0;
            this.txtDALPath.TextIsChanged = false;
            this.txtDALPath.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtPrjPath_MouseDoubleClick);
            // 
            // btnDALPath
            // 
            this.btnDALPath.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDALPath.Location = new System.Drawing.Point(399, 0);
            this.btnDALPath.Name = "btnDALPath";
            this.btnDALPath.Size = new System.Drawing.Size(43, 25);
            this.btnDALPath.TabIndex = 1;
            this.btnDALPath.Text = "浏览";
            this.btnDALPath.UseVisualStyleBackColor = true;
            this.btnDALPath.Click += new System.EventHandler(this.btnDALPath_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 3);
            this.panel1.Controls.Add(this.txtBLLPath);
            this.panel1.Controls.Add(this.btnBLLPath);
            this.panel1.Location = new System.Drawing.Point(130, 125);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 25);
            this.panel1.TabIndex = 12;
            // 
            // txtBLLPath
            // 
            this.txtBLLPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBLLPath.BackColor = System.Drawing.Color.Gainsboro;
            this.txtBLLPath.Format = null;
            this.txtBLLPath.Location = new System.Drawing.Point(3, 2);
            this.txtBLLPath.Name = "txtBLLPath";
            this.txtBLLPath.OldBackColor = System.Drawing.SystemColors.Window;
            this.txtBLLPath.ReadOnly = true;
            this.txtBLLPath.RequiredHandle = null;
            this.txtBLLPath.SetValueToControl = null;
            this.txtBLLPath.Size = new System.Drawing.Size(396, 21);
            this.txtBLLPath.TabIndex = 0;
            this.txtBLLPath.TextIsChanged = false;
            this.txtBLLPath.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtPrjPath_MouseDoubleClick);
            // 
            // btnBLLPath
            // 
            this.btnBLLPath.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBLLPath.Location = new System.Drawing.Point(399, 0);
            this.btnBLLPath.Name = "btnBLLPath";
            this.btnBLLPath.Size = new System.Drawing.Size(43, 25);
            this.btnBLLPath.TabIndex = 1;
            this.btnBLLPath.Text = "浏览";
            this.btnBLLPath.UseVisualStyleBackColor = true;
            this.btnBLLPath.Click += new System.EventHandler(this.btnBLLPath_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "项目名称:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "逻辑层:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "数据层:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 20;
            this.label5.Text = "实体层:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "项目路径:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(430, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "前缀字符:";
            // 
            // txtBLLName
            // 
            this.txtBLLName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBLLName.BackColor = System.Drawing.SystemColors.Window;
            this.txtBLLName.Format = null;
            this.txtBLLName.Location = new System.Drawing.Point(133, 78);
            this.txtBLLName.Name = "txtBLLName";
            this.txtBLLName.OldBackColor = System.Drawing.SystemColors.Window;
            this.txtBLLName.RequiredHandle = null;
            this.txtBLLName.SetValueToControl = null;
            this.txtBLLName.Size = new System.Drawing.Size(291, 21);
            this.txtBLLName.TabIndex = 6;
            this.txtBLLName.TextIsChanged = false;
            // 
            // txtDALName
            // 
            this.txtDALName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDALName.BackColor = System.Drawing.SystemColors.Window;
            this.txtDALName.Format = null;
            this.txtDALName.Location = new System.Drawing.Point(133, 153);
            this.txtDALName.Name = "txtDALName";
            this.txtDALName.OldBackColor = System.Drawing.SystemColors.Window;
            this.txtDALName.RequiredHandle = null;
            this.txtDALName.SetValueToControl = null;
            this.txtDALName.Size = new System.Drawing.Size(291, 21);
            this.txtDALName.TabIndex = 15;
            this.txtDALName.TextIsChanged = false;
            // 
            // txtEntityName
            // 
            this.txtEntityName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEntityName.BackColor = System.Drawing.SystemColors.Window;
            this.txtEntityName.Format = null;
            this.txtEntityName.Location = new System.Drawing.Point(133, 203);
            this.txtEntityName.Name = "txtEntityName";
            this.txtEntityName.OldBackColor = System.Drawing.SystemColors.Window;
            this.txtEntityName.RequiredHandle = null;
            this.txtEntityName.SetValueToControl = null;
            this.txtEntityName.Size = new System.Drawing.Size(291, 21);
            this.txtEntityName.TabIndex = 22;
            this.txtEntityName.TextIsChanged = false;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(68, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 5;
            this.label11.Text = "命名空间:";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(68, 156);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 14;
            this.label12.Text = "命名空间:";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(68, 206);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 12);
            this.label13.TabIndex = 21;
            this.label13.Text = "命名空间:";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(68, 131);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 12);
            this.label14.TabIndex = 11;
            this.label14.Text = "保存路径:";
            // 
            // txtBLLPrefixChar
            // 
            this.txtBLLPrefixChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBLLPrefixChar.BackColor = System.Drawing.SystemColors.Window;
            this.txtBLLPrefixChar.Format = null;
            this.txtBLLPrefixChar.Location = new System.Drawing.Point(495, 78);
            this.txtBLLPrefixChar.Name = "txtBLLPrefixChar";
            this.txtBLLPrefixChar.OldBackColor = System.Drawing.SystemColors.Window;
            this.txtBLLPrefixChar.RequiredHandle = null;
            this.txtBLLPrefixChar.SetValueToControl = null;
            this.txtBLLPrefixChar.Size = new System.Drawing.Size(74, 21);
            this.txtBLLPrefixChar.TabIndex = 8;
            this.txtBLLPrefixChar.Text = "BO";
            this.txtBLLPrefixChar.TextIsChanged = false;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(68, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "保存路径:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(68, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 25;
            this.label8.Text = "保存路径:";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(430, 156);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 16;
            this.label15.Text = "前缀字符:";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(430, 206);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 12);
            this.label16.TabIndex = 23;
            this.label16.Text = "前缀字符:";
            // 
            // txtDALPrefixChar
            // 
            this.txtDALPrefixChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDALPrefixChar.BackColor = System.Drawing.SystemColors.Window;
            this.txtDALPrefixChar.Format = null;
            this.txtDALPrefixChar.Location = new System.Drawing.Point(495, 153);
            this.txtDALPrefixChar.Name = "txtDALPrefixChar";
            this.txtDALPrefixChar.OldBackColor = System.Drawing.SystemColors.Window;
            this.txtDALPrefixChar.RequiredHandle = null;
            this.txtDALPrefixChar.SetValueToControl = null;
            this.txtDALPrefixChar.Size = new System.Drawing.Size(74, 21);
            this.txtDALPrefixChar.TabIndex = 17;
            this.txtDALPrefixChar.Text = "DA";
            this.txtDALPrefixChar.TextIsChanged = false;
            // 
            // txtEntityPrefixChar
            // 
            this.txtEntityPrefixChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEntityPrefixChar.BackColor = System.Drawing.SystemColors.Window;
            this.txtEntityPrefixChar.Format = null;
            this.txtEntityPrefixChar.Location = new System.Drawing.Point(495, 203);
            this.txtEntityPrefixChar.Name = "txtEntityPrefixChar";
            this.txtEntityPrefixChar.OldBackColor = System.Drawing.SystemColors.Window;
            this.txtEntityPrefixChar.RequiredHandle = null;
            this.txtEntityPrefixChar.SetValueToControl = null;
            this.txtEntityPrefixChar.Size = new System.Drawing.Size(74, 21);
            this.txtEntityPrefixChar.TabIndex = 24;
            this.txtEntityPrefixChar.Text = "tb";
            this.txtEntityPrefixChar.TextIsChanged = false;
            // 
            // txtPrjName
            // 
            this.txtPrjName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrjName.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.SetColumnSpan(this.txtPrjName, 4);
            this.txtPrjName.Format = null;
            this.txtPrjName.Location = new System.Drawing.Point(68, 28);
            this.txtPrjName.Name = "txtPrjName";
            this.txtPrjName.OldBackColor = System.Drawing.SystemColors.Window;
            this.txtPrjName.RequiredHandle = null;
            this.txtPrjName.SetValueToControl = null;
            this.txtPrjName.Size = new System.Drawing.Size(501, 21);
            this.txtPrjName.TabIndex = 1;
            this.txtPrjName.TextIsChanged = false;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(68, 106);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 12);
            this.label17.TabIndex = 9;
            this.label17.Text = "连接变量:";
            // 
            // txtBLLConnection
            // 
            this.txtBLLConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBLLConnection.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.SetColumnSpan(this.txtBLLConnection, 3);
            this.txtBLLConnection.Format = null;
            this.txtBLLConnection.Location = new System.Drawing.Point(133, 103);
            this.txtBLLConnection.Name = "txtBLLConnection";
            this.txtBLLConnection.OldBackColor = System.Drawing.SystemColors.Window;
            this.txtBLLConnection.RequiredHandle = null;
            this.txtBLLConnection.SetValueToControl = null;
            this.txtBLLConnection.Size = new System.Drawing.Size(436, 21);
            this.txtBLLConnection.TabIndex = 10;
            this.txtBLLConnection.TextIsChanged = false;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 6);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 12);
            this.label18.TabIndex = 0;
            this.label18.Text = "项目模板:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(6, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(578, 275);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "项目设置(鼠标双击路径内容,打开所在文件夹)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Location = new System.Drawing.Point(6, 286);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(578, 123);
            this.groupBox2.TabIndex = 1;
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
            this.tableLayoutPanel2.TabIndex = 0;
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
            this.label10.TabIndex = 2;
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
            this.txtConnStr.RequiredHandle = null;
            this.tableLayoutPanel2.SetRowSpan(this.txtConnStr, 2);
            this.txtConnStr.SetValueToControl = null;
            this.txtConnStr.Size = new System.Drawing.Size(513, 69);
            this.txtConnStr.TabIndex = 3;
            this.txtConnStr.TextIsChanged = false;
            // 
            // lblDataSource
            // 
            this.lblDataSource.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDataSource.AutoSize = true;
            this.lblDataSource.Location = new System.Drawing.Point(56, 8);
            this.lblDataSource.Name = "lblDataSource";
            this.lblDataSource.Size = new System.Drawing.Size(17, 12);
            this.lblDataSource.TabIndex = 0;
            this.lblDataSource.Text = "--";
            // 
            // btnDBSet
            // 
            this.btnDBSet.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDBSet.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnDBSet.Location = new System.Drawing.Point(515, 3);
            this.btnDBSet.Name = "btnDBSet";
            this.btnDBSet.Size = new System.Drawing.Size(54, 22);
            this.btnDBSet.TabIndex = 1;
            this.btnDBSet.Text = "设 置";
            this.btnDBSet.UseVisualStyleBackColor = true;
            this.btnDBSet.Click += new System.EventHandler(this.btnDBSet_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnSave.Location = new System.Drawing.Point(439, 417);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保 存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnClose.Location = new System.Drawing.Point(515, 417);
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
            this.ClientSize = new System.Drawing.Size(590, 449);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(596, 443);
            this.Name = "ProjectFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "项 目";
            this.Load += new System.EventHandler(this.ProjectFrm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private hwj.UserControls.CommonControls.xTextBox txtBLLName;
        private hwj.UserControls.CommonControls.xTextBox txtDALName;
        private hwj.UserControls.CommonControls.xTextBox txtEntityName;
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
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private hwj.UserControls.CommonControls.xTextBox txtBLLPrefixChar;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private hwj.UserControls.CommonControls.xTextBox txtDALPrefixChar;
        private hwj.UserControls.CommonControls.xTextBox txtEntityPrefixChar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBLLPath;
        private System.Windows.Forms.Panel panel3;
        private hwj.UserControls.CommonControls.xTextBox txtEntityPath;
        private System.Windows.Forms.Button btnEntityPath;
        private System.Windows.Forms.Panel panel2;
        private hwj.UserControls.CommonControls.xTextBox txtDALPath;
        private System.Windows.Forms.Button btnDALPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label17;
        private hwj.UserControls.CommonControls.xTextBox txtBLLConnection;
        private System.Windows.Forms.Panel panel4;
        private hwj.UserControls.CommonControls.xTextBox txtPrjPath;
        private System.Windows.Forms.Button btnPrjPath;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cboTemplateType;
    }
}