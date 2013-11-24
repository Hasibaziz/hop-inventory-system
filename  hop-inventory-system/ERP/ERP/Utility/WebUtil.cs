using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using ERP.Domain.Model;
using ERP.Mail;

namespace ERP.Utility
{
    public class WebUtil
    {
        public static bool sendNotificationToSiteUser(UsercreateinfoEntity user)
        {
            StringBuilder template = new StringBuilder(WebUtil.ReadEmailTemplate(AppConstants.EmailTemplate.COMMON));
            if (template.Length > 0)
            {
                StringBuilder sb = new StringBuilder();
                //sb.AppendFormat("Dear Admin,<br/>");
                sb.AppendFormat("Thank you for registering in {0}. Your user name and passwords are -.<br /><br />", ConfigReader.SiteName);
                sb.AppendFormat("User Name: {0}<br />Password: {1}<br /> Location: {2}", user.UserName, user.Password, user.LocID);

                ///Proejct Details
                //sb.Append("<br /><br />");
                template.Replace(AppConstants.ETConstants.DOMAIN, WebUtil.GetDomainAddress());
                template.Replace(AppConstants.ETConstants.MESSAGE, sb.ToString());
                // String fromEmail = ConfigReader.SupportEmail;
                String toEmail = String.Empty;//ConfigReader.AdminEmail;
                string pass = string.Empty;
                toEmail = user.Usermail;
                pass = user.Password;
                //string emailBody = "Thank You for Your registering at Hop Lun (Bangladesh) Ltd. Inventory System-10.3.12.156:802 <br /><br />";
                //MailManager mailmgr = new MailManager();
                String subject = String.Format("User information for {0}.", ConfigReader.SiteName);
                // WebUtil.SendMail(fromEmail, toEmail, String.Empty, String.Empty, subject, template.ToString());
                MailManager.SendMail(toEmail, subject, template.ToString());
            }
            return true;
        }

        public static String ReadEmailTemplate(String templateFileName)
        {
            String filePath = HttpContext.Current.Server.MapPath(templateFileName);
            if (File.Exists(filePath))
                return File.ReadAllText(filePath);

            return String.Empty;
        }
        public static String GetDomainAddress()
        {
            Uri uri = HttpContext.Current.Request.Url;
            String url = String.Format("{0}{1}{2}{3}", uri.Scheme, Uri.SchemeDelimiter, uri.Host, uri.Port == 80 ? String.Empty : ":" + uri.Port);
            //return String.Format("http://{0}", HttpContext.Current.Request.Url.Host);
            return url;
         }


        internal static bool sendPasswordToSiteUser(Models.LoginModel Email)
        {
            StringBuilder template = new StringBuilder(WebUtil.ReadEmailTemplate(AppConstants.EmailTemplate.COMMON));
            if (template.Length > 0)
            {
                StringBuilder sb = new StringBuilder();
                //sb.AppendFormat("Dear Admin,<br/>");
                sb.AppendFormat("Thank you for registering in {0}. Your user name and passwords are -.<br /><br />", ConfigReader.SiteName);
                sb.AppendFormat("User Name: {0}<br />Password: {1}<br /> Location: {2}", Email.UserName, Email.Password, Email.Location);

                ///Proejct Details
                //sb.Append("<br /><br />");
                template.Replace(AppConstants.ETConstants.DOMAIN, WebUtil.GetDomainAddress());
                template.Replace(AppConstants.ETConstants.MESSAGE, sb.ToString());
                // String fromEmail = ConfigReader.SupportEmail;
                String toEmail = String.Empty;//ConfigReader.AdminEmail;
                string pass = string.Empty;
                toEmail = Email.Useremail;
                pass = Email.Password;
                //string emailBody = "Thank You for Your registering at Hop Lun (Bangladesh) Ltd. Inventory System-10.3.12.156:802 <br /><br />";
                //MailManager mailmgr = new MailManager();
                String subject = String.Format("User information for {0}.", ConfigReader.SiteName);
                // WebUtil.SendMail(fromEmail, toEmail, String.Empty, String.Empty, subject, template.ToString());
                MailManager.SendMail(toEmail, subject, template.ToString());
            }
            return true;
        }
    }
}