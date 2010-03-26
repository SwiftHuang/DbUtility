using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace hwj.MarkTableObject.Forms
{
    public partial class GeneralFrm : Form
    {
        public Entity.ProjectInfo ProjectInfo { get; set; }
        public List<string> TableList { get; set; }
        public List<string> ViewList { get; set; }
        public GeneralFrm()
        {
            InitializeComponent();
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            if (ProjectInfo != null)
            {
                foreach (string s in TableList)
                {
                    BLL.BuilderEntity.CreateTableFile(ProjectInfo, s);
                }
            }
        }


    }
}
