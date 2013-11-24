using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Server.BLL;
namespace ERP.Structure.TaskManager
{
    internal class ErpTaskManager
    {
        public object Execute(string methodName, object param)
        {
            switch (methodName)
            {
                case ERPTask.MG_GetSaleCarDetailsInfo:
                    CommonBLL commonBLL = null;
                    commonBLL = new CommonBLL();
                    return commonBLL.GetSaleCarDetailsInfo(param);
                    break;

                #region Auto Generated - TR_ServiceMaster
                case ERPTask.AG_SaveTrServicemasterInfo:
                    TrServicemasterBLL trServicemasterBLL = null;
                    trServicemasterBLL = new TrServicemasterBLL();
                    return trServicemasterBLL.SaveTrServicemasterInfo(param);
                    break;
                case ERPTask.AG_UpdateTrServicemasterInfo:
                    trServicemasterBLL = new TrServicemasterBLL();
                    return trServicemasterBLL.UpdateTrServicemasterInfo(param);
                    break;
                case ERPTask.AG_DeleteTrServicemasterInfoById:
                    trServicemasterBLL = new TrServicemasterBLL();
                    return trServicemasterBLL.DeleteTrServicemasterInfoById(param);
                    break;
                case ERPTask.AG_GetAllTrServicemasterRecord:
                    trServicemasterBLL = new TrServicemasterBLL();
                    return trServicemasterBLL.GetAllTrServicemasterRecord(param);
                    break;
                case ERPTask.AG_GetSingleTrServicemasterRecordById:
                    trServicemasterBLL = new TrServicemasterBLL();
                    return trServicemasterBLL.GetSingleTrServicemasterRecordById(param);
                    break;
                #endregion

                #region Auto Generated - TR_ServiceDetails
                case ERPTask.AG_SaveTrServicedetailsInfo:
                    TrServicedetailsBLL trServicedetailsBLL = null;
                    trServicedetailsBLL = new TrServicedetailsBLL();
                    return trServicedetailsBLL.SaveTrServicedetailsInfo(param);
                    break;
                case ERPTask.AG_UpdateTrServicedetailsInfo:
                    trServicedetailsBLL = new TrServicedetailsBLL();
                    return trServicedetailsBLL.UpdateTrServicedetailsInfo(param);
                    break;
                case ERPTask.AG_DeleteTrServicedetailsInfoById:
                    trServicedetailsBLL = new TrServicedetailsBLL();
                    return trServicedetailsBLL.DeleteTrServicedetailsInfoById(param);
                    break;
                case ERPTask.AG_GetAllTrServicedetailsRecord:
                    trServicedetailsBLL = new TrServicedetailsBLL();
                    return trServicedetailsBLL.GetAllTrServicedetailsRecord(param);
                    break;
                case ERPTask.AG_GetSingleTrServicedetailsRecordById:
                    trServicedetailsBLL = new TrServicedetailsBLL();
                    return trServicedetailsBLL.GetSingleTrServicedetailsRecordById(param);
                    break;
                #endregion

                default:
                    break;
            }
            return null;
        }
        public object Execute(string methodName)
        {
            throw new NotImplementedException();
        }
    }
}
