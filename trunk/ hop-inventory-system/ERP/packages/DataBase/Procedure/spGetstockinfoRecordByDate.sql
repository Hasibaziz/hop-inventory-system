USE [ITInventory]
GO
/****** Object:  StoredProcedure [dbo].[spGetstockinfoRecordByDate]    Script Date: 12/01/2013 12:26:30 ******/
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
	SELECT SID, ItemID, ModelID, convert(date,SDate,103) as SDate, IDate, IssueQty, TOTALRQty, TOTALIQty, BalanceQty FROM ITInventory.dbo.INV_Stock
	WHERE (convert(date,SDate,103)>=convert(date, @StartDate,103))
	--WHERE (SDate BETWEEN (@StartDate) AND (@EndDate))
	--and ItemID=@ItemID and ModelID=@ModelID
	ORDER BY convert(date, SDate,103) DESC
END
ELSE IF ((@StartDate!=' ') and (@EndDate!=' ') and (@ItemID=' ') and (@ModelID=' '))
BEGIN
    SELECT SID, ItemID, ModelID, convert(date,SDate,103) as SDate, IDate, IssueQty, TOTALRQty, TOTALIQty, BalanceQty FROM ITInventory.dbo.INV_Stock
	WHERE convert(date,SDate,103)  >=convert(date,@StartDate,103) AND convert(date,SDate,103)<=convert(date,@EndDate,103)
	--and ItemID=@ItemID and ModelID=@ModelID
	ORDER BY convert(date, SDate,103) DESC
END
ELSE IF ((@StartDate!=' ') and (@EndDate!=' ') and (@ItemID!=' ') and (@ModelID=' '))
BEGIN
    SELECT SID, ItemID, ModelID, convert(date,SDate,103) as SDate, IDate, IssueQty, TOTALRQty, TOTALIQty, BalanceQty FROM ITInventory.dbo.INV_Stock
	WHERE convert(date,SDate,103)  >=convert(date,@StartDate,103) AND convert(date,SDate,103)<=convert(date,@EndDate,103)
	and ItemID=@ItemID
	--and ItemID=@ItemID and ModelID=@ModelID
	ORDER BY convert(date, SDate,103) DESC
END
ELSE IF ((@StartDate=' ') and (@EndDate=' ') and (@ItemID=' ') and (@ModelID!=' '))
BEGIN
    SELECT SID, ItemID, ModelID, convert(date,SDate,103) as SDate, IDate, IssueQty, TOTALRQty, TOTALIQty, BalanceQty FROM ITInventory.dbo.INV_Stock
	--WHERE (SDate BETWEEN (@StartDate) AND (@EndDate))
	--and ItemID=@ItemID and ModelID=@ModelID
	WHERE ModelID=@ModelID
	ORDER BY convert(date, SDate,103) DESC
END
ELSE IF ((@StartDate!=' ') and (@EndDate!=' ') and (@ItemID!=' ') and (@ModelID!=' '))
BEGIN
    SELECT SID, ItemID, ModelID, convert(date,SDate,103) as SDate, IDate, IssueQty, TOTALRQty, TOTALIQty, BalanceQty FROM ITInventory.dbo.INV_Stock
	WHERE convert(date,SDate,103)  >=convert(date,@StartDate,103) AND convert(date,SDate,103)<=convert(date,@EndDate,103)
	and ItemID=@ItemID and ModelID=@ModelID
	ORDER BY convert(date, SDate,103) DESC
END
ELSE
BEGIN
    SELECT SID, ItemID, ModelID, convert(date,SDate,103) as SDate, IDate, IssueQty, TOTALRQty, TOTALIQty, BalanceQty FROM ITInventory.dbo.INV_Stock
	--WHERE (SDate BETWEEN (@StartDate) AND (@EndDate))
	--and ItemID=@ItemID and ModelID=@ModelID
	ORDER BY convert(date, SDate,103) DESC
END
