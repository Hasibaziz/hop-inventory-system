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
   public class InvLeaveinfoBLL
    {
       public object GetLeaveinfolistRecord(object param)
       {
           object retObj = null;
           InvLeaveinfoDAL UserctrDAL = new InvLeaveinfoDAL();
           retObj = (object)UserctrDAL.GetLeaveinfolistRecord(param);
           return retObj;
       }
       public object SaveLeaveinfo(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           object retObj = null;
           using (DbConnection connection = db.CreateConnection())
           {
               connection.Open();
               DbTransaction transaction = connection.BeginTransaction();
               try
               {
                   InvLeaveinfoEntity LVEntity = (InvLeaveinfoEntity)param;
                   InvLeaveinfoDAL LVDAL = new InvLeaveinfoDAL();
                   retObj = (object)LVDAL.SaveLeaveinfo(LVEntity, db, transaction);
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
       public object UpdateLeaveinfo(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           object retObj = null;
           using (DbConnection connection = db.CreateConnection())
           {
               connection.Open();
               DbTransaction transaction = connection.BeginTransaction();
               try
               {
                   InvLeaveinfoEntity LVEntity = (InvLeaveinfoEntity)param;
                   InvLeaveinfoDAL LVDAL = new InvLeaveinfoDAL();
                   retObj = (object)LVDAL.UpdateLeaveinfo(LVEntity, db, transaction);
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
       public object GetIdlesearchByuym(object param)
       {
           object retObj = null;
           InvLeaveinfoDAL LVDAL = new InvLeaveinfoDAL();
           InvLeaveinfoEntity obj = (InvLeaveinfoEntity)param;
           retObj = (object)LVDAL.GetIdlesearchByuym(obj, param);
           return retObj;
       }
    }
}
