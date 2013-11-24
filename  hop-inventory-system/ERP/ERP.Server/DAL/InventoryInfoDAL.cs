using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using ERP.Domain.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERP.Server.DAL
{
   public partial class InventoryInfoDAL
    {


       public bool SaveInventoryInfo(InventoryModel InvenModel, Database db, DbTransaction transaction)
        {
            string sql = "INSERT INTO HL_InventoryInfo ( AccCode, BrandModel, Configuration, Category, SerialNo, Location, UserName, PurchDate, Remark, MonitorSLNO, UpsSLNO, DeptNo, Team, Status, HostName, ITemNo ) VALUES (  @AccCode, @BrandModel, @Configuration, @Category, @SerialNo, @Location, @UserName, @PurchDate, @Remark, @MonitorSLNO, @UpsSLNO, @DeptNo, @Team, @Status, @HostName, @ITemNo )";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);

            //db.AddInParameter(dbCommand, "AccID", DbType.String, InvenModel.AccID);
            db.AddInParameter(dbCommand, "AccCode", DbType.String, InvenModel.AccCode);
            db.AddInParameter(dbCommand, "BrandModel", DbType.String, InvenModel.BrandModel);
            db.AddInParameter(dbCommand, "Configuration", DbType.String, InvenModel.Configuration);
            db.AddInParameter(dbCommand, "Category", DbType.String, InvenModel.Category);
            db.AddInParameter(dbCommand, "SerialNo", DbType.String, InvenModel.SerialNo);
            db.AddInParameter(dbCommand, "Location", DbType.String, InvenModel.Location);
            db.AddInParameter(dbCommand, "UserName", DbType.String, InvenModel.UserName);
            db.AddInParameter(dbCommand, "PurchDate", DbType.String, InvenModel.PurchDate);
            db.AddInParameter(dbCommand, "Remark", DbType.String, InvenModel.Remark);
            db.AddInParameter(dbCommand, "MonitorSLNO", DbType.String, InvenModel.MonitorSLNO);
            db.AddInParameter(dbCommand, "UpsSLNO", DbType.String, InvenModel.UpsSLNO);
            db.AddInParameter(dbCommand, "DeptNo", DbType.String, InvenModel.DeptNo);
            db.AddInParameter(dbCommand, "Team", DbType.String, InvenModel.Team);
            db.AddInParameter(dbCommand, "Status", DbType.String, InvenModel.Status);
            db.AddInParameter(dbCommand, "HostName", DbType.String, InvenModel.HostName);
            db.AddInParameter(dbCommand, "ITemNo", DbType.String, InvenModel.ITemNo);

            db.ExecuteNonQuery(dbCommand, transaction);
            return true;
        }

       public bool UpdateInventoryInfo(InventoryModel InvenModel, Database db, DbTransaction transaction)
        {
            string sql = "UPDATE HL_InventoryInfo SET AccCode= @AccCode, BrandModel= @BrandModel, Configuration= @Configuration, Category= @Category, SerialNo= @SerialNo, Location= @Location, UserName= @UserName, PurchDate= @PurchDate, Remark= @Remark, MonitorSLNO= @MonitorSLNO, UpsSLNO= @UpsSLNO, DeptNo=@DeptNo, Team=@Team, Status=@Status, HostName=@HostName, ITemNo=@ITemNo   WHERE AccID=@AccID";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);

            db.AddInParameter(dbCommand, "AccID", DbType.String, InvenModel.AccID);
            db.AddInParameter(dbCommand, "AccCode", DbType.String, InvenModel.AccCode);
            db.AddInParameter(dbCommand, "BrandModel", DbType.String, InvenModel.BrandModel);
            db.AddInParameter(dbCommand, "Configuration", DbType.String, InvenModel.Configuration);
            db.AddInParameter(dbCommand, "Category", DbType.String, InvenModel.Category);
            db.AddInParameter(dbCommand, "SerialNo", DbType.String, InvenModel.SerialNo);
            db.AddInParameter(dbCommand, "Location", DbType.String, InvenModel.Location);
            db.AddInParameter(dbCommand, "UserName", DbType.String, InvenModel.UserName);
            db.AddInParameter(dbCommand, "PurchDate", DbType.String, InvenModel.PurchDate);
            db.AddInParameter(dbCommand, "Remark", DbType.String, InvenModel.Remark);
            db.AddInParameter(dbCommand, "MonitorSLNO", DbType.String, InvenModel.MonitorSLNO);
            db.AddInParameter(dbCommand, "UpsSLNO", DbType.String, InvenModel.UpsSLNO);
            db.AddInParameter(dbCommand, "DeptNo", DbType.String, InvenModel.DeptNo);
            db.AddInParameter(dbCommand, "Team", DbType.String, InvenModel.Team);
            db.AddInParameter(dbCommand, "Status", DbType.String, InvenModel.Status);
            db.AddInParameter(dbCommand, "HostName", DbType.String, InvenModel.HostName);
            db.AddInParameter(dbCommand, "ITemNo", DbType.String, InvenModel.ITemNo);

            db.ExecuteNonQuery(dbCommand, transaction);
            return true;
        }

       public bool DeleteInventoryInfoById(object param, Database db, DbTransaction transaction)
        {
            string sql = "DELETE FROM HL_InventoryInfo WHERE AccID=@AccID";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "AccID", DbType.String, param);

            db.ExecuteNonQuery(dbCommand, transaction);
            return true;
        }

       public InventoryModel GetSingleInventoryInfoRecordById(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sql = "SELECT AccID, AccCode, BrandModel, GovFee, ServiceFee, OthersFee, FixedFigure, CC, Sit, UserID, EnterDate, UpdateDate FROM TR_ServiceDetails WHERE Id=@Id";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "Id", DbType.String, param);
            InventoryModel InvenModel = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    InvenModel = new InventoryModel();
                    if (dataReader["AccID"] != DBNull.Value)
                    {
                        InvenModel.AccID = dataReader["AccID"].ToString();
                    }
                    if (dataReader["AccCode"] != DBNull.Value)
                    {
                        InvenModel.AccCode = dataReader["AccCode"].ToString();
                    }
                    if (dataReader["BrandModel"] != DBNull.Value)
                    {
                        InvenModel.BrandModel = dataReader["BrandModel"].ToString();
                    }
                    if (dataReader["Configuration"] != DBNull.Value)
                    {
                        InvenModel.Configuration = dataReader["Configuration"].ToString();
                    }
                    if (dataReader["Category"] != DBNull.Value)
                    {
                        InvenModel.Category = dataReader["Category"].ToString();
                    }
                    if (dataReader["SerialNo"] != DBNull.Value)
                    {
                        InvenModel.SerialNo = dataReader["SerialNo"].ToString();
                    }
                    if (dataReader["Location"] != DBNull.Value)
                    {
                        InvenModel.Location = dataReader["Location"].ToString();
                    }
                    if (dataReader["UserName"] != DBNull.Value)
                    {
                        InvenModel.UserName = dataReader["UserName"].ToString();
                    }
                    if (dataReader["PurchDate"] != DBNull.Value)
                    {
                        InvenModel.PurchDate = dataReader["PurchDate"].ToString();
                    }
                    if (dataReader["Remark"] != DBNull.Value)
                    {
                        InvenModel.Remark = dataReader["Remark"].ToString();
                    }
                    if (dataReader["MonitorSLNO"] != DBNull.Value)
                    {
                        InvenModel.MonitorSLNO = dataReader["MonitorSLNO"].ToString();
                    }
                    if (dataReader["UpsSLNO"] != DBNull.Value)
                    {
                        InvenModel.UpsSLNO = dataReader["UpsSLNO"].ToString();
                    }
                    if (dataReader["DeptNo"] != DBNull.Value)
                    {
                        InvenModel.DeptNo = dataReader["DeptNo"].ToString();
                    }
                    if (dataReader["Team"] != DBNull.Value)
                    {
                        InvenModel.Team = dataReader["Team"].ToString();
                    }
                    if (dataReader["Status"] != DBNull.Value)
                    {
                        InvenModel.Status = dataReader["Status"].ToString();
                    }
                    if (dataReader["HostName"] != DBNull.Value)
                    {
                        InvenModel.HostName = dataReader["HostName"].ToString();
                    }
                    if (dataReader["ITemNo"] != DBNull.Value)
                    {
                        InvenModel.ITemNo = dataReader["ITemNo"].ToString();
                    }
                }
            }
            return InvenModel;
        }

       public DataTable GetAllInventoryInfoRecord(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sql = "SELECT AccID, AccCode, BrandModel, Configuration, Category, SerialNo, Location, UserName, PurchDate, Remark, MonitorSLNO, UpsSLNO, DeptNo, Team, Status, HostName, ITemNo FROM HL_InventoryInfo";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }
    }
}
