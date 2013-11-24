using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ERP.Domain.Model
{
   public class InvitemreceiveEntity
    {
       public string IRID
       {
           set;
           get;
       }
       public string ItemID
       {
           set;
           get;
       }
       public string ModelID
       {
           set;
           get;
       }
       [Required(ErrorMessage = "{0} is required!")]
       [Display(Name = "Receive Date")]
       public string RDate
       {
           set;
           get;
       }
       [Required(ErrorMessage = "{0} is required!")]
       [Display(Name = "Challan Number")]
       public string Chlanno
       {
           set;
           get;
       }
       [Required(ErrorMessage = "{0} is required!")]
       [Display(Name = "Supplier Name")]
       public string Suppliername
       {
           set;
           get;
       }
       [Required(ErrorMessage = "{0} is required!")]
       [Display(Name = "Location")]
       public string LocID
       {
           set;
           get;
       }
       public string Quantity
       {
           set;
           get;
       }
    }
}
