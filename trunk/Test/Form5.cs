using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Test
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private int oldRowIndex = 0;
        private const int CUSTOM_CONTENT_HEIGHT = 80;
        private DataSet myDataSet;

        private void Form5_Load(object sender, EventArgs e)
        {
            DataGridView1.AutoGenerateColumns = false;
            Padding newPadding = new Padding(0, 1, 0, CUSTOM_CONTENT_HEIGHT);
            this.DataGridView1.RowTemplate.DefaultCellStyle.Padding = newPadding;

            //this.DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.Transparent;

            this.DataGridView1.RowTemplate.Height += CUSTOM_CONTENT_HEIGHT;

            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            this.DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.DataGridView1.DataSource = GetData();
            //this.DataGridView1.Refresh();
            //myDataSet = LoadDataToDataSet();

            //if (myDataSet != null)
            //{
            //    //// 将 BindingSource 组件系结至数据集对象中的「飞狐工作室」数据表。
            //    //this.BindingSource1.DataMember = "飞狐工作室";
            //    //this.BindingSource1.DataSource = myDataSet;

            //    //this.BindingSource1.AllowNew = false;

            //    //// 将 BindingNavigator 控件的数据来源也设定成 BindingSource 组件
            //    ////，如此一来，就可以使用 BindingNavigator 控件去导览
            //    //// DataGridView 控件中的数据列。
            //    //this.BindingNavigator1.BindingSource = this.BindingSource1;

            //    this.DataGridView1.DataSource = GetData();
            //}
            //else
            //{
            //    return;
            //}

            //this.DataGridView1.Columns[4].Visible = false;

            this.DataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.DataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.DataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

            this.DataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

        private void DataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            this.DataGridView1.Invalidate();
        }

        private void DataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (oldRowIndex != -1)
            {
                this.DataGridView1.InvalidateRow(oldRowIndex);
            }

            oldRowIndex = this.DataGridView1.CurrentCellAddress.Y;
        }

        private void DataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts = e.PaintParts & (~DataGridViewPaintParts.Focus);

            if ((e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected)
            {
                Rectangle rowBounds = new Rectangle(this.DataGridView1.RowHeadersWidth, e.RowBounds.Top, this.DataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) - this.DataGridView1.HorizontalScrollingOffset + 1, e.RowBounds.Height);

                System.Drawing.Drawing2D.LinearGradientBrush backbrush = new System.Drawing.Drawing2D.LinearGradientBrush(rowBounds, this.DataGridView1.DefaultCellStyle.SelectionBackColor, e.InheritedRowStyle.SelectionBackColor, System.Drawing.Drawing2D.LinearGradientMode.Horizontal);

                try
                {
                    e.Graphics.FillRectangle(backbrush, rowBounds);
                }
                finally
                {
                    backbrush.Dispose();
                }
            }
        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rowBounds = new Rectangle(this.DataGridView1.RowHeadersWidth, e.RowBounds.Top, this.DataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) - this.DataGridView1.HorizontalScrollingOffset + 1, e.RowBounds.Height);

            SolidBrush forebrush = null;

            try
            {
                if ((e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected)
                {
                    forebrush = new SolidBrush(e.InheritedRowStyle.SelectionForeColor);
                }
                else
                {
                    forebrush = new SolidBrush(e.InheritedRowStyle.ForeColor);
                }

                Object recipe = this.DataGridView1.Rows.SharedRow(e.RowIndex).Cells[4].Value;

                if (!(recipe == null))
                {
                    string text = recipe.ToString();
                    Rectangle textArea = rowBounds;
                    RectangleF clip = textArea;

                    textArea.X -= this.DataGridView1.HorizontalScrollingOffset;
                    textArea.Width += this.DataGridView1.HorizontalScrollingOffset;
                    textArea.Y += rowBounds.Height - e.InheritedRowStyle.Padding.Bottom;
                    textArea.Height -= rowBounds.Height - e.InheritedRowStyle.Padding.Bottom;
                    textArea.Height = (textArea.Height / e.InheritedRowStyle.Font.Height) * e.InheritedRowStyle.Font.Height;

                    clip.Width -= this.DataGridView1.RowHeadersWidth + 1 - clip.X;
                    clip.X = this.DataGridView1.RowHeadersWidth + 1;

                    RectangleF oldClip = e.Graphics.ClipBounds;

                    e.Graphics.SetClip(clip);

                    e.Graphics.DrawString(text, e.InheritedRowStyle.Font, forebrush, textArea);
                    e.Graphics.DrawString(text, e.InheritedRowStyle.Font, forebrush,100,100);

                    e.Graphics.SetClip(oldClip);
                }
            }
            finally
            {
                forebrush.Dispose();
            }

            if (this.DataGridView1.CurrentCellAddress.Y == e.RowIndex)
            {
                e.DrawFocus(rowBounds, true);
            }
        }

        private void DataGridView1_RowHeightChanged(object sender, DataGridViewRowEventArgs e)
        {
            int preferredNormalContentHeight = e.Row.GetPreferredHeight(e.Row.Index, DataGridViewAutoSizeRowMode.AllCellsExceptHeader, true) - e.Row.DefaultCellStyle.Padding.Bottom;

            Padding newPadding = e.Row.DefaultCellStyle.Padding;

            newPadding.Bottom = e.Row.Height - preferredNormalContentHeight;
            e.Row.DefaultCellStyle.Padding = newPadding;
        }

        // 本程序会连接至数据来源并建立所需的 DataSet 对象。
        private DataSet LoadDataToDataSet()
        {
            // 利用 SqlConnectionStringBuilder 对象来构建连接字符串。
            SqlConnectionStringBuilder sqlStringBuilder =
                new SqlConnectionStringBuilder();

            sqlStringBuilder.DataSource = @"(local)\SQLEXPRESS";
            sqlStringBuilder.InitialCatalog = "北风贸易";
            sqlStringBuilder.IntegratedSecurity = true;

            // 建立一个数据集。
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection northwindConnection =
                    new SqlConnection(sqlStringBuilder.ConnectionString))
                {
                    SqlCommand cmdLiming = new SqlCommand(
                      "SELECT 姓名,员工性别,出生日期, 目前薪资, 自传" +
                      " FROM dbo.飞狐工作室 WHERE 自传 IS NOT NULL",
                      northwindConnection);

                    northwindConnection.Open();

                    using (SqlDataReader drLiming = cmdLiming.ExecuteReader())
                    {
                        ds.Load(
                          drLiming,
                          LoadOption.OverwriteChanges,
                          new string[] { "飞狐工作室" });
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "要能够顺利执行本范例程序，您的计算机必须已安装 SQL Server " +
                    "Express，并且必须已附加了本书所附的「北风贸易」数据库。" +
                    "关于如何安装 SQL Server Express，请参阅附录或相关文件说明。");

                // 无法连接至 SQL Server。
                return null;
            }

            return ds;
        }

        private List<Test> GetData()
        {
            List<Test> lst = new List<Test>();
            lst.Add(new Test("V1", "V1", "col3", "col4", "col5"));
            lst.Add(new Test("V1", "V1", "col3", "col4", "col5"));
            lst.Add(new Test("V1", "V1", "col3", "col4", "col5"));
            lst.Add(new Test("V1", "V1", "col3", "col4", "col5"));
            lst.Add(new Test("V1", "V1", "col3", "col4", "col5"));
            lst.Add(new Test("V1", "V1", "col3", "col4", "col5"));
            return lst;
        }

        public class Test
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Column3 { get; set; }
            public string Column4 { get; set; }
            public string Column5 { get; set; }

            public Test()
            {

            }

            public Test(string name, string desc, string col3, string col4, string col5)
            {
                Name = name;
                Description = desc;
                Column3 = col3;
                Column4 = col4;
                Column5 = col5;
            }
        }

        private Color _Color1 = Color.Red;
        private Color _Color2 = Color.White;
        private float _ColorAngle = 0f;
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Getting the graphics object
            Graphics g = e.Graphics;

            // Creating the rectangle for the gradient
            Rectangle rBackground = new Rectangle(0, 0, this.Width, this.Height);

            // Creating the lineargradient
            System.Drawing.Drawing2D.LinearGradientBrush bBackground
                = new System.Drawing.Drawing2D.LinearGradientBrush(rBackground, _Color1, _Color2, _ColorAngle);

            // Draw the gradient onto the form
            g.FillRectangle(bBackground, rBackground);

            // Disposing of the resources held by the brush
            bBackground.Dispose();

            //base.OnPaintBackground(e);
        }
    }
}
