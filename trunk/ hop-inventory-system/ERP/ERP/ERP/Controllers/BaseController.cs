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

        protected void SetLoginSessionData(SystemContact contact, bool createPersistentCookie)
        {
            SetUserSessionData(contact);
            FormsAuthentication.SetAuthCookie("1", createPersistentCookie);
        }

        protected void SetUserSessionData(SystemContact contact)
        {
            CurrentUserName = contact.FirstName + " " + contact.LastName;
            LoginDatetime = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
            CurrentUserId = "1";
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
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
