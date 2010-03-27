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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSQL = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpMain = new System.Windows.Forms.TabPage();
            this.tpBLL = new System.Windows.Forms.TabPage();
            this.tpDAL = new System.Windows.Forms.TabPage();
            this.tpEntity = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPrjInfo = new System.Windows.Forms.ComboBox();
            this.dgList = new hwj.UserControls.DataList.xDataGridView();
            this.btnGenSql = new hwj.UserControls.CommonControls.xButton();
            this.btnGenFile = new hwj.UserControls.CommonControls.xButton();
            this.btnPreview = new hwj.UserControls.CommonControls.xButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.txtEntityCode = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpMain.SuspendLayout();
            this.tpEntity.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.txtSQL);
            this.groupBox1.Location = new System.Drawing.Point(3, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(797, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SQL语句";
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
            this.groupBox2.Size = new System.Drawing.Size(797, 310);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "表信息";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpMain);
            this.tabControl1.Controls.Add(this.tpEntity);
            this.tabControl1.Controls.Add(this.tpBLL);
            this.tabControl1.Controls.Add(this.tpDAL);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(817, 568);
            this.tabControl1.TabIndex = 3;
            // 
            // tpMain
            // 
            this.tpMain.Controls.Add(this.tableLayoutPanel1);
            this.tpMain.Location = new System.Drawing.Point(4, 22);
            this.tpMain.Name = "tpMain";
            this.tpMain.Padding = new System.Windows.Forms.Padding(3);
            this.tpMain.Size = new System.Drawing.Size(809, 542);
            this.tpMain.TabIndex = 0;
            this.tpMain.Text = "生成代码";
            this.tpMain.UseVisualStyleBackColor = true;
            // 
            // tpBLL
            // 
            this.tpBLL.Location = new System.Drawing.Point(4, 22);
            this.tpBLL.Name = "tpBLL";
            this.tpBLL.Padding = new System.Windows.Forms.Padding(3);
            this.tpBLL.Size = new System.Drawing.Size(809, 542);
            this.tpBLL.TabIndex = 1;
            this.tpBLL.Text = "逻辑层代码";
            this.tpBLL.UseVisualStyleBackColor = true;
            // 
            // tpDAL
            // 
            this.tpDAL.Location = new System.Drawing.Point(4, 22);
            this.tpDAL.Name = "tpDAL";
            this.tpDAL.Size = new System.Drawing.Size(809, 542);
            this.tpDAL.TabIndex = 2;
            this.tpDAL.Text = "数据层代码";
            this.tpDAL.UseVisualStyleBackColor = true;
            // 
            // tpEntity
            // 
            this.tpEntity.Controls.Add(this.txtEntityCode);
            this.tpEntity.Location = new System.Drawing.Point(4, 22);
            this.tpEntity.Name = "tpEntity";
            this.tpEntity.Size = new System.Drawing.Size(809, 542);
            this.tpEntity.TabIndex = 3;
            this.tpEntity.Text = "实体代码";
            this.tpEntity.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.Controls.Add(this.btnGenSql, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnGenFile, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnPreview, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(803, 536);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cboPrjInfo, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtTableName, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(803, 30);
            this.tableLayoutPanel2.TabIndex = 3;
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
            // cboPrjInfo
            // 
            this.cboPrjInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboPrjInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrjInfo.FormattingEnabled = true;
            this.cboPrjInfo.Location = new System.Drawing.Point(68, 5);
            this.cboPrjInfo.Name = "cboPrjInfo";
            this.cboPrjInfo.Size = new System.Drawing.Size(393, 20);
            this.cboPrjInfo.TabIndex = 1;
            this.cboPrjInfo.SelectedIndexChanged += new System.EventHandler(this.cboPrjInfo_SelectedIndexChanged);
            // 
            // dgList
            // 
            this.dgList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgList.DataListPage = null;
            this.dgList.DisplayRows = 0;
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Location = new System.Drawing.Point(3, 17);
            this.dgList.Name = "dgList";
            this.dgList.RowFooterVisible = false;
            this.dgList.RowHeadersVisible = false;
            this.dgList.RowSeqVisible = false;
            this.dgList.RowTemplate.Height = 23;
            this.dgList.Size = new System.Drawing.Size(791, 290);
            this.dgList.SumColumnName = ((System.Collections.Generic.List<string>)(resources.GetObject("dgList.SumColumnName")));
            this.dgList.TabIndex = 0;
            // 
            // btnGenSql
            // 
            this.btnGenSql.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenSql.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnGenSql.Location = new System.Drawing.Point(725, 163);
            this.btnGenSql.Name = "btnGenSql";
            this.btnGenSql.Size = new System.Drawing.Size(75, 23);
            this.btnGenSql.TabIndex = 1;
            this.btnGenSql.Text = "生成表";
            this.btnGenSql.UseVisualStyleBackColor = true;
            this.btnGenSql.Click += new System.EventHandler(this.btnGenSql_Click);
            // 
            // btnGenFile
            // 
            this.btnGenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenFile.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnGenFile.Location = new System.Drawing.Point(725, 510);
            this.btnGenFile.Name = "btnGenFile";
            this.btnGenFile.Size = new System.Drawing.Size(75, 23);
            this.btnGenFile.TabIndex = 2;
            this.btnGenFile.Text = "生成文件";
            this.btnGenFile.UseVisualStyleBackColor = true;
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnPreview.Location = new System.Drawing.Point(638, 510);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 2;
            this.btnPreview.Text = "代码预览";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(467, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "类名:";
            // 
            // txtTableName
            // 
            this.txtTableName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTableName.Location = new System.Drawing.Point(508, 4);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(292, 21);
            this.txtTableName.TabIndex = 2;
            this.txtTableName.Text = "SqlEntity";
            // 
            // txtEntityCode
            // 
            this.txtEntityCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEntityCode.Location = new System.Drawing.Point(0, 0);
            this.txtEntityCode.Multiline = true;
            this.txtEntityCode.Name = "txtEntityCode";
            this.txtEntityCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtEntityCode.Size = new System.Drawing.Size(809, 542);
            this.txtEntityCode.TabIndex = 0;
            // 
            // GenSQLCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "GenSQLCtrl";
            this.Size = new System.Drawing.Size(817, 568);
            this.Enter += new System.EventHandler(this.GenSQLCtrl_Enter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpMain.ResumeLayout(false);
            this.tpEntity.ResumeLayout(false);
            this.tpEntity.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private hwj.UserControls.CommonControls.xButton btnGenSql;
        private System.Windows.Forms.TextBox txtSQL;
        private System.Windows.Forms.GroupBox groupBox2;
        private hwj.UserControls.DataList.xDataGridView dgList;
        private hwj.UserControls.CommonControls.xButton btnGenFile;
        private System.Windows.Forms.TabControl tabControl1;
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
    }
}
