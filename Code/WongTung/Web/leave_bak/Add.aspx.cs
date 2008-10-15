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
namespace WongTung.Web.leave_bak
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
	if(this.txtCO_CODE.Text =="")
	{
		strErr+="CO_CODE不能为空！\\n";	
	}
	if(this.txtLEVAE_CODE.Text =="")
	{
		strErr+="LEVAE_CODE不能为空！\\n";	
	}
	if(this.txtLEVAE_DESC.Text =="")
	{
		strErr+="LEVAE_DESC不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string CO_CODE=this.txtCO_CODE.Text;
	string LEVAE_CODE=this.txtLEVAE_CODE.Text;
	string LEVAE_DESC=this.txtLEVAE_DESC.Text;

	WongTung.Model.leave_bak model=new WongTung.Model.leave_bak();
	model.CO_CODE=CO_CODE;
	model.LEVAE_CODE=LEVAE_CODE;
	model.LEVAE_DESC=LEVAE_DESC;

	WongTung.BLL.leave_bak bll=new WongTung.BLL.leave_bak();
	bll.Add(model);

		}

    }
}
