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
namespace WongTung.Web.department
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
					//ShowInfo(DEPT_CODE);
				}
			}
		}
		
	private void ShowInfo(string DEPT_CODE)
	{
		WongTung.BLL.department bll=new WongTung.BLL.department();
		WongTung.Model.department model=bll.GetModel(DEPT_CODE);
		this.lblDEPT_CO_CODE.Text=model.DEPT_CO_CODE;
		this.lblDEPT_NAME.Text=model.DEPT_NAME;

	}


    }
}
