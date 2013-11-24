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
using ERP.Utility;

namespace ERP.Controllers
{
    public class OpexController : BaseController
    {
        //
        // GET: /Opex/

        public ActionResult Index()
        {
            return View();
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
        /////////////////////////////////////////////////////////**********Stock Information*******************//////////////////////////////////////////

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


    }
}
