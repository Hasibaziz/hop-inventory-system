using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Domain.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using ERP.Server.DAL;


namespace ERP.Server.BLL
{
    public partial class UpdateuserinfoBLL
    {
        public object GetUpdateuserinfoRecord(object param)
        {
            object retObj = null;
            UpdateuserinfoDAL UpduserDAL = new UpdateuserinfoDAL();
            //UpdateuserinfoEntity obj = (UpdateuserinfoEntity)param;
            retObj = (object)UpduserDAL.GetUpdateuserinfoRecord(param);
            return retObj;
        }
        public object GetUpdateusernameRecord(object param)
        {
            object retObj = null;
            UpdateuserinfoDAL UpduserDAL = new UpdateuserinfoDAL();
            //UpdateuserinfoEntity obj = (UpdateuserinfoEntity)param;
            retObj = (object)UpduserDAL.GetUpdateusernameRecord(param);
            return retObj;
        }
    }
}
