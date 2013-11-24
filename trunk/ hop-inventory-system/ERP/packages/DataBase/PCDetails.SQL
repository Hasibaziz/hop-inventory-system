use ITInventory

/****** Object:  Table [dbo].[INV_PCDetails]  Script Date: 09/03/2012 19:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[INV_PCDetails](
	[PCDetailsID] [uniqueidentifier] NOT NULL,
	[PCID] [uniqueidentifier] NOT NULL,
        [MonitorID] [uniqueidentifier] NOT NULL,
	[HardID] [uniqueidentifier] NOT NULL,
	[MotherID] [uniqueidentifier] NOT NULL,
	[ProcessID] [uniqueidentifier] NOT NULL,
	[RamID] [uniqueidentifier] NOT NULL,
        [UPSID] [uniqueidentifier] NOT NULL,	
        [DeptID] [uniqueidentifier] NOT NULL,
        [UserID] [uniqueidentifier] NOT NULL,
        [WindowsKey] [nvarchar](100) NULL,
        [IPMAC] [nvarchar](100) NULL,
	[HostName] [nvarchar](100) NULL,

	FOREIGN KEY (PCID) REFERENCES INV_PCInformation (PCID),
        
	
 CONSTRAINT [PK_INV_PCDetails] PRIMARY KEY CLUSTERED 
([PCDetailsID] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[INV_PCDetails] ADD  CONSTRAINT [DF_INV_PCDetails_PCDetailsID]  DEFAULT (newid()) FOR [PCDetailsID]
GO


