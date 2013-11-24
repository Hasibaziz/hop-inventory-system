using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Domain.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using ERP.Server.DAL;

namespace ERP.Server.BLL
{
    public class GetUsercreateinfoBLL
    {
        public object GetUsercreateinfoRecord(object param)
        {
            object retObj = null;
            GetUsercreateinfoDAL UserctrDAL = new GetUsercreateinfoDAL();
            retObj = (object)UserctrDAL.GetUsercreateinfoRecord(param);
            return retObj;
        }
        public object SaveusercreateRecord(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            object retObj = null;
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    UsercreateinfoEntity UserctrEntity = (UsercreateinfoEntity)param;
                    GetUsercreateinfoDAL UserctrDAL = new GetUsercreateinfoDAL();
                    retObj = (object)UserctrDAL.SaveusercreateRecord(UserctrEntity, db, transaction);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return retObj;
        }
        public object UpdateusercreateRecord(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            object retObj = null;
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    UsercreateinfoEntity UserctrEntity = (UsercreateinfoEntity)param;
                    GetUsercreateinfoDAL UserctrDAL = new GetUsercreateinfoDAL();
                    retObj = (object)UserctrDAL.UpdateusercreateRecord(UserctrEntity, db, transaction);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return retObj;
        }



        public object GetDuplicateMail(object param)
        {
            object retObj = null;
            string Email = param.ToString();
            GetUsercreateinfoDAL UserctrDAL = new GetUsercreateinfoDAL();
            //UsercreateinfoEntity obj = (UsercreateinfoEntity)param;
            retObj = (object)UserctrDAL.GetDuplicateMail(Email, param);
            return retObj;
        }


    }

}
