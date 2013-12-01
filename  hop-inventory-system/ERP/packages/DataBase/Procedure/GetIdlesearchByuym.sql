USE [ITInventory]
GO
/****** Object:  StoredProcedure [dbo].[GetIdlesearchByuym]    Script Date: 12/01/2013 12:24:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Hasib>
-- Create date: <Create Date,,>
-- Description:	<Description,, Idle Days Search>
-- =============================================
ALTER PROCEDURE [dbo].[GetIdlesearchByuym] 
				 @UnitID AS nvarchar(100)
				,@Years  AS nvarchar(100)
				,@Months AS nvarchar(100)
		
AS
IF(@UnitID!=' ') AND (@Years=' ') AND (@Months=' ')
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT	 [IID]
			,[EID]
			,[UnitID]
			,[Years]
			,[Months]
			,[Idledays]
    FROM 
			[ITInventory].[dbo].[Inv_Idleentry] 
    WHERE
			UnitID=@UnitID
			--AND
			--Years=@Years 
			--AND
			--Months=@Months 	         
	     
END
ELSE IF(@UnitID!=' ') AND (@Years!=' ') AND (@Months=' ')
BEGIN
	
	SELECT   [IID]
			,[EID]
			,[UnitID]
			,[Years]
			,[Months]
			,[Idledays]
    FROM 
			[ITInventory].[dbo].[Inv_Idleentry] 
    WHERE
			UnitID=@UnitID
			AND
			Years=@Years 
			--AND
			--Months=@Months     
	     
END
ELSE IF (@UnitID!=' ') AND (@Years!=' ') AND (@Months!=' ')
BEGIN
	
	SELECT   [IID]
			,[EID]
			,[UnitID]
			,[Years]
			,[Months]
			,[Idledays]
    FROM 
			[ITInventory].[dbo].[Inv_Idleentry] 
    WHERE
			UnitID=@UnitID
			AND
			Years=@Years 
			AND
			Months=@Months  
	     
END
ELSE
BEGIN
	
	SELECT   [IID]
			,[EID]
			,[UnitID]
			,[Years]
			,[Months]
			,[Idledays]
    FROM 
			[ITInventory].[dbo].[Inv_Idleentry] 
    WHERE
			UnitID=@UnitID
			--AND
			--Years=@Years 
			--AND
			--Months=@Months  
	     
END
