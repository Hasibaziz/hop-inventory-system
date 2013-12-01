USE [ITInventory]
GO
/****** Object:  StoredProcedure [dbo].[spSetFTYTransfer]    Script Date: 12/01/2013 12:27:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:        <Author,,Name>
-- Create date: <Create Date,,>
-- Description:    <Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spSetFTYTransfer]
                  @ItemID AS Uniqueidentifier
                , @IssueDate AS nvarchar(100)
                , @LocID as Uniqueidentifier
               
AS

IF (NOT EXISTS(SELECT * FROM ITInventory.dbo.INV_FTYTransfer where IssueDate =@IssueDate))
BEGIN
  SET NOCOUNT ON;
    INSERT INTO ITInventory.dbo.INV_FTYTransfer ( ItemID, IssueDate, LocID, IsReceive) VALUES ( @ItemID, @IssueDate, @LocID, 'False' )
END
ELSE
BEGIN
    UPDATE ITInventory.dbo.INV_FTYTransfer SET ItemID=@ItemID, LocID=@LocID, IsReceive='True' where IssueDate=@IssueDate
END 