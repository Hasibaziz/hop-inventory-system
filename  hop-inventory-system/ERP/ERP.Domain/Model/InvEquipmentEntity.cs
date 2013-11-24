using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ERP.Domain.Model
{
    public class InvEquipmentEntity
    {
        public string SL { get; set; }
        public string EID { get; set; }
        //[Required(ErrorMessage = "{0} is required!")]
        //[Display(Name = "Location")]
        public string LocID { get; set; }
        //[Required(ErrorMessage = "{0} is required!")]
        //[Display(Name = "Equipment Number")]
        public string ENumber { get; set; }
        //[Required(ErrorMessage = "{0} is required!")]
        //[Display(Name = "Asset Code")]
        public string AccountCode { get; set; }
        public string AssetCode { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Serialno { get; set; }
        public string Subserialno { get; set; }
        //[Required(ErrorMessage = "{0} is required!")]
        //[Display(Name = "Machine Name")]
        public string MNID { get; set; }
        public string Description { get; set; }
        public string Machineid { get; set; }
        public string Lifetime { get; set; }
        public string PurchDate { get; set; }      
        public string UnitID { get; set; }
        public string BNID { get; set; }
        public string FID { get; set; }
        public string LID { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public string CID { get; set; } 
              
        public string Y { get; set; }
        public string M { get; set; }
        public string D { get; set; }

        public string Location { get; set; }
        public string Userstatus { get; set; }
         
      
       
       
    }
}
