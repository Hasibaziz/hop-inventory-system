using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Server;

namespace ERP.Structure
{
    public partial struct ERPTask
    {
        public const string MG_GetSaleCarDetailsInfo = "MG_GetSaleCarDetailsInfo";

        #region Auto Generated - TR_ServiceMaster
        public const string AG_SaveTrServicemasterInfo = "AG_SaveTrServicemasterInfo";
        public const string AG_UpdateTrServicemasterInfo = "AG_UpdateTrServicemasterInfo";
        public const string AG_DeleteTrServicemasterInfoById = "AG_DeleteTrServicemasterInfoById";
        public const string AG_GetAllTrServicemasterRecord = "AG_GetAllTrServicemasterRecord";
        public const string AG_GetSingleTrServicemasterRecordById = "AG_GetSingleTrServicemasterRecordById";
        #endregion

        #region Auto Generated - TR_ServiceDetails
        public const string AG_SaveTrServicedetailsInfo = "AG_SaveTrServicedetailsInfo";
        public const string AG_UpdateTrServicedetailsInfo = "AG_UpdateTrServicedetailsInfo";
        public const string AG_DeleteTrServicedetailsInfoById = "AG_DeleteTrServicedetailsInfoById";
        public const string AG_GetAllTrServicedetailsRecord = "AG_GetAllTrServicedetailsRecord";
        public const string AG_GetSingleTrServicedetailsRecordById = "AG_GetSingleTrServicedetailsRecordById";
        #endregion

        #region Auto Generated - InventoryInfo
        public const string AG_SaveInventoryInfo = "AG_SaveInventoryInfo";
        public const string AG_UpdateInventoryInfo = "AG_UpdateInventoryInfo";
        public const string AG_DeleteInventoryInfoById = "AG_DeleteInventoryInfoById";
        public const string AG_GetAllInventoryInfoRecord = "AG_GetAllInventoryInfoRecord";
        public const string AG_GetSingleInventoryInfoRecordById = "AG_GetSingleInventoryInfoRecordById";
        public const string AG_GetOLDInfoRecord = "AG_GetOLDInfoRecord";
        #endregion

        #region Auto Generated - MonitorInfo
        public const string AG_SaveMonitorInfo = "AG_SaveMonitorInfo";
        public const string AG_UpdateMonitorInfo = "AG_UpdateMonitorInfo";
        public const string AG_DeleteMonitorInfoById = "AG_DeleteMonitorInfoById";
        public const string AG_GetMonitorInfoRecord = "AG_GetMonitorInfoRecord";
        //public const string AG_GetSingleInventoryInfoRecordById = "AG_GetSingleInventoryInfoRecordById";
        #endregion

        #region Auto Generated - DepartmentInfo
        public const string AG_SaveDepartmentInfo = "AG_SaveDepartmentInfo";
        public const string AG_UpdateDepartmentInfo = "AG_UpdateDepartmentInfo";
        public const string AG_DeleteDepartmentInfoById = "AG_DeleteDepartmentInfoById";
        public const string AG_GetDepartmentInfoRecord = "AG_GetDepartmentInfoRecord";
        public const string AG_GetDuplicatedept = "AG_GetDuplicatedept";
        //public const string AG_GetSingleDepartmentInfoRecordById = "AG_GetSingleDepartmentInfoRecordById";
        #endregion

        #region Auto Generated - EmployeeInfo
        public const string AG_SaveEmployeeInfo = "AG_SaveEmployeeInfo";
        public const string AG_UpdateEmployeeInfo = "AG_UpdateEmployeeInfo";
        public const string AG_DeleteEmployeeInfoById = "AG_DeletEmployeeInfoById";
        public const string AG_GetEmployeeInfoRecord = "AG_GetEmployeeInfoRecord";
        public const string AG_GetEmployeeInfo = "AG_GetEmployeeInfo";
        public const string AG_GetInventoryDetailsRecordByID = "AG_GetInventoryDetailsRecordByID";
        public const string AG_GetAllIEmpRecordByEmpId = "AG_GetAllIEmpRecordByEmpId";
        public const string AG_GetDuplicateEMP = "AG_GetDuplicateEMP";
        public const string AG_GetLocationInfo = "AG_GetLocationInfo";
        public const string AG_GetAllLocationByCID = "AG_GetAllLocationByCID";
        public const string AG_GetAllBuildingByCID = "AG_GetAllBuildingByCID";        
        #endregion

