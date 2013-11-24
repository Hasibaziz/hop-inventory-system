using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace ERP.Utility
{
    public class ConfigReader
    {
        private static String GetAppSettingsValue(String key)
        {
            return ConfigurationManager.AppSettings[key];
        }  

        public static String SiteName
        {
            get
            {
                return GetAppSettingsValue("SiteName");
            }
        }
    }
}