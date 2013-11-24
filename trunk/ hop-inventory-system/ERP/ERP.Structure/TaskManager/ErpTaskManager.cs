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

                #region Auto Generated - InventoryInfo
                case ERPTask.AG_SaveInventoryInfo:
                    InventoryInfoBLL objInvenBLL = null;
                    objInvenBLL = new InventoryInfoBLL();
                    return objInvenBLL.SaveInventoryInfo(param);
                    break;
                case ERPTask.AG_UpdateInventoryInfo:
                    objInvenBLL = new InventoryInfoBLL();
                    return objInvenBLL.UpdateInventoryInfo(param);
                    break;
                case ERPTask.AG_DeleteInventoryInfoById:
                    objInvenBLL = new InventoryInfoBLL();
                    return objInvenBLL.DeleteInventoryInfoById(param);
                    break;
                case ERPTask.AG_GetAllInventoryInfoRecord:
                    objInvenBLL = new InventoryInfoBLL();
                    return objInvenBLL.GetAllInventoryInfoRecord(param);
                    break;
                case ERPTask.AG_GetSingleInventoryInfoRecordById:
                    objInvenBLL = new InventoryInfoBLL();
                    return objInvenBLL.GetSingleInventoryInfoRecordById(param);
                    break;               
                #endregion


                #region Auto Generated - MonitorDetails
                case ERPTask.AG_SaveMonitorInfo:
                    InvMonitorInfoBLL InvMonitorBLL = null;
                    InvMonitorBLL = new InvMonitorInfoBLL();
                    return InvMonitorBLL.SaveInvMonitorInfo(param);
                    break;
                case ERPTask.AG_UpdateMonitorInfo:
                    InvMonitorBLL = new InvMonitorInfoBLL();
                    return InvMonitorBLL.UpdateInvMonitorInfo(param);
                    break;
                case ERPTask.AG_DeleteMonitorInfoById:
                    InvMonitorBLL = new InvMonitorInfoBLL();
                    return InvMonitorBLL.DeleteMonitorInfoById(param);
                    break;
                case ERPTask.AG_GetMonitorInfoRecord:
                    InvMonitorBLL = new InvMonitorInfoBLL();
                    return InvMonitorBLL.GetInvMonitorInfoRecord(param);
                    break;
                #endregion

                #region Auto Generated - DepartmentInfo
                case ERPTask.AG_SaveDepartmentInfo:
                    InvDepartmentinfoBLL InvDepartBLL = null;
                    InvDepartBLL = new InvDepartmentinfoBLL();
                    return InvDepartBLL.SaveDepartmentInfo(param);
                    break;
                //case ERPTask.AG_UpdateDepartmentInfo:
                //    InvDepartBLL = new InvDepartmentinfoBLL();
                //    return InvDepartBLL.UpdateTrServicedetailsInfo(param);
                //    break;
                case ERPTask.AG_DeleteDepartmentInfoById:
                    InvDepartBLL = new InvDepartmentinfoBLL();
                    return InvDepartBLL.DeleteDepartmentInfoById(param);
                    break;
                case ERPTask.AG_GetDepartmentInfoRecord:
                    InvDepartBLL = new InvDepartmentinfoBLL();
                    return InvDepartBLL.GetDepartmentInfoRecord(param);
                    break;
                case ERPTask.AG_GetDuplicatedept:
                    InvDepartBLL = new InvDepartmentinfoBLL();
                    return InvDepartBLL.GetDuplicatedept(param);
                    break;
                #endregion

                #region Auto Generated - EmployeeInfo
                case ERPTask.AG_SaveEmployeeInfo:
                    InvEmployeeinfoBLL InvEmpBLL = null;
                    InvEmpBLL = new InvEmployeeinfoBLL();
                    return InvEmpBLL.SaveEmployeeInfo(param);
                    break;                
                case ERPTask.AG_DeleteEmployeeInfoById:
                    InvEmpBLL = new InvEmployeeinfoBLL();
                    return InvEmpBLL.DeleteEmployeeInfoById(param);
                    break;
                case ERPTask.AG_GetEmployeeInfoRecord:
                    InvEmpBLL = new InvEmployeeinfoBLL();
                    return InvEmpBLL.GetEmployeeInfoRecord(param);
                    break;
                case ERPTask.AG_GetEmployeeInfo:
                    InvEmpBLL = new InvEmployeeinfoBLL();
                    return InvEmpBLL.GetEmployeeInfo(param);
                    break;
                case ERPTask.AG_GetDuplicateEMP:
                    InvEmpBLL = new InvEmployeeinfoBLL();
                    return InvEmpBLL.GetDuplicateEMP(param);
                    break;
                case ERPTask.AG_GetLocationInfo:
                    InvEmpBLL = new InvEmployeeinfoBLL();
                    return InvEmpBLL.GetLocationInfo(param);
                    break;
                case ERPTask.AG_GetAllLocationByCID:
                    InvEmpBLL = new InvEmployeeinfoBLL();
                    return InvEmpBLL.GetAllLocationByCID(param);
                    break;
                case ERPTask.AG_GetAllBuildingByCID:
                    InvEmpBLL = new InvEmployeeinfoBLL();
                    return InvEmpBLL.GetAllBuildingByCID(param);
                    break;
                #endregion

                #region Auto Generated - PrinterDetails
                case ERPTask.AG_SavePrinterInfo:
                    InvPrinterInfoBLL InvPrinterBLL = null;
                    InvPrinterBLL = new InvPrinterInfoBLL();
                    return InvPrinterBLL.SaveInvPrinterInfo(param);
                    break;
                case ERPTask.AG_UpdatePrinterInfo:
                    trServicedetailsBLL = new TrServicedetailsBLL();
                    return trServicedetailsBLL.UpdateTrServicedetailsInfo(param);
                    break;
                case ERPTask.AG_DeletePrinterInfoById:
                    InvPrinterBLL = new InvPrinterInfoBLL();
                    return InvPrinterBLL.DeletePrinterInfoById(param);
                    break;
                case ERPTask.AG_GetPrinterInfoRecord:
                    InvPrinterBLL = new InvPrinterInfoBLL();
                    return InvPrinterBLL.GetInvPrinterInfoRecord(param);
                    break;
                #endregion

                #region Auto Generated - UPSDetails
                case ERPTask.AG_SaveUPSInfo:
                    InvupsinfoBLL InvUPSBLL = null;
                    InvUPSBLL = new InvupsinfoBLL();
                    return InvUPSBLL.SaveInvUPSInfo(param);
                    break;
                case ERPTask.AG_UpdateUPSInfo:
                    trServicedetailsBLL = new TrServicedetailsBLL();
                    return trServicedetailsBLL.UpdateTrServicedetailsInfo(param);
                    break;
                case ERPTask.AG_DeleteUPSInfoById:
                    InvUPSBLL = new InvupsinfoBLL();
                    return InvUPSBLL.DeleteUPSInfoById(param);
                    break;
                case ERPTask.AG_GetUPSInfoRecord:
                    InvUPSBLL = new InvupsinfoBLL();
                    return InvUPSBLL.GetInvUPSInfoRecord(param);
                    break;
                #endregion

                #region Auto Generated - InventoryDetails
                case ERPTask.AG_SaveInventoryDetails:
                    InvInventoryDetailsBLL InvInvBLL = null;
                    InvInvBLL = new InvInventoryDetailsBLL();
                    return InvInvBLL.SaveInventoryDetails(param);
                    break;
                case ERPTask.AG_GetInventoryDetailsRecord:
                    InvInvBLL = new InvInventoryDetailsBLL();
                    return InvInvBLL.GetInventoryDetailsRecord(param);
                    break;

                case ERPTask.AG_DeleteInventoryDetailsById:
                    InvInvBLL = new InvInventoryDetailsBLL();
                    return InvInvBLL.DeleteInventoryDetailsById(param);
                    break;

                case ERPTask.AG_UpdateInventoryDetails:
                    InvInvBLL = new InvInventoryDetailsBLL();
                    return InvInvBLL.UpdateInventoryDetails(param);
                    break;
                case ERPTask.AG_GetAllInvEmployeeRecordByEmpId:
                    InvInvBLL = new InvInventoryDetailsBLL();
                    return InvInvBLL.GetAllInvEmployeeRecordByEmpId(param);
                    break;
                case ERPTask.AG_GetSingleEmpDetailsRecordById:
                    InvInvBLL = new InvInventoryDetailsBLL();
                    return InvInvBLL.GetSingleEmpDetailsRecordById(param);
                    break;
                case ERPTask.AG_GetInventoryDetailsRecordByID:
                    InvInvBLL = new InvInventoryDetailsBLL();
                    return InvInvBLL.GetInventoryDetailsRecordByID(param);
                    break;
                case ERPTask.AG_GetOLDInfoRecord:
                    InvInvBLL = new InvInventoryDetailsBLL();
                    return InvInvBLL.GetOLDInfoRecord(param);
                    break;
                case ERPTask.AG_GetDuplicatevalue:
                    InvInvBLL = new InvInventoryDetailsBLL();
                    return InvInvBLL.GetDeplicateRecord(param);
                    break;
                case ERPTask.AG_GetSingleInventoryRecordById:
                    InvInvBLL = new InvInventoryDetailsBLL();
                    return InvInvBLL.GetSingleInventoryRecordById(param);
                    break;
                case ERPTask.AG_GetAutonumber:
                    InvInvBLL = new InvInventoryDetailsBLL();
                    return InvInvBLL.GetAutonumber(param);
                    break;
                //case ERPTask.AG_GetEquipmentinfoRecord:
                //    InvInvBLL = new InvInventoryDetailsBLL();
                //    return InvInvBLL.GetEquipmentinfoRecord(param);
                //    break;

                #endregion

                #region Auto Generated - DeviceInfo
                case ERPTask.AG_GetDeviceInfoRecord:
                    DeviceinfoBLL InvDEVBLL = null;
                    InvDEVBLL = new DeviceinfoBLL();
                    return InvDEVBLL.GetDeviceInfoRecord(param);
                    break;
                #endregion

                #region Auto Generated - LaptopInfo
                case ERPTask.AG_GetLaptopDetailsRecord:
                    LaptopinfoBLL LaptopBLL = null;
                    LaptopBLL = new LaptopinfoBLL();
                    return LaptopBLL.GetLaptopinfoRecord(param);
                    break;
                case ERPTask.AG_GetLaptopDetailsRecordByID:
                    LaptopBLL = new LaptopinfoBLL();
                    return LaptopBLL.GetLaptopDetailsRecordByID(param);
                    break;
                case ERPTask.AG_SaveLaptopDetails:
                    LaptopBLL = new LaptopinfoBLL();
                    return LaptopBLL.SaveLaptopDetails(param);
                    break;
                case ERPTask.AG_UpdateLaptopDetails:
                    LaptopBLL = new LaptopinfoBLL();
                    return LaptopBLL.UpdateLaptopDetails(param);
                    break;
                #endregion

                #region Auto Generated - AllDeviceinfo
                case ERPTask.AG_GetALLDeviceinfoRecord:
                    AllDeviceinfoBLL AllDEVBLL = null;
                    AllDEVBLL = new AllDeviceinfoBLL();
                    return AllDEVBLL.GetAllDeviceinfoRecord(param);
                    break;
                #endregion

                #region Auto Generated - ServerInfo
                case ERPTask.AG_GetServerinfoRecord:
                    ServerinfoBLL ServerBLL = null;
                    ServerBLL = new ServerinfoBLL();
                    return ServerBLL.GetServerinfoRecord(param);
                    break;
                case ERPTask.AG_GetServerDetailsRecordByID:
                    ServerBLL = new ServerinfoBLL();
                    return ServerBLL.GetServerDetailsRecordByID(param);
                    break;
                case ERPTask.AG_SaveServerDetails:
                    ServerBLL = new ServerinfoBLL();
                    return ServerBLL.SaveServerDetails(param);
                    break;
                case ERPTask.AG_UpdateServerDetails:
                    ServerBLL = new ServerinfoBLL();
                    return ServerBLL.UpdateServerDetails(param);
                    break;
                #endregion


                #region Auto Generated - PrinterDetails
                case ERPTask.AG_GetPrinterDetailsRecord:
                    PrinterDetailsBLL PrinterBLL = null;
                    PrinterBLL = new PrinterDetailsBLL();
                    return PrinterBLL.GetPrinterDetailsRecord(param);
                    break;
                case ERPTask.AG_GetPrinterDetailsRecordByID:
                    PrinterBLL = new PrinterDetailsBLL();
                    return PrinterBLL.GetPrinterDetailsRecordByID(param);
                    break;
                case ERPTask.AG_SavePrinterDetails:
                    PrinterBLL = new PrinterDetailsBLL();
                    return PrinterBLL.SavePrinterDetails(param);
                    break;
                case ERPTask.AG_UpdatePrinterDetails:
                    PrinterBLL = new PrinterDetailsBLL();
                    return PrinterBLL.UpdatePrinterDetails(param);
                    break;
                #endregion

                #region Auto Generated - Updateuserinfo
                case ERPTask.AG_GetUpdateuserinfoRecord:
                    UpdateuserinfoBLL UpduserBLL = null;
                    UpduserBLL = new UpdateuserinfoBLL();
                    return UpduserBLL.GetUpdateuserinfoRecord(param);
                    break;
                case ERPTask.AG_GetUpdateusernameRecord:
                    UpduserBLL = new UpdateuserinfoBLL();
                    return UpduserBLL.GetUpdateusernameRecord(param);
                    break;
                #endregion

                #region Auto Generated - UsercreateinfoRecord
                case ERPTask.AG_GetUsercreateinfoRecord:
                    GetUsercreateinfoBLL UserctrBLL = null;
                    UserctrBLL = new GetUsercreateinfoBLL();
                    return UserctrBLL.GetUsercreateinfoRecord(param);
                    break;
                case ERPTask.AG_SaveUsercreateInfo:
                    UserctrBLL = new GetUsercreateinfoBLL();
                    return UserctrBLL.SaveusercreateRecord(param);
                    break;
                case ERPTask.AG_UpdateUsercreateInfo:
                    UserctrBLL = new GetUsercreateinfoBLL();
                    return UserctrBLL.UpdateusercreateRecord(param);
                    break;
                case ERPTask.AG_GetDuplicateMail:
                    UserctrBLL = new GetUsercreateinfoBLL();
                    return UserctrBLL.GetDuplicateMail(param);
                    break;
                #endregion

                #region Auto Generated - InventoryReporting
                case ERPTask.AG_GetALLDeviceinfoReport:
                    InvreportingBLL RPTBLL = null;
                    RPTBLL = new InvreportingBLL();
                    return RPTBLL.GetAllDeviceinfoReport(param);
                    break;
                //case ERPTask.AG_SaveUsercreateInfo:
                //    UserctrBLL = new GetUsercreateinfoBLL();
                //    return UserctrBLL.SaveusercreateRecord(param);
                //    break;
                //case ERPTask.AG_UpdateUsercreateInfo:
                //    UserctrBLL = new GetUsercreateinfoBLL();
                //    return UserctrBLL.UpdateusercreateRecord(param);
                //    break;
                //case ERPTask.AG_GetDuplicateMail:
                //    UserctrBLL = new GetUsercreateinfoBLL();
                //    return UserctrBLL.GetDuplicateMail(param);
                //    break;
                #endregion

                #region Auto Generated - ItemsListRecord
                case ERPTask.AG_GetItemsListRecord:
                    ItemsRecordBLL ItemsBLL = null;
                    ItemsBLL = new ItemsRecordBLL();
                    return ItemsBLL.GetItemsListRecord(param);
                    break;
                case ERPTask.AG_SaveInvitemsRecord:
                    ItemsBLL = new ItemsRecordBLL();
                    return ItemsBLL.SaveInvitemsRecord(param);
                    break;
                case ERPTask.AG_UpdateInvitemsRecord:
                    ItemsBLL = new ItemsRecordBLL();
                    return ItemsBLL.UpdateInvitemsRecord(param);
                    break;
                case ERPTask.AG_DeleteInvitemsRecordById:
                    ItemsBLL = new ItemsRecordBLL();
                    return ItemsBLL.DeleteitemsById(param);
                    break;
                case ERPTask.AG_GetitemnameInfo:
                    ItemsBLL = new ItemsRecordBLL();
                    return ItemsBLL.GetitemsById(param);
                    break;
                #endregion

                #region Auto Generated - ModelsListRecord
                case ERPTask.AG_GetModelsListRecord:
                    InvmodelBLL ModelsBLL = null;
                    ModelsBLL = new InvmodelBLL();
                    return ModelsBLL.GetmodelsListRecord(param);
                    break;
                case ERPTask.AG_SaveInvmodelRecord:
                    ModelsBLL = new InvmodelBLL();
                    return ModelsBLL.SavemodelsRecord(param);
                    break;
                case ERPTask.AG_UpdateInvmodelRecord:
                    ModelsBLL = new InvmodelBLL();
                    return ModelsBLL.UpdateInvmodelsRecord(param);
                    break;
                case ERPTask.AG_DeleteInvmodelRecordById:
                    ModelsBLL = new InvmodelBLL();
                    return ModelsBLL.DeletemodelsById(param);
                    break;
                case ERPTask.AG_GetmodelnameInfo:
                    ModelsBLL = new InvmodelBLL();
                    return ModelsBLL.GetmodelsById(param);
                    break;
                case ERPTask.AG_Getitemmodel:
                    ModelsBLL = new InvmodelBLL();
                    return ModelsBLL.Getitemmodel(param);
                    break;
                #endregion


                #region Auto Generated - ItemreceiveListRecord
                case ERPTask.AG_GetitemreceiveListRecord:
                    InvitemreceiveBLL IRBLL = null;
                    IRBLL = new InvitemreceiveBLL();
                    return IRBLL.GetitemreceiveListRecord(param);
                    break;
                case ERPTask.AG_SaveitemreceiveRecord:
                    IRBLL = new InvitemreceiveBLL();
                    return IRBLL.SaveInvitemsreceiveRecord(param);
                    break;
                case ERPTask.AG_UpdateitemreceiveRecord:
                    IRBLL = new InvitemreceiveBLL();
                    return IRBLL.UpdateInvitemsreceiveRecord(param);
                    break;               
                //case ERPTask.AG_DeleteInvmodelRecordById:
                //    ModelsBLL = new InvmodelBLL();
                //    return ModelsBLL.DeletemodelsById(param);
                //    break;              
                #endregion

                #region Auto Generated - ReceiveissueList
                case ERPTask.AG_GetReceiveissueListRecord:
                    InvReceivenissueBLL RNIBLL = null;
                    RNIBLL = new InvReceivenissueBLL();
                    return RNIBLL.GetReceiveissueRecord(param);
                    break;
                case ERPTask.AG_SaveReceiveissueRecord:
                    RNIBLL = new InvReceivenissueBLL();
                    return RNIBLL.SaveReceiveissueRecord(param);
                    break;
                case ERPTask.AG_GetSumvalueRecord:
                    RNIBLL = new InvReceivenissueBLL();
                    return RNIBLL.GetSumvalueRecord(param);
                    break;
                case ERPTask.AG_GetusersumvalueRecord:
                    RNIBLL = new InvReceivenissueBLL();
                    return RNIBLL.GetusersumvalueRecord(param);
                    break; 
                case ERPTask.AG_UpdateReceiveissueRecord:
                    //RNIBLL = new InvReceivenissueBLL();
                    //return RNIBLL.UpdateInvitemsreceiveRecord(param);
                    //break; 
                case ERPTask.AG_GetAssetdistbyMDate:
                    RNIBLL = new InvReceivenissueBLL();
                    return RNIBLL.GetAssetdistbyMDate(param);
                    break;
                case ERPTask.AG_GetFTRTransferListRecord:
                    RNIBLL = new InvReceivenissueBLL();
                    return RNIBLL.GetFTRTransferListRecord(param);
                    break;
                case ERPTask.AG_GetassettransBylocdate:
                    RNIBLL = new InvReceivenissueBLL();
                    return RNIBLL.GetassettransBylocdate(param);
                    break;
                case ERPTask.AG_UpdateFTRTransferList:
                    RNIBLL = new InvReceivenissueBLL();
                    return RNIBLL.UpdateFTRTransferList(param);
                    break;
                #endregion

                #region Auto Generated - Userissue
                case ERPTask.AG_GetUserissueitemRecord:
                    InvuserissueitemBLL LVL = null;
                    LVL = new InvuserissueitemBLL();
                    return LVL.GetUserissueitemRecord(param);
                    break;
                case ERPTask.AG_SaveUserissueInfo:
                    LVL = new InvuserissueitemBLL();
                    return LVL.SaveUserissueInfo(param);
                    break;
                case ERPTask.AG_UpdateUserissueInfo:
                    LVL = new InvuserissueitemBLL();
                    return LVL.UpdateUserissueInfo(param);
                    break;
                //case ERPTask.AG_UpdateReceiveissueRecord:
                //    RNIBLL = new InvReceivenissueBLL();
                //    return RNIBLL.UpdateInvitemsreceiveRecord(param);
                //    break;                            
                #endregion

                ////////////////////Report
                /////////////

                #region Auto Generated - StockInfoRecord
                case ERPTask.AG_GetstockinfoListRecord:
                    InvstockinfoBLL STKBLL = null;
                    STKBLL = new InvstockinfoBLL();
                    return STKBLL.GetstockinfoListRecord(param);
                    break;
                case ERPTask.AG_GetstockinfoRecordByDate:
                    STKBLL = new InvstockinfoBLL();
                    return STKBLL.GetstockinfoRecordByDate(param);
                    break;
                case ERPTask.AG_GetstockinfoexcelByDate:
                    STKBLL = new InvstockinfoBLL();
                    return STKBLL.GetstockinfoexcelByDate(param);
                    break;
                case ERPTask.AG_GetftystockinfoListRecord:
                    STKBLL = new InvstockinfoBLL();
                    return STKBLL.GetftystockinfoListRecord(param);
                    break;
                case ERPTask.AG_GetpassissueListRecord:
                    STKBLL = new InvstockinfoBLL();
                    return STKBLL.GetpassissueListRecord(param);
                    break;
                case ERPTask.AG_GetpassissueListRecordByDate:
                    STKBLL = new InvstockinfoBLL();
                    return STKBLL.GetpassissueListRecordByDate(param);
                    break;
                case ERPTask.AG_GetpassissueListRecordView:
                    STKBLL = new InvstockinfoBLL();
                    return STKBLL.GetpassissueListRecordView(param);
                    break;
                #endregion

                #region Auto Generated - DevicenameRecord
                case ERPTask.AG_GetDevicenameRecord:
                    InvDevicenameBLL DeviceBLL = null;
                    DeviceBLL = new InvDevicenameBLL();
                    return DeviceBLL.GetDevicenameRecord(param);
                    break;
                case ERPTask.AG_SaveDeviceInfo:
                    DeviceBLL = new InvDevicenameBLL();
                    return DeviceBLL.SaveDeviceInfo(param);
                    break;
                case ERPTask.AG_UpdateDeviceInfo:
                    DeviceBLL = new InvDevicenameBLL();
                    return DeviceBLL.UpdateDeviceInfo(param);
                    break;
                case ERPTask.AG_GetDupdevicename:
                    DeviceBLL = new InvDevicenameBLL();
                    return DeviceBLL.GetDupdevicename(param);
                    break; 
                #endregion

                #region Auto Generated - Leaveinfo
                case ERPTask.AG_GetLeaveinfolistRecord:
                    InvLeaveinfoBLL Leave = null;
                    Leave = new InvLeaveinfoBLL();
                    return Leave.GetLeaveinfolistRecord(param);
                    break;
                case ERPTask.AG_SaveLeaveinfoRecord:
                    Leave = new InvLeaveinfoBLL();
                    return Leave.SaveLeaveinfo(param);
                    break;
                case ERPTask.AG_UpdateLeaveinfoRecord:
                    Leave = new InvLeaveinfoBLL();
                    return Leave.UpdateLeaveinfo(param);
                    break;
                case ERPTask.AG_GetIdlesearchByuym:
                    Leave = new InvLeaveinfoBLL();
                    return Leave.GetIdlesearchByuym(param);
                    break;                     
                #endregion

                #region Auto Generated - Serviceinfo
                case ERPTask.AG_GetServiceinfolistRecord:
                    InvServiceinfoBLL SVRBLL = null;
                    SVRBLL = new InvServiceinfoBLL();
                    return SVRBLL.GetServiceinfolistRecord(param);
                    break;
                case ERPTask.AG_SaveServiceinfoRecord:
                    SVRBLL = new InvServiceinfoBLL();
                    return SVRBLL.SaveServiceinfoRecord(param);
                    break;
                case ERPTask.AG_UpdateServiceinfoRecord:
                    SVRBLL = new InvServiceinfoBLL();
                    return SVRBLL.UpdateServiceinfoRecord(param);
                    break;
                case ERPTask.AG_GetAllEquipmentbyLocation:
                    SVRBLL = new InvServiceinfoBLL();
                    return SVRBLL.GetAllEquipmentbyLocation(param);
                    break;
                case ERPTask.AG_GetAllEquipmentno:
                    SVRBLL = new InvServiceinfoBLL();
                    return SVRBLL.GetAllEquipmentno(param);
                    break;
                case ERPTask.AG_GetXValRecord:
                    SVRBLL = new InvServiceinfoBLL();
                    return SVRBLL.GetXValRecord(param);
                    break;
                case ERPTask.AG_GetYValRecord:
                    SVRBLL = new InvServiceinfoBLL();
                    return SVRBLL.GetYValRecord(param);
                    break;
                #endregion

                #region Auto Generated - SupportRecord
                case ERPTask.AG_GetCountryRecord:
                    InvSupportRecordBLL SR = null;
                    SR = new InvSupportRecordBLL();
                    return SR.GetCountryRecord(param);
                    break;
                case ERPTask.AG_SaveCountryInfo:
                    SR = new InvSupportRecordBLL();
                    return SR.SaveCountryInfo(param);
                    break;
                case ERPTask.AG_UpdateCountryInfo:
                    SR = new InvSupportRecordBLL();
                    return SR.UpdateCountryInfo(param);
                    break;
                case ERPTask.AG_GetDupCountry:
                    SR = new InvSupportRecordBLL();
                    return SR.GetDupCountry(param);
                    break;
                case ERPTask.AG_GetAllCountry:
                    SR = new InvSupportRecordBLL();
                    return SR.GetAllCountryRecord(param);
                    break;

                case ERPTask.AG_GetUnitRecord:                  
                    SR = new InvSupportRecordBLL();
                    return SR.GetUnitRecord(param);
                    break;
                case ERPTask.AG_SaveUnitInfo:
                    SR = new InvSupportRecordBLL();
                    return SR.SaveUnitInfo(param);
                    break;
                case ERPTask.AG_UpdateUnitInfo:
                    SR = new InvSupportRecordBLL();
                    return SR.UpdateUnitInfo(param);
                    break;
                case ERPTask.AG_GetDupUnit:
                    SR = new InvSupportRecordBLL();
                    return SR.GetDupUnit(param);
                    break;
                case ERPTask.AG_GetAllUnit:
                    SR = new InvSupportRecordBLL();
                    return SR.GetAllUnit(param);
                    break;
                case ERPTask.AG_GetAllBuildinginfo:
                    SR = new InvSupportRecordBLL();
                    return SR.GetAllBuildinginfo(param);
                    break;
                case ERPTask.AG_GetBuildinginfoRecord:
                    SR = new InvSupportRecordBLL();
                    return SR.GetBuildinginfoRecord(param);
                    break;
                case ERPTask.AG_SaveBuildingInfo:
                    SR = new InvSupportRecordBLL();
                    return SR.SaveBuildingInfo(param);
                    break;
                case ERPTask.AG_UpdateBuildingInfo:
                    SR = new InvSupportRecordBLL();
                    return SR.UpdateBuildingInfo(param);
                    break;
                case ERPTask.AG_GetDupBuilding:
                    SR = new InvSupportRecordBLL();
                    return SR.GetDupBuilding(param);
                    break;
                case ERPTask.AG_GetFloorinfofoRecord:
                    SR = new InvSupportRecordBLL();
                    return SR.GetFloorinfofoRecord(param);
                    break;
                case ERPTask.AG_SaveFloorRecord:
                    SR = new InvSupportRecordBLL();
                    return SR.SaveFloorRecord(param);
                    break;
                case ERPTask.AG_UpdateFloorRecord:
                    SR = new InvSupportRecordBLL();
                    return SR.UpdateFloorRecord(param);
                    break;
                case ERPTask.AG_GetAllFloorinfo:
                    SR = new InvSupportRecordBLL();
                    return SR.GetAllFloorinfo(param);
                    break;
                case ERPTask.AG_GetAllGetFloorByBNID:
                    SR = new InvSupportRecordBLL();
                    return SR.GetAllGetFloorByBNID(param);
                    break;
                case ERPTask.AG_GetLineinfofoRecord:
                    SR = new InvSupportRecordBLL();
                    return SR.GetLineinfofoRecord(param);
                    break;
                case ERPTask.AG_SaveLineRecord:
                    SR = new InvSupportRecordBLL();
                    return SR.SaveLineRecord(param);
                    break;
                case ERPTask.AG_UpdateLineRecord:
                    SR = new InvSupportRecordBLL();
                    return SR.UpdateLineRecord(param);
                    break;
                case ERPTask.AG_GetAllLineinfo:
                    SR = new InvSupportRecordBLL();
                    return SR.GetAllLineinfo(param);
                    break;
                case ERPTask.AG_GetMachineinfofoRecord:
                    SR = new InvSupportRecordBLL();
                    return SR.GetMachineinfofoRecord(param);
                    break;
                case ERPTask.AG_SaveMachineInfo:
                    SR = new InvSupportRecordBLL();
                    return SR.SaveMachineInfo(param);
                    break;
                case ERPTask.AG_UpdateMachineInfo:
                    SR = new InvSupportRecordBLL();
                    return SR.UpdateMachineInfo(param);
                    break;
                case ERPTask.AG_GetAllMachineinfo:
                    SR = new InvSupportRecordBLL();
                    return SR.GetAllMachineinfo(param);
                    break;
                case ERPTask.AG_GetMachinedetail:
                    SR = new InvSupportRecordBLL();
                    return SR.GetMachinedetail(param);
                    break;
                #endregion


                #region Auto Generated - EquipmentinfoRecord
                case ERPTask.AG_GetEquipmentinfoRecord:
                    InvEquipmentinfoBLL EQBLL = null;
                    EQBLL = new InvEquipmentinfoBLL();
                    return EQBLL.GetEquipmentinfoRecord(param);
                    break;
                case ERPTask.AG_SaveEquipmentDetails:
                    EQBLL = new InvEquipmentinfoBLL();
                    return EQBLL.SaveEquipmentDetails(param);
                    break;
                case ERPTask.AG_UpdateEquipmentDetails:
                    EQBLL = new InvEquipmentinfoBLL();
                    return EQBLL.UpdateEquipmentDetails(param);
                    break;
                case ERPTask.AG_GetEQAutonumber:
                    EQBLL = new InvEquipmentinfoBLL();
                    return EQBLL.GetAutonumber(param);
                    break;
                case ERPTask.AG_GetAllENUMBERList:
                    EQBLL = new InvEquipmentinfoBLL();
                    return EQBLL.GetAllENUMBERList(param);
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
