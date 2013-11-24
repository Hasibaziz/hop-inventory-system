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
   public partial  class LaptopinfoDAL
    {
       public DataTable GetLaptopinfoRecord(InvInventorydetailsEntity obj, object param)
       {
           if ((obj.Location == "HLNT" && obj.Userstatus == "Common") || (obj.Location == "HLBD" && obj.Userstatus == "Common") || (obj.Location == "HLAP" && obj.Userstatus == "Common"))
           {
               Database db = DatabaseFactory.CreateDatabase();
               string STR = "f96ef579-cae8-48f9-96ce-c177d30d7683";
               string sql = "SELECT A.AccountID, A.AccountCode, A.BrandModel, A.Category, A.Configuration, A.SerialNo, A.Location, A.DeptID, A.EMPID,A.EMPID AS EMPNAME, A.PurchDate, A.Remark, A.Team, A.Status, A.HostName, A.ITemNo, A.DeviceID";
               sql = sql + " FROM ITInventory.dbo.INV_InventoryInfo as A WHERE DeviceID='" + STR + "' and A.Location=@Location ORDER BY EmpID ASC ";
               DbCommand dbCommand = db.GetSqlStringCommand(sql);
               db.AddInParameter(dbCommand, "Location", DbType.String, obj.Location);
               DataSet ds = db.ExecuteDataSet(dbCommand);
               return ds.Tables[0];
           }
           else if ((obj.Location == "HLNT" && obj.Userstatus == "Normal") || (obj.Location == "HLBD" && obj.Userstatus == "Normal") || (obj.Location == "HLAP" && obj.Userstatus == "Normal"))
           {
               Database db = DatabaseFactory.CreateDatabase();
               string STR = "f96ef579-cae8-48f9-96ce-c177d30d7683";
               string sql = "SELECT A.AccountID, A.AccountCode, A.BrandModel, A.Category, A.Configuration, A.SerialNo, A.Location, A.DeptID, A.EMPID,A.EMPID AS EMPNAME, A.PurchDate, A.Remark, A.Team, A.Status, A.HostName, A.ITemNo, A.DeviceID";
               sql = sql + " FROM ITInventory.dbo.INV_InventoryInfo as A WHERE DeviceID='" + STR + "' and A.Location=@Location ORDER BY EmpID ASC ";
               DbCommand dbCommand = db.GetSqlStringCommand(sql);
               db.AddInParameter(dbCommand, "Location", DbType.String, obj.Location);
               DataSet ds = db.ExecuteDataSet(dbCommand);
               return ds.Tables[0];
           }
           else 
           {
               Database db = DatabaseFactory.CreateDatabase();
               string STR = "f96ef579-cae8-48f9-96ce-c177d30d7683";
               string sql = "SELECT A.AccountID, A.AccountCode, A.BrandModel, A.Category, A.Configuration, A.SerialNo, A.Location, A.DeptID, A.EMPID,A.EMPID AS EMPNAME, A.PurchDate, A.Remark, A.Team, A.Status, A.HostName, A.ITemNo, A.DeviceID";
               sql = sql + " FROM ITInventory.dbo.INV_InventoryInfo as A WHERE DeviceID='" + STR + "' and A.Location=LEFT(Location,4) ORDER BY EmpID ASC ";
               DbCommand dbCommand = db.GetSqlStringCommand(sql);
               db.AddInParameter(dbCommand, "Location", DbType.String, obj.Location);
               DataSet ds = db.ExecuteDataSet(dbCommand);
               return ds.Tables[0];
           }
       }
       public DataTable GetLaptopDetailsRecordByID(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           string STR = "f96ef579-cae8-48f9-96ce-c177d30d7683";
           string sql = " SELECT D.AccountID as AccountID, D.AccountCode as AccountCode, D.BrandModel AS BrandModel, D.Category AS Category, D.Configuration AS Configuration, D.SerialNo AS SerialNo, D.Location AS Location, D.DeptID AS DeptID, D.EMPID AS EMPID, D.PurchDate AS PurchDate, D.Remark AS Remark, D.Team AS Team, D.Status AS Status, D.HostName AS HostName, D.ITemNo  AS ITemNo, D.DeviceID";
           sql = sql + " FROM ITInventory.dbo.INV_InventoryInfo AS D ";
           sql = sql + " where D.DeviceID='" + STR + "' AND D.AccountID=@AccountID ";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           db.AddInParameter(dbCommand, "AccountID", DbType.String, param.ToString());
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }
       public bool SaveLaptopDetails(InvInventorydetailsEntity InvInvEntity, Database db, DbTransaction transaction)
       {
           string sql = "INSERT INTO ITInventory.dbo.INV_InventoryInfo ( AccountCode, BrandModel, Category, Configuration, SerialNo, Location, DeptID, EMPID, PurchDate, Remark, Team, Status, HostName, ITemNo, DeviceID) VALUES (  @AccountCode, @BrandModel, @Category, @Configuration, @SerialNo, @Location, @DeptID, @EMPID, @PurchDate, @Remark, @Team, @Status, @HostName, @ITemNo, @DeviceID )";
           string sql03 = "INSERT INTO [ITInventory].[dbo].[INV_Userinfo](AccountCode, UserID, Modifydate) VALUES (@AccountCode, @UserID, @Modifydate)";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DbCommand dbCommand03 = db.GetSqlStringCommand(sql03);

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

           db.AddInParameter(dbCommand03, "AccountCode", DbType.String, InvInvEntity.AccountCode);
           db.AddInParameter(dbCommand03, "UserID", DbType.String, InvInvEntity.UserID);
           db.AddInParameter(dbCommand03, "Modifydate", DbType.String, InvInvEntity.Modifydate);

           db.ExecuteNonQuery(dbCommand, transaction);
           db.ExecuteNonQuery(dbCommand03, transaction);
           return true;
       }
       public bool UpdateLaptopDetails(InvInventorydetailsEntity InvInvEntity, Database db, DbTransaction transaction)
       {
           string sql = " UPDATE ITInventory.dbo.INV_InventoryInfo SET AccountID= @AccountID, AccountCode= @AccountCode, BrandModel= @BrandModel, Category= @Category, Configuration= @Configuration, SerialNo= @SerialNo, Location= @Location, DeptID= @DeptID, EMPID= @EMPID, PurchDate= CONVERT(DATE, @PurchDate, 103), Remark= @Remark,  Team= @Team,  Status= @Status,  HostName= @HostName,  ITemNo= @ITemNo,  DeviceID= @DeviceID WHERE AccountID=@AccountID";
           string sql03 = "INSERT INTO [ITInventory].[dbo].[INV_Userinfo](AccountCode, UserID, Modifydate) VALUES (@AccountCode, @UserID, @Modifydate)";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DbCommand dbCommand03 = db.GetSqlStringCommand(sql03);

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

           db.AddInParameter(dbCommand03, "AccountCode", DbType.String, InvInvEntity.AccountCode);
           db.AddInParameter(dbCommand03, "UserID", DbType.String, InvInvEntity.UserID);
           db.AddInParameter(dbCommand03, "Modifydate", DbType.String, InvInvEntity.Modifydate);
           
           db.ExecuteNonQuery(dbCommand, transaction);
           db.ExecuteNonQuery(dbCommand03, transaction);
           return true;
       }
    }
}
