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
   public class InvServiceinfoBLL
    {
       public object GetServiceinfolistRecord(object param)
       {
           object retObj = null;
           InvServiceinfoDAL SVRDAL = new InvServiceinfoDAL();
           retObj = (object)SVRDAL.GetServiceinfolistRecord(param);
           return retObj;
       }
       public object SaveServiceinfoRecord(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           object retObj = null;
           using (DbConnection connection = db.CreateConnection())
           {
               connection.Open();
               DbTransaction transaction = connection.BeginTransaction();
               try
               {
                   InvServiceinfoEntity SVSEntity = (InvServiceinfoEntity)param;
                   InvServiceinfoDAL SVSDAL = new InvServiceinfoDAL();
                   retObj = (object)SVSDAL.SaveServiceinfoRecord(SVSEntity, db, transaction);
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
       public object UpdateServiceinfoRecord(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           object retObj = null;
           using (DbConnection connection = db.CreateConnection())
           {
               connection.Open();
               DbTransaction transaction = connection.BeginTransaction();
               try
               {
                   InvServiceinfoEntity SVSEntity = (InvServiceinfoEntity)param;
                   InvServiceinfoDAL SVSDAL = new InvServiceinfoDAL();
                   retObj = (object)SVSDAL.UpdateServiceinfoRecord(SVSEntity, db, transaction);
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



       public object GetAllEquipmentbyLocation(object param)
       {
           object retObj = null;
           InvServiceinfoDAL SVRDAL = new InvServiceinfoDAL();
           retObj = (object)SVRDAL.GetAllEquipmentbyLocation(param);
           return retObj;
       }
       public object GetAllEquipmentno(object param)
       {
           object retObj = null;
           InvServiceinfoDAL SVRDAL = new InvServiceinfoDAL();
           retObj = (object)SVRDAL.GetAllEquipmentno(param);
           return retObj;
       }

       public object GetXValRecord(object param)
       {
           object retObj = null;
           InvServiceinfoDAL SVRDAL = new InvServiceinfoDAL();
           retObj = (object)SVRDAL.GetXValRecord(param);
           return retObj;
       }
       public object GetYValRecord(object param)
       {
           object retObj = null;
           InvServiceinfoDAL SVRDAL = new InvServiceinfoDAL();
           retObj = (object)SVRDAL.GetYValRecord(param);
           return retObj;
       }

    }
}
