USE [ITInventory]
GO
/****** Object:  Trigger [dbo].[STOCKI]    Script Date: 09/04/2013 12:44:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[STOCKI]   
ON  [ITInventory].[dbo].[INV_ItemIssue]  
   FOR INSERT, UPDATE
AS 
PRINT GETDATE()
DECLARE  @ModelID AS uniqueidentifier;
--DECLARE  @ItemID  AS uniqueidentifier;
--DECLARE  @TOTALRQty INT;
--DECLARE  @TOTALIQty INT;
--DECLARE  @BalanceQty INT;

select @ModelID=i.ModelID from inserted i;	

--SELECT @ItemID=i.ItemID from inserted i;
--SELECT @TOTALRQty=(SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=@ModelID);
--SELECT @TOTALIQty=(SELECT sum(IssueQty) FROM dbo.INV_ItemIssue WHERE ModelID=@ModelID);
--SELECT @BalanceQty=((SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=@ModelID)-(SELECT sum(IssueQty) FROM dbo.INV_ItemIssue WHERE ModelID=@ModelID));



BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for trigger here
    IF (NOT EXISTS(SELECT * FROM dbo.INV_Stock WHERE ModelID=@ModelID and SDate=(SELECT MAX(IDate) FROM dbo.INV_ItemIssue) ))
     INSERT INTO dbo.INV_Stock( ItemID, ModelID, SDate, TOTALRQty, TOTALIQty, BalanceQty )
     SELECT ItemID as ItemID, 
            ModelID AS ModelID, 
            --SDate=convert(date,GETDATE(),103),            
            MAX(IDate) as SDate,
            (SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=@ModelID) as TOTALRQty, 
            (SELECT sum(IssueQty) FROM dbo.INV_ItemIssue WHERE ModelID=@ModelID) as TOTALIQty,            
            ((SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=@ModelID)-(SELECT sum(IssueQty) FROM dbo.INV_ItemIssue WHERE ModelID=@ModelID)) as BalanceQty  
        FROM
        dbo.INV_ItemIssue
        WHERE ModelID=@ModelID   
        GROUP BY ItemID, ModelID  
    ELSE
     UPDATE  dbo.INV_Stock 
     SET 
     TOTALRQty=(SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=@ModelID) , 
     TOTALIQty=(SELECT sum(IssueQty) FROM dbo.INV_ItemIssue WHERE ModelID=@ModelID),
     BalanceQty=((SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=@ModelID)-(SELECT sum(IssueQty) FROM dbo.INV_ItemIssue WHERE ModelID=@ModelID))          
     WHERE ModelID=@ModelID and SDate=(SELECT MAX(IDate) FROM dbo.INV_ItemIssue)
 END