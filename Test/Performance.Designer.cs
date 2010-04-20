namespace Test
{
    partial class Performance
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
            this.btnFillAll = new System.Windows.Forms.Button();
            this.btnLike = new hwj.UserControls.CommonControls.xButton();
            this.lblLike = new System.Windows.Forms.Label();
            this.lblFindAll = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnFind = new hwj.UserControls.CommonControls.xButton();
            this.lblFind = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBinary = new hwj.UserControls.CommonControls.xButton();
            this.lblBinary = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGetTable = new hwj.UserControls.CommonControls.xButton();
            this.btnGetList = new hwj.UserControls.CommonControls.xButton();
            this.lblGetTable = new System.Windows.Forms.Label();
            this.lblGetList = new System.Windows.Forms.Label();
            this.btnBreakNum = new hwj.UserControls.CommonControls.xButton();
            this.lblBreakNum = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFillAll
            // 
            this.btnFillAll.Location = new System.Drawing.Point(435, 3);
            this.btnFillAll.Name = "btnFillAll";
            this.btnFillAll.Size = new System.Drawing.Size(75, 23);
            this.btnFillAll.TabIndex = 0;
            this.btnFillAll.Text = "Test";
            this.btnFillAll.UseVisualStyleBackColor = true;
            this.btnFillAll.Click += new System.EventHandler(this.btnFillAll_Click);
            // 
            // btnLike
            // 
            this.btnLike.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnLike.Location = new System.Drawing.Point(164, 3);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new System.Drawing.Size(74, 23);
            this.btnLike.TabIndex = 1;
            this.btnLike.Text = "Test";
            this.btnLike.UseVisualStyleBackColor = true;
            this.btnLike.Click += new System.EventHandler(this.btnLike_Click);
            // 
            // lblLike
            // 
            this.lblLike.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLike.AutoSize = true;
            this.lblLike.Location = new System.Drawing.Point(62, 9);
            this.lblLike.Name = "lblLike";
            this.lblLike.Size = new System.Drawing.Size(96, 12);
            this.lblLike.TabIndex = 2;
            this.lblLike.Text = "label1";
            // 
            // lblFindAll
            // 
            this.lblFindAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFindAll.AutoSize = true;
            this.lblFindAll.Location = new System.Drawing.Point(333, 9);
            this.lblFindAll.Name = "lblFindAll";
            this.lblFindAll.Size = new System.Drawing.Size(96, 12);
            this.lblFindAll.TabIndex = 3;
            this.lblFindAll.Text = "label1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.Controls.Add(this.btnLike, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFillAll, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFindAll, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLike, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFind, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFind, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnBinary, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblBinary, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnGetTable, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnGetList, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblGetTable, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblGetList, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnBreakNum, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblBreakNum, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(513, 264);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // btnFind
            // 
            this.btnFind.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnFind.Location = new System.Drawing.Point(164, 33);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(74, 23);
            this.btnFind.TabIndex = 1;
            this.btnFind.Text = "Test";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // lblFind
            // 
            this.lblFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFind.AutoSize = true;
            this.lblFind.Location = new System.Drawing.Point(62, 39);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(96, 12);
            this.lblFind.TabIndex = 2;
            this.lblFind.Text = "label1";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Find ALL";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Like";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Find";
            // 
            // btnBinary
            // 
            this.btnBinary.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnBinary.Location = new System.Drawing.Point(435, 33);
            this.btnBinary.Name = "btnBinary";
            this.btnBinary.Size = new System.Drawing.Size(75, 23);
            this.btnBinary.TabIndex = 1;
            this.btnBinary.Text = "Test";
            this.btnBinary.UseVisualStyleBackColor = true;
            this.btnBinary.Click += new System.EventHandler(this.btnBinary_Click);
            // 
            // lblBinary
            // 
            this.lblBinary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBinary.AutoSize = true;
            this.lblBinary.Location = new System.Drawing.Point(333, 39);
            this.lblBinary.Name = "lblBinary";
            this.lblBinary.Size = new System.Drawing.Size(96, 12);
            this.lblBinary.TabIndex = 2;
            this.lblBinary.Text = "label1";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "Binary Search";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Table";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(244, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "GenList";
            // 
            // btnGetTable
            // 
            this.btnGetTable.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnGetTable.Location = new System.Drawing.Point(164, 63);
            this.btnGetTable.Name = "btnGetTable";
            this.btnGetTable.Size = new System.Drawing.Size(74, 23);
            this.btnGetTable.TabIndex = 1;
            this.btnGetTable.Text = "Test";
            this.btnGetTable.UseVisualStyleBackColor = true;
            this.btnGetTable.Click += new System.EventHandler(this.btnGetTable_Click);
            // 
            // btnGetList
            // 
            this.btnGetList.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnGetList.Location = new System.Drawing.Point(435, 63);
            this.btnGetList.Name = "btnGetList";
            this.btnGetList.Size = new System.Drawing.Size(75, 23);
            this.btnGetList.TabIndex = 1;
            this.btnGetList.Text = "Test";
            this.btnGetList.UseVisualStyleBackColor = true;
            this.btnGetList.Click += new System.EventHandler(this.btnGetList_Click);
            // 
            // lblGetTable
            // 
            this.lblGetTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGetTable.AutoSize = true;
            this.lblGetTable.Location = new System.Drawing.Point(62, 69);
            this.lblGetTable.Name = "lblGetTable";
            this.lblGetTable.Size = new System.Drawing.Size(96, 12);
            this.lblGetTable.TabIndex = 2;
            this.lblGetTable.Text = "label1";
            // 
            // lblGetList
            // 
            this.lblGetList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGetList.AutoSize = true;
            this.lblGetList.Location = new System.Drawing.Point(333, 69);
            this.lblGetList.Name = "lblGetList";
            this.lblGetList.Size = new System.Drawing.Size(96, 12);
            this.lblGetList.TabIndex = 2;
            this.lblGetList.Text = "label1";
            // 
            // btnBreakNum
            // 
            this.btnBreakNum.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnBreakNum.Location = new System.Drawing.Point(164, 93);
            this.btnBreakNum.Name = "btnBreakNum";
            this.btnBreakNum.Size = new System.Drawing.Size(74, 23);
            this.btnBreakNum.TabIndex = 1;
            this.btnBreakNum.Text = "Test";
            this.btnBreakNum.UseVisualStyleBackColor = true;
            this.btnBreakNum.Click += new System.EventHandler(this.btnBreakNum_Click);
            // 
            // lblBreakNum
            // 
            this.lblBreakNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBreakNum.AutoSize = true;
            this.lblBreakNum.Location = new System.Drawing.Point(62, 98);
            this.lblBreakNum.Name = "lblBreakNum";
            this.lblBreakNum.Size = new System.Drawing.Size(96, 12);
            this.lblBreakNum.TabIndex = 2;
            this.lblBreakNum.Text = "label1";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "BreakNum";
            // 
            // Performance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 264);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Performance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFillAll;
        private hwj.UserControls.CommonControls.xButton btnLike;
        private System.Windows.Forms.Label lblLike;
        private System.Windows.Forms.Label lblFindAll;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private hwj.UserControls.CommonControls.xButton btnFind;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private hwj.UserControls.CommonControls.xButton btnBinary;
        private System.Windows.Forms.Label lblBinary;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private hwj.UserControls.CommonControls.xButton btnGetTable;
        private hwj.UserControls.CommonControls.xButton btnGetList;
        private System.Windows.Forms.Label lblGetTable;
        private System.Windows.Forms.Label lblGetList;
        private hwj.UserControls.CommonControls.xButton btnBreakNum;
        private System.Windows.Forms.Label lblBreakNum;
        private System.Windows.Forms.Label label8;
    }
}