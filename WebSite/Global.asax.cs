using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;

using WongTung.Common;

namespace WongTung.WebSite
{
    public class Global : System.Web.HttpApplication
    {
        public static string LoginPageUrl = "~/login.aspx";
        public static bool DisplayDetailsError = false;

        protected void Application_Start(object sender, EventArgs e)
        {
            LoginPageUrl = WebConfig.LoginPageUrl;
            DisplayDetailsError = WebConfig.DisplayErrorDetails;

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}