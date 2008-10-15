using System;
using System.Configuration;

namespace WongTung.Common
{
    public class WebConfig
    {
        public static string WongTungConnection
        {
            get { return ConfigurationManager.ConnectionStrings["WongTungConnection"].ToString(); }
        }
        public static string LoginPageUrl
        {
            get { return ConfigurationManager.AppSettings["LoginPageUrl"]; }
        }
        public static bool DisplayErrorDetails
        {
            get { return General.String2Bool(ConfigurationManager.AppSettings["DisplayErrorDetails"].ToString()); }
        }
        public static bool ConnectionStringEncrypt
        {
            get { return General.String2Bool(ConfigurationManager.AppSettings["ConnectionStringEncrypt"].ToString()); }
        }
    }
}
