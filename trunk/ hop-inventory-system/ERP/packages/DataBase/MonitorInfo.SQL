use ITInventory

/****** Object:  Table [dbo].[INV_MonitorDetails]  Script Date: 09/03/2012 19:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[INV_MonitorDetails](
	[MonitorID]        [uniqueidentifier]        NOT NULL,
	[MonitorName]      [nvarchar] (100)              NULL, 
	[ModelNo]          [nvarchar](100)               NULL,
	[SerialNo]         [nvarchar](100)               NULL,
        [PurchDate]        [nvarchar](50)                NULL,
        [DeptID]           [uniqueidentifier]        NOT NULL,
        [EmpID]            [uniqueidentifier]        NOT NULL,
        [DistDate]         [nvarchar](50)                NULL,
        [Description]      [nvarchar](100)               NULL,

        FOREIGN KEY (DeptID) REFERENCES INV_Department   (DeptID),
        FOREIGN KEY (EmpID)  REFERENCES INV_EmployeeInfo (EmpID),
		
 CONSTRAINT [PK_INV_MonitorDetails] PRIMARY KEY CLUSTERED 
([MonitorID] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[INV_MonitorDetails] ADD  CONSTRAINT [DF_INV_MonitorDetails_MonitorID]  DEFAULT (newid()) FOR [MonitorID]
GO
