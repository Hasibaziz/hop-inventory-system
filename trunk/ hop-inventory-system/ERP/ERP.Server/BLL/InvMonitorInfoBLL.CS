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
   public partial class InvMonitorInfoBLL
    {
       public object GetInvMonitorInfoRecord(object param)
       {
           object retObj = null;
           InvMonitorInfoDAL InvMonitorDAL = new InvMonitorInfoDAL();
           retObj = (object)InvMonitorDAL.GetMonitorInfoRecord(param);
           return retObj;
       }
       public object SaveInvMonitorInfo(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           object retObj = null;
           using (DbConnection connection = db.CreateConnection())
           {
               connection.Open();
               DbTransaction transaction = connection.BeginTransaction();
               try
               {
                   MonitorDetailsEntity InvMonitorEntity = (MonitorDetailsEntity)param;
                   InvMonitorInfoDAL InvMonitorDAL = new InvMonitorInfoDAL();
                   retObj = (object)InvMonitorDAL.SaveInvMonitorInfo(InvMonitorEntity, db, transaction);
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
       public object UpdateInvMonitorInfo(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           object retObj = null;
           using (DbConnection connection = db.CreateConnection())
           {
               connection.Open();
               DbTransaction transaction = connection.BeginTransaction();
               try
               {
                   MonitorDetailsEntity InvMonitorEntity = (MonitorDetailsEntity)param;
                   InvMonitorInfoDAL InvMonitorDAL = new InvMonitorInfoDAL();
                   retObj = (object)InvMonitorDAL.UpdateInvMonitorInfo(InvMonitorEntity, db, transaction);
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
       public object DeleteMonitorInfoById(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           object retObj = null;
           using (DbConnection connection = db.CreateConnection())
           {
               connection.Open();
               DbTransaction transaction = connection.BeginTransaction();
               try
               {
                   InvMonitorInfoDAL MonitorDAL = new InvMonitorInfoDAL();
                   retObj = (object)MonitorDAL.DeleteMonitorInfoById(param, db, transaction);
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
