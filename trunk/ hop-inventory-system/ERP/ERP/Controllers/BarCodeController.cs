using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.HelperClasses;

namespace ERP.Controllers
{
    public class BarCodeController : Controller
    {
        //
        // GET: /BarCode/Display/id?ShowText=true|false&Thickness=1|2|3&Height=pixels
        public ImageResult Display(string id, bool showText = true, int thickness = 1, int height = 75)
        {
            var barcode = new Code39BarCode()
            {
                BarCodeText = id,
                Height = height,
                ShowBarCodeText = showText
            };

            if (thickness == 2)
                barcode.BarCodeWeight = BarCodeWeight.Medium;
            else if (thickness == 3)
                barcode.BarCodeWeight = BarCodeWeight.Large;

            return this.Image(barcode.Generate(), "image/gif");
        }

    }
}
