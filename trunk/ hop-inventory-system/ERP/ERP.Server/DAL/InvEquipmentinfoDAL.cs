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
    public partial class InvEquipmentinfoDAL
    {
        public DataTable GetEquipmentinfoRecord(InvEquipmentEntity obj, object param)
        {
            //if ((obj.Location == "HLNT" && obj.Userstatus == "Normal") || (obj.Location == "HLBD" && obj.Userstatus == "Normal") || (obj.Location == "HLAP" && obj.Userstatus == "Normal"))
            //if (obj.Location == "HLNT" || obj.Location == "HLBD" || obj.Location == "HLAP")
            //{
            Database db = DatabaseFactory.CreateDatabase();
            string sql = "SELECT [EID],[LocID],[ENumber],[AccountCode],[AssetCode],[Brand],[Model],[Serialno],[Subserialno],[MNID],[Machineid],[Lifetime],[PurchDate],[UnitID],[BNID],[FID],[LID],[Status],[Remarks],[CID]";
            sql = sql + " FROM [ITInventory].[dbo].[Inv_Equipmentinfo] ";
            sql = sql + " ORDER BY ENumber ASC";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            //db.AddInParameter(dbCommand, "Location", DbType.String, obj.Location);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
            // }
            //else if ((obj.Location == "HLNT" && obj.Userstatus == "Normal") || (obj.Location == "HLBD" && obj.Userstatus == "Normal") || (obj.Location == "HLAP" && obj.Userstatus == "Normal"))
            //{
            //    Database db = DatabaseFactory.CreateDatabase();
            //    string STR = "22fc4927-cf7c-4e72-8575-2780eec97126";
            //    string sql = "SELECT A.Office, A.Proposed, A.AccountID, A.AccountCode, A.BrandModel, A.Category, A.Configuration, A.SerialNo, A.Location, A.DeptID, A.EMPID, A.EMPID AS EMPNAME, A.PurchDate, A.Remark, B.SerialNo AS MonitorID, C.SerialNo AS UPSID, A.Team, A.Status, A.HostName, A.ITemNo, A.DeviceID";
            //    sql = sql + " FROM ITInventory.dbo.INV_InventoryInfo as A LEFT OUTER JOIN";
            //    sql = sql + " ITInventory.dbo.INV_MonitorDetails AS B ON A.EMPID=B.EMPID";
            //    sql = sql + " LEFT OUTER JOIN ITInventory.dbo.INV_UPSDetails AS C ON A.EMPID=C.EMPID";
            //    sql = sql + " WHERE  A.DeviceID='" + STR + "' and A.Location=@Location";
            //    DbCommand dbCommand = db.GetSqlStringCommand(sql);
            //    db.AddInParameter(dbCommand, "Location", DbType.String, obj.Location);
            //    DataSet ds = db.ExecuteDataSet(dbCommand);
            //    return ds.Tables[0];
            //}
            //else
            //{
            //    Database db = DatabaseFactory.CreateDatabase();
            //    //string STR = "22fc4927-cf7c-4e72-8575-2780eec97126";
            //    //string sql = "SELECT ROW_NUMBER() OVER(ORDER BY AccountCode) SLNO, A.Office, A.Proposed, A.AccountID, A.AccountCode, A.BrandModel, A.Category, A.Configuration, A.SerialNo, A.Location, A.DeptID, A.EMPID, A.EMPID AS EMPNAME, A.PurchDate, A.Remark, B.SerialNo AS MonitorID, C.SerialNo AS UPSID, A.Team, A.Status, A.HostName, A.ITemNo, A.DeviceID";
            //    string sql = "SELECT ENumber, A.Office, A.Proposed, A.AccountID, A.AccountCode, A.BrandModel, A.Category, A.Configuration, A.SerialNo, A.Location, A.DeptID, A.EMPID, A.EMPID AS EMPNAME, A.PurchDate, A.Remark, A.Team, A.Status, A.HostName, A.ITemNo, A.DeviceID";
            //    sql = sql + " FROM ITInventory.dbo.INV_InventoryInfo as A ";
            //    sql = sql + " WHERE  A.Location=LEFT(A.Location,4) ORDER BY A.EMPID ASC";
            //    DbCommand dbCommand = db.GetSqlStringCommand(sql);
            //    db.AddInParameter(dbCommand, "Location", DbType.String, obj.Location);
            //    DataSet ds = db.ExecuteDataSet(dbCommand);
            //    return ds.Tables[0];
            //}
        }
        public bool SaveEquipmentDetails(InvEquipmentEntity EQEntity, Database db, DbTransaction transaction)
        {

            string sql = "INSERT INTO ITInventory.dbo.Inv_Equipmentinfo ([LocID],[ENumber],[AccountCode],[AssetCode],[Brand],[Model],[Serialno],[Subserialno],[MNID],[Machineid],[Lifetime],[PurchDate],[UnitID],[BNID],[FID],[LID],[Status],[Remarks],[CID]) VALUES (@LocID, @ENumber, @AccountCode, @AssetCode, @Brand, @Model, @Serialno, @Subserialno, @MNID, @Machineid, @Lifetime, @PurchDate, @UnitID, @BNID, @FID, @LID, @Status, @Remarks, @CID )";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);

            db.AddInParameter(dbCommand, "LocID", DbType.String, EQEntity.LocID);
            db.AddInParameter(dbCommand, "ENumber", DbType.String, EQEntity.ENumber);
            db.AddInParameter(dbCommand, "AccountCode", DbType.String, EQEntity.AccountCode);
            db.AddInParameter(dbCommand, "AssetCode", DbType.String, EQEntity.AssetCode);
            db.AddInParameter(dbCommand, "Brand", DbType.String, EQEntity.Brand);
            db.AddInParameter(dbCommand, "Model", DbType.String, EQEntity.Model);
            db.AddInParameter(dbCommand, "Serialno", DbType.String, EQEntity.Serialno);
            db.AddInParameter(dbCommand, "Subserialno", DbType.String, EQEntity.Subserialno);
            db.AddInParameter(dbCommand, "MNID", DbType.String, EQEntity.MNID);
            db.AddInParameter(dbCommand, "Machineid", DbType.String, EQEntity.Machineid);
            db.AddInParameter(dbCommand, "Lifetime", DbType.String, EQEntity.Lifetime);
            db.AddInParameter(dbCommand, "PurchDate", DbType.String, EQEntity.PurchDate);
            db.AddInParameter(dbCommand, "UnitID", DbType.String, EQEntity.UnitID);
            db.AddInParameter(dbCommand, "BNID", DbType.String, EQEntity.BNID);
            db.AddInParameter(dbCommand, "FID", DbType.String, EQEntity.FID);
            db.AddInParameter(dbCommand, "LID", DbType.String, EQEntity.LID);
            db.AddInParameter(dbCommand, "Status", DbType.String, EQEntity.Status);
            db.AddInParameter(dbCommand, "Remarks", DbType.String, EQEntity.Remarks);
            db.AddInParameter(dbCommand, "CID", DbType.String, EQEntity.CID);          

            db.ExecuteNonQuery(dbCommand, transaction);          
            return true;
        }
        public bool UpdateEquipmentDetails(InvEquipmentEntity EQEntity, Database db, DbTransaction transaction)
        {
            string sql = " UPDATE ITInventory.dbo.Inv_Equipmentinfo SET ENumber= @ENumber, Machineid= @Machineid, AccountCode=@AccountCode, BrandModel= @BrandModel, Type= @Type, Machineno= @Machineno, Lifetime= @Lifetime, LocID= @LocID, PurchDate=@PurchDate, UnitID= @UnitID,  CID= @CID,  Status= @Status WHERE EID=@EID";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);


            //db.AddInParameter(dbCommand, "ENumber", DbType.String, EQEntity.ENumber);
            //db.AddInParameter(dbCommand, "Machineid", DbType.String, EQEntity.Machineid);
            //db.AddInParameter(dbCommand, "AccountCode", DbType.String, EQEntity.AccountCode);
            //db.AddInParameter(dbCommand, "BrandModel", DbType.String, EQEntity.BrandModel);
            //db.AddInParameter(dbCommand, "Type", DbType.String, EQEntity.Type);
            //db.AddInParameter(dbCommand, "Machineno", DbType.String, EQEntity.Machineno);
            //db.AddInParameter(dbCommand, "Lifetime", DbType.String, EQEntity.Lifetime);
            //db.AddInParameter(dbCommand, "LocID", DbType.String, EQEntity.LocID);
            //db.AddInParameter(dbCommand, "PurchDate", DbType.String, EQEntity.PurchDate);
            //db.AddInParameter(dbCommand, "UnitID", DbType.String, EQEntity.UnitID);
            //db.AddInParameter(dbCommand, "Buildingno", DbType.String, EQEntity.Buildingno);
            //db.AddInParameter(dbCommand, "Floorno", DbType.String, EQEntity.Floorno);
            //db.AddInParameter(dbCommand, "Lineno", DbType.String, EQEntity.Lineno);
            //db.AddInParameter(dbCommand, "Status", DbType.String, EQEntity.Status); 
            //db.AddInParameter(dbCommand, "CID", DbType.String, EQEntity.CID);          

            db.ExecuteNonQuery(dbCommand, transaction);
           
            return true;
        }


        public DataTable GetAutonumber(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sql = "SELECT MAX(ENumber) as ENumber, B.Location FROM ITInventory.dbo.Inv_Equipmentinfo AS A, ITInventory.dbo.INV_Location AS B where A.LocID=b.LocID and A.LocID=@LocID GROUP BY B.Location ";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "LocID", DbType.String, param.ToString());
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }

        public DataTable GetAllENUMBERList(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sql = "SELECT EID, ENumber FROM ITInventory.dbo.Inv_Equipmentinfo ORDER BY ENumber ASC";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }
    }
}
