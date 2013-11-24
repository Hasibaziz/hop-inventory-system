using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Models;
using ERP.HelperClasses;

namespace ERP.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "ERP";
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult BarCodeGen()
        {
            var model = new BarcodeDemoModel()
            {
                ShowBarcodeText = true
            };

            return View(model);
        }
        [HttpGet]
        //public ImageResult BarCodeGen(string id = "111111", bool showText = true, int thickness = 1, int height = 75)
        //{
        //    var barcode = new Code39BarCode()
        //    {
        //        BarCodeText = id,
        //        Height = height,
        //        ShowBarCodeText = showText
        //    };

        //    if (thickness == 2)
        //        barcode.BarCodeWeight = BarCodeWeight.Medium;
        //    else if (thickness == 3)
        //        barcode.BarCodeWeight = BarCodeWeight.Large;

        //    return this.Image(barcode.Generate(), "image/gif");
        //}
        [HttpPost]
        public ActionResult BarCodeGen(BarcodeDemoModel model)
        {
            var showTextValue = model.ShowBarcodeText ? "true" : "false";

            model.BarcodeImageUrl = string.Format("BarCode/Display/{0}?ShowText={1}&Thickness={2}",
                                            model.BarcodeText,
                                            showTextValue,
                                            model.BarcodeThickness);

           return View(model);
        }
    }
}
