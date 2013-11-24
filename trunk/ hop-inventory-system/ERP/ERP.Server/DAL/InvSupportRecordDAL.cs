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
   public class InvSupportRecordDAL
    {
       public DataTable GetCountryRecord(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT CID, Name, Description FROM ITInventory.dbo.INV_Country ORDER BY Name ASC";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }
       public bool SaveCountryInfo(InvCountryinfoEntity CountryEntity, Database db, DbTransaction transaction)
       {
           string sql = "INSERT INTO ITInventory.dbo.INV_Country ( Name, Description) VALUES (  @Name,  @Description )";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);

           db.AddInParameter(dbCommand, "Name", DbType.String, CountryEntity.Name);
           db.AddInParameter(dbCommand, "Description", DbType.String, CountryEntity.Description);

           db.ExecuteNonQuery(dbCommand, transaction);
           return true;
       }
       public bool UpdateCountryInfo(InvCountryinfoEntity CountryEntity, Database db, DbTransaction transaction)
       {
           string sql = "UPDATE INV_Country SET Name=@Name, Description=@Description WHERE CID=@CID";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           db.AddInParameter(dbCommand, "CID", DbType.String, CountryEntity.CID);
           db.AddInParameter(dbCommand, "Name", DbType.String, CountryEntity.Name);
           db.AddInParameter(dbCommand, "Description", DbType.String, CountryEntity.Description);

           db.ExecuteNonQuery(dbCommand, transaction);
           return true;
       }
       public DataTable GetDupCountry(string DUPCountry, object param)
       {
           Database db = DatabaseFactory.CreateDatabase();

           //string sql = "SELECT COUNT(Usermail) as MailCount FROM ITInventory.dbo.Login_info GROUP BY Usermail HAVING COUNT(Usermail)>=1";
           string sql = "SELECT Name  FROM ITInventory.dbo.INV_Country where Name like '%" + DUPCountry + "%'";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           //db.AddInParameter(dbCommand, "Usermail", DbType.String, UserEntity.Usermail);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }
       public DataTable GetAllCountryRecord(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT CID, Name FROM ITInventory.dbo.INV_Country ORDER BY Name ASC";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }


       public DataTable GetUnitRecord(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT UnitID, UnitName, Description FROM ITInventory.dbo.INV_Unitentry ORDER BY UnitName ASC";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }
       public bool SaveUnitInfo(InvUnitinfoEntity UnitEntity, Database db, DbTransaction transaction)
       {
           string sql = "INSERT INTO ITInventory.dbo.INV_Unitentry ( UnitName, Description) VALUES (  @UnitName,  @Description )";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);

           db.AddInParameter(dbCommand, "UnitName", DbType.String, UnitEntity.UnitName);
           db.AddInParameter(dbCommand, "Description", DbType.String, UnitEntity.Description);

           db.ExecuteNonQuery(dbCommand, transaction);
           return true;
       }
       public bool UpdateUnitInfo(InvUnitinfoEntity UnitEntity, Database db, DbTransaction transaction)
       {
           string sql = "UPDATE INV_Unitentry SET UnitName=@UnitName, Description=@Description WHERE UnitID=@UnitID";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           db.AddInParameter(dbCommand, "UnitID", DbType.String, UnitEntity.UnitID);
           db.AddInParameter(dbCommand, "UnitName", DbType.String, UnitEntity.UnitName);
           db.AddInParameter(dbCommand, "Description", DbType.String, UnitEntity.Description);

           db.ExecuteNonQuery(dbCommand, transaction);
           return true;
       }
       public DataTable GetDupUnit(string DUPUnit, object param)
       {
           Database db = DatabaseFactory.CreateDatabase();

           //string sql = "SELECT COUNT(Usermail) as MailCount FROM ITInventory.dbo.Login_info GROUP BY Usermail HAVING COUNT(Usermail)>=1";
           string sql = "SELECT UnitName  FROM ITInventory.dbo.INV_Unitentry where UnitName like '%" + DUPUnit + "%'";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           //db.AddInParameter(dbCommand, "Usermail", DbType.String, UserEntity.Usermail);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }
       public DataTable GetAllUnit(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT UnitID, UnitName FROM ITInventory.dbo.INV_Unitentry ORDER BY UnitName ASC";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }
       public DataTable GetAllBuildinginfo(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT [BNID], [BuildingName], [LocID], [Description] FROM [ITInventory].[dbo].[INV_Buildinginfo]  ORDER BY BuildingName ASC";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }

       public DataTable GetBuildinginfoRecord(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT [BNID], [BuildingName], [LocID], [Description]   FROM [ITInventory].[dbo].[INV_Buildinginfo] ORDER BY BuildingName ASC";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }
       public bool SaveBuildingInfo(InvBuilinginfoEntity BEntity, Database db, DbTransaction transaction)
       {
           string sql = "INSERT INTO ITInventory.dbo.INV_Buildinginfo (LocID, BuildingName, Description) VALUES (@LocID,  @BuildingName,  @Description )";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);

           db.AddInParameter(dbCommand, "LocID", DbType.String, BEntity.LocID);
           db.AddInParameter(dbCommand, "BuildingName", DbType.String, BEntity.BuildingName);
           db.AddInParameter(dbCommand, "Description", DbType.String, BEntity.Description);

           db.ExecuteNonQuery(dbCommand, transaction);
           return true;
       }
       public bool UpdateBuildingInfo(InvBuilinginfoEntity BEntity, Database db, DbTransaction transaction)
       {
           string sql = "UPDATE ITInventory.dbo.INV_Buildinginfo SET LocID=@LocID, BuildingName=@BuildingName, Description=@Description WHERE BNID=@BNID";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);

           db.AddInParameter(dbCommand, "BNID", DbType.String, BEntity.BNID);
           db.AddInParameter(dbCommand, "LocID", DbType.String, BEntity.LocID);
           db.AddInParameter(dbCommand, "BuildingName", DbType.String, BEntity.BuildingName);
           db.AddInParameter(dbCommand, "Description", DbType.String, BEntity.Description);

           db.ExecuteNonQuery(dbCommand, transaction);
           return true;
       }
       public DataTable GetDupBuilding(string BDUP, object param)
       {
           Database db = DatabaseFactory.CreateDatabase();

           //string sql = "SELECT COUNT(Usermail) as MailCount FROM ITInventory.dbo.Login_info GROUP BY Usermail HAVING COUNT(Usermail)>=1";
           string sql = "SELECT [LocID], [BuildingName]  FROM [ITInventory].[dbo].[INV_Buildinginfo] where BuildingName like '%" + BDUP + "%'";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           //db.AddInParameter(dbCommand, "Usermail", DbType.String, UserEntity.Usermail);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }

       public DataTable GetFloorinfofoRecord(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT [FID], [FloorName], [BNID]  FROM [ITInventory].[dbo].[INV_Floorinfo] ORDER BY FloorName ASC";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }
       public bool SaveFloorRecord(InvFloorinfoEntity fEntity, Database db, DbTransaction transaction)
       {
           string sql = "INSERT INTO [ITInventory].[dbo].[INV_Floorinfo] ( BNID, FloorName) VALUES (  @BNID,  @FloorName )";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);

           db.AddInParameter(dbCommand, "BNID", DbType.String, fEntity.BNID);
           db.AddInParameter(dbCommand, "FloorName", DbType.String, fEntity.FloorName);

           db.ExecuteNonQuery(dbCommand, transaction);
           return true;
       }
       public bool UpdateFloorRecord(InvFloorinfoEntity fEntity, Database db, DbTransaction transaction)
       {
           string sql = "UPDATE [ITInventory].[dbo].[INV_Floorinfo] SET BNID=@BNID, FloorName=@FloorName  WHERE FID=@FID";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);

           db.AddInParameter(dbCommand, "FID", DbType.String, fEntity.FID);
           db.AddInParameter(dbCommand, "BNID", DbType.String, fEntity.BNID);
           db.AddInParameter(dbCommand, "FloorName", DbType.String, fEntity.FloorName);

           db.ExecuteNonQuery(dbCommand, transaction);
           return true;
       }
       public DataTable GetAllFloorinfo(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT [FID], [FloorName]  FROM [ITInventory].[dbo].[INV_Floorinfo] ORDER BY FloorName ASC";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }      
       public DataTable GetAllGetFloorByBNID(object param)
       {
           InvBuilinginfoEntity obj = (InvBuilinginfoEntity)param;
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT A.[FID], A.[FloorName] FROM [ITInventory].[dbo].[INV_Floorinfo] AS A, [ITInventory].[dbo].[INV_Buildinginfo] AS B WHERE A.BNID=B.BNID AND A.BNID='" + obj.BNID + "'  ORDER BY A.[FloorName] ASC";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }

       public DataTable GetLineinfofoRecord(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT [LID], [LineName], [FID]  FROM [ITInventory].[dbo].[INV_Lineinfo] ORDER BY LineName ASC";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }
       public bool SaveLineRecord(InvLineinfoEntity lEntity, Database db, DbTransaction transaction)
       {
           string sql = "INSERT INTO [ITInventory].[dbo].[INV_Lineinfo] ( FID, LineName) VALUES (  @FID,  @LineName )";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);

           db.AddInParameter(dbCommand, "FID", DbType.String, lEntity.FID);
           db.AddInParameter(dbCommand, "LineName", DbType.String, lEntity.LineName);

           db.ExecuteNonQuery(dbCommand, transaction);
           return true;
       }
       public bool UpdateLineRecord(InvLineinfoEntity lEntity, Database db, DbTransaction transaction)
       {
           string sql = "UPDATE [ITInventory].[dbo].[INV_Lineinfo] SET FID=@FID, LineName=@LineName  WHERE LID=@LID";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);

           db.AddInParameter(dbCommand, "LID", DbType.String, lEntity.LID);
           db.AddInParameter(dbCommand, "FID", DbType.String, lEntity.FID);
           db.AddInParameter(dbCommand, "LineName", DbType.String, lEntity.LineName);

           db.ExecuteNonQuery(dbCommand, transaction);
           return true;
       }
       public DataTable GetAllLineinfo(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT [LID], [LineName]  FROM [ITInventory].[dbo].[INV_Lineinfo] ORDER BY LineName ASC";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }

       public DataTable GetMachineinfofoRecord(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT [MNID], [MachineName], [Description]  FROM [ITInventory].[dbo].[INV_Machineinfo] ORDER BY MachineName ASC";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }
       public bool SaveMachineInfo(InvMachineinfoEntity mEntity, Database db, DbTransaction transaction)
       {
           string sql = "INSERT INTO [ITInventory].[dbo].[INV_Machineinfo] ( MachineName, Description) VALUES (  @MachineName,  @Description )";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);

           db.AddInParameter(dbCommand, "MachineName", DbType.String, mEntity.MachineName);
           db.AddInParameter(dbCommand, "Description", DbType.String, mEntity.Description);

           db.ExecuteNonQuery(dbCommand, transaction);
           return true;
       }
       public bool UpdateMachineInfo(InvMachineinfoEntity mEntity, Database db, DbTransaction transaction)
       {
           string sql = "UPDATE [ITInventory].[dbo].[INV_Machineinfo] SET MachineName=@MachineName, Description=@Description  WHERE MNID=@MNID";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);

           db.AddInParameter(dbCommand, "MNID", DbType.String, mEntity.MNID);
           db.AddInParameter(dbCommand, "MachineName", DbType.String, mEntity.MachineName);
           db.AddInParameter(dbCommand, "Description", DbType.String, mEntity.Description);

           db.ExecuteNonQuery(dbCommand, transaction);
           return true;
       }
       public DataTable GetAllMachineinfo(object param)
       {
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT [MNID], [MachineName]  FROM [ITInventory].[dbo].[INV_Machineinfo] ORDER BY MachineName ASC";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }
       public DataTable GetMachinedetail(object param)
       {
           InvMachineinfoEntity obj = (InvMachineinfoEntity)param;
           Database db = DatabaseFactory.CreateDatabase();
           string sql = "SELECT [MNID], [Description]  FROM [ITInventory].[dbo].[INV_Machineinfo] WHERE MNID='" + obj.MNID + "' ";
           DbCommand dbCommand = db.GetSqlStringCommand(sql);
           DataSet ds = db.ExecuteDataSet(dbCommand);
           return ds.Tables[0];
       }

    }
}
