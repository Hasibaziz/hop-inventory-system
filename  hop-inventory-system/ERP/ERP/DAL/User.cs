using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using ERP.Domain.Model;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;


using System.Web.Mvc;
using System.Configuration;
using ERP.Models;
using ERP.Utility;


namespace ERP.DAL
{
    public partial class User
    {

        //public DataTable GetUserInfo(object param)
        public DataTable GetUserInfo(LoginModel param)
        {           
            Database db = DatabaseFactory.CreateDatabase();
            DbConnection connection = db.CreateConnection();


            string sql = "SELECT A.UserID, A.UserName, A.Password, B.Location, A.UsersStatus FROM ITInventory.dbo.Logininfo as A,ITInventory.dbo.INV_Location as B  WHERE A.LocID=B.LocID AND A.UserName='" + param.UserName + "' and A.Password='" + param.Password + "' ";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
           
            dbCommand.Connection = connection;
            connection.Open();
            DataSet ds = db.ExecuteDataSet(dbCommand);
            //IDataReader ds = db.ExecuteReader(dbCommand);
            connection.Close();
            return ds.Tables[0];
        }
        public DataTable SetUserName(LoginModel param)
        {

            Database db = DatabaseFactory.CreateDatabase();
            DbConnection connection = db.CreateConnection();


            string sql = "SELECT A.UserID, A.UserName, A.Password, B.Location, A.UsersStatus FROM ITInventory.dbo.Logininfo as A,ITInventory.dbo.INV_Location as B  WHERE A.LocID=B.LocID AND A.UserName='" + param.UserName + "' ";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);

            dbCommand.Connection = connection;
            connection.Open();
            DataSet ds = db.ExecuteDataSet(dbCommand);
            //IDataReader ds = db.ExecuteReader(dbCommand);
            connection.Close();
            return ds.Tables[0];
        }
        public DataTable GetForgetpass(LoginModel param)
        {           
            Database db = DatabaseFactory.CreateDatabase();
            DbConnection connection = db.CreateConnection();


            //string sql = "SELECT UserID, UserName, Password, Usermail, LocID FROM ITInventory.dbo.Logininfo WHERE Usermail='" + param.Useremail + "' ";
            string sql = "SELECT A.UserID, A.UserName as UserName, A.Password as Password, A.Usermail as Usermail, B.Location as Location FROM ITInventory.dbo.Logininfo as A,ITInventory.dbo.INV_Location as B  WHERE A.LocID=B.LocID AND A.Usermail='" + param.Useremail + "' ";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);

            dbCommand.Connection = connection;
            connection.Open();
            DataSet ds = db.ExecuteDataSet(dbCommand);
            //IDataReader ds = db.ExecuteReader(dbCommand);
            connection.Close();
            return ds.Tables[0];
        }        
    }
}