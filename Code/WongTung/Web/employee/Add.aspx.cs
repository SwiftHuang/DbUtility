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
namespace WongTung.Web.employee
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
	if(this.txtEMP_CO_CODE.Text =="")
	{
		strErr+="EMP_CO_CODE不能为空！\\n";	
	}
	if(this.txtEMP_NAME.Text =="")
	{
		strErr+="EMP_NAME不能为空！\\n";	
	}
	if(this.txtEMP_POS_CODE.Text =="")
	{
		strErr+="EMP_POS_CODE不能为空！\\n";	
	}
	if(this.txtEMP_DEP_CODE.Text =="")
	{
		strErr+="EMP_DEP_CODE不能为空！\\n";	
	}
	if(this.txtEMP_INITIAL.Text =="")
	{
		strErr+="EMP_INITIAL不能为空！\\n";	
	}
	if(this.txtEMP_OFFICE.Text =="")
	{
		strErr+="EMP_OFFICE不能为空！\\n";	
	}
	if(this.txtEMP_CHNAME.Text =="")
	{
		strErr+="EMP_CHNAME不能为空！\\n";	
	}
	if(this.txtEMP_SPE.Text =="")
	{
		strErr+="EMP_SPE不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtEMP_CRE_DATE.Text))
	{
	strErr+="EMP_CRE_DATE不是时间格式！\\n";	
	}
	if(this.txtEMP_DEL.Text =="")
	{
		strErr+="EMP_DEL不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string EMP_CO_CODE=this.txtEMP_CO_CODE.Text;
	string EMP_NAME=this.txtEMP_NAME.Text;
	string EMP_POS_CODE=this.txtEMP_POS_CODE.Text;
	string EMP_DEP_CODE=this.txtEMP_DEP_CODE.Text;
	string EMP_INITIAL=this.txtEMP_INITIAL.Text;
	string EMP_OFFICE=this.txtEMP_OFFICE.Text;
	string EMP_CHNAME=this.txtEMP_CHNAME.Text;
	string EMP_SPE=this.txtEMP_SPE.Text;
	DateTime EMP_CRE_DATE=DateTime.Parse(this.txtEMP_CRE_DATE.Text);
	string EMP_DEL=this.txtEMP_DEL.Text;

	WongTung.Model.employee model=new WongTung.Model.employee();
	model.EMP_CO_CODE=EMP_CO_CODE;
	model.EMP_NAME=EMP_NAME;
	model.EMP_POS_CODE=EMP_POS_CODE;
	model.EMP_DEP_CODE=EMP_DEP_CODE;
	model.EMP_INITIAL=EMP_INITIAL;
	model.EMP_OFFICE=EMP_OFFICE;
	model.EMP_CHNAME=EMP_CHNAME;
	model.EMP_SPE=EMP_SPE;
	model.EMP_CRE_DATE=EMP_CRE_DATE;
	model.EMP_DEL=EMP_DEL;

	WongTung.BLL.employee bll=new WongTung.BLL.employee();
	bll.Add(model);

		}

    }
}
