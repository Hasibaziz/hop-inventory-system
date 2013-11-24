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
  public partial  class InvstockinfoDAL
    {
      public DataTable GetstockinfoListRecord(object param)
      {
          Database db = DatabaseFactory.CreateDatabase();
          string sql = "SELECT SID, ItemID, ModelID, SDate, TOTALRQty, TOTALIQty, BalanceQty FROM ITInventory.dbo.INV_Stock ORDER BY convert(date,SDate,103) DESC";
          DbCommand dbCommand = db.GetSqlStringCommand(sql);
          DataSet ds = db.ExecuteDataSet(dbCommand);
          return ds.Tables[0];
      }
      public DataTable GetstockinfoRecordByDate( InvallstockEntity obj, object param)
      {
          Database db = DatabaseFactory.CreateDatabase();
          //string sql = "SELECT SID, ItemID, ModelID, SDate, TOTALRQty, TOTALIQty, BalanceQty FROM ITInventory.dbo.INV_Stock ";
          //sql =sql + " WHERE (SDate BETWEEN ('"+obj.StartDate+"') AND ('"+obj.EndDate+"'))";
          //sql =sql + " and ItemID='" + obj.ItemID + "' and ModelID='"+obj.ModelID+"'";
          //sql = sql + " ORDER BY convert(date, SDate,103) DESC";
          //DbCommand dbCommand = db.GetSqlStringCommand(sql);
          //DataSet ds = db.ExecuteDataSet(dbCommand);

          object[] parameters = new object[] { obj.StartDate, obj.EndDate, obj.ItemID, obj.ModelID };
          DbCommand dbCommand = db.GetStoredProcCommand("spGetstockinfoRecordByDate", parameters);
          DataSet ds = db.ExecuteDataSet(dbCommand);         
          return ds.Tables[0];
      }
      public DataTable GetstockinfoexcelByDate(object param)
      {
          InvallstockEntity obj = (InvallstockEntity)param;
          Database db = DatabaseFactory.CreateDatabase();
          string sql = "SELECT B.ItemName AS 'Item Name', C.ModelName AS 'Model Name', A.SDate as 'Date', A.TOTALRQty as 'Receive Qty', A.TOTALIQty as 'Issue Qty', A.BalanceQty as 'Balance Qty' FROM ITInventory.dbo.INV_Stock as A, ITInventory.dbo.INV_Items AS B, ITInventory.dbo.INV_Models AS C";
          sql = sql + " WHERE (A.ItemID=B.ItemID AND A.ModelID=C.ModelID) AND (A.SDate BETWEEN ('" + obj.StartDate + "') AND ('" + obj.EndDate + "'))";
          sql = sql + " and A.ItemID='" + obj.ItemID + "' and A.ModelID='" + obj.ModelID + "'";
          sql = sql + " ORDER BY convert(date, A.SDate,103) DESC";
          DbCommand dbCommand = db.GetSqlStringCommand(sql);
          DataSet ds = db.ExecuteDataSet(dbCommand);
          return ds.Tables[0];
      }

      public DataTable GetftystockinfoListRecord(object param)
      {
          InvftystockinfoEntity obj = (InvftystockinfoEntity)param;
          if ((obj.Location == "HLNT" && obj.Userstatus == "Normal") || (obj.Location == "HYBD" && obj.Userstatus == "Normal") || (obj.Location == "HLWF" && obj.Userstatus == "Normal") || (obj.Location == "HLAP" && obj.Userstatus == "Normal") || (obj.Location == "HLRC" && obj.Userstatus == "Normal") || (obj.Location == "HLST" && obj.Userstatus == "Normal"))
          {
              Database db = DatabaseFactory.CreateDatabase();
              string sql = "SELECT FSID, ItemID, ModelID, FSDate, TFSRQty, TFSIQty, LocID,  FSBalanceQty FROM ITInventory.dbo.INV_Factorystock ORDER BY FSDate, TFSIQty DESC";
              DbCommand dbCommand = db.GetSqlStringCommand(sql);
              DataSet ds = db.ExecuteDataSet(dbCommand);
              return ds.Tables[0];
          }
          else if ((obj.Location == "HLNT" && obj.Userstatus == "OPEX") || (obj.Location == "HYBD" && obj.Userstatus == "OPEX") || (obj.Location == "HLWF" && obj.Userstatus == "OPEX") || (obj.Location == "HLAP" && obj.Userstatus == "OPEX") || (obj.Location == "HLRC" && obj.Userstatus == "OPEX") || (obj.Location == "HLST" && obj.Userstatus == "OPEX"))
          {
              Database db = DatabaseFactory.CreateDatabase();
              string sql = "SELECT A.FSID, A.ItemID, A.ModelID, A.FSDate, A.TFSRQty, A.TFSIQty, A.LocID,  A.FSBalanceQty FROM ITInventory.dbo.INV_Factorystock as A, ITInventory.dbo.INV_Location as B WHERE (A.LocID=B.LocID and B.Location='" + obj.Location + "')ORDER BY A.FSDate, A.TFSIQty DESC";
              DbCommand dbCommand = db.GetSqlStringCommand(sql);
              DataSet ds = db.ExecuteDataSet(dbCommand);
              return ds.Tables[0];
          }
          else
          {
              Database db = DatabaseFactory.CreateDatabase();
              string sql = "SELECT FSID, ItemID, ModelID, FSDate, TFSRQty, TFSIQty, LocID,  FSBalanceQty FROM ITInventory.dbo.INV_Factorystock ORDER BY FSDate, TFSIQty DESC";
              DbCommand dbCommand = db.GetSqlStringCommand(sql);
              DataSet ds = db.ExecuteDataSet(dbCommand);
              return ds.Tables[0];
          }
      }
      public DataTable GetpassissueListRecord(object param)
      {
          InvgetpassissuereportEntity obj = (InvgetpassissuereportEntity)param;
          if ((obj.Location == "HLNT" && obj.Userstatus == "Normal") || (obj.Location == "HYBD" && obj.Userstatus == "Normal") || (obj.Location == "HLWF" && obj.Userstatus == "Normal") || (obj.Location == "HLAP" && obj.Userstatus == "Normal") || (obj.Location == "HLRC" && obj.Userstatus == "Normal") || (obj.Location == "HLST" && obj.Userstatus == "Normal"))
          {
              Database db = DatabaseFactory.CreateDatabase();
              string sql = "SELECT B.ItemName, C.ModelName, A.IssueDate, A.ReceiverName, D.Location, A.IssueQty FROM INV_ReceiveNissue as A, INV_Items as B, INV_Models as C, INV_Location as D WHERE A.ItemID=B.ItemID AND A.ModelID=C.ModelID AND A.LocID=D.LocID   ORDER BY convert(date,A.IssueDate,103) DESC";
              DbCommand dbCommand = db.GetSqlStringCommand(sql);
              DataSet ds = db.ExecuteDataSet(dbCommand);
              return ds.Tables[0];
          }
          else if ((obj.Location == "HLNT" && obj.Userstatus == "OPEX") || (obj.Location == "HYBD" && obj.Userstatus == "OPEX") || (obj.Location == "HLWF" && obj.Userstatus == "OPEX") || (obj.Location == "HLAP" && obj.Userstatus == "OPEX") || (obj.Location == "HLRC" && obj.Userstatus == "OPEX") || (obj.Location == "HLST" && obj.Userstatus == "OPEX"))
          {
              Database db = DatabaseFactory.CreateDatabase();
              string sql = "SELECT B.ItemName, C.ModelName, A.IssueDate, A.ReceiverName, D.Location, A.IssueQty FROM INV_ReceiveNissue as A, INV_Items as B, INV_Models as C, INV_Location as D WHERE A.ItemID=B.ItemID AND A.ModelID=C.ModelID AND (A.LocID=D.LocID and D.Location='" + obj.Location + "')  ORDER BY convert(date,A.IssueDate,103) DESC";
              DbCommand dbCommand = db.GetSqlStringCommand(sql);
              DataSet ds = db.ExecuteDataSet(dbCommand);
              return ds.Tables[0];
          }
          else
          {
              Database db = DatabaseFactory.CreateDatabase();
              string sql = "SELECT B.ItemName, C.ModelName, A.IssueDate, A.ReceiverName, D.Location, A.IssueQty FROM INV_ReceiveNissue as A, INV_Items as B, INV_Models as C, INV_Location as D WHERE A.ItemID=B.ItemID AND A.ModelID=C.ModelID AND A.LocID=D.LocID  ORDER BY convert(date, A.IssueDate,103) DESC";
              DbCommand dbCommand = db.GetSqlStringCommand(sql);
              DataSet ds = db.ExecuteDataSet(dbCommand);
              return ds.Tables[0];
          }
      }
      public DataTable GetpassissueListRecordByDate(object param)
      {
          InvgetpassissuereportEntity obj = (InvgetpassissuereportEntity)param;
          if ((obj.Location == "HLNT" && obj.Userstatus == "Normal") || (obj.Location == "HYBD" && obj.Userstatus == "Normal") || (obj.Location == "HLWF" && obj.Userstatus == "Normal") || (obj.Location == "HLAP" && obj.Userstatus == "Normal") || (obj.Location == "HLRC" && obj.Userstatus == "Normal") || (obj.Location == "HLST" && obj.Userstatus == "Normal"))
          {
              Database db = DatabaseFactory.CreateDatabase();
              string sql = "SELECT B.ItemName, C.ModelName, A.IssueDate, A.ReceiverName, D.Location, A.IssueQty FROM INV_ReceiveNissue as A, INV_Items as B, INV_Models as C, INV_Location as D WHERE A.ItemID=B.ItemID AND A.ModelID=C.ModelID AND A.LocID=D.LocID  and A.IssueDate='" + obj.IssueDate + "'  ORDER BY convert(date, A.IssueDate,103) DESC";
              DbCommand dbCommand = db.GetSqlStringCommand(sql);
              DataSet ds = db.ExecuteDataSet(dbCommand);
              return ds.Tables[0];
          }
          else if ((obj.Location == "HLNT" && obj.Userstatus == "OPEX") || (obj.Location == "HYBD" && obj.Userstatus == "OPEX") || (obj.Location == "HLWF" && obj.Userstatus == "OPEX") || (obj.Location == "HLAP" && obj.Userstatus == "OPEX") || (obj.Location == "HLRC" && obj.Userstatus == "OPEX") || (obj.Location == "HLST" && obj.Userstatus == "OPEX"))
          {
              Database db = DatabaseFactory.CreateDatabase();
              string sql = "SELECT B.ItemName, C.ModelName, A.IssueDate, A.ReceiverName, D.Location, A.IssueQty FROM INV_ReceiveNissue as A, INV_Items as B, INV_Models as C, INV_Location as D WHERE A.ItemID=B.ItemID AND A.ModelID=C.ModelID AND (A.LocID=D.LocID and D.Location='" + obj.Location + "') and A.IssueDate='" + obj.IssueDate + "'  ORDER BY convert(date,IssueDate,103) DESC";
              DbCommand dbCommand = db.GetSqlStringCommand(sql);
              DataSet ds = db.ExecuteDataSet(dbCommand);
              return ds.Tables[0];
          }
          else
          {
              Database db = DatabaseFactory.CreateDatabase();
              string sql = "SELECT B.ItemName, C.ModelName, A.IssueDate, A.ReceiverName, D.Location, A.IssueQty FROM INV_ReceiveNissue as A, INV_Items as B, INV_Models as C, INV_Location as D WHERE A.ItemID=B.ItemID AND A.ModelID=C.ModelID AND A.LocID=D.LocID and A.IssueDate='"+obj.IssueDate+"'  ORDER BY convert(date, A.IssueDate,103)  DESC";
              DbCommand dbCommand = db.GetSqlStringCommand(sql);
              DataSet ds = db.ExecuteDataSet(dbCommand);
              return ds.Tables[0];
          }
      }



      public DataTable GetpassissueListRecordView(object param)
      {
         // InvgetpassissuereportEntity obj = (InvgetpassissuereportEntity)param;
         
              Database db = DatabaseFactory.CreateDatabase();
              string sql = "SELECT B.ItemName, C.ModelName, A.IssueDate, A.ReceiverName, D.Location, A.IssueQty FROM INV_ReceiveNissue as A, INV_Items as B, INV_Models as C, INV_Location as D WHERE A.ItemID=B.ItemID AND A.ModelID=C.ModelID AND A.LocID=D.LocID ORDER BY convert(date, A.IssueDate,103)  DESC";
              DbCommand dbCommand = db.GetSqlStringCommand(sql);
              DataSet ds = db.ExecuteDataSet(dbCommand);
              return ds.Tables[0];
         }

    }
}
