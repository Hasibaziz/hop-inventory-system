using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Domain.Model
{
   public class UsercreateinfoEntity
    {
       public string UserID { get; set; }
       public string UserName { get; set; }
       public string Password { get; set; }
       public string Usermail { get; set; }
       public string LocID { get; set; }
       public string Createdate { get; set; }
       public string UsersStatus { get; set; }
       //public string MailCount { get; set; }
    }
}
