using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Models
{
    public class BarcodeDemoModel
    {
        public string BarcodeText { get; set; }
        public string BarcodeThickness { get; set; }
        public bool ShowBarcodeText { get; set; }
        public string BarcodeImageUrl { get; set; }

        private List<SelectListItem> _ThicknessOptions = null;
        public List<SelectListItem> ThicknessOptions
        {
            get
            {
                if (_ThicknessOptions == null)
                {
                    _ThicknessOptions = new List<SelectListItem>();

                    _ThicknessOptions.Add(new SelectListItem() { Text = "Thin", Value = "1" });
                    _ThicknessOptions.Add(new SelectListItem() { Text = "Medium", Value = "2" });
                    _ThicknessOptions.Add(new SelectListItem() { Text = "Thick", Value = "3" });
                }

                return _ThicknessOptions;
            }
        }
    }
}