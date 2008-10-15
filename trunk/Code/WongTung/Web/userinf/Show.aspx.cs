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
namespace WongTung.Web.userinf
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
					//ShowInfo(USER_CODE);
				}
			}
		}
		
	private void ShowInfo(string USER_CODE)
	{
		WongTung.BLL.userinf bll=new WongTung.BLL.userinf();
		WongTung.Model.userinf model=bll.GetModel(USER_CODE);
		this.lblUSER_CO_CODE.Text=model.USER_CO_CODE;
		this.lblUSER_NAME.Text=model.USER_NAME;
		this.lblUSER_EMP_CODE.Text=model.USER_EMP_CODE;
		this.lblUSER_RAND.Text=model.USER_RAND;
		this.lblUSER_CURDATE.Text=model.USER_CURDATE.ToString();
		this.lblUSER_RAND_BACK.Text=model.USER_RAND_BACK;
		this.lblUSER_ACTIVATE.Text=model.USER_ACTIVATE;
		this.lblUSER_CHNAME.Text=model.USER_CHNAME;

	}


    }
}
