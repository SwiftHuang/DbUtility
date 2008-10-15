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
namespace WongTung.Web.spe_endorse
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
					//ShowInfo(SPE_CODE);
				}
			}
		}
		
	private void ShowInfo(string SPE_CODE)
	{
		WongTung.BLL.spe_endorse bll=new WongTung.BLL.spe_endorse();
		WongTung.Model.spe_endorse model=bll.GetModel(SPE_CODE);
		this.lblSPE_CRE_EMP.Text=model.SPE_CRE_EMP;
		this.lblSPE_CRE_DATE.Text=model.SPE_CRE_DATE.ToString();

	}


    }
}
