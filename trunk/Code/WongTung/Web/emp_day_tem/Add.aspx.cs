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
namespace WongTung.Web.emp_day_tem
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
	if(this.txtED_JS_1.Text =="")
	{
		strErr+="ED_JS_1不能为空！\\n";	
	}
	if(this.txtED_JS_2.Text =="")
	{
		strErr+="ED_JS_2不能为空！\\n";	
	}
	if(this.txtED_JS_3.Text =="")
	{
		strErr+="ED_JS_3不能为空！\\n";	
	}
	if(this.txtED_JS_4.Text =="")
	{
		strErr+="ED_JS_4不能为空！\\n";	
	}
	if(this.txtED_JS_5.Text =="")
	{
		strErr+="ED_JS_5不能为空！\\n";	
	}
	if(this.txtED_JS_6.Text =="")
	{
		strErr+="ED_JS_6不能为空！\\n";	
	}
	if(this.txtED_JS_7.Text =="")
	{
		strErr+="ED_JS_7不能为空！\\n";	
	}
	if(this.txtED_JS_8.Text =="")
	{
		strErr+="ED_JS_8不能为空！\\n";	
	}
	if(this.txtED_JS_9.Text =="")
	{
		strErr+="ED_JS_9不能为空！\\n";	
	}
	if(this.txtED_JS_10.Text =="")
	{
		strErr+="ED_JS_10不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string ED_JS_1=this.txtED_JS_1.Text;
	string ED_JS_2=this.txtED_JS_2.Text;
	string ED_JS_3=this.txtED_JS_3.Text;
	string ED_JS_4=this.txtED_JS_4.Text;
	string ED_JS_5=this.txtED_JS_5.Text;
	string ED_JS_6=this.txtED_JS_6.Text;
	string ED_JS_7=this.txtED_JS_7.Text;
	string ED_JS_8=this.txtED_JS_8.Text;
	string ED_JS_9=this.txtED_JS_9.Text;
	string ED_JS_10=this.txtED_JS_10.Text;

	WongTung.Model.emp_day_tem model=new WongTung.Model.emp_day_tem();
	model.ED_JS_1=ED_JS_1;
	model.ED_JS_2=ED_JS_2;
	model.ED_JS_3=ED_JS_3;
	model.ED_JS_4=ED_JS_4;
	model.ED_JS_5=ED_JS_5;
	model.ED_JS_6=ED_JS_6;
	model.ED_JS_7=ED_JS_7;
	model.ED_JS_8=ED_JS_8;
	model.ED_JS_9=ED_JS_9;
	model.ED_JS_10=ED_JS_10;

	WongTung.BLL.emp_day_tem bll=new WongTung.BLL.emp_day_tem();
	bll.Add(model);

		}

    }
}
