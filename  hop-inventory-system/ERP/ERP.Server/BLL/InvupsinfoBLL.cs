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
   public partial class InvupsinfoBLL
    {
        public object GetInvUPSInfoRecord(object param)
        {
            object retObj = null;
            InvupsinfoDAL InvUPSDAL = new InvupsinfoDAL();
            retObj = (object)InvUPSDAL.GetUPSInfoRecord(param);
            return retObj;
        }
        public object SaveInvUPSInfo(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            object retObj = null;
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    UPSInfoEntity InvUPSEntity = (UPSInfoEntity)param;
                    InvupsinfoDAL InvUPSDAL = new InvupsinfoDAL();
                    retObj = (object)InvUPSDAL.SaveInvUPSInfo(InvUPSEntity, db, transaction);
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
        public object DeleteUPSInfoById(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            object retObj = null;
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    InvupsinfoDAL UPSDAL = new InvupsinfoDAL();
                    retObj = (object)UPSDAL.DeleteUPSInfoById(param, db, transaction);
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
