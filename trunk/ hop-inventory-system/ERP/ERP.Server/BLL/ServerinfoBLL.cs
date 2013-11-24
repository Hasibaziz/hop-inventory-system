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
   public partial class ServerinfoBLL
    {
        public object GetServerinfoRecord(object param)
        {
            object retObj = null;
            ServerinfoDAL ServerDAL = new ServerinfoDAL();
            InvInventorydetailsEntity obj = (InvInventorydetailsEntity)param;
            retObj = (object)ServerDAL.GetServerinfoRecord(obj, param);
            return retObj;
        }
        public object GetServerDetailsRecordByID(object param)
        {
            object retObj = null;
            ServerinfoDAL InvDAL = new ServerinfoDAL();
            retObj = (object)InvDAL.GetServerinfoRecordByID(param);
            return retObj;
        }
        public object SaveServerDetails(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            object retObj = null;
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    InvInventorydetailsEntity InvInvEntity = (InvInventorydetailsEntity)param;
                    ServerinfoDAL SVRDAL = new ServerinfoDAL();
                    retObj = (object)SVRDAL.SaveServerDetails(InvInvEntity, db, transaction);
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
        public object UpdateServerDetails(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            object retObj = null;
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    InvInventorydetailsEntity InvInvEntity = (InvInventorydetailsEntity)param;
                    ServerinfoDAL SVRDAL = new ServerinfoDAL();
                    retObj = (object)SVRDAL.UpdateServerDetails(InvInvEntity, db, transaction);
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
