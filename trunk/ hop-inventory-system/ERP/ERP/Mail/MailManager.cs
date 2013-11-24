using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace ERP.Mail
{
    public class MailManager
    {

       public static bool SendMail(String toEmail, String pass, String message)
        //public static bool SendMail(String toEmail, String subject, String message)
        {
            bool isSent = false;
            try
            {
                isSent =SendEmail(toEmail, pass, message);
                //isSent = MailManager.SendEmail(toEmail, subject, message);
                //isSent = MailManager.SendEmailThroughGmail(toEmail, fromEmail, subject, message);
            }
            catch (Exception)
            {
                return false;
            }
            return isSent;
        }

       public static bool SendEmail(string mailTo, string mailSubject, string mailBody)
        {
            string email = ConfigurationManager.AppSettings.Get("SmtpFromEmail");
            string password = ConfigurationManager.AppSettings.Get("SmtpFromEmailPassword");
            string SmtpHost = ConfigurationManager.AppSettings.Get("SmtpHost");
            string port = ConfigurationManager.AppSettings.Get("SmtpPort");
            int SmtpPort = int.Parse(port);
         
            NetworkCredential loginInfo = new NetworkCredential(email, password);
            MailMessage msg = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = SmtpHost;
            smtpClient.Port = SmtpPort;

            smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            msg.From = new MailAddress(email);
            msg.To.Add(new MailAddress(mailTo));
           
            msg.Subject = mailSubject;
            msg.Body = mailBody;
            msg.IsBodyHtml = true;

            //smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = loginInfo;
            smtpClient.EnableSsl = true;        //For Gamil Configuration
            //****ServicePointManager **** No Need for Gmail Configuration
            ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtpClient.Send(msg);
            return true;
        }     


    }
}