using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ERP.Domain.Model
{
    public class InvFloorinfoEntity
    {
        public string FID
        {
            set;
            get;
        }
        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Location ")]
        public string LocID
        {
            set;
            get;
        }
        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Building Name/No ")]
        public string BNID
        {
            set;
            get;
        }
        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Floor Name ")]
        public string FloorName
        {
            set;
            get;
        }
    }
}
