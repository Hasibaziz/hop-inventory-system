using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ERP.Models;
using ERP.Structure;
using ERP.Domain.Model;
using System.Data;
using System.Configuration;



namespace ERP.Controllers
{
    public class BaseController : Controller
    {
        public object ExecuteDB(string methodName, object param)
        {
            object retObject = ServerManager.GetTaskManager.Execute(1, methodName, param);
            return retObject;
        }

        public string CurrentUserId
        {
            get
            {
                if (Session["UserId"] != null)
                {
                    return (Session["UserId"].ToString());
                }

                return string.Empty;
            }
            set
            {
                Session["UserId"] = value;
            }
        }

        public string CurrentLocation
        {
            get
            {
                if (Session["Location"] != null)
                {
                    return (Session["Location"].ToString());
                }

                return string.Empty;
            }
            set
            {
                Session["Location"] = value;
            }
        }
        public string CurrentUserstatus
        {
            get
            {
                if (Session["UsersStatus"] != null)
                {
                    return (Session["UsersStatus"].ToString());
                }

                return string.Empty;
            }
            set
            {
                Session["UsersStatus"] = value;
            }
        }

        public string CurrentUserName
        {
            get
            {
                if (Session["UserName"] != null)
                {
                    return Session["UserName"].ToString();
                }

                return string.Empty;
            }

            set { Session["UserName"] = value; }
        }

        public string LoginDatetime
        {
            get
            {
                if (Session["LoginDatetime"] != null)
                {
                    return Session["LoginDatetime"].ToString();
                }

                return string.Empty;
            }

            set { Session["LoginDatetime"] = value; }
        }

        public string CurrentUserEmail
        {
            get
            {
                if (Session["UserEmail"] != null)
                {
                    return Session["UserEmail"].ToString();
                }

                return string.Empty;
            }

            set { Session["UserEmail"] = value; }
        }
        public string CurrentUserPassword
        {
            get
            {
                if (Session["UserPassword"] != null)
                {
                    return (Session["UserPassword"].ToString());
                }

                return string.Empty;
            }
            set
            {
                Session["UserPassword"] = value;
            }
        }
        //protected void SetLoginSessionData(SystemContact contact, bool createPersistentCookie)
        //{
        //    SetUserSessionData(contact);
        //    FormsAuthentication.SetAuthCookie("1", createPersistentCookie);
        //}

        //protected void SetUserSessionData(SystemContact contact)
        //{
        //    CurrentUserName = contact.FirstName + " " + contact.LastName;
        //    LoginDatetime = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
        //    CurrentUserId = "1";
        //}

        protected void SetLoginSessionData(LoginModel LoginM, bool createPersistentCookie)
        {
            SetUserSessionData(LoginM);
            FormsAuthentication.SetAuthCookie("1", createPersistentCookie);
        }


        protected void SetUserSessionData(LoginModel LoginM)
        {
            //CurrentUserName = LoginM.Id + " " + LoginM.Password;
            CurrentUserPassword = LoginM.Password;
            CurrentUserName = LoginM.UserName;
            LoginDatetime = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
            CurrentUserId = LoginM.UserID;
            CurrentLocation = LoginM.Location;
            CurrentUserstatus = LoginM.UsersStatus;
        }


        public bool isValidField(string _val)
        {
            if (_val == null)
                return false;
            else if (_val.Trim().Length == 0)
                return false;
            else if (_val.Trim() == "Select")
                return false;
            else if (_val.Trim() == "0")
                return false;
            return true;
        }
        public bool isValidNumericField(string _val)
        {
            if (_val == null)
                return false;
            else if (_val.Trim().Length == 0)
                return false;
            else if (_val.Trim() == "0")
                return false;
            else
            {
                try
                {
                    double dl = Convert.ToDouble(_val.Trim());
                    if (dl < 0)
                        return false;
                }
                catch { return false; }
            }
            return true;
        }
        public string ConvertNulltoString(string _val)
        {
            if (_val == null)
                return "";
            else
                return _val;
        }

        public string GetConvertedDate(string _dt)
        {
            if (_dt == null) return null;

            string[] _Convertdate = _dt.Split('/');
            string _dtNewdate = _Convertdate[1] + "/" + _Convertdate[0] + "/" + _Convertdate[2];
            return _dtNewdate;
        }


