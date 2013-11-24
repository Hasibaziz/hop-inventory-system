use ITInventory

/****** Object:  Table [dbo].[INV_Buildinginfo]  Script Date: 09/03/2012 19:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[INV_Buildinginfo](
	[BNID]            [uniqueidentifier]   NOT NULL,
        [BuildingName]    [nvarchar] (100)     NOT NULL, 
        [LocID]           [uniqueidentifier]   NOT NULL,
        [Description]     [nvarchar] (100)         NULL, 

       
		
 CONSTRAINT [PK_INV_Buildinginfo] PRIMARY KEY CLUSTERED 
([BNID] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[INV_Buildinginfo] ADD  CONSTRAINT [DF_INV_Buildinginfo_BNID]  DEFAULT (newid()) FOR [BNID]
GO


