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
    public partial class InvmodelBLL
    {
        public object GetmodelsListRecord(object param)
        {
            object retObj = null;
            InvmodelsDALL ModelsDAL = new InvmodelsDALL();
            retObj = (object)ModelsDAL.GetModelsListRecord(param);
            return retObj;
        }
        public object SavemodelsRecord(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            object retObj = null;
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    InvmodelEntity InvmodelEntity = (InvmodelEntity)param;
                    InvmodelsDALL ModelsDAL = new InvmodelsDALL();
                    retObj = (object)ModelsDAL.SaveInvmodelsRecord(InvmodelEntity, db, transaction);
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
        public object UpdateInvmodelsRecord(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            object retObj = null;
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    InvmodelEntity InvmodelEntity = (InvmodelEntity)param;
                    InvmodelsDALL ModelsDAL = new InvmodelsDALL();
                    retObj = (object)ModelsDAL.UpdateInvmodelsRecord(InvmodelEntity, db, transaction);
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
        public object DeletemodelsById(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            object retObj = null;
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    InvmodelsDALL ModelsDAL = new InvmodelsDALL();
                    retObj = (object)ModelsDAL.DeleteInvmodelsRecordById(param, db, transaction);
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
        public object GetmodelsById(object param)
        {
            object retObj = null;
            InvmodelsDALL ModelsDAL = new InvmodelsDALL();
            retObj = (object)ModelsDAL.GetmodelsById(param);
            return retObj;
        }
        public object Getitemmodel(object param)
        {
            object retObj = null;           
            InvmodelsDALL ModelsDAL = new InvmodelsDALL();
            retObj = (object)ModelsDAL.Getitemmodel(param);
            return retObj;
        }
    }
}
