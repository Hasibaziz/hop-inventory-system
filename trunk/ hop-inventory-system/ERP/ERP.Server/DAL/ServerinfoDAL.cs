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
   public partial class ServerinfoDAL
    {
       public DataTable GetServerinfoRecord(InvInventorydetailsEntity obj, object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           string STR = "1a7d727d-d362-4476-8813-54daa3953d56";
           string sql = "SELECT A.AccountID, A.AccountCode, A.BrandModel, A.Category, A.Configuration, A.SerialNo, A.Location, A.DeptID, A.EMPID, A.EMPID AS EMPNAME, A.PurchDate, A.Remark, A.Team, A.Status, A.HostName, A.ITemNo, A.DeviceID";
           sql = sql + " FROM ITInventory.dbo.INV_InventoryInfo as A WHERE DeviceID='" + STR + "' and A.Location=@Location ORDER BY EmpID ASC";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           db.AddInParameter(dbCommand, "Location", DbType.String, obj.Location);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }
       public DataTable GetServerinfoRecordByID(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           string STR = "1a7d727d-d362-4476-8813-54daa3953d56";
           string sql = " SELECT D.AccountID as AccountID, D.AccountCode as AccountCode, D.BrandModel AS BrandModel, D.Category AS Category, D.Configuration AS Configuration, D.SerialNo AS SerialNo, D.Location AS Location, D.DeptID AS DeptID, D.EMPID AS EMPID, D.PurchDate AS PurchDate, D.Remark AS Remark, D.Team AS Team, D.Status AS Status, D.HostName AS HostName, D.ITemNo  AS ITemNo, D.DeviceID,";
           sql = sql + " A.MonitorID AS MonitorID, A.MonitorName as MonitorName, A.ModelNo AS MModelNo, A.SerialNo AS MSerialNo, A.PurchDate AS MPurchDate, A.DistDate AS MDistDate";
           sql = sql + " FROM ITInventory.dbo.INV_InventoryInfo AS D left outer join ITInventory.dbo.INV_MonitorDetails AS A ON A.EmpID=D.EmpID";
           sql = sql + " where D.DeviceID='" + STR + "' AND D.AccountID=@AccountID";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           db.AddInParameter(dbCommand, "AccountID", DbType.String, param.ToString());
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }
       public bool SaveServerDetails(InvInventorydetailsEntity InvInvEntity, Database db, DbTransaction transaction)
       {
           string sql = "INSERT INTO ITInventory.dbo.INV_InventoryInfo ( AccountCode, BrandModel, Category, Configuration, SerialNo, Location, DeptID, EMPID, PurchDate, Remark, Team, Status, HostName, ITemNo, DeviceID) VALUES (  @AccountCode, @BrandModel, @Category, @Configuration, @SerialNo, @Location, @DeptID, @EMPID, @PurchDate, @Remark, @Team, @Status, @HostName, @ITemNo, @DeviceID )";
           string sql01 = "INSERT INTO [ITInventory].[dbo].[INV_MonitorDetails](MonitorName, ModelNo, SerialNo, PurchDate, DeptID, EmpID, DistDate) VALUES (@MonitorName, @MModelNo, @MSerialNo, @MPurchDate, @DeptID, @EmpID, @MDistDate)";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DbCommand dbCommand01 = db.GetSqlStringCommand(sql01);

           db.AddInParameter(dbCommand, "AccountCode", DbType.String, InvInvEntity.AccountCode);
           db.AddInParameter(dbCommand, "BrandModel", DbType.String, InvInvEntity.BrandModel);
           db.AddInParameter(dbCommand, "Category", DbType.String, InvInvEntity.Category);
           db.AddInParameter(dbCommand, "Configuration", DbType.String, InvInvEntity.Configuration);
           db.AddInParameter(dbCommand, "SerialNo", DbType.String, InvInvEntity.SerialNo);
           db.AddInParameter(dbCommand, "Location", DbType.String, InvInvEntity.Location);
           db.AddInParameter(dbCommand, "DeptID", DbType.String, InvInvEntity.DeptID);
           db.AddInParameter(dbCommand, "EMPID", DbType.String, InvInvEntity.EMPID);
           db.AddInParameter(dbCommand, "PurchDate", DbType.String, InvInvEntity.PurchDate);
           db.AddInParameter(dbCommand, "Remark", DbType.String, InvInvEntity.Remark);
           db.AddInParameter(dbCommand, "Team", DbType.String, InvInvEntity.Team);
           db.AddInParameter(dbCommand, "Status", DbType.String, InvInvEntity.Status);
           db.AddInParameter(dbCommand, "HostName", DbType.String, InvInvEntity.HostName);
           db.AddInParameter(dbCommand, "ITemNo", DbType.String, InvInvEntity.ITemNo);
           db.AddInParameter(dbCommand, "DeviceID", DbType.String, InvInvEntity.DeviceID);
           /// //////////**************************  MONITOR  *************************hasib_aziz@yahoo.com****************
           db.AddInParameter(dbCommand01, "MonitorName", DbType.String, InvInvEntity.MonitorName);
           db.AddInParameter(dbCommand01, "MModelNo", DbType.String, InvInvEntity.MModelNo);
           db.AddInParameter(dbCommand01, "MSerialNo", DbType.String, InvInvEntity.MSerialNo);
           db.AddInParameter(dbCommand01, "MPurchDate", DbType.String, InvInvEntity.MPurchDate);
           db.AddInParameter(dbCommand01, "DeptID", DbType.String, InvInvEntity.DeptID);
           db.AddInParameter(dbCommand01, "EMPID", DbType.String, InvInvEntity.EMPID);
           db.AddInParameter(dbCommand01, "MDistDate", DbType.String, InvInvEntity.MDistDate);

           db.ExecuteNonQuery(dbCommand, transaction);
           db.ExecuteNonQuery(dbCommand01, transaction);
           return true;
       }
       public bool UpdateServerDetails(InvInventorydetailsEntity InvInvEntity, Database db, DbTransaction transaction)
       {
           string sql = " UPDATE ITInventory.dbo.INV_InventoryInfo SET AccountID= @AccountID, AccountCode= @AccountCode, BrandModel= @BrandModel, Category= @Category, Configuration= @Configuration, SerialNo= @SerialNo, Location= @Location, DeptID= @DeptID, EMPID= @EMPID, PurchDate=CONVERT(DATE, @PurchDate, 103), Remark= @Remark,  Team= @Team,  Status= @Status,  HostName= @HostName,  ITemNo= @ITemNo,  DeviceID= @DeviceID WHERE AccountID=@AccountID";
           string sql01 = " UPDATE [ITInventory].[dbo].[INV_MonitorDetails] set MonitorID=@MonitorID, MonitorName=@MonitorName, ModelNo=@MModelNo, SerialNo=@MSerialNo, PurchDate=CONVERT(DATE, @MPurchDate, 103),  DeptID= @DeptID, EMPID= @EMPID, DistDate=CONVERT(DATE, @MDistDate, 103) WHERE MonitorID=@MonitorID ";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DbCommand dbCommand01 = db.GetSqlStringCommand(sql01);


           db.AddInParameter(dbCommand, "AccountID", DbType.String, InvInvEntity.AccountID);
           db.AddInParameter(dbCommand, "AccountCode", DbType.String, InvInvEntity.AccountCode);
           db.AddInParameter(dbCommand, "BrandModel", DbType.String, InvInvEntity.BrandModel);
           db.AddInParameter(dbCommand, "Category", DbType.String, InvInvEntity.Category);
           db.AddInParameter(dbCommand, "Configuration", DbType.String, InvInvEntity.Configuration);
           db.AddInParameter(dbCommand, "SerialNo", DbType.String, InvInvEntity.SerialNo);
           db.AddInParameter(dbCommand, "Location", DbType.String, InvInvEntity.Location);
           db.AddInParameter(dbCommand, "DeptID", DbType.String, InvInvEntity.DeptID);
           db.AddInParameter(dbCommand, "EMPID", DbType.String, InvInvEntity.EMPID);
           db.AddInParameter(dbCommand, "PurchDate", DbType.String, InvInvEntity.PurchDate);
           db.AddInParameter(dbCommand, "Remark", DbType.String, InvInvEntity.Remark);
           //db.AddInParameter(dbCommand, "MonitorID", DbType.String, InvInvEntity.MonitorID);
           //db.AddInParameter(dbCommand, "UPSID", DbType.String, InvInvEntity.UPSID);
           db.AddInParameter(dbCommand, "Team", DbType.String, InvInvEntity.Team);
           db.AddInParameter(dbCommand, "Status", DbType.String, InvInvEntity.Status);
           db.AddInParameter(dbCommand, "HostName", DbType.String, InvInvEntity.HostName);
           db.AddInParameter(dbCommand, "ITemNo", DbType.String, InvInvEntity.ITemNo);
           db.AddInParameter(dbCommand, "DeviceID", DbType.String, InvInvEntity.DeviceID);
           /// //////////**************************  MONITOR  *****************************************
           db.AddInParameter(dbCommand01, "MonitorID", DbType.String, InvInvEntity.MonitorID);
           db.AddInParameter(dbCommand01, "MonitorName", DbType.String, InvInvEntity.MonitorName);
           db.AddInParameter(dbCommand01, "MModelNo", DbType.String, InvInvEntity.MModelNo);
           db.AddInParameter(dbCommand01, "MSerialNo", DbType.String, InvInvEntity.MSerialNo);
           db.AddInParameter(dbCommand01, "MPurchDate", DbType.String, InvInvEntity.MPurchDate);
           db.AddInParameter(dbCommand01, "DeptID", DbType.String, InvInvEntity.DeptID);
           db.AddInParameter(dbCommand01, "EMPID", DbType.String, InvInvEntity.EMPID);
           db.AddInParameter(dbCommand01, "MDistDate", DbType.String, InvInvEntity.MDistDate);

           db.ExecuteNonQuery(dbCommand, transaction);
           db.ExecuteNonQuery(dbCommand01, transaction);
           return true;
           
       }
    }
}
