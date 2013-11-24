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
   public partial class AllDeviceinfoBLL
    {
       public object GetAllDeviceinfoRecord(object param)
       {
           object retObj = null;
           AllDeviceinfoDAL AllDEVDAL = new AllDeviceinfoDAL();
           InvInventorydetailsEntity obj = (InvInventorydetailsEntity)param;
           retObj = (object)AllDEVDAL.GetAllDeviceinfoRecord(obj,param);
           return retObj;
       }
    }
}
