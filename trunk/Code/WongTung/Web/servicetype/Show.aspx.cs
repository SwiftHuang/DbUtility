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
namespace WongTung.Web.servicetype
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
		WongTung.BLL.servicetype bll=new WongTung.BLL.servicetype();
		WongTung.Model.servicetype model=bll.GetModel();
		this.lblST_CO_CODE.Text=model.ST_CO_CODE;
		this.lblST_JOB_CODE.Text=model.ST_JOB_CODE;
		this.lblST_SER_CODE.Text=model.ST_SER_CODE;
		this.lblST_DESC.Text=model.ST_DESC;
		this.lblST_DESC1.Text=model.ST_DESC1;
		this.lblST_DESC_T1.Text=model.ST_DESC_T1;
		this.lblST_DESC_S1.Text=model.ST_DESC_S1;
		this.lblST_DESC_T2.Text=model.ST_DESC_T2;
		this.lblST_DESC_S2.Text=model.ST_DESC_S2;

	}


    }
}
