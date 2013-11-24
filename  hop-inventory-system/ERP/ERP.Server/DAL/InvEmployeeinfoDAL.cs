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
   public partial class InvEmployeeinfoDAL
    {
       public DataTable GetEmployeeinfoRecord(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sql = "SELECT EmpID, EmpNo, EmpName, DeptID, Location, JoinDate FROM ITInventory.dbo.INV_EmployeeInfo ORDER BY EmpNo ASC";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }

       public DataTable GetEmployeeinfo(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           //string sql = "SELECT EmpID, EmpNo, EmpName, DeptID, Location, JoinDate FROM ITInventory.dbo.INV_EmployeeInfo ORDER BY EmpNo ASC";
           string sql = "SELECT A.EmpID AS EmpID, A.EmpNo, A.EmpName AS EmpName, A.DeptID FROM ITInventory.dbo.INV_EmployeeInfo AS A, Inv_InventoryInfo AS B WHERE A.EmpID=B.EmpID ORDER BY EmpNo ASC";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }

       public bool SaveEmployeeinfo(EmployeeinfoEntity EmpEntity, Database db, DbTransaction transaction)
        {
            string sql = "INSERT INTO ITInventory.dbo.INV_EmployeeInfo ( EmpNo, EmpName, DeptID, Location, JoinDate) VALUES (  @EmpNo,  @EmpName, @DeptID, @Location, @JoinDate )";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);

            db.AddInParameter(dbCommand, "EmpNo", DbType.String, EmpEntity.EmpNo);
            db.AddInParameter(dbCommand, "EmpName", DbType.String, EmpEntity.EmpName);
            db.AddInParameter(dbCommand, "DeptID", DbType.String, EmpEntity.DeptID);
            db.AddInParameter(dbCommand, "Location", DbType.String, EmpEntity.Location);
            db.AddInParameter(dbCommand, "JoinDate", DbType.String, EmpEntity.JoinDate);

            db.ExecuteNonQuery(dbCommand, transaction);
            return true;
        }

       public bool DeleteEmployeeInfoById(object param, Database db, DbTransaction transaction)
        {
            string sql = "DELETE FROM ITInventory.dbo.INV_EmployeeInfo WHERE EmpID=@EmpID";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "EmpID", DbType.String, param);

            db.ExecuteNonQuery(dbCommand, transaction);
            return true;
        }

       public DataTable GetDuplicateEMP(string DUPEMP, object param)
       {
           Database db = DatabaseFactory.CreateDatabase();

           //string sql = "SELECT COUNT(Usermail) as MailCount FROM ITInventory.dbo.Login_info GROUP BY Usermail HAVING COUNT(Usermail)>=1";
           string sql = "SELECT EmpNo  FROM ITInventory.dbo.INV_EmployeeInfo where EmpNo like '%" + DUPEMP + "%'";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           //db.AddInParameter(dbCommand, "Usermail", DbType.String, UserEntity.Usermail);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }

       public DataTable GetLocationInfo(object param)
       {
           Invlocation obj = (Invlocation)param;
           if ((obj.Location == "HLNT" && obj.Userstatus=="Normal") || (obj.Location == "HYBD" && obj.Userstatus=="Normal") || (obj.Location == "HLWF" && obj.Userstatus=="Normal")|| (obj.Location == "HLAP" && obj.Userstatus=="Normal") || (obj.Location == "HLRC" && obj.Userstatus=="Normal") || (obj.Location == "HLST" && obj.Userstatus=="Normal"))
           {
               Database db = DatabaseFactory.CreateDatabase();
               string sql = "SELECT [LocID], [Location], [Description] FROM [ITInventory].[dbo].[INV_Location] ORDER BY Location ASC";
               DbCommand dbCommand = db.GetSqlStringCommand(sql);              
               DataSet ds = db.ExecuteDataSet(dbCommand);
               return ds.Tables[0];
           }
           else if ((obj.Location == "HLNT" && obj.Userstatus == "OPEX") || (obj.Location == "HYBD" && obj.Userstatus == "OPEX") || (obj.Location == "HLWF" && obj.Userstatus == "OPEX") || (obj.Location == "HLAP" && obj.Userstatus == "OPEX") || (obj.Location == "HLRC" && obj.Userstatus == "OPEX") || (obj.Location == "HLST" && obj.Userstatus == "OPEX"))
           {
               Database db = DatabaseFactory.CreateDatabase();
               string sql = "SELECT [LocID], [Location], [Description] FROM [ITInventory].[dbo].[INV_Location] WHERE Location='" + obj.Location + "' ";
               DbCommand dbCommand = db.GetSqlStringCommand(sql);
               DataSet ds = db.ExecuteDataSet(dbCommand);
               return ds.Tables[0];
           } 
           else
           {
               Database db = DatabaseFactory.CreateDatabase();
               string sql = "SELECT [LocID], [Location], [Description] FROM [ITInventory].[dbo].[INV_Location] ORDER BY Location ASC";
               DbCommand dbCommand = db.GetSqlStringCommand(sql);
               DataSet ds = db.ExecuteDataSet(dbCommand);
               return ds.Tables[0];
           }
       }

       public DataTable GetAllLocationByCID(object param)
       {
           Invlocation obj = (Invlocation)param;
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT A.[LocID], A.[Location], A.[CountryID] FROM [ITInventory].[dbo].[INV_Location] AS A, [ITInventory].[dbo].[INV_Country] AS B WHERE A.CountryID=B.CID AND A.CountryID='"+obj.CID+"'  ORDER BY A.Location ASC";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }

       public DataTable GetAllBuildingByCID(object param)
       {
           Invlocation obj = (Invlocation)param;
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT A.[BNID], A.[BuildingName], A.[LocID] FROM [ITInventory].[dbo].[INV_Buildinginfo] AS A, dbo.INV_Location AS B WHERE A.LocID=B.LocID AND A.LocID='" + obj.LocID + "'  ORDER BY A.[BuildingName] ASC";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }
    }
}
