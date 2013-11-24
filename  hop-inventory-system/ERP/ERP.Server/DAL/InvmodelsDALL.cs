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
    public partial class InvmodelsDALL
    {
        public DataTable GetModelsListRecord(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sql = "SELECT [ModelID], [ItemID], [ModelName], [ModelDate], [EXDate], [TPage], [Description] FROM [ITInventory].[dbo].[INV_Models]";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }
        public bool SaveInvmodelsRecord(InvmodelEntity InvmodelEntity, Database db, DbTransaction transaction)
        {
            string sql = "INSERT INTO INV_Models (ItemID, ModelName, ModelDate, EXDate, TPage, Description) VALUES (@ItemID, @ModelName, @ModelDate, @EXDate, @TPage, @Description )";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);

            db.AddInParameter(dbCommand, "ItemID", DbType.String, InvmodelEntity.ItemID);
            db.AddInParameter(dbCommand, "ModelName", DbType.String, InvmodelEntity.ModelName);
            db.AddInParameter(dbCommand, "ModelDate", DbType.String, InvmodelEntity.ModelDate);
            db.AddInParameter(dbCommand, "EXDate", DbType.String, InvmodelEntity.EXDate);
            db.AddInParameter(dbCommand, "TPage", DbType.String, InvmodelEntity.TPage);
            db.AddInParameter(dbCommand, "Description", DbType.String, InvmodelEntity.Description);


            db.ExecuteNonQuery(dbCommand, transaction);
            return true;
        }
        public bool UpdateInvmodelsRecord(InvmodelEntity InvmodelEntity, Database db, DbTransaction transaction)
        {
            string sql = "UPDATE INV_Models SET ItemID= @ItemID, ModelName=@ModelName, ModelDate=@ModelDate, EXDate=@EXDate, TPage=@TPage, Description= @Description WHERE ModelID=@ModelID";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "ModelID", DbType.String, InvmodelEntity.ModelID);
            db.AddInParameter(dbCommand, "ItemID", DbType.String, InvmodelEntity.ItemID);
            db.AddInParameter(dbCommand, "ModelName", DbType.String, InvmodelEntity.ModelName);
            db.AddInParameter(dbCommand, "ModelDate", DbType.String, InvmodelEntity.ModelDate);
            db.AddInParameter(dbCommand, "EXDate", DbType.String, InvmodelEntity.EXDate);
            db.AddInParameter(dbCommand, "TPage", DbType.String, InvmodelEntity.TPage);
            db.AddInParameter(dbCommand, "Description", DbType.String, InvmodelEntity.Description);

            db.ExecuteNonQuery(dbCommand, transaction);
            return true;
        }
        public bool DeleteInvmodelsRecordById(object param, Database db, DbTransaction transaction)
        {
            string sql = "DELETE FROM INV_Models WHERE ModelID=@ModelID";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "ModelID", DbType.String, param);

            db.ExecuteNonQuery(dbCommand, transaction);
            return true;
        }
        public DataTable GetmodelsById(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            //string sql = "SELECT EmpID, EmpNo, EmpName, DeptID, Location, JoinDate FROM ITInventory.dbo.INV_EmployeeInfo ORDER BY EmpNo ASC";
            string sql = "SELECT [ModelID], [ItemID], [ModelName], [ModelDate], [EXDate], [TPage], [Description] FROM [ITInventory].[dbo].[INV_Models]";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }
        public DataTable Getitemmodel(object param)
        {           
            InvmodelEntity obj=(InvmodelEntity)param;
            Database db = DatabaseFactory.CreateDatabase();
            //string sql = "SELECT EmpID, EmpNo, EmpName, DeptID, Location, JoinDate FROM ITInventory.dbo.INV_EmployeeInfo ORDER BY EmpNo ASC";
            string sql = "SELECT [ModelID], [ModelName] FROM [ITInventory].[dbo].[INV_Models] WHERE [ItemID]='" + obj.ItemID + "'";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }
        
    }
}
