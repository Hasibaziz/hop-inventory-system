using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Domain.Model
{
   public class InventoryModel
    {
       public string AccID { get; set; }
       public string AccCode { get; set; }
       public string BrandModel { get; set; }
       public string Configuration { get; set; }
       public string Category { get; set; }
       public string SerialNo { get; set; }
       public string Location { get; set; }
       public string UserName { get; set; }
       public string PurchDate { get; set; }
       public string Remark { get; set; }
       public string MonitorSLNO { get; set; }
       public string UpsSLNO { get; set; }
       public string DeptNo { get; set; }
       public string Team { get; set; }
       public string Status { get; set; }
       public string HostName { get; set; }
       public string ITemNo { get; set; }
    }
}
