using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Structure;
using ERP.Domain.Model;
using System.Threading;
using System.Data;
using ERP.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ERP.Controllers
{
    public class DevicesController : BaseController
    {
        //
        // GET: /Devices/hasib_aziz@yahoo.com

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MonitorInfo()
        {
            return View();
        }
        public ActionResult PrinterInfo()
        {
            return View();
        }

        public ActionResult PCDetails()
        {
            //InvInventorydetailsEntity InvEntity = new InvInventorydetailsEntity();
            InvDepartmentinfoEntity DeptEntity = new InvDepartmentinfoEntity();
            ViewData["DeptID"] = GetAllDepartmentnameList(DeptEntity);
            EmployeeinfoEntity EMP = new EmployeeinfoEntity();
            ViewData["EmpID"] = GetAllEmployeenameList(EMP);
            InvDeviceinfoEntity DEV = new InvDeviceinfoEntity();
            ViewData["DeviceID"] = GetAllDeviceList(DEV);
            //return View(InvEntity);
            return View();
        }
        [HttpPost]
        public ActionResult PCDetails(InvInventorydetailsEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    //return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                    InvInventorydetailsEntity InvEntity = new InvInventorydetailsEntity();
                    InvDepartmentinfoEntity DeptEntity = new InvDepartmentinfoEntity();
                    ViewData["DeptID"] = GetAllDepartmentnameList(DeptEntity);
                    EmployeeinfoEntity EMP = new EmployeeinfoEntity();
                    ViewData["EmpID"] = GetAllEmployeenameList(EMP);
                    InvDeviceinfoEntity DEV = new InvDeviceinfoEntity();
                    ViewData["DeviceID"] = GetAllDeviceList(DEV);
                    return View(InvEntity);
                } 
                _Model.UserID = CurrentUserId;
                _Model.Modifydate = LoginDatetime;
                bool isUpdate = false;
                if (_Model.AccountID == null)
                {                  
                    //Autonumber(_Model.Location);  

                    object locnum = Autonumber(_Model.Location);                    
                    //object enumber=Autonumber(_Model.ENumber);
                    //_Model.Location = location(_Model.Location);                       
                    if (locnum == null)
                    {
                        //Autovalue.Fornullvalue(_Model.Location);
                        _Model.ENumber = Autovalue.Fornullvalue(_Model.Location);
                        // if (Depvaluecheck(_Model.AccountCode) != false)
                        //return Json(new { Success = true, Message = "Asset Code Already Exists" }); 
                        //Main     return Json(new { Result = "Message", Message = "Asset Code Already Exists." });
                        //return new JavascriptResult { Script = "alert('Saved successfully');" };
                        //return Content("<script language='javascript' type='text/javascript'>alert('Asset Code Already Exists!');</script>");                         
                        //return Json("ok");
                    }
                    else
                    {
                        //object enumber = Autonumber(_Model.ENumber);
                        string current = locnum.ToString();
                        //string current = Autonumber(current);
                        _Model.ENumber = Autovalue.GetNextValue(current);
                    }
                    //TempData["alertMessage"] = "Whatever you want to alert the user with";
                    TempData["notice"] = "New Equipment Number:" + _Model.ENumber;
                    //Json(new { Message = "New Equipment Number: "+_Model.ENumber });
                    //ViewBag.Message = "New Equipment Number:" + _Model.ENumber;
                    Response.Write("<script>alert('New Equipment Number:');</script>" + _Model.ENumber );
                    JavaScript("alert('Email sent successfully');" + _Model.ENumber);
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveInventoryDetails, _Model);                   
                }
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateInventoryDetails, _Model);             
               

                if (isUpdate)
                {
                    //var addedModel = _Model;
                   //return Json(new { Script = "alert('Saved successfully');" });
                    //return new JavaScriptResult() { Script = "alert('saved Successfully Added. Thank You.'); window.location='/ObnCategory/Index';" };
                    //return new JavaScriptResult() { Script = "PopUpWindow('saved Successfully Added. Thank You.');" };
                    //Response.Write("<script>alert('OK!');</script>");
                    //return RedirectToAction("PCDetails", "Devices", new { Message = " <script>alert('New Equipment Number:');</script>" + _Model.ENumber });
                    return RedirectToAction("PCDetails", "Devices");
                }
                else
                    return Json(new { Success = "ERROR", Message = "Information failed to save" });
            }
            catch (Exception ex)
            {
                return Json(new { Success = "ERROR", Message = ex.Message });
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
        [HttpPost]
        public ActionResult LaptopDetails(InvInventorydetailsEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    //return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                    InvInventorydetailsEntity InvEntity = new InvInventorydetailsEntity();
                    InvDepartmentinfoEntity DeptEntity = new InvDepartmentinfoEntity();
                    ViewData["DeptID"] = GetAllDepartmentnameList(DeptEntity);
                    EmployeeinfoEntity EMP = new EmployeeinfoEntity();
                    ViewData["EmpID"] = GetAllEmployeenameList(EMP);
                    InvDeviceinfoEntity DEV = new InvDeviceinfoEntity();
                    ViewData["DeviceID"] = GetAllDeviceList(DEV);
                    return View(InvEntity);
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
                    return RedirectToAction("LaptopDetails", "Devices");
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
        public ActionResult ServerDetails()
        {
            InvDepartmentinfoEntity DeptEntity = new InvDepartmentinfoEntity();
            ViewData["DeptID"] = GetAllDepartmentnameList(DeptEntity);
            EmployeeinfoEntity EMP = new EmployeeinfoEntity();
            ViewData["EmpID"] = GetAllEmployeenameList(EMP);
            InvDeviceinfoEntity DEV = new InvDeviceinfoEntity();
            ViewData["DeviceID"] = GetAllDeviceList(DEV);
            InvInventorydetailsEntity InvDet = new InvInventorydetailsEntity();
            InvDet.MonitorName = "None"; InvDet.MSerialNo = "None";
            InvDet.MModelNo = "None"; InvDet.MPurchDate = "None";
            InvDet.MDistDate = "None";
            return View(InvDet);
        }

        [HttpPost]
        public ActionResult ServerDetails(InvInventorydetailsEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    //return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                    InvDepartmentinfoEntity DeptEntity = new InvDepartmentinfoEntity();
                    ViewData["DeptID"] = GetAllDepartmentnameList(DeptEntity);
                    EmployeeinfoEntity EMP = new EmployeeinfoEntity();
                    ViewData["EmpID"] = GetAllEmployeenameList(EMP);
                    InvDeviceinfoEntity DEV = new InvDeviceinfoEntity();
                    ViewData["DeviceID"] = GetAllDeviceList(DEV);
                    InvInventorydetailsEntity InvDet = new InvInventorydetailsEntity();
                    InvDet.MonitorName = "None"; InvDet.MSerialNo = "None";
                    InvDet.MModelNo = "None"; InvDet.MPurchDate = "None";
                    InvDet.MDistDate = "None";
                    return View(InvDet);
                }

                _Model.UserID = CurrentUserId;
                _Model.Modifydate = LoginDatetime;
                bool isUpdate = false;
                if (_Model.AccountID == null)
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveServerDetails, _Model);
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateServerDetails, _Model);
                if (isUpdate)
                {
                    //var addedModel = _Model;
                    //return Json(new { Result = "OK", Record = addedModel });
                    return RedirectToAction("ServerDetails", "Devices");
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
        public ActionResult UPSInfo()
        {
            return View();
        }

        [HttpPost]
        public JsonResult MonitorInfoList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetMonitorInfoRecord, null);
                    List<MonitorDetailsEntity> ItemList = null;
                    ItemList = new List<MonitorDetailsEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new MonitorDetailsEntity()
                            {
                                MonitorID = dr["MonitorID"].ToString(),
                                MonitorName = dr["MonitorName"].ToString(),
                                ModelNo = dr["ModelNo"].ToString(),
                                SerialNo = dr["SerialNo"].ToString(),
                                PurchDate = dr["PurchDate"].ToString(),
                                DeptID = dr["DeptID"].ToString(),
                                EmpID = dr["EmpID"].ToString(),
                                DistDate = dr["DistDate"].ToString()
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
        public JsonResult AddUpdateMonitorInfo(MonitorDetailsEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }


                bool isUpdate = false;
                if (_Model.MonitorID == null)
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveMonitorInfo, _Model);
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateMonitorInfo, _Model);
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
        public JsonResult DeleteMonitorInfo(string MonitorID)
        {
            try
            {
                Thread.Sleep(50);
                bool isUpdate = false;
                isUpdate = (bool)ExecuteDB(ERPTask.AG_DeleteMonitorInfoById, MonitorID);
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
        public JsonResult PrinterInfoList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetPrinterInfoRecord, null);
                    List<PrinterInfoEntity> ItemList = null;
                    ItemList = new List<PrinterInfoEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new PrinterInfoEntity()
                            {
                                PrinterID = dr["PrinterID"].ToString(),
                                AccountCode = dr["AccountCode"].ToString(),
                                PrinterName = dr["PrinterName"].ToString(),                               
                                IPMAC = dr["IPMAC"].ToString(),
                                PurchDate = dr["PurchDate"].ToString(),
                                DeptID = dr["DeptID"].ToString(),
                                DistDate = dr["DistDate"].ToString(),
                                Type = dr["Type"].ToString(),
                                Totaluser = dr["Totaluser"].ToString(),                                
                                Dailyppage = dr["Dailyppage"].ToString(),
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
        public JsonResult AddUpdatePrinterInfo(PrinterInfoEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }


                bool isUpdate = false;
                if (_Model.PrinterID == null)
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_SavePrinterInfo, _Model);
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdatePrinterInfo, _Model);
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
        public JsonResult DeletePrinterInfo(string PrinterID)
        {
            try
            {
                Thread.Sleep(50);
                bool isUpdate = false;
                isUpdate = (bool)ExecuteDB(ERPTask.AG_DeletePrinterInfoById, PrinterID);
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
        public JsonResult UPSInfoList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                try
                {
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetUPSInfoRecord, null);
                    List<UPSInfoEntity> ItemList = null;
                    ItemList = new List<UPSInfoEntity>();
                    int iCount = 0;
                    int offset = 0;
                    offset = jtStartIndex / jtPageSize;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                        {
                            ItemList.Add(new UPSInfoEntity()
                            {
                                UPSID = dr["UPSID"].ToString(),
                                UPSName = dr["UPSName"].ToString(),
                                ModelNo = dr["ModelNo"].ToString(),
                                SerialNo = dr["SerialNo"].ToString(),
                                PurchDate = dr["PurchDate"].ToString(),
                                DeptID = dr["DeptID"].ToString(),
                                EmpID = dr["EmpID"].ToString(),
                                DistDate = dr["DistDate"].ToString()
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
        public JsonResult AddUpdateUPSInfo(UPSInfoEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }


                bool isUpdate = false;
                if (_Model.UPSID == null)
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveUPSInfo, _Model);
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateUPSInfo, _Model);
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
        public JsonResult DeleteUPSInfo(string UPSID)
        {
            try
            {
                Thread.Sleep(50);
                bool isUpdate = false;
                isUpdate = (bool)ExecuteDB(ERPTask.AG_DeleteUPSInfoById, UPSID);
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
        [HttpPost]
        public ActionResult PrinterView(InvInventorydetailsEntity _Model)
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
                    return RedirectToAction("PrinterDetails", "Inventory");
                }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }

        }
/// <summary>
/// //////////////////////////////////////////////Employee ID *****************/////////////////////////////////
/// </summary>
/// <param name="UserID"></param>
/// <returns></returns>
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

/// <summary>
/// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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

        public bool Depvaluecheck(string UserID)
        {
              try
                {
                    InvInventorydetailsEntity obj = (InvInventorydetailsEntity)GetDupvalue(UserID);
                    if(obj.AccountCode==null)
                        return false;
                    else 
                        return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

        //public JsonResult Autonumber(string Loc)
        //{

        //    try
        //    {
        //        InvInventorydetailsEntity obj = (InvInventorydetailsEntity)Getautono(Loc);
        //        TempData["ENumber"] = obj.ENumber;
        //        return Json(obj);
        //        //return new JsonResult{Data = obj};
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Result = "ERROR", Message = ex.Message });
        //    }
        //}

        private object Autonumber(string Loc)
        {
            InvInventorydetailsEntity _Model = new InvInventorydetailsEntity();
            _Model.Location = Loc;
            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAutonumber, Loc);
            foreach (DataRow dr in dt.Rows)
            {

                _Model.Location = dr["Location"].ToString();
                _Model.ENumber = dr["ENumber"].ToString();

            }
            if (_Model.Location == null)
                return (_Model.Location);
            else
                return (_Model.ENumber);
        }      

/////////////////////////////////////////////////************** Equipment Entry ******///////////////////////////////////////////
        public ActionResult Newequipment()
        {
            InvCountryinfoEntity Country = new InvCountryinfoEntity();
            ViewData["CID"] = GetCountry(Country);
            InvUnitinfoEntity Units = new InvUnitinfoEntity();
            ViewData["UnitID"] = GetAllUnit(Units);
            InvFloorinfoEntity FEntity = new InvFloorinfoEntity();
            ViewData["FID"] = GetAllFloorinfo(FEntity);
            InvLineinfoEntity lEntity = new InvLineinfoEntity();
            ViewData["LID"] = GetAllLineinfo(lEntity);
            InvMachineinfoEntity mEntity = new InvMachineinfoEntity();
            ViewData["MNID"] = GetAllMachineinfo(mEntity);
            InvBuilinginfoEntity Build = new InvBuilinginfoEntity();
            ViewData["BNID"] = GetAllBuildinginfo(Build);
            Invlocation LocEntity = new Invlocation();
            //LocEntity.Location = CurrentLocation;
            //LocEntity.Userstatus = CurrentUserstatus;
            ViewData["LocID"] = GetLocation(LocEntity);
            return View();
        }
        [HttpPost]
        public ActionResult Newequipment(InvEquipmentEntity _Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });                   
                }
                //_Model.UserID = CurrentUserId;
                //_Model.Modifydate = LoginDatetime;
                bool isUpdate = false;
                if (_Model.EID == null)
                {
                    //Autonumber(_Model.Location);  

                    object locnum = EQAutonumber(_Model.LocID);                                        
                    if (locnum == null)
                    {
                       _Model.ENumber = Autovalue.FornullvalueLocID(_Model.LocID);                       
                    }
                    else
                    {
                        //object enumber = Autonumber(_Model.ENumber);
                        string current = locnum.ToString();
                        //string current = Autonumber(current);
                        _Model.ENumber = Autovalue.GetNextValue(current);
                    }
                    //TempData["alertMessage"] = "Whatever you want to alert the user with";
                    TempData["notice"] = "New Equipment Number:" + _Model.ENumber;
                    //Json(new { Message = "New Equipment Number: "+_Model.ENumber });
                    //ViewBag.Message = "New Equipment Number:" + _Model.ENumber;
                    Response.Write("<script>alert('New Equipment Number:');</script>" + _Model.ENumber);
                    JavaScript("alert('New Equipment Number:');" + _Model.ENumber);
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveEquipmentDetails, _Model);
                }
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateEquipmentDetails, _Model);


                if (isUpdate)
                {
                    return RedirectToAction("Newequipment", "Devices");
                }
                else
                    return Json(new { Success = "ERROR", Message = "Information failed to save" });
            }
            catch (Exception ex)
            {
                return Json(new { Success = "ERROR", Message = ex.Message });
            }
        }
        private object EQAutonumber(string Loc)
        {
            InvEquipmentEntity _Model = new InvEquipmentEntity();
            _Model.Location = Loc;
            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetEQAutonumber, Loc);
            foreach (DataRow dr in dt.Rows)
            {

                _Model.Location = dr["Location"].ToString();
                _Model.ENumber = dr["ENumber"].ToString();

            }
            if (_Model.Location == null)
                return (_Model.Location);
            else
                return (_Model.ENumber);
        }
        public JsonResult GetlocationBycID(string cid)
        {
            try
            {
                return Json(GetLocationList(cid));
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
        public JsonResult GetFloorByBNID(string bnid)
        {
            try
            {
                return Json(GetFloorList(bnid));
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


    }
}
