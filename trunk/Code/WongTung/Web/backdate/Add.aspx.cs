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
namespace WongTung.Web.backdate
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
	if(this.txtBK_CO_CODE.Text =="")
	{
		strErr+="BK_CO_CODE不能为空！\\n";	
	}
	if(this.txtBK_USER.Text =="")
	{
		strErr+="BK_USER不能为空！\\n";	
	}
	if(this.txtBK_RAN_NO.Text =="")
	{
		strErr+="BK_RAN_NO不能为空！\\n";	
	}
	if(this.txtBK_EMP.Text =="")
	{
		strErr+="BK_EMP不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtBK_RAN_DATE.Text))
	{
	strErr+="BK_RAN_DATE不是时间格式！\\n";	
	}
	if(!PageValidate.IsDateTime(txtBK_CRE_DATE.Text))
	{
	strErr+="BK_CRE_DATE不是时间格式！\\n";	
	}
	if(this.txtBK_STATUS.Text =="")
	{
		strErr+="BK_STATUS不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string BK_CO_CODE=this.txtBK_CO_CODE.Text;
	string BK_USER=this.txtBK_USER.Text;
	string BK_RAN_NO=this.txtBK_RAN_NO.Text;
	string BK_EMP=this.txtBK_EMP.Text;
	DateTime BK_RAN_DATE=DateTime.Parse(this.txtBK_RAN_DATE.Text);
	DateTime BK_CRE_DATE=DateTime.Parse(this.txtBK_CRE_DATE.Text);
	string BK_STATUS=this.txtBK_STATUS.Text;

	WongTung.Model.backdate model=new WongTung.Model.backdate();
	model.BK_CO_CODE=BK_CO_CODE;
	model.BK_USER=BK_USER;
	model.BK_RAN_NO=BK_RAN_NO;
	model.BK_EMP=BK_EMP;
	model.BK_RAN_DATE=BK_RAN_DATE;
	model.BK_CRE_DATE=BK_CRE_DATE;
	model.BK_STATUS=BK_STATUS;

	WongTung.BLL.backdate bll=new WongTung.BLL.backdate();
	bll.Add(model);

		}

    }
}
