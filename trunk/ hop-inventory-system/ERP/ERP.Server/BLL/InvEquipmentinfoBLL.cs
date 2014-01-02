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
    public partial class InvEquipmentinfoBLL
    {
        public object GetEquipmentinfoRecord(object param)
        {
            object retObj = null;
            InvEquipmentinfoDAL EQDAL = new InvEquipmentinfoDAL();
            InvEquipmentEntity obj = (InvEquipmentEntity)param;
            retObj = (object)EQDAL.GetEquipmentinfoRecord(obj, param);
            return retObj;
        }
        public object SaveEquipmentDetails(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           object retObj = null;
           using (DbConnection connection = db.CreateConnection())
           {
               connection.Open();
               DbTransaction transaction = connection.BeginTransaction();
               try
               {
                   InvEquipmentEntity EQEntity = (InvEquipmentEntity)param;
                   InvEquipmentinfoDAL EQDAL = new InvEquipmentinfoDAL();
                   retObj = (object)EQDAL.SaveEquipmentDetails(EQEntity, db, transaction);
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
        public object UpdateEquipmentDetails(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            object retObj = null;
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    InvEquipmentEntity EQEntity = (InvEquipmentEntity)param;
                    InvEquipmentinfoDAL EQDAL = new InvEquipmentinfoDAL();
                    retObj = (object)EQDAL.UpdateEquipmentDetails(EQEntity, db, transaction);
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

        public object GetAutonumber(object param)
        {
            object retObj = null;
            InvEquipmentinfoDAL InvInvDAL = new InvEquipmentinfoDAL();
            //InvInventorydetailsEntity Loc = (InvInventorydetailsEntity)param;
            retObj = (object)InvInvDAL.GetAutonumber(param);
            return retObj;
        }
        public object GetAllENUMBERList(object param)
        {
            object retObj = null;
            InvEquipmentinfoDAL SRDAL = new InvEquipmentinfoDAL();
            retObj = (object)SRDAL.GetAllENUMBERList(param);
            return retObj;
        }

        public object GetEquipmentinfobyloc(object param)
        {
            object retObj = null;
            InvEquipmentinfoDAL EQDAL = new InvEquipmentinfoDAL();
            InvEquipmentEntity obj = (InvEquipmentEntity)param;
            retObj = (object)EQDAL.GetEquipmentinfobyloc(obj, param);
            return retObj;
        }
    }
}
