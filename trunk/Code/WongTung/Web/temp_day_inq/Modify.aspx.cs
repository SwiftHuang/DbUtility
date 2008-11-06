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
namespace WongTung.Web.temp_day_inq
{
    public partial class Modify : System.Web.UI.Page
    {       

        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "��Ϣ�޸�";
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null || Request.Params["id"].Trim() != "")
				{
					string id = Request.Params["id"];
					ShowInfo();
				}
			}
		}
			
	private void ShowInfo()
	{
		WongTung.BLL.temp_day_inq bll=new WongTung.BLL.temp_day_inq();
		WongTung.Model.temp_day_inq model=bll.GetModel();
		this.txtTEM_CO_CODE.Text=model.TEM_CO_CODE;
		this.txtTEM_STAFF_CODE.Text=model.TEM_STAFF_CODE;
		this.txtTEM_WORK_DATE.Text=model.TEM_WORK_DATE.ToString();
		this.txtTEM_LINE_NO.Text=model.TEM_LINE_NO.ToString();
		this.txtTEM_HOUR_TYPE.Text=model.TEM_HOUR_TYPE;
		this.txtTEM_APP_CODE.Text=model.TEM_APP_CODE;
		this.txtTEM_SER_CODE.Text=model.TEM_SER_CODE;
		this.txtTEM_JOB_CODE.Text=model.TEM_JOB_CODE;
		this.txtTEM_NOR_HOUR_0.Text=model.TEM_NOR_HOUR_0.ToString();
		this.txtTEM_NOR_HOUR_1.Text=model.TEM_NOR_HOUR_1.ToString();
		this.txtTEM_NOR_HOUR_2.Text=model.TEM_NOR_HOUR_2.ToString();
		this.txtTEM_NOR_HOUR_3.Text=model.TEM_NOR_HOUR_3.ToString();
		this.txtTEM_NOR_HOUR_4.Text=model.TEM_NOR_HOUR_4.ToString();
		this.txtTEM_NOR_HOUR_5.Text=model.TEM_NOR_HOUR_5.ToString();
		this.txtTEM_NOR_HOUR_6.Text=model.TEM_NOR_HOUR_6.ToString();
		this.txtTEM_TYPE.Text=model.TEM_TYPE;
		this.txtTEM_APP_FLAG.Text=model.TEM_APP_FLAG;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtTEM_CO_CODE.Text =="")
	{
		strErr+="TEM_CO_CODE����Ϊ�գ�\\n";	
	}
	if(this.txtTEM_STAFF_CODE.Text =="")
	{
		strErr+="TEM_STAFF_CODE����Ϊ�գ�\\n";	
	}
	if(!PageValidate.IsDateTime(txtTEM_WORK_DATE.Text))
	{
		strErr+="TEM_WORK_DATE����ʱ���ʽ��\\n";	
	}
	if(!PageValidate.IsDecimal(txtTEM_LINE_NO.Text))
	{
		strErr+="TEM_LINE_NO�������֣�\\n";	
	}
	if(this.txtTEM_HOUR_TYPE.Text =="")
	{
		strErr+="TEM_HOUR_TYPE����Ϊ�գ�\\n";	
	}
	if(this.txtTEM_APP_CODE.Text =="")
	{
		strErr+="TEM_APP_CODE����Ϊ�գ�\\n";	
	}
	if(this.txtTEM_SER_CODE.Text =="")
	{
		strErr+="TEM_SER_CODE����Ϊ�գ�\\n";	
	}
	if(this.txtTEM_JOB_CODE.Text =="")
	{
		strErr+="TEM_JOB_CODE����Ϊ�գ�\\n";	
	}
	if(!PageValidate.IsDecimal(txtTEM_NOR_HOUR_0.Text))
	{
		strErr+="TEM_NOR_HOUR_0�������֣�\\n";	
	}
	if(!PageValidate.IsDecimal(txtTEM_NOR_HOUR_1.Text))
	{
		strErr+="TEM_NOR_HOUR_1�������֣�\\n";	
	}
	if(!PageValidate.IsDecimal(txtTEM_NOR_HOUR_2.Text))
	{
		strErr+="TEM_NOR_HOUR_2�������֣�\\n";	
	}
	if(!PageValidate.IsDecimal(txtTEM_NOR_HOUR_3.Text))
	{
		strErr+="TEM_NOR_HOUR_3�������֣�\\n";	
	}
	if(!PageValidate.IsDecimal(txtTEM_NOR_HOUR_4.Text))
	{
		strErr+="TEM_NOR_HOUR_4�������֣�\\n";	
	}
	if(!PageValidate.IsDecimal(txtTEM_NOR_HOUR_5.Text))
	{
		strErr+="TEM_NOR_HOUR_5�������֣�\\n";	
	}
	if(!PageValidate.IsDecimal(txtTEM_NOR_HOUR_6.Text))
	{
		strErr+="TEM_NOR_HOUR_6�������֣�\\n";	
	}
	if(this.txtTEM_TYPE.Text =="")
	{
		strErr+="TEM_TYPE����Ϊ�գ�\\n";	
	}
	if(this.txtTEM_APP_FLAG.Text =="")
	{
		strErr+="TEM_APP_FLAG����Ϊ�գ�\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string TEM_CO_CODE=this.txtTEM_CO_CODE.Text;
	string TEM_STAFF_CODE=this.txtTEM_STAFF_CODE.Text;
	DateTime TEM_WORK_DATE=DateTime.Parse(this.txtTEM_WORK_DATE.Text);
	decimal TEM_LINE_NO=decimal.Parse(this.txtTEM_LINE_NO.Text);
	string TEM_HOUR_TYPE=this.txtTEM_HOUR_TYPE.Text;
	string TEM_APP_CODE=this.txtTEM_APP_CODE.Text;
	string TEM_SER_CODE=this.txtTEM_SER_CODE.Text;
	string TEM_JOB_CODE=this.txtTEM_JOB_CODE.Text;
	decimal TEM_NOR_HOUR_0=decimal.Parse(this.txtTEM_NOR_HOUR_0.Text);
	decimal TEM_NOR_HOUR_1=decimal.Parse(this.txtTEM_NOR_HOUR_1.Text);
	decimal TEM_NOR_HOUR_2=decimal.Parse(this.txtTEM_NOR_HOUR_2.Text);
	decimal TEM_NOR_HOUR_3=decimal.Parse(this.txtTEM_NOR_HOUR_3.Text);
	decimal TEM_NOR_HOUR_4=decimal.Parse(this.txtTEM_NOR_HOUR_4.Text);
	decimal TEM_NOR_HOUR_5=decimal.Parse(this.txtTEM_NOR_HOUR_5.Text);
	decimal TEM_NOR_HOUR_6=decimal.Parse(this.txtTEM_NOR_HOUR_6.Text);
	string TEM_TYPE=this.txtTEM_TYPE.Text;
	string TEM_APP_FLAG=this.txtTEM_APP_FLAG.Text;


	WongTung.Model.temp_day_inq model=new WongTung.Model.temp_day_inq();
	model.TEM_CO_CODE=TEM_CO_CODE;
	model.TEM_STAFF_CODE=TEM_STAFF_CODE;
	model.TEM_WORK_DATE=TEM_WORK_DATE;
	model.TEM_LINE_NO=TEM_LINE_NO;
	model.TEM_HOUR_TYPE=TEM_HOUR_TYPE;
	model.TEM_APP_CODE=TEM_APP_CODE;
	model.TEM_SER_CODE=TEM_SER_CODE;
	model.TEM_JOB_CODE=TEM_JOB_CODE;
	model.TEM_NOR_HOUR_0=TEM_NOR_HOUR_0;
	model.TEM_NOR_HOUR_1=TEM_NOR_HOUR_1;
	model.TEM_NOR_HOUR_2=TEM_NOR_HOUR_2;
	model.TEM_NOR_HOUR_3=TEM_NOR_HOUR_3;
	model.TEM_NOR_HOUR_4=TEM_NOR_HOUR_4;
	model.TEM_NOR_HOUR_5=TEM_NOR_HOUR_5;
	model.TEM_NOR_HOUR_6=TEM_NOR_HOUR_6;
	model.TEM_TYPE=TEM_TYPE;
	model.TEM_APP_FLAG=TEM_APP_FLAG;

	WongTung.BLL.temp_day_inq bll=new WongTung.BLL.temp_day_inq();
	bll.Update(model);

		}

    }
}