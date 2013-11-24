using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Reports
{
    public class PCInvreportEntity
    {
        public string SL { get; set; }
        public string AccountID { get; set; }      
        public string AccountCode { get; set; }
        public string BrandModel { get; set; }
        public string Category { get; set; }
        public string Configuration { get; set; }
        public string SerialNo { get; set; }
        public string Location { get; set; }
        public string DeptID { get; set; }
        public string EMPID { get; set; }
        public string EMPNAME { get; set; }
        public string PurchDate { get; set; }
        public string Remark { get; set; }
        public string Team { get; set; }
        public string Status { get; set; }
        public string HostName { get; set; }
        public string ITemNo { get; set; }
        public string DeviceID { get; set; }
        public string Proposed { get; set; }
        public string Office { get; set; }
        public string Y { get; set; }
        public string M { get; set; }
        public string D { get; set; }

        public string MonitorID { get; set; }
        public string MonitorName { get; set; }
        public string MModelNo { get; set; }
        public string MSerialNo { get; set; }
        public string MPurchDate { get; set; }
        public string MDistDate { get; set; }

        public string UPSID { get; set; }
        public string UPSName { set; get; }
        public string UModelNo { get; set; }
        public string USerialNo { get; set; }
        public string UPurchDate { get; set; }
        public string UDistDate { get; set; }

        public string PrinterID { get; set; }
        public string PrinterName { get; set; }
        public string IPMAC { get; set; }
        public string PPurchDate { get; set; }
        public string PDistDate { get; set; }
        public string Type { get; set; }
        public string Totaluser { get; set; }
        public string Dailyppage { get; set; }

        public string UserID { get; set; }
        public string Modifydate { get; set; }

        public string Userstatus { get; set; }
    }
}