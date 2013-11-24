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
   public partial class AllDeviceinfoDAL
    {
       public DataTable GetAllDeviceinfoRecord(InvInventorydetailsEntity obj, object param)
       {
           //if (obj.Location == "HLNT" || obj.Location == "HLBD" || obj.Location == "HLAP")
           //{
           //    Database db = DatabaseFactory.CreateDatabase();

           //    //string sql = "SELECT ROW_NUMBER() OVER(ORDER BY AccountCode) SLNo, A.Office, A.Proposed, A.AccountID, A.AccountCode, A.BrandModel, A.Category, A.Configuration, A.SerialNo, A.Location, A.DeptID, A.EMPID, A.EMPID as EMPNAME, A.PurchDate, A.Remark, B.SerialNo AS MonitorID, C.SerialNo AS UPSID, A.Team, A.Status, A.HostName, A.ITemNo, A.DeviceID, (DATEDIFF(MONTH, A.PurchDate, GETDATE())/12) as Y, (DATEDIFF(MONTH, A.PurchDate, GETDATE())%12) as M, DATEDIFF( dd, DATEADD( mm, DATEDIFF( mm, GETDATE(), A.PurchDate), GETDATE()), A.PurchDate) as D";
           //    string sql = "SELECT ENumber, A.Office, A.Proposed, A.AccountID, A.AccountCode, A.BrandModel, A.Category, A.Configuration, A.SerialNo, A.Location, A.DeptID, A.EMPID, A.EMPID as EMPNAME, A.PurchDate, A.Remark, B.SerialNo AS MonitorID, C.SerialNo AS UPSID, A.Team, A.Status, A.HostName, A.ITemNo, A.DeviceID, (DATEDIFF(MONTH, A.PurchDate, GETDATE())/12) as Y, (DATEDIFF(MONTH, A.PurchDate, GETDATE())%12) as M, DATEDIFF( dd, DATEADD( mm, DATEDIFF( mm, GETDATE(), A.PurchDate), GETDATE()), A.PurchDate) as D";
           //    sql = sql + " FROM ITInventory.dbo.INV_InventoryInfo as A Left Join ";
           //    sql = sql + " ITInventory.dbo.INV_MonitorDetails AS B on A.EMPID=B.EMPID Left Join ";
           //    sql = sql + " ITInventory.dbo.INV_UPSDetails AS C on A.EMPID=C.EMPID WHERE A.Location=@Location";
           //    DbCommand dbCommand = db.GetSqlStringCommand(sql);
           //    db.AddInParameter(dbCommand, "Location", DbType.String, obj.Location);
           //    DataSet ds = db.ExecuteDataSet(dbCommand);
           //    return ds.Tables[0];
           //}
           //else
           //{
               Database db = DatabaseFactory.CreateDatabase();

               //string sql = "SELECT ROW_NUMBER() OVER(ORDER BY AccountCode) SLNo, A.Office, A.Proposed, A.AccountID, A.AccountCode, A.BrandModel, A.Category, A.Configuration, A.SerialNo, A.Location, A.DeptID, A.EMPID, A.EMPID as EMPNAME, A.PurchDate, A.Remark, B.SerialNo AS MonitorID, C.SerialNo AS UPSID, A.Team, A.Status, A.HostName, A.ITemNo, A.DeviceID, (DATEDIFF(MONTH, A.PurchDate, GETDATE())/12) as Y, (DATEDIFF(MONTH, A.PurchDate, GETDATE())%12) as M, DATEDIFF( dd, DATEADD( mm, DATEDIFF( mm, GETDATE(), A.PurchDate), GETDATE()), A.PurchDate) as D";
               string sql = "SELECT ENumber, A.Office, A.Proposed, A.AccountID, A.AccountCode, A.BrandModel, A.Category, A.Configuration, A.SerialNo, A.Location, A.DeptID, A.EMPID, A.EMPID as EMPNAME, A.PurchDate, A.Remark, B.SerialNo AS MonitorID, C.SerialNo AS UPSID, A.Team, A.Status, A.HostName, A.ITemNo, A.DeviceID, (DATEDIFF(MONTH, A.PurchDate, GETDATE())/12) as Y, (DATEDIFF(MONTH, A.PurchDate, GETDATE())%12) as M, DATEDIFF( dd, DATEADD( mm, DATEDIFF( mm, GETDATE(), A.PurchDate), GETDATE()), A.PurchDate) as D";
               sql = sql + " FROM ITInventory.dbo.INV_InventoryInfo as A Left Join ";
               sql = sql + " ITInventory.dbo.INV_MonitorDetails AS B on A.EMPID=B.EMPID Left Join ";
               sql = sql + " ITInventory.dbo.INV_UPSDetails AS C on A.EMPID=C.EMPID WHERE A.Location=LEFT(Location,4)";
               DbCommand dbCommand = db.GetSqlStringCommand(sql);
               //db.AddInParameter(dbCommand, "Location", DbType.String, obj.Location);
               DataSet ds = db.ExecuteDataSet(dbCommand);
               return ds.Tables[0];
          // }
       }
     
    }
}
