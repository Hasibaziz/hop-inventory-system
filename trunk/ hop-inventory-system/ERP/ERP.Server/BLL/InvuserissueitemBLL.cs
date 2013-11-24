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
    public partial class InvuserissueitemBLL
    {
        public object GetUserissueitemRecord(object param)
        {
            object retObj = null;
            InvuserissueitemDAL USRDAL = new InvuserissueitemDAL();
            retObj = (object)USRDAL.GetUserissueitemRecord(param);
            return retObj;
        }
        public object SaveUserissueInfo(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            object retObj = null;
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    InvuserissueEntity USREntity = (InvuserissueEntity)param;
                    InvuserissueitemDAL USRDAL = new InvuserissueitemDAL();
                    retObj = (object)USRDAL.SaveUserissueInfo(USREntity, db, transaction);
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
        public object UpdateUserissueInfo(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            object retObj = null;
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    InvuserissueEntity USREntity = (InvuserissueEntity)param;
                    InvuserissueitemDAL USRDAL = new InvuserissueitemDAL();
                    retObj = (object)USRDAL.UpdateUserissueInfo(USREntity, db, transaction);
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

    }
}
