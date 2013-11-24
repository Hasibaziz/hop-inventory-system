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
    public partial class InvReceivenissueDAL
    {
        public DataTable GetReceiveissueRecord(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();           //Inventory/ReceiveissueList
            string sql = "SELECT [RIssueID],[ItemID],[ModelID],[ReceiveQty],[IssueDate],[ReceiverName], [ReceiverEmail], [Transportno],[LocID],[IssueQty],[BalanceQty] FROM [ITInventory].[dbo].[INV_ReceiveNissue] ORDER BY convert(date,IssueDate,103) DESC";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }
        public bool SaveReceiveissueRecord(InvreceivenissueEntity RIEntity, Database db, DbTransaction transaction)
        {
            //string sql = "INSERT INTO INV_ReceiveNissue ( ItemID, ModelID, ReceiveQty, IssueDate ,ReceiverName, ReceiverEmail, Transportno, LocID, IssueQty, BalanceQty ) VALUES ( @ItemID, @ModelID, @ReceiveQty, @IssueDate, @ReceiverName, @ReceiverEmail, @Transportno, @LocID, @IssueQty, @BalanceQty )";
            string sql = "IF (NOT EXISTS (SELECT * FROM INV_ReceiveNissue WHERE ModelID= @ModelID AND IssueDate=@IssueDate AND LocID= @LocID)) BEGIN  INSERT INTO INV_ReceiveNissue ( ItemID, ModelID, ReceiveQty, IssueDate ,ReceiverName, ReceiverEmail, Transportno, LocID, IssueQty, BalanceQty )  VALUES ( @ItemID, @ModelID, @ReceiveQty, @IssueDate, @ReceiverName, @ReceiverEmail, @Transportno, @LocID, @IssueQty, @BalanceQty ) END ELSE BEGIN   UPDATE INV_ReceiveNissue SET IssueQty=(SELECT IssueQty FROM INV_ReceiveNissue WHERE ModelID= @ModelID AND IssueDate=@IssueDate AND LocID= @LocID)+@IssueQty WHERE ModelID= @ModelID AND IssueDate=@IssueDate AND LocID= @LocID   END ";

            //string sql01 = "INSERT INTO INV_ItemIssue ( ItemID, ModelID, IDate , ReceiverName, LocID, IssueQty ) VALUES ( @ItemID, @ModelID, @IDate, @ReceiverName, @LocID, @IssueQty )";
            string sql01 = " IF (NOT EXISTS(SELECT * FROM ITInventory.dbo.INV_ItemIssue where  ModelID=@ModelID and  IDate=@IDate and LocID=@LocID)) BEGIN   INSERT INTO INV_ItemIssue ( ItemID, ModelID, IDate , ReceiverName, LocID, IssueQty ) VALUES ( @ItemID, @ModelID, @IDate, @ReceiverName, @LocID, @IssueQty )  END ELSE BEGIN  UPDATE ITInventory.dbo.INV_ItemIssue SET IssueQty=IssueQty+@IssueQty where ModelID=@ModelID and  IDate=@IDate and LocID=@LocID END ";

            //string sql02 = "INSERT INTO INV_FTYTransfer ( ItemID, IssueDate, LocID, IsReceive) VALUES ( @ItemID, @IssueDate, @LocID, 'False' )";
            string sql02 = "IF (NOT EXISTS(SELECT * FROM ITInventory.dbo.INV_FTYTransfer where IssueDate =@IssueDate and LocID=@LocID )) BEGIN     INSERT INTO ITInventory.dbo.INV_FTYTransfer ( ItemID, IssueDate, LocID, IsReceive) VALUES ( @ItemID, @IssueDate, @LocID, 'False' ) END ELSE BEGIN     UPDATE ITInventory.dbo.INV_FTYTransfer SET ItemID=@ItemID, IsReceive='False' where IssueDate=@IssueDate and LocID=@LocID END";

            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            DbCommand dbCommand01 = db.GetSqlStringCommand(sql01);
            DbCommand dbCommand02 = db.GetSqlStringCommand(sql02);

            db.AddInParameter(dbCommand, "ItemID", DbType.String, RIEntity.ItemID);
            db.AddInParameter(dbCommand, "ModelID", DbType.String, RIEntity.ModelID);
            db.AddInParameter(dbCommand, "ReceiveQty", DbType.String, RIEntity.ReceiveQty);
            db.AddInParameter(dbCommand, "IssueDate", DbType.String, RIEntity.IssueDate);
            db.AddInParameter(dbCommand, "ReceiverName", DbType.String, RIEntity.ReceiverName);
            db.AddInParameter(dbCommand, "ReceiverEmail", DbType.String, RIEntity.ReceiverEmail);
            db.AddInParameter(dbCommand, "Transportno", DbType.String, RIEntity.Transportno);
            db.AddInParameter(dbCommand, "LocID", DbType.String, RIEntity.LocID);
            db.AddInParameter(dbCommand, "IssueQty", DbType.String, RIEntity.IssueQty);
            db.AddInParameter(dbCommand, "BalanceQty", DbType.String, RIEntity.NewbalanceQty);

            db.AddInParameter(dbCommand01, "ItemID", DbType.String, RIEntity.ItemID);
            db.AddInParameter(dbCommand01, "ModelID", DbType.String, RIEntity.ModelID);
            db.AddInParameter(dbCommand01, "IDate", DbType.String, RIEntity.IssueDate);
            db.AddInParameter(dbCommand01, "ReceiverName", DbType.String, RIEntity.ReceiverName);
            db.AddInParameter(dbCommand01, "LocID", DbType.String, RIEntity.LocID);
            db.AddInParameter(dbCommand01, "IssueQty", DbType.String, RIEntity.IssueQty);

            db.AddInParameter(dbCommand02, "ItemID", DbType.String, RIEntity.ItemID);
            //db.AddInParameter(dbCommand02, "ModelID", DbType.String, RIEntity.ModelID);            
            db.AddInParameter(dbCommand02, "IssueDate", DbType.String, RIEntity.IssueDate);            
            db.AddInParameter(dbCommand02, "LocID", DbType.String, RIEntity.LocID);
            //db.AddInParameter(dbCommand02, "IssueQty", DbType.String, RIEntity.IssueQty);            


            //object[] parameters = new object[] { RIEntity.ModelID };
            //DbCommand dbCommand05 = db.GetStoredProcCommand("spSetISSUESTOCK", parameters);
            //DataSet ds = db.ExecuteDataSet(dbCommand05);

            db.ExecuteNonQuery(dbCommand, transaction);
            db.ExecuteNonQuery(dbCommand01, transaction);
            db.ExecuteNonQuery(dbCommand02, transaction);
            //return ds.Tables[0];
            return true;
        }
        public DataTable GetSumvalueRecord(object param)
        {
            InvreceivenissueEntity IREntity = (InvreceivenissueEntity)param;
            Database db = DatabaseFactory.CreateDatabase();
            //string sql = "SELECT SUM([Quantity]) AS ReceiveQty SUM() AS TotalissueQty FROM [ITInventory].[dbo].[INV_ItemReceive] WHERE ModelID='" + IREntity.ModelID + "' GROUP BY ItemID, ModelID ";
            //string sql = "SELECT SUM(A.Quantity) AS ReceiveQty, (SELECT SUM(IssueQty) FROM [ITInventory].[dbo].[INV_ItemIssue] WHERE ModelID='" + IREntity.ModelID + "' group by ModelID) AS TotalissueQty, (SUM(A.Quantity)-(SELECT SUM(IssueQty) FROM [ITInventory].[dbo].[INV_ItemIssue] WHERE ModelID='" + IREntity.ModelID + "' group by ModelID)) AS BalanceQty FROM [ITInventory].[dbo].[INV_ItemReceive] AS A,[ITInventory].[dbo].[INV_ItemIssue] AS B WHERE A.ModelID=B.ModelID AND A.ModelID='" + IREntity.ModelID + "'";
            string sql = "SELECT SUM(Quantity) AS ReceiveQty, (SELECT SUM(IssueQty)   FROM [ITInventory].[dbo].[INV_ItemIssue]   WHERE ModelID='" + IREntity.ModelID + "' group by ModelID) AS TotalissueQty,  (SUM(Quantity)- (SELECT SUM(IssueQty)   FROM [ITInventory].[dbo].[INV_ItemIssue]   WHERE ModelID='" + IREntity.ModelID + "' group by ModelID)) AS BalanceQty FROM [ITInventory].[dbo].[INV_ItemReceive] WHERE ModelID='" + IREntity.ModelID + "' group by  ModelID";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }
        public DataTable GetusersumvalueRecord(object param)
        {
            InvreceivenissueEntity obj = (InvreceivenissueEntity)param;
            if (obj.Location == "HLNT" || obj.Location == "HYBD" || obj.Location == "HLWF" || obj.Location == "HLAP" || obj.Location == "HLRC" || obj.Location == "HLST")
            {

                Database db = DatabaseFactory.CreateDatabase();
                //string sql = "SELECT SUM([Quantity]) AS ReceiveQty SUM() AS TotalissueQty FROM [ITInventory].[dbo].[INV_ItemReceive] WHERE ModelID='" + IREntity.ModelID + "' GROUP BY ItemID, ModelID ";
                //string sql = "SELECT SUM(A.Quantity) AS ReceiveQty, (SELECT SUM(IssueQty) FROM [ITInventory].[dbo].[INV_ItemIssue] WHERE ModelID='" + IREntity.ModelID + "' group by ModelID) AS TotalissueQty, (SUM(A.Quantity)-(SELECT SUM(IssueQty) FROM [ITInventory].[dbo].[INV_ItemIssue] WHERE ModelID='" + IREntity.ModelID + "' group by ModelID)) AS BalanceQty FROM [ITInventory].[dbo].[INV_ItemReceive] AS A,[ITInventory].[dbo].[INV_ItemIssue] AS B WHERE A.ModelID=B.ModelID AND A.ModelID='" + IREntity.ModelID + "'";
                //string sql = "SELECT SUM(Quantity) AS ReceiveQty, (SELECT SUM(IssueQty)   FROM [ITInventory].[dbo].[INV_ItemIssue]   WHERE ModelID='" + IREntity.ModelID + "' group by ModelID) AS TotalissueQty,  (SUM(Quantity)- (SELECT SUM(IssueQty)   FROM [ITInventory].[dbo].[INV_ItemIssue]   WHERE ModelID='" + IREntity.ModelID + "' group by ModelID)) AS BalanceQty FROM [ITInventory].[dbo].[INV_ItemReceive] WHERE ModelID='" + IREntity.ModelID + "' group by  ModelID";
                //(Main)string sql = "SELECT SUM(A.IssueQty) as BalanceQty from INV_ItemIssue as A, INV_Location as B WHERE (A.LocID=B.LocID and B.Location='" + obj.Location + "') AND A.ModelID='" + obj.ModelID + "' ";
                string sql = "SELECT SUM(A.IssueQty) as BalanceQty, (SELECT SUM(A.UIssueQty) FROM [ITInventory].[dbo].[INV_Userissue] AS A, INV_Location as B WHERE (A.LocID=B.LocID and B.Location='" + obj.Location + "') AND A.ModelID='" + obj.ModelID + "') as UIssueTotal from INV_ItemIssue as A, INV_Location as B WHERE (A.LocID=B.LocID and B.Location='" + obj.Location + "') AND A.ModelID='" + obj.ModelID + "' ";
                DbCommand dbCommand = db.GetSqlStringCommand(sql);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                return ds.Tables[0];
            }
            else
            {
                Database db = DatabaseFactory.CreateDatabase();
                //string sql = "SELECT SUM([Quantity]) AS ReceiveQty SUM() AS TotalissueQty FROM [ITInventory].[dbo].[INV_ItemReceive] WHERE ModelID='" + IREntity.ModelID + "' GROUP BY ItemID, ModelID ";
                //string sql = "SELECT SUM(A.Quantity) AS ReceiveQty, (SELECT SUM(IssueQty) FROM [ITInventory].[dbo].[INV_ItemIssue] WHERE ModelID='" + IREntity.ModelID + "' group by ModelID) AS TotalissueQty, (SUM(A.Quantity)-(SELECT SUM(IssueQty) FROM [ITInventory].[dbo].[INV_ItemIssue] WHERE ModelID='" + IREntity.ModelID + "' group by ModelID)) AS BalanceQty FROM [ITInventory].[dbo].[INV_ItemReceive] AS A,[ITInventory].[dbo].[INV_ItemIssue] AS B WHERE A.ModelID=B.ModelID AND A.ModelID='" + IREntity.ModelID + "'";
                //string sql = "SELECT SUM(Quantity) AS ReceiveQty, (SELECT SUM(IssueQty)   FROM [ITInventory].[dbo].[INV_ItemIssue]   WHERE ModelID='" + IREntity.ModelID + "' group by ModelID) AS TotalissueQty,  (SUM(Quantity)- (SELECT SUM(IssueQty)   FROM [ITInventory].[dbo].[INV_ItemIssue]   WHERE ModelID='" + IREntity.ModelID + "' group by ModelID)) AS BalanceQty FROM [ITInventory].[dbo].[INV_ItemReceive] WHERE ModelID='" + IREntity.ModelID + "' group by  ModelID";
                string sql = "SELECT SUM(A.IssueQty) as BalanceQty, (SELECT SUM(A.UIssueQty) FROM [ITInventory].[dbo].[INV_Userissue] AS A, INV_Location as B WHERE (A.LocID=B.LocID and B.Location=LEFT(B.Location,4)) AND A.ModelID='" + obj.ModelID + "') as UIssueTotal from INV_ItemIssue as A, INV_Location as B WHERE (A.LocID=B.LocID and B.Location=LEFT(B.Location,4)) AND A.ModelID='" + obj.ModelID + "'";
                DbCommand dbCommand = db.GetSqlStringCommand(sql);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                return ds.Tables[0];
            }
        }




        public DataTable GetFTRTransferListRecord(object param)
        {
            InvFTRTransferEntity obj = (InvFTRTransferEntity)param;     //Inventory/FTRTransferList
            if ((obj.Location == "HLNT" && obj.Userstatus == "Normal") || (obj.Location == "HYBD" && obj.Userstatus == "Normal") || (obj.Location == "HLWF" && obj.Userstatus == "Normal") || (obj.Location == "HLAP" && obj.Userstatus == "Normal") || (obj.Location == "HLRC" && obj.Userstatus == "Normal") || (obj.Location == "HLST" && obj.Userstatus == "Normal"))
            {
                Database db = DatabaseFactory.CreateDatabase();
                //string sql = "SELECT A.[TRID] AS TRID, A.[ItemID] AS ItemID,B.[ModelID] AS ModelID, A.[IssueDate] AS IssueDate, A.[LocID] AS LocID, B.[IssueQty] AS IssueQty, A.[IsReceive] AS IsReceive   FROM [ITInventory].[dbo].[INV_FTYTransfer] AS A INNER JOIN [ITInventory].[dbo].[INV_ReceiveNissue] AS B ON A.ItemID=B.ItemID WHERE A.Location=LEFT(Location,4) ORDER BY A.IssueDate";
                //string sql = "SELECT [TRID] AS TRID, [ItemID] AS ItemID, [IssueDate] AS IssueDate, [LocID] AS LocID, [IsReceive] AS IsReceive   FROM [ITInventory].[dbo].[INV_FTYTransfer]   ORDER BY  IssueDate DESC";
                //string sql = "SELECT  [ItemID] AS ItemID,[IssueDate] AS IssueDate, [LocID] AS LocID, [IsReceive] AS IsReceive   FROM [ITInventory].[dbo].[INV_FTYTransfer]   ORDER BY  IssueDate DESC";
                string sql = "SELECT MAX([TRID]) AS TRID, [ItemID] AS ItemID, [IssueDate] AS IssueDate, [LocID] AS LocID, [IsReceive] AS IsReceive   FROM [ITInventory].[dbo].[INV_FTYTransfer]   GROUP BY  IssueDate, ItemID,LocID,IsReceive ORDER BY convert(date,IssueDate,103) DESC ";
                DbCommand dbCommand = db.GetSqlStringCommand(sql);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                return ds.Tables[0];
           }
            else if ((obj.Location == "HLNT" && obj.Userstatus == "OPEX") || (obj.Location == "HYBD" && obj.Userstatus == "OPEX") || (obj.Location == "HLWF" && obj.Userstatus == "OPEX") || (obj.Location == "HLAP" && obj.Userstatus == "OPEX") || (obj.Location == "HLRC" && obj.Userstatus == "OPEX") || (obj.Location == "HLST" && obj.Userstatus == "OPEX"))
            {
                Database db = DatabaseFactory.CreateDatabase();
                //string sql = "SELECT A.[TRID] AS TRID, A.[ItemID] AS ItemID,B.[ModelID] AS ModelID, A.[IssueDate] AS IssueDate, A.[LocID] AS LocID, B.[IssueQty] AS IssueQty, A.[IsReceive] AS IsReceive   FROM [ITInventory].[dbo].[INV_FTYTransfer] AS A INNER JOIN [ITInventory].[dbo].[INV_ReceiveNissue] AS B ON A.ItemID=B.ItemID WHERE A.Location=LEFT(Location,4) ORDER BY A.IssueDate";
                //string sql = "SELECT [TRID] AS TRID, [ItemID] AS ItemID, [IssueDate] AS IssueDate, [LocID] AS LocID, [IsReceive] AS IsReceive   FROM [ITInventory].[dbo].[INV_FTYTransfer]   ORDER BY  IssueDate DESC";
                //string sql = "SELECT  [ItemID] AS ItemID,[IssueDate] AS IssueDate, [LocID] AS LocID, [IsReceive] AS IsReceive   FROM [ITInventory].[dbo].[INV_FTYTransfer]   ORDER BY  IssueDate DESC";
                string sql = "SELECT MAX(A.[TRID]) AS TRID, A.[ItemID] AS ItemID, A.[IssueDate] AS IssueDate, A.[LocID] AS LocID, A.[IsReceive] AS IsReceive   FROM [ITInventory].[dbo].[INV_FTYTransfer] as A, [ITInventory].[dbo].[INV_Location] as B WHERE A.LocID=B.LocID AND B.Location='" + obj.Location + "' GROUP BY  A.IssueDate, A.ItemID, A.LocID, A.IsReceive ORDER BY convert(date,A.IssueDate,103) DESC";
                DbCommand dbCommand = db.GetSqlStringCommand(sql);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                return ds.Tables[0];
            }
            else
            {
                Database db = DatabaseFactory.CreateDatabase();
                //string sql = "SELECT A.[TRID] AS TRID, A.[ItemID] AS ItemID,B.[ModelID] AS ModelID, A.[IssueDate] AS IssueDate, A.[LocID] AS LocID, B.[IssueQty] AS IssueQty, A.[IsReceive] AS IsReceive   FROM [ITInventory].[dbo].[INV_FTYTransfer] AS A INNER JOIN [ITInventory].[dbo].[INV_ReceiveNissue] AS B ON A.ItemID=B.ItemID WHERE A.Location=LEFT(Location,4) ORDER BY A.IssueDate";
                //string sql = "SELECT [TRID] AS TRID, [ItemID] AS ItemID, [IssueDate] AS IssueDate, [LocID] AS LocID, [IsReceive] AS IsReceive   FROM [ITInventory].[dbo].[INV_FTYTransfer]   ORDER BY  IssueDate DESC";
                //string sql = "SELECT  [ItemID] AS ItemID,[IssueDate] AS IssueDate, [LocID] AS LocID, [IsReceive] AS IsReceive   FROM [ITInventory].[dbo].[INV_FTYTransfer]   ORDER BY  IssueDate DESC";
                string sql = "SELECT MAX([TRID]) AS TRID, [ItemID] AS ItemID, [IssueDate] AS IssueDate, [LocID] AS LocID, [IsReceive] AS IsReceive   FROM [ITInventory].[dbo].[INV_FTYTransfer]   GROUP BY  IssueDate, ItemID,LocID,IsReceive ORDER BY convert(date,IssueDate,103) DESC ";
                DbCommand dbCommand = db.GetSqlStringCommand(sql);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                return ds.Tables[0];
            }
        }
        public DataTable GetAssetdistbyMDate(object param)
        {
            InvFTRTransferEntity obj = (InvFTRTransferEntity)param;
            if ((obj.Location == "HLNT" && obj.Userstatus == "Normal") || (obj.Location == "HYBD" && obj.Userstatus == "Normal") || (obj.Location == "HLWF" && obj.Userstatus == "Normal") || (obj.Location == "HLAP" && obj.Userstatus == "Normal") || (obj.Location == "HLRC" && obj.Userstatus == "Normal") || (obj.Location == "HLST" && obj.Userstatus == "Normal"))
            {
                Database db = DatabaseFactory.CreateDatabase();
                //string sql = "SELECT SUM([Quantity]) AS ReceiveQty SUM() AS TotalissueQty FROM [ITInventory].[dbo].[INV_ItemReceive] WHERE ModelID='" + IREntity.ModelID + "' GROUP BY ItemID, ModelID ";            
                //string sql = "SELECT A.[TRID] AS TRID, A.[ItemID] AS ItemID,B.[ModelID] AS ModelID, A.[IssueDate] AS IssueDate, A.[LocID] AS LocID, B.[IssueQty] AS IssueQty, A.[IsReceive] AS IsReceive   FROM [ITInventory].[dbo].[INV_FTYTransfer] AS A, [ITInventory].[dbo].[INV_ReceiveNissue] AS B WHERE (A.ItemID=B.ItemID AND A.IssueDate=B.IssueDate)  AND A.IssueDate=convert(date,'" + IREntity.IssueDate + "',103)";
                //string sql = "SELECT A.[TRID] AS TRID, A.[ItemID] AS ItemID,B.[ModelID] AS ModelID, A.[IssueDate] AS IssueDate, A.[LocID] AS LocID, B.[IssueQty] AS IssueQty, A.[IsReceive] AS IsReceive   FROM [ITInventory].[dbo].[INV_FTYTransfer] AS A LEFT JOIN [ITInventory].[dbo].[INV_ReceiveNissue] AS B ON (A.ItemID=B.ItemID)  WHERE A.IssueDate=convert(date,'" + IREntity.IssueDate + "',103)";
                string sql = "SELECT A.[RIssueID], A.[ItemID], A.[ModelID], A.[IssueDate] AS IssueDate, A.[LocID], A.[IssueQty]  FROM [ITInventory].[dbo].[INV_ReceiveNissue] as A, [ITInventory].[dbo].[INV_Location] as B WHERE A.LocID=B.LocID AND B.Location=LEFT(B.Location,4) AND A.ItemID='" + obj.ItemID + "' AND A.IssueDate='" + obj.IssueDate + "' ";
                DbCommand dbCommand = db.GetSqlStringCommand(sql);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                return ds.Tables[0];
            }
            else if ((obj.Location == "HLNT" && obj.Userstatus == "OPEX") || (obj.Location == "HYBD" && obj.Userstatus == "OPEX") || (obj.Location == "HLWF" && obj.Userstatus == "OPEX") || (obj.Location == "HLAP" && obj.Userstatus == "OPEX") || (obj.Location == "HLRC" && obj.Userstatus == "OPEX") || (obj.Location == "HLST" && obj.Userstatus == "OPEX"))
            {
                Database db = DatabaseFactory.CreateDatabase();
                //string sql = "SELECT SUM([Quantity]) AS ReceiveQty SUM() AS TotalissueQty FROM [ITInventory].[dbo].[INV_ItemReceive] WHERE ModelID='" + IREntity.ModelID + "' GROUP BY ItemID, ModelID ";            
                //string sql = "SELECT A.[TRID] AS TRID, A.[ItemID] AS ItemID,B.[ModelID] AS ModelID, A.[IssueDate] AS IssueDate, A.[LocID] AS LocID, B.[IssueQty] AS IssueQty, A.[IsReceive] AS IsReceive   FROM [ITInventory].[dbo].[INV_FTYTransfer] AS A, [ITInventory].[dbo].[INV_ReceiveNissue] AS B WHERE (A.ItemID=B.ItemID AND A.IssueDate=B.IssueDate)  AND A.IssueDate=convert(date,'" + IREntity.IssueDate + "',103)";
                //string sql = "SELECT A.[TRID] AS TRID, A.[ItemID] AS ItemID,B.[ModelID] AS ModelID, A.[IssueDate] AS IssueDate, A.[LocID] AS LocID, B.[IssueQty] AS IssueQty, A.[IsReceive] AS IsReceive   FROM [ITInventory].[dbo].[INV_FTYTransfer] AS A LEFT JOIN [ITInventory].[dbo].[INV_ReceiveNissue] AS B ON (A.ItemID=B.ItemID)  WHERE A.IssueDate=convert(date,'" + IREntity.IssueDate + "',103)";
                string sql = "SELECT A.[RIssueID], A.[ItemID], A.[ModelID], A.[IssueDate] AS IssueDate, A.[LocID], A.[IssueQty]  FROM [ITInventory].[dbo].[INV_ReceiveNissue] as A, [ITInventory].[dbo].[INV_Location] as B WHERE A.LocID=B.LocID AND B.Location='" + obj.Location + "' AND A.ItemID='" + obj.ItemID + "' AND A.IssueDate='" + obj.IssueDate + "' ";
                DbCommand dbCommand = db.GetSqlStringCommand(sql);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                return ds.Tables[0];
            }
            else
            {
                Database db = DatabaseFactory.CreateDatabase();
                //string sql = "SELECT SUM([Quantity]) AS ReceiveQty SUM() AS TotalissueQty FROM [ITInventory].[dbo].[INV_ItemReceive] WHERE ModelID='" + IREntity.ModelID + "' GROUP BY ItemID, ModelID ";            
                //string sql = "SELECT A.[TRID] AS TRID, A.[ItemID] AS ItemID,B.[ModelID] AS ModelID, A.[IssueDate] AS IssueDate, A.[LocID] AS LocID, B.[IssueQty] AS IssueQty, A.[IsReceive] AS IsReceive   FROM [ITInventory].[dbo].[INV_FTYTransfer] AS A, [ITInventory].[dbo].[INV_ReceiveNissue] AS B WHERE (A.ItemID=B.ItemID AND A.IssueDate=B.IssueDate)  AND A.IssueDate=convert(date,'" + IREntity.IssueDate + "',103)";
                //string sql = "SELECT A.[TRID] AS TRID, A.[ItemID] AS ItemID,B.[ModelID] AS ModelID, A.[IssueDate] AS IssueDate, A.[LocID] AS LocID, B.[IssueQty] AS IssueQty, A.[IsReceive] AS IsReceive   FROM [ITInventory].[dbo].[INV_FTYTransfer] AS A LEFT JOIN [ITInventory].[dbo].[INV_ReceiveNissue] AS B ON (A.ItemID=B.ItemID)  WHERE A.IssueDate=convert(date,'" + IREntity.IssueDate + "',103)";
                string sql = "SELECT A.[RIssueID], A.[ItemID], A.[ModelID], A.[IssueDate] AS IssueDate, A.[LocID], A.[IssueQty]  FROM [ITInventory].[dbo].[INV_ReceiveNissue] as A, [ITInventory].[dbo].[INV_Location] as B WHERE A.LocID=B.LocID AND B.Location=LEFT(B.Location,4) AND A.ItemID='" + obj.ItemID + "' AND A.IssueDate='" + obj.IssueDate + "' ";
                DbCommand dbCommand = db.GetSqlStringCommand(sql);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                return ds.Tables[0];
            }
        }
        public DataTable GetassettransBylocdate(InvFTRTransferEntity obj, object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            object[] parameters = new object[] { obj.ItemID, obj.IssueDate, obj.Location, obj.Userstatus };
            DbCommand dbCommand = db.GetStoredProcCommand("spGetassettransBylocdate", parameters);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }
        public bool UpdateFTRTransferList(InvFTRTransferEntity FTREntity, Database db, DbTransaction transaction)
        {
            string sql = "UPDATE [ITInventory].[dbo].[INV_FTYTransfer] SET ItemID= @ItemID, IssueDate= @IssueDate, IsReceive=@IsReceive  WHERE TRID=@TRID";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "TRID", DbType.String, FTREntity.TRID);
            db.AddInParameter(dbCommand, "ItemID", DbType.String, FTREntity.ItemID);
            db.AddInParameter(dbCommand, "IssueDate", DbType.String, FTREntity.IssueDate);
            db.AddInParameter(dbCommand, "IsReceive", DbType.String, FTREntity.IsReceive);

            db.ExecuteNonQuery(dbCommand, transaction);
            return true;
        }
    }
}
