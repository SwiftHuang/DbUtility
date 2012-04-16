namespace hwj.MarkTableObject.Forms
{
    partial class Main
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("项 目");
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.treeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMenuConn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMenuGeneral = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tvServers = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tBtnAddPrj = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabClassTran = new System.Windows.Forms.TabPage();
            this.genSQLCtrl2 = new hwj.MarkTableObject.Components.GenSQLCtrl();
            this.ucClassTransfer1 = new hwj.MarkTableObject.Components.UCClassTransfer();
            this.treeMenu.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabClassTran.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 659);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(981, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // treeMenu
            // 
            this.treeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuConn,
            this.toolStripSeparator1,
            this.tsMenuGeneral,
            this.tsMenuSetting});
            this.treeMenu.Name = "treeMenu";
            this.treeMenu.Size = new System.Drawing.Size(125, 76);
            // 
            // tsMenuConn
            // 
            this.tsMenuConn.Name = "tsMenuConn";
            this.tsMenuConn.Size = new System.Drawing.Size(124, 22);
            this.tsMenuConn.Text = "连 接";
            this.tsMenuConn.Click += new System.EventHandler(this.tsMenuConn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // tsMenuGeneral
            // 
            this.tsMenuGeneral.Name = "tsMenuGeneral";
            this.tsMenuGeneral.Size = new System.Drawing.Size(124, 22);
            this.tsMenuGeneral.Text = "批量生成";
            this.tsMenuGeneral.Click += new System.EventHandler(this.tsMenuGeneral_Click);
            // 
            // tsMenuSetting
            // 
            this.tsMenuSetting.Name = "tsMenuSetting";
            this.tsMenuSetting.Size = new System.Drawing.Size(124, 22);
            this.tsMenuSetting.Text = "属 性";
            this.tsMenuSetting.Click += new System.EventHandler(this.tsMenuSetting_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(981, 659);
            this.splitContainer1.SplitterDistance = 234;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tvServers, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(234, 659);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tvServers
            // 
            this.tvServers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvServers.Location = new System.Drawing.Point(3, 28);
            this.tvServers.Name = "tvServers";
            treeNode1.Name = "NodeProject";
            treeNode1.Text = "项 目";
            this.tvServers.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvServers.Size = new System.Drawing.Size(228, 628);
            this.tvServers.TabIndex = 0;
            this.tvServers.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvServers_NodeMouseDoubleClick);
            this.tvServers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvServers_MouseDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tBtnAddPrj});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(234, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tBtnAddPrj
            // 
            this.tBtnAddPrj.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tBtnAddPrj.Image = global::hwj.MarkTableObject.Properties.Resources.add;
            this.tBtnAddPrj.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tBtnAddPrj.Name = "tBtnAddPrj";
            this.tBtnAddPrj.Size = new System.Drawing.Size(23, 22);
            this.tBtnAddPrj.Text = "添加项目";
            this.tBtnAddPrj.Click += new System.EventHandler(this.tBtnAddPrj_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabClassTran);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(743, 659);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(735, 633);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "首 页";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.genSQLCtrl2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(735, 633);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "生成代码";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabClassTran
            // 
            this.tabClassTran.Controls.Add(this.ucClassTransfer1);
            this.tabClassTran.Location = new System.Drawing.Point(4, 22);
            this.tabClassTran.Name = "tabClassTran";
            this.tabClassTran.Size = new System.Drawing.Size(735, 633);
            this.tabClassTran.TabIndex = 2;
            this.tabClassTran.Text = "类转换";
            this.tabClassTran.UseVisualStyleBackColor = true;
            // 
            // genSQLCtrl2
            // 
            this.genSQLCtrl2.ClassName = "SqlEntity";
            this.genSQLCtrl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.genSQLCtrl2.Location = new System.Drawing.Point(3, 3);
            this.genSQLCtrl2.Module = hwj.MarkTableObject.DBModule.SQL;
            this.genSQLCtrl2.Name = "genSQLCtrl2";
            this.genSQLCtrl2.PrjInfo = null;
            this.genSQLCtrl2.Size = new System.Drawing.Size(729, 627);
            this.genSQLCtrl2.TabIndex = 0;
            // 
            // ucClassTransfer1
            // 
            this.ucClassTransfer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucClassTransfer1.Location = new System.Drawing.Point(0, 0);
            this.ucClassTransfer1.Name = "ucClassTransfer1";
            this.ucClassTransfer1.Size = new System.Drawing.Size(735, 633);
            this.ucClassTransfer1.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 681);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "代码生成工具 Ver 0.0.0.0";
            this.Load += new System.EventHandler(this.Main_Load);
            this.treeMenu.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabClassTran.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tBtnAddPrj;
        private System.Windows.Forms.ContextMenuStrip treeMenu;
        private System.Windows.Forms.ToolStripMenuItem tsMenuGeneral;
        private System.Windows.Forms.ToolStripMenuItem tsMenuSetting;
        private System.Windows.Forms.ToolStripMenuItem tsMenuConn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private hwj.MarkTableObject.Components.GenSQLCtrl genSQLCtrl1;
        private System.Windows.Forms.TreeView tvServers;
        private hwj.MarkTableObject.Components.GenSQLCtrl genSQLCtrl2;
        private System.Windows.Forms.TabPage tabClassTran;
        private hwj.MarkTableObject.Components.UCClassTransfer ucClassTransfer1;

    }
}

