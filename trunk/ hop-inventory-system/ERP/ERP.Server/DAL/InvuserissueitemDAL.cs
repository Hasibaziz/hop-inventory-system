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
   public partial class InvuserissueitemDAL
    {
       public DataTable GetUserissueitemRecord(object param)
       {
           InvuserissueEntity obj = (InvuserissueEntity)param;
           if ((obj.Location == "HLNT" && obj.Userstatus == "Normal") || (obj.Location == "HYBD" && obj.Userstatus == "Normal") || (obj.Location == "HLWF" && obj.Userstatus == "Normal") || (obj.Location == "HLAP" && obj.Userstatus == "Normal") || (obj.Location == "HLRC" && obj.Userstatus == "Normal") || (obj.Location == "HLST" && obj.Userstatus == "Normal"))
           {
               Database db = DatabaseFactory.CreateDatabase();
               string sql = "SELECT  A.[UIssueID], A.[ItemID], A.[ModelID], A.[EmpID], A.[DeptID], A.[LocID], A.[UIssueDate], A.[UITRFNo], A.[UIssueQty]   FROM [ITInventory].[dbo].[INV_Userissue] as A, [ITInventory].[dbo].[INV_Location] as B WHERE A.LocID=B.LocID AND B.Location=LEFT(B.Location,4)";
               DbCommand dbCommand = db.GetSqlStringCommand(sql);
               DataSet ds = db.ExecuteDataSet(dbCommand);
               return ds.Tables[0];
           }
           else if ((obj.Location == "HLNT" && obj.Userstatus == "OPEX") || (obj.Location == "HYBD" && obj.Userstatus == "OPEX") || (obj.Location == "HLWF" && obj.Userstatus == "OPEX") || (obj.Location == "HLAP" && obj.Userstatus == "OPEX") || (obj.Location == "HLRC" && obj.Userstatus == "OPEX") || (obj.Location == "HLST" && obj.Userstatus == "OPEX"))
           {
               Database db = DatabaseFactory.CreateDatabase();
               string sql = "SELECT  A.[UIssueID], A.[ItemID], A.[ModelID], A.[EmpID], A.[DeptID], A.[LocID], A.[UIssueDate], A.[UITRFNo], A.[UIssueQty]   FROM [ITInventory].[dbo].[INV_Userissue] as A, [ITInventory].[dbo].[INV_Location] as B WHERE A.LocID=B.LocID AND B.Location='" + obj.Location + "'";
               DbCommand dbCommand = db.GetSqlStringCommand(sql);
               DataSet ds = db.ExecuteDataSet(dbCommand);
               return ds.Tables[0];
           }
           else
           {
               Database db = DatabaseFactory.CreateDatabase();
               string sql = "SELECT  A.[UIssueID], A.[ItemID], A.[ModelID], A.[EmpID], A.[DeptID], A.[LocID], A.[UIssueDate], A.[UITRFNo], A.[UIssueQty]   FROM [ITInventory].[dbo].[INV_Userissue] as A, [ITInventory].[dbo].[INV_Location] as B WHERE A.LocID=B.LocID AND B.Location=LEFT(B.Location,4)";
               DbCommand dbCommand = db.GetSqlStringCommand(sql);
               DataSet ds = db.ExecuteDataSet(dbCommand);
               return ds.Tables[0];
           }

       }
       public bool SaveUserissueInfo(InvuserissueEntity USREntity, Database db, DbTransaction transaction)
       {
           string sql = "INSERT INTO [ITInventory].[dbo].[INV_Userissue] ( [ItemID], [ModelID], [EmpID], [DeptID], [LocID], [UIssueDate], [UITRFNo], [UIssueQty] ) VALUES ( @ItemID, @ModelID, @EmpID, @DeptID, @LocID, @UIssueDate, @UITRFNo, @UIssueQty )";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);

           db.AddInParameter(dbCommand, "ItemID", DbType.String, USREntity.ItemID);
           db.AddInParameter(dbCommand, "ModelID", DbType.String, USREntity.ModelID);
           db.AddInParameter(dbCommand, "EmpID", DbType.String, USREntity.EmpID);
           db.AddInParameter(dbCommand, "DeptID", DbType.String, USREntity.DeptID);
           db.AddInParameter(dbCommand, "LocID", DbType.String, USREntity.LocID);  
           db.AddInParameter(dbCommand, "UIssueDate", DbType.String, USREntity.UIssueDate);
           db.AddInParameter(dbCommand, "UITRFNo", DbType.String, USREntity.UITRFNo);
           db.AddInParameter(dbCommand, "UIssueQty", DbType.String, USREntity.UIssueQty);

           db.ExecuteNonQuery(dbCommand, transaction);
           return true;
       }
       public bool UpdateUserissueInfo(InvuserissueEntity USREntity, Database db, DbTransaction transaction)
       {
           string sql = "UPDATE [ITInventory].[dbo].[INV_Userissue] set UIssueQty = @UIssueQty WHERE UIssueID=@UIssueID";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);

           db.AddInParameter(dbCommand, "UIssueID", DbType.String, USREntity.UIssueID);
           //db.AddInParameter(dbCommand, "ItemID", DbType.String, USREntity.ItemID);
           //db.AddInParameter(dbCommand, "ModelID", DbType.String, USREntity.ModelID);
           //db.AddInParameter(dbCommand, "EmpID", DbType.String, USREntity.EmpID);
           //db.AddInParameter(dbCommand, "DeptID", DbType.String, USREntity.DeptID);
           //db.AddInParameter(dbCommand, "LocID", DbType.String, USREntity.LocID);
           //db.AddInParameter(dbCommand, "UIssueDate", DbType.String, USREntity.UIssueDate);
           //db.AddInParameter(dbCommand, "UITRFNo", DbType.String, USREntity.UITRFNo);
           db.AddInParameter(dbCommand, "UIssueQty", DbType.String, USREntity.UIssueQty);

           db.ExecuteNonQuery(dbCommand, transaction);
           return true;
       }
    }
}
