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
namespace WongTung.Web.prriod
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
	if(this.txtPR_CO_CODE.Text =="")
	{
		strErr+="PR_CO_CODE不能为空！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPR_NO.Text))
	{
		strErr+="PR_NO不是数字！\\n";	
	}
	if(this.txtPR_FROM.Text =="")
	{
		strErr+="PR_FROM不能为空！\\n";	
	}
	if(this.txtPR_TO.Text =="")
	{
		strErr+="PR_TO不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string PR_CO_CODE=this.txtPR_CO_CODE.Text;
	decimal PR_NO=decimal.Parse(this.txtPR_NO.Text);
	string PR_FROM=this.txtPR_FROM.Text;
	string PR_TO=this.txtPR_TO.Text;

	WongTung.Model.prriod model=new WongTung.Model.prriod();
	model.PR_CO_CODE=PR_CO_CODE;
	model.PR_NO=PR_NO;
	model.PR_FROM=PR_FROM;
	model.PR_TO=PR_TO;

	WongTung.BLL.prriod bll=new WongTung.BLL.prriod();
	bll.Add(model);

		}

    }
}
