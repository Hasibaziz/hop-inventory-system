using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Domain.Model
{
   public class PrinterInfoEntity
    {
       public string PrinterID { get; set; }
       public string AccountCode { get; set; }
       public string PrinterName { get; set; }
       public string IPMAC { get; set; }
       public string PurchDate { get; set; }
       public string DeptID { get; set; }
       public string DistDate { get; set; }
       public string Type { get; set; }
       public string Totaluser { get; set; }
       public string Dailyppage { get; set; }
       public string DeviceID { get; set; }

    }
}
