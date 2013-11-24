using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Utility
{
    public class AppConstants
    {
        #region Email Templates
        public class EmailTemplate
        {
            public const String COMMON = "/EmailTemplates/Common.html";
        }
        /// <summary>
        /// Custom Tag Constants in the Email Templates
        /// </summary>
        public class ETConstants
        {
            public const String MESSAGE = "[*MESSAGE*]";
            public const String DOMAIN = "[*DOMAIN*]";
        }
        #endregion
    }
}