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
namespace WongTung.Web.holiday
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
		WongTung.BLL.holiday bll=new WongTung.BLL.holiday();
		WongTung.Model.holiday model=bll.GetModel();
		this.lblHD_CO_CODE.Text=model.HD_CO_CODE;
		this.lblHD_EMP_CODE.Text=model.HD_EMP_CODE;
		this.lblHD_LINE_NO.Text=model.HD_LINE_NO.ToString();
		this.lblHD_DATE.Text=model.HD_DATE.ToString();
		this.lblHD_LEVE_CODE.Text=model.HD_LEVE_CODE;

	}


    }
}
