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
   public class InvServiceinfoDAL
    {
       public DataTable GetServiceinfolistRecord(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT [ServiceID], [AccountID], [LocID], [Servicedate], [Mlifetime], [Description] FROM [ITInventory].[dbo].[INV_Service]";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }
       public bool SaveServiceinfoRecord(InvServiceinfoEntity SVSEntity, Database db, DbTransaction transaction)
       {
           string sql = "INSERT INTO [ITInventory].[dbo].[INV_Service]([AccountID],[LocID],[Servicedate],[Mlifetime],[Description]) VALUES(@AccountID, @LocID, @Servicedate, @Mlifetime, @Description)";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);

           db.AddInParameter(dbCommand, "AccountID", DbType.String, SVSEntity.AccountID);
           db.AddInParameter(dbCommand, "LocID", DbType.String, SVSEntity.LocID);
           db.AddInParameter(dbCommand, "Servicedate", DbType.String, SVSEntity.Servicedate);
           db.AddInParameter(dbCommand, "Mlifetime", DbType.String, SVSEntity.Mlifetime);
           db.AddInParameter(dbCommand, "Description", DbType.String, SVSEntity.Description);

           db.ExecuteNonQuery(dbCommand, transaction);
           return true;
       }
       public bool UpdateServiceinfoRecord(InvServiceinfoEntity SVSEntity, Database db, DbTransaction transaction)
       {
           string sql = "UPDATE [ITInventory].[dbo].[INV_Service] SET AccountID= @AccountID, LocID=@LocID, Servicedate=@Servicedate, Mlifetime=@Mlifetime, Description=@Description WHERE ServiceID=@ServiceID";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);

           db.AddInParameter(dbCommand, "ServiceID", DbType.String, SVSEntity.ServiceID);
           db.AddInParameter(dbCommand, "AccountID", DbType.String, SVSEntity.AccountID);
           db.AddInParameter(dbCommand, "LocID", DbType.String, SVSEntity.LocID);
           db.AddInParameter(dbCommand, "Servicedate", DbType.String, SVSEntity.Servicedate);
           db.AddInParameter(dbCommand, "Mlifetime", DbType.String, SVSEntity.Mlifetime);
           db.AddInParameter(dbCommand, "Description", DbType.String, SVSEntity.Description);

           db.ExecuteNonQuery(dbCommand, transaction);
           return true;
       }



       public DataTable GetAllEquipmentbyLocation(object param)
       {
           InvServiceinfoEntity obj = (InvServiceinfoEntity)param;
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT A.[AccountID], A.[ENumber] FROM [ITInventory].[dbo].[Inv_InventoryInfo] as A, [ITInventory].[dbo].[INV_Location] as B WHERE A.Location=B.Location AND B.Location='" + obj.Location + "'";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }
       public DataTable GetAllEquipmentno(object param)
       {
           InvServiceinfoEntity obj = (InvServiceinfoEntity)param;
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT [AccountID], [ENumber] FROM [ITInventory].[dbo].[Inv_InventoryInfo]";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }

       public DataTable GetXValRecord(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT [Servicedate], [Mlifetime] FROM [ITInventory].[dbo].[INV_Service]";
           //string sql = "SELECT convert(date,[Servicedate],103) as [Servicedate] , cast([Mlifetime] as int) as [Mlifetime] FROM [ITInventory].[dbo].[INV_Service]";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }
       public DataTable GetYValRecord(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT [Mlifetime] FROM [ITInventory].[dbo].[INV_Service]";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }

    }
}
