using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Domain.Model
{
   public class MonitorDetailsEntity
    {
       public string MonitorID { get; set; }
       public string MonitorName { get; set; }
       public string ModelNo { get; set; }
       public string SerialNo { get; set; }
       public string PurchDate { get; set; }
       public string DeptID { get; set; }
       public string EmpID { get; set; }
       public string DistDate { get; set; }
       public string Description { get; set; }
    }
}
