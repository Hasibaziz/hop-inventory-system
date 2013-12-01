USE [ITInventory]
GO
/****** Object:  StoredProcedure [dbo].[spMEfficincy]    Script Date: 12/01/2013 12:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spMEfficincy]
                --@YEARS AS VARCHAR(20)	
AS
DECLARE @Totaldays DECIMAL (18, 2)
DECLARE @Years     VARCHAR(20)
--SET @Totaldays=(datediff(day,DATEADD(YEAR, DATEDIFF(YEAR, 0,DATEADD(YEAR, 0,GETDATE())), 0),GETDATE())+1)
SET @Totaldays=(datediff(day,DATEADD(YEAR, DATEDIFF(YEAR, 0,DATEADD(YEAR, 0,CONVERT(DATE, '08/31/2013'))), 0),CONVERT(DATE, '08/31/2013'))+1)
SET @Years='2013'


BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
 SELECT 
    A.ENumber
    ,SUM(B.Idledays) AS Idledays
    ,CAST(((@Totaldays-SUM(B.Idledays))/@Totaldays)*100 as DECIMAL (18, 2)) as Efficiency
    ,B.YEARS
 from 
    dbo.Inv_Equipmentinfo AS A
    ,dbo.Inv_Idleentry AS B 
 where 
     B.YEARS=@Years
 AND 
     A.EID=B.EID  
 GROUP BY 
     A.ENumber
    ,B.YEARS
END
