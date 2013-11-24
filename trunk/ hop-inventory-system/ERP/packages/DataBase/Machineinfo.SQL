use ITInventory

/****** Object:  Table [dbo].[INV_Machineinfo]  Script Date: 09/03/2012 19:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[INV_Machineinfo](
	[MNID] [uniqueidentifier] NOT NULL,
        [MachineName] [nvarchar] (100) NOT NULL, 
        [Description] [nvarchar] (100) NOT NULL, 

       
		
 CONSTRAINT [PK_INV_Machineinfo] PRIMARY KEY CLUSTERED 
([MNID] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[INV_Machineinfo] ADD  CONSTRAINT [DF_INV_Machineinfo_MNID]  DEFAULT (newid()) FOR [MNID]
GO


