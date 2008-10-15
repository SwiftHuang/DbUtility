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
namespace WongTung.Web.backspecial
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
	if(this.txtBS_CO_CODE.Text =="")
	{
		strErr+="BS_CO_CODE不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtBS_DATE.Text))
	{
	strErr+="BS_DATE不是时间格式！\\n";	
	}
	if(!PageValidate.IsDateTime(txtBS_CURDATE.Text))
	{
	strErr+="BS_CURDATE不是时间格式！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string BS_CO_CODE=this.txtBS_CO_CODE.Text;
	DateTime BS_DATE=DateTime.Parse(this.txtBS_DATE.Text);
	DateTime BS_CURDATE=DateTime.Parse(this.txtBS_CURDATE.Text);

	WongTung.Model.backspecial model=new WongTung.Model.backspecial();
	model.BS_CO_CODE=BS_CO_CODE;
	model.BS_DATE=BS_DATE;
	model.BS_CURDATE=BS_CURDATE;

	WongTung.BLL.backspecial bll=new WongTung.BLL.backspecial();
	bll.Add(model);

		}

    }
}
