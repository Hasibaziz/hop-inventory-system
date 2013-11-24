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
  public partial  class InvDevicenameDAL
    {
      public DataTable GetDevicenameRecord(object param)
      {
          Database db = DatabaseFactory.CreateDatabase();
          string sql = "SELECT DeviceID, DeviceName, Description FROM ITInventory.dbo.INV_Devices ORDER BY DeviceName ASC";
          DbCommand dbCommand = db.GetSqlStringCommand(sql);
          DataSet ds = db.ExecuteDataSet(dbCommand);
          return ds.Tables[0];
      }
      public bool SaveDeviceInfo(InvDevicenameEntity DeviceEntity, Database db, DbTransaction transaction)
      {
          string sql = "INSERT INTO ITInventory.dbo.INV_Devices ( DeviceName, Description) VALUES (  @DeviceName,  @Description )";
          DbCommand dbCommand = db.GetSqlStringCommand(sql);

          db.AddInParameter(dbCommand, "DeviceName", DbType.String, DeviceEntity.DeviceName);
          db.AddInParameter(dbCommand, "Description", DbType.String, DeviceEntity.Description);         

          db.ExecuteNonQuery(dbCommand, transaction);
          return true;
      }
      public bool UpdateDeviceInfo(InvDevicenameEntity DeviceEntity, Database db, DbTransaction transaction)
      {
          string sql = "UPDATE INV_Devices SET DeviceName=@DeviceName, Description=@Description WHERE DeviceID=@DeviceID";
          DbCommand dbCommand = db.GetSqlStringCommand(sql);
          db.AddInParameter(dbCommand, "DeviceID", DbType.String, DeviceEntity.DeviceID);
          db.AddInParameter(dbCommand, "DeviceName", DbType.String, DeviceEntity.DeviceName);
          db.AddInParameter(dbCommand, "Description", DbType.String, DeviceEntity.Description);        

          db.ExecuteNonQuery(dbCommand, transaction);
          return true;
      }
      public DataTable GetDupdevicename(string DUPDevice, object param)
      {
          Database db = DatabaseFactory.CreateDatabase();

          //string sql = "SELECT COUNT(Usermail) as MailCount FROM ITInventory.dbo.Login_info GROUP BY Usermail HAVING COUNT(Usermail)>=1";
          string sql = "SELECT DeviceName  FROM ITInventory.dbo.INV_Devices where DeviceName like '%" + DUPDevice + "%'";
          DbCommand dbCommand = db.GetSqlStringCommand(sql);
          //db.AddInParameter(dbCommand, "Usermail", DbType.String, UserEntity.Usermail);
          DataSet ds = db.ExecuteDataSet(dbCommand);
          return ds.Tables[0];
      }
    }
}
