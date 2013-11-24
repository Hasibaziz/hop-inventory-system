USE [ITInventory]
GO
/****** Object:  Table [dbo].[Inv_InventoryInfo]    Script Date: 09/19/2012 13:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inv_InventoryInfo](
	[AccountID]          [uniqueidentifier] NOT NULL,
        [ENumber]            [nvarchar](MAX)    NOT NULL,
	[AccountCode]        [nvarchar](100)        NULL,
	[BrandModel]         [nvarchar](100)        NULL,
	[Category]           [nvarchar](100)        NULL,
	[Configuration]      [nvarchar](200)        NULL,
	[SerialNo]           [nvarchar](100)        NULL,
	[Location]           [nvarchar](100)        NULL,
	[EMPID]              [uniqueidentifier] NOT NULL,
	[PurchDate]          [nvarchar](50)     NOT NULL,
	[Remark]             [nvarchar](100)        NULL,
	[MonitorID]          [nvarchar](100)        NULL,
	[UPSID]              [nvarchar](100)        NULL,
	[DeptID]             [uniqueidentifier] NOT NULL,
	[Team]               [nvarchar](100)        NULL,
	[Status]             [nvarchar](100)        NULL,
	[HostName]           [nvarchar](100)        NULL,
	[ITemNo]             [nvarchar](100)        NULL,
        [Proposed]           [nvarchar](MAX)        NULL,
        [Office]             [nvarchar](MAX)        NULL,
        [DeviceID]           [uniqueidentifier] NOT NULL,

        FOREIGN KEY (DeptID) REFERENCES INV_Department     (DeptID),
        FOREIGN KEY (EmpID)  REFERENCES INV_EmployeeInfo   (EmpID),
        FOREIGN KEY (DeviceID)  REFERENCES INV_Devices   (DeviceID),

 CONSTRAINT [PK_Inv_InventoryInfo] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Inv_InventoryInfo] ADD  CONSTRAINT [DF_Inv_InventoryInfo_AccountID]  DEFAULT (newid()) FOR [AccountID]
GO