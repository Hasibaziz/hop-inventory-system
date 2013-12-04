USE [ITInventory]
GO
/****** Object:  StoredProcedure [dbo].[spGetstockinfoRecordByDate]    Script Date: 12/04/2013 11:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spGetstockinfoRecordByDate]
                    @StartDate AS nvarchar(100),
                    @EndDate   AS nvarchar(100),
                    @ItemID    AS nvarchar(100),
                    @ModelID   AS nvarchar(100)
                    
AS
IF ((@StartDate!=' ') and (@EndDate=' ') and (@ItemID=' ') and (@ModelID=' '))
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT a.ItemID, a.ModelID, a.IDate as SDate, a.IDate, a.IssueQty
       ,(SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=a.ModelID) as TOTALRQty
       ,(SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE CONVERT(DATE,b.IDate, 103) <= CONVERT(DATE,a.IDate, 103) AND b.ModelID=a.ModelID) as TOTALIQty
       ,((SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=a.ModelID)-(SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE CONVERT(DATE,b.IDate, 103) <= CONVERT(DATE,a.IDate, 103) AND b.ModelID=a.ModelID)) as BalanceQty
    FROM  dbo.INV_ItemIssue  a 
    WHERE convert(date,a.IDate,103)  >=convert(date,@StartDate,103) 
    --AND convert(date,IDate,103)<=convert(date,@EndDate,103)
    --AND a.ItemID=@ItemID and a.ModelID=@ModelID
    ORDER BY a.ModelID, CONVERT(DATE,a.IDate, 103) DESC
END
ELSE IF ((@StartDate!=' ') and (@EndDate!=' ') and (@ItemID=' ') and (@ModelID=' '))
BEGIN
    SELECT a.ItemID, a.ModelID, a.IDate as SDate, a.IDate, a.IssueQty
       ,(SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=a.ModelID) as TOTALRQty
       ,(SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE CONVERT(DATE,b.IDate, 103) <= CONVERT(DATE,a.IDate, 103) AND b.ModelID=a.ModelID) as TOTALIQty
       ,((SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=a.ModelID)-(SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE CONVERT(DATE,b.IDate, 103) <= CONVERT(DATE,a.IDate, 103) AND b.ModelID=a.ModelID)) as BalanceQty
    FROM  dbo.INV_ItemIssue  a 
    WHERE convert(date,a.IDate,103)  >=convert(date,@StartDate,103) AND convert(date,IDate,103)<=convert(date,@EndDate,103)
    --AND a.ItemID=@ItemID and a.ModelID=@ModelID
    ORDER BY a.ModelID, CONVERT(DATE,a.IDate, 103) DESC
END
ELSE IF ((@StartDate!=' ') and (@EndDate!=' ') and (@ItemID!=' ') and (@ModelID=' '))
BEGIN
    SELECT a.ItemID, a.ModelID, a.IDate as SDate, a.IDate, a.IssueQty
       ,(SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=a.ModelID) as TOTALRQty
       ,(SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE CONVERT(DATE,b.IDate, 103) <= CONVERT(DATE,a.IDate, 103) AND b.ModelID=a.ModelID) as TOTALIQty
       ,((SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=a.ModelID)-(SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE CONVERT(DATE,b.IDate, 103) <= CONVERT(DATE,a.IDate, 103) AND b.ModelID=a.ModelID)) as BalanceQty
    FROM  dbo.INV_ItemIssue  a 
    WHERE convert(date,a.IDate,103)  >=convert(date,@StartDate,103) AND convert(date,IDate,103)<=convert(date,@EndDate,103)
    AND a.ItemID=@ItemID 
    --and a.ModelID=@ModelID
    ORDER BY a.ModelID, CONVERT(DATE,a.IDate, 103) DESC
END
ELSE IF ((@StartDate=' ') and (@EndDate=' ') and (@ItemID=' ') and (@ModelID!=' '))
BEGIN
    SELECT a.ItemID, a.ModelID, a.IDate as SDate, a.IDate, a.IssueQty
       ,(SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=a.ModelID) as TOTALRQty
       ,(SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE CONVERT(DATE,b.IDate, 103) <= CONVERT(DATE,a.IDate, 103) AND b.ModelID=a.ModelID) as TOTALIQty
       ,((SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=a.ModelID)-(SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE CONVERT(DATE,b.IDate, 103) <= CONVERT(DATE,a.IDate, 103) AND b.ModelID=a.ModelID)) as BalanceQty
    FROM  dbo.INV_ItemIssue  a 
    WHERE a.ModelID=@ModelID
    ORDER BY a.ModelID, CONVERT(DATE,a.IDate, 103) DESC
END
ELSE IF ((@StartDate!=' ') and (@EndDate!=' ') and (@ItemID!=' ') and (@ModelID!=' '))
BEGIN
    SELECT a.ItemID, a.ModelID, a.IDate as SDate, a.IDate, a.IssueQty
       ,(SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=a.ModelID) as TOTALRQty
       ,(SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE CONVERT(DATE,b.IDate, 103) <= CONVERT(DATE,a.IDate, 103) AND b.ModelID=a.ModelID) as TOTALIQty
       ,((SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=a.ModelID)-(SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE CONVERT(DATE,b.IDate, 103) <= CONVERT(DATE,a.IDate, 103) AND b.ModelID=a.ModelID)) as BalanceQty
    FROM  dbo.INV_ItemIssue  a 
    WHERE convert(date,a.IDate,103)  >=convert(date,@StartDate,103) AND convert(date,IDate,103)<=convert(date,@EndDate,103)
    AND  a.ItemID=@ItemID and a.ModelID=@ModelID
    ORDER BY a.ModelID, CONVERT(DATE,a.IDate, 103) DESC
END
ELSE
BEGIN
   SELECT a.ItemID, a.ModelID, a.IDate as SDate, a.IDate, a.IssueQty
       ,(SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=a.ModelID) as TOTALRQty
       , (SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE CONVERT(DATE,b.IDate, 103) <= CONVERT(DATE,a.IDate, 103) AND b.ModelID=a.ModelID) as TOTALIQty
       ,((SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=a.ModelID)-(SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE CONVERT(DATE,b.IDate, 103) <= CONVERT(DATE,a.IDate, 103) AND b.ModelID=a.ModelID)) as BalanceQty
   FROM  dbo.INV_ItemIssue  a 
   ORDER BY a.ModelID, CONVERT(DATE,a.IDate, 103) DESC
END
