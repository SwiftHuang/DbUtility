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
namespace WongTung.Web.backdate
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
		WongTung.BLL.backdate bll=new WongTung.BLL.backdate();
		WongTung.Model.backdate model=bll.GetModel();
		this.lblBK_CO_CODE.Text=model.BK_CO_CODE;
		this.lblBK_USER.Text=model.BK_USER;
		this.lblBK_RAN_NO.Text=model.BK_RAN_NO;
		this.lblBK_EMP.Text=model.BK_EMP;
		this.lblBK_RAN_DATE.Text=model.BK_RAN_DATE.ToString();
		this.lblBK_CRE_DATE.Text=model.BK_CRE_DATE.ToString();
		this.lblBK_STATUS.Text=model.BK_STATUS;

	}


    }
}
