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
  public partial  class InvDevicenameBLL
    {
      public object GetDevicenameRecord(object param)
      {
          object retObj = null;
          InvDevicenameDAL InvDeviceDAL = new InvDevicenameDAL();
          retObj = (object)InvDeviceDAL.GetDevicenameRecord(param);
          return retObj;
      }
      public object SaveDeviceInfo(object param)
      {
          Database db = DatabaseFactory.CreateDatabase();
          object retObj = null;
          using (DbConnection connection = db.CreateConnection())
          {
              connection.Open();
              DbTransaction transaction = connection.BeginTransaction();
              try
              {
                  InvDevicenameEntity DeviceEntity = (InvDevicenameEntity)param;
                  InvDevicenameDAL InvdeviceDAL = new InvDevicenameDAL();
                  retObj = (object)InvdeviceDAL.SaveDeviceInfo(DeviceEntity, db, transaction);
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
      public object UpdateDeviceInfo(object param)
      {
          Database db = DatabaseFactory.CreateDatabase();
          object retObj = null;
          using (DbConnection connection = db.CreateConnection())
          {
              connection.Open();
              DbTransaction transaction = connection.BeginTransaction();
              try
              {
                  InvDevicenameEntity DeviceEntity = (InvDevicenameEntity)param;
                  InvDevicenameDAL InvdeviceDAL = new InvDevicenameDAL();
                  retObj = (object)InvdeviceDAL.UpdateDeviceInfo(DeviceEntity, db, transaction);
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
      public object GetDupdevicename(object param)
      {
          object retObj = null;
          string DUPDevice = param.ToString();
          InvDevicenameDAL InvdeviceDAL = new InvDevicenameDAL();
          retObj = (object)InvdeviceDAL.GetDupdevicename(DUPDevice, param);
          return retObj;
      }
    }
}
