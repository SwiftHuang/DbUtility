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
namespace WongTung.Web.temp_day_inq
{
    public partial class Show : System.Web.UI.Page
    {        
        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "œÍœ∏–≈œ¢";
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
		this.lblTEM_CO_CODE.Text=model.TEM_CO_CODE;
		this.lblTEM_STAFF_CODE.Text=model.TEM_STAFF_CODE;
		this.lblTEM_WORK_DATE.Text=model.TEM_WORK_DATE.ToString();
		this.lblTEM_LINE_NO.Text=model.TEM_LINE_NO.ToString();
		this.lblTEM_HOUR_TYPE.Text=model.TEM_HOUR_TYPE;
		this.lblTEM_APP_CODE.Text=model.TEM_APP_CODE;
		this.lblTEM_SER_CODE.Text=model.TEM_SER_CODE;
		this.lblTEM_JOB_CODE.Text=model.TEM_JOB_CODE;
		this.lblTEM_NOR_HOUR_0.Text=model.TEM_NOR_HOUR_0.ToString();
		this.lblTEM_NOR_HOUR_1.Text=model.TEM_NOR_HOUR_1.ToString();
		this.lblTEM_NOR_HOUR_2.Text=model.TEM_NOR_HOUR_2.ToString();
		this.lblTEM_NOR_HOUR_3.Text=model.TEM_NOR_HOUR_3.ToString();
		this.lblTEM_NOR_HOUR_4.Text=model.TEM_NOR_HOUR_4.ToString();
		this.lblTEM_NOR_HOUR_5.Text=model.TEM_NOR_HOUR_5.ToString();
		this.lblTEM_NOR_HOUR_6.Text=model.TEM_NOR_HOUR_6.ToString();
		this.lblTEM_TYPE.Text=model.TEM_TYPE;
		this.lblTEM_APP_FLAG.Text=model.TEM_APP_FLAG;

	}


    }
}
