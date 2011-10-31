namespace hwj.MarkTableObject.Components
{
    partial class GenSQLCtrl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenSQLCtrl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gpSQL = new System.Windows.Forms.GroupBox();
            this.txtSQL = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgList = new hwj.UserControls.DataList.xDataGridView();
            this.tabGen = new System.Windows.Forms.TabControl();
            this.tpMain = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnGenSql = new hwj.UserControls.CommonControls.xButton();
            this.btnGenFile = new hwj.UserControls.CommonControls.xButton();
            this.btnPreview = new hwj.UserControls.CommonControls.xButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSQLType = new System.Windows.Forms.ComboBox();
            this.cboPrjInfo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tblSP = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSPName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSPParam = new System.Windows.Forms.TextBox();
            this.tpEntity = new System.Windows.Forms.TabPage();
            this.txtEntityCode = new System.Windows.Forms.TextBox();
            this.tpDAL = new System.Windows.Forms.TabPage();
            this.txtDALCode = new System.Windows.Forms.TextBox();
            this.tpBLL = new System.Windows.Forms.TabPage();
            this.txtBLLCode = new System.Windows.Forms.TextBox();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colAllowDBNull = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsUnique = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsAutoIncrement = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBaseTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnEntityCopy = new hwj.UserControls.CommonControls.xButton();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDALCopy = new hwj.UserControls.CommonControls.xButton();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnBLLCopy = new hwj.UserControls.CommonControls.xButton();
            this.gpSQL.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.tabGen.SuspendLayout();
            this.tpMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tblSP.SuspendLayout();
            this.tpEntity.SuspendLayout();
            this.tpDAL.SuspendLayout();
            this.tpBLL.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpSQL
            // 
            this.gpSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.gpSQL, 2);
            this.gpSQL.Controls.Add(this.txtSQL);
            this.gpSQL.Location = new System.Drawing.Point(3, 33);
            this.gpSQL.Name = "gpSQL";
            this.gpSQL.Size = new System.Drawing.Size(797, 124);
            this.gpSQL.TabIndex = 1;
            this.gpSQL.TabStop = false;
            this.gpSQL.Text = "SQL语句";
            // 
            // txtSQL
            // 
            this.txtSQL.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSQL.Location = new System.Drawing.Point(3, 17);
            this.txtSQL.Multiline = true;
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSQL.Size = new System.Drawing.Size(791, 99);
            this.txtSQL.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 2);
            this.groupBox2.Controls.Add(this.dgList);
            this.groupBox2.Location = new System.Drawing.Point(3, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(797, 311);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "表信息";
            // 
            // dgList
            // 
            this.dgList.AllowUserToAddRows = false;
            this.dgList.AllowUserToDeleteRows = false;
            this.dgList.AllowUserToResizeRows = false;
            this.dgList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colName,
            this.colKey,
            this.colDataTypeName,
            this.colBaseTableName,
            this.colDataType,
            this.colAllowDBNull,
            this.colIsUnique,
            this.colIsAutoIncrement,
            this.colDescription});
            this.dgList.DataListPage = null;
            this.dgList.DisplayRows = 0;
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Location = new System.Drawing.Point(3, 17);
            this.dgList.Name = "dgList";
            this.dgList.RowFooterVisible = false;
            this.dgList.RowHeadersVisible = false;
            this.dgList.RowSeqVisible = true;
            this.dgList.RowTemplate.Height = 23;
            this.dgList.Size = new System.Drawing.Size(791, 291);
            this.dgList.SumColumnName = ((System.Collections.Generic.List<string>)(resources.GetObject("dgList.SumColumnName")));
            this.dgList.TabIndex = 0;
            this.dgList.ValueIsChanged = false;
            // 
            // tabGen
            // 
            this.tabGen.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabGen.Controls.Add(this.tpMain);
            this.tabGen.Controls.Add(this.tpEntity);
            this.tabGen.Controls.Add(this.tpDAL);
            this.tabGen.Controls.Add(this.tpBLL);
            this.tabGen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGen.Location = new System.Drawing.Point(0, 0);
            this.tabGen.Multiline = true;
            this.tabGen.Name = "tabGen";
            this.tabGen.SelectedIndex = 0;
            this.tabGen.Size = new System.Drawing.Size(817, 568);
            this.tabGen.TabIndex = 3;
            // 
            // tpMain
            // 
            this.tpMain.Controls.Add(this.tableLayoutPanel1);
            this.tpMain.Location = new System.Drawing.Point(4, 4);
            this.tpMain.Name = "tpMain";
            this.tpMain.Padding = new System.Windows.Forms.Padding(3);
            this.tpMain.Size = new System.Drawing.Size(809, 543);
            this.tpMain.TabIndex = 0;
            this.tpMain.Text = "生成代码";
            this.tpMain.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.Controls.Add(this.btnGenSql, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.gpSQL, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnGenFile, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnPreview, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tblSP, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(803, 537);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnGenSql
            // 
            this.btnGenSql.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenSql.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnGenSql.Location = new System.Drawing.Point(725, 163);
            this.btnGenSql.Name = "btnGenSql";
            this.btnGenSql.Size = new System.Drawing.Size(75, 23);
            this.btnGenSql.TabIndex = 3;
            this.btnGenSql.Text = "生成表";
            this.btnGenSql.UseVisualStyleBackColor = true;
            this.btnGenSql.Click += new System.EventHandler(this.btnGenSql_Click);
            // 
            // btnGenFile
            // 
            this.btnGenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenFile.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnGenFile.Location = new System.Drawing.Point(725, 511);
            this.btnGenFile.Name = "btnGenFile";
            this.btnGenFile.Size = new System.Drawing.Size(75, 23);
            this.btnGenFile.TabIndex = 6;
            this.btnGenFile.Text = "生成文件";
            this.btnGenFile.UseVisualStyleBackColor = true;
            this.btnGenFile.Visible = false;
            this.btnGenFile.Click += new System.EventHandler(this.btnGenFile_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnPreview.Location = new System.Drawing.Point(638, 511);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 5;
            this.btnPreview.Text = "代码预览";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cboSQLType, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.cboPrjInfo, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtTableName, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(803, 30);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前项目:";
            // 
            // cboSQLType
            // 
            this.cboSQLType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSQLType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSQLType.FormattingEnabled = true;
            this.cboSQLType.Items.AddRange(new object[] {
            "SQL语句",
            "存储过程",
            "生成表",
            "生成视图"});
            this.cboSQLType.Location = new System.Drawing.Point(679, 5);
            this.cboSQLType.Name = "cboSQLType";
            this.cboSQLType.Size = new System.Drawing.Size(121, 20);
            this.cboSQLType.TabIndex = 5;
            this.cboSQLType.SelectedIndexChanged += new System.EventHandler(this.cboSQLType_SelectedIndexChanged);
            // 
            // cboPrjInfo
            // 
            this.cboPrjInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboPrjInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrjInfo.FormattingEnabled = true;
            this.cboPrjInfo.Location = new System.Drawing.Point(68, 5);
            this.cboPrjInfo.Name = "cboPrjInfo";
            this.cboPrjInfo.Size = new System.Drawing.Size(379, 20);
            this.cboPrjInfo.TabIndex = 1;
            this.cboPrjInfo.SelectedIndexChanged += new System.EventHandler(this.cboPrjInfo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(453, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "类名:";
            // 
            // txtTableName
            // 
            this.txtTableName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTableName.Location = new System.Drawing.Point(494, 4);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(114, 21);
            this.txtTableName.TabIndex = 3;
            this.txtTableName.Text = "SqlEntity";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(614, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "语句类型:";
            // 
            // tblSP
            // 
            this.tblSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tblSP.ColumnCount = 4;
            this.tblSP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblSP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tblSP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblSP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSP.Controls.Add(this.label4, 0, 0);
            this.tblSP.Controls.Add(this.txtSPName, 1, 0);
            this.tblSP.Controls.Add(this.label5, 2, 0);
            this.tblSP.Controls.Add(this.txtSPParam, 3, 0);
            this.tblSP.Location = new System.Drawing.Point(0, 160);
            this.tblSP.Margin = new System.Windows.Forms.Padding(0);
            this.tblSP.Name = "tblSP";
            this.tblSP.RowCount = 1;
            this.tblSP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSP.Size = new System.Drawing.Size(716, 30);
            this.tblSP.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "存储过程名称:";
            // 
            // txtSPName
            // 
            this.txtSPName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSPName.Location = new System.Drawing.Point(92, 4);
            this.txtSPName.Name = "txtSPName";
            this.txtSPName.Size = new System.Drawing.Size(194, 21);
            this.txtSPName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(292, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "存储过程参数:";
            // 
            // txtSPParam
            // 
            this.txtSPParam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSPParam.Location = new System.Drawing.Point(381, 4);
            this.txtSPParam.Name = "txtSPParam";
            this.txtSPParam.ReadOnly = true;
            this.txtSPParam.Size = new System.Drawing.Size(332, 21);
            this.txtSPParam.TabIndex = 3;
            // 
            // tpEntity
            // 
            this.tpEntity.Controls.Add(this.tableLayoutPanel3);
            this.tpEntity.Location = new System.Drawing.Point(4, 4);
            this.tpEntity.Name = "tpEntity";
            this.tpEntity.Size = new System.Drawing.Size(809, 543);
            this.tpEntity.TabIndex = 3;
            this.tpEntity.Text = "实体代码";
            this.tpEntity.UseVisualStyleBackColor = true;
            // 
            // txtEntityCode
            // 
            this.txtEntityCode.AcceptsReturn = true;
            this.txtEntityCode.AcceptsTab = true;
            this.tableLayoutPanel3.SetColumnSpan(this.txtEntityCode, 2);
            this.txtEntityCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEntityCode.Location = new System.Drawing.Point(3, 3);
            this.txtEntityCode.Multiline = true;
            this.txtEntityCode.Name = "txtEntityCode";
            this.txtEntityCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtEntityCode.Size = new System.Drawing.Size(803, 508);
            this.txtEntityCode.TabIndex = 0;
            this.txtEntityCode.WordWrap = false;
            // 
            // tpDAL
            // 
            this.tpDAL.Controls.Add(this.tableLayoutPanel4);
            this.tpDAL.Location = new System.Drawing.Point(4, 4);
            this.tpDAL.Name = "tpDAL";
            this.tpDAL.Size = new System.Drawing.Size(809, 543);
            this.tpDAL.TabIndex = 2;
            this.tpDAL.Text = "数据层代码";
            this.tpDAL.UseVisualStyleBackColor = true;
            // 
            // txtDALCode
            // 
            this.txtDALCode.AcceptsReturn = true;
            this.txtDALCode.AcceptsTab = true;
            this.tableLayoutPanel4.SetColumnSpan(this.txtDALCode, 2);
            this.txtDALCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDALCode.Location = new System.Drawing.Point(3, 3);
            this.txtDALCode.Multiline = true;
            this.txtDALCode.Name = "txtDALCode";
            this.txtDALCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDALCode.Size = new System.Drawing.Size(803, 508);
            this.txtDALCode.TabIndex = 1;
            this.txtDALCode.WordWrap = false;
            // 
            // tpBLL
            // 
            this.tpBLL.Controls.Add(this.tableLayoutPanel5);
            this.tpBLL.Location = new System.Drawing.Point(4, 4);
            this.tpBLL.Name = "tpBLL";
            this.tpBLL.Size = new System.Drawing.Size(809, 543);
            this.tpBLL.TabIndex = 1;
            this.tpBLL.Text = "逻辑层代码";
            this.tpBLL.UseVisualStyleBackColor = true;
            // 
            // txtBLLCode
            // 
            this.txtBLLCode.AcceptsReturn = true;
            this.txtBLLCode.AcceptsTab = true;
            this.tableLayoutPanel5.SetColumnSpan(this.txtBLLCode, 2);
            this.txtBLLCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBLLCode.Location = new System.Drawing.Point(3, 3);
            this.txtBLLCode.Multiline = true;
            this.txtBLLCode.Name = "txtBLLCode";
            this.txtBLLCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBLLCode.Size = new System.Drawing.Size(803, 508);
            this.txtBLLCode.TabIndex = 1;
            this.txtBLLCode.WordWrap = false;
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "False";
            this.colSelected.DefaultCellStyle = dataGridViewCellStyle1;
            this.colSelected.FalseValue = "False";
            this.colSelected.FillWeight = 40F;
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.TrueValue = "True";
            this.colSelected.Visible = false;
            this.colSelected.Width = 40;
            // 
            // colKey
            // 
            this.colKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colKey.DataPropertyName = "IsKey";
            this.colKey.Frozen = true;
            this.colKey.HeaderText = "键值";
            this.colKey.MinimumWidth = 55;
            this.colKey.Name = "colKey";
            this.colKey.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colKey.Width = 55;
            // 
            // colAllowDBNull
            // 
            this.colAllowDBNull.DataPropertyName = "AllowDBNull";
            this.colAllowDBNull.HeaderText = "为空";
            this.colAllowDBNull.MinimumWidth = 55;
            this.colAllowDBNull.Name = "colAllowDBNull";
            this.colAllowDBNull.ReadOnly = true;
            this.colAllowDBNull.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAllowDBNull.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colAllowDBNull.Width = 55;
            // 
            // colIsUnique
            // 
            this.colIsUnique.DataPropertyName = "IsUnique";
            this.colIsUnique.HeaderText = "IsUnique";
            this.colIsUnique.Name = "colIsUnique";
            this.colIsUnique.ReadOnly = true;
            this.colIsUnique.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsUnique.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsUnique.Visible = false;
            // 
            // colIsAutoIncrement
            // 
            this.colIsAutoIncrement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colIsAutoIncrement.DataPropertyName = "IsAutoIncrement";
            this.colIsAutoIncrement.HeaderText = "自增";
            this.colIsAutoIncrement.MinimumWidth = 55;
            this.colIsAutoIncrement.Name = "colIsAutoIncrement";
            this.colIsAutoIncrement.ReadOnly = true;
            this.colIsAutoIncrement.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsAutoIncrement.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsAutoIncrement.Width = 55;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ColumnName";
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "列名";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DataTypeName";
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "数据库类型";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "BaseTableName";
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "表名";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DataType";
            this.dataGridViewTextBoxColumn4.HeaderText = "数据类型";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn5.FillWeight = 120F;
            this.dataGridViewTextBoxColumn5.HeaderText = "描述";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // colName
            // 
            this.colName.DataPropertyName = "ColumnName";
            this.colName.Frozen = true;
            this.colName.HeaderText = "列名";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 120;
            // 
            // colDataTypeName
            // 
            this.colDataTypeName.DataPropertyName = "DataTypeName";
            this.colDataTypeName.Frozen = true;
            this.colDataTypeName.HeaderText = "数据库类型";
            this.colDataTypeName.Name = "colDataTypeName";
            this.colDataTypeName.ReadOnly = true;
            // 
            // colBaseTableName
            // 
            this.colBaseTableName.DataPropertyName = "BaseTableName";
            this.colBaseTableName.Frozen = true;
            this.colBaseTableName.HeaderText = "表名";
            this.colBaseTableName.Name = "colBaseTableName";
            this.colBaseTableName.ReadOnly = true;
            this.colBaseTableName.Width = 120;
            // 
            // colDataType
            // 
            this.colDataType.DataPropertyName = "DataType";
            this.colDataType.HeaderText = "数据类型";
            this.colDataType.Name = "colDataType";
            this.colDataType.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.FillWeight = 120F;
            this.colDescription.HeaderText = "描述";
            this.colDescription.MinimumWidth = 120;
            this.colDescription.Name = "colDescription";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.txtEntityCode, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnEntityCopy, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(809, 543);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // btnEntityCopy
            // 
            this.btnEntityCopy.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnEntityCopy.Location = new System.Drawing.Point(731, 517);
            this.btnEntityCopy.Name = "btnEntityCopy";
            this.btnEntityCopy.Size = new System.Drawing.Size(75, 23);
            this.btnEntityCopy.TabIndex = 1;
            this.btnEntityCopy.Text = "复 制";
            this.btnEntityCopy.UseVisualStyleBackColor = true;
            this.btnEntityCopy.Click += new System.EventHandler(this.btnEntityCopy_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.txtDALCode, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnDALCopy, 1, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(809, 543);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // btnDALCopy
            // 
            this.btnDALCopy.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnDALCopy.Location = new System.Drawing.Point(731, 517);
            this.btnDALCopy.Name = "btnDALCopy";
            this.btnDALCopy.Size = new System.Drawing.Size(75, 23);
            this.btnDALCopy.TabIndex = 2;
            this.btnDALCopy.Text = "复 制";
            this.btnDALCopy.UseVisualStyleBackColor = true;
            this.btnDALCopy.Click += new System.EventHandler(this.btnDALCopy_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.txtBLLCode, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnBLLCopy, 1, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(809, 543);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // btnBLLCopy
            // 
            this.btnBLLCopy.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnBLLCopy.Location = new System.Drawing.Point(731, 517);
            this.btnBLLCopy.Name = "btnBLLCopy";
            this.btnBLLCopy.Size = new System.Drawing.Size(75, 23);
            this.btnBLLCopy.TabIndex = 2;
            this.btnBLLCopy.Text = "复 制";
            this.btnBLLCopy.UseVisualStyleBackColor = true;
            this.btnBLLCopy.Click += new System.EventHandler(this.btnBLLCopy_Click);
            // 
            // GenSQLCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabGen);
            this.Name = "GenSQLCtrl";
            this.Size = new System.Drawing.Size(817, 568);
            this.Enter += new System.EventHandler(this.GenSQLCtrl_Enter);
            this.gpSQL.ResumeLayout(false);
            this.gpSQL.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.tabGen.ResumeLayout(false);
            this.tpMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tblSP.ResumeLayout(false);
            this.tblSP.PerformLayout();
            this.tpEntity.ResumeLayout(false);
            this.tpDAL.ResumeLayout(false);
            this.tpBLL.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpSQL;
        private hwj.UserControls.CommonControls.xButton btnGenSql;
        private  System.Windows.Forms.TextBox txtSQL;
        private System.Windows.Forms.GroupBox groupBox2;
        private hwj.UserControls.DataList.xDataGridView dgList;
        private hwj.UserControls.CommonControls.xButton btnGenFile;
        private System.Windows.Forms.TabControl tabGen;
        private System.Windows.Forms.TabPage tpMain;
        private System.Windows.Forms.TabPage tpBLL;
        private System.Windows.Forms.TabPage tpDAL;
        private hwj.UserControls.CommonControls.xButton btnPreview;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPrjInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTableName;
        public System.Windows.Forms.TextBox txtEntityCode;
        public System.Windows.Forms.TabPage tpEntity;
        public System.Windows.Forms.TextBox txtBLLCode;
        public System.Windows.Forms.TextBox txtDALCode;
        private System.Windows.Forms.ComboBox cboSQLType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tblSP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSPName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSPParam;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBaseTableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAllowDBNull;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsUnique;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsAutoIncrement;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private hwj.UserControls.CommonControls.xButton btnEntityCopy;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private hwj.UserControls.CommonControls.xButton btnDALCopy;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private hwj.UserControls.CommonControls.xButton btnBLLCopy;
    }
}
