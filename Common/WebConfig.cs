using System;
using System.Configuration;

namespace WongTung.Common
{
    public class WebConfig
    {

        private static string _WongTungConnection;
        public static string WongTungConnection
        {
            get
            {
                if (_WongTungConnection == null)
                    _WongTungConnection = ConfigurationManager.ConnectionStrings["WongTungConnection"].ToString();
                return _WongTungConnection;
            }
        }
        private static string _LoginPageUrl;
        public static string LoginPageUrl
        {
            get
            {
                if (_LoginPageUrl == null)
                    _LoginPageUrl = ConfigurationManager.AppSettings["LoginPageUrl"];
                return _LoginPageUrl;
            }
        }
        public readonly static bool DisplayErrorDetails = General.String2Bool(ConfigurationManager.AppSettings["DisplayErrorDetails"].ToString());
        public readonly static bool ConnectionStringEncrypt = General.String2Bool(ConfigurationManager.AppSettings["ConnectionStringEncrypt"].ToString());
        private static string _DatabaseTypeString;
        public static string DatabaseTypeString
        {
            get
            {
                if (_DatabaseTypeString == null)
                    _DatabaseTypeString = ConfigurationManager.AppSettings["DatabaseType"].ToString().ToUpper().Trim();
                return _DatabaseTypeString;
            }
        }
    }
}
