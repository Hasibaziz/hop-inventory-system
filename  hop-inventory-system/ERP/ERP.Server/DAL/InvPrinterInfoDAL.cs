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
   public partial class InvPrinterInfoDAL
    {
       public DataTable GetPrinterInfoRecord(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sql = "SELECT PrinterID, AccountCode, PrinterName,IPMAC, PurchDate, DeptID, DistDate, Type, Totaluser, Dailyppage, DeviceID FROM ITInventory.dbo.INV_PrinterDetails";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }
       public bool SaveInvPrinterInfo(PrinterInfoEntity InvPrinterEntity, Database db, DbTransaction transaction)
        {
            string sql = "INSERT INTO ITInventory.dbo.INV_PrinterDetails (AccountCode, PrinterName,IPMAC, PurchDate, DeptID, DistDate, Type, Totaluser, Dailyppage, DeviceID ) VALUES ( @AccountCode, @PrinterName,  @IPMAC, @PurchDate,  @DeptID, @DistDate, @Type, @Totaluser, @Dailyppage, @DeviceID )";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);

            db.AddInParameter(dbCommand, "AccountCode", DbType.String, InvPrinterEntity.AccountCode);
            db.AddInParameter(dbCommand, "PrinterName", DbType.String, InvPrinterEntity.PrinterName);
            db.AddInParameter(dbCommand, "IPMAC", DbType.String, InvPrinterEntity.IPMAC);
            db.AddInParameter(dbCommand, "PurchDate", DbType.String, InvPrinterEntity.PurchDate);
            db.AddInParameter(dbCommand, "DeptID", DbType.String, InvPrinterEntity.DeptID);
            db.AddInParameter(dbCommand, "DistDate", DbType.String, InvPrinterEntity.DistDate);
            db.AddInParameter(dbCommand, "Type", DbType.String, InvPrinterEntity.Type);
            db.AddInParameter(dbCommand, "Totaluser", DbType.String, InvPrinterEntity.Totaluser);
            db.AddInParameter(dbCommand, "Dailyppage", DbType.String, InvPrinterEntity.Dailyppage);
            db.AddInParameter(dbCommand, "DeviceID", DbType.String, InvPrinterEntity.DeviceID);
            
            db.ExecuteNonQuery(dbCommand, transaction);
            return true;
        }
       public bool DeletePrinterInfoById(object param, Database db, DbTransaction transaction)
        {
            string sql = "DELETE FROM ITInventory.dbo.INV_PrinterDetails WHERE PrinterID=@PrinterID";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "PrinterID", DbType.String, param);

            db.ExecuteNonQuery(dbCommand, transaction);
            return true;
        }

    }
}
