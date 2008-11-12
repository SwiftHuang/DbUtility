using System;
using System.Configuration;

namespace WongTung.Common
{
    public class WebConfig
    {
        public readonly static bool DisplayErrorDetails = General.String2Bool(ConfigurationManager.AppSettings["DisplayErrorDetails"].ToString());
        public readonly static bool ConnectionStringEncrypt = General.String2Bool(ConfigurationManager.AppSettings["ConnectionStringEncrypt"].ToString());

        public readonly static string DatabaseConnection = GetConnectionString("WongTungConnection", ConnectionStringEncrypt);

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

        private static string GetConnectionString(string configName, bool isEncrype)
        {
            string connectionString = ConfigurationManager.AppSettings[configName];
            if (isEncrype)
            {
                connectionString = DESEncrypt.Decrypt(connectionString);
            }
            return connectionString;
        }
    }
}
