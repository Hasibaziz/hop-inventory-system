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
   public partial class InvEmployeeinfoBLL
    {
        public object GetEmployeeInfoRecord(object param)
        {
            object retObj = null;
            InvEmployeeinfoDAL InvEmpDAL = new InvEmployeeinfoDAL();
            retObj = (object)InvEmpDAL.GetEmployeeinfoRecord(param);
            return retObj;
        }
        public object GetEmployeeInfo(object param)
        {
            object retObj = null;
            InvEmployeeinfoDAL InvEmpDAL = new InvEmployeeinfoDAL();
            retObj = (object)InvEmpDAL.GetEmployeeinfo(param);
            return retObj;
        }
        public object SaveEmployeeInfo(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            object retObj = null;
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    EmployeeinfoEntity EmpEntity = (EmployeeinfoEntity)param;
                    InvEmployeeinfoDAL InvEmpDAL = new InvEmployeeinfoDAL();
                    retObj = (object)InvEmpDAL.SaveEmployeeinfo(EmpEntity, db, transaction);
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
        public object DeleteEmployeeInfoById(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            object retObj = null;
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    InvEmployeeinfoDAL EmpDAL = new InvEmployeeinfoDAL();
                    retObj = (object)EmpDAL.DeleteEmployeeInfoById(param, db, transaction);
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
        public object GetDuplicateEMP(object param)
        {
            object retObj = null;
            string DUPEMP = param.ToString();
            InvEmployeeinfoDAL empctrDAL = new InvEmployeeinfoDAL();           
            retObj = (object)empctrDAL.GetDuplicateEMP(DUPEMP, param);
            return retObj;
        }
        public object GetLocationInfo(object param)
        {
            object retObj = null;
            InvEmployeeinfoDAL InvEmpDAL = new InvEmployeeinfoDAL();
            //Invlocation obj = (Invlocation)param;
            retObj = (object)InvEmpDAL.GetLocationInfo(param);
            return retObj;
        }
        public object GetAllLocationByCID(object param)
        {
            object retObj = null;
            InvEmployeeinfoDAL InvEmpDAL = new InvEmployeeinfoDAL();
            //Invlocation obj = (Invlocation)param;
            retObj = (object)InvEmpDAL.GetAllLocationByCID(param);
            return retObj;
        }
        public object GetAllBuildingByCID(object param)
        {
            object retObj = null;
            InvEmployeeinfoDAL InvEmpDAL = new InvEmployeeinfoDAL();
            //Invlocation obj = (Invlocation)param;
            retObj = (object)InvEmpDAL.GetAllBuildingByCID(param);
            return retObj;
        }
    }
}
