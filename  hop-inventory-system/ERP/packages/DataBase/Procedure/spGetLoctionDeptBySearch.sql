USE [ITInventory]
GO
/****** Object:  StoredProcedure [dbo].[spGetLoctionDeptBySearch]    Script Date: 08/25/2013 10:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spGetLoctionDeptBySearch]	
				  @Location AS nvarchar(100)
				, @DeptName AS nvarchar(100)
				
AS
--IF((@Location='HLNT' OR @Location='HLAP' OR @Location='HLBD' OR @Location='HLRC' OR @Location='HLWF' OR @Location='HYBD') and @DeptName='Please Select...')
--******** For only Location Selection
IF(@Location!='Please Select...') and (@DeptName='Please Select...')
	
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
    SELECT    A.Office
			, A.Proposed
			, A.AccountID
			, A.AccountCode
			, A.BrandModel
			, A.Category
			, A.Configuration
			, A.SerialNo
			, A.Location
			, A.DeptID
			, A.EMPID
			, A.EMPID AS EMPNAME
			, convert(date, A.PurchDate,103) as PurchDate
			, A.Remark
			, B.SerialNo AS MonitorID
			, C.SerialNo AS UPSID
			, A.Team, A.Status
			, A.HostName
			, A.ITemNo
			, A.DeviceID 
			FROM ITInventory.dbo.INV_InventoryInfo as A 
				LEFT OUTER JOIN ITInventory.dbo.INV_MonitorDetails AS B ON A.EMPID=B.EMPID 
				LEFT OUTER JOIN ITInventory.dbo.INV_UPSDetails AS C ON A.EMPID=C.EMPID 
				LEFT OUTER JOIN ITInventory.dbo.INV_EmployeeInfo AS E ON A.EMPID=E.EMPID 
				LEFT OUTER JOIN ITInventory.dbo.INV_Department AS D ON A.DeptID=D.DeptID 
			WHERE  
			A.DeviceID='22fc4927-cf7c-4e72-8575-2780eec97126' 
				and 
			A.Location=@Location
END
--*******FOR All Selection
ELSE IF(@Location='Please Select...') AND (@DeptName='Please Select...')

   BEGIN
   SELECT    A.Office
			, A.Proposed
			, A.AccountID
			, A.AccountCode
			, A.BrandModel
			, A.Category
			, A.Configuration
			, A.SerialNo
			, A.Location
			, A.DeptID
			, A.EMPID
			, A.EMPID AS EMPNAME
			, convert(date, A.PurchDate,103) as PurchDate
			, A.Remark
			, B.SerialNo AS MonitorID
			, C.SerialNo AS UPSID
			, A.Team, A.Status
			, A.HostName
			, A.ITemNo
			, A.DeviceID 
			FROM ITInventory.dbo.INV_InventoryInfo as A 
				LEFT OUTER JOIN ITInventory.dbo.INV_MonitorDetails AS B ON A.EMPID=B.EMPID 
				LEFT OUTER JOIN ITInventory.dbo.INV_UPSDetails AS C ON A.EMPID=C.EMPID 
				LEFT OUTER JOIN ITInventory.dbo.INV_EmployeeInfo AS E ON A.EMPID=E.EMPID 
				LEFT OUTER JOIN ITInventory.dbo.INV_Department AS D ON A.DeptID=D.DeptID 
			WHERE  
			A.DeviceID='22fc4927-cf7c-4e72-8575-2780eec97126' 				
END
---******* For Only Department Selection
ELSE IF(@Location='Please Select...') AND (@DeptName!='Please Select...')

 BEGIN
   SELECT    A.Office
			, A.Proposed
			, A.AccountID
			, A.AccountCode
			, A.BrandModel
			, A.Category
			, A.Configuration
			, A.SerialNo
			, A.Location
			, A.DeptID
			, A.EMPID
			, A.EMPID AS EMPNAME
			, convert(date, A.PurchDate,103) as PurchDate
			, A.Remark
			, B.SerialNo AS MonitorID
			, C.SerialNo AS UPSID
			, A.Team, A.Status
			, A.HostName
			, A.ITemNo
			, A.DeviceID 
			FROM ITInventory.dbo.INV_InventoryInfo as A 
				LEFT OUTER JOIN ITInventory.dbo.INV_MonitorDetails AS B ON A.EMPID=B.EMPID 
				LEFT OUTER JOIN ITInventory.dbo.INV_UPSDetails AS C ON A.EMPID=C.EMPID 
				LEFT OUTER JOIN ITInventory.dbo.INV_EmployeeInfo AS E ON A.EMPID=E.EMPID 
				LEFT OUTER JOIN ITInventory.dbo.INV_Department AS D ON A.DeptID=D.DeptID 
			WHERE  
			A.DeviceID='22fc4927-cf7c-4e72-8575-2780eec97126' 
				and 
			D.DeptName=@DeptName
END
ELSE
--- For Location and Department Selection
BEGIN
   SELECT    A.Office
			, A.Proposed
			, A.AccountID
			, A.AccountCode
			, A.BrandModel
			, A.Category
			, A.Configuration
			, A.SerialNo
			, A.Location
			, A.DeptID
			, A.EMPID
			, A.EMPID AS EMPNAME
			, convert(date, A.PurchDate,103) as PurchDate
			, A.Remark
			, B.SerialNo AS MonitorID
			, C.SerialNo AS UPSID
			, A.Team, A.Status
			, A.HostName
			, A.ITemNo
			, A.DeviceID 
			FROM ITInventory.dbo.INV_InventoryInfo as A 
				LEFT OUTER JOIN ITInventory.dbo.INV_MonitorDetails AS B ON A.EMPID=B.EMPID 
				LEFT OUTER JOIN ITInventory.dbo.INV_UPSDetails AS C ON A.EMPID=C.EMPID 
				LEFT OUTER JOIN ITInventory.dbo.INV_EmployeeInfo AS E ON A.EMPID=E.EMPID 
				LEFT OUTER JOIN ITInventory.dbo.INV_Department AS D ON A.DeptID=D.DeptID 
			WHERE  
			A.DeviceID='22fc4927-cf7c-4e72-8575-2780eec97126' 
				and 
			(A.Location=@Location AND D.DeptName=@DeptName)
END