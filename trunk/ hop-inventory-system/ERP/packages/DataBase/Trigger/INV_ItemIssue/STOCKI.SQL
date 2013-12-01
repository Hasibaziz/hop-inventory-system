USE [ITInventory]
GO
/****** Object:  Trigger [dbo].[STOCKI]    Script Date: 12/01/2013 12:15:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Md.Hasib>
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
DECLARE  @ISSUEQty  INT;
DECLARE  @IDate     VARCHAR(50);
 

select @ModelID  =i.ModelID  from inserted i;	
select @ISSUEQty =i.IssueQty from inserted i;
select @IDate    =MAX(i.IDate)    from inserted i;

--SELECT @ItemID=i.ItemID from inserted i;
--SELECT @TOTALRQty=(SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=@ModelID);
--SELECT @TOTALIQty=(SELECT sum(IssueQty) FROM dbo.INV_ItemIssue WHERE ModelID=@ModelID);
--SELECT @BalanceQty=((SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=@ModelID)-(SELECT sum(IssueQty) FROM dbo.INV_ItemIssue WHERE ModelID=@ModelID));
   
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for trigger here
 IF (NOT EXISTS(SELECT * FROM dbo.INV_Stock WHERE ModelID=@ModelID and SDate=@IDate ))
 --  IF (NOT EXISTS(SELECT * FROM dbo.INV_Stock WHERE ModelID=@ModelID and SDate=@IDate ))
    --IF (NOT EXISTS(SELECT * FROM dbo.INV_Stock WHERE ModelID=@ModelID and SDate=(SELECT MAX(SDate) FROM dbo.INV_Stock) ))
     INSERT INTO dbo.INV_Stock( ItemID, ModelID, SDate,IDate,IssueQty, TOTALRQty, TOTALIQty, BalanceQty )
     SELECT a.ItemID
           , a.ModelID
           , a.IDate as SDate
           , a.IDate
           , a.IssueQty
           ,(SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=@ModelID) as TOTALRQty
           , (SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE b.IDate <= a.IDate AND b.ModelID=@ModelID) as TOTALIQty
           ,((SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=@ModelID)-(SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE b.IDate <= a.IDate AND b.ModelID=@ModelID)) as BalanceQty
     FROM  dbo.INV_ItemIssue  a where a.ModelID=@ModelID 
     AND IDate=@IDate    ---***** IF Date Not Select Then all Data Will be calculate according to Model ID
     ORDER BY a.IDate
  ELSE
 
update dbo.INV_Stock 
   SET  IssueQty=(SELECT IssueQty FROM dbo.INV_ItemIssue WHERE ModelID=@ModelID AND IDate=@IDate),
        TOTALRQty=(SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=@ModelID),
        TOTALIQty=(SELECT (SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE b.IDate <= I.IDate AND b.ModelID=@ModelID) FROM dbo.INV_ItemIssue AS I  WHERE I.ModelID=@ModelID and I.IDate=@IDate),
        BalanceQty=((SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=@ModelID)-(SELECT (SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE b.IDate <= I.IDate AND b.ModelID=@ModelID) FROM dbo.INV_ItemIssue AS I  WHERE I.ModelID=@ModelID and I.IDate=@IDate))
        
  --  FROM dbo.INV_ItemIssue AS I 
    WHERE IDate=@IDate
    
 END