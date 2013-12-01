USE [ITInventory]
GO
/****** Object:  StoredProcedure [dbo].[spSetISSUESTOCK]    Script Date: 12/01/2013 12:28:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:        <Author,,Name>
-- Create date: <Create Date,,>
-- Description:    <Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spSetISSUESTOCK]
                  @ModelID AS Uniqueidentifier
               
               
AS

 IF (NOT EXISTS(SELECT * FROM dbo.INV_Stock WHERE ModelID=@ModelID and SDate=(SELECT MAX(IDate) FROM dbo.INV_ItemIssue) ))
BEGIN
  SET NOCOUNT ON;
    INSERT INTO dbo.INV_Stock( ItemID, ModelID, SDate, TOTALRQty, TOTALIQty, BalanceQty )
     SELECT ItemID as ItemID, 
            ModelID AS ModelID, 
            --SDate=convert(date,GETDATE(),103),            
            MAX(IDate) as SDate,
            (SELECT TOTALRQty FROM dbo.INV_Stock WHERE ModelID=@ModelID and SDate=(SELECT MAX(SDate) FROM dbo.INV_Stock) ) as TOTALRQty,
            ((SELECT TOTALIQty from dbo.INV_Stock WHERE ModelID=@ModelID and SDate=(SELECT MAX(SDate) FROM dbo.INV_Stock))+( SELECT IssueQty FROM dbo.INV_ItemIssue WHERE ModelID=@ModelID and IDate=(SELECT MAX(IDate) FROM dbo.INV_ItemIssue) ) ) AS TOTALIQty,
            
            ((SELECT TOTALRQty FROM dbo.INV_Stock WHERE ModelID=@ModelID and SDate=(SELECT MAX(SDate) FROM dbo.INV_Stock)) 
             - 
            ((SELECT TOTALIQty from dbo.INV_Stock WHERE ModelID=@ModelID and SDate=(SELECT MAX(SDate) FROM dbo.INV_Stock))+( SELECT IssueQty FROM dbo.INV_ItemIssue WHERE ModelID=@ModelID and IDate=(SELECT MAX(IDate) FROM dbo.INV_ItemIssue) ) ) ) as BalanceQty           
        
        FROM
        dbo.INV_ItemIssue
        WHERE ModelID=@ModelID   
        GROUP BY ItemID, ModelID  
END
ELSE
BEGIN
   UPDATE  dbo.INV_Stock 
    SET 
    TOTALRQty=(SELECT TOTALRQty FROM dbo.INV_Stock WHERE ModelID=@ModelID and SDate=(SELECT MAX(SDate) FROM dbo.INV_Stock) ),
    TOTALIQty=((SELECT TOTALIQty from dbo.INV_Stock WHERE ModelID=@ModelID and SDate=(SELECT MAX(SDate) FROM dbo.INV_Stock))+( SELECT IssueQty FROM dbo.INV_ItemIssue WHERE ModelID=@ModelID and IDate=(SELECT MAX(IDate) FROM dbo.INV_ItemIssue) ) ),
     
    BalanceQty= ((SELECT TOTALRQty FROM dbo.INV_Stock WHERE ModelID=@ModelID and SDate=(SELECT MAX(SDate) FROM dbo.INV_Stock)) 
                - 
                ((SELECT TOTALIQty from dbo.INV_Stock WHERE ModelID=@ModelID and SDate=(SELECT MAX(SDate) FROM dbo.INV_Stock))+( SELECT IssueQty FROM dbo.INV_ItemIssue WHERE ModelID=@ModelID and IDate=(SELECT MAX(IDate) FROM dbo.INV_ItemIssue) ) ) )
     
    WHERE ModelID=@ModelID and SDate=(SELECT MAX(SDate) FROM dbo.INV_Stock)
END 