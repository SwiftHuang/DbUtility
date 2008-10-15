using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using WongTung.WebSite;
using WongTung.Entity;


namespace WongTung.WebSite
{
    public partial class ErrorPage : BasePage
    {
        #region Attribue
        ErrorInfo err = new ErrorInfo();
        public string RedirectUrl { get; set; }
        #endregion
        protected override void OnInit(EventArgs e)
        {
            base.EnabledLoginCheck = false;
            base.EnabledErrorHandle = false;
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
                ShowInfo();
        }

        #region Function
        private void ShowInfo()
        {
            ErrorInfo.GetSessionTo(ref err);
            if (err == null)
                Response.Redirect(Global.LoginPageUrl);
            else
            {
                ErrorPanel1.ErrorInfos = err;
                SendEmail();
            }
            err.ClearSession();
        }
        //AutoSendEmail
        private void SendEmail()
        {
        }
        #endregion


    }
}
