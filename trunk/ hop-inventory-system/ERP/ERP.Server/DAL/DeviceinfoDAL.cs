using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using ERP.Domain.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace ERP.Server.DAL
{
   public partial class DeviceinfoDAL
    {
       public DataTable GetAllDeviceInfoRecord(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT DeviceID, DeviceName FROM ITInventory.dbo.INV_Devices";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }
    }
}
