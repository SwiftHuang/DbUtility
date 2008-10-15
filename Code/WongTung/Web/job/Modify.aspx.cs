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
namespace WongTung.Web.job
{
    public partial class Modify : System.Web.UI.Page
    {       

        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "信息修改";
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null || Request.Params["id"].Trim() != "")
				{
					string id = Request.Params["id"];
					//ShowInfo(JOB_CODE);
				}
			}
		}
			
	private void ShowInfo(string JOB_CODE)
	{
		WongTung.BLL.job bll=new WongTung.BLL.job();
		WongTung.Model.job model=bll.GetModel(JOB_CODE);
		this.txtJOB_CO_CODE.Text=model.JOB_CO_CODE;
		this.lblJOB_CODE.Text=model.JOB_CODE;
		this.txtJOB_NAME.Text=model.JOB_NAME;
		this.txtJOB_CON.Text=model.JOB_CON.ToString();
		this.txtJOB_OPEN_BAL_HOUR.Text=model.JOB_OPEN_BAL_HOUR.ToString();
		this.txtJOB_YTD_HOUR.Text=model.JOB_YTD_HOUR.ToString();
		this.txtJOB_OPEN_BAL_AMT.Text=model.JOB_OPEN_BAL_AMT.ToString();
		this.txtJOB_YTD_AMT.Text=model.JOB_YTD_AMT.ToString();
		this.txtJOB_REC.Text=model.JOB_REC.ToString();
		this.txtJOB_OS_BAL.Text=model.JOB_OS_BAL.ToString();
		this.txtJOB_BUD_HOUR.Text=model.JOB_BUD_HOUR.ToString();
		this.txtJOB_CO_ORD.Text=model.JOB_CO_ORD.ToString();
		this.txtJOB_ADMIN.Text=model.JOB_ADMIN.ToString();
		this.txtJOB_DESIGN.Text=model.JOB_DESIGN.ToString();
		this.txtJOB_LEV1.Text=model.JOB_LEV1.ToString();
		this.txtJOB_LEV2.Text=model.JOB_LEV2.ToString();
		this.txtJOB_LEV3.Text=model.JOB_LEV3.ToString();
		this.txtJOB_CHARGE_OUT.Text=model.JOB_CHARGE_OUT.ToString();
		this.txtJOB_DAILY.Text=model.JOB_DAILY.ToString();
		this.txtJOB_MON.Text=model.JOB_MON.ToString();
		this.txtJOB_PERIOD.Text=model.JOB_PERIOD.ToString();
		this.txtJOB_PERIOD_VAL.Text=model.JOB_PERIOD_VAL.ToString();
		this.txtJOB_AUTH.Text=model.JOB_AUTH;
		this.txtJOB_OFF_INCHG_AD.Text=model.JOB_OFF_INCHG_AD;
		this.txtJOB_OFF_INCHG_DES.Text=model.JOB_OFF_INCHG_DES;
		this.txtJOB_AUTH_1.Text=model.JOB_AUTH_1;
		this.txtJOB_AUTH_2.Text=model.JOB_AUTH_2;
		this.txtJOB_AUTH_3.Text=model.JOB_AUTH_3;
		this.txtJOB_AUTH_4.Text=model.JOB_AUTH_4;
		this.txtJOB_AUTH_5.Text=model.JOB_AUTH_5;
		this.txtJOB_INDEX.Text=model.JOB_INDEX.ToString();
		this.txtJOB_NAME_S.Text=model.JOB_NAME_S;
		this.txtJOB_NAME_T.Text=model.JOB_NAME_T;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtJOB_CO_CODE.Text =="")
	{
		strErr+="JOB_CO_CODE不能为空！\\n";	
	}
	if(this.txtJOB_NAME.Text =="")
	{
		strErr+="JOB_NAME不能为空！\\n";	
	}
	if(!PageValidate.IsDecimal(txtJOB_CON.Text))
	{
		strErr+="JOB_CON不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtJOB_OPEN_BAL_HOUR.Text))
	{
		strErr+="JOB_OPEN_BAL_HOUR不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtJOB_YTD_HOUR.Text))
	{
		strErr+="JOB_YTD_HOUR不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtJOB_OPEN_BAL_AMT.Text))
	{
		strErr+="JOB_OPEN_BAL_AMT不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtJOB_YTD_AMT.Text))
	{
		strErr+="JOB_YTD_AMT不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtJOB_REC.Text))
	{
		strErr+="JOB_REC不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtJOB_OS_BAL.Text))
	{
		strErr+="JOB_OS_BAL不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtJOB_BUD_HOUR.Text))
	{
		strErr+="JOB_BUD_HOUR不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtJOB_CO_ORD.Text))
	{
		strErr+="JOB_CO_ORD不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtJOB_ADMIN.Text))
	{
		strErr+="JOB_ADMIN不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtJOB_DESIGN.Text))
	{
		strErr+="JOB_DESIGN不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtJOB_LEV1.Text))
	{
		strErr+="JOB_LEV1不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtJOB_LEV2.Text))
	{
		strErr+="JOB_LEV2不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtJOB_LEV3.Text))
	{
		strErr+="JOB_LEV3不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtJOB_CHARGE_OUT.Text))
	{
		strErr+="JOB_CHARGE_OUT不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtJOB_DAILY.Text))
	{
		strErr+="JOB_DAILY不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtJOB_MON.Text))
	{
		strErr+="JOB_MON不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtJOB_PERIOD.Text))
	{
		strErr+="JOB_PERIOD不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtJOB_PERIOD_VAL.Text))
	{
		strErr+="JOB_PERIOD_VAL不是数字！\\n";	
	}
	if(this.txtJOB_AUTH.Text =="")
	{
		strErr+="JOB_AUTH不能为空！\\n";	
	}
	if(this.txtJOB_OFF_INCHG_AD.Text =="")
	{
		strErr+="JOB_OFF_INCHG_AD不能为空！\\n";	
	}
	if(this.txtJOB_OFF_INCHG_DES.Text =="")
	{
		strErr+="JOB_OFF_INCHG_DES不能为空！\\n";	
	}
	if(this.txtJOB_AUTH_1.Text =="")
	{
		strErr+="JOB_AUTH_1不能为空！\\n";	
	}
	if(this.txtJOB_AUTH_2.Text =="")
	{
		strErr+="JOB_AUTH_2不能为空！\\n";	
	}
	if(this.txtJOB_AUTH_3.Text =="")
	{
		strErr+="JOB_AUTH_3不能为空！\\n";	
	}
	if(this.txtJOB_AUTH_4.Text =="")
	{
		strErr+="JOB_AUTH_4不能为空！\\n";	
	}
	if(this.txtJOB_AUTH_5.Text =="")
	{
		strErr+="JOB_AUTH_5不能为空！\\n";	
	}
	if(!PageValidate.IsNumber(txtJOB_INDEX.Text))
	{
		strErr+="JOB_INDEX不是数字！\\n";	
	}
	if(this.txtJOB_NAME_S.Text =="")
	{
		strErr+="JOB_NAME_S不能为空！\\n";	
	}
	if(this.txtJOB_NAME_T.Text =="")
	{
		strErr+="JOB_NAME_T不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string JOB_CO_CODE=this.txtJOB_CO_CODE.Text;
	string JOB_NAME=this.txtJOB_NAME.Text;
	decimal JOB_CON=decimal.Parse(this.txtJOB_CON.Text);
	decimal JOB_OPEN_BAL_HOUR=decimal.Parse(this.txtJOB_OPEN_BAL_HOUR.Text);
	decimal JOB_YTD_HOUR=decimal.Parse(this.txtJOB_YTD_HOUR.Text);
	decimal JOB_OPEN_BAL_AMT=decimal.Parse(this.txtJOB_OPEN_BAL_AMT.Text);
	decimal JOB_YTD_AMT=decimal.Parse(this.txtJOB_YTD_AMT.Text);
	decimal JOB_REC=decimal.Parse(this.txtJOB_REC.Text);
	decimal JOB_OS_BAL=decimal.Parse(this.txtJOB_OS_BAL.Text);
	decimal JOB_BUD_HOUR=decimal.Parse(this.txtJOB_BUD_HOUR.Text);
	int JOB_CO_ORD=int.Parse(this.txtJOB_CO_ORD.Text);
	int JOB_ADMIN=int.Parse(this.txtJOB_ADMIN.Text);
	int JOB_DESIGN=int.Parse(this.txtJOB_DESIGN.Text);
	int JOB_LEV1=int.Parse(this.txtJOB_LEV1.Text);
	int JOB_LEV2=int.Parse(this.txtJOB_LEV2.Text);
	int JOB_LEV3=int.Parse(this.txtJOB_LEV3.Text);
	int JOB_CHARGE_OUT=int.Parse(this.txtJOB_CHARGE_OUT.Text);
	int JOB_DAILY=int.Parse(this.txtJOB_DAILY.Text);
	int JOB_MON=int.Parse(this.txtJOB_MON.Text);
	decimal JOB_PERIOD=decimal.Parse(this.txtJOB_PERIOD.Text);
	decimal JOB_PERIOD_VAL=decimal.Parse(this.txtJOB_PERIOD_VAL.Text);
	string JOB_AUTH=this.txtJOB_AUTH.Text;
	string JOB_OFF_INCHG_AD=this.txtJOB_OFF_INCHG_AD.Text;
	string JOB_OFF_INCHG_DES=this.txtJOB_OFF_INCHG_DES.Text;
	string JOB_AUTH_1=this.txtJOB_AUTH_1.Text;
	string JOB_AUTH_2=this.txtJOB_AUTH_2.Text;
	string JOB_AUTH_3=this.txtJOB_AUTH_3.Text;
	string JOB_AUTH_4=this.txtJOB_AUTH_4.Text;
	string JOB_AUTH_5=this.txtJOB_AUTH_5.Text;
	int JOB_INDEX=int.Parse(this.txtJOB_INDEX.Text);
	string JOB_NAME_S=this.txtJOB_NAME_S.Text;
	string JOB_NAME_T=this.txtJOB_NAME_T.Text;


	WongTung.Model.job model=new WongTung.Model.job();
	model.JOB_CO_CODE=JOB_CO_CODE;
	model.JOB_NAME=JOB_NAME;
	model.JOB_CON=JOB_CON;
	model.JOB_OPEN_BAL_HOUR=JOB_OPEN_BAL_HOUR;
	model.JOB_YTD_HOUR=JOB_YTD_HOUR;
	model.JOB_OPEN_BAL_AMT=JOB_OPEN_BAL_AMT;
	model.JOB_YTD_AMT=JOB_YTD_AMT;
	model.JOB_REC=JOB_REC;
	model.JOB_OS_BAL=JOB_OS_BAL;
	model.JOB_BUD_HOUR=JOB_BUD_HOUR;
	model.JOB_CO_ORD=JOB_CO_ORD;
	model.JOB_ADMIN=JOB_ADMIN;
	model.JOB_DESIGN=JOB_DESIGN;
	model.JOB_LEV1=JOB_LEV1;
	model.JOB_LEV2=JOB_LEV2;
	model.JOB_LEV3=JOB_LEV3;
	model.JOB_CHARGE_OUT=JOB_CHARGE_OUT;
	model.JOB_DAILY=JOB_DAILY;
	model.JOB_MON=JOB_MON;
	model.JOB_PERIOD=JOB_PERIOD;
	model.JOB_PERIOD_VAL=JOB_PERIOD_VAL;
	model.JOB_AUTH=JOB_AUTH;
	model.JOB_OFF_INCHG_AD=JOB_OFF_INCHG_AD;
	model.JOB_OFF_INCHG_DES=JOB_OFF_INCHG_DES;
	model.JOB_AUTH_1=JOB_AUTH_1;
	model.JOB_AUTH_2=JOB_AUTH_2;
	model.JOB_AUTH_3=JOB_AUTH_3;
	model.JOB_AUTH_4=JOB_AUTH_4;
	model.JOB_AUTH_5=JOB_AUTH_5;
	model.JOB_INDEX=JOB_INDEX;
	model.JOB_NAME_S=JOB_NAME_S;
	model.JOB_NAME_T=JOB_NAME_T;

	WongTung.BLL.job bll=new WongTung.BLL.job();
	bll.Update(model);

		}

    }
}
