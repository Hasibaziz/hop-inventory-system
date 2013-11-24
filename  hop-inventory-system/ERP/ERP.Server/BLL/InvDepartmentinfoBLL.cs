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
   public partial class InvDepartmentinfoBLL
    {
       public object GetDepartmentInfoRecord(object param)
       {
           object retObj = null;
           InvDepartmentinfoDAL InvDeptDAL = new InvDepartmentinfoDAL();
           retObj = (object)InvDeptDAL.GetDepartmentRecord(param);
           return retObj;
       }
       public object SaveDepartmentInfo(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           object retObj = null;
           using (DbConnection connection = db.CreateConnection())
           {
               connection.Open();
               DbTransaction transaction = connection.BeginTransaction();
               try
               {
                   InvDepartmentinfoEntity InvDeptEntity = (InvDepartmentinfoEntity)param;
                   InvDepartmentinfoDAL InvDeptDAL = new InvDepartmentinfoDAL();
                   retObj = (object)InvDeptDAL.SaveDepartmentinfo(InvDeptEntity, db, transaction);
                   transaction.Commit();
               }
               catch
               {
                   transaction.Rollback();
                   throw;
               }
               finally
               {
                   connection.Close();
               }
           }
           return retObj;
       }
       public object DeleteDepartmentInfoById(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           object retObj = null;
           using (DbConnection connection = db.CreateConnection())
           {
               connection.Open();
               DbTransaction transaction = connection.BeginTransaction();
               try
               {
                   InvDepartmentinfoDAL DeptDAL = new InvDepartmentinfoDAL();
                   retObj = (object)DeptDAL.DeleteDepartmentInfoById(param, db, transaction);
                   transaction.Commit();
               }
               catch
               {
                   transaction.Rollback();
                   throw;
               }
               finally
               {
                   connection.Close();
               }
           }
           return retObj;
       }

       public object GetDuplicatedept(object param)
       {
           object retObj = null;
           string DUPDEPT = param.ToString();
           InvDepartmentinfoDAL DeptctrDAL = new InvDepartmentinfoDAL();
           retObj = (object)DeptctrDAL.GetDuplicatedept(DUPDEPT, param);
           return retObj;
       }
    }
}
