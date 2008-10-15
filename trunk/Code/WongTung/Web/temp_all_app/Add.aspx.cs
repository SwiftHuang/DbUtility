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
namespace WongTung.Web.temp_all_app
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
	if(this.txtTEM_CO_CODE.Text =="")
	{
		strErr+="TEM_CO_CODE不能为空！\\n";	
	}
	if(this.txtTEM_STAFF_CODE.Text =="")
	{
		strErr+="TEM_STAFF_CODE不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtTEM_WORK_DATE.Text))
	{
	strErr+="TEM_WORK_DATE不是时间格式！\\n";	
	}
	if(!PageValidate.IsNumber(txtTEM_LINE_NO.Text))
	{
		strErr+="TEM_LINE_NO不是数字！\\n";	
	}
	if(this.txtTEM_HOUR_TYPE.Text =="")
	{
		strErr+="TEM_HOUR_TYPE不能为空！\\n";	
	}
	if(this.txtTEM_APP_CODE.Text =="")
	{
		strErr+="TEM_APP_CODE不能为空！\\n";	
	}
	if(this.txtTEM_SER_CODE.Text =="")
	{
		strErr+="TEM_SER_CODE不能为空！\\n";	
	}
	if(this.txtTEM_JOB_CODE.Text =="")
	{
		strErr+="TEM_JOB_CODE不能为空！\\n";	
	}
	if(!PageValidate.IsDecimal(txtTEM_BF_SUM.Text))
	{
		strErr+="TEM_BF_SUM不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtTEM_NOR_HOUR_0.Text))
	{
		strErr+="TEM_NOR_HOUR_0不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtTEM_NOR_HOUR_1.Text))
	{
		strErr+="TEM_NOR_HOUR_1不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtTEM_NOR_HOUR_2.Text))
	{
		strErr+="TEM_NOR_HOUR_2不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtTEM_NOR_HOUR_3.Text))
	{
		strErr+="TEM_NOR_HOUR_3不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtTEM_NOR_HOUR_4.Text))
	{
		strErr+="TEM_NOR_HOUR_4不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtTEM_NOR_HOUR_5.Text))
	{
		strErr+="TEM_NOR_HOUR_5不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtTEM_NOR_HOUR_6.Text))
	{
		strErr+="TEM_NOR_HOUR_6不是数字！\\n";	
	}
	if(this.txtTEM_TYPE.Text =="")
	{
		strErr+="TEM_TYPE不能为空！\\n";	
	}
	if(this.txtTEM_APP_FLAG.Text =="")
	{
		strErr+="TEM_APP_FLAG不能为空！\\n";	
	}
	if(this.txtTEM_QUE.Text =="")
	{
		strErr+="TEM_QUE不能为空！\\n";	
	}
	if(this.txtTEM_POS_CODE.Text =="")
	{
		strErr+="TEM_POS_CODE不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string TEM_CO_CODE=this.txtTEM_CO_CODE.Text;
	string TEM_STAFF_CODE=this.txtTEM_STAFF_CODE.Text;
	DateTime TEM_WORK_DATE=DateTime.Parse(this.txtTEM_WORK_DATE.Text);
	int TEM_LINE_NO=int.Parse(this.txtTEM_LINE_NO.Text);
	string TEM_HOUR_TYPE=this.txtTEM_HOUR_TYPE.Text;
	string TEM_APP_CODE=this.txtTEM_APP_CODE.Text;
	string TEM_SER_CODE=this.txtTEM_SER_CODE.Text;
	string TEM_JOB_CODE=this.txtTEM_JOB_CODE.Text;
	decimal TEM_BF_SUM=decimal.Parse(this.txtTEM_BF_SUM.Text);
	decimal TEM_NOR_HOUR_0=decimal.Parse(this.txtTEM_NOR_HOUR_0.Text);
	decimal TEM_NOR_HOUR_1=decimal.Parse(this.txtTEM_NOR_HOUR_1.Text);
	decimal TEM_NOR_HOUR_2=decimal.Parse(this.txtTEM_NOR_HOUR_2.Text);
	decimal TEM_NOR_HOUR_3=decimal.Parse(this.txtTEM_NOR_HOUR_3.Text);
	decimal TEM_NOR_HOUR_4=decimal.Parse(this.txtTEM_NOR_HOUR_4.Text);
	decimal TEM_NOR_HOUR_5=decimal.Parse(this.txtTEM_NOR_HOUR_5.Text);
	decimal TEM_NOR_HOUR_6=decimal.Parse(this.txtTEM_NOR_HOUR_6.Text);
	string TEM_TYPE=this.txtTEM_TYPE.Text;
	string TEM_APP_FLAG=this.txtTEM_APP_FLAG.Text;
	string TEM_QUE=this.txtTEM_QUE.Text;
	string TEM_POS_CODE=this.txtTEM_POS_CODE.Text;

	WongTung.Model.temp_all_app model=new WongTung.Model.temp_all_app();
	model.TEM_CO_CODE=TEM_CO_CODE;
	model.TEM_STAFF_CODE=TEM_STAFF_CODE;
	model.TEM_WORK_DATE=TEM_WORK_DATE;
	model.TEM_LINE_NO=TEM_LINE_NO;
	model.TEM_HOUR_TYPE=TEM_HOUR_TYPE;
	model.TEM_APP_CODE=TEM_APP_CODE;
	model.TEM_SER_CODE=TEM_SER_CODE;
	model.TEM_JOB_CODE=TEM_JOB_CODE;
	model.TEM_BF_SUM=TEM_BF_SUM;
	model.TEM_NOR_HOUR_0=TEM_NOR_HOUR_0;
	model.TEM_NOR_HOUR_1=TEM_NOR_HOUR_1;
	model.TEM_NOR_HOUR_2=TEM_NOR_HOUR_2;
	model.TEM_NOR_HOUR_3=TEM_NOR_HOUR_3;
	model.TEM_NOR_HOUR_4=TEM_NOR_HOUR_4;
	model.TEM_NOR_HOUR_5=TEM_NOR_HOUR_5;
	model.TEM_NOR_HOUR_6=TEM_NOR_HOUR_6;
	model.TEM_TYPE=TEM_TYPE;
	model.TEM_APP_FLAG=TEM_APP_FLAG;
	model.TEM_QUE=TEM_QUE;
	model.TEM_POS_CODE=TEM_POS_CODE;

	WongTung.BLL.temp_all_app bll=new WongTung.BLL.temp_all_app();
	bll.Add(model);

		}

    }
}
