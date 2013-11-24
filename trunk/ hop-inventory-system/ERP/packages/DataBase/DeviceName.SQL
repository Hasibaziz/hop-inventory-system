use ITInventory

/****** Object:  Table [dbo].[INV_Devices]  Script Date: 09/03/2012 19:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[INV_Devices](
	[DeviceID] [uniqueidentifier] NOT NULL,
        [DeviceName] [nvarchar] (100) NOT NULL, 

       
		
 CONSTRAINT [PK_INV_Devices] PRIMARY KEY CLUSTERED 
([DeviceID] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[INV_Devices] ADD  CONSTRAINT [DF_INV_Devices_DeviceID]  DEFAULT (newid()) FOR [DeviceID]
GO


