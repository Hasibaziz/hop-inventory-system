using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Structure;
using ERP.Domain.Model;
using System.Threading;
using System.Data;
using ERP.Models;
using System.IO;
using System.Collections;
using ERP.Mail;
using ERP.Utility;
using System.Text;
using ERP.Reports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace ERP.Controllers
{
    public class InventoryController : BaseController
    {
        //
        // GET: /Inventory/Hasib

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DepartmentInfo()
        {
            return View();
        }
        public ActionResult EmployeeInfo()
        {
            return View();
        }
        public ActionResult DeviceName()
        {
            return View();
        }
        [HttpPost]
        public JsonResult DevicenameList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetDevicenameRecord, null);
                    List<InvDevicenameEntity> ItemList = null;
                    ItemList = new List<InvDevicenameEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvDevicenameEntity()
                            {
                                DeviceID = dr["DeviceID"].ToString(),
                                DeviceName = dr["DeviceName"].ToString(),
                                Description = dr["Description"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult AddUpdateDeviceInfo(InvDevicenameEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }


                bool isUpdate = false;
                if (_Model.DeviceID == null)
                    if (Dupdevicenamecheck(_Model.DeviceName) != false)
                        return Json(new { Result = "Message", Message = "The Device Name is already taken. Please choose another." });
                    else
                    {
                        isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveDeviceInfo, _Model);
                    }
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateDeviceInfo, _Model);
                if (isUpdate)
                {
                    var addedModel = _Model;
                    return Json(new { Result = "OK", Record = addedModel });
                }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        public bool Dupdevicenamecheck(string UserID)
        {
            try
            {
                InvDevicenameEntity obj = (InvDevicenameEntity)GetDupdevicename(UserID);
                //var obj1 = GetDupMail(UserID);                
                if (obj.DeviceName == null)
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public ActionResult Inventory()
        {
            return View();
        }
        public ActionResult AllDeviceinfo()
        {
            InvDepartmentinfoEntity DeptEntity = new InvDepartmentinfoEntity();
            ViewData["DeptID"] = GetAllDepartmentnameList(DeptEntity);
            EmployeeinfoEntity EMP = new EmployeeinfoEntity();
            ViewData["EmpID"] = GetAllEmployeenameList(EMP);
            ///ViewData["EmpID"] = GetAllEmployeeName(EMP);
            InvDeviceinfoEntity DEV = new InvDeviceinfoEntity();
            ViewData["DeviceID"] = GetAllDeviceList(DEV);
            return View();
        }
        [HttpPost]
        public JsonResult AllDeviceinfoList(InvInventorydetailsEntity _model, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    _model.Location = CurrentLocation;            
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetALLDeviceinfoRecord, _model);
                    List<InvInventorydetailsEntity> ItemList = null;
                    ItemList = new List<InvInventorydetailsEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvInventorydetailsEntity()
                            {
                                //SL = (iCount + 1).ToString(),
                                ENumber = dr["ENumber"].ToString(),
                                AccountID = dr["AccountID"].ToString(),
                                Office=dr["Office"].ToString(),
                                Proposed=dr["Proposed"].ToString(),
                                AccountCode = dr["AccountCode"].ToString(),
                                BrandModel = dr["BrandModel"].ToString(),
                                Configuration = dr["Configuration"].ToString(),
                                Category = dr["Category"].ToString(),
                                SerialNo = dr["SerialNo"].ToString(),
                                Location = dr["Location"].ToString(),
                                DeptID = dr["DeptID"].ToString(),
                                EMPID = dr["EMPID"].ToString(),
                                EMPNAME = dr["EMPNAME"].ToString(),
                                PurchDate =dr["PurchDate"].ToString(),
                                Remark = dr["Remark"].ToString(),
                                MonitorID = dr["MonitorID"].ToString(),
                                UPSID = dr["UPSID"].ToString(),
                                Team = dr["Team"].ToString(),
                                Status = dr["Status"].ToString(),
                                HostName = dr["HostName"].ToString(),
                                ITemNo = dr["ITemNo"].ToString(),
                                DeviceID = dr["DeviceID"].ToString(),
                                Y = dr["Y"].ToString(),
                                M = dr["M"].ToString(),
                                D = dr["D"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
       
        [HttpPost]
        public JsonResult InventoryInfoList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllInventoryInfoRecord, null);
                    List<InventoryModel> ItemList = null;
                    ItemList = new List<InventoryModel>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InventoryModel()
                            {
                                AccID = dr["AccID"].ToString(),
                                AccCode = dr["AccCode"].ToString(),
                                BrandModel = dr["BrandModel"].ToString(),
                                Configuration = dr["Configuration"].ToString(),
                                Category = dr["Category"].ToString(),
                                SerialNo = dr["SerialNo"].ToString(),
                                Location = dr["Location"].ToString(),
                                UserName = dr["UserName"].ToString(),
                                PurchDate = dr["PurchDate"].ToString(),
                                Remark = dr["Remark"].ToString(),
                                MonitorSLNO = dr["MonitorSLNO"].ToString(),
                                UpsSLNO = dr["UpsSLNO"].ToString(),
                                DeptNo = dr["DeptNo"].ToString(),
                                Team = dr["Team"].ToString(),
                                Status = dr["Status"].ToString(),
                                HostName = dr["HostName"].ToString(),
                                ITemNo = dr["ITemNo"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult AddUpdateInventoryInfo(InventoryModel _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }


                bool isUpdate = false;
                if (_Model.AccID == null)
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveInventoryInfo, _Model);
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateInventoryInfo, _Model);
                if (isUpdate)
                {
                    var addedModel = _Model;
                    return Json(new { Result = "OK", Record = addedModel });
                }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult DeleteInventoryInfo(string ID)
        {
            try
            {
                Thread.Sleep(50);
                bool isUpdate = false;
                isUpdate = (bool)ExecuteDB(ERPTask.AG_DeleteInventoryInfoById, ID);
                if (isUpdate)
                    return Json(new { Result = "OK" });
                else
                    return Json(new { Result = "ERROR", Message = "Failed to Delete" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public ActionResult Equipmentinfo()
        {
            //InvDepartmentinfoEntity DeptEntity = new InvDepartmentinfoEntity();
            //ViewData["DeptID"] = GetAllDepartmentnameList(DeptEntity);
            InvCountryinfoEntity Country = new InvCountryinfoEntity();
            ViewData["CID"] = GetCountry(Country);           
            InvUnitinfoEntity Units = new InvUnitinfoEntity();
            ViewData["UnitID"] = GetAllUnit(Units);
            Invlocation LocEntity = new Invlocation();
            //LocEntity.Location = CurrentLocation;
            //LocEntity.Userstatus = CurrentUserstatus;
            ViewData["LocID"] = GetLocation(LocEntity);
            return View();
        }
        [HttpPost]
        public JsonResult EquipmentinfoList(InvEquipmentEntity _Model, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    //_Model.Location = CurrentLocation;
                    //_Model.Userstatus = CurrentUserstatus;
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetEquipmentinfoRecord, _Model);
                    List<InvEquipmentEntity> ItemList = null;
                    ItemList = new List<InvEquipmentEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvEquipmentEntity()
                            {
                                SL = (iCount + 1).ToString(),
                                EID = dr["EID"].ToString(),
                                LocID = dr["LocID"].ToString(),
                                ENumber = dr["ENumber"].ToString(),                               
                                AccountCode = dr["AccountCode"].ToString(),
                                AssetCode = dr["AssetCode"].ToString(), 
                                Brand = dr["Brand"].ToString(),
                                Model = dr["Model"].ToString(),
                                Serialno = dr["Serialno"].ToString(),
                                Subserialno = dr["Subserialno"].ToString(),
                                MNID = dr["MNID"].ToString(),
                                Machineid = dr["Machineid"].ToString(),
                                Lifetime = dr["Lifetime"].ToString(),
                                PurchDate = dr["PurchDate"].ToString(),
                                UnitID = dr["UnitID"].ToString(),
                                BNID = dr["BNID"].ToString(),
                                FID = dr["FID"].ToString(),
                                LID = dr["LID"].ToString(),
                                Status = dr["Status"].ToString(),
                                Remarks = dr["Remarks"].ToString(),
                                CID = dr["CID"].ToString()                              
                                                             
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        public JsonResult AllEQPList()
        {
            try
            {
                InvEquipmentEntity models = new InvEquipmentEntity();
                //models.Userstatus = CurrentUserstatus;
                //models.Location = CurrentLocation;
                var jList = GetAllEquipment(models).Select(c => new { DisplayText = c.Text, Value = c.Value });
                return Json(new { Result = "OK", Options = jList });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
       


        [HttpPost]
        public JsonResult DepartmentInfoList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetDepartmentInfoRecord, null);
                    List<InvDepartmentinfoEntity> ItemList = null;
                    ItemList = new List<InvDepartmentinfoEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvDepartmentinfoEntity()
                            {
                                DeptID=dr["DeptID"].ToString(),
                                DeptNo = dr["DeptNo"].ToString(),
                                DeptName = dr["DeptName"].ToString(),
                                Description = dr["Description"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult AddUpdateDepartmentInfo(InvDepartmentinfoEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }


                bool isUpdate = false;
                if (_Model.DeptID == null)
                    if (Dupdeptcheck(_Model.DeptNo) != false)
                        return Json(new { Result = "Message", Message = "The Department ID is already taken. Please choose another." });
                    else
                    {
                        isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveDepartmentInfo, _Model);
                    }
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateDepartmentInfo, _Model);
                if (isUpdate)
                {
                    var addedModel = _Model;
                    return Json(new { Result = "OK", Record = addedModel });
                }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult DeleteDepartmentInfo(string DeptID)
        {
            try
            {
                Thread.Sleep(50);
                bool isUpdate = false;
                isUpdate = (bool)ExecuteDB(ERPTask.AG_DeleteDepartmentInfoById, DeptID);
                if (isUpdate)
                    return Json(new { Result = "OK" });
                else
                    return Json(new { Result = "ERROR", Message = "Failed to Delete" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult AllDepartmentNameListItem()
        {
            try
            {
                InvDepartmentinfoEntity Dept = new InvDepartmentinfoEntity();
                var jList = GetAllDepartmentnameList(Dept).Select(c => new { DisplayText = c.Text, Value = c.Value });
                return Json(new { Result = "OK", Options = jList });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult EmployeeInfoList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetEmployeeInfoRecord, null);
                    List<EmployeeinfoEntity> ItemList = null;
                    ItemList = new List<EmployeeinfoEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new EmployeeinfoEntity()
                            {
                                EmpID = dr["EmpID"].ToString(),
                                EmpNo = dr["EmpNo"].ToString(),
                                EmpName = dr["EmpName"].ToString(),
                                DeptID = dr["DeptID"].ToString(),
                                Location=dr["Location"].ToString(),
                                JoinDate = dr["JoinDate"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult AddUpdateEmployeeInfo(EmployeeinfoEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }


                bool isUpdate = false;
                if (_Model.EmpID == null)
                    if (Dupempcheck(_Model.EmpNo) != false)                       
                        return Json(new { Result = "Message", Message = "The Employee ID is already taken. Please choose another." });                   
                    else
                    {
                        isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveEmployeeInfo, _Model);
                    }
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateEmployeeInfo, _Model);
                if (isUpdate)
                {
                    var addedModel = _Model;
                    return Json(new { Result = "OK", Record = addedModel });
                }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult DeleteEmployeeInfo(string EmpID)
        {
            try
            {
                Thread.Sleep(50);
                bool isUpdate = false;
                isUpdate = (bool)ExecuteDB(ERPTask.AG_DeleteEmployeeInfoById, EmpID);
                if (isUpdate)
                    return Json(new { Result = "OK" });
                else
                    return Json(new { Result = "ERROR", Message = "Failed to Delete" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult AllEmployeeNameListItem()
        {
            try
            {
                EmployeeinfoEntity EMP = new EmployeeinfoEntity();
                var jList = GetAllEmployeenameList(EMP).Select(c => new { DisplayText = c.Text, Value = c.Value });
                return Json(new { Result = "OK", Options = jList });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult AllEmployeeNameItem()
        {
            try
            {
                EmployeeinfoEntity EMP = new EmployeeinfoEntity();
                var jList = GetAllEmployeeName(EMP).Select(c => new { DisplayText = c.Text, Value = c.Value });
                return Json(new { Result = "OK", Options = jList });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult AllDeviceNameListItem()
        {
            try
            {
                InvDeviceinfoEntity DEV = new InvDeviceinfoEntity();
                var jList = GetAllDeviceList(DEV).Select(c => new { DisplayText = c.Text, Value = c.Value });
                return Json(new { Result = "OK", Options = jList });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpGet]
        public ActionResult InventoryDetails()
        {
            InvDepartmentinfoEntity DeptEntity = new InvDepartmentinfoEntity();
            ViewData["DeptID"] = GetAllDepartmentnameList(DeptEntity);
            EmployeeinfoEntity EMP = new EmployeeinfoEntity();
            ViewData["EmpID"] = GetAllEmployeenameList(EMP);
            InvDeviceinfoEntity DEV = new InvDeviceinfoEntity();
            ViewData["DeviceID"] = GetAllDeviceList(DEV);
            return View();
        }
///////////////////////******************** For Selecting Department Wise Employee ID **********************////////////////////////
        //public JsonResult EmployeeList(string ClassID)
        //{
        //    try
        //    {
        //        return Json(GetEmployeeList(ClassID));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Result = "ERROR", Message = ex.Message });
        //    }
        //}

        //private List<SelectListItem> GetEmployeeList(string DEPT)
        //{
        //    InvInventorydetailsEntity bh = new InvInventorydetailsEntity();
        //    bh.DeptID = DEPT;

        //    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllInvEmployeeRecordByEmpId, bh);
        //    List<SelectListItem> Items = new List<SelectListItem>();
        //    if (dt.Rows.Count > 0)
        //    {
        //        Items.Add(new SelectListItem { Text = "", Value = "" });
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            Items.Add(new SelectListItem { Text = dr["EmpNo"].ToString(), Value = dr["DeptID"].ToString() });
        //        }
        //    }
        //    else
        //    {
        //        Items = new List<SelectListItem>();
        //        Items.Add(new SelectListItem { Text = "", Value = "" });
        //    }
        //    return Items;
        //}
//////////////////////////////********************************************************//////////////////////////////////////////////
        public JsonResult GetEmployeeInfo(string UserID)
        {
            if (UserID.ToString().Trim() == "")
            {
                return Json(new { Result = "ERROR", Message = "Enter SupplierID" });
            }
            else
            {
                try
                {
                    InvInventorydetailsEntity obj = (InvInventorydetailsEntity)GetInventoryDetails(UserID);

                    return Json(obj);
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
        }

/////////////////////////////////////////////////***********************************Hasib////////////////////////////////////////////////
        [HttpPost]
        public JsonResult InventoryDetailsList(InvInventorydetailsEntity _Model, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    _Model.Location = CurrentLocation;
                    _Model.Userstatus = CurrentUserstatus;
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetInventoryDetailsRecord, _Model);
                    List<InventorydetailsEntity> ItemList = null;
                    ItemList = new List<InventorydetailsEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InventorydetailsEntity()
                            {
                                //SL = (iCount + 1).ToString(),
                                ENumber = dr["ENumber"].ToString(),
                                AccountID = dr["AccountID"].ToString(),
                                AccountCode = dr["AccountCode"].ToString(),
                                Office = dr["Office"].ToString(),
                                Proposed = dr["Proposed"].ToString(),
                                BrandModel = dr["BrandModel"].ToString(),
                                Configuration = dr["Configuration"].ToString(),
                                Category = dr["Category"].ToString(),
                                SerialNo = dr["SerialNo"].ToString(),
                                Location = dr["Location"].ToString(),
                                DeptID = dr["DeptID"].ToString(),
                                EMPID = dr["EMPID"].ToString(),
                                EMPNAME = dr["EMPNAME"].ToString(),
                                PurchDate = dr["PurchDate"].ToString(),
                                Remark = dr["Remark"].ToString(),
                                MonitorID = dr["MonitorID"].ToString(),
                                UPSID = dr["UPSID"].ToString(),                                
                                Team = dr["Team"].ToString(),
                                Status = dr["Status"].ToString(),
                                HostName = dr["HostName"].ToString(),
                                ITemNo = dr["ITemNo"].ToString(),
                                DeviceID = dr["DeviceID"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult DeleteInventoryDetails(string AccountID)
        {
            try
            {
                Thread.Sleep(50);
                bool isUpdate = false;
                isUpdate = (bool)ExecuteDB(ERPTask.AG_DeleteInventoryDetailsById, AccountID);
                if (isUpdate)
                    return Json(new { Result = "OK" });
                else
                    return Json(new { Result = "ERROR", Message = "Failed to Delete" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }


        [HttpPost]
        public ActionResult InventoryDetailsbyID(InvInventorydetailsEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                _Model.UserID = CurrentUserId;
                _Model.Modifydate = LoginDatetime;
                bool isUpdate = false;
                if (_Model.AccountID == null)
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveInventoryDetails, _Model);
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateInventoryDetails, _Model);
                if (isUpdate)
                {
                    //var addedModel = _Model;
                    //return Json(new { Result = "OK", Record = addedModel });
                    return RedirectToAction("InventoryDetailsView", "Inventory");
                }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public ActionResult InventoryDetailsView()
        {
            InvDepartmentinfoEntity DeptEntity = new InvDepartmentinfoEntity();
            ViewData["DeptID"] = GetAllDepartmentnameList(DeptEntity);
            return View();
        }
        [HttpGet]
        public ActionResult InventoryDetailsbyID(String ID)
        {
            InvInventorydetailsEntity _Model = new InvInventorydetailsEntity();

            InvDepartmentinfoEntity DeptEntity = new InvDepartmentinfoEntity();
            ViewData["DeptName"] = GetAllDepartmentnameList(DeptEntity);
            EmployeeinfoEntity EMP = new EmployeeinfoEntity();
            ViewData["EmpNo"] = GetAllEmployeenameList(EMP);
            InvDeviceinfoEntity DEV = new InvDeviceinfoEntity();
            ViewData["DeviceName"] = GetAllDeviceList(DEV);

            if (ID != null)
            {
                DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetInventoryDetailsRecordByID, ID);
                List<InvInventorydetailsEntity> ItemList = null;
                ItemList = new List<InvInventorydetailsEntity>();

                foreach (DataRow dr in dt.Rows)
                {
                    _Model.AccountID = dr["AccountID"].ToString();
                    _Model.AccountCode = dr["AccountCode"].ToString();
                    _Model.BrandModel = dr["BrandModel"].ToString();
                    _Model.Configuration = dr["Configuration"].ToString();
                    _Model.Category = dr["Category"].ToString();
                    _Model.SerialNo = dr["SerialNo"].ToString();
                    _Model.Location = dr["Location"].ToString();
                    _Model.DeptID = dr["DeptID"].ToString();
                    _Model.EMPID = dr["EMPID"].ToString();
                    _Model.PurchDate = dr["PurchDate"].ToString();
                    _Model.Remark = dr["Remark"].ToString();
                    //_Model.MonitorID = dr["MonitorID"].ToString();
                    //_Model.UPSID = dr["UPSID"].ToString();
                    _Model.Team = dr["Team"].ToString();
                    _Model.Status = dr["Status"].ToString();
                    _Model.HostName = dr["HostName"].ToString();
                    _Model.ITemNo = dr["ITemNo"].ToString();
                    _Model.DeviceID = dr["DeviceID"].ToString();
                    _Model.Office = dr["Office"].ToString();
                    _Model.Proposed = dr["Proposed"].ToString();

                    _Model.MonitorID = dr["MonitorID"].ToString();
                    _Model.MonitorName = dr["MonitorName"].ToString();
                    _Model.MModelNo = dr["MModelNo"].ToString();
                    _Model.MSerialNo = dr["MSerialNo"].ToString();
                    _Model.MPurchDate = dr["MPurchDate"].ToString();
                    _Model.MDistDate = dr["MDistDate"].ToString();

                    _Model.UPSID = dr["UPSID"].ToString();
                    _Model.UPSName = dr["UPSName"].ToString();
                    _Model.UModelNo = dr["UModelNo"].ToString();
                    _Model.USerialNo = dr["USerialNo"].ToString();
                    _Model.UPurchDate = dr["UPurchDate"].ToString();
                    _Model.UDistDate = dr["UDistDate"].ToString();

                }

            }

            return View("InventoryDetails",_Model);
        }
        [HttpPost]
        public JsonResult OLDInfoList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetOLDInfoRecord, null);
                    List<OLDInfoEntity> ItemList = null;
                    ItemList = new List<OLDInfoEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new OLDInfoEntity()
                            {
                                OLDID = dr["OLDID"].ToString(),
                                CPUID = dr["CPUID"].ToString(),
                                CPUCONFIG = dr["CPUCONFIG"].ToString(),
                                MONITORID = dr["MONITORID"].ToString(),
                                UPSID = dr["UPSID"].ToString(),
                                EMPID = dr["EMPID"].ToString(),
                                Dateofplace = dr["Dateofplace"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }


        public ActionResult Laptopinfo()
        {
            InvDepartmentinfoEntity DeptEntity = new InvDepartmentinfoEntity();
            ViewData["DeptID"] = GetAllDepartmentnameList(DeptEntity);
            EmployeeinfoEntity EMP = new EmployeeinfoEntity();
            ViewData["EmpID"] = GetAllEmployeenameList(EMP);
            InvDeviceinfoEntity DEV = new InvDeviceinfoEntity();
            ViewData["DeviceID"] = GetAllDeviceList(DEV);
            return View();
        }
        [HttpPost]
        public JsonResult LaptopinfoList(InvInventorydetailsEntity _Model,  int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    _Model.Location = CurrentLocation;
                    _Model.Userstatus = CurrentUserstatus;
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetLaptopDetailsRecord, _Model);
                    List<InvInventorydetailsEntity> ItemList = null;
                    ItemList = new List<InvInventorydetailsEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvInventorydetailsEntity()
                            {
                                SL = (iCount + 1).ToString(),
                                AccountID = dr["AccountID"].ToString(),
                                AccountCode = dr["AccountCode"].ToString(),
                                BrandModel = dr["BrandModel"].ToString(),
                                Configuration = dr["Configuration"].ToString(),
                                Category = dr["Category"].ToString(),
                                SerialNo = dr["SerialNo"].ToString(),
                                Location = dr["Location"].ToString(),
                                DeptID = dr["DeptID"].ToString(),
                                EMPID = dr["EMPID"].ToString(),
                                EMPNAME = dr["EMPNAME"].ToString(),
                                PurchDate = dr["PurchDate"].ToString(),
                                Remark = dr["Remark"].ToString(),
                               // MonitorID = dr["MonitorID"].ToString(),
                               // UPSID = dr["UPSID"].ToString(),
                                Team = dr["Team"].ToString(),
                                Status = dr["Status"].ToString(),
                                HostName = dr["HostName"].ToString(),
                                ITemNo = dr["ITemNo"].ToString(),
                                DeviceID = dr["DeviceID"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpGet]
        public ActionResult LaptopDetails()
        {
            InvDepartmentinfoEntity DeptEntity = new InvDepartmentinfoEntity();
            ViewData["DeptID"] = GetAllDepartmentnameList(DeptEntity);
            EmployeeinfoEntity EMP = new EmployeeinfoEntity();
            ViewData["EmpID"] = GetAllEmployeenameList(EMP);
            InvDeviceinfoEntity DEV = new InvDeviceinfoEntity();
            ViewData["DeviceID"] = GetAllDeviceList(DEV);
            return View();
        }
        [HttpGet]
        public ActionResult LaptopDetailsbyID(String ID)
        {
            InvInventorydetailsEntity _Model = new InvInventorydetailsEntity();

            InvDepartmentinfoEntity DeptEntity = new InvDepartmentinfoEntity();
            ViewData["DeptName"] = GetAllDepartmentnameList(DeptEntity);
            EmployeeinfoEntity EMP = new EmployeeinfoEntity();
            ViewData["EmpNo"] = GetAllEmployeenameList(EMP);
            InvDeviceinfoEntity DEV = new InvDeviceinfoEntity();
            ViewData["DeviceName"] = GetAllDeviceList(DEV);

            if (ID != null)
            {
                DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetLaptopDetailsRecordByID, ID);
                List<InvInventorydetailsEntity> ItemList = null;
                ItemList = new List<InvInventorydetailsEntity>();

                foreach (DataRow dr in dt.Rows)
                {
                    _Model.AccountID = dr["AccountID"].ToString();
                    _Model.AccountCode = dr["AccountCode"].ToString();
                    _Model.BrandModel = dr["BrandModel"].ToString();
                    _Model.Configuration = dr["Configuration"].ToString();
                    _Model.Category = dr["Category"].ToString();
                    _Model.SerialNo = dr["SerialNo"].ToString();
                    _Model.Location = dr["Location"].ToString();
                    _Model.DeptID = dr["DeptID"].ToString();
                    _Model.EMPID = dr["EMPID"].ToString();
                    _Model.PurchDate = dr["PurchDate"].ToString();
                    _Model.Remark = dr["Remark"].ToString();
                    //_Model.MonitorID = dr["MonitorID"].ToString();
                    //_Model.UPSID = dr["UPSID"].ToString();
                    _Model.Team = dr["Team"].ToString();
                    _Model.Status = dr["Status"].ToString();
                    _Model.HostName = dr["HostName"].ToString();
                    _Model.ITemNo = dr["ITemNo"].ToString();
                    _Model.DeviceID = dr["DeviceID"].ToString();                  

                }

            }

            return View("LaptopDetails", _Model);
        }
        [HttpPost]
        public ActionResult LaptopDetailsbyID(InvInventorydetailsEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                _Model.Location = CurrentLocation;
                _Model.Userstatus = CurrentUserstatus;
                bool isUpdate = false;
                if (_Model.AccountID == null)
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveLaptopDetails, _Model);
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateLaptopDetails, _Model);
                if (isUpdate)
                {
                    //var addedModel = _Model;
                    //return Json(new { Result = "OK", Record = addedModel });
                    return RedirectToAction("Laptopinfo", "Inventory");
                }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }


        public ActionResult Serverinfo()
        {
            InvDepartmentinfoEntity DeptEntity = new InvDepartmentinfoEntity();
            ViewData["DeptID"] = GetAllDepartmentnameList(DeptEntity);
            EmployeeinfoEntity EMP = new EmployeeinfoEntity();
            ViewData["EmpID"] = GetAllEmployeenameList(EMP);
            InvDeviceinfoEntity DEV = new InvDeviceinfoEntity();
            ViewData["DeviceID"] = GetAllDeviceList(DEV);
            return View();
        }
        [HttpPost]
        public JsonResult ServerinfoList(InvInventorydetailsEntity _Model,  int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    _Model.Location = CurrentLocation;
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetServerinfoRecord, _Model);
                    List<InvInventorydetailsEntity> ItemList = null;
                    ItemList = new List<InvInventorydetailsEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvInventorydetailsEntity()
                            {
                                SL = (iCount + 1).ToString(),
                                AccountID = dr["AccountID"].ToString(),
                                AccountCode = dr["AccountCode"].ToString(),
                                BrandModel = dr["BrandModel"].ToString(),
                                Configuration = dr["Configuration"].ToString(),
                                Category = dr["Category"].ToString(),
                                SerialNo = dr["SerialNo"].ToString(),
                                Location = dr["Location"].ToString(),
                                DeptID = dr["DeptID"].ToString(),
                                EMPID = dr["EMPID"].ToString(),
                                EMPNAME = dr["EMPNAME"].ToString(),
                                PurchDate = dr["PurchDate"].ToString(),
                                Remark = dr["Remark"].ToString(),
                                // MonitorID = dr["MonitorID"].ToString(),
                                // UPSID = dr["UPSID"].ToString(),
                                Team = dr["Team"].ToString(),
                                Status = dr["Status"].ToString(),
                                HostName = dr["HostName"].ToString(),
                                ITemNo = dr["ITemNo"].ToString(),
                                DeviceID = dr["DeviceID"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpGet]
        public ActionResult ServerDetails()
        {
           
            InvDepartmentinfoEntity DeptEntity = new InvDepartmentinfoEntity();
            ViewData["DeptID"] = GetAllDepartmentnameList(DeptEntity);
            EmployeeinfoEntity EMP = new EmployeeinfoEntity();
            ViewData["EmpID"] = GetAllEmployeenameList(EMP);
            InvDeviceinfoEntity DEV = new InvDeviceinfoEntity();
            ViewData["DeviceID"] = GetAllDeviceList(DEV);
            return View();
        }
        [HttpGet]
        public ActionResult ServerDetailsbyID(String ID)
        {
            InvInventorydetailsEntity _Model = new InvInventorydetailsEntity();

            InvDepartmentinfoEntity DeptEntity = new InvDepartmentinfoEntity();
            ViewData["DeptName"] = GetAllDepartmentnameList(DeptEntity);
            EmployeeinfoEntity EMP = new EmployeeinfoEntity();
            ViewData["EmpNo"] = GetAllEmployeenameList(EMP);
            InvDeviceinfoEntity DEV = new InvDeviceinfoEntity();
            ViewData["DeviceName"] = GetAllDeviceList(DEV);

            if (ID != null)
            {
                DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetServerDetailsRecordByID, ID);
                List<InvInventorydetailsEntity> ItemList = null;
                ItemList = new List<InvInventorydetailsEntity>();

                foreach (DataRow dr in dt.Rows)
                {
                    _Model.AccountID = dr["AccountID"].ToString();
                    _Model.AccountCode = dr["AccountCode"].ToString();
                    _Model.BrandModel = dr["BrandModel"].ToString();
                    _Model.Configuration = dr["Configuration"].ToString();
                    _Model.Category = dr["Category"].ToString();
                    _Model.SerialNo = dr["SerialNo"].ToString();
                    _Model.Location = dr["Location"].ToString();
                    _Model.DeptID = dr["DeptID"].ToString();
                    _Model.EMPID = dr["EMPID"].ToString();
                    _Model.PurchDate = dr["PurchDate"].ToString();
                    _Model.Remark = dr["Remark"].ToString();
                    //_Model.MonitorID = dr["MonitorID"].ToString();
                    //_Model.UPSID = dr["UPSID"].ToString();
                    _Model.Team = dr["Team"].ToString();
                    _Model.Status = dr["Status"].ToString();
                    _Model.HostName = dr["HostName"].ToString();
                    _Model.ITemNo = dr["ITemNo"].ToString();
                    _Model.DeviceID = dr["DeviceID"].ToString();

                    _Model.MonitorID = dr["MonitorID"].ToString();
                    _Model.MonitorName = dr["MonitorName"].ToString();
                    _Model.MModelNo = dr["MModelNo"].ToString();
                    _Model.MSerialNo = dr["MSerialNo"].ToString();
                    _Model.MPurchDate = dr["MPurchDate"].ToString();
                    _Model.MDistDate = dr["MDistDate"].ToString();

                }

            }

            return View("ServerDetails", _Model);
        }
        [HttpPost]
        public ActionResult ServerDetailsbyID(InvInventorydetailsEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }


                bool isUpdate = false;
                if (_Model.AccountID == null)
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveServerDetails, _Model);
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateServerDetails, _Model);
                if (isUpdate)
                {
                    //var addedModel = _Model;
                    //return Json(new { Result = "OK", Record = addedModel });
                    return RedirectToAction("Serverinfo", "Inventory");
                }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }


        public ActionResult PrinterDetails()
        {
            InvDepartmentinfoEntity DeptEntity = new InvDepartmentinfoEntity();
            ViewData["DeptID"] = GetAllDepartmentnameList(DeptEntity);
            EmployeeinfoEntity EMP = new EmployeeinfoEntity();
            ViewData["EmpID"] = GetAllEmployeenameList(EMP);
            InvDeviceinfoEntity DEV = new InvDeviceinfoEntity();
            ViewData["DeviceID"] = GetAllDeviceList(DEV);
            return View();
        }
        public ActionResult PrinterView()
        {
            InvDepartmentinfoEntity DeptEntity = new InvDepartmentinfoEntity();
            ViewData["DeptID"] = GetAllDepartmentnameList(DeptEntity);
            EmployeeinfoEntity EMP = new EmployeeinfoEntity();
            ViewData["EmpID"] = GetAllEmployeenameList(EMP);
            InvDeviceinfoEntity DEV = new InvDeviceinfoEntity();
            ViewData["DeviceID"] = GetAllDeviceList(DEV);
            return View();
        }
        [HttpGet]
        public ActionResult PrinterDetailsbyID(String ID)
        {
            InvInventorydetailsEntity _Model = new InvInventorydetailsEntity();

            InvDepartmentinfoEntity DeptEntity = new InvDepartmentinfoEntity();
            ViewData["DeptName"] = GetAllDepartmentnameList(DeptEntity);
            EmployeeinfoEntity EMP = new EmployeeinfoEntity();
            ViewData["EmpNo"] = GetAllEmployeenameList(EMP);
            InvDeviceinfoEntity DEV = new InvDeviceinfoEntity();
            ViewData["DeviceName"] = GetAllDeviceList(DEV);

            if (ID != null)
            {
                DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetPrinterDetailsRecordByID, ID);
                List<InvInventorydetailsEntity> ItemList = null;
                ItemList = new List<InvInventorydetailsEntity>();

                foreach (DataRow dr in dt.Rows)
                {
                    _Model.AccountID = dr["AccountID"].ToString();
                    _Model.AccountCode = dr["AccountCode"].ToString();
                    _Model.BrandModel = dr["BrandModel"].ToString();
                    _Model.Configuration = dr["Configuration"].ToString();
                    _Model.Category = dr["Category"].ToString();
                    _Model.SerialNo = dr["SerialNo"].ToString();
                    _Model.Location = dr["Location"].ToString();
                    _Model.DeptID = dr["DeptID"].ToString();
                    _Model.EMPID = dr["EMPID"].ToString();
                    _Model.PurchDate = dr["PurchDate"].ToString();
                    _Model.Remark = dr["Remark"].ToString();
                    _Model.Team = dr["Team"].ToString();
                    _Model.Status = dr["Status"].ToString();
                    _Model.HostName = dr["HostName"].ToString();
                    _Model.ITemNo = dr["ITemNo"].ToString();
                    _Model.DeviceID = dr["DeviceID"].ToString();

                    _Model.PrinterID=dr["PrinterID"].ToString();
                    _Model.PrinterName = dr["PrinterName"].ToString();
                    _Model.IPMAC=dr["IPMAC"].ToString();
                    _Model.PPurchDate=dr["PPurchDate"].ToString();
                    _Model.PDistDate=dr["PDistDate"].ToString();
                    _Model.Type=dr["Type"].ToString();
                    _Model.Totaluser=dr["Totaluser"].ToString();
                    _Model.Dailyppage = dr["Dailyppage"].ToString();

                }

            }

            return View("PrinterDetails", _Model);
        }
        [HttpPost]
        public JsonResult PrinterDetailsList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetPrinterDetailsRecord, null);
                    List<InvInventorydetailsEntity> ItemList = null;
                    ItemList = new List<InvInventorydetailsEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvInventorydetailsEntity()
                            {
                                SL = (iCount + 1).ToString(),
                                AccountID = dr["AccountID"].ToString(),
                                AccountCode = dr["AccountCode"].ToString(),
                                BrandModel = dr["BrandModel"].ToString(),
                                Configuration = dr["Configuration"].ToString(),
                                Category = dr["Category"].ToString(),
                                SerialNo = dr["SerialNo"].ToString(),
                                Location = dr["Location"].ToString(),
                                DeptID = dr["DeptID"].ToString(),
                                EMPID = dr["EMPID"].ToString(),
                                EMPNAME = dr["EMPNAME"].ToString(),
                                PurchDate = dr["PurchDate"].ToString(),
                                Remark = dr["Remark"].ToString(),
                                Team = dr["Team"].ToString(),
                                Status = dr["Status"].ToString(),
                                HostName = dr["HostName"].ToString(),
                                ITemNo = dr["ITemNo"].ToString(),
                                DeviceID = dr["DeviceID"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public ActionResult PrinterDetailsbyID(InvInventorydetailsEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }


                bool isUpdate = false;
                if (_Model.AccountID == null)
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_SavePrinterDetails, _Model);
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdatePrinterDetails, _Model);
                if (isUpdate)
                {
                    //var addedModel = _Model;
                    //return Json(new { Result = "OK", Record = addedModel });
                    return RedirectToAction("PrinterView", "Inventory");
                }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
 
        }


        public ActionResult Updateuserinfo()
        {
            UpdateuserinfoEntity Updusers = new UpdateuserinfoEntity();
            ViewData["DeptID"] = GetUpdateusername(Updusers);
            return View();
        }
        [HttpPost]
        public JsonResult UpdateuserinfoList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetUpdateuserinfoRecord, null);
                    List<UpdateuserinfoEntity> ItemList = null;
                    ItemList = new List<UpdateuserinfoEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new UpdateuserinfoEntity()
                            {
                                UserinfoID = dr["UserinfoID"].ToString(),
                                AccountCode = dr["AccountCode"].ToString(),
                                UserID = dr["UserID"].ToString(),
                                Modifydate = dr["Modifydate"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        public JsonResult AllUpdateuserListItem()
        {
            try
            {
                UpdateuserinfoEntity UPD = new UpdateuserinfoEntity();
                var jList = GetUpdateusername(UPD).Select(c => new { DisplayText = c.Text, Value = c.Value });
                return Json(new { Result = "OK", Options = jList });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult Depvaluecheck(string UserID)
        {
            if (UserID.ToString().Trim() == "")
            {
                return Json(new { Result = "ERROR", Message = "Enter AccountCode" });
            }
            else
            {
                try
                {
                    InvInventorydetailsEntity obj = (InvInventorydetailsEntity)GetDupvalue(UserID);

                    return Json(obj);
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
        }

        public ActionResult Usercreateinfo()
        {
            UsercreateinfoEntity _Model = new UsercreateinfoEntity();
            _Model.Createdate = DateTime.Today.ToString("dd/MM/yyyy");
            Invlocation LocEntity = new Invlocation();
            ViewData["Location"] = GetLocation(LocEntity);
            return View(_Model);
        }
        [HttpPost]
        public JsonResult UsercreateinfoList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetUsercreateinfoRecord, null);
                    List<UsercreateinfoEntity> ItemList = null;
                    ItemList = new List<UsercreateinfoEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new UsercreateinfoEntity()
                            {
                                UserID = dr["UserID"].ToString(),
                                UserName = dr["UserName"].ToString(),
                                Usermail = dr["Usermail"].ToString(),
                                Password = dr["Password"].ToString(),
                                LocID = dr["LocID"].ToString(),
                                UsersStatus = dr["UsersStatus"].ToString(),
                                Createdate = dr["Createdate"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult AddUpdateUsercreateInfo(UsercreateinfoEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }


                bool isUpdate = false;
                if (_Model.UserID == null)
                {
                    if (Depmailcheck(_Model.Usermail) != false)
                        //ModelState.AddModelError("", "The Email address is already taken. Please choose another.");
                        //return Json("Sorry, " + _Model.Usermail + " already exist", JsonRequestBehavior.AllowGet);
                        return Json(new { Result = "Message", Message = "The Email address is already taken. Please choose another." });
                    //return ModelState.AddModelError("", "Given user name already taken. Please choose another.");
                    else
                    {
                        WebUtil.sendNotificationToSiteUser(_Model);          ///***********  For Sending Mail
                        string Encriptpass = _Model.Password;
                        _Model.Password = Encdecript.Encryptdata(Encriptpass);
                        isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveUsercreateInfo, _Model);
                    }
                }
                else
                {
                    string Encriptupass = _Model.Password;
                    _Model.Password = Encdecript.Encryptdata(Encriptupass);
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateUsercreateInfo, _Model);
                }
                if (isUpdate)
                {
                    var addedModel = _Model;
                    return Json(new { Result = "OK", Record = addedModel });
                }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public bool Depmailcheck(string UserID)
        {
            try
            {
                UsercreateinfoEntity obj = (UsercreateinfoEntity)GetDupMail(UserID);
                //var obj1 = GetDupMail(UserID);                
                if (obj.Usermail == null)
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Dupempcheck(string UserID)
        {
            try
            {
                EmployeeinfoEntity obj = (EmployeeinfoEntity)GetDupEMP(UserID);
                //var obj1 = GetDupMail(UserID);                
                if (obj.EmpNo == null)
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Dupdeptcheck(string DeptID)
        {
            try
            {
                InvDepartmentinfoEntity obj = (InvDepartmentinfoEntity)GetDupdept(DeptID);
                //var obj1 = GetDupMail(UserID);                
                if (obj.DeptNo == null)
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        ///////////////////////////////////////////*********Search Account Code (Hasib)*****////////////////////////////////////////////////////

        [HttpPost]
        public JsonResult InventoryDetailsListbyid(InvInventorydetailsEntity _Model, string FLocation="", string DNAME = "", string ENAME = "", string ACode = "", int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {                    
                    _Model.AccountCode = ACode;
                    _Model.EMPNAME = ENAME;
                    _Model.DEPTNAME = DNAME;
                    _Model.Location = FLocation;
                    //_Model.Location = CurrentLocation;
                    _Model.Userstatus = CurrentUserstatus;
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetSingleInventoryRecordById, _Model);
                    List<InventorydetailsEntity> ItemList = null;
                    ItemList = new List<InventorydetailsEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InventorydetailsEntity()
                            {
                                SL = (iCount + 1).ToString(),
                                AccountID = dr["AccountID"].ToString(),
                                AccountCode = dr["AccountCode"].ToString(),
                                BrandModel = dr["BrandModel"].ToString(),
                                Configuration = dr["Configuration"].ToString(),
                                Category = dr["Category"].ToString(),
                                SerialNo = dr["SerialNo"].ToString(),
                                Location = dr["Location"].ToString(),
                                DeptID = dr["DeptID"].ToString(),
                                EMPID = dr["EMPID"].ToString(),
                                EMPNAME = dr["EMPNAME"].ToString(),
                                PurchDate = dr["PurchDate"].ToString(),
                                Remark = dr["Remark"].ToString(),
                                MonitorID = dr["MonitorID"].ToString(),
                                UPSID = dr["UPSID"].ToString(),
                                Team = dr["Team"].ToString(),
                                Status = dr["Status"].ToString(),
                                HostName = dr["HostName"].ToString(),
                                ITemNo = dr["ITemNo"].ToString(),
                                DeviceID = dr["DeviceID"].ToString()                                
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        //////////////////////////////////******************************* Excel Reporting (Hasib) ********/////////////////////////////////////////////
        public ActionResult ExcelReport()
        {

            InvInventorydetailsEntity _Model = new InvInventorydetailsEntity();
            _Model.Location = CurrentLocation;
            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetALLDeviceinfoReport, _Model);
            StringBuilder sb = new StringBuilder();

            sb.Append("<table border='" + "2px" + "'b>");

            //write column headings
            sb.Append("<tr>");

            foreach (System.Data.DataColumn dc in dt.Columns)
            {
                sb.Append("<td><b><font face=Arial size=2>" + dc.ColumnName + "</font></b></td>");
            }
            sb.Append("</tr>");

            foreach (System.Data.DataRow dr in dt.Rows)
            {
                sb.Append("<tr>");
                foreach (System.Data.DataColumn dc in dt.Columns)
                {
                    sb.Append("<td><font face=Arial size=" + "14px" + ">" + dr[dc].ToString() + "</font></td>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");

            //this.Response.AddHeader("Content-Disposition", "Employees.xls");
            this.Response.ContentType = "application/vnd.ms-excel";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            return File(buffer, "application/vnd.ms-excel", "AllDevices.xls");
        }

        public ActionResult AllInvReport()
        {
            InvInventorydetailsEntity _Model = new InvInventorydetailsEntity();
            _Model.Location = CurrentLocation;
            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetALLDeviceinfoReport, _Model);
            ERP.Utility.AppExcel.ExcelFileResult actionResult = new ERP.Utility.AppExcel.ExcelFileResult(dt) { FileDownloadName = "AllInvReport.xls" };
            return actionResult;
        }

////////////////////////////////////////********************************  OPAX Items *******************//////////////////////////////////////////////
        public ActionResult Additems()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ItemsList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetItemsListRecord, null);
                    List<InvitemsEntity> ItemList = null;
                    ItemList = new List<InvitemsEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvitemsEntity()
                            {
                                ItemID = dr["ItemID"].ToString(),
                                ItemName = dr["ItemName"].ToString(),
                                ItemDate = dr["ItemDate"].ToString(),
                                Description = dr["Description"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult AddUpdateItems(InvitemsEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }


                bool isUpdate = false;
                if (_Model.ItemID == null)
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveInvitemsRecord, _Model);
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateInvitemsRecord, _Model);
                if (isUpdate)
                {
                    var addedModel = _Model;
                    return Json(new { Result = "OK", Record = addedModel });
                }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult DeleteItemsRecord(string ItemID)
        {
            try
            {
                Thread.Sleep(50);
                bool isUpdate = false;
                isUpdate = (bool)ExecuteDB(ERPTask.AG_DeleteInvitemsRecordById, ItemID);
                if (isUpdate)
                    return Json(new { Result = "OK" });
                else
                    return Json(new { Result = "ERROR", Message = "Failed to Delete" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public ActionResult Addmodels()
        {
          return View();
        }
        [HttpPost]
        public JsonResult ModelsList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetModelsListRecord, null);
                    List<InvmodelEntity> ItemList = null;
                    ItemList = new List<InvmodelEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvmodelEntity()
                            {
                                ModelID = dr["ModelID"].ToString(),
                                ItemID = dr["ItemID"].ToString(),
                                ModelName = dr["ModelName"].ToString(),
                                ModelDate = dr["ModelDate"].ToString(),
                                EXDate = dr["EXDate"].ToString(),
                                TPage = dr["TPage"].ToString(),
                                Description = dr["Description"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult AddUpdateModels(InvmodelEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }


                bool isUpdate = false;
                if (_Model.ModelID == null)
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveInvmodelRecord, _Model);
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateInvmodelRecord, _Model);
                if (isUpdate)
                {
                    var addedModel = _Model;
                    return Json(new { Result = "OK", Record = addedModel });
                }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult DeleteModelsRecord(string ModelID)
        {
            try
            {
                Thread.Sleep(50);
                bool isUpdate = false;
                isUpdate = (bool)ExecuteDB(ERPTask.AG_DeleteInvmodelRecordById, ModelID);
                if (isUpdate)
                    return Json(new { Result = "OK" });
                else
                    return Json(new { Result = "ERROR", Message = "Failed to Delete" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult AllListItems()
        {
            try
            {
                InvitemsEntity items = new InvitemsEntity();
                var jList = GetAllitemsName(items).Select(c => new { DisplayText = c.Text, Value = c.Value });
                return Json(new { Result = "OK", Options = jList });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult AllListModels()
        {
            try
            {
                InvmodelEntity models = new InvmodelEntity();
                var jList = GetAllmodelsName(models).Select(c => new { DisplayText = c.Text, Value = c.Value });
                return Json(new { Result = "OK", Options = jList });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        public JsonResult AllLocation()
        {
            try
            {
                Invlocation models = new Invlocation();
                models.Userstatus = CurrentUserstatus;
                models.Location = CurrentLocation;
                var jList = GetLocation(models).Select(c => new { DisplayText = c.Text, Value = c.Value });
                return Json(new { Result = "OK", Options = jList });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        public ActionResult Itemreceive()
        {
            Invlocation LocEntity = new Invlocation();
            ViewData["Location"] = GetLocation(LocEntity);
            return View();
        }
        [HttpPost]
        public JsonResult ItemreceiveList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetitemreceiveListRecord, null);
                    List<InvitemreceiveEntity> ItemList = null;
                    ItemList = new List<InvitemreceiveEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvitemreceiveEntity()
                            {
                                IRID=dr["IRID"].ToString(),
                                ModelID = dr["ModelID"].ToString(),
                                ItemID = dr["ItemID"].ToString(),
                                RDate = dr["RDate"].ToString(),
                                Chlanno = dr["Chlanno"].ToString(),
                                Suppliername = dr["Suppliername"].ToString(),
                                LocID = dr["LocID"].ToString(),
                                Quantity = dr["Quantity"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        //public ActionResult Additemreceive()
        //{
        //    return PartialView("_Addreceiveitem");
        //}
        [HttpGet]
        public ActionResult Additemreceive()
        {
            InvitemsEntity items = new InvitemsEntity();
            ViewData["ItemName"] = GetAllitemsName(items);
            InvmodelEntity models = new InvmodelEntity();
            ViewData["ModelName"] = GetAllmodelsName(models);
            Invlocation LocEntity = new Invlocation();
            ViewData["Location"] = GetLocation(LocEntity);
            return View();
        }
        [HttpPost]
        public ActionResult Additemreceive(InvitemreceiveEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }


                bool isUpdate = false;
                if (_Model.IRID == null)
                {
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveitemreceiveRecord, _Model);
                    return RedirectToAction("Additemreceive", "Inventory");
                  }
                else if (_Model.IRID != null)
                {
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateitemreceiveRecord, _Model);
                    var addedModel = _Model;
                    return Json(new { Result = "OK", Record = addedModel });                   
                }
                //if (isUpdate)
                // {
                //     var addedModel = _Model;
                //     return Json(new { Result = "OK", Record = addedModel });
                //     //return RedirectToAction("Additemreceive", "Inventory", addedModel);
                //    }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });               
            
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public ActionResult Receiveissue()
        {
            Invlocation LocEntity = new Invlocation();
            ViewData["Location"] = GetLocation(LocEntity);
            return View();
        }
        [HttpPost]
        public JsonResult ReceiveissueList(InvreceivenissueEntity _Model, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    _Model.Location = CurrentLocation;
                    _Model.Userstatus = CurrentUserstatus;
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetReceiveissueListRecord, _Model);
                    List<InvreceivenissueEntity> ItemList = null;
                    ItemList = new List<InvreceivenissueEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvreceivenissueEntity()
                            {
                                RIssueID = dr["RIssueID"].ToString(),
                                ModelID = dr["ModelID"].ToString(),
                                ItemID = dr["ItemID"].ToString(),
                                ReceiveQty = dr["ReceiveQty"].ToString(),
                                IssueDate = dr["IssueDate"].ToString(),
                                ReceiverName = dr["ReceiverName"].ToString(),
                                ReceiverEmail = dr["ReceiverEmail"].ToString(),
                                Transportno = dr["Transportno"].ToString(),
                                LocID = dr["LocID"].ToString(),
                                IssueQty = dr["IssueQty"].ToString(),
                                BalanceQty = dr["BalanceQty"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
       

        public ActionResult Issueitems()
        {
            InvreceivenissueEntity _Model = new InvreceivenissueEntity();
            InvitemsEntity items = new InvitemsEntity();
            ViewData["ItemName"] = GetAllitemsName(items);
            Invlocation LocEntity = new Invlocation();
            ViewData["Location"] = GetLocation(LocEntity);
            //InvmodelEntity models = new InvmodelEntity();
            //ViewData["ModelName"] = GetAllmodelsName(models);
            //_Model.TotalissueQty = "0";
            //_Model.BalanceQty = "0";
            //return View(_Model);
            return View();
        }
        [HttpPost]
        public ActionResult Issueitems(InvreceivenissueEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    //return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                    InvreceivenissueEntity RIEntity = new InvreceivenissueEntity();
                    InvitemsEntity items = new InvitemsEntity();
                    ViewData["ItemName"] = GetAllitemsName(items);
                    Invlocation LocEntity = new Invlocation();
                    ViewData["Location"] = GetLocation(LocEntity);
                    return View(RIEntity);
                }
                
                bool isUpdate = false;
                if (_Model.RIssueID == null)
                {
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveReceiveissueRecord, _Model);
                    return RedirectToAction("Issueitems", "Inventory");
                }
                else if (_Model.RIssueID != null)
                {
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateReceiveissueRecord, _Model);
                    var addedModel = _Model;
                    return Json(new { Result = "OK", Record = addedModel });
                }
                //if (isUpdate)
                // {
                //     var addedModel = _Model;
                //     return Json(new { Result = "OK", Record = addedModel });
                //     //return RedirectToAction("Additemreceive", "Inventory", addedModel);
                //    }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });

            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult Getsumvalue(string XModelid, string LOC)
        {
            if (XModelid.ToString().Trim() == "")           
            {
                return Json(new { Result = "ERROR", Message = "Enter Item and Model ID" });
            }
            else
            {
                try
                {
                    InvreceivenissueEntity obj = (InvreceivenissueEntity)GetSumvalues(XModelid, LOC);

                    return Json(obj);
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
        }

        public JsonResult ItemmodelList(string IID)
        {
            try
            {
                return Json(GetitemmodelsName(IID));
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        private List<SelectListItem> GetitemmodelsName(string iid)
        {
            InvmodelEntity bh = new InvmodelEntity();
            bh.ItemID = iid;

            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_Getitemmodel, bh);
            List<SelectListItem> Items = new List<SelectListItem>();
            if (dt.Rows.Count > 0)
            {
                Items.Add(new SelectListItem { Text = "", Value = "" });
                foreach (DataRow dr in dt.Rows)
                {
                    Items.Add(new SelectListItem { Text = dr["ModelName"].ToString(), Value = dr["ModelID"].ToString() });
                }
            }
            else
            {
                Items = new List<SelectListItem>();
                Items.Add(new SelectListItem { Text = "", Value = "" });
            }
            return Items;
        }

        public ActionResult Userissue()
        {
            InvitemsEntity items = new InvitemsEntity();
            ViewData["ItemName"] = GetAllitemsName(items);
            InvDepartmentinfoEntity DeptEntity = new InvDepartmentinfoEntity();
            ViewData["DeptID"] = GetAllDepartmentnameList(DeptEntity);
            Invlocation LocEntity = new Invlocation();
            LocEntity.Location = CurrentLocation;
            LocEntity.Userstatus = CurrentUserstatus;
            ViewData["Location"] = GetLocation(LocEntity);
            return View();
        }
        [HttpPost]
        public JsonResult UserissueitemList(InvuserissueEntity _Model, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    _Model.Location = CurrentLocation;
                    _Model.Userstatus = CurrentUserstatus;
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetUserissueitemRecord, _Model);
                    List<InvuserissueEntity> ItemList = null;
                    ItemList = new List<InvuserissueEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvuserissueEntity()
                            {
                                UIssueID = dr["UIssueID"].ToString(),
                                EmpID = dr["EmpID"].ToString(),
                                DeptID = dr["DeptID"].ToString(),
                                ItemID = dr["ItemID"].ToString(),
                                ModelID = dr["ModelID"].ToString(),                                
                                LocID = dr["LocID"].ToString(),
                                UIssueDate = dr["UIssueDate"].ToString(),
                                UITRFNo = dr["UITRFNo"].ToString(),
                                UIssueQty = dr["UIssueQty"].ToString()                               
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public ActionResult Userissue(InvuserissueEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                bool isSave = false;
                bool isUpdate = false;
                if (_Model.UIssueID == null)
                    isSave = (bool)ExecuteDB(ERPTask.AG_SaveUserissueInfo, _Model);
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateUserissueInfo, _Model);
                if (isSave)
                {                    
                    return RedirectToAction("Userissue", "Inventory");
                }
                else if (isUpdate)
                {
                    var addedModel = _Model;
                    return Json(new { Result = "OK", Record = addedModel });
                }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult AutoITRF(String Locname)
        {
            string Itrfno = Autovalue.AutoITRFValue(Locname);
            return Json(Itrfno);
        }

        public JsonResult EmployeeList(string ClassID)
        {
            try
            {
                return Json(GetEmployeeList(ClassID));
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        private List<SelectListItem> GetEmployeeList(string DEPT)
        {
            InvInventorydetailsEntity bh = new InvInventorydetailsEntity();
            //EmployeeinfoEntity bh = new EmployeeinfoEntity();
            bh.DeptID = DEPT;

            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllInvEmployeeRecordByEmpId, bh);
            List<SelectListItem> Items = new List<SelectListItem>();
            if (dt.Rows.Count > 0)
            {
                Items.Add(new SelectListItem { Text = "", Value = "" });
                foreach (DataRow dr in dt.Rows)
                {
                    Items.Add(new SelectListItem { Text = dr["EmpNo"].ToString(), Value = dr["EmpID"].ToString() });
                }
            }
            else
            {
                Items = new List<SelectListItem>();
                Items.Add(new SelectListItem { Text = "", Value = "" });
            }
            return Items;
        }

        //public JsonResult Autonumber(string Loc)
        //{

        //    try
        //    {
        //        InvInventorydetailsEntity obj = (InvInventorydetailsEntity)Getautono(Loc);
        //        return Json(obj);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Result = "ERROR", Message = ex.Message });
        //    }
        //}

        /// <summary>
        /// ////////////////////////////******************* Child Table ********////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>
        public ActionResult Assetdist()
        {
            InvitemsEntity items = new InvitemsEntity();
            ViewData["ItemName"] = GetAllitemsName(items);
            Invlocation LocEntity = new Invlocation();
            LocEntity.Location = CurrentLocation;
            LocEntity.Userstatus = CurrentUserstatus;
            ViewData["Location"] = GetLocation(LocEntity);
            return View();
        }
        [HttpPost]
        public JsonResult FTRTransferList(InvFTRTransferEntity _Model, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    _Model.Location = CurrentLocation;
                    _Model.Userstatus = CurrentUserstatus;
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetFTRTransferListRecord, _Model);
                    List<InvFTRTransferEntity> ItemList = null;
                    ItemList = new List<InvFTRTransferEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvFTRTransferEntity()
                            {
                                TRID = dr["TRID"].ToString(),
                               // ModelID = dr["ModelID"].ToString(),
                                ItemID = dr["ItemID"].ToString(),                               
                                IssueDate = dr["IssueDate"].ToString(),                                
                                LocID = dr["LocID"].ToString(),
                               // IssueQty = dr["IssueQty"].ToString(),
                                IsReceive = Convert.ToBoolean(dr["IsReceive"].ToString())
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult AssetdistbyMDate(InvFTRTransferEntity _Model, string MDate = "", string itemid = "", int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    _Model.IssueDate = MDate;
                    _Model.ItemID = itemid;
                    _Model.Location = CurrentLocation;
                    _Model.Userstatus = CurrentUserstatus;                    
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAssetdistbyMDate, _Model);
                    List<InvFTRTransferEntity> ItemList = null;
                    ItemList = new List<InvFTRTransferEntity>();
                    //int iCount = 0;
                    //int offset = 0;
                    //offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        //if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        //{
                        ItemList.Add(new InvFTRTransferEntity()
                            {

                                RIssueID = dr["RIssueID"].ToString(),
                                ModelID = dr["ModelID"].ToString(),
                                ItemID = dr["ItemID"].ToString(),                               
                                IssueDate = dr["IssueDate"].ToString(),                                
                                LocID = dr["LocID"].ToString(),
                                IssueQty = dr["IssueQty"].ToString()
                                //IsReceive =Convert.ToBoolean( dr["IsReceive"].ToString())
                            });
                        //}
                        //iCount += 1;
                    }
                    //var RecordCount = dt.Rows.Count;
                    var Record = ItemList;                   
                    //return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                    return Json(new { Result = "OK", Records = Record });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        /// <summary>
        /// ////////////*************** Using Store Procedure *****************//////////////////////////////////////////////
        /// </summary>      
        [HttpPost]
        public JsonResult AssettransferBylocdate(InvFTRTransferEntity _Model, string itemname = "", string issuedate = "", string ENAME = "", string ACode = "", int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    _Model.ItemID = itemname;
                    _Model.IssueDate = issuedate;                   
                    _Model.Location = CurrentLocation;
                    _Model.Userstatus = CurrentUserstatus;
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetassettransBylocdate, _Model);
                    List<InvFTRTransferEntity> ItemList = null;
                    ItemList = new List<InvFTRTransferEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvFTRTransferEntity()
                            {
                                TRID = dr["TRID"].ToString(),
                                //ModelID = dr["ModelID"].ToString(),
                                ItemID = dr["ItemID"].ToString(),                               
                                IssueDate = dr["IssueDate"].ToString(),                               
                                LocID = dr["LocID"].ToString(),
                                //IssueQty = dr["IssueQty"].ToString(),
                                IsReceive =Convert.ToBoolean( dr["IsReceive"].ToString())
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult AddUpdateFTRTransfer(InvFTRTransferEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }


                bool isUpdate = false;
                if (_Model.TRID == null)
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveFTRTransferList, _Model);
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateFTRTransferList, _Model);
                if (isUpdate)
                {
                    var addedModel = _Model;
                    return Json(new { Result = "OK", Record = addedModel });
                }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public JsonResult Usersumvalue(string XModelid)
        {
            if (XModelid.ToString().Trim() == "")
            {
                return Json(new { Result = "ERROR", Message = "Enter Item and Model ID" });
            }
            else
            {
                try
                {
                    InvreceivenissueEntity obj = (InvreceivenissueEntity)Usersumvalues(XModelid);
                    return Json(obj);
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
        }
    
    /////////////////////////////////////*********************************** Stock Information***********************//////////////////////////////////////
        public ActionResult Receiverpt()
        {
            Invlocation LocEntity = new Invlocation();
            ViewData["Location"] = GetLocation(LocEntity);
            return View();
        }
        [HttpPost]
        public JsonResult TotalItemreceiveList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GettotalitemreceiveListRecord, null);
                    List<InvitemreceiveEntity> ItemList = null;
                    ItemList = new List<InvitemreceiveEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvitemreceiveEntity()
                            {
                                IRID = dr["IRID"].ToString(),
                                ModelID = dr["ModelID"].ToString(),
                                ItemID = dr["ItemID"].ToString(),
                                RDate = dr["RDate"].ToString(),
                                Chlanno = dr["Chlanno"].ToString(),
                                Suppliername = dr["Suppliername"].ToString(),
                                LocID = dr["LocID"].ToString(),
                                Quantity = dr["Quantity"].ToString(),
                                RTotalQty = dr["RTotalQty"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }


        public ActionResult Stockinfo()
        {
            InvitemsEntity items = new InvitemsEntity();
            ViewData["ItemName"] = GetAllitemsName(items);
            InvmodelEntity models = new InvmodelEntity();
            ViewData["ModelName"] = GetAllmodelsName(models);
            Invlocation LocEntity = new Invlocation();
            //LocEntity.Location = CurrentLocation;
            //LocEntity.Userstatus = CurrentUserstatus;
            ViewData["Location"] = GetLocation(LocEntity);
            return View();
        }
        [HttpPost]
        public JsonResult StockinfoList(InvallstockEntity _Model, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    //_Model.Location = CurrentLocation;
                    //_Model.Userstatus = CurrentUserstatus;
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetstockinfoListRecord, _Model);
                    List<InvallstockEntity> ItemList = null;
                    ItemList = new List<InvallstockEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvallstockEntity()
                            {
                               // SID = dr["SID"].ToString(),
                                ModelID = dr["ModelID"].ToString(),
                                ItemID = dr["ItemID"].ToString(),
                                LocID = dr["LocID"].ToString(), 
                                SDate = dr["SDate"].ToString(),
                                IDate = dr["IDate"].ToString(),
                                IssueQty = dr["IssueQty"].ToString(),
                                TOTALRQty = dr["TOTALRQty"].ToString(),
                                TOTALIQty = dr["TOTALIQty"].ToString(),                               
                                BalanceQty = dr["BalanceQty"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult StockinfoByDate(InvallstockEntity _Model, String StartDate="", String  EndDate="", String ItemID="", String ModelID="", int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    //_Model.Location = CurrentLocation;
                    //_Model.Userstatus = CurrentUserstatus;
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetstockinfoRecordByDate, _Model);
                    List<InvallstockEntity> ItemList = null;
                    ItemList = new List<InvallstockEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvallstockEntity()
                            {
                                //SID = dr["SID"].ToString(),
                                ModelID = dr["ModelID"].ToString(),
                                ItemID = dr["ItemID"].ToString(),
                                LocID = dr["LocID"].ToString(), 
                                SDate = dr["SDate"].ToString(),
                                IDate = dr["IDate"].ToString(),
                                IssueQty = dr["IssueQty"].ToString(),
                                TOTALRQty = dr["TOTALRQty"].ToString(),
                                TOTALIQty = dr["TOTALIQty"].ToString(),
                                BalanceQty = dr["BalanceQty"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        public ActionResult StockinfoByDateExcel(String StartDate = "", String EndDate = "", String ItemID = "", String ModelID = "")
        {
            InvallstockEntity _Model = new InvallstockEntity();
            //_Model.Location = CurrentLocation;
            _Model.StartDate = StartDate;
            _Model.EndDate = EndDate;
            _Model.ItemID = ItemID;
            _Model.ModelID = ModelID;
            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetstockinfoexcelByDate, _Model);
            ERP.Utility.AppExcel.ExcelFileResult actionResult = new ERP.Utility.AppExcel.ExcelFileResult(dt) { FileDownloadName = " Stockinfo.xls" };
            return actionResult;
        }


        public ActionResult FTYStock()
        {
            return View();
        }
        [HttpPost]
        public JsonResult FTYStockinfoList(InvftystockinfoEntity _Model, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    _Model.Location = CurrentLocation;
                    _Model.Userstatus = CurrentUserstatus;
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetftystockinfoListRecord, _Model);
                    List<InvftystockinfoEntity> ItemList = null;
                    ItemList = new List<InvftystockinfoEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvftystockinfoEntity()
                            {
                                FSID = dr["FSID"].ToString(),
                                ModelID = dr["ModelID"].ToString(),
                                ItemID = dr["ItemID"].ToString(),
                                FSDate = dr["FSDate"].ToString(),
                                TFSRQty = dr["TFSRQty"].ToString(),
                                TFSIQty = dr["TFSIQty"].ToString(),
                                LocID = dr["LocID"].ToString(),
                                FSBalanceQty = dr["FSBalanceQty"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

//////////////////////////////////////************************************* Get Pass Report ************************///////////////////////////////////////
        public ActionResult Getpassissue()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetpassissueList(InvgetpassissuereportEntity _Model, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    _Model.Location = CurrentLocation;
                    _Model.Userstatus = CurrentUserstatus;
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetpassissueListRecord, _Model);
                    List<InvgetpassissuereportEntity> ItemList = null;
                    ItemList = new List<InvgetpassissuereportEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvgetpassissuereportEntity()
                            {
                                IssueName = CurrentUserName.ToString(),
                                ILocation = CurrentLocation.ToString(),
                                SL= (iCount + 1).ToString(),
                                ItemName = dr["ItemName"].ToString(),
                                ModelName = dr["ModelName"].ToString(),
                                IssueDate = dr["IssueDate"].ToString(),
                                ReceiverName = dr["ReceiverName"].ToString(),
                                Location = dr["Location"].ToString(),
                                IssueQty = dr["IssueQty"].ToString(),                               
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    Session["Getpass"] = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult GetpassissueByDate(InvgetpassissuereportEntity _Model, string issuedate = "", int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    _Model.Location = CurrentLocation;
                    _Model.Userstatus = CurrentUserstatus;
                    _Model.IssueDate = issuedate;
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetpassissueListRecordByDate, _Model);
                    List<InvgetpassissuereportEntity> ItemList = null;
                    ItemList = new List<InvgetpassissuereportEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvgetpassissuereportEntity()
                            {
                                IssueName = CurrentUserName,
                                ILocation = CurrentLocation,
                                SL= (iCount + 1).ToString(),
                                ItemName = dr["ItemName"].ToString(),
                                ModelName = dr["ModelName"].ToString(),
                                IssueDate = dr["IssueDate"].ToString(),
                                ReceiverName = dr["ReceiverName"].ToString(),
                                Location = dr["Location"].ToString(),
                                IssueQty = dr["IssueQty"].ToString(),
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    Session["Getpass"] = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        public ActionResult Getpassissuerpt()
        {
            GetpassissueRPTEntity obj;

            ReportClass rptH = new ReportClass();
            ArrayList al = new ArrayList();
            rptH.FileName = Server.MapPath("/Reports/GetpassissueReport.rpt");
            rptH.Load();

            List<InvgetpassissuereportEntity> ItemList = (List<InvgetpassissuereportEntity>)Session["Getpass"];
            foreach (InvgetpassissuereportEntity dr in ItemList)
            {
                obj = new GetpassissueRPTEntity();

                obj.SL = dr.SL;
                obj.ItemName = dr.ItemName;
                obj.ModelName = dr.ModelName;
                obj.ReceiverName = dr.ReceiverName;
                obj.Location = dr.Location;
                obj.IssueDate = dr.IssueDate;
                obj.IssueQty = dr.IssueQty;

                al.Add(obj);
            }
            rptH.SetDataSource(al);
            MemoryStream stream = (MemoryStream)rptH.ExportToStream(ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }
////////////////////////////////////////////////////////********************************//////////////////////////////////////////////////////////////////
        /// <summary>
        /// /Report Viewer hasib_aziz@hotmail.com.
        /// </summary>
        /// <returns></returns>
        public ActionResult ReportViewer()
        {
            InvgetpassissuereportEntity _Model = new InvgetpassissuereportEntity();
            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetpassissueListRecordView, _Model);
            Session["ReportSource"] = dt;
            Response.Redirect("~/Reports/WebForm1.aspx");
            return View();
        }
        public ActionResult ReportView()
        {
           // Response.Redirect("");
            return View();
        }
///////////////////////////////////////////////////////*****Leave Entry*****************/////////////////////////////////////////////////////////////////
        public ActionResult Leaveinfo()
        {
            InvUnitinfoEntity Units = new InvUnitinfoEntity();
            ViewData["UnitID"] = GetAllUnit(Units);
            return View();
        }
        [HttpPost]
        public JsonResult Leaveinfolist(InvLeaveinfoEntity _Model, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    //_Model.Location = CurrentLocation;
                    //_Model.Userstatus = CurrentUserstatus;
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetLeaveinfolistRecord, _Model);
                    List<InvLeaveinfoEntity> ItemList = null;
                    ItemList = new List<InvLeaveinfoEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvLeaveinfoEntity()
                            {
                                IID = dr["IID"].ToString(),
                                EID = dr["EID"].ToString(),
                                UnitID = dr["UnitID"].ToString(),
                                Years = dr["Years"].ToString(),
                                Months = dr["Months"].ToString(),
                                Idledays = dr["Idledays"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    //Session["Getpass"] = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult AddUpdateLeaveinfo(InvLeaveinfoEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }


                bool isUpdate = false;
                if (_Model.IID == null)
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveLeaveinfoRecord, _Model);
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateLeaveinfoRecord, _Model);
                if (isUpdate)
                {
                    var addedModel = _Model;
                    return Json(new { Result = "OK", Record = addedModel });
                }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        public ActionResult IdleEntry()
        {
            InvUnitinfoEntity Units = new InvUnitinfoEntity();
            ViewData["UnitID"] = GetAllUnit(Units);
            return View();
        }
        [HttpPost]
        public ActionResult IdleEntry(InvLeaveinfoEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }


                bool isUpdate = false;
                if (_Model.IID == null)
                {
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveLeaveinfoRecord, _Model);
                    return RedirectToAction("IdleEntry", "Inventory");
                }
                else if (_Model.IID != null)
                {
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateLeaveinfoRecord, _Model);
                    var addedModel = _Model;
                    return Json(new { Result = "OK", Record = addedModel });
                }
                //if (isUpdate)
                // {
                //     var addedModel = _Model;
                //     return Json(new { Result = "OK", Record = addedModel });
                //     //return RedirectToAction("Additemreceive", "Inventory", addedModel);
                //    }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });

            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult IdlesearchByuym(InvLeaveinfoEntity _Model, string Unitid = "", string years = "", string months = "", int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    _Model.UnitID = Unitid;
                    _Model.Years = years;
                    _Model.Months = months;
                   // _Model.Location = CurrentLocation;
                   // _Model.Userstatus = CurrentUserstatus;
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetIdlesearchByuym, _Model);
                    List<InvLeaveinfoEntity> ItemList = null;
                    ItemList = new List<InvLeaveinfoEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvLeaveinfoEntity()
                            {
                                IID = dr["IID"].ToString(),
                                EID = dr["EID"].ToString(),
                                UnitID = dr["UnitID"].ToString(),
                                Years = dr["Years"].ToString(),
                                Months = dr["Months"].ToString(),
                                Idledays = dr["Idledays"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
       


        public ActionResult Serviceinfo()
        {
            //Invlocation LocEntity = new Invlocation();
            //ViewData["Location"] = GetLocation(LocEntity);
            //InvServiceinfoEntity SVREntity = new InvServiceinfoEntity();
            //ViewData["ENumber"] = EquipmentList(SVREntity);
            return View();
        }
        [HttpPost]
        public JsonResult Serviceinfolist(InvServiceinfoEntity _Model, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    _Model.Location = CurrentLocation;
                    _Model.Userstatus = CurrentUserstatus;
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetServiceinfolistRecord, _Model);
                    List<InvServiceinfoEntity> ItemList = null;
                    ItemList = new List<InvServiceinfoEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvServiceinfoEntity()
                            {
                                ServiceID = dr["ServiceID"].ToString(),
                                AccountID = dr["AccountID"].ToString(),
                                LocID = dr["LocID"].ToString(),
                                Servicedate = dr["Servicedate"].ToString(),
                                Mlifetime = dr["Mlifetime"].ToString(),
                                Description = dr["Description"].ToString(),
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    //Session["Getpass"] = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        public JsonResult AllEquipmentno()
        {
            try
            {
                InvServiceinfoEntity Model = new InvServiceinfoEntity();
                var jList = GetAllEquipmentno(Model).Select(c => new { DisplayText = c.Text, Value = c.Value });
                return Json(new { Result = "OK", Options = jList });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult AddUpdateServiceinfo(InvServiceinfoEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }


                bool isUpdate = false;
                if (_Model.ServiceID == null)
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveServiceinfoRecord, _Model);
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateServiceinfoRecord, _Model);
                if (isUpdate)
                {
                    var addedModel = _Model;
                    return Json(new { Result = "OK", Record = addedModel });
                }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        public JsonResult EquipmentList(string Location)
        {
            try
            {
                return Json(GetEquipmentList(Location));
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        private List<SelectListItem> GetEquipmentList(string LOC)
        {
            InvServiceinfoEntity Model = new InvServiceinfoEntity();
            //EmployeeinfoEntity bh = new EmployeeinfoEntity();
            Model.Location = LOC;

            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllEquipmentbyLocation, Model);
            List<SelectListItem> Items = new List<SelectListItem>();
            if (dt.Rows.Count > 0)
            {
                Items.Add(new SelectListItem { Text = "", Value = "" });
                foreach (DataRow dr in dt.Rows)
                {
                    Items.Add(new SelectListItem { Text = dr["ENumber"].ToString(), Value = dr["AccountID"].ToString() });
                }
            }
            else
            {
                Items = new List<SelectListItem>();
                Items.Add(new SelectListItem { Text = "", Value = "" });
            }
            return Items;
        }
/// <summary>
/// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// </summary>
/// <returns></returns>
/// 

        public ActionResult Country()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CountryList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetCountryRecord, null);
                    List<InvCountryinfoEntity> ItemList = null;
                    ItemList = new List<InvCountryinfoEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvCountryinfoEntity()
                            {
                                CID = dr["CID"].ToString(),
                                Name = dr["Name"].ToString(),
                                Description = dr["Description"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult AddUpdateCountryInfo(InvCountryinfoEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }


                bool isUpdate = false;
                if (_Model.CID == null)
                    if (DupCountrycheck(_Model.Name) != false)
                        return Json(new { Result = "Message", Message = "The Country Name is already taken. Please choose another." });
                    else
                    {
                        isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveCountryInfo, _Model);
                    }
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateCountryInfo, _Model);
                if (isUpdate)
                {
                    var addedModel = _Model;
                    return Json(new { Result = "OK", Record = addedModel });
                }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        public bool DupCountrycheck(string CountryID)
        {
            try
            {
                InvCountryinfoEntity obj = (InvCountryinfoEntity)GetDupCountry(CountryID);
                //var obj1 = GetDupMail(UserID);                
                if (obj.Name == null)
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public JsonResult AllCountry()
        {
            try
            {
                InvCountryinfoEntity models = new InvCountryinfoEntity();
                //models.Userstatus = CurrentUserstatus;
                //models.Location = CurrentLocation;
                var jList = GetCountry(models).Select(c => new { DisplayText = c.Text, Value = c.Value });
                return Json(new { Result = "OK", Options = jList });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }


        public ActionResult Unitentry()
        {
            return View();
        }
        [HttpPost]
        public JsonResult UnitinfoList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetUnitRecord, null);
                    List<InvUnitinfoEntity> ItemList = null;
                    ItemList = new List<InvUnitinfoEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvUnitinfoEntity()
                            {
                                UnitID = dr["UnitID"].ToString(),
                                UnitName = dr["UnitName"].ToString(),
                                Description = dr["Description"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult AddUpdateUnitInfo(InvUnitinfoEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }


                bool isUpdate = false;
                if (_Model.UnitID == null)
                    if (DupUnitcheck(_Model.UnitName) != false)
                        return Json(new { Result = "Message", Message = "The Unit Name is already taken. Please choose another." });
                    else
                    {
                        isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveUnitInfo, _Model);
                    }
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateUnitInfo, _Model);
                if (isUpdate)
                {
                    var addedModel = _Model;
                    return Json(new { Result = "OK", Record = addedModel });
                }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        public bool DupUnitcheck(string UnitID)
        {
            try
            {
                InvUnitinfoEntity obj = (InvUnitinfoEntity)GetDupUnit(UnitID);
                //var obj1 = GetDupMail(UserID);                
                if (obj.UnitName == null)
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public JsonResult AllUnits()
        {
            try
            {
                InvUnitinfoEntity models = new InvUnitinfoEntity();
                //models.Userstatus = CurrentUserstatus;
                //models.Location = CurrentLocation;
                var jList = GetAllUnit(models).Select(c => new { DisplayText = c.Text, Value = c.Value });
                return Json(new { Result = "OK", Options = jList });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }


        public ActionResult Buildinginfo()
        {
            return View();
        }
        [HttpPost]
        public JsonResult BuildinginfoList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetBuildinginfoRecord, null);
                    List<InvBuilinginfoEntity> ItemList = null;
                    ItemList = new List<InvBuilinginfoEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvBuilinginfoEntity()
                            {
                                BNID = dr["BNID"].ToString(),
                                LocID = dr["LocID"].ToString(),
                                BuildingName = dr["BuildingName"].ToString(),
                                Description = dr["Description"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult AddUpdateBuildingInfo(InvBuilinginfoEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }


                bool isUpdate = false;
                if (_Model.BNID == null)
                    if (DupBuildingcheck(_Model.BuildingName) != false)
                        return Json(new { Result = "Message", Message = "The Building Name is already taken. Please choose another." });
                    else
                    {
                        isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveBuildingInfo, _Model);
                    }
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateBuildingInfo, _Model);
                if (isUpdate)
                {
                    var addedModel = _Model;
                    return Json(new { Result = "OK", Record = addedModel });
                }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        public bool DupBuildingcheck(string BNID)
        {
            try
            {
                InvBuilinginfoEntity obj = (InvBuilinginfoEntity)GetDupBuilding(BNID);
                //var obj1 = GetDupMail(UserID);                
                if (obj.BuildingName == null)
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public JsonResult AllBuildinginfo()
        {
            try
            {
                InvBuilinginfoEntity models = new InvBuilinginfoEntity();
                //models.Userstatus = CurrentUserstatus;
                //models.Location = CurrentLocation;
                var jList = GetAllBuildinginfo(models).Select(c => new { DisplayText = c.Text, Value = c.Value });
                return Json(new { Result = "OK", Options = jList });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        public JsonResult GetBuildingBylocID(string locid)
        {
            try
            {
                return Json(GetBuildingList(locid));
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public ActionResult Floorinfo()
        {
            return View();
        }
        [HttpPost]
        public JsonResult FloorinfoList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetFloorinfofoRecord, null);
                    List<InvFloorinfoEntity> ItemList = null;
                    ItemList = new List<InvFloorinfoEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvFloorinfoEntity()
                            {
                                FID = dr["FID"].ToString(),
                                //LocID = dr["LocID"].ToString(),
                                BNID = dr["BNID"].ToString(),
                                FloorName = dr["FloorName"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        public ActionResult AddFloor()
        {
            InvBuilinginfoEntity Build = new InvBuilinginfoEntity();
            ViewData["BNID"] = GetAllBuildinginfo(Build);
            Invlocation LocEntity = new Invlocation();
            //LocEntity.Location = CurrentLocation;
            //LocEntity.Userstatus = CurrentUserstatus;
            ViewData["LocID"] = GetLocation(LocEntity);
            return View();
        }
        [HttpPost]
        public ActionResult AddFloor(InvFloorinfoEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    //return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                    InvBuilinginfoEntity Build = new InvBuilinginfoEntity();
                    ViewData["BNID"] = GetAllBuildinginfo(Build);
                    Invlocation LocEntity = new Invlocation();                   
                    ViewData["LocID"] = GetLocation(LocEntity);
                    return View(_Model);
                }


                bool isUpdate = false;
                if (_Model.FID == null)
                {
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveFloorRecord, _Model);
                    return RedirectToAction("AddFloor", "Inventory");
                }
                else if (_Model.FID != null)
                {
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateFloorRecord, _Model);
                    var addedModel = _Model;
                    return Json(new { Result = "OK", Record = addedModel });
                }
                //if (isUpdate)
                // {
                //     var addedModel = _Model;
                //     return Json(new { Result = "OK", Record = addedModel });
                //     //return RedirectToAction("Additemreceive", "Inventory", addedModel);
                //    }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });

            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        public JsonResult AllFloorinfo()
        {
            try
            {
                InvFloorinfoEntity models = new InvFloorinfoEntity();
                //models.Userstatus = CurrentUserstatus;
                //models.Location = CurrentLocation;
                var jList = GetAllFloorinfo(models).Select(c => new { DisplayText = c.Text, Value = c.Value });
                return Json(new { Result = "OK", Options = jList });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        public JsonResult GetFloorByBNID(string flrid)
        {
            try
            {
                return Json(GetFloorList(flrid));
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public ActionResult Lineinfo()
        {
            return View();
        }
        [HttpPost]
        public JsonResult LineinfoList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetLineinfofoRecord, null);
                    List<InvLineinfoEntity> ItemList = null;
                    ItemList = new List<InvLineinfoEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvLineinfoEntity()
                            {
                                LID = dr["LID"].ToString(),
                                //LocID = dr["LocID"].ToString(),
                                FID = dr["FID"].ToString(),
                                LineName = dr["LineName"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        public ActionResult AddLine() 
        {
            InvBuilinginfoEntity Build = new InvBuilinginfoEntity();
            ViewData["BNID"] = GetAllBuildinginfo(Build);
            Invlocation LocEntity = new Invlocation();
            //LocEntity.Location = CurrentLocation;
            //LocEntity.Userstatus = CurrentUserstatus;
            ViewData["LocID"] = GetLocation(LocEntity);
            InvFloorinfoEntity flvEntity = new InvFloorinfoEntity();
            ViewData["FID"] = GetAllFloorinfo(flvEntity);
            return View();
        }
        [HttpPost]
        public ActionResult AddLine(InvLineinfoEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    //return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                    InvBuilinginfoEntity Build = new InvBuilinginfoEntity();
                    ViewData["BNID"] = GetAllBuildinginfo(Build);
                    Invlocation LocEntity = new Invlocation();
                    //LocEntity.Location = CurrentLocation;
                    //LocEntity.Userstatus = CurrentUserstatus;
                    ViewData["LocID"] = GetLocation(LocEntity);
                    InvFloorinfoEntity flvEntity = new InvFloorinfoEntity();
                    ViewData["FID"] = GetAllFloorinfo(flvEntity);
                    return View(_Model);
                }


                bool isUpdate = false;
                if (_Model.LID == null)
                {
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveLineRecord, _Model);
                    return RedirectToAction("AddLine", "Inventory");
                }
                else if (_Model.LID != null)
                {
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateLineRecord, _Model);
                    var addedModel = _Model;
                    return Json(new { Result = "OK", Record = addedModel });
                }
                //if (isUpdate)
                // {
                //     var addedModel = _Model;
                //     return Json(new { Result = "OK", Record = addedModel });
                //     //return RedirectToAction("Additemreceive", "Inventory", addedModel);
                //    }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });

            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        public JsonResult AllLineinfo()
        {
            try
            {
                InvLineinfoEntity models = new InvLineinfoEntity();
                //models.Userstatus = CurrentUserstatus;
                //models.Location = CurrentLocation;
                var jList = GetAllLineinfo(models).Select(c => new { DisplayText = c.Text, Value = c.Value });
                return Json(new { Result = "OK", Options = jList });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public ActionResult Machineinfo()
        {
            return View();
        }
        [HttpPost]
        public JsonResult MachineinfoList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetMachineinfofoRecord, null);
                    List<InvMachineinfoEntity> ItemList = null;
                    ItemList = new List<InvMachineinfoEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new InvMachineinfoEntity()
                            {
                                MNID = dr["MNID"].ToString(),
                                MachineName = dr["MachineName"].ToString(),
                                Description = dr["Description"].ToString()
                            });
                        }
                        iCount += 1;
                    }
                    var RecordCount = dt.Rows.Count;
                    var Record = ItemList;
                    return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult AddUpdateMachineInfo(InvMachineinfoEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }


                bool isUpdate = false;
                if (_Model.MNID == null)
                    //if (DupBuildingcheck(_Model.BuildingName) != false)
                    //    return Json(new { Result = "Message", Message = "The Building Name is already taken. Please choose another." });
                    //else
                    //{
                        isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveMachineInfo, _Model);
                    //}
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateMachineInfo, _Model);
                if (isUpdate)
                {
                    var addedModel = _Model;
                    return Json(new { Result = "OK", Record = addedModel });
                }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        public JsonResult GetmachinenameByID(string mnid)
        {
            if (mnid.ToString().Trim() == "")
            {
                return Json(new { Result = "ERROR", Message = "Enter Item and Model ID" });
            }
            else
            {
                try
                {
                    InvMachineinfoEntity obj = (InvMachineinfoEntity)GetMachinedetail(mnid);

                    return Json(obj);
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
        }
       
        public ActionResult MEfficincy()
        {
            return View();
        }

        
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
