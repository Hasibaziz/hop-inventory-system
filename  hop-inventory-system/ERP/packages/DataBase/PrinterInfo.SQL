use ITInventory

/****** Object:  Table [dbo].[INV_PrinterDetails]  Script Date: 09/03/2012 19:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[INV_PrinterDetails](
	[PrinterID] [uniqueidentifier] NOT NULL,
        [AccountCode] [nvarchar](100) NULL,
	[PrinterName] [nvarchar] (100)  NULL, 
	[ModelNo] [nvarchar](100) NULL,
	[SerialNo] [nvarchar](100) NULL,
        [IPMAC] [nvarchar](100) NULL,
        [PurchDate] [datetime]  NULL,
        [DeptID] [uniqueidentifier] NOT NULL,
        [DistDate] [datetime]  NULL,
        [Type] [nvarchar](100) NULL,
        [Totaluser][nvarchar](100) NULL,
        [Dailyppage][nvarchar](100) NULL,
        [DeviceID][uniqueidentifier] NOT NULL,

        FOREIGN KEY (DeptID) REFERENCES INV_Department (DeptID),
        FOREIGN KEY (DeviceID) REFERENCES INV_Devices (DeviceID),
		
 CONSTRAINT [PK_INV_PrinterDetails] PRIMARY KEY CLUSTERED 
([PrinterID] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[INV_PrinterDetails] ADD  CONSTRAINT [DF_INV_PrinterDetails_PrinterID]  DEFAULT (newid()) FOR [PrinterID]
GO


