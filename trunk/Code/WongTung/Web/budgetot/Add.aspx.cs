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
namespace WongTung.Web.budgetot
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
	if(this.txtBG_CO_CODE.Text =="")
	{
		strErr+="BG_CO_CODE不能为空！\\n";	
	}
	if(this.txtBG_JOB_CODE.Text =="")
	{
		strErr+="BG_JOB_CODE不能为空！\\n";	
	}
	if(this.txtBG_SER_CODE.Text =="")
	{
		strErr+="BG_SER_CODE不能为空！\\n";	
	}
	if(this.txtBG_POS.Text =="")
	{
		strErr+="BG_POS不能为空！\\n";	
	}
	if(!PageValidate.IsDecimal(txtBG_HOUR.Text))
	{
		strErr+="BG_HOUR不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtBG_EXP_BUDGET.Text))
	{
		strErr+="BG_EXP_BUDGET不是数字！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string BG_CO_CODE=this.txtBG_CO_CODE.Text;
	string BG_JOB_CODE=this.txtBG_JOB_CODE.Text;
	string BG_SER_CODE=this.txtBG_SER_CODE.Text;
	string BG_POS=this.txtBG_POS.Text;
	decimal BG_HOUR=decimal.Parse(this.txtBG_HOUR.Text);
	decimal BG_EXP_BUDGET=decimal.Parse(this.txtBG_EXP_BUDGET.Text);

	WongTung.Model.budgetot model=new WongTung.Model.budgetot();
	model.BG_CO_CODE=BG_CO_CODE;
	model.BG_JOB_CODE=BG_JOB_CODE;
	model.BG_SER_CODE=BG_SER_CODE;
	model.BG_POS=BG_POS;
	model.BG_HOUR=BG_HOUR;
	model.BG_EXP_BUDGET=BG_EXP_BUDGET;

	WongTung.BLL.budgetot bll=new WongTung.BLL.budgetot();
	bll.Add(model);

		}

    }
}
