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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.xTextBox2 = new hwj.UserControls.CommonControls.xTextBox();
            this.xComboBox1 = new hwj.UserControls.CommonControls.xComboBox();
            this.xDataGridView1 = new hwj.UserControls.DataList.xDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.page1 = new hwj.UserControls.DataList.DataListPage();
            this.xTextBox1 = new hwj.UserControls.CommonControls.xTextBox();
            this.suggestBox1 = new hwj.UserControls.Suggest.SuggestBox();
            this.xDataGridView2 = new hwj.UserControls.DataList.xDataGridView();
            this.xDataGridView3 = new hwj.UserControls.DataList.xDataGridView();
            this.xDataGridView4 = new hwj.UserControls.DataList.xDataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.xDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(186, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 0;
            // 
            // xTextBox2
            // 
            this.xTextBox2.BackColor = System.Drawing.SystemColors.Window;
            this.xTextBox2.Format = null;
            this.xTextBox2.Location = new System.Drawing.Point(343, 49);
            this.xTextBox2.Name = "xTextBox2";
            this.xTextBox2.Size = new System.Drawing.Size(100, 21);
            this.xTextBox2.TabIndex = 4;
            // 
            // xComboBox1
            // 
            this.xComboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.xComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.xComboBox1.EnterEqualTab = true;
            this.xComboBox1.FormattingEnabled = true;
            this.xComboBox1.IsRequired = true;
            this.xComboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.xComboBox1.Location = new System.Drawing.Point(186, 51);
            this.xComboBox1.Name = "xComboBox1";
            this.xComboBox1.Size = new System.Drawing.Size(121, 20);
            this.xComboBox1.TabIndex = 3;
            // 
            // xDataGridView1
            // 
            this.xDataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.xDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.xDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.xDataGridView1.DisplayRows = 0;
            this.xDataGridView1.Location = new System.Drawing.Point(0, 77);
            this.xDataGridView1.Name = "xDataGridView1";
            this.xDataGridView1.RowFooterVisible = false;
            this.xDataGridView1.RowHeadersVisible = false;
            this.xDataGridView1.RowSeqVisible = true;
            this.xDataGridView1.RowTemplate.Height = 23;
            this.xDataGridView1.Size = new System.Drawing.Size(299, 230);
            this.xDataGridView1.SumColumnName = null;
            this.xDataGridView1.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // page1
            // 
            this.page1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.page1.CheckBoxColumn = null;
            this.page1.DataGridView = null;
            this.page1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.page1.Enabled = false;
            this.page1.Location = new System.Drawing.Point(0, 384);
            this.page1.Name = "page1";
            this.page1.PageIndex = 1;
            this.page1.PageSize = 1000;
            this.page1.RecordCount = 0;
            this.page1.Size = new System.Drawing.Size(830, 28);
            this.page1.TabIndex = 2;
            this.page1.PageIndexChanged += new hwj.UserControls.DataList.DataListPage.PageIndexChangedHandler(this.page1_PageIndexChanged);
            // 
            // xTextBox1
            // 
            this.xTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.xTextBox1.ContentType = hwj.UserControls.CommonControls.ContentType.Numberic;
            this.xTextBox1.Format = null;
            this.xTextBox1.Location = new System.Drawing.Point(500, 25);
            this.xTextBox1.Name = "xTextBox1";
            this.xTextBox1.Size = new System.Drawing.Size(100, 21);
            this.xTextBox1.TabIndex = 2;
            this.xTextBox1.Text = "0.00";
            this.xTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // suggestBox1
            // 
            this.suggestBox1.BackColor = System.Drawing.SystemColors.Window;
            this.suggestBox1.DropDownStyle = hwj.UserControls.Suggest.SuggestBox.SuggextBoxStyle.DropDownList;
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
            this.suggestBox1.TabIndex = 1;
            // 
            // xDataGridView2
            // 
            this.xDataGridView2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.xDataGridView2.DisplayRows = 0;
            this.xDataGridView2.Location = new System.Drawing.Point(0, 0);
            this.xDataGridView2.Name = "xDataGridView2";
            this.xDataGridView2.RowFooterVisible = false;
            this.xDataGridView2.RowHeadersVisible = false;
            this.xDataGridView2.RowSeqVisible = false;
            this.xDataGridView2.Size = new System.Drawing.Size(240, 150);
            this.xDataGridView2.SumColumnName = ((System.Collections.Generic.List<string>)(resources.GetObject("xDataGridView2.SumColumnName")));
            this.xDataGridView2.TabIndex = 0;
            // 
            // xDataGridView3
            // 
            this.xDataGridView3.BackgroundColor = System.Drawing.SystemColors.Window;
            this.xDataGridView3.DisplayRows = 0;
            this.xDataGridView3.Location = new System.Drawing.Point(0, 0);
            this.xDataGridView3.Name = "xDataGridView3";
            this.xDataGridView3.RowFooterVisible = false;
            this.xDataGridView3.RowHeadersVisible = false;
            this.xDataGridView3.RowSeqVisible = false;
            this.xDataGridView3.Size = new System.Drawing.Size(240, 150);
            this.xDataGridView3.SumColumnName = ((System.Collections.Generic.List<string>)(resources.GetObject("xDataGridView3.SumColumnName")));
            this.xDataGridView3.TabIndex = 0;
            // 
            // xDataGridView4
            // 
            this.xDataGridView4.BackgroundColor = System.Drawing.SystemColors.Window;
            this.xDataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.xDataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4});
            this.xDataGridView4.DisplayRows = 0;
            this.xDataGridView4.Location = new System.Drawing.Point(327, 86);
            this.xDataGridView4.Name = "xDataGridView4";
            this.xDataGridView4.RowFooterVisible = false;
            this.xDataGridView4.RowHeadersVisible = false;
            this.xDataGridView4.RowSeqVisible = false;
            this.xDataGridView4.RowTemplate.Height = 23;
            this.xDataGridView4.Size = new System.Drawing.Size(240, 150);
            this.xDataGridView4.SumColumnName = ((System.Collections.Generic.List<string>)(resources.GetObject("xDataGridView4.SumColumnName")));
            this.xDataGridView4.TabIndex = 5;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            // 
            // Suggest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 412);
            this.Controls.Add(this.xDataGridView4);
            this.Controls.Add(this.xTextBox2);
            this.Controls.Add(this.xComboBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.xDataGridView1);
            this.Controls.Add(this.page1);
            this.Controls.Add(this.xTextBox1);
            this.Controls.Add(this.suggestBox1);
            this.Name = "Suggest";
            this.Text = "Suggest";
            this.Load += new System.EventHandler(this.Suggest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDataGridView4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private hwj.UserControls.Suggest.SuggestBox suggestBox1;
        private hwj.UserControls.CommonControls.xTextBox xTextBox1;
        private hwj.UserControls.DataList.DataListPage page1;
        private hwj.UserControls.DataList.xDataGridView xDataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private hwj.UserControls.CommonControls.xComboBox xComboBox1;
        private hwj.UserControls.CommonControls.xTextBox xTextBox2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private hwj.UserControls.DataList.xDataGridView xDataGridView2;
        private hwj.UserControls.DataList.xDataGridView xDataGridView3;
        private hwj.UserControls.DataList.xDataGridView xDataGridView4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}