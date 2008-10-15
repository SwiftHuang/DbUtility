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
namespace WongTung.Web.holiday_date
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
					//ShowInfo(HO_CO_CODE,HO_CODE);
				}
			}
		}
			
	private void ShowInfo(string HO_CO_CODE,string HO_CODE)
	{
		WongTung.BLL.holiday_date bll=new WongTung.BLL.holiday_date();
		WongTung.Model.holiday_date model=bll.GetModel(HO_CO_CODE,HO_CODE);
		this.lblHO_CO_CODE.Text=model.HO_CO_CODE;
		this.txtHO_LOC.Text=model.HO_LOC;
		this.lblHO_CODE.Text=model.HO_CODE;
		this.txtHO_DATE_START.Text=model.HO_DATE_START.ToString();
		this.txtHO_DATE_END.Text=model.HO_DATE_END.ToString();
		this.txtHO_DESC.Text=model.HO_DESC;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtHO_LOC.Text =="")
	{
		strErr+="HO_LOC不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtHO_DATE_START.Text))
	{
		strErr+="HO_DATE_START不是时间格式！\\n";	
	}
	if(!PageValidate.IsDateTime(txtHO_DATE_END.Text))
	{
		strErr+="HO_DATE_END不是时间格式！\\n";	
	}
	if(this.txtHO_DESC.Text =="")
	{
		strErr+="HO_DESC不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string HO_LOC=this.txtHO_LOC.Text;
	DateTime HO_DATE_START=DateTime.Parse(this.txtHO_DATE_START.Text);
	DateTime HO_DATE_END=DateTime.Parse(this.txtHO_DATE_END.Text);
	string HO_DESC=this.txtHO_DESC.Text;


	WongTung.Model.holiday_date model=new WongTung.Model.holiday_date();
	model.HO_LOC=HO_LOC;
	model.HO_DATE_START=HO_DATE_START;
	model.HO_DATE_END=HO_DATE_END;
	model.HO_DESC=HO_DESC;

	WongTung.BLL.holiday_date bll=new WongTung.BLL.holiday_date();
	bll.Update(model);

		}

    }
}
