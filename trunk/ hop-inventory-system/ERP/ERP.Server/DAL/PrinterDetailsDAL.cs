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
    public partial class PrinterDetailsDAL
    {
        public DataTable GetPrinterDetailsRecord(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string STR = "cbbcc811-1d1e-4cd6-91d2-682cff76f7ff";
            string sql = "SELECT A.AccountID, A.AccountCode, A.BrandModel, A.Category, A.Configuration, A.SerialNo, A.Location, A.DeptID, A.EMPID, A.EMPID AS EMPNAME, A.PurchDate, A.Remark, A.Team, A.Status, A.HostName, A.ITemNo, A.DeviceID";
            sql = sql + " FROM ITInventory.dbo.INV_InventoryInfo as A  WHERE DeviceID='" + STR + "'";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }
        public DataTable GetPrinterDetailsRecordByID(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string STR = "cbbcc811-1d1e-4cd6-91d2-682cff76f7ff";
            string sql = " SELECT D.AccountID as AccountID, D.AccountCode as AccountCode, D.BrandModel AS BrandModel, D.Category AS Category, D.Configuration AS Configuration, D.SerialNo AS SerialNo, D.Location AS Location, D.DeptID AS DeptID, D.EMPID AS EMPID, D.PurchDate AS PurchDate, D.Remark AS Remark, D.Team AS Team, D.Status AS Status, D.HostName AS HostName, D.ITemNo  AS ITemNo, D.DeviceID,";
            sql = sql + " B.PrinterID, B.PrinterName, B.IPMAC, B.Type, B.PurchDate AS PPurchDate , B.DistDate AS PDistDate, B.Totaluser, B.Dailyppage";
            sql = sql + " FROM ITInventory.dbo.INV_InventoryInfo AS D LEFT JOIN  ITInventory.dbo.INV_PrinterDetails as B ";
            sql = sql + " ON D.AccountCode=B.AccountCode WHERE D.DeviceID='" + STR + "' AND D.AccountID=@AccountCode";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "AccountCode", DbType.String, param.ToString());
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }
        public bool SavePrinterDetails(InvInventorydetailsEntity InvInvEntity, Database db, DbTransaction transaction)
        {
            string sql = "INSERT INTO ITInventory.dbo.INV_InventoryInfo ( AccountCode, BrandModel, Category, Configuration, SerialNo, Location, DeptID, EMPID, PurchDate, Remark, Team, Status, HostName, ITemNo, DeviceID) VALUES (  @AccountCode, @BrandModel, @Category, @Configuration, @SerialNo, @Location, @DeptID, @EMPID, @PurchDate, @Remark, @Team, @Status, @HostName, @ITemNo, @DeviceID )";
            string sql01 = "INSERT INTO [ITInventory].[dbo].[INV_PrinterDetails](AccountCode, PrinterName, IPMAC, PurchDate, DeptID, DistDate, Type, Totaluser, Dailyppage, DeviceID) VALUES (@AccountCode, @PrinterName, @IPMAC, @PPurchDate, @DeptID, @PDistDate, @Type, @Totaluser, @Dailyppage, @DeviceID)";
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
            ///// //////////**************************  MONITOR  *************************hasib_aziz@yahoo.com****************
            db.AddInParameter(dbCommand01, "PrinterName", DbType.String, InvInvEntity.PrinterName);
            db.AddInParameter(dbCommand01, "AccountCode", DbType.String, InvInvEntity.AccountCode);
            db.AddInParameter(dbCommand01, "IPMAC", DbType.String, InvInvEntity.IPMAC);
            db.AddInParameter(dbCommand01, "PPurchDate", DbType.String, InvInvEntity.PPurchDate);
            db.AddInParameter(dbCommand01, "PDistDate", DbType.String, InvInvEntity.PDistDate);
            db.AddInParameter(dbCommand01, "DeptID", DbType.String, InvInvEntity.DeptID);
            db.AddInParameter(dbCommand01, "Type", DbType.String, InvInvEntity.Type);
            db.AddInParameter(dbCommand01, "Totaluser", DbType.String, InvInvEntity.Totaluser);
            db.AddInParameter(dbCommand01, "Dailyppage", DbType.String, InvInvEntity.Dailyppage);
            db.AddInParameter(dbCommand01, "DeviceID", DbType.String, InvInvEntity.DeviceID);

            db.ExecuteNonQuery(dbCommand, transaction);
            db.ExecuteNonQuery(dbCommand01, transaction);
            return true;
        }
        public bool UpdatePrinterDetails(InvInventorydetailsEntity InvInvEntity, Database db, DbTransaction transaction)
        {
            string sql = " UPDATE ITInventory.dbo.INV_InventoryInfo SET AccountID= @AccountID, AccountCode= @AccountCode, BrandModel= @BrandModel, Category= @Category, Configuration= @Configuration, SerialNo= @SerialNo, Location= @Location, DeptID= @DeptID, EMPID= @EMPID, PurchDate=CONVERT(DATE, @PurchDate, 103), Remark= @Remark,  Team= @Team,  Status= @Status,  HostName= @HostName,  ITemNo= @ITemNo,  DeviceID= @DeviceID WHERE AccountID=@AccountID";
            string sql01 = "UPDATE [ITInventory].[dbo].[INV_PrinterDetails] SET  PrinterID=@PrinterID, AccountCode=@AccountCode, PrinterName=@PrinterName, IPMAC=@IPMAC, PurchDate=CONVERT(DATE, @PPurchDate, 103), DeptID=@DeptID, DistDate=CONVERT(DATE, @PDistDate, 103), Type=@Type, Totaluser=@Totaluser, Dailyppage=@Dailyppage, DeviceID=@DeviceID WHERE  PrinterID=@PrinterID";

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
            ///DB.PRINTER *******************************************************************
            db.AddInParameter(dbCommand01, "PrinterID", DbType.String, InvInvEntity.PrinterID);
            db.AddInParameter(dbCommand01, "AccountCode", DbType.String, InvInvEntity.AccountCode);
            db.AddInParameter(dbCommand01, "PrinterName", DbType.String, InvInvEntity.PrinterName);            
            db.AddInParameter(dbCommand01, "IPMAC", DbType.String, InvInvEntity.IPMAC);
            db.AddInParameter(dbCommand01, "PPurchDate", DbType.String, InvInvEntity.PPurchDate);            
            db.AddInParameter(dbCommand01, "DeptID", DbType.String, InvInvEntity.DeptID);
            db.AddInParameter(dbCommand01, "PDistDate", DbType.String, InvInvEntity.PDistDate);
            db.AddInParameter(dbCommand01, "Type", DbType.String, InvInvEntity.Type);
            db.AddInParameter(dbCommand01, "Totaluser", DbType.String, InvInvEntity.Totaluser);
            db.AddInParameter(dbCommand01, "Dailyppage", DbType.String, InvInvEntity.Dailyppage);
            db.AddInParameter(dbCommand01, "DeviceID", DbType.String, InvInvEntity.DeviceID);


            db.ExecuteNonQuery(dbCommand, transaction);
            db.ExecuteNonQuery(dbCommand01, transaction);
            return true;
        }
    }
}
