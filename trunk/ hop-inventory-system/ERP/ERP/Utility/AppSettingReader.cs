using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace ERP.Utility
{
    public class AppSettingReader
    {
        private static String GetAppSettingsValue(String key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static String SmtpHost
        {
            get
            {
                return GetAppSettingsValue("SmtpHost");
            }
        }
        /// <summary>
        /// Get the Configuration Value for SMTP port. If not specified then retuns a default value of 25
        /// </summary>
        public static int SmtpPort
        {
            get
            {
                int port = 0;
                String paramValue = GetAppSettingsValue("SmtpPort");
                int.TryParse(paramValue, out port);
                return port == 0 ? 25 : port;
            }
        }

        public static String ErrorEmail
        {
            get
            {
                return GetAppSettingsValue("ErrorEmail");
            }
        }
        public static String AdminEmail
        {
            get
            {
                return GetAppSettingsValue("AdminEmail");
            }
        }



    }
}