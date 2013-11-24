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
   public class InvSupportRecordBLL
    {
       public object GetCountryRecord(object param)
       {
           object retObj = null;
           InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
           retObj = (object)SRDAL.GetCountryRecord(param);
           return retObj;
       }
       public object SaveCountryInfo(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           object retObj = null;
           using (DbConnection connection = db.CreateConnection())
           {
               connection.Open();
               DbTransaction transaction = connection.BeginTransaction();
               try
               {
                   InvCountryinfoEntity CountryEntity = (InvCountryinfoEntity)param;
                   InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
                   retObj = (object)SRDAL.SaveCountryInfo(CountryEntity, db, transaction);
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
       public object UpdateCountryInfo(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           object retObj = null;
           using (DbConnection connection = db.CreateConnection())
           {
               connection.Open();
               DbTransaction transaction = connection.BeginTransaction();
               try
               {
                   InvCountryinfoEntity CountryEntity = (InvCountryinfoEntity)param;
                   InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
                   retObj = (object)SRDAL.UpdateCountryInfo(CountryEntity, db, transaction);
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

       public object GetDupCountry(object param)
       {
           object retObj = null;
           string DUPCountry = param.ToString();
           InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
           retObj = (object)SRDAL.GetDupCountry(DUPCountry, param);
           return retObj;
       }
       public object GetAllCountryRecord(object param)
       {
           object retObj = null;
           InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
           retObj = (object)SRDAL.GetAllCountryRecord(param);
           return retObj;
       }

       public object GetUnitRecord(object param)
       {
           object retObj = null;
           InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
           retObj = (object)SRDAL.GetUnitRecord(param);
           return retObj;
       }
       public object SaveUnitInfo(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           object retObj = null;
           using (DbConnection connection = db.CreateConnection())
           {
               connection.Open();
               DbTransaction transaction = connection.BeginTransaction();
               try
               {
                   InvUnitinfoEntity UnitEntity = (InvUnitinfoEntity)param;
                   InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
                   retObj = (object)SRDAL.SaveUnitInfo(UnitEntity, db, transaction);
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
       public object UpdateUnitInfo(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           object retObj = null;
           using (DbConnection connection = db.CreateConnection())
           {
               connection.Open();
               DbTransaction transaction = connection.BeginTransaction();
               try
               {
                   InvUnitinfoEntity UnitEntity = (InvUnitinfoEntity)param;
                   InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
                   retObj = (object)SRDAL.UpdateUnitInfo(UnitEntity, db, transaction);
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

       public object GetDupUnit(object param)
       {
           object retObj = null;
           string DUPUnit = param.ToString();
           InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
           retObj = (object)SRDAL.GetDupUnit(DUPUnit, param);
           return retObj;
       }
       public object GetAllUnit(object param)
       {
           object retObj = null;
           InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
           retObj = (object)SRDAL.GetAllUnit(param);
           return retObj;
       }
       public object GetAllBuildinginfo(object param)
       {
           object retObj = null;
           InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
           retObj = (object)SRDAL.GetAllBuildinginfo(param);
           return retObj;
       }


       public object GetBuildinginfoRecord(object param)
       {
           object retObj = null;
           InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
           retObj = (object)SRDAL.GetBuildinginfoRecord(param);
           return retObj;
       }
       public object SaveBuildingInfo(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           object retObj = null;
           using (DbConnection connection = db.CreateConnection())
           {
               connection.Open();
               DbTransaction transaction = connection.BeginTransaction();
               try
               {
                   InvBuilinginfoEntity BuildingEntity = (InvBuilinginfoEntity)param;
                   InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
                   retObj = (object)SRDAL.SaveBuildingInfo(BuildingEntity, db, transaction);
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
       public object UpdateBuildingInfo(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           object retObj = null;
           using (DbConnection connection = db.CreateConnection())
           {
               connection.Open();
               DbTransaction transaction = connection.BeginTransaction();
               try
               {
                   InvBuilinginfoEntity BuildingEntity = (InvBuilinginfoEntity)param;
                   InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
                   retObj = (object)SRDAL.UpdateBuildingInfo(BuildingEntity, db, transaction);
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
       public object GetDupBuilding(object param)
       {
           object retObj = null;
           string DUPBuild = param.ToString();
           InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
           retObj = (object)SRDAL.GetDupBuilding(DUPBuild, param);
           return retObj;
       }

       public object GetFloorinfofoRecord(object param)
       {
           object retObj = null;
           InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
           retObj = (object)SRDAL.GetFloorinfofoRecord(param);
           return retObj;
       }
       public object SaveFloorRecord(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           object retObj = null;
           using (DbConnection connection = db.CreateConnection())
           {
               connection.Open();
               DbTransaction transaction = connection.BeginTransaction();
               try
               {
                   InvFloorinfoEntity FloorEntity = (InvFloorinfoEntity)param;
                   InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
                   retObj = (object)SRDAL.SaveFloorRecord(FloorEntity, db, transaction);
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
       public object UpdateFloorRecord(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           object retObj = null;
           using (DbConnection connection = db.CreateConnection())
           {
               connection.Open();
               DbTransaction transaction = connection.BeginTransaction();
               try
               {
                   InvFloorinfoEntity FloorEntity = (InvFloorinfoEntity)param;
                   InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
                   retObj = (object)SRDAL.UpdateFloorRecord(FloorEntity, db, transaction);
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
       public object GetAllFloorinfo(object param)
       {
           object retObj = null;
           InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
           retObj = (object)SRDAL.GetAllFloorinfo(param);
           return retObj;
       }
       public object GetAllGetFloorByBNID(object param)
       {
           object retObj = null;
           InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
           retObj = (object)SRDAL.GetAllGetFloorByBNID(param);
           return retObj;
       }

       public object GetLineinfofoRecord(object param)
       {
           object retObj = null;
           InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
           retObj = (object)SRDAL.GetLineinfofoRecord(param);
           return retObj;
       }
       public object SaveLineRecord(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           object retObj = null;
           using (DbConnection connection = db.CreateConnection())
           {
               connection.Open();
               DbTransaction transaction = connection.BeginTransaction();
               try
               {
                   InvLineinfoEntity LineEntity = (InvLineinfoEntity)param;
                   InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
                   retObj = (object)SRDAL.SaveLineRecord(LineEntity, db, transaction);
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
       public object UpdateLineRecord(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           object retObj = null;
           using (DbConnection connection = db.CreateConnection())
           {
               connection.Open();
               DbTransaction transaction = connection.BeginTransaction();
               try
               {
                   InvLineinfoEntity LineEntity = (InvLineinfoEntity)param;
                   InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
                   retObj = (object)SRDAL.UpdateLineRecord(LineEntity, db, transaction);
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
       public object GetAllLineinfo(object param)
       {
           object retObj = null;
           InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
           retObj = (object)SRDAL.GetAllLineinfo(param);
           return retObj;
       }

       public object GetMachineinfofoRecord(object param)
       {
           object retObj = null;
           InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
           retObj = (object)SRDAL.GetMachineinfofoRecord(param);
           return retObj;
       }
       public object SaveMachineInfo(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           object retObj = null;
           using (DbConnection connection = db.CreateConnection())
           {
               connection.Open();
               DbTransaction transaction = connection.BeginTransaction();
               try
               {
                   InvMachineinfoEntity mEntity = (InvMachineinfoEntity)param;
                   InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
                   retObj = (object)SRDAL.SaveMachineInfo(mEntity, db, transaction);
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
       public object UpdateMachineInfo(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           object retObj = null;
           using (DbConnection connection = db.CreateConnection())
           {
               connection.Open();
               DbTransaction transaction = connection.BeginTransaction();
               try
               {
                   InvMachineinfoEntity mEntity = (InvMachineinfoEntity)param;
                   InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
                   retObj = (object)SRDAL.UpdateMachineInfo(mEntity, db, transaction);
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
       public object GetAllMachineinfo(object param)
       {
           object retObj = null;
           InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
           retObj = (object)SRDAL.GetAllMachineinfo(param);
           return retObj;
       }
       public object GetMachinedetail(object param)
       {
           object retObj = null;
           InvSupportRecordDAL SRDAL = new InvSupportRecordDAL();
           retObj = (object)SRDAL.GetMachinedetail(param);
           return retObj;
       }
    }
}
