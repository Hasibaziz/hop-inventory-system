using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using ERP.Models;
using ERP.DAL;
using System.Data;
using ERP.Structure;
using System.Text;
using ERP.Utility;

namespace ERP.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        public ActionResult Login(LoginModel model)
        {
            ModelState.Clear();
            return View("Login", model);
        }
        [HttpPost]
        public ActionResult Login(string submit, LoginModel model)
        {
                User iUser = new User();                               
                if(model.Password!=null)
                     model.Password = Encdecript.Encryptdata(model.Password);               

                DataTable dt = iUser.GetUserInfo(model);
                if (dt.Rows.Count > 0)
                {                   
                    if ((model.UserName == dt.Rows[0]["UserName"].ToString())
                        && (model.Password == dt.Rows[0]["Password"].ToString()))
                    {
                        model.UserName = dt.Rows[0]["UserName"].ToString();
                        model.UserID = dt.Rows[0]["UserID"].ToString();
                        model.Password =dt.Rows[0]["Password"].ToString();
                        model.Location = dt.Rows[0]["Location"].ToString();
                        model.UsersStatus = dt.Rows[0]["UsersStatus"].ToString();
                        
                        SetLoginSessionData(model, false);
                        if (CurrentLocation == "HLUN" && CurrentUserstatus=="Admin")
                            return RedirectToAction("Index", "Home");
                        else if ((CurrentLocation == "HLBD" && CurrentUserstatus == "Normal" )
                                || (CurrentLocation == "HLNT" && CurrentUserstatus == "Normal" ) 
                                || (CurrentLocation == "HLAP" && CurrentUserstatus=="Normal"))  // Edit Update Data
                            return RedirectToAction("Index", "Updusers");
                        else if ((CurrentLocation == "HLBD" && CurrentUserstatus == "OPEX")
                            || (CurrentLocation == "HLNT" && CurrentUserstatus == "OPEX")
                            || (CurrentLocation == "HYBD" && CurrentUserstatus == "OPEX")) //Factory Users Only
                            return RedirectToAction("Index", "OPEX");
                        else                            
                            return RedirectToAction("Index", "Users");
                    }
                    else
                    {

                        ModelState.AddModelError("UserName", "invalid User Name or password.");
                    }
                }
                else
                {

                    ModelState.AddModelError("UserName", "invalid User Name or password.");
                }
            
            return View("Login", model);
        }
        public JsonResult UserNameLOC(string UName)
        {
              try
                {
                    LoginModel obj = (LoginModel)GetLocation(UName);

                    return Json(obj);
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }           
        }
        public object GetLocation(string UName)
        {
            LoginModel _Model = new LoginModel();
            _Model.UserName = UName;
            User iUser = new User();
            DataTable dt = iUser.SetUserName(_Model);

            foreach (DataRow dr in dt.Rows)
            {

                _Model.UserName = dr["UserName"].ToString();
                _Model.Location = dr["Location"].ToString();                      

            }
            return _Model;
        }

        public ActionResult Forgetpass(string UEmail)
        {
            //LoginModel LM = new LoginModel();
            //LM.Useremail = UEmail;
            //if(Request.IsAjaxRequest())
            //    return PartialView("_Forgetpass", LM);
            //return PartialView("_Forgetpass");
            return PartialView("Login");           
        }

        public JsonResult GetForgetmail(string Umail)
        {
            try
            {
                    LoginModel _Model = new LoginModel();
                    _Model.Useremail = Umail;
                    if (_Model.Useremail == "")
                    {
                        return Json(new { Success = "Information failed to Send", Message = "Information failed" });
                    }
                    else
                    {

                        User iUser = new User();
                        DataTable dt = iUser.GetForgetpass(_Model);

                        foreach (DataRow dr in dt.Rows)
                        {

                            _Model.Password = dr["Password"].ToString();
                            _Model.UserName = dr["UserName"].ToString();
                            _Model.Location = dr["Location"].ToString();

                        }
                        string Decryptpass = _Model.Password;
                        _Model.Password = Encdecript.Decryptdata(Decryptpass);
                        WebUtil.sendPasswordToSiteUser(_Model);
                    }
                    return Json(new { Success = "Please Check Mail", Message = "Information Passed" });             
              }
            catch (Exception ex)
            {
                return Json(new { Success = "Enter a Valid Mail", Message = ex.Message });
            }
        }      


        public ActionResult Logout(SystemUserModel model)
        {
            //Response.ExpiresAbsolute = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0));
            //Response.Expires = 0;
            //Response.CacheControl = "no-cache";

            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }      

    }
}
