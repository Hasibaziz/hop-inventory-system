using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Domain.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using ERP.Server.DAL;


namespace ERP.Server.BLL
{
    public partial class InvreportingBLL
    {
        public object GetAllDeviceinfoReport(object param)
        {
            object retObj = null;
            InvreportingDAL AllDEVDAL = new InvreportingDAL();
            InvInventorydetailsEntity obj = (InvInventorydetailsEntity)param;
            retObj = (object)AllDEVDAL.GetAllDeviceinfoReport(obj, param);
            return retObj;
        }
    }
}
