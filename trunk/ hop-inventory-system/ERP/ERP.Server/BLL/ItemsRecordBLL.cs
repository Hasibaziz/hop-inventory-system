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
    public partial class ItemsRecordBLL
    {
        public object GetItemsListRecord(object param)
        {
            object retObj = null;
            ItemsRecordDAL ItemsDAL = new ItemsRecordDAL();
            retObj = (object)ItemsDAL.GetItemsListRecord(param);
            return retObj;
        }
        public object SaveInvitemsRecord(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            object retObj = null;
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    InvitemsEntity InvitemsEntity = (InvitemsEntity)param;
                    ItemsRecordDAL ItemsDAL = new ItemsRecordDAL();
                    retObj = (object)ItemsDAL.SaveInvitemsRecord(InvitemsEntity, db, transaction);
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
        public object UpdateInvitemsRecord(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            object retObj = null;
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    InvitemsEntity InvitemsEntity = (InvitemsEntity)param;
                    ItemsRecordDAL ItemsDAL = new ItemsRecordDAL();
                    retObj = (object)ItemsDAL.UpdateInvitemsRecord(InvitemsEntity, db, transaction);
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
        public object DeleteitemsById(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            object retObj = null;
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    ItemsRecordDAL ItemsDAL = new ItemsRecordDAL();
                    retObj = (object)ItemsDAL.DeleteInvitemsRecordById(param, db, transaction);
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
        public object GetitemsById(object param)
        {
            object retObj = null;
            ItemsRecordDAL ItemsDAL = new ItemsRecordDAL();
            retObj = (object)ItemsDAL.GetitemsById(param);
            return retObj;
        }
    }
}
