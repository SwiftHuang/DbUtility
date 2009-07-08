using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using hwj.UserControls.Suggest;
namespace Test
{
    public partial class Suggest : Form
    {
        public Suggest()
        {
            InitializeComponent();
        }

        private void suggestBox1_DataBinding(object sender, EventArgs e)
        {
            Entity.Table.tbDistricts lst = BLL.Table.BOtbDistrict.GetList(suggestBox1.Text);
            SuggestList sLst = new SuggestList();
            foreach (Entity.Table.tbDistrict c in lst)
            {
                SuggestValue v = new SuggestValue();
                v.Key = c.Code;
                v.PrimaryValue = c.Code;
                v.SecondValue = c.Name;
                sLst.Add(v);
            }
            suggestBox1.DataList = sLst;
        }

        private void Suggest_Load(object sender, EventArgs e)
        {
            page1.PerformPageChange(1, 2);
        }

        private void page1_PageIndexChanged(int index, int pageSize)
        {
            Entity.Table.tbDistrictPage p = BLL.Table.BOtbDistrict.GetPage(index, pageSize);
            xDataGridView1.DataSource = p.Result;
            page1.RecordCount = p.RecordCount;
        }
    }
}
