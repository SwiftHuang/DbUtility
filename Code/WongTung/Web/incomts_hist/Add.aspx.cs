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
namespace WongTung.Web.incomts_hist
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
	if(this.txtIST_CO_CODE.Text =="")
	{
		strErr+="IST_CO_CODE不能为空！\\n";	
	}
	if(this.txtIST_OFFICE_CODE.Text =="")
	{
		strErr+="IST_OFFICE_CODE不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtIST_WORK_DATE.Text))
	{
	strErr+="IST_WORK_DATE不是时间格式！\\n";	
	}
	if(this.txtIST_USER_CODE.Text =="")
	{
		strErr+="IST_USER_CODE不能为空！\\n";	
	}
	if(this.txtIST_USER_NAME.Text =="")
	{
		strErr+="IST_USER_NAME不能为空！\\n";	
	}
	if(this.txtIST_INPUT_OK.Text =="")
	{
		strErr+="IST_INPUT_OK不能为空！\\n";	
	}
	if(this.txtIST_APP.Text =="")
	{
		strErr+="IST_APP不能为空！\\n";	
	}
	if(!PageValidate.IsDecimal(txtIST_NOR_HR.Text))
	{
		strErr+="IST_NOR_HR不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtIST_OT_HR.Text))
	{
		strErr+="IST_OT_HR不是数字！\\n";	
	}
	if(this.txtIST_PERIOD.Text =="")
	{
		strErr+="IST_PERIOD不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string IST_CO_CODE=this.txtIST_CO_CODE.Text;
	string IST_OFFICE_CODE=this.txtIST_OFFICE_CODE.Text;
	DateTime IST_WORK_DATE=DateTime.Parse(this.txtIST_WORK_DATE.Text);
	string IST_USER_CODE=this.txtIST_USER_CODE.Text;
	string IST_USER_NAME=this.txtIST_USER_NAME.Text;
	string IST_INPUT_OK=this.txtIST_INPUT_OK.Text;
	string IST_APP=this.txtIST_APP.Text;
	decimal IST_NOR_HR=decimal.Parse(this.txtIST_NOR_HR.Text);
	decimal IST_OT_HR=decimal.Parse(this.txtIST_OT_HR.Text);
	string IST_PERIOD=this.txtIST_PERIOD.Text;

	WongTung.Model.incomts_hist model=new WongTung.Model.incomts_hist();
	model.IST_CO_CODE=IST_CO_CODE;
	model.IST_OFFICE_CODE=IST_OFFICE_CODE;
	model.IST_WORK_DATE=IST_WORK_DATE;
	model.IST_USER_CODE=IST_USER_CODE;
	model.IST_USER_NAME=IST_USER_NAME;
	model.IST_INPUT_OK=IST_INPUT_OK;
	model.IST_APP=IST_APP;
	model.IST_NOR_HR=IST_NOR_HR;
	model.IST_OT_HR=IST_OT_HR;
	model.IST_PERIOD=IST_PERIOD;

	WongTung.BLL.incomts_hist bll=new WongTung.BLL.incomts_hist();
	bll.Add(model);

		}

    }
}
