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
namespace WongTung.Web.holiday_date
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
					//ShowInfo(HO_CO_CODE,HO_CODE);
				}
			}
		}
		
	private void ShowInfo(string HO_CO_CODE,string HO_CODE)
	{
		WongTung.BLL.holiday_date bll=new WongTung.BLL.holiday_date();
		WongTung.Model.holiday_date model=bll.GetModel(HO_CO_CODE,HO_CODE);
		this.lblHO_LOC.Text=model.HO_LOC;
		this.lblHO_DATE_START.Text=model.HO_DATE_START.ToString();
		this.lblHO_DATE_END.Text=model.HO_DATE_END.ToString();
		this.lblHO_DESC.Text=model.HO_DESC;

	}


    }
}
