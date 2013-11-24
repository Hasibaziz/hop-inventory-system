use ITInventory

/****** Object:  Table [dbo].[INV_UPSDetails]  Script Date: 09/03/2012 19:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[INV_UPSDetails](
	[UPSID]             [uniqueidentifier]       NOT NULL,
	[UPSName]           [nvarchar] (100)             NULL, 
	[ModelNo]           [nvarchar](100)              NULL,
	[SerialNo]          [nvarchar](100)              NULL,
        [PurchDate]         [nvarchar](50)               NULL,
        [DeptID]            [uniqueidentifier]       NOT NULL,
        [EmpID]             [uniqueidentifier]       NOT NULL,
        [DistDate]          [nvarchar](50)               NULL,
        [Description]       [nvarchar](100)              NULL,

        FOREIGN KEY (DeptID) REFERENCES INV_Department   (DeptID),
        FOREIGN KEY (EmpID)  REFERENCES INV_EmployeeInfo (EmpID),
		
 CONSTRAINT [PK_INV_UPSDetails] PRIMARY KEY CLUSTERED 
([UPSID] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[INV_UPSDetails] ADD  CONSTRAINT [DF_INV_UPSDetails_UPSID]  DEFAULT (newid()) FOR [UPSID]
GO
