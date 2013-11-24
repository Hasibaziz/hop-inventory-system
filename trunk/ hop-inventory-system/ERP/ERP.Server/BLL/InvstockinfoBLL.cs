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
   public partial class InvstockinfoBLL
    {
       public object GetstockinfoListRecord(object param)
       {
           object retObj = null;
           InvstockinfoDAL STKDAL = new InvstockinfoDAL();
           retObj = (object)STKDAL.GetstockinfoListRecord(param);
           return retObj;
       }
       public object GetstockinfoRecordByDate(object param)
       {
           object retObj = null;
           InvstockinfoDAL STKDAL = new InvstockinfoDAL();
           InvallstockEntity obj = (InvallstockEntity)param;
           retObj = (object)STKDAL.GetstockinfoRecordByDate(obj, param);
           return retObj;
       }
       public object GetstockinfoexcelByDate(object param)
       {
           object retObj = null;
           InvstockinfoDAL STKDAL = new InvstockinfoDAL();
           retObj = (object)STKDAL.GetstockinfoexcelByDate(param);
           return retObj;
       }

       public object GetftystockinfoListRecord(object param)
       {
           object retObj = null;
           InvstockinfoDAL STKDAL = new InvstockinfoDAL();
           retObj = (object)STKDAL.GetftystockinfoListRecord(param);
           return retObj;
       }
       public object GetpassissueListRecord(object param)
       {
           object retObj = null;
           InvstockinfoDAL STKDAL = new InvstockinfoDAL();
           retObj = (object)STKDAL.GetpassissueListRecord(param);
           return retObj;
       }
       public object GetpassissueListRecordByDate(object param)
       {
           object retObj = null;
           InvstockinfoDAL STKDAL = new InvstockinfoDAL();
           retObj = (object)STKDAL.GetpassissueListRecordByDate(param);
           return retObj;
       }


       public object GetpassissueListRecordView(object param)
       {
           object retObj = null;
           InvstockinfoDAL STKDAL = new InvstockinfoDAL();
           retObj = (object)STKDAL.GetpassissueListRecordView(param);
           return retObj;
       }

    }
}