        #region Auto Generated - PrinterInfo
        public const string AG_SavePrinterInfo = "AG_SavePrinterInfo";
        public const string AG_UpdatePrinterInfo = "AG_UpdatePrinterInfo";
        public const string AG_DeletePrinterInfoById = "AG_DeletePrinterInfoById";
        public const string AG_GetPrinterInfoRecord = "AG_GetPrinterInfoRecord";
        //public const string AG_GetSingleInventoryInfoRecordById = "AG_GetSingleInventoryInfoRecordById";
        #endregion

        #region Auto Generated - UPSInfo
        public const string AG_SaveUPSInfo = "AG_SaveUPSInfo";
        public const string AG_UpdateUPSInfo = "AG_UpdateUPSInfo";
        public const string AG_DeleteUPSInfoById = "AG_DeleteUPSInfoById";
        public const string AG_GetUPSInfoRecord = "AG_GetUPSInfoRecord";
        //public const string AG_GetSingleInventoryInfoRecordById = "AG_GetSingleInventoryInfoRecordById";
        #endregion

        #region Auto Generated - InventoryDetails
        public const string AG_SaveInventoryDetails = "AG_SaveInventoryDetails";
        public const string AG_UpdateInventoryDetails = "AG_UpdateInventoryDetails";
        public const string AG_DeleteInventoryDetailsById = "AG_DeleteInventoryDetailsById";
        public const string AG_GetInventoryDetailsRecord = "AG_GetInventoryDetailsRecord";
        public const string AG_GetAllInvEmployeeRecordByEmpId = "AG_GetAllInvEmployeeRecordByEmpId";
        public const string AG_GetSingleEmpDetailsRecordById = "AG_GetSingleEmpDetailsRecordById";
        public const string AG_GetDuplicatevalue = "AG_GetDuplicatevalue";
        public const string AG_GetSingleInventoryRecordById = "AG_GetSingleInventoryRecordById";
        public const string AG_GetAutonumber = "AG_GetAutonumber";
        //public const string AG_GetEquipmentinfoRecord = "AG_GetEquipmentinfoRecord";
        #endregion

        #region Auto Generated - DeviceInfo
        public const string AG_GetDeviceInfoRecord = "AG_GetDeviceInfoRecord";
        #endregion

        #region Auto Generated - LaptopDetails
        public const string AG_GetLaptopDetailsRecord = "AG_GetLaptopDetailsRecord";
        public const string AG_GetLaptopDetailsRecordByID = "AG_GetLaptopDetailsRecordByID";
        public const string AG_SaveLaptopDetails = "AG_SaveLaptopDetails";
        public const string AG_UpdateLaptopDetails = "AG_UpdateLaptopDetails";       
        #endregion

        #region Auto Generated - ALLDeviceinfoRecord
        public const string AG_GetALLDeviceinfoRecord = "AG_GetALLDeviceinfoRecord";
        #endregion

        #region Auto Generated - ServerDetails
        public const string AG_GetServerinfoRecord = "AG_GetServerinfoRecord";
        public const string AG_GetServerDetailsRecordByID = "AG_GetServerDetailsRecordByID";
        public const string AG_SaveServerDetails = "AG_SaveServerDetails";
        public const string AG_UpdateServerDetails = "AG_UpdateServerDetails";
        #endregion

        #region Auto Generated - PrinterDetails
        public const string AG_GetPrinterDetailsRecord = "AG_GetPrinterDetailsRecord";
        public const string AG_GetPrinterDetailsRecordByID = "AG_GetPrinterDetailsRecordByID";
        public const string AG_SavePrinterDetails = "AG_SavePrinterDetails";
        public const string AG_UpdatePrinterDetails = "AG_UpdatePrinterDetails";
        #endregion

        #region Auto Generated - Updateuserinfo
        public const string AG_GetUpdateuserinfoRecord = "AG_GetUpdateuserinfoRecord";
        public const string AG_GetUpdateusernameRecord = "AG_GetUpdateusernameRecord";  
        #endregion

        #region Auto Generated - UsercreateinfoRecord
        public const string AG_GetUsercreateinfoRecord = "AG_GetUsercreateinfoRecord";
        public const string AG_SaveUsercreateInfo = "AG_SaveUsercreateInfo";
        public const string AG_UpdateUsercreateInfo = "AG_UpdateUsercreateInfo";
        public const string AG_GetDuplicateMail = "AG_GetDuplicateMail";        
        #endregion

