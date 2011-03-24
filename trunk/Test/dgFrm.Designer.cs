namespace Test
{
    partial class dgFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dgFrm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataListPage1 = new hwj.UserControls.DataList.DataListPage();
            this.dgList = new hwj.UserControls.DataList.xDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new hwj.UserControls.DataList.xDataGridViewTextBoxColumn();
            this.Column4 = new hwj.UserControls.DataList.xDataGridViewNumbericColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.xButton1 = new hwj.UserControls.CommonControls.xButton();
            this.btnGet = new hwj.UserControls.CommonControls.xButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataListPage1
            // 
            this.dataListPage1.CheckBoxColumn = null;
            this.dataListPage1.DataGridView = this.dgList;
            this.dataListPage1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataListPage1.Enabled = false;
            this.dataListPage1.Location = new System.Drawing.Point(0, 430);
            this.dataListPage1.Name = "dataListPage1";
            this.dataListPage1.PageIndex = 1;
            this.dataListPage1.PageSize = 100;
            this.dataListPage1.RecordCount = 0;
            this.dataListPage1.SelectAllVisible = true;
            this.dataListPage1.SelectChecked = false;
            this.dataListPage1.Size = new System.Drawing.Size(831, 25);
            this.dataListPage1.TabIndex = 3;
            // 
            // dgList
            // 
            this.dgList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgList.DataListPage = this.dataListPage1;
            this.dgList.DisplayRows = 0;
            this.dgList.Location = new System.Drawing.Point(12, 12);
            this.dgList.Name = "dgList";
            this.dgList.RowFooterVisible = false;
            this.dgList.RowHeadersVisible = false;
            this.dgList.RowSeqVisible = false;
            this.dgList.RowTemplate.Height = 23;
            this.dgList.Size = new System.Drawing.Size(807, 323);
            this.dgList.SumColumnName = ((System.Collections.Generic.List<string>)(resources.GetObject("dgList.SumColumnName")));
            this.dgList.TabIndex = 0;
            this.dgList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgList_CellValueChanged);
            this.dgList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgList_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.MaxInputLength = 5;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Format = "N1";
            this.Column4.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column4.HeaderText = "Column4";
            this.Column4.MaxInputLength = 5;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            // 
            // xButton1
            // 
            this.xButton1.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.xButton1.Location = new System.Drawing.Point(583, 341);
            this.xButton1.Name = "xButton1";
            this.xButton1.Size = new System.Drawing.Size(75, 23);
            this.xButton1.TabIndex = 2;
            this.xButton1.Text = "xButton1";
            this.xButton1.UseVisualStyleBackColor = true;
            this.xButton1.Click += new System.EventHandler(this.xButton1_Click);
            // 
            // btnGet
            // 
            this.btnGet.CursorFromClick = System.Windows.Forms.Cursors.WaitCursor;
            this.btnGet.Location = new System.Drawing.Point(744, 341);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 23);
            this.btnGet.TabIndex = 1;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // dgFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 455);
            this.Controls.Add(this.dataListPage1);
            this.Controls.Add(this.xButton1);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.dgList);
            this.Name = "dgFrm";
            this.Text = "DataGridView";
            this.Load += new System.EventHandler(this.dgFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private hwj.UserControls.DataList.xDataGridView dgList;
        private hwj.UserControls.CommonControls.xButton btnGet;
        private hwj.UserControls.CommonControls.xButton xButton1;
        private hwj.UserControls.DataList.DataListPage dataListPage1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private hwj.UserControls.DataList.xDataGridViewTextBoxColumn Column3;
        private hwj.UserControls.DataList.xDataGridViewNumbericColumn Column4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
    }
}