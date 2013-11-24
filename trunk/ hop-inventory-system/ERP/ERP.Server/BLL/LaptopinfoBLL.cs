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
   public partial class LaptopinfoBLL
    {
       public object GetLaptopinfoRecord(object param)
       {
           object retObj = null;
           LaptopinfoDAL LaptopDAL = new LaptopinfoDAL();
           InvInventorydetailsEntity obj = (InvInventorydetailsEntity)param;
           retObj = (object)LaptopDAL.GetLaptopinfoRecord(obj, param);
           return retObj;
       }
       public object GetLaptopDetailsRecordByID(object param)
       {
           object retObj = null;
           LaptopinfoDAL InvDAL = new LaptopinfoDAL();
           retObj = (object)InvDAL.GetLaptopDetailsRecordByID(param);
           return retObj;
       }
       public object SaveLaptopDetails(object param)
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
                   LaptopinfoDAL LPTDAL = new LaptopinfoDAL();
                   retObj = (object)LPTDAL.SaveLaptopDetails(InvInvEntity, db, transaction);
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
       public object UpdateLaptopDetails(object param)
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
                   LaptopinfoDAL LPTDAL = new LaptopinfoDAL();
                   retObj = (object)LPTDAL.UpdateLaptopDetails(InvInvEntity, db, transaction);
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
