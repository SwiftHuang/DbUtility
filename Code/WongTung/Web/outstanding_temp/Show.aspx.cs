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
namespace WongTung.Web.outstanding_temp
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
					//ShowInfo(NUM);
				}
			}
		}
		
	private void ShowInfo(decimal NUM)
	{
		WongTung.BLL.outstanding_temp bll=new WongTung.BLL.outstanding_temp();
		WongTung.Model.outstanding_temp model=bll.GetModel(NUM);
		this.lblOUT_OFF_CODE.Text=model.OUT_OFF_CODE;
		this.lblOUT_OFF_NAME.Text=model.OUT_OFF_NAME;
		this.lblOUT_EMP_CODE.Text=model.OUT_EMP_CODE;
		this.lblOUT_EMP_NAME.Text=model.OUT_EMP_NAME;
		this.lblOUT_DAY.Text=model.OUT_DAY.ToString();
		this.lblOUT_POS_CLASS.Text=model.OUT_POS_CLASS.ToString();
		this.lblOUT_POS_CODE.Text=model.OUT_POS_CODE;
		this.lblOUT_UPDATE_DATE.Text=model.OUT_UPDATE_DATE.ToString();

	}


    }
}
