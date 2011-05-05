using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test.DemoFrm
{
    public partial class DragFrm : Form
    {
        public DragFrm()
        {
            InitializeComponent();
        }

        private void DragFrm_Load(object sender, EventArgs e)
        {
            List<string> strList = new List<string>();

            for (int i = 0; i < 20; i++)
            {
                strList.Add(string.Format("Vin-{0}", i));
            }

            listBox1.DataSource = strList;
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            DragDropEffects d = DoDragDrop(listBox1.Items[listBox1.IndexFromPoint(e.X, e.Y)], DragDropEffects.Copy);
        }

        private void DragFrm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void DragFrm_DragDrop(object sender, DragEventArgs e)
        {
            if (e.AllowedEffect == DragDropEffects.All)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }
        private void listView1_DragDrop(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.StringFormat) && e.AllowedEffect == DragDropEffects.Copy)
            {
                listView1.Items.Add(new ListViewItem((String)e.Data.GetData(DataFormats.StringFormat)));
                //Button btn = new Button();
                //btn.Name = (String)e.Data.GetData(DataFormats.StringFormat);
                //btn.Text = btn.Name;
                //listView1.Controls.Add(btn);
            }
        }



        private void listView1_DragLeave(object sender, EventArgs e)
        {
            //if (listView1.SelectedItems.Count > 0)
            //{
            //    //DragDropEffects d = DoDragDrop(listView1.SelectedItems[0].Text, DragDropEffects.All);

            //    //if (d == DragDropEffects.All)
            //    //{
            //    listView1.Items.Remove(listView1.SelectedItems[0]);
            //    //}
            //}
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                DragDropEffects d = DoDragDrop(listView1.SelectedItems[0].Text, DragDropEffects.All);
            }
        }




        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {

        }
    }
}
