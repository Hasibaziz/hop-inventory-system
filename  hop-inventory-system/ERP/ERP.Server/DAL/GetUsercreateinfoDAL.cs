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
    public class GetUsercreateinfoDAL
    {
        public DataTable GetUsercreateinfoRecord(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sql = "SELECT UserID, UserName, Password, Usermail, LocID, UsersStatus, Createdate FROM ITInventory.dbo.Logininfo";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }
        public bool SaveusercreateRecord(UsercreateinfoEntity UserEntity, Database db, DbTransaction transaction)
        {
            string sql = "INSERT INTO ITInventory.dbo.Logininfo ( UserName, Password, Usermail, LocID, UsersStatus, Createdate) VALUES (  @UserName, @Password, @Usermail, @LocID, @UsersStatus, @Createdate)";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);

            db.AddInParameter(dbCommand, "UserName", DbType.String, UserEntity.UserName);
            db.AddInParameter(dbCommand, "Password", DbType.String, UserEntity.Password);
            db.AddInParameter(dbCommand, "Usermail", DbType.String, UserEntity.Usermail);
            db.AddInParameter(dbCommand, "LocID", DbType.String, UserEntity.LocID);
            db.AddInParameter(dbCommand, "UsersStatus", DbType.String, UserEntity.UsersStatus);
            db.AddInParameter(dbCommand, "Createdate", DbType.String, UserEntity.Createdate);

            db.ExecuteNonQuery(dbCommand, transaction);
            return true;
        }
        public bool UpdateusercreateRecord(UsercreateinfoEntity UserEntity, Database db, DbTransaction transaction)
        {
            string sql = "UPDATE ITInventory.dbo.Logininfo SET UserName= @UserName, Password= @Password, Usermail=@Usermail, LocID=@LocID, UsersStatus=@UsersStatus, Createdate=@Createdate  WHERE UserID=@UserID";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);

            db.AddInParameter(dbCommand, "UserID", DbType.String, UserEntity.UserID);
            db.AddInParameter(dbCommand, "UserName", DbType.String, UserEntity.UserName);
            db.AddInParameter(dbCommand, "Password", DbType.String, UserEntity.Password);
            db.AddInParameter(dbCommand, "Usermail", DbType.String, UserEntity.Usermail);
            db.AddInParameter(dbCommand, "LocID", DbType.String, UserEntity.LocID);
            db.AddInParameter(dbCommand, "UsersStatus", DbType.String, UserEntity.UsersStatus);
            db.AddInParameter(dbCommand, "Createdate", DbType.String, UserEntity.Createdate);

            db.ExecuteNonQuery(dbCommand, transaction);
            return true;
        }



        public DataTable GetDuplicateMail(string UserEntity, object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
           
            //string sql = "SELECT COUNT(Usermail) as MailCount FROM ITInventory.dbo.Login_info GROUP BY Usermail HAVING COUNT(Usermail)>=1";
            string sql = "SELECT Usermail  FROM ITInventory.dbo.Logininfo where Usermail like '%" + UserEntity + "%'";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            //db.AddInParameter(dbCommand, "Usermail", DbType.String, UserEntity.Usermail);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }

    }
}
