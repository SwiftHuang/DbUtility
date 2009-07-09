namespace Test
{
    partial class Suggest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Suggest));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.xDataGridView1 = new hwj.UserControls.DataList.xDataGridView();
            this.page1 = new hwj.UserControls.DataList.DataListPage();
            this.xTextBox1 = new hwj.UserControls.CommonControls.xTextBox();
            this.suggestBox1 = new hwj.UserControls.Suggest.SuggestBox();
            ((System.ComponentModel.ISupportInitialize)(this.xDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // xDataGridView1
            // 
            this.xDataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.xDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.xDataGridView1.DisplayRows = ((ulong)(0ul));
            this.xDataGridView1.FooterVisible = false;
            this.xDataGridView1.Location = new System.Drawing.Point(94, 97);
            this.xDataGridView1.Name = "xDataGridView1";
            this.xDataGridView1.RowHeadersVisible = false;
            this.xDataGridView1.RowNum = true;
            this.xDataGridView1.RowTemplate.Height = 23;
            this.xDataGridView1.Size = new System.Drawing.Size(629, 230);
            this.xDataGridView1.SumColumnName = ((System.Collections.Generic.List<string>)(resources.GetObject("xDataGridView1.SumColumnName")));
            this.xDataGridView1.TabIndex = 3;
            // 
            // page1
            // 
            this.page1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.page1.Location = new System.Drawing.Point(94, 327);
            this.page1.Name = "page1";
            this.page1.PageIndex = 1;
            this.page1.PageSize = 1000;
            this.page1.RecordCount = 0;
            this.page1.Size = new System.Drawing.Size(629, 28);
            this.page1.TabIndex = 2;
            this.page1.PageIndexChanged += new hwj.UserControls.DataList.DataListPage.PageIndexChangedHandler(this.page1_PageIndexChanged);
            // 
            // xTextBox1
            // 
            this.xTextBox1.ContentType = hwj.UserControls.CommonControls.ContentType.Numberic;
            this.xTextBox1.Format = null;
            this.xTextBox1.Location = new System.Drawing.Point(500, 25);
            this.xTextBox1.Name = "xTextBox1";
            this.xTextBox1.Size = new System.Drawing.Size(100, 21);
            this.xTextBox1.TabIndex = 1;
            this.xTextBox1.Text = "0.00";
            this.xTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // suggestBox1
            // 
            this.suggestBox1.BackColor = System.Drawing.SystemColors.Window;
            this.suggestBox1.EmptyValue = "";
            this.suggestBox1.Location = new System.Drawing.Point(343, 25);
            this.suggestBox1.MaxLength = 32767;
            this.suggestBox1.Name = "suggestBox1";
            this.suggestBox1.PrimaryColumnHeaderName = null;
            this.suggestBox1.SecondColumnHeaderName = null;
            this.suggestBox1.SecondColumnMode = false;
            this.suggestBox1.SelectedText = "";
            this.suggestBox1.SelectedValue = "";
            this.suggestBox1.Size = new System.Drawing.Size(120, 21);
            this.suggestBox1.TabIndex = 0;
            this.suggestBox1.DataBinding += new System.EventHandler(this.suggestBox1_DataBinding);
            // 
            // Suggest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 412);
            this.Controls.Add(this.xDataGridView1);
            this.Controls.Add(this.page1);
            this.Controls.Add(this.xTextBox1);
            this.Controls.Add(this.suggestBox1);
            this.Name = "Suggest";
            this.Text = "Suggest";
            this.Load += new System.EventHandler(this.Suggest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private hwj.UserControls.Suggest.SuggestBox suggestBox1;
        private hwj.UserControls.CommonControls.xTextBox xTextBox1;
        private hwj.UserControls.DataList.DataListPage page1;
        private hwj.UserControls.DataList.xDataGridView xDataGridView1;
    }
}