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
namespace WongTung.Web.emp_day_tem
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
					//ShowInfo(ED_CO_CODE,ED_EMP_CODE);
				}
			}
		}
		
	private void ShowInfo(string ED_CO_CODE,string ED_EMP_CODE)
	{
		WongTung.BLL.emp_day_tem bll=new WongTung.BLL.emp_day_tem();
		WongTung.Model.emp_day_tem model=bll.GetModel(ED_CO_CODE,ED_EMP_CODE);
		this.lblED_JS_1.Text=model.ED_JS_1;
		this.lblED_JS_2.Text=model.ED_JS_2;
		this.lblED_JS_3.Text=model.ED_JS_3;
		this.lblED_JS_4.Text=model.ED_JS_4;
		this.lblED_JS_5.Text=model.ED_JS_5;
		this.lblED_JS_6.Text=model.ED_JS_6;
		this.lblED_JS_7.Text=model.ED_JS_7;
		this.lblED_JS_8.Text=model.ED_JS_8;
		this.lblED_JS_9.Text=model.ED_JS_9;
		this.lblED_JS_10.Text=model.ED_JS_10;

	}


    }
}
