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
using ERP.Reports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ERP.Utility;


namespace ERP.Controllers
{
    public class UpdusersController : BaseController
    {
        //
        // GET: /Updusers/

        public ActionResult Index()
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
        public JsonResult AllDeviceinfoList(InvInventorydetailsEntity _Model, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    _Model.Location = CurrentLocation;
                    _Model.Userstatus = CurrentUserstatus;
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetALLDeviceinfoRecord, _Model);
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
                                DeviceID = dr["DeviceID"].ToString(),
                                Y = dr["Y"].ToString(),
                                M = dr["M"].ToString(),
                                D = dr["D"].ToString(),
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
        [HttpPost]
        public JsonResult InventoryDetailsList(InvInventorydetailsEntity _Model, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    _Model.Location = CurrentLocation;
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetInventoryDetailsRecord, _Model);
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
                                //Y = dr["Y"].ToString()
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
        public ActionResult InventoryDetailsView()
        {
            return View();
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
                    return RedirectToAction("InventoryDetailsView", "Updusers");
                }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
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

            return View("InventoryDetails", _Model);
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

        //////////////////////////////////////  Laptop Information ////////////////////////////////////////////
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
        public JsonResult LaptopinfoList(InvInventorydetailsEntity _Model, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
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

                _Model.UserID = CurrentUserId;
                _Model.Modifydate = LoginDatetime;
                bool isUpdate = false;
                if (_Model.AccountID == null)
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveLaptopDetails, _Model);
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateLaptopDetails, _Model);
                if (isUpdate)
                {
                    //var addedModel = _Model;
                    //return Json(new { Result = "OK", Record = addedModel });
                    return RedirectToAction("Laptopinfo", "Updusers");
                }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        ////////////////////////////////////////////////***************************OPAX ITEMS******************/////////////////////////////////
        public JsonResult AllLocation()
        {
            try
            {
                Invlocation models = new Invlocation();
                var jList = GetLocation(models).Select(c => new { DisplayText = c.Text, Value = c.Value });
                return Json(new { Result = "OK", Options = jList });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        
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
                                IRID = dr["IRID"].ToString(),
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
                    return RedirectToAction("Additemreceive", "Updusers");
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
            LocEntity.Location = CurrentLocation;
            LocEntity.Userstatus = CurrentUserstatus;
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
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetReceiveissueListRecord, null);
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
            return View();
        }
        [HttpPost]
        public ActionResult Issueitems(InvreceivenissueEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
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

////////////////////////////////////////////////////////// **********Stock Information********///////////////////////////////////////////////////////
        public ActionResult Stockinfo()
        {
            InvitemsEntity items = new InvitemsEntity();
            ViewData["ItemName"] = GetAllitemsName(items);
            InvmodelEntity models = new InvmodelEntity();
            ViewData["ModelName"] = GetAllmodelsName(models);
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
                                SID = dr["SID"].ToString(),
                                ModelID = dr["ModelID"].ToString(),
                                ItemID = dr["ItemID"].ToString(),
                                SDate = dr["SDate"].ToString(),
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
        public JsonResult StockinfoByDate(InvallstockEntity _Model, String StartDate = "", String EndDate = "", String ItemID = "", String ModelID = "", int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
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
                                SID = dr["SID"].ToString(),
                                ModelID = dr["ModelID"].ToString(),
                                ItemID = dr["ItemID"].ToString(),
                                SDate = dr["SDate"].ToString(),
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
///////////////////////////////////////********************************* GET Pass Reports **********/////////////////////////////////////////////////
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
                                IssueName = CurrentUserName,
                                ILocation = CurrentLocation,
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
////////////////////////////////////////////////////////////******************************//////////////////////////////////////////////////////////////////

    }
}
