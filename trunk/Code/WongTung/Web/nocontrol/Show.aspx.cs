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
namespace WongTung.Web.nocontrol
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
		WongTung.BLL.nocontrol bll=new WongTung.BLL.nocontrol();
		WongTung.Model.nocontrol model=bll.GetModel();
		this.lblNO_CO_CODE.Text=model.NO_CO_CODE;
		this.lblNO_CODE.Text=model.NO_CODE;
		this.lblNO_DESC.Text=model.NO_DESC;
		this.lblNO_STA_NO.Text=model.NO_STA_NO.ToString();
		this.lblNO_SEQ_NO.Text=model.NO_SEQ_NO.ToString();

	}


    }
}
