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
namespace WongTung.Web.icpinq
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
		WongTung.BLL.icpinq bll=new WongTung.BLL.icpinq();
		WongTung.Model.icpinq model=bll.GetModel();
		this.lblICP_CO_CODE.Text=model.ICP_CO_CODE;
		this.lblICP_OFFICE_CODE.Text=model.ICP_OFFICE_CODE;
		this.lblICP_OFFICE_NAME.Text=model.ICP_OFFICE_NAME;
		this.lblICP_EMP_CODE.Text=model.ICP_EMP_CODE;
		this.lblICP_EMP_NAME.Text=model.ICP_EMP_NAME;

	}


    }
}
