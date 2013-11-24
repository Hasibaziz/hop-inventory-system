using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ERP.HelperClasses
{
    /// <summary>
    /// Code taken from the following blog entry by Jeremiah Clark:
    /// http://blogs.msdn.com/b/miah/archive/2008/11/13/extending-mvc-returning-an-image-from-a-controller-action.aspx
    /// </summary>
    public static class ControllerExtensions
    {
        public static ImageResult Image(this Controller controller, Stream imageStream, string contentType)
        {
            return new ImageResult(imageStream, contentType);
        }

        public static ImageResult Image(this Controller controller, byte[] imageBytes, string contentType)
        {
            return new ImageResult(new MemoryStream(imageBytes), contentType);
        }
    }
}