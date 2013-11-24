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
   public partial class InvMonitorInfoDAL
    {
       public DataTable GetMonitorInfoRecord(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT MonitorID, MonitorName, ModelNo, SerialNo, PurchDate, DeptID, EmpID, DistDate FROM ITInventory.dbo.INV_MonitorDetails";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }
       public bool SaveInvMonitorInfo(MonitorDetailsEntity InvMonitorEntity, Database db, DbTransaction transaction)
       {
           string sql = "INSERT INTO ITInventory.dbo.INV_MonitorDetails ( MonitorName, ModelNo, SerialNo, PurchDate, DeptID, EmpID, DistDate) VALUES (  @MonitorName,  @ModelNo,  @SerialNo,  @PurchDate,  @DeptID, @EmpID, @DistDate )";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);

           //db.AddInParameter(dbCommand, "Srvicenameid", DbType.String, InvMonitorEntity.Srvicenameid);
           db.AddInParameter(dbCommand, "MonitorName", DbType.String, InvMonitorEntity.MonitorName);
           db.AddInParameter(dbCommand, "ModelNo", DbType.String, InvMonitorEntity.ModelNo);
           db.AddInParameter(dbCommand, "SerialNo", DbType.String, InvMonitorEntity.SerialNo);
           db.AddInParameter(dbCommand, "PurchDate", DbType.String, InvMonitorEntity.PurchDate);
           db.AddInParameter(dbCommand, "DeptID", DbType.String, InvMonitorEntity.DeptID);
           db.AddInParameter(dbCommand, "EmpID", DbType.String, InvMonitorEntity.EmpID);
           db.AddInParameter(dbCommand, "DistDate", DbType.String, InvMonitorEntity.DistDate);
          // db.AddInParameter(dbCommand, "Description", DbType.String, InvMonitorEntity.Description);

           db.ExecuteNonQuery(dbCommand, transaction);
           return true;
       }
       public bool UpdateInvMonitorInfo(MonitorDetailsEntity InvMonitorEntity, Database db, DbTransaction transaction)
       {
           string sql = " UPDATE [ITInventory].[dbo].[INV_MonitorDetails] set MonitorID=@MonitorID, MonitorName=@MonitorName, ModelNo=@ModelNo, SerialNo=@SerialNo, PurchDate=@PurchDate,  DeptID= @DeptID, EMPID= @EMPID, DistDate=@DistDate WHERE MonitorID=@MonitorID ";
          
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
                    
           /// //////////**************************  MONITOR  *****************************************
           db.AddInParameter(dbCommand, "MonitorID", DbType.String, InvMonitorEntity.MonitorID);
           db.AddInParameter(dbCommand, "MonitorName", DbType.String, InvMonitorEntity.MonitorName);
           db.AddInParameter(dbCommand, "ModelNo", DbType.String, InvMonitorEntity.ModelNo);
           db.AddInParameter(dbCommand, "SerialNo", DbType.String, InvMonitorEntity.SerialNo);
           db.AddInParameter(dbCommand, "PurchDate", DbType.String, InvMonitorEntity.PurchDate);
           db.AddInParameter(dbCommand, "DeptID", DbType.String, InvMonitorEntity.DeptID);
           db.AddInParameter(dbCommand, "EMPID", DbType.String, InvMonitorEntity.EmpID);
           db.AddInParameter(dbCommand, "DistDate", DbType.String, InvMonitorEntity.DistDate);
          
           db.ExecuteNonQuery(dbCommand, transaction);          
           return true;
       }
       public bool DeleteMonitorInfoById(object param, Database db, DbTransaction transaction)
       {
           string sql = "DELETE FROM ITInventory.dbo.INV_MonitorDetails WHERE MonitorID=@MonitorID";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           db.AddInParameter(dbCommand, "MonitorID", DbType.String, param);

           db.ExecuteNonQuery(dbCommand, transaction);
           return true;
       }

    }
}
