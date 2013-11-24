USE [ITInventory]
GO
/****** Object:  StoredProcedure [dbo].[spGetassettransBylocdate]    Script Date: 08/25/2013 10:42:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spGetassettransBylocdate]	
				  @ItemID AS nvarchar(100)
				, @IssueDate AS nvarchar(100)
				,@Location AS nvarchar(100)
				,@Userstatus as nvarchar(100)
				
AS
--IF((@Location='HLNT' and @Userstatus='Normal' OR (@Location='HLAP' and @Userstatus='Normal')OR (@Location='HLBD' and @Userstatus='Normal') OR (@Location='HLRC' and @Userstatus='Normal') OR (@Location='HLWF' and @Userstatus='Normal') OR (@Location='HYBD' and @Userstatus='Normal'))
--******** For only Location Selection
IF ((@Location='HLNT' and @Userstatus='Normal') OR (@Location='HLAP' and @Userstatus='Normal')OR (@Location='HLBD' and @Userstatus='Normal') OR (@Location='HLRC' and @Userstatus='Normal') OR (@Location='HLWF' and @Userstatus='Normal') OR (@Location='HYBD' and @Userstatus='Normal'))
BEGIN
IF((@ItemID!=' ') and (@IssueDate=' '))	
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
SELECT MAX(A.[TRID]) AS TRID, 
	       A.[ItemID] AS ItemID,	      
	       A.[IssueDate] AS IssueDate, 
	       A.[LocID] AS [LocID], 	      
	       A.[IsReceive] AS IsReceive   
	       FROM [ITInventory].[dbo].[INV_FTYTransfer] as A, [ITInventory].[dbo].[INV_Location] as B
	       WHERE 	
	       (A.LocID=B.LocID AND B.Location=@Location)       
	       AND
	       ItemID=@ItemID GROUP BY  A.IssueDate, A.ItemID, A.LocID, A.IsReceive ORDER BY A.IssueDate DESC	      
END	
 ELSE IF ((@ItemID=' ') and (@IssueDate!=' '))
BEGIN	
SELECT MAX(A.[TRID]) AS TRID, 
	       A.[ItemID] AS ItemID,	      
	       A.[IssueDate] AS IssueDate, 
	       A.[LocID] AS [LocID], 	      
	       A.[IsReceive] AS IsReceive   
	       FROM [ITInventory].[dbo].[INV_FTYTransfer] as A, [ITInventory].[dbo].[INV_Location] as B
	       WHERE 	
	       (A.LocID=B.LocID AND B.Location=@Location)       
	       AND	      
	       IssueDate=@IssueDate GROUP BY  A.IssueDate, A.ItemID, A.LocID, A.IsReceive ORDER BY A.IssueDate DESC
END
ELSE 
BEGIN	
SELECT MAX(A.[TRID]) AS TRID, 
	       A.[ItemID] AS ItemID,	      
	       A.[IssueDate] AS IssueDate, 
	       A.[LocID] AS [LocID], 	      
	       A.[IsReceive] AS IsReceive   
	       FROM [ITInventory].[dbo].[INV_FTYTransfer] as A, [ITInventory].[dbo].[INV_Location] as B
	       WHERE 	
	       (A.LocID=B.LocID AND B.Location=@Location)       
	       AND
	       (IssueDate=@IssueDate and  ItemID=@ItemID)	   GROUP BY  A.IssueDate, A.ItemID, A.LocID, A.IsReceive ORDER BY A.IssueDate DESC     
END
END
ELSE IF ((@Location='HLNT' and @Userstatus='OPEX') OR (@Location='HLAP' and @Userstatus='OPEX')OR (@Location='HLBD' and @Userstatus='OPEX') OR (@Location='HLRC' and @Userstatus='OPEX') OR (@Location='HLWF' and @Userstatus='OPEX') OR (@Location='HYBD' and @Userstatus='OPEX'))
BEGIN
IF((@ItemID!=' ') and (@IssueDate=' '))	
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
SELECT MAX(A.[TRID]) AS TRID, 
	       A.[ItemID] AS ItemID,	      
	       A.[IssueDate] AS IssueDate, 
	       A.[LocID] AS [LocID], 	      
	       A.[IsReceive] AS IsReceive   
	       FROM [ITInventory].[dbo].[INV_FTYTransfer] as A, [ITInventory].[dbo].[INV_Location] as B
	       WHERE 	
	       (A.LocID=B.LocID AND B.Location=@Location)       
	       AND
	       ItemID=@ItemID	 GROUP BY  A.IssueDate, A.ItemID, A.LocID, A.IsReceive ORDER BY A.IssueDate DESC     
END	
 ELSE IF ((@ItemID=' ') and (@IssueDate!=' '))
BEGIN	
SELECT MAX(A.[TRID]) AS TRID, 
	       A.[ItemID] AS ItemID,	      
	       A.[IssueDate] AS IssueDate, 
	       A.[LocID] AS [LocID], 	      
	       A.[IsReceive] AS IsReceive   
	       FROM [ITInventory].[dbo].[INV_FTYTransfer] as A, [ITInventory].[dbo].[INV_Location] as B
	       WHERE 	
	       (A.LocID=B.LocID AND B.Location=@Location)       
	       AND	      
	       IssueDate=@IssueDate GROUP BY  A.IssueDate, A.ItemID, A.LocID, A.IsReceive ORDER BY A.IssueDate DESC
END
ELSE 
BEGIN	
SELECT MAX(A.[TRID]) AS TRID, 
	       A.[ItemID] AS ItemID,	      
	       A.[IssueDate] AS IssueDate, 
	       A.[LocID] AS [LocID], 	      
	       A.[IsReceive] AS IsReceive   
	       FROM [ITInventory].[dbo].[INV_FTYTransfer] as A, [ITInventory].[dbo].[INV_Location] as B
	       WHERE 	
	       (A.LocID=B.LocID AND B.Location=@Location)       
	       AND
	       (IssueDate=@IssueDate and  ItemID=@ItemID)	GROUP BY  A.IssueDate, A.ItemID, A.LocID, A.IsReceive ORDER BY A.IssueDate DESC        
END
END

ELSE
BEGIN
IF((@ItemID!=' ') and (@IssueDate=' '))	
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
SELECT MAX(A.[TRID]) AS TRID, 
	       A.[ItemID] AS ItemID,	      
	       A.[IssueDate] AS IssueDate, 
	       A.[LocID] AS [LocID], 	      
	       A.[IsReceive] AS IsReceive   
	       FROM [ITInventory].[dbo].[INV_FTYTransfer] as A, [ITInventory].[dbo].[INV_Location] as B
	       WHERE 	
	       (A.LocID=B.LocID AND B.Location=LEFT(Location,4))       
	       AND
	       ItemID=@ItemID	    GROUP BY  A.IssueDate, A.ItemID, A.LocID, A.IsReceive ORDER BY A.IssueDate DESC  
END	
 ELSE IF ((@ItemID=' ') and (@IssueDate!=' '))
BEGIN	
SELECT MAX(A.[TRID]) AS TRID, 
	       A.[ItemID] AS ItemID,	      
	       A.[IssueDate] AS IssueDate, 
	       A.[LocID] AS [LocID], 	      
	       A.[IsReceive] AS IsReceive   
	       FROM [ITInventory].[dbo].[INV_FTYTransfer] as A, [ITInventory].[dbo].[INV_Location] as B
	       WHERE 	
	       (A.LocID=B.LocID AND B.Location=LEFT(Location,4))       
	       AND	      
	       IssueDate=@IssueDate GROUP BY  A.IssueDate, A.ItemID, A.LocID, A.IsReceive ORDER BY A.IssueDate DESC
END
ELSE 
BEGIN	
SELECT MAX(A.[TRID]) AS TRID, 
	       A.[ItemID] AS ItemID,	      
	       A.[IssueDate] AS IssueDate, 
	       A.[LocID] AS [LocID], 	      
	       A.[IsReceive] AS IsReceive   
	       FROM [ITInventory].[dbo].[INV_FTYTransfer] as A, [ITInventory].[dbo].[INV_Location] as B
	       WHERE 	
	       (A.LocID=B.LocID AND B.Location=LEFT(Location,4))       
	       AND
	       (IssueDate=@IssueDate and  ItemID=@ItemID)	 GROUP BY  A.IssueDate, A.ItemID, A.LocID, A.IsReceive ORDER BY A.IssueDate DESC       
END
END
