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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnGet = new hwj.UserControls.CommonControls.xButton();
            this.dgList = new hwj.UserControls.DataList.xDataGridView();
            this.coAmount = new hwj.UserControls.DataList.xDataGridViewNumbericColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.xButton1 = new hwj.UserControls.CommonControls.xButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.SuspendLayout();
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
            // dgList
            // 
            this.dgList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coAmount,
            this.Column1});
            this.dgList.DataListPage = null;
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
            // 
            // coAmount
            // 
            this.coAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "###,##0.00";
            this.coAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.coAmount.HeaderText = "Amount";
            this.coAmount.Name = "coAmount";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
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
            // dgFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 455);
            this.Controls.Add(this.xButton1);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.dgList);
            this.Name = "dgFrm";
            this.Text = "DataGridView";
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private hwj.UserControls.DataList.xDataGridView dgList;
        private hwj.UserControls.CommonControls.xButton btnGet;
        private hwj.UserControls.DataList.xDataGridViewNumbericColumn coAmount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private hwj.UserControls.CommonControls.xButton xButton1;
    }
}