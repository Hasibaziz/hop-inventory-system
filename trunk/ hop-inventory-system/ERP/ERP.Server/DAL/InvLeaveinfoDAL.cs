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
   public class InvLeaveinfoDAL
    {
       public DataTable GetLeaveinfolistRecord(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT [IID],[EID],[UnitID],[Years],[Months],[Idledays]  FROM [ITInventory].[dbo].[Inv_Idleentry] ORDER BY Years DESC";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }
       public bool SaveLeaveinfo(InvLeaveinfoEntity LVEntity, Database db, DbTransaction transaction)
       {
           string sql = "INSERT INTO [ITInventory].[dbo].[Inv_Idleentry]([EID], [UnitID], [Years], [Months], [Idledays])" +
                        " SELECT EID, UnitID, @Years, @Months, @Idledays FROM dbo.Inv_Equipmentinfo where UnitID=@UnitID";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);

           db.AddInParameter(dbCommand, "UnitID", DbType.String, LVEntity.UnitID);
           db.AddInParameter(dbCommand, "Years", DbType.String, LVEntity.Years);
           db.AddInParameter(dbCommand, "Months", DbType.String, LVEntity.Months);
           db.AddInParameter(dbCommand, "Idledays", DbType.String, LVEntity.Idledays);          

           db.ExecuteNonQuery(dbCommand, transaction);
           return true;
       }
       public bool UpdateLeaveinfo(InvLeaveinfoEntity LVEntity, Database db, DbTransaction transaction)
       {
           string sql = "UPDATE [ITInventory].[dbo].[Inv_Idleentry] SET EID= @EID, UnitID=@UnitID, Years=@Years, Months=@Months, Idledays=@Idledays  WHERE IID=@IID";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);

           db.AddInParameter(dbCommand, "IID", DbType.String, LVEntity.IID);
           db.AddInParameter(dbCommand, "EID", DbType.String, LVEntity.EID);
           db.AddInParameter(dbCommand, "UnitID", DbType.String, LVEntity.UnitID);          
           db.AddInParameter(dbCommand, "Years", DbType.String, LVEntity.Years);
           db.AddInParameter(dbCommand, "Months", DbType.String, LVEntity.Months);
           db.AddInParameter(dbCommand, "Idledays", DbType.String, LVEntity.Idledays);

           db.ExecuteNonQuery(dbCommand, transaction);
           return true;
       }

       public DataTable GetIdlesearchByuym(InvLeaveinfoEntity obj, object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           object[] parameters = new object[] { obj.UnitID, obj.Years, obj.Months };
           DbCommand dbCommand = db.GetStoredProcCommand("GetIdlesearchByuym", parameters);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }
    }
}
