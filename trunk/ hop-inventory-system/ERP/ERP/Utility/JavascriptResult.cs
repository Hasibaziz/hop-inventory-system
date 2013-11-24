using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Utility
{
    public class JavascriptResult : ActionResult 
    {
        public string Script {
            get;
            set;
        }

        public override void ExecuteResult(ControllerContext context) {
            if (context == null) {
                throw new ArgumentNullException("context");
            }

            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = "application/x-javascript";

            if (Script != null) {
                response.Write(Script);
            }
        }
    
    }
}