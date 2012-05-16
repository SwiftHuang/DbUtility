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
    public partial class Form1 : Form
    {
        hwj.UserControls.Function.Verify.ValueChangedHandle ValueChanged = new hwj.UserControls.Function.Verify.ValueChangedHandle();
        public Form1()
        {
            InitializeComponent();
            ValueChanged.ClearCheckObject();
            ValueChanged.SetCheckObject();
            xTextBox2.InvalidPasswordChar = new List<char> { ' ', '1' };

            ValueChanged.xValueChanged += new EventHandler(ValueChanged_xValueChanged);
        }

        void ValueChanged_xValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Changed");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hwj.UserControls.Suggest.SuggestList list = new hwj.UserControls.Suggest.SuggestList();

            for (int i = 0; i < 100; i++)
            {
                hwj.UserControls.Suggest.SuggestValue v = new hwj.UserControls.Suggest.SuggestValue();
                v.Key = i.ToString();
                v.PrimaryValue = i.ToString();
                v.SecondValue = i.ToString();
                list.Add(v);
            }

            suggestBox1.DataList = list;
        }

        private void maskedDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            xTextBox1.Text = maskedDateTimePicker1.Value.ToString();
        }

        private void xButton1_Click(object sender, EventArgs e)
        {
            ValueChanged.IsChanged = false;
            xTextBox1.ValueChangedEnabled = false;


        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }
    }
}
