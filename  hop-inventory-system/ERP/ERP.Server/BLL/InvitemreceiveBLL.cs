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
    public partial class InvitemreceiveBLL
    {
        public object GetitemreceiveListRecord(object param)
        {
            object retObj = null;
            InvitemreceiveDAL IRDAL = new InvitemreceiveDAL();
            retObj = (object)IRDAL.GetitemreceiveListRecord(param);
            return retObj;
        }
        public object SaveInvitemsreceiveRecord(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            object retObj = null;
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    InvitemreceiveEntity irEntity = (InvitemreceiveEntity)param;
                    InvitemreceiveDAL IRDAL = new InvitemreceiveDAL();
                    retObj = (object)IRDAL.SaveInvitemsreceiveRecord(irEntity, db, transaction);
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
        public object UpdateInvitemsreceiveRecord(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            object retObj = null;
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    InvitemreceiveEntity irEntity = (InvitemreceiveEntity)param;
                    InvitemreceiveDAL IRDAL = new InvitemreceiveDAL();
                    retObj = (object)IRDAL.UpdateInvitemsreceiveRecord(irEntity, db, transaction);
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
        //public object DeleteitemsreceiveById(object param)
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    object retObj = null;
        //    using (DbConnection connection = db.CreateConnection())
        //    {
        //        connection.Open();
        //        DbTransaction transaction = connection.BeginTransaction();
        //        try
        //        {
        //            InvitemreceiveDAL IRDAL = new InvitemreceiveDAL();
        //            retObj = (object)IRDAL.DeleteInvitemsreceiveRecordById(param, db, transaction);
        //            transaction.Commit();
        //        }
        //        catch
        //        {
        //            transaction.Rollback();
        //            throw;
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //    return retObj;
        //}       

        public object GettotalitemreceiveListRecord(object param)
        {
            object retObj = null;
            InvitemreceiveDAL IRDAL = new InvitemreceiveDAL();
            retObj = (object)IRDAL.GettotalitemreceiveListRecord(param);
            return retObj;
        }

    }
}
