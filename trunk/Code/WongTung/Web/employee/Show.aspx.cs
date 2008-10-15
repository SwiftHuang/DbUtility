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
namespace WongTung.Web.employee
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
					//ShowInfo(EMP_CODE);
				}
			}
		}
		
	private void ShowInfo(string EMP_CODE)
	{
		WongTung.BLL.employee bll=new WongTung.BLL.employee();
		WongTung.Model.employee model=bll.GetModel(EMP_CODE);
		this.lblEMP_CO_CODE.Text=model.EMP_CO_CODE;
		this.lblEMP_NAME.Text=model.EMP_NAME;
		this.lblEMP_POS_CODE.Text=model.EMP_POS_CODE;
		this.lblEMP_DEP_CODE.Text=model.EMP_DEP_CODE;
		this.lblEMP_INITIAL.Text=model.EMP_INITIAL;
		this.lblEMP_OFFICE.Text=model.EMP_OFFICE;
		this.lblEMP_CHNAME.Text=model.EMP_CHNAME;
		this.lblEMP_SPE.Text=model.EMP_SPE;
		this.lblEMP_CRE_DATE.Text=model.EMP_CRE_DATE.ToString();
		this.lblEMP_DEL.Text=model.EMP_DEL;

	}


    }
}
