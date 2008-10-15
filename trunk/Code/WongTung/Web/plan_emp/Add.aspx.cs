using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using LTP.Common;
namespace WongTung.Web.plan_emp
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "信息添加";
		}
		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(!PageValidate.IsNumber(txtPLA_EMP_NUM.Text))
	{
		strErr+="PLA_EMP_NUM不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPLA_EMP_NOR.Text))
	{
		strErr+="PLA_EMP_NOR不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPLA_EMP_OT1.Text))
	{
		strErr+="PLA_EMP_OT1不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPLA_EMP_OT2.Text))
	{
		strErr+="PLA_EMP_OT2不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPLA_EMP_OT3.Text))
	{
		strErr+="PLA_EMP_OT3不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPLA_EMP_T1.Text))
	{
		strErr+="PLA_EMP_T1不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPLA_EMP_T2.Text))
	{
		strErr+="PLA_EMP_T2不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPLA_EMP_T3.Text))
	{
		strErr+="PLA_EMP_T3不是数字！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	int PLA_EMP_NUM=int.Parse(this.txtPLA_EMP_NUM.Text);
	decimal PLA_EMP_NOR=decimal.Parse(this.txtPLA_EMP_NOR.Text);
	decimal PLA_EMP_OT1=decimal.Parse(this.txtPLA_EMP_OT1.Text);
	decimal PLA_EMP_OT2=decimal.Parse(this.txtPLA_EMP_OT2.Text);
	decimal PLA_EMP_OT3=decimal.Parse(this.txtPLA_EMP_OT3.Text);
	decimal PLA_EMP_T1=decimal.Parse(this.txtPLA_EMP_T1.Text);
	decimal PLA_EMP_T2=decimal.Parse(this.txtPLA_EMP_T2.Text);
	decimal PLA_EMP_T3=decimal.Parse(this.txtPLA_EMP_T3.Text);

	WongTung.Model.plan_emp model=new WongTung.Model.plan_emp();
	model.PLA_EMP_NUM=PLA_EMP_NUM;
	model.PLA_EMP_NOR=PLA_EMP_NOR;
	model.PLA_EMP_OT1=PLA_EMP_OT1;
	model.PLA_EMP_OT2=PLA_EMP_OT2;
	model.PLA_EMP_OT3=PLA_EMP_OT3;
	model.PLA_EMP_T1=PLA_EMP_T1;
	model.PLA_EMP_T2=PLA_EMP_T2;
	model.PLA_EMP_T3=PLA_EMP_T3;

	WongTung.BLL.plan_emp bll=new WongTung.BLL.plan_emp();
	bll.Add(model);

		}

    }
}
