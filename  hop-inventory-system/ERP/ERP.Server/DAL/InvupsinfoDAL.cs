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
   public partial class InvupsinfoDAL
    {
        public DataTable GetUPSInfoRecord(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sql = "SELECT UPSID, UPSName, ModelNo, SerialNo, PurchDate, DeptID, EmpID, DistDate FROM ITInventory.dbo.INV_UPSDetails";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }
        public bool SaveInvUPSInfo(UPSInfoEntity InvUPSEntity, Database db, DbTransaction transaction)
        {
            string sql = "INSERT INTO ITInventory.dbo.INV_UPSDetails ( UPSName, ModelNo, SerialNo, PurchDate, DeptID, EmpID, DistDate ) VALUES (  @UPSName,  @ModelNo,  @SerialNo,  @PurchDate,  @DeptID, @EmpID, @DistDate )";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);

            db.AddInParameter(dbCommand, "UPSName", DbType.String, InvUPSEntity.UPSName);
            db.AddInParameter(dbCommand, "ModelNo", DbType.String, InvUPSEntity.ModelNo);
            db.AddInParameter(dbCommand, "SerialNo", DbType.String, InvUPSEntity.SerialNo);
            db.AddInParameter(dbCommand, "PurchDate", DbType.String, InvUPSEntity.PurchDate);
            db.AddInParameter(dbCommand, "DeptID", DbType.String, InvUPSEntity.DeptID);
            db.AddInParameter(dbCommand, "EmpID", DbType.String, InvUPSEntity.EmpID);
            db.AddInParameter(dbCommand, "DistDate", DbType.String, InvUPSEntity.DistDate);
            //db.AddInParameter(dbCommand, "Description", DbType.String, InvUPSEntity.Description);

            db.ExecuteNonQuery(dbCommand, transaction);
            return true;
        }
        public bool DeleteUPSInfoById(object param, Database db, DbTransaction transaction)
        {
            string sql = "DELETE FROM ITInventory.dbo.INV_UPSDetails WHERE UPSID=@UPSID";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "UPSID", DbType.String, param);

            db.ExecuteNonQuery(dbCommand, transaction);
            return true;
        }
    }
}
