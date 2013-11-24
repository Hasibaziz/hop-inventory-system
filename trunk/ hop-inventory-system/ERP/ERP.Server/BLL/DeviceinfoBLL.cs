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
  public partial  class DeviceinfoBLL
    {
      public object GetDeviceInfoRecord(object param)
      {
          object retObj = null;
          DeviceinfoDAL InvDeviceDAL = new DeviceinfoDAL();
          retObj = (object)InvDeviceDAL.GetAllDeviceInfoRecord(param);
          return retObj;
      }
    }
}
