using System;
using System.Web.UI;
using WongTung.Common;
using WongTung.Entity;

namespace WongTung.WebSite.Components
{
    public partial class ErrorPanel : System.Web.UI.UserControl
    {
        public ErrorInfo ErrorInfos { get; set; }
        private string sSeparator = "\r\n---------------------------------------------------------\r\n";

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            ShowInfo();
        }

        #region Function
        private void ShowInfo()
        {
            if (ErrorInfos != null)
            {
                if (ErrorInfos.ErrorType == ErrorInfo.ErrorTypes.DefaultException || ErrorInfos.ErrorType == ErrorInfo.ErrorTypes.Exception)
                    ExceptionHandle();
                else
                    OtherExceptionHandle();
                ErrorInfos.ClearSession();
            }
        }
        private void ExceptionHandle()
        {
            string sInfo = string.Empty;
            if (ErrorInfos.ErrorType == ErrorInfo.ErrorTypes.DefaultException)
                lblErrTitle.Text = this.GetLocalResourceObject("NormalError").ToString();
            else if (ErrorInfos.ErrorType == ErrorInfo.ErrorTypes.Exception)
                lblErrTitle.Text = this.GetLocalResourceObject("AbnormalError").ToString();
            else
                lblErrTitle.Text = this.GetLocalResourceObject("UnknowError").ToString();

            txtErrMessage.Text = ErrorInfos.Exceptions.Message;

            sInfo = string.Format("User ID:{0}\r\nLogin time:{1}\r\nError time:{2}" + sSeparator,
                (ErrorInfos.LoginInfos == null ? "-----" : ErrorInfos.LoginInfos.UserID),
                (ErrorInfos.LoginInfos == null ? "-----" : ErrorInfos.LoginInfos.LoginTime.ToString()),
                DateTime.Now);

            if (Global.DisplayDetailsError)
            {
                sInfo += string.Format("Message:\r\n   {0}" + sSeparator + "TargetSite:\r\n   {1}" + sSeparator + "StackTrace:\r\n{2}",
                       ErrorInfos.Exceptions.Message.ToString(),
                       ErrorInfos.Exceptions.TargetSite.ToString(),
                       ErrorInfos.Exceptions.StackTrace.ToString());
            }
            else
                sInfo += txtErrMessage.Text;

            txtErrDetail.Text = sInfo;
        }
        private void OtherExceptionHandle()
        {
            if (ErrorInfos.ErrorType == ErrorInfo.ErrorTypes.Login)
            {
                lblErrTitle.Text = "Re-login page";
                txtErrMessage.Text = "Please re-sign users.";
                txtErrDetail.Text = txtErrMessage.Text;
                string sRedirectUrl = Page.ResolveClientUrl(Global.LoginPageUrl);
                xAjax.ExecScript(this.Page, "var time=8;function Redirect(){window.location='" + sRedirectUrl + "';}var i=0;function dis(){document.getElementById('" + btnRedirect.ClientID + "').value='" + btnRedirect.Text + " ('+(time - i)+')';i++;}timer=setInterval('dis()', 1000);timer=setTimeout('Redirect()',time * 1000);");
            }
        }
        #endregion

        #region Button Events
        protected void btnRedirect_Click(object sender, EventArgs e)
        {
            LoginInfo login = new LoginInfo();
            login.ClearSession();
            Response.Redirect(Global.LoginPageUrl, false);
        }
        #endregion
    }
}