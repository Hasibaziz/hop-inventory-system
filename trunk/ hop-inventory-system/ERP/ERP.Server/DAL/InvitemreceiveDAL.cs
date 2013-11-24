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
    public partial class InvitemreceiveDAL
    {
        public DataTable GetitemreceiveListRecord(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sql = "SELECT [IRID],[ItemID],[ModelID],[RDate],[Chlanno], [Suppliername], [LocID], [Quantity] FROM [ITInventory].[dbo].[INV_ItemReceive]";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }
        public bool SaveInvitemsreceiveRecord(InvitemreceiveEntity IREntity, Database db, DbTransaction transaction)
        {
            string sql = "INSERT INTO INV_ItemReceive ( ItemID, ModelID, RDate, Chlanno, Suppliername, LocID, Quantity) VALUES ( @ItemID, @ModelID, @RDate, @Chlanno, @Suppliername, @LocID, @Quantity )";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);

            db.AddInParameter(dbCommand, "ItemID", DbType.String, IREntity.ItemID);
            db.AddInParameter(dbCommand, "ModelID", DbType.String, IREntity.ModelID);
            db.AddInParameter(dbCommand, "RDate", DbType.String, IREntity.RDate);
            db.AddInParameter(dbCommand, "Chlanno", DbType.String, IREntity.Chlanno);
            db.AddInParameter(dbCommand, "Suppliername", DbType.String, IREntity.Suppliername);
            db.AddInParameter(dbCommand, "LocID", DbType.String, IREntity.LocID);
            db.AddInParameter(dbCommand, "Quantity", DbType.String, IREntity.Quantity);

            db.ExecuteNonQuery(dbCommand, transaction);
            return true;
        }
        public bool UpdateInvitemsreceiveRecord(InvitemreceiveEntity IREntity, Database db, DbTransaction transaction)
        {
            string sql = "UPDATE INV_ItemReceive SET ItemID= @ItemID, ModelID=@ModelID, RDate=@RDate, Chlanno=@Chlanno, Suppliername=@Suppliername, LocID=@LocID,  Quantity=@Quantity WHERE IRID=@IRID";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);

            db.AddInParameter(dbCommand, "IRID", DbType.String, IREntity.IRID);
            db.AddInParameter(dbCommand, "ItemID", DbType.String, IREntity.ItemID);
            db.AddInParameter(dbCommand, "ModelID", DbType.String, IREntity.ModelID);
            db.AddInParameter(dbCommand, "RDate", DbType.String, IREntity.RDate);
            db.AddInParameter(dbCommand, "Chlanno", DbType.String, IREntity.Chlanno);
            db.AddInParameter(dbCommand, "Suppliername", DbType.String, IREntity.Suppliername);
            db.AddInParameter(dbCommand, "LocID", DbType.String, IREntity.LocID);
            db.AddInParameter(dbCommand, "Quantity", DbType.String, IREntity.Quantity);

            db.ExecuteNonQuery(dbCommand, transaction);
            return true;
        }
        //public bool DeleteInvitemsreceiveRecordById(object param, Database db, DbTransaction transaction)
        //{
        //    string sql = "DELETE FROM INV_Items WHERE ItemID=@ItemID";
        //    DbCommand dbCommand = db.GetSqlStringCommand(sql);
        //    db.AddInParameter(dbCommand, "ItemID", DbType.String, param);

        //    db.ExecuteNonQuery(dbCommand, transaction);
        //    return true;
        //}
       
    }
}
