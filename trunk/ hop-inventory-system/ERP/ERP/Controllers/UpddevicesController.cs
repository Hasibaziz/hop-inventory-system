using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Structure;
using ERP.Domain.Model;
using System.Threading;
using System.Data;


namespace ERP.Controllers
{
    public class UpddevicesController : BaseController
    {
        //
        // GET: /Upddevices/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Locationinfo()
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


                bool isUpdate = false;
                if (_Model.AccountID == null)
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveInventoryDetails, _Model);
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateInventoryDetails, _Model);
                if (isUpdate)
                {
                    //var addedModel = _Model;
                    //return Json(new { Script = "alert('Saved successfully');" });
                    //return new JavaScriptResult() { Script = "alert('saved Successfully Added. Thank You.'); window.location='/ObnCategory/Index';" };
                    //return new JavaScriptResult() { Script = "PopUpWindow('saved Successfully Added. Thank You.');" };
                    return RedirectToAction("PCDetails", "Upddevices");
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


                bool isUpdate = false;
                if (_Model.AccountID == null)
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveLaptopDetails, _Model);
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateLaptopDetails, _Model);
                if (isUpdate)
                {
                    //var addedModel = _Model;
                    //return Json(new { Result = "OK", Record = addedModel });
                    return RedirectToAction("LaptopDetails", "Upddevices");
                }
                else
                    return Json(new { Result = "ERROR", Message = "Information failed to save" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
       

    }
}