        public List<SelectListItem> GetAllServiceNameListItem()
        {
            try
            {
                DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllTrServicemasterRecord, null);
                List<SelectListItem> ItemList = null;
                ItemList = new List<SelectListItem>();
                foreach (DataRow dr in dt.Rows)
                {
                    ItemList.Add(new SelectListItem()
                    {
                        Value = dr["ID"].ToString(),
                        Text = dr["Servicename"].ToString()
                    });

                }
                return ItemList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<SelectListItem> GetAllDepartmentnameList(InvDepartmentinfoEntity Dept)
        {
            try
            {
                DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetDepartmentInfoRecord, Dept);
                List<SelectListItem> ItemList = null;
                ItemList = new List<SelectListItem>();
                foreach (DataRow dr in dt.Rows)
                {
                    ItemList.Add(new SelectListItem()
                    {
                        Value = dr["DeptID"].ToString(),
                        Text = dr["DeptName"].ToString()
                    });

                }
                return ItemList;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<SelectListItem> GetAllEmployeenameList(EmployeeinfoEntity EMP)
        {
            try
            {
                DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetEmployeeInfoRecord, EMP);
                List<SelectListItem> ItemList = null;
                ItemList = new List<SelectListItem>();
                foreach (DataRow dr in dt.Rows)
                {
                    ItemList.Add(new SelectListItem()
                    {
                        Value = dr["EmpID"].ToString(),
                        Text = dr["EmpNo"].ToString()                       
                    });

                }
                return ItemList;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<SelectListItem> GetAllEmployeeName(EmployeeinfoEntity EMP)
        {
            try
            {
                DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetEmployeeInfo, EMP);
                List<SelectListItem> ItemList = null;
                ItemList = new List<SelectListItem>();
                foreach (DataRow dr in dt.Rows)
                {
                    ItemList.Add(new SelectListItem()
                    {
                        Value = dr["EmpID"].ToString(),
                        Text = dr["EmpName"].ToString()
                    });

                }
                return ItemList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<SelectListItem> GetAllDeviceList(InvDeviceinfoEntity DEV)
        {
            try
            {
                DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetDeviceInfoRecord, DEV);
                List<SelectListItem> ItemList = null;
                ItemList = new List<SelectListItem>();
                foreach (DataRow dr in dt.Rows)
                {
                    ItemList.Add(new SelectListItem()
                    {
                        Value = dr["DeviceID"].ToString(),
                        Text = dr["DeviceName"].ToString()

                    });

                }
                return ItemList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object GetInventoryDetails(string EmpID)
        {
            InventorydetailsEntity _Model = new InventorydetailsEntity();
            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetSingleEmpDetailsRecordById, EmpID);

            foreach (DataRow dr in dt.Rows)
            {

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
            return _Model;
        }

        public List<SelectListItem> GetUpdateusername(UpdateuserinfoEntity Upd)
        {
            try
            {
                DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetUpdateusernameRecord, Upd);
                List<SelectListItem> ItemList = null;
                ItemList = new List<SelectListItem>();
                foreach (DataRow dr in dt.Rows)
                {
                    ItemList.Add(new SelectListItem()
                    {
                        Value = dr["UserID"].ToString(),
                        Text = dr["UserName"].ToString()
                    });

                }
                return ItemList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object GetDupvalue(string Dep)
        {
            InventorydetailsEntity _Model = new InventorydetailsEntity();
            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetDuplicatevalue, Dep);

            foreach (DataRow dr in dt.Rows)
            {
                _Model.EMPID = dr["EMPID"].ToString();
                _Model.AccountCode = dr["AccountCode"].ToString();               

            }
            return _Model;
        }

        public object GetDupMail(string Mail)
        {
            UsercreateinfoEntity _Model = new UsercreateinfoEntity();
            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetDuplicateMail, Mail);
          
            foreach (DataRow dr in dt.Rows)
            {
                _Model.Usermail = dr["Usermail"].ToString();              

            }
            return _Model;
        }

        public object GetDupEMP(string EMP)
        {
            EmployeeinfoEntity _Model = new EmployeeinfoEntity();
            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetDuplicateEMP, EMP);

            foreach (DataRow dr in dt.Rows)
            {
                _Model.EmpNo = dr["EMPNO"].ToString();

            }
            return _Model;
        }

        public object GetDupdept(string DEPT)
        {
            InvDepartmentinfoEntity _Model = new InvDepartmentinfoEntity();
            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetDuplicatedept, DEPT);

            foreach (DataRow dr in dt.Rows)
            {
                _Model.DeptNo = dr["DeptNo"].ToString();

            }
            return _Model;
        }

        public object GetDupdevicename(string DName)
        {
            InvDevicenameEntity _Model = new InvDevicenameEntity();
            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetDupdevicename, DName);

            foreach (DataRow dr in dt.Rows)
            {
                _Model.DeviceName = dr["DeviceName"].ToString();

            }
            return _Model;
        }

       


/// <summary>
        /// ////////////************** Hit Users Information (Hasib) **********************************************************
/// </summary>
/// <returns></returns>
/// 
        public static Dictionary<string, DateTime> ConnectedtUsers { get; set; }
        public JsonResult UserConnected()
        {
            string ip = Request.UserHostAddress;
            //string yourHost = System.Net.Dns.GetHostName();
            //string yourIP = System.Net.Dns.GetHostEntry(ip).AddressList[0].ToString();
            //string yourIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            string IPA = Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Request.ServerVariables["REMOTE_ADDR"];
            if (MvcApplication.ConnectedtUsers.ContainsKey(ip))
            {
                MvcApplication.ConnectedtUsers[ip] = DateTime.Now;
            }
            else
            {
                MvcApplication.ConnectedtUsers.Add(ip, DateTime.Now);
            }

            int connected = MvcApplication.ConnectedtUsers.Where(c => c.Value.AddSeconds(30d) > DateTime.Now).Count();

            foreach (string key in MvcApplication.ConnectedtUsers.Where(c => c.Value.AddSeconds(30d) < DateTime.Now).Select(c => c.Key))
            {
                MvcApplication.ConnectedtUsers.Remove(key);
            }

            return Json(new { count = connected, result = IPA }, JsonRequestBehavior.AllowGet);
        }
        /////////////////////////// Hit Users Information End Process (Hasib) *********/////////////////////////////////////////

/// <summary>
/// ////// ///*** After Logout Browser Back Key Disable (Hasib)
/// </summary>
        public class MyExpirePageActionFilterAttribute : System.Web.Mvc.ActionFilterAttribute
        {
            public override void OnActionExecuted(System.Web.Mvc.ActionExecutedContext filterContext)
            {
                base.OnActionExecuted(filterContext);
                filterContext.HttpContext.Response.Expires = -1;
                filterContext.HttpContext.Response.Cache.SetNoServerCaching();
                filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                filterContext.HttpContext.Response.Cache.SetAllowResponseInBrowserHistory(false);
                filterContext.HttpContext.Response.CacheControl = "no-cache";
                filterContext.HttpContext.Response.Cache.SetNoStore();
            }
        }


       
///////////////////////////********************End Back Key Disable Process (Hasib) *************/////////////////////////
        public List<SelectListItem> GetLocation(Invlocation Loc)
        {
            try
            {
                DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetLocationInfo, Loc);
                List<SelectListItem> ItemList = null;
                ItemList = new List<SelectListItem>();
                foreach (DataRow dr in dt.Rows)
                {
                    ItemList.Add(new SelectListItem()
                    {
                        Value = dr["LocID"].ToString(),
                        Text = dr["Location"].ToString()
                    });

                }
                return ItemList;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<SelectListItem> GetAllitemsName(InvitemsEntity items)
        {
            try
            {
                DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetitemnameInfo, items);
                List<SelectListItem> ItemList = null;
                ItemList = new List<SelectListItem>();
                foreach (DataRow dr in dt.Rows)
                {
                    ItemList.Add(new SelectListItem()
                    {
                        Value = dr["ItemID"].ToString(),
                        Text = dr["ItemName"].ToString()
                    });

                }
                return ItemList;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<SelectListItem> GetAllmodelsName(InvmodelEntity models)
        {
            try
            {
                DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetmodelnameInfo, models);
                List<SelectListItem> ItemList = null;
                ItemList = new List<SelectListItem>();
                foreach (DataRow dr in dt.Rows)
                {
                    ItemList.Add(new SelectListItem()
                    {
                        Value = dr["ModelID"].ToString(),
                        Text = dr["ModelName"].ToString()
                    });

                }
                return ItemList;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public object GetSumvalues(string iModel, string iLoc)
        {

            InvreceivenissueEntity _Model = new InvreceivenissueEntity();
            _Model.ModelID = iModel;
            _Model.LocID = iLoc;
            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetSumvalueRecord, _Model);

            foreach (DataRow dr in dt.Rows)
            {

                //_Model.ItemID = dr["ItemID"].ToString();               
                _Model.ReceiveQty = dr["ReceiveQty"].ToString();
                _Model.TotalissueQty = dr["TotalissueQty"].ToString();
                _Model.BalanceQty = dr["BalanceQty"].ToString();          

            }
            return _Model;
        }

        public object Getautono(string Loc)
        {
            InvInventorydetailsEntity _Model = new InvInventorydetailsEntity();
            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAutonumber, Loc);

            foreach (DataRow dr in dt.Rows)
            {               
                _Model.Location = dr["Location"].ToString();
                _Model.ENumber = dr["ENumber"].ToString();

            }
            return _Model;
        }
        public object Usersumvalues(string imodel)
        {

            InvreceivenissueEntity _Model = new InvreceivenissueEntity();
            _Model.ModelID = imodel;          
            _Model.Location = CurrentLocation;
            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetusersumvalueRecord, _Model);

            foreach (DataRow dr in dt.Rows)
            {

                //_Model.ItemID = dr["ItemID"].ToString();               
                //_Model.ReceiveQty = dr["ReceiveQty"].ToString();
                //_Model.TotalissueQty = dr["TotalissueQty"].ToString();
                _Model.BalanceQty = dr["BalanceQty"].ToString();
                _Model.UIssueTotal = dr["UIssueTotal"].ToString();

            }
            return _Model;
        }

        //public object GetitemmodelsName(string IID)
        //{
        //    InvmodelEntity _Model = new InvmodelEntity();
        //    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_Getitemmodel, IID);

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        //_Model.ModelID = dr["ModelID"].ToString();
        //        _Model.ModelName = dr["ModelName"].ToString();

        //    }
        //    return _Model;
        //}

        public List<SelectListItem> GetAllEquipmentno(InvServiceinfoEntity model)
        {
            try
            {
                DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllEquipmentno, model);
                List<SelectListItem> ItemList = null;
                ItemList = new List<SelectListItem>();
                foreach (DataRow dr in dt.Rows)
                {
                    ItemList.Add(new SelectListItem()
                    {
                        Value = dr["AccountID"].ToString(),
                        Text = dr["ENumber"].ToString()
                    });

                }
                return ItemList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object GetDupCountry(string CName)
        {
            InvCountryinfoEntity _Model = new InvCountryinfoEntity();
            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetDupCountry, CName);

            foreach (DataRow dr in dt.Rows)
            {
                _Model.Name = dr["Name"].ToString();

            }
            return _Model;
        }
        public List<SelectListItem> GetCountry(InvCountryinfoEntity CNAME)
        {
            try
            {
                DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllCountry, CNAME);
                List<SelectListItem> ItemList = null;
                ItemList = new List<SelectListItem>();
                foreach (DataRow dr in dt.Rows)
                {
                    ItemList.Add(new SelectListItem()
                    {
                        Value = dr["CID"].ToString(),
                        Text = dr["Name"].ToString()
                    });

                }
                return ItemList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object GetDupUnit(string UName)
        {
            InvUnitinfoEntity _Model = new InvUnitinfoEntity();
            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetDupUnit, UName);

            foreach (DataRow dr in dt.Rows)
            {
                _Model.UnitName = dr["UnitName"].ToString();

            }
            return _Model;
        }
        public List<SelectListItem> GetAllUnit(InvUnitinfoEntity Unit)
        {
            try
            {
                DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllUnit, Unit);
                List<SelectListItem> ItemList = null;
                ItemList = new List<SelectListItem>();
                foreach (DataRow dr in dt.Rows)
                {
                    ItemList.Add(new SelectListItem()
                    {
                        Value = dr["UnitID"].ToString(),
                        Text = dr["UnitName"].ToString()
                    });

                }
                return ItemList;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<SelectListItem> GetAllEquipment(InvEquipmentEntity Equip)
        {
            try
            {
                DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllENUMBERList, Equip);
                List<SelectListItem> ItemList = null;
                ItemList = new List<SelectListItem>();
                foreach (DataRow dr in dt.Rows)
                {
                    ItemList.Add(new SelectListItem()
                    {
                        Value = dr["EID"].ToString(),
                        Text = dr["ENumber"].ToString()
                    });

                }
                return ItemList;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<SelectListItem> GetAllBuildinginfo(InvBuilinginfoEntity Buld)
        {
            try
            {
                DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllBuildinginfo, Buld);
                List<SelectListItem> ItemList = null;
                ItemList = new List<SelectListItem>();
                foreach (DataRow dr in dt.Rows)
                {
                    ItemList.Add(new SelectListItem()
                    {
                        Value = dr["BNID"].ToString(),
                        Text = dr["BuildingName"].ToString()
                    });

                }
                return ItemList;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<SelectListItem> GetAllFloorinfo(InvFloorinfoEntity Floor)
        {
            try
            {
                DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllFloorinfo, Floor);
                List<SelectListItem> ItemList = null;
                ItemList = new List<SelectListItem>();
                foreach (DataRow dr in dt.Rows)
                {
                    ItemList.Add(new SelectListItem()
                    {
                        Value = dr["FID"].ToString(),
                        Text = dr["FloorName"].ToString()
                    });

                }
                return ItemList;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<SelectListItem> GetAllLineinfo(InvLineinfoEntity line)
        {
            try
            {
                DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllLineinfo, line);
                List<SelectListItem> ItemList = null;
                ItemList = new List<SelectListItem>();
                foreach (DataRow dr in dt.Rows)
                {
                    ItemList.Add(new SelectListItem()
                    {
                        Value = dr["LID"].ToString(),
                        Text = dr["LineName"].ToString()
                    });

                }
                return ItemList;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<SelectListItem> GetAllMachineinfo(InvMachineinfoEntity line)
        {
            try
            {
                DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllMachineinfo, line);
                List<SelectListItem> ItemList = null;
                ItemList = new List<SelectListItem>();
                foreach (DataRow dr in dt.Rows)
                {
                    ItemList.Add(new SelectListItem()
                    {
                        Value = dr["MNID"].ToString(),
                        Text = dr["MachineName"].ToString()
                    });

                }
                return ItemList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<SelectListItem> GetLocationList(string CountryID)
        {
            Invlocation bh = new Invlocation();
            //EmployeeinfoEntity bh = new EmployeeinfoEntity();
            bh.CID = CountryID;

            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllLocationByCID, bh);
            List<SelectListItem> Items = new List<SelectListItem>();
            if (dt.Rows.Count > 0)
            {
                Items.Add(new SelectListItem { Text = "", Value = "" });
                foreach (DataRow dr in dt.Rows)
                {
                    Items.Add(new SelectListItem { Text = dr["Location"].ToString(), Value = dr["LocID"].ToString() });
                }
            }
            else
            {
                Items = new List<SelectListItem>();
                Items.Add(new SelectListItem { Text = "", Value = "" });
            }
            return Items;
        }
        public List<SelectListItem> GetBuildingList(string locID)
        {
            Invlocation Model = new Invlocation();
            //EmployeeinfoEntity bh = new EmployeeinfoEntity();
            Model.LocID = locID;

            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllBuildingByCID, Model);
            List<SelectListItem> Items = new List<SelectListItem>();
            if (dt.Rows.Count > 0)
            {
                Items.Add(new SelectListItem { Text = "", Value = "" });
                foreach (DataRow dr in dt.Rows)
                {
                    Items.Add(new SelectListItem { Text = dr["BuildingName"].ToString(), Value = dr["BNID"].ToString() });
                }
            }
            else
            {
                Items = new List<SelectListItem>();
                Items.Add(new SelectListItem { Text = "", Value = "" });
            }
            return Items;
        }
        public List<SelectListItem> GetFloorList(string Buildingid)
        {
            InvBuilinginfoEntity Model = new InvBuilinginfoEntity();
            //EmployeeinfoEntity bh = new EmployeeinfoEntity();
            Model.BNID = Buildingid;

            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllGetFloorByBNID, Model);
            List<SelectListItem> Items = new List<SelectListItem>();
            if (dt.Rows.Count > 0)
            {
                Items.Add(new SelectListItem { Text = "", Value = "" });
                foreach (DataRow dr in dt.Rows)
                {
                    Items.Add(new SelectListItem { Text = dr["FloorName"].ToString(), Value = dr["FID"].ToString() });
                }
            }
            else
            {
                Items = new List<SelectListItem>();
                Items.Add(new SelectListItem { Text = "", Value = "" });
            }
            return Items;
        }
        public object GetMachinedetail(string imodel)
        {

            InvMachineinfoEntity _Model = new InvMachineinfoEntity();
            _Model.MNID = imodel;
            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetMachinedetail, _Model);

            foreach (DataRow dr in dt.Rows)
            {

                _Model.MNID = dr["MNID"].ToString();
                _Model.Description = dr["Description"].ToString();               

            }
            return _Model;
        }


        public object GetDupBuilding(string BName)
        {
            InvBuilinginfoEntity _Model = new InvBuilinginfoEntity();
            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetDupBuilding, BName);

            foreach (DataRow dr in dt.Rows)
            {
                _Model.LocID = dr["LocID"].ToString();
                _Model.BuildingName = dr["BuildingName"].ToString();

            }
            return _Model;
        }
    }
}
