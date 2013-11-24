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
   public partial class PrinterDetailsBLL
    {
       public object GetPrinterDetailsRecord(object param)
        {
            object retObj = null;
            PrinterDetailsDAL PrinterDAL = new PrinterDetailsDAL();
            retObj = (object)PrinterDAL.GetPrinterDetailsRecord(param);
            return retObj;
        }
       public object GetPrinterDetailsRecordByID(object param)
        {
            object retObj = null;
            PrinterDetailsDAL InvDAL = new PrinterDetailsDAL();
            retObj = (object)InvDAL.GetPrinterDetailsRecordByID(param);
            return retObj;
        }
       public object SavePrinterDetails(object param)
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
                    PrinterDetailsDAL PRNDAL = new PrinterDetailsDAL();
                    retObj = (object)PRNDAL.SavePrinterDetails(InvInvEntity, db, transaction);
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
       public object UpdatePrinterDetails(object param)
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
                   PrinterDetailsDAL PRNDAL = new PrinterDetailsDAL();
                   retObj = (object)PRNDAL.UpdatePrinterDetails(InvInvEntity, db, transaction);
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
