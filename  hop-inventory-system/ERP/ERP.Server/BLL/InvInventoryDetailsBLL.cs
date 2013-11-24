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
   public partial class InvInventoryDetailsBLL
    {
       public object GetInventoryDetailsRecord(object param)
       {
           object retObj = null;
           InvInventoryDetailsDAL InvInvDAL = new InvInventoryDetailsDAL();
           InvInventorydetailsEntity obj = (InvInventorydetailsEntity)param;
           retObj = (object)InvInvDAL.GetInventoryDetailsRecord(obj, param);
           return retObj;
       }
       public object SaveInventoryDetails(object param)
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
                   InvInventoryDetailsDAL InvInvDAL = new InvInventoryDetailsDAL();
                   retObj = (object)InvInvDAL.SaveInventoryDetails(InvInvEntity, db, transaction);
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
       public object UpdateInventoryDetails(object param)
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
                   InvInventoryDetailsDAL InvInvDAL = new InvInventoryDetailsDAL();
                   retObj = (object)InvInvDAL.UpdateInventoryDetails(InvInvEntity, db, transaction);
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
       public object DeleteInventoryDetailsById(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           object retObj = null;
           using (DbConnection connection = db.CreateConnection())
           {
               connection.Open();
               DbTransaction transaction = connection.BeginTransaction();
               try
               {
                   InvInventoryDetailsDAL InvDetails = new InvInventoryDetailsDAL();
                   retObj = (object)InvDetails.DeleteInventoryDetailsById(param, db, transaction);
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
       public object GetAllInvEmployeeRecordByEmpId(object param)
       {
           object retObj = null;
           InvInventorydetailsEntity InvEntity = (InvInventorydetailsEntity)param;
           InvInventoryDetailsDAL InvInvDAL = new InvInventoryDetailsDAL();
           retObj = (object)InvInvDAL.GetAllInvEmployeeRecordByEmpId(InvEntity, param);
           return retObj;
       }
       public object GetSingleEmpDetailsRecordById(object param)
       {
           object retObj = null;
           //InvInventorydetailsEntity InvENTITY = (InvInventorydetailsEntity)param;
           InvInventoryDetailsDAL InvDAL = new InvInventoryDetailsDAL();
           retObj = (object)InvDAL.GetSingleEmpDetailsRecordById(param);
           return retObj;
       }
       public object GetInventoryDetailsRecordByID(object param)
       {
           object retObj = null;
           InvInventoryDetailsDAL InvDAL = new InvInventoryDetailsDAL();
           retObj = (object)InvDAL.GetInventoryDetailsRecordByID(param);
           return retObj;
       }

       public object GetDeplicateRecord(object param)
       {
           object retObj = null;
           InvInventoryDetailsDAL InvDAL = new InvInventoryDetailsDAL();
           retObj = (object)InvDAL.GetDeplicateRecord(param);
           return retObj;
       }

       public object GetOLDInfoRecord(object param)
       {
           object retObj = null;
           InvInventoryDetailsDAL InvInvDAL = new InvInventoryDetailsDAL();
           retObj = (object)InvInvDAL.GetOLDInfoRecord(param);
           return retObj;
       }

       public object GetSingleInventoryRecordById(object param)
       {
           object retObj = null;
           InvInventoryDetailsDAL InvDAL = new InvInventoryDetailsDAL();
           InvInventorydetailsEntity obj = (InvInventorydetailsEntity)param;
           retObj = (object)InvDAL.GetSingleInventoryRecordById(obj,param);
           return retObj;
       }

       public object GetAutonumber(object param)
       {
           object retObj = null;
           InvInventoryDetailsDAL InvInvDAL = new InvInventoryDetailsDAL();
           //InvInventorydetailsEntity Loc = (InvInventorydetailsEntity)param;
           retObj = (object)InvInvDAL.GetAutonumber(param);
           return retObj;
       }

      
    }
}
