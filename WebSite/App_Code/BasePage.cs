using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.Common;
using System.Globalization;

using WongTung.Entity;
//using WongTung.Business;
using WongTung.WebSite;
using WongTung.Common;

namespace WongTung.WebSite
{
    /// <summary>
    /// 所有页面的基类
    /// </summary>
    public class BasePage : Page
    {
        #region Property
        private LoginInfo _LoginInfo = null;
        private bool _EnabledLoginCheck = true;
        private bool _EnabledErrorHandle = true;
        private static CultureInfo defaultCulture = new CultureInfo("en-us");

        public LoginInfo myLoginInfo
        {
            get { return _LoginInfo; }
            set { _LoginInfo = value; }
        }
        public bool EnabledLoginCheck
        {
            get { return _EnabledLoginCheck; }
            set { _EnabledLoginCheck = value; }
        }
        public bool EnabledErrorHandle
        {
            get { return _EnabledErrorHandle; }
            set { _EnabledErrorHandle = value; }
        }
        #endregion

        public BasePage()
        {
            _LoginInfo = new LoginInfo();
        }

        protected override void OnPreRenderComplete(EventArgs e)
        {
            base.OnPreRenderComplete(e);
        }

        #region Override Funtion
        protected override void OnLoad(EventArgs e)
        {
            LoginInfo.GetSessionTo(ref _LoginInfo);
            this.ValidateLogin();
            base.OnLoad(e);

        }
        protected override void InitializeCulture()
        {
            string lang = Request["lang"];
            if (lang != null)
            {
                lang = lang.ToLower();
            }

            if ("zh-tw".Equals(lang) || "zh-cn".Equals(lang) || "en-us".Equals(lang))
            {
                Session["CurrentUICulture"] = new System.Globalization.CultureInfo(lang);
                Session["culture_string"] = lang;
            }

            System.Globalization.CultureInfo ci = Session["CurrentUICulture"] as System.Globalization.CultureInfo;
            if (ci != null)
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            }
            // Don't know why, but sometimes the browser culture gets automatically assigned
            // into current culture, so datetime passed into the database gets Chinese month names
            System.Threading.Thread.CurrentThread.CurrentCulture = defaultCulture;
        }
        #endregion

        #region Funtion
        private void ValidateLogin()
        {
            if (EnabledLoginCheck)
            {
                if (myLoginInfo == null)
                {
                    ErrorInfo err = new ErrorInfo();
                    err.ErrorType = ErrorInfo.ErrorTypes.Login;
                    err.SetSession();

                    Response.Redirect("~/ErrorPage.aspx");
                }
            }
        }
        protected void Page_Error(object sender, EventArgs e)
        {
            if (EnabledErrorHandle)
            {
                ErrorInfo err = new ErrorInfo();
                Exception objErr = Server.GetLastError().GetBaseException();

                if (objErr.GetType().Name == "xException")
                {
                    err.ErrorType = ErrorInfo.ErrorTypes.DefaultException;
                }
                else
                {
                    err.ErrorType = ErrorInfo.ErrorTypes.Exception;
                }
                err.LoginInfos = myLoginInfo;
                err.Exceptions = objErr;
                err.SetSession();
                Server.ClearError();

                Response.Redirect("~/ErrorPage.aspx");
            }
        }
        #endregion

    }
}



