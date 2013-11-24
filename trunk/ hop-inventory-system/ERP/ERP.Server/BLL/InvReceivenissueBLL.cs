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
    public partial class InvReceivenissueBLL
    {
        public object GetReceiveissueRecord(object param)
        {
            object retObj = null;
            InvReceivenissueDAL RIDAL = new InvReceivenissueDAL();
            retObj = (object)RIDAL.GetReceiveissueRecord(param);
            return retObj;
        }
        public object SaveReceiveissueRecord(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            object retObj = null;
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    InvreceivenissueEntity RIEntity = (InvreceivenissueEntity)param;
                    InvReceivenissueDAL RIDAL = new InvReceivenissueDAL();
                    retObj = (object)RIDAL.SaveReceiveissueRecord(RIEntity, db, transaction);
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
        public object GetSumvalueRecord(object param)
        {
            object retObj = null;           
            InvReceivenissueDAL IRDAL = new InvReceivenissueDAL();
            retObj = (object)IRDAL.GetSumvalueRecord(param);
            return retObj;
        }
        public object GetusersumvalueRecord(object param)
        {
            object retObj = null;
            InvReceivenissueDAL IRDAL = new InvReceivenissueDAL();
            retObj = (object)IRDAL.GetusersumvalueRecord(param);
            return retObj;
        }



        public object GetFTRTransferListRecord(object param)
        {
            object retObj = null;
            InvReceivenissueDAL RIDAL = new InvReceivenissueDAL();
            retObj = (object)RIDAL.GetFTRTransferListRecord(param);
            return retObj;
        }
        public object GetAssetdistbyMDate(object param)
        {
            object retObj = null;
            InvReceivenissueDAL IRDAL = new InvReceivenissueDAL();
            retObj = (object)IRDAL.GetAssetdistbyMDate(param);
            return retObj;
        }
        public object GetassettransBylocdate(object param)
        {
            object retObj = null;
            InvReceivenissueDAL IRDAL = new InvReceivenissueDAL();
            InvFTRTransferEntity obj = (InvFTRTransferEntity)param;
            retObj = (object)IRDAL.GetassettransBylocdate(obj, param);
            return retObj;
        }
        public object UpdateFTRTransferList(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            object retObj = null;
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    InvFTRTransferEntity FTYEntity = (InvFTRTransferEntity)param;
                    InvReceivenissueDAL RIDAL = new InvReceivenissueDAL();
                    retObj = (object)RIDAL.UpdateFTRTransferList(FTYEntity, db, transaction);
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
