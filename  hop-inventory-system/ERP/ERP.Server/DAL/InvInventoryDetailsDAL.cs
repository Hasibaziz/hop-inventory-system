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
   public partial class InvInventoryDetailsDAL
    {
       public DataTable GetInventoryDetailsRecord(InvInventorydetailsEntity obj, object param)
       {
           if ((obj.Location == "HLNT" && obj.Userstatus == "Normal") || (obj.Location == "HLBD" && obj.Userstatus == "Normal") || (obj.Location == "HLAP" && obj.Userstatus == "Normal"))
           //if (obj.Location == "HLNT" || obj.Location == "HLBD" || obj.Location == "HLAP")
           {
               Database db = DatabaseFactory.CreateDatabase();
               string STR = "22fc4927-cf7c-4e72-8575-2780eec97126";
               //string sql = "SELECT ROW_NUMBER() OVER(ORDER BY AccountCode) SLNO, A.Office, A.Proposed, A.AccountID, A.AccountCode, A.BrandModel, A.Category, A.Configuration, A.SerialNo, A.Location, A.DeptID, A.EMPID, A.EMPID AS EMPNAME, convert(date, A.PurchDate,103) as PurchDate, A.Remark, B.SerialNo AS MonitorID, C.SerialNo AS UPSID, A.Team, A.Status, A.HostName, A.ITemNo, A.DeviceID";
               string sql = "SELECT ENumber, A.Office, A.Proposed, A.AccountID, A.AccountCode, A.BrandModel, A.Category, A.Configuration, A.SerialNo, A.Location, A.DeptID, A.EMPID, A.EMPID AS EMPNAME, convert(date, A.PurchDate,103) as PurchDate, A.Remark, B.SerialNo AS MonitorID, C.SerialNo AS UPSID, A.Team, A.Status, A.HostName, A.ITemNo, A.DeviceID";
               sql = sql + " FROM ITInventory.dbo.INV_InventoryInfo as A LEFT OUTER JOIN";
               sql = sql + " ITInventory.dbo.INV_MonitorDetails AS B ON A.EMPID=B.EMPID";
               sql = sql + " LEFT OUTER JOIN ITInventory.dbo.INV_UPSDetails AS C ON A.EMPID=C.EMPID";
               sql = sql + " WHERE  A.DeviceID='" + STR + "' and A.Location=@Location ORDER BY A.EMPID ASC";
               DbCommand dbCommand = db.GetSqlStringCommand(sql);
               db.AddInParameter(dbCommand, "Location", DbType.String, obj.Location);
               DataSet ds = db.ExecuteDataSet(dbCommand);
               return ds.Tables[0];
           }
           //else if ((obj.Location == "HLNT" && obj.Userstatus == "Normal") || (obj.Location == "HLBD" && obj.Userstatus == "Normal") || (obj.Location == "HLAP" && obj.Userstatus == "Normal"))
           //{
           //    Database db = DatabaseFactory.CreateDatabase();
           //    string STR = "22fc4927-cf7c-4e72-8575-2780eec97126";
           //    string sql = "SELECT A.Office, A.Proposed, A.AccountID, A.AccountCode, A.BrandModel, A.Category, A.Configuration, A.SerialNo, A.Location, A.DeptID, A.EMPID, A.EMPID AS EMPNAME, A.PurchDate, A.Remark, B.SerialNo AS MonitorID, C.SerialNo AS UPSID, A.Team, A.Status, A.HostName, A.ITemNo, A.DeviceID";
           //    sql = sql + " FROM ITInventory.dbo.INV_InventoryInfo as A LEFT OUTER JOIN";
           //    sql = sql + " ITInventory.dbo.INV_MonitorDetails AS B ON A.EMPID=B.EMPID";
           //    sql = sql + " LEFT OUTER JOIN ITInventory.dbo.INV_UPSDetails AS C ON A.EMPID=C.EMPID";
           //    sql = sql + " WHERE  A.DeviceID='" + STR + "' and A.Location=@Location";
           //    DbCommand dbCommand = db.GetSqlStringCommand(sql);
           //    db.AddInParameter(dbCommand, "Location", DbType.String, obj.Location);
           //    DataSet ds = db.ExecuteDataSet(dbCommand);
           //    return ds.Tables[0];
           //}
           else
           {
               Database db = DatabaseFactory.CreateDatabase();
               string STR = "22fc4927-cf7c-4e72-8575-2780eec97126";
               //string sql = "SELECT ROW_NUMBER() OVER(ORDER BY AccountCode) SLNO, A.Office, A.Proposed, A.AccountID, A.AccountCode, A.BrandModel, A.Category, A.Configuration, A.SerialNo, A.Location, A.DeptID, A.EMPID, A.EMPID AS EMPNAME, A.PurchDate, A.Remark, B.SerialNo AS MonitorID, C.SerialNo AS UPSID, A.Team, A.Status, A.HostName, A.ITemNo, A.DeviceID";
               string sql = "SELECT ENumber, A.Office, A.Proposed, A.AccountID, A.AccountCode, A.BrandModel, A.Category, A.Configuration, A.SerialNo, A.Location, A.DeptID, A.EMPID, A.EMPID AS EMPNAME, A.PurchDate, A.Remark, B.SerialNo AS MonitorID, C.SerialNo AS UPSID, A.Team, A.Status, A.HostName, A.ITemNo, A.DeviceID";
               sql = sql + " FROM ITInventory.dbo.INV_InventoryInfo as A LEFT OUTER JOIN";
               sql = sql + " ITInventory.dbo.INV_MonitorDetails AS B ON A.EMPID=B.EMPID";
               sql = sql + " LEFT OUTER JOIN ITInventory.dbo.INV_UPSDetails AS C ON A.EMPID=C.EMPID";
               sql = sql + " WHERE  A.DeviceID='" + STR + "' and A.Location=LEFT(A.Location,4) ORDER BY A.EMPID ASC";
               DbCommand dbCommand = db.GetSqlStringCommand(sql);
               db.AddInParameter(dbCommand, "Location", DbType.String, obj.Location);
               DataSet ds = db.ExecuteDataSet(dbCommand);
               return ds.Tables[0]; 
           }
       }
       public bool SaveInventoryDetails(InvInventorydetailsEntity InvInvEntity, Database db, DbTransaction transaction)
       {

           string sql = "INSERT INTO ITInventory.dbo.INV_InventoryInfo ( AccountCode, ENumber, BrandModel, Category, Configuration, SerialNo, Location, DeptID, EMPID, PurchDate, Remark, Team, Status, HostName, ITemNo, DeviceID, Office, Proposed) VALUES (  @AccountCode, @ENumber, @BrandModel, @Category, @Configuration, @SerialNo, @Location, @DeptID, @EMPID, @PurchDate, @Remark, @Team, @Status, @HostName, @ITemNo, @DeviceID, @Office, @Proposed )";
           string sql01 = "INSERT INTO [ITInventory].[dbo].[INV_MonitorDetails](MonitorName, ModelNo, SerialNo, PurchDate, DeptID, EmpID, DistDate) VALUES (@MonitorName, @MModelNo, @MSerialNo, @MPurchDate, @DeptID, @EmpID, @MDistDate)";
           string sql02 = "INSERT INTO [ITInventory].[dbo].[INV_UPSDetails]( UPSName,ModelNo,SerialNo,PurchDate,DeptID,EmpID,DistDate) VALUES (@UPSName, @UModelNo, @USerialNo, @UPurchDate, @DeptID, @EmpID, @UDistDate)";
           string sql03 = "INSERT INTO [ITInventory].[dbo].[INV_Userinfo](AccountCode, UserID, Modifydate) VALUES (@AccountCode, @UserID, @Modifydate)";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DbCommand dbCommand01 = db.GetSqlStringCommand(sql01);
           DbCommand dbCommand02 = db.GetSqlStringCommand(sql02);
           DbCommand dbCommand03 = db.GetSqlStringCommand(sql03);

           db.AddInParameter(dbCommand, "AccountCode", DbType.String, InvInvEntity.AccountCode);
           db.AddInParameter(dbCommand, "ENumber", DbType.String, InvInvEntity.ENumber);
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
           db.AddInParameter(dbCommand, "Office", DbType.String, InvInvEntity.Office);
           db.AddInParameter(dbCommand, "Proposed", DbType.String, InvInvEntity.Proposed);
/// //////////**************************  MONITOR  *****************************************
           db.AddInParameter(dbCommand01, "MonitorName", DbType.String, InvInvEntity.MonitorName);
           db.AddInParameter(dbCommand01, "MModelNo", DbType.String, InvInvEntity.MModelNo);
           db.AddInParameter(dbCommand01, "MSerialNo", DbType.String, InvInvEntity.MSerialNo);
           db.AddInParameter(dbCommand01, "MPurchDate", DbType.String, InvInvEntity.MPurchDate);
           db.AddInParameter(dbCommand01, "DeptID", DbType.String, InvInvEntity.DeptID);
           db.AddInParameter(dbCommand01, "EMPID", DbType.String, InvInvEntity.EMPID);
           db.AddInParameter(dbCommand01, "MDistDate", DbType.String, InvInvEntity.MDistDate);
/////////********************************** UPS *************************************************
           db.AddInParameter(dbCommand02, "UPSName", DbType.String, InvInvEntity.UPSName);
           db.AddInParameter(dbCommand02, "UModelNo", DbType.String, InvInvEntity.UModelNo);
           db.AddInParameter(dbCommand02, "USerialNo", DbType.String, InvInvEntity.USerialNo);
           db.AddInParameter(dbCommand02, "UPurchDate", DbType.String, InvInvEntity.UPurchDate);
           db.AddInParameter(dbCommand02, "DeptID", DbType.String, InvInvEntity.DeptID);
           db.AddInParameter(dbCommand02, "EMPID", DbType.String, InvInvEntity.EMPID);
           db.AddInParameter(dbCommand02, "UDistDate", DbType.String, InvInvEntity.UDistDate);

           db.AddInParameter(dbCommand03, "AccountCode", DbType.String, InvInvEntity.AccountCode);
           db.AddInParameter(dbCommand03, "UserID", DbType.String, InvInvEntity.UserID);
           db.AddInParameter(dbCommand03, "Modifydate", DbType.String, InvInvEntity.Modifydate);

           db.ExecuteNonQuery(dbCommand, transaction);
           db.ExecuteNonQuery(dbCommand01, transaction);
           db.ExecuteNonQuery(dbCommand02, transaction);
           db.ExecuteNonQuery(dbCommand03, transaction);
           return true;
       }
       public bool UpdateInventoryDetails(InvInventorydetailsEntity InvInvEntity, Database db, DbTransaction transaction)
       {
           string sql = " UPDATE ITInventory.dbo.INV_InventoryInfo SET AccountID= @AccountID, AccountCode= @AccountCode, ENumber=@ENumber, BrandModel= @BrandModel, Category= @Category, Configuration= @Configuration, SerialNo= @SerialNo, Location= @Location, DeptID= @DeptID, EMPID= @EMPID, PurchDate= CONVERT(DATE, @PurchDate, 103), Remark= @Remark,  Team= @Team,  Status= @Status,  HostName= @HostName,  ITemNo= @ITemNo,  DeviceID= @DeviceID, Office=@Office, Proposed=@Proposed WHERE AccountID=@AccountID";
           string sql01 = " UPDATE [ITInventory].[dbo].[INV_MonitorDetails] set MonitorID=@MonitorID, MonitorName=@MonitorName, ModelNo=@MModelNo, SerialNo=@MSerialNo, PurchDate=CONVERT(DATE, @MPurchDate,103),  DeptID= @DeptID, EMPID= @EMPID, DistDate=CONVERT(DATE, @MDistDate,103) WHERE MonitorID=@MonitorID ";
           string sql02 = " UPDATE [ITInventory].[dbo].[INV_UPSDetails] set UPSID=@UPSID, UPSName=@UPSName, ModelNo=@UModelNo, SerialNo=@USerialNo, PurchDate=CONVERT(DATE, @UPurchDate,103),  DeptID= @DeptID, EMPID= @EMPID, DistDate=CONVERT(DATE, @UDistDate,103) WHERE UPSID=@UPSID ";
           string sql03 = "INSERT INTO [ITInventory].[dbo].[INV_Userinfo](AccountCode, UserID, Modifydate) VALUES (@AccountCode, @UserID, @Modifydate)";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DbCommand dbCommand01 = db.GetSqlStringCommand(sql01);
           DbCommand dbCommand02 = db.GetSqlStringCommand(sql02);
           DbCommand dbCommand03 = db.GetSqlStringCommand(sql03);

           db.AddInParameter(dbCommand, "AccountID", DbType.String, InvInvEntity.AccountID);
           db.AddInParameter(dbCommand, "AccountCode", DbType.String, InvInvEntity.AccountCode);
           db.AddInParameter(dbCommand, "ENumber", DbType.String, InvInvEntity.ENumber);
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
           db.AddInParameter(dbCommand, "Office", DbType.String, InvInvEntity.Office);
           db.AddInParameter(dbCommand, "Proposed", DbType.String, InvInvEntity.Proposed);
           /// //////////**************************  MONITOR  *****************************************
           db.AddInParameter(dbCommand01, "MonitorID", DbType.String, InvInvEntity.MonitorID);
           db.AddInParameter(dbCommand01, "MonitorName", DbType.String, InvInvEntity.MonitorName);
           db.AddInParameter(dbCommand01, "MModelNo", DbType.String, InvInvEntity.MModelNo);
           db.AddInParameter(dbCommand01, "MSerialNo", DbType.String, InvInvEntity.MSerialNo);
           db.AddInParameter(dbCommand01, "MPurchDate", DbType.String, InvInvEntity.MPurchDate);
           db.AddInParameter(dbCommand01, "DeptID", DbType.String, InvInvEntity.DeptID);
           db.AddInParameter(dbCommand01, "EMPID", DbType.String, InvInvEntity.EMPID);
           db.AddInParameter(dbCommand01, "MDistDate", DbType.String, InvInvEntity.MDistDate);
           /////////********************************** UPS *************************************************
           db.AddInParameter(dbCommand02, "UPSID", DbType.String, InvInvEntity.UPSID);
           db.AddInParameter(dbCommand02, "UPSName", DbType.String, InvInvEntity.UPSName);
           db.AddInParameter(dbCommand02, "UModelNo", DbType.String, InvInvEntity.UModelNo);
           db.AddInParameter(dbCommand02, "USerialNo", DbType.String, InvInvEntity.USerialNo);
           db.AddInParameter(dbCommand02, "UPurchDate", DbType.String, InvInvEntity.UPurchDate);
           db.AddInParameter(dbCommand02, "DeptID", DbType.String, InvInvEntity.DeptID);
           db.AddInParameter(dbCommand02, "EMPID", DbType.String, InvInvEntity.EMPID);
           db.AddInParameter(dbCommand02, "UDistDate", DbType.String, InvInvEntity.UDistDate);


           db.AddInParameter(dbCommand03, "AccountCode", DbType.String, InvInvEntity.AccountCode);
           db.AddInParameter(dbCommand03, "UserID", DbType.String, InvInvEntity.UserID);
           db.AddInParameter(dbCommand03, "Modifydate", DbType.String, InvInvEntity.Modifydate);

           db.ExecuteNonQuery(dbCommand, transaction);
           db.ExecuteNonQuery(dbCommand01, transaction);
           db.ExecuteNonQuery(dbCommand02, transaction);
           db.ExecuteNonQuery(dbCommand03, transaction);
           return true;
       }
       public bool DeleteInventoryDetailsById(object param, Database db, DbTransaction transaction)
       {
           string sql = "DELETE Monitor from ITInventory.dbo.INV_MonitorDetails  Monitor INNER JOIN ITInventory.dbo.INV_InventoryInfo  INV ON Monitor.EmpID=INV.EmpID WHERE AccountID=@AccountID";
           string sql01 = "DELETE UPS from [ITInventory].[dbo].[INV_UPSDetails]  UPS INNER JOIN ITInventory.dbo.INV_InventoryInfo  INV ON UPS.EmpID=INV.EmpID WHERE AccountID=@AccountID";
           string sql02 = "DELETE INV from ITInventory.dbo.INV_InventoryInfo  INV WHERE AccountID=@AccountID";
           
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DbCommand dbCommand01 = db.GetSqlStringCommand(sql01);
           DbCommand dbCommand02 = db.GetSqlStringCommand(sql02);

           db.AddInParameter(dbCommand, "AccountID", DbType.String, param);
           db.AddInParameter(dbCommand01, "AccountID", DbType.String, param);
           db.AddInParameter(dbCommand02, "AccountID", DbType.String, param);

           db.ExecuteNonQuery(dbCommand, transaction);
           db.ExecuteNonQuery(dbCommand01, transaction);
           db.ExecuteNonQuery(dbCommand02, transaction);
           return true;
       }
       public DataTable GetAllInvEmployeeRecordByEmpId(InvInventorydetailsEntity InvEntity, object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           //string sql = "SELECT DeptID, EmpNo FROM ITInventory.dbo.INV_EmployeeInfo WHERE DeptID=@DeptID";
           string sql = "SELECT EmpID, EmpNo FROM ITInventory.dbo.INV_EmployeeInfo WHERE DeptID='" + InvEntity.DeptID + "' ORDER BY EmpNo ASC";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           //db.AddInParameter(dbCommand, "DeptID", DbType.String, EmpEntity.EmpID);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }
       public DataTable GetSingleEmpDetailsRecordById(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT A.MonitorID AS MonitorID, A.MonitorName as MonitorName, A.ModelNo AS MModelNo, A.SerialNo AS MSerialNo, A.PurchDate AS MPurchDate, A.DistDate AS MDistDate, B.UPSID AS UPSID, B.UPSName as UPSName, B.ModelNo AS UModelNo, B.SerialNo AS USerialNo, B.PurchDate AS UPurchDate, B.DistDate AS UDistDate ";
           sql = sql + "FROM ITInventory.dbo.INV_MonitorDetails AS A FULL OUTER JOIN ITInventory.dbo.INV_UPSDetails AS B ON A.EmpID=B.EmpID ";
           sql = sql + "WHERE A.EmpID=@EmpID";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           db.AddInParameter(dbCommand, "EmpID", DbType.String, param.ToString());
           //db.AddInParameter(dbCommand, "DeptID", DbType.String, param.ToString());
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }
       public DataTable GetInventoryDetailsRecordByID(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           string STR = "22fc4927-cf7c-4e72-8575-2780eec97126";
           //string sql = "SELECT AccountID, AccountCode, BrandModel, Category, Configuration, SerialNo, Location, DeptID, EMPID, PurchDate, Remark, Team, Status, HostName, ITemNo FROM ";
           //sql = sql + " ITInventory.dbo.INV_InventoryInfo WHERE AccountID=@AccountID";
           //sql = sql + "(SELECT A.MonitorID AS MonitorID, A.MonitorName as MonitorName, A.ModelNo AS MModelNo, A.SerialNo AS MSerialNo, A.PurchDate AS MPurchDate, A.DistDate AS MDistDate, B.UPSID AS UPSID, B.UPSName as UPSName, B.ModelNo AS UModelNo, B.SerialNo AS USerialNo, B.PurchDate AS UPurchDate, B.DistDate AS UDistDate FROM ITInventory.dbo.INV_MonitorDetails AS A, ITInventory.dbo.INV_UPSDetails AS B, ITInventory.dbo.INV_InventoryInfo AS C WHERE A.EmpID=B.EmpID AND A.EmpID=C.EmpID)";
           string sql = " SELECT A.Office, A.Proposed, A.AccountID as AccountID, A.AccountCode as AccountCode, A.BrandModel AS BrandModel, A.Category AS Category, A.Configuration AS Configuration, A.SerialNo AS SerialNo, A.Location AS Location, A.DeptID AS DeptID, A.EMPID AS EMPID, A.PurchDate AS PurchDate, A.Remark AS Remark, A.Team AS Team, A.Status AS Status, A.HostName AS HostName, A.ITemNo  AS ITemNo, A.DeviceID";
           sql = sql + " ,C.MonitorID AS MonitorID, C.MonitorName as MonitorName, C.ModelNo AS MModelNo, C.SerialNo AS MSerialNo, C.PurchDate AS MPurchDate, C.DistDate AS MDistDate";
           sql = sql + " ,B.UPSID AS UPSID, B.UPSName as UPSName, B.ModelNo AS UModelNo, B.SerialNo AS USerialNo, B.PurchDate AS UPurchDate, B.DistDate AS UDistDate  ";
           sql = sql + "FROM ITInventory.dbo.INV_InventoryInfo AS A Left outer join ITInventory.dbo.INV_UPSDetails AS B on A.EmpID=B.EmpID left outer join ITInventory.dbo.INV_MonitorDetails  AS C on  A.EmpID=C.EmpID";
           sql = sql + " WHERE A.DeviceID='" + STR + "'  AND A.AccountID=@AccountID";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           db.AddInParameter(dbCommand, "AccountID", DbType.String, param.ToString());
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }

       public DataTable GetDeplicateRecord(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT EMPID, AccountCode FROM [ITInventory].[dbo].[Inv_InventoryInfo] WHERE AccountCode=@AccountCode";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           db.AddInParameter(dbCommand, "AccountCode", DbType.String, param.ToString());
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }


       public DataTable GetOLDInfoRecord(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT OLDID, CPUID, CPUCONFIG, MONITORID, UPSID, EMPID, Dateofplace FROM ITInventory.dbo.Inv_OLDInfo where EMPID=@EMPID";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           db.AddInParameter(dbCommand, "EmpID", DbType.String, param.ToString());
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }

/// <summary>
/// //////////************************************** Search Account Code wise ******************/////////////////////////////
/// </summary>
/// <param name="obj"></param>
/// <param name="param"></param>
/// <returns></returns>
       public DataTable GetSingleInventoryRecordById(InvInventorydetailsEntity obj, object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           string STR = "22fc4927-cf7c-4e72-8575-2780eec97126";
           if (obj.AccountCode !="" )
           {
               string sql = "SELECT A.Office, A.Proposed, A.AccountID, A.AccountCode, A.BrandModel, A.Category, A.Configuration, A.SerialNo, A.Location, A.DeptID, A.EMPID, A.EMPID AS EMPNAME, convert(date, A.PurchDate,103) as PurchDate, A.Remark, B.SerialNo AS MonitorID, C.SerialNo AS UPSID, A.Team, A.Status, A.HostName, A.ITemNo, A.DeviceID";
               sql = sql + " FROM ITInventory.dbo.INV_InventoryInfo as A LEFT OUTER JOIN";
               sql = sql + " ITInventory.dbo.INV_MonitorDetails AS B ON A.EMPID=B.EMPID";
               sql = sql + " LEFT OUTER JOIN ITInventory.dbo.INV_UPSDetails AS C ON A.EMPID=C.EMPID";
               sql = sql + " LEFT OUTER JOIN ITInventory.dbo.INV_EmployeeInfo AS E ON A.EMPID=E.EMPID";
               sql = sql + " LEFT OUTER JOIN ITInventory.dbo.INV_Department AS D ON A.DeptID=D.DeptID";
               sql = sql + " WHERE  A.DeviceID='" + STR + "' and A.Location=LEFT(A.Location,4) AND A.AccountCode='" + obj.AccountCode + "'  ";
               DbCommand dbCommand = db.GetSqlStringCommand(sql);
               DataSet ds = db.ExecuteDataSet(dbCommand);
               return ds.Tables[0];
           }
           else if(obj.EMPNAME!="")
           {
               string sql = "SELECT A.Office, A.Proposed, A.AccountID, A.AccountCode, A.BrandModel, A.Category, A.Configuration, A.SerialNo, A.Location, A.DeptID, A.EMPID, A.EMPID AS EMPNAME, convert(date, A.PurchDate,103) as PurchDate, A.Remark, B.SerialNo AS MonitorID, C.SerialNo AS UPSID, A.Team, A.Status, A.HostName, A.ITemNo, A.DeviceID";
               sql = sql + " FROM ITInventory.dbo.INV_InventoryInfo as A LEFT OUTER JOIN";
               sql = sql + " ITInventory.dbo.INV_MonitorDetails AS B ON A.EMPID=B.EMPID";
               sql = sql + " LEFT OUTER JOIN ITInventory.dbo.INV_UPSDetails AS C ON A.EMPID=C.EMPID";
               sql = sql + " LEFT OUTER JOIN ITInventory.dbo.INV_EmployeeInfo AS E ON A.EMPID=E.EMPID";
               sql = sql + " LEFT OUTER JOIN ITInventory.dbo.INV_Department AS D ON A.DeptID=D.DeptID";
               sql = sql + " WHERE  A.DeviceID='" + STR + "' and A.Location=LEFT(A.Location,4) AND E.EmpName like '%" + obj.EMPNAME + "%' ";
               DbCommand dbCommand = db.GetSqlStringCommand(sql);
               DataSet ds = db.ExecuteDataSet(dbCommand);
               return ds.Tables[0];
           }
           else
           {
              object[] parameters = new object[] { obj.Location, obj.DEPTNAME };
              DbCommand dbCommand = db.GetStoredProcCommand("spGetLoctionDeptBySearch", parameters);
              DataSet ds = db.ExecuteDataSet(dbCommand);      
              return ds.Tables[0];
           }          
       }

       public DataTable GetAutonumber(object param)
       {
           //InvInventorydetailsEntity Loc = (InvInventorydetailsEntity)param;
           Database db = DatabaseFactory.CreateDatabase();
           //string sql = "SELECT MAX(ENumber), Location FROM ITInventory.dbo.INV_InventoryInfo where Location='"+Loc.Location+"' ";
           string sql = "SELECT MAX(ENumber) as ENumber, Location FROM ITInventory.dbo.INV_InventoryInfo where Location=@Location GROUP BY Location ";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           db.AddInParameter(dbCommand, "Location", DbType.String, param.ToString());
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }
       

    }
}
