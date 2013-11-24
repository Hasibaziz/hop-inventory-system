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

namespace ERP.Controllers
{
    public class UsersController : BaseController
    {
        //
        // GET: /Users/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Locationinfo()
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
                                Y=dr["Y"].ToString(),
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
        public ActionResult InventoryDetailsView()
        {
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
                    _Model.Userstatus = CurrentUserstatus;
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
       

    }
}
