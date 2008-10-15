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
namespace WongTung.Web.jobbud
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
	if(this.txtJOB_STAFF.Text =="")
	{
		strErr+="JOB_STAFF不能为空！\\n";	
	}
	if(!PageValidate.IsDecimal(txtJOB_BUD.Text))
	{
		strErr+="JOB_BUD不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtJOB_NOR.Text))
	{
		strErr+="JOB_NOR不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtJOB_NOR_EXP.Text))
	{
		strErr+="JOB_NOR_EXP不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtJOB_OT.Text))
	{
		strErr+="JOB_OT不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtJOB_OT_EXP.Text))
	{
		strErr+="JOB_OT_EXP不是数字！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string JOB_STAFF=this.txtJOB_STAFF.Text;
	decimal JOB_BUD=decimal.Parse(this.txtJOB_BUD.Text);
	decimal JOB_NOR=decimal.Parse(this.txtJOB_NOR.Text);
	decimal JOB_NOR_EXP=decimal.Parse(this.txtJOB_NOR_EXP.Text);
	decimal JOB_OT=decimal.Parse(this.txtJOB_OT.Text);
	decimal JOB_OT_EXP=decimal.Parse(this.txtJOB_OT_EXP.Text);

	WongTung.Model.jobbud model=new WongTung.Model.jobbud();
	model.JOB_STAFF=JOB_STAFF;
	model.JOB_BUD=JOB_BUD;
	model.JOB_NOR=JOB_NOR;
	model.JOB_NOR_EXP=JOB_NOR_EXP;
	model.JOB_OT=JOB_OT;
	model.JOB_OT_EXP=JOB_OT_EXP;

	WongTung.BLL.jobbud bll=new WongTung.BLL.jobbud();
	bll.Add(model);

		}

    }
}
