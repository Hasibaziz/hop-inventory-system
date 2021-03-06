set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

-- =============================================
-- Author:		<Author,,Apurba Kumar Sarker>
-- Create date: <Create Date,,09/17/2013>
-- Description:	<Description,,Data Insert in the STOCK Table>
-- =============================================
ALTER TRIGGER [TrgInsertUpdateOFStockTable]
   ON  [dbo].[INV_ItemIssue]
   AFTER INSERT,UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Declare the variable to be used.
	DECLARE @MyBoll int;
	DECLARE @IssueQtyDec int;


    -- ItemID and ModelID Wise Stock Sum -- INV_ItemIssue
	SET @IssueQtyDec = 0;
	SET @IssueQtyDec = (
						SELECT     SUM(IssueQty) AS IQty
						FROM         INV_ItemIssue
						WHERE     (ItemID = 1) AND (ModelID = 1)--Inserted.ItemID
						);

	-- Check Stock Table Data Insert OR Update
	-- Initialize the variable.
	SET @MyBoll = 0;
	SET @MyBoll = (
						SELECT     ISNULL(SUM(TOTALIQty), 0) AS TIQty
						FROM         INV_Stock
						WHERE     (ItemID = 1) AND (ModelID = 1)
						);

-- IF == 0 then Insert  === > 0 Then Update
----
	IF (@MyBoll = 0)
	BEGIN
		INSERT INTO INV_Stock
							  (ItemID, ModelID, SDate, TOTALRQty, TOTALIQty, BalanceQty)
		VALUES     (1, 1, '09/17/2013', 0, @IssueQtyDec, @IssueQtyDec);
	END
	--- UPDATE STOCK TABLE ----
	ELSE
	BEGIN
		UPDATE    INV_Stock
		SET              TOTALIQty = @IssueQtyDec, BalanceQty = 0
		WHERE     (ItemID = 1) AND (ModelID = 1);
	END
----


END

