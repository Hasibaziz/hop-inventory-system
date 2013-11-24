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
   public partial class InventoryInfoBLL
    {
       public object SaveInventoryInfo(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            object retObj = null;
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    InventoryModel InvenModel = (InventoryModel)param;
                    InventoryInfoDAL InventoryDAL = new InventoryInfoDAL();
                    retObj = (object)InventoryDAL.SaveInventoryInfo(InvenModel, db, transaction);
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

       public object UpdateInventoryInfo(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            object retObj = null;
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    InventoryModel InvenModel = (InventoryModel)param;
                    InventoryInfoDAL InvenDAL = new InventoryInfoDAL();
                    retObj = (object)InvenDAL.UpdateInventoryInfo(InvenModel, db, transaction);
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

       public object DeleteInventoryInfoById(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            object retObj = null;
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    InventoryInfoDAL InvenDAL = new InventoryInfoDAL();
                    retObj = (object)InvenDAL.DeleteInventoryInfoById(param, db, transaction);
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

       public object GetSingleInventoryInfoRecordById(object param)
        {
            object retObj = null;
            InventoryInfoDAL InvenDAL = new InventoryInfoDAL();
            retObj = (object)InvenDAL.GetSingleInventoryInfoRecordById(param);
            return retObj;
        }

       public object GetAllInventoryInfoRecord(object param)
       {
           object retObj = null;
           InventoryInfoDAL InvenDAL = new InventoryInfoDAL();
           retObj = (object)InvenDAL.GetAllInventoryInfoRecord(param);
           return retObj;
       }
    }
}
