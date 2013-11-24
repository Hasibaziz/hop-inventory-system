using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ERP.Domain.Model
{
   public class InvMachineinfoEntity
    {
       public string MNID
       {
           set;
           get;
       }
       [Required(ErrorMessage = "{0} is required!")]
       [Display(Name = "Machine Name ")]
       public string MachineName
       {
           set;
           get;
       }
       [Required(ErrorMessage = "{0} is required!")]
       [Display(Name = "Description ")]
       public string Description
       {
           set;
           get;
       }
    }
}
