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
   public partial class InvDepartmentinfoDAL
    {
       public DataTable GetDepartmentRecord(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT DeptID, DeptNo, DeptName, Description FROM ITInventory.dbo.INV_Department  ORDER BY DeptNo ASC";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }

       public bool SaveDepartmentinfo(InvDepartmentinfoEntity InvDeptEntity, Database db, DbTransaction transaction)
       {
           string sql = "INSERT INTO ITInventory.dbo.INV_Department ( DeptNo, DeptName, Description) VALUES (  @DeptNo,  @DeptName, @Description )";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);

           db.AddInParameter(dbCommand, "DeptNo", DbType.String, InvDeptEntity.DeptNo);
           db.AddInParameter(dbCommand, "DeptName", DbType.String, InvDeptEntity.DeptName);
           db.AddInParameter(dbCommand, "Description", DbType.String, InvDeptEntity.Description);

           db.ExecuteNonQuery(dbCommand, transaction);
           return true;
       }

       public bool DeleteDepartmentInfoById(object param, Database db, DbTransaction transaction)
       {
           string sql = "DELETE FROM ITInventory.dbo.INV_Department WHERE DeptID=@DeptID";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           db.AddInParameter(dbCommand, "DeptID", DbType.String, param);

           db.ExecuteNonQuery(dbCommand, transaction);
           return true;
       }

       public DataTable GetDuplicatedept(string DUPDEPT, object param)
       {
           Database db = DatabaseFactory.CreateDatabase();

           //string sql = "SELECT COUNT(Usermail) as MailCount FROM ITInventory.dbo.Login_info GROUP BY Usermail HAVING COUNT(Usermail)>=1";
           string sql = "SELECT DeptNo  FROM ITInventory.dbo.INV_Department where DeptNo='" + DUPDEPT + "'";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           //db.AddInParameter(dbCommand, "Usermail", DbType.String, UserEntity.Usermail);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }
    }
}