        #region Auto Generated - InventoryReporting
        public const string AG_GetALLDeviceinfoReport = "AG_GetALLDeviceinfoReport";
        //public const string AG_SaveUsercreateInfo = "AG_SaveUsercreateInfo";
        //public const string AG_UpdateUsercreateInfo = "AG_UpdateUsercreateInfo";
        //public const string AG_GetDuplicateMail = "AG_GetDuplicateMail";
        #endregion

        #region Auto Generated - Inv_ItemsList
        public const string AG_GetItemsListRecord = "AG_GetItemsListRecord";
        public const string AG_SaveInvitemsRecord = "AG_SaveInvitemRecord";
        public const string AG_UpdateInvitemsRecord = "AG_UpdateInvitemsRecord";
        public const string AG_DeleteInvitemsRecordById = "AG_DeleteInvitemsRecordById";
        public const string AG_GetmodelnameInfo = "AG_GetmodelnameInfo"; 
        #endregion

        #region Auto Generated - Inv_ModelList
        public const string AG_GetModelsListRecord = "AG_GetModelsListRecord";
        public const string AG_SaveInvmodelRecord = "AG_SaveInvmodelRecord";
        public const string AG_UpdateInvmodelRecord = "AG_UpdateInvmodelRecord";
        public const string AG_DeleteInvmodelRecordById = "AG_DeleteInvmodelRecordById";
        public const string AG_GetitemnameInfo = "AG_GetitemnameInfo";
        public const string AG_Getitemmodel = "AG_Getitemmodel";
        #endregion

        #region Auto Generated - Inv_ItemReceive
        public const string AG_GetitemreceiveListRecord = "AG_GetitemreceiveListRecord";
        public const string AG_SaveitemreceiveRecord = "AG_SaveitemreceiveRecord";
        public const string AG_UpdateitemreceiveRecord = "AG_UpdateitemreceiveRecord";
        //public const string AG_DeleteitemreceiveRecordById = "AG_DeleteitemreceiveRecordById";      
        #endregion

        #region Auto Generated - ReceiveIssue
        public const string AG_GetReceiveissueListRecord = "AG_GetReceiveissueListRecord";
        public const string AG_SaveReceiveissueRecord = "AG_SaveReceiveissueRecord";
        public const string AG_UpdateReceiveissueRecord = "AG_UpdateReceiveissueRecord";
        //public const string AG_DeleteitemreceiveRecordById = "AG_DeleteitemreceiveRecordById"; 
        public const string AG_GetSumvalueRecord = "AG_GetSumvalueRecord";
        public const string AG_GetusersumvalueRecord = "AG_GetusersumvalueRecord";
        public const string AG_GetAssetdistbyMDate = "AG_GetAssetdistbyMDate";
        public const string AG_GetassettransBylocdate = "AG_GetassettransBylocdate";
        public const string AG_GetFTRTransferListRecord = "AG_GetFTRTransferListRecord";
        public const string AG_SaveFTRTransferList = "AG_SaveFTRTransferList";
        public const string AG_UpdateFTRTransferList = "AG_UpdateFTRTransferList";
        #endregion

        #region Auto Generated - Userissue
        public const string AG_GetUserissueitemRecord = "AG_GetUserissueitemRecord";
        public const string AG_SaveUserissueInfo = "AG_SaveUserissueInfo";
        public const string AG_UpdateUserissueInfo = "AG_UpdateUserissueInfo";
        #endregion

        /// <summary>
        /// ///////////////////////////For Report Part
        /// hasib_aziz@yahoo.com
        /// </summary>
        #region Auto Generated - GetstockinfoListRecord
        public const string AG_GetstockinfoListRecord = "AG_GetstockinfoListRecord";
        public const string AG_GetstockinfoRecordByDate = "AG_GetstockinfoRecordByDate";
        public const string AG_GetstockinfoexcelByDate = "AG_GetstockinfoexcelByDate";
        public const string AG_GetftystockinfoListRecord = "AG_GetftystockinfoListRecord";
        public const string AG_GetpassissueListRecord = "AG_GetpassissueListRecord";
        public const string AG_GetpassissueListRecordByDate = "AG_GetpassissueListRecordByDate";
        public const string AG_GetpassissueListRecordView = "AG_GetpassissueListRecordView";
        #endregion

