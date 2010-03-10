namespace hwj.MarkTableObject.Components
{
    partial class MSSQLCtrl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRefreshDB = new hwj.UserControls.CommonControls.xButton();
            this.cboDatabase = new hwj.UserControls.CommonControls.xComboBox();
            this.txtServer = new hwj.UserControls.CommonControls.xTextBox();
            this.cboServerType = new hwj.UserControls.CommonControls.xComboBox();
            this.cboVerificationType = new hwj.UserControls.CommonControls.xComboBox();
            this.txtUser = new hwj.UserControls.CommonControls.xTextBox();
            this.txtPassword = new hwj.UserControls.CommonControls.xTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnRefreshDB, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.cboDatabase, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtServer, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboServerType, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboVerificationType, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtUser, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtPassword, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(397, 201);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器名称:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "服务器类型:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "身份验证:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "登录名:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "密码:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "数据库:";
            // 
            // btnRefreshDB
            // 
            this.btnRefreshDB.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnRefreshDB.Location = new System.Drawing.Point(336, 143);
            this.btnRefreshDB.Name = "btnRefreshDB";
            this.btnRefreshDB.Size = new System.Drawing.Size(58, 22);
            this.btnRefreshDB.TabIndex = 1;
            this.btnRefreshDB.Text = "刷新";
            this.btnRefreshDB.UseVisualStyleBackColor = true;
            this.btnRefreshDB.Click += new System.EventHandler(this.btnRefreshDB_Click);
            // 
            // cboDatabase
            // 
            this.cboDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDatabase.BackColor = System.Drawing.SystemColors.Window;
            this.cboDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDatabase.FormattingEnabled = true;
            this.cboDatabase.Location = new System.Drawing.Point(80, 144);
            this.cboDatabase.Name = "cboDatabase";
            this.cboDatabase.OldBackColor = System.Drawing.SystemColors.Window;
            this.cboDatabase.Size = new System.Drawing.Size(250, 20);
            this.cboDatabase.TabIndex = 2;
            this.cboDatabase.Click += new System.EventHandler(this.cboDatabase_Click);
            // 
            // txtServer
            // 
            this.txtServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServer.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.SetColumnSpan(this.txtServer, 2);
            this.txtServer.Format = null;
            this.txtServer.Location = new System.Drawing.Point(80, 3);
            this.txtServer.Name = "txtServer";
            this.txtServer.OldBackColor = System.Drawing.SystemColors.Window;
            this.txtServer.SetValueToControl = null;
            this.txtServer.Size = new System.Drawing.Size(314, 21);
            this.txtServer.TabIndex = 3;
            this.txtServer.Text = "192.168.1.200";
            this.txtServer.TextIsChanged = false;
            // 
            // cboServerType
            // 
            this.cboServerType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboServerType.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.SetColumnSpan(this.cboServerType, 2);
            this.cboServerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServerType.FormattingEnabled = true;
            this.cboServerType.Items.AddRange(new object[] {
            "SQL Server2005",
            "SQL Server2000"});
            this.cboServerType.Location = new System.Drawing.Point(80, 32);
            this.cboServerType.Name = "cboServerType";
            this.cboServerType.OldBackColor = System.Drawing.SystemColors.Window;
            this.cboServerType.Size = new System.Drawing.Size(314, 20);
            this.cboServerType.TabIndex = 4;
            // 
            // cboVerificationType
            // 
            this.cboVerificationType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboVerificationType.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.SetColumnSpan(this.cboVerificationType, 2);
            this.cboVerificationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVerificationType.FormattingEnabled = true;
            this.cboVerificationType.Items.AddRange(new object[] {
            "SQL Server 身份认证",
            "Windows 身份认证"});
            this.cboVerificationType.Location = new System.Drawing.Point(80, 60);
            this.cboVerificationType.Name = "cboVerificationType";
            this.cboVerificationType.OldBackColor = System.Drawing.SystemColors.Window;
            this.cboVerificationType.Size = new System.Drawing.Size(314, 20);
            this.cboVerificationType.TabIndex = 5;
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUser.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.SetColumnSpan(this.txtUser, 2);
            this.txtUser.Format = null;
            this.txtUser.Location = new System.Drawing.Point(80, 87);
            this.txtUser.Name = "txtUser";
            this.txtUser.OldBackColor = System.Drawing.SystemColors.Window;
            this.txtUser.SetValueToControl = null;
            this.txtUser.Size = new System.Drawing.Size(314, 21);
            this.txtUser.TabIndex = 6;
            this.txtUser.Text = "sa";
            this.txtUser.TextIsChanged = false;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.SetColumnSpan(this.txtPassword, 2);
            this.txtPassword.Format = null;
            this.txtPassword.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPassword.Location = new System.Drawing.Point(80, 115);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.OldBackColor = System.Drawing.SystemColors.Window;
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.SetValueToControl = null;
            this.txtPassword.Size = new System.Drawing.Size(314, 21);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.Text = "113502";
            this.txtPassword.TextIsChanged = false;
            // 
            // MSSQLCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MSSQLCtrl";
            this.Size = new System.Drawing.Size(397, 201);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private hwj.UserControls.CommonControls.xButton btnRefreshDB;
        private hwj.UserControls.CommonControls.xComboBox cboDatabase;
        private hwj.UserControls.CommonControls.xTextBox txtServer;
        private hwj.UserControls.CommonControls.xComboBox cboServerType;
        private hwj.UserControls.CommonControls.xComboBox cboVerificationType;
        private hwj.UserControls.CommonControls.xTextBox txtUser;
        private hwj.UserControls.CommonControls.xTextBox txtPassword;
    }
}
