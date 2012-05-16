using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.xSplitContainer1.SplitterMoved -= new SplitterEventHandler(xSplitContainer1_SplitterMoved);
        }

        void xSplitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
