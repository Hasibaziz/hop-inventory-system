using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Domain.Model
{
    public class InvinvmoniupsEntity
    {
        public InvInventorydetailsEntity InvInventorydetailsEntity { get; set; }
        public MonitorDetailsEntity MonitorDetailsEntity { get; set; }
        public UPSInfoEntity UPSInfoEntity { get; set; }
    }
}
