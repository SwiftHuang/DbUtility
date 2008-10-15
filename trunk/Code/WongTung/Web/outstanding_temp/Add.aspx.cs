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
namespace WongTung.Web.outstanding_temp
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
	if(this.txtOUT_OFF_CODE.Text =="")
	{
		strErr+="OUT_OFF_CODE不能为空！\\n";	
	}
	if(this.txtOUT_OFF_NAME.Text =="")
	{
		strErr+="OUT_OFF_NAME不能为空！\\n";	
	}
	if(this.txtOUT_EMP_CODE.Text =="")
	{
		strErr+="OUT_EMP_CODE不能为空！\\n";	
	}
	if(this.txtOUT_EMP_NAME.Text =="")
	{
		strErr+="OUT_EMP_NAME不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtOUT_DAY.Text))
	{
	strErr+="OUT_DAY不是时间格式！\\n";	
	}
	if(!PageValidate.IsDecimal(txtOUT_POS_CLASS.Text))
	{
		strErr+="OUT_POS_CLASS不是数字！\\n";	
	}
	if(this.txtOUT_POS_CODE.Text =="")
	{
		strErr+="OUT_POS_CODE不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtOUT_UPDATE_DATE.Text))
	{
	strErr+="OUT_UPDATE_DATE不是时间格式！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string OUT_OFF_CODE=this.txtOUT_OFF_CODE.Text;
	string OUT_OFF_NAME=this.txtOUT_OFF_NAME.Text;
	string OUT_EMP_CODE=this.txtOUT_EMP_CODE.Text;
	string OUT_EMP_NAME=this.txtOUT_EMP_NAME.Text;
	DateTime OUT_DAY=DateTime.Parse(this.txtOUT_DAY.Text);
	decimal OUT_POS_CLASS=decimal.Parse(this.txtOUT_POS_CLASS.Text);
	string OUT_POS_CODE=this.txtOUT_POS_CODE.Text;
	DateTime OUT_UPDATE_DATE=DateTime.Parse(this.txtOUT_UPDATE_DATE.Text);

	WongTung.Model.outstanding_temp model=new WongTung.Model.outstanding_temp();
	model.OUT_OFF_CODE=OUT_OFF_CODE;
	model.OUT_OFF_NAME=OUT_OFF_NAME;
	model.OUT_EMP_CODE=OUT_EMP_CODE;
	model.OUT_EMP_NAME=OUT_EMP_NAME;
	model.OUT_DAY=OUT_DAY;
	model.OUT_POS_CLASS=OUT_POS_CLASS;
	model.OUT_POS_CODE=OUT_POS_CODE;
	model.OUT_UPDATE_DATE=OUT_UPDATE_DATE;

	WongTung.BLL.outstanding_temp bll=new WongTung.BLL.outstanding_temp();
	bll.Add(model);

		}

    }
}
