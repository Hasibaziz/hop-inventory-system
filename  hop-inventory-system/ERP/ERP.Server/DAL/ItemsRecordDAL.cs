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
    public partial class ItemsRecordDAL
    {
        public DataTable GetItemsListRecord(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sql = "SELECT [ItemID], [ItemName], [ItemDate], [Description] FROM [ITInventory].[dbo].[INV_Items]";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }
        public bool SaveInvitemsRecord(InvitemsEntity InvitemsEntity, Database db, DbTransaction transaction)
        {
            string sql = "INSERT INTO INV_Items ( ItemName, ItemDate, Description) VALUES (  @ItemName, @ItemDate,  @Description )";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);

            db.AddInParameter(dbCommand, "ItemName", DbType.String, InvitemsEntity.ItemName);
            db.AddInParameter(dbCommand, "ItemDate", DbType.String, InvitemsEntity.ItemDate);
            db.AddInParameter(dbCommand, "Description", DbType.String, InvitemsEntity.Description);

            db.ExecuteNonQuery(dbCommand, transaction);
            return true;
        }
        public bool UpdateInvitemsRecord(InvitemsEntity InvitemsEntity, Database db, DbTransaction transaction)
        {
            string sql = "UPDATE INV_Items SET ItemName= @ItemName, ItemDate=@ItemDate, Description= @Description WHERE ItemID=@ItemID";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "ItemID", DbType.String, InvitemsEntity.ItemID);
            db.AddInParameter(dbCommand, "ItemName", DbType.String, InvitemsEntity.ItemName);
            db.AddInParameter(dbCommand, "ItemDate", DbType.String, InvitemsEntity.ItemDate);
            db.AddInParameter(dbCommand, "Description", DbType.String, InvitemsEntity.Description);

            db.ExecuteNonQuery(dbCommand, transaction);
            return true;
        }
        public bool DeleteInvitemsRecordById(object param, Database db, DbTransaction transaction)
        {
            string sql = "DELETE FROM INV_Items WHERE ItemID=@ItemID";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "ItemID", DbType.String, param);

            db.ExecuteNonQuery(dbCommand, transaction);
            return true;
        }
        public DataTable GetitemsById(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            //string sql = "SELECT EmpID, EmpNo, EmpName, DeptID, Location, JoinDate FROM ITInventory.dbo.INV_EmployeeInfo ORDER BY EmpNo ASC";
            string sql = "SELECT [ItemID], [ItemName], [ItemDate], [Description] FROM [ITInventory].[dbo].[INV_Items] ORDER BY ItemName ASC";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }
    }
}
