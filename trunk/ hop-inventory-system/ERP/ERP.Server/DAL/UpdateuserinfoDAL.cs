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
    public partial class UpdateuserinfoDAL
    {
        public DataTable GetUpdateuserinfoRecord(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sql = "SELECT UserinfoID, AccountCode, UserID, Modifydate FROM ITInventory.dbo.INV_Userinfo ORDER BY UserID ASC";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }
        public DataTable GetUpdateusernameRecord(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sql = "SELECT A.UserID, B.UserName FROM ITInventory.dbo.INV_Userinfo AS A, ITInventory.dbo.Login_info AS B  WHERE A.UserID=B.UserID ORDER BY UserID ASC";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }

    }
}
