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
   public partial class InvPrinterInfoBLL
    {
       public object GetInvPrinterInfoRecord(object param)
       {
           object retObj = null;
           InvPrinterInfoDAL InvPrinterDAL = new InvPrinterInfoDAL();
           retObj = (object)InvPrinterDAL.GetPrinterInfoRecord(param);
           return retObj;
       }
       public object SaveInvPrinterInfo(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           object retObj = null;
           using (DbConnection connection = db.CreateConnection())
           {
               connection.Open();
               DbTransaction transaction = connection.BeginTransaction();
               try
               {
                   PrinterInfoEntity InvPrinterEntity = (PrinterInfoEntity)param;
                   InvPrinterInfoDAL InvPrinterDAL = new InvPrinterInfoDAL();
                   retObj = (object)InvPrinterDAL.SaveInvPrinterInfo(InvPrinterEntity, db, transaction);
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
       public object DeletePrinterInfoById(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           object retObj = null;
           using (DbConnection connection = db.CreateConnection())
           {
               connection.Open();
               DbTransaction transaction = connection.BeginTransaction();
               try
               {
                   InvPrinterInfoDAL PrinterDAL = new InvPrinterInfoDAL();
                   retObj = (object)PrinterDAL.DeletePrinterInfoById(param, db, transaction);
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
