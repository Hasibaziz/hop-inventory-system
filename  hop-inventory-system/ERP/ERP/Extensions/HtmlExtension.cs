using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Telerik.Web.Mvc.Extensions;
using Telerik.Web.Mvc.Infrastructure;
using Telerik.Web.Mvc.UI;
using System.Web.Mvc;

namespace Mvc.Web.HtmlExtension
{
    public static class HtmlExtension
    {
        public static string GetCurrentTheme(this HtmlHelper html)
        {
            return html.ViewContext.HttpContext.Request.QueryString["theme"] ?? "vista";
        }

    }
}