        #region Auto Generated - GetDevicenameRecord
        public const string AG_GetDevicenameRecord = "AG_GetDevicenameRecord";
        public const string AG_SaveDeviceInfo = "AG_SaveDeviceInfo";
        public const string AG_UpdateDeviceInfo = "AG_UpdateDeviceInfo";
        public const string AG_GetDupdevicename = "AG_GetDupdevicename";
        #endregion

        #region Auto Generated - GetLeaveinfolistRecord
        public const string AG_GetLeaveinfolistRecord = "AG_GetLeaveinfolistRecord";
        public const string AG_SaveLeaveinfoRecord = "AG_SaveLeaveinfoRecord";
        public const string AG_UpdateLeaveinfoRecord = "AG_UpdateLeaveinfoRecord";
        public const string AG_GetIdlesearchByuym = "AG_GetIdlesearchByuym";
        #endregion

        #region Auto Generated - GetServicinginfoRecord
        public const string AG_GetServiceinfolistRecord = "AG_GetServiceinfolistRecord";
        public const string AG_SaveServiceinfoRecord = "AG_SaveServiceinfoRecord";
        public const string AG_UpdateServiceinfoRecord="AG_UpdateServiceinfoRecord";
        public const string AG_GetAllEquipmentbyLocation = "AG_GetAllEquipmentbyLocation";
        public const string AG_GetAllEquipmentno = "AG_GetAllEquipmentno";

        public const string AG_GetXValRecord = "AG_GetXValRecord";
        public const string AG_GetYValRecord = "AG_GetYValRecord";
        #endregion

        #region Auto Generated - SupportRecord
        public const string AG_GetCountryRecord = "AG_GetCountryRecord";
        public const string AG_SaveCountryInfo = "AG_SaveCountryInfo";
        public const string AG_UpdateCountryInfo = "AG_UpdateCountryInfo";
        public const string AG_GetDupCountry = "AG_GetDupCountry";
        public const string AG_GetAllCountry = "AG_GetAllCountry";

        public const string AG_GetUnitRecord = "AG_GetUnitRecord";
        public const string AG_SaveUnitInfo = "AG_SaveUnitInfo";
        public const string AG_UpdateUnitInfo = "AG_UpdateUnitInfo";
        public const string AG_GetDupUnit = "AG_GetDupUnit";
        public const string AG_GetAllUnit = "AG_GetAllUnit";

        public const string AG_GetBuildinginfoRecord = "AG_GetBuildinginfoRecord";
        public const string AG_SaveBuildingInfo = "AG_SaveBuildingInfo";
        public const string AG_UpdateBuildingInfo = "AG_UpdateBuildingInfo";
        public const string AG_GetDupBuilding = "AG_GetDupBuilding";

        public const string AG_GetFloorinfofoRecord = "AG_GetFloorinfofoRecord";
        public const string AG_SaveFloorRecord = "AG_SaveFloorRecord";
        public const string AG_UpdateFloorRecord = "AG_UpdateFloorRecord";
        public const string AG_GetAllFloorinfo = "AG_GetAllFloorinfo";
        public const string AG_GetAllGetFloorByBNID = "AG_GetAllGetFloorByBNID";

        public const string AG_GetLineinfofoRecord = "AG_GetLineinfofoRecord";
        public const string AG_SaveLineRecord = "AG_SaveLineRecord";
        public const string AG_UpdateLineRecord = "AG_UpdateLineRecord";
        public const string AG_GetAllLineinfo = "AG_GetAllLineinfo";

        public const string AG_GetMachineinfofoRecord = "AG_GetMachineinfofoRecord";
        public const string AG_SaveMachineInfo = "AG_SaveMachineInfo";
        public const string AG_UpdateMachineInfo = "AG_UpdateMachineInfo";
        public const string AG_GetAllMachineinfo = "AG_GetAllMachineinfo";
        public const string AG_GetMachinedetail = "AG_GetMachinedetail";

        #endregion

        #region Auto Generated - EquipmentinfoRecord
        public const string AG_GetEquipmentinfoRecord = "AG_GetEquipmentinfoRecord";
        public const string AG_SaveEquipmentDetails = "AG_SaveEquipmentDetails";
        public const string AG_UpdateEquipmentDetails = "AG_UpdateEquipmentDetails";
        public const string AG_GetEQAutonumber = "AG_GetEQAutonumber";
        public const string AG_GetAllENUMBERList = "AG_GetAllENUMBERList";
        public const string AG_GetAllBuildinginfo = "AG_GetAllBuildinginfo";
        #endregion

    }
}
