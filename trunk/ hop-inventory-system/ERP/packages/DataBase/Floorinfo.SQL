use ITInventory

/****** Object:  Table [dbo].[INV_Floorinfo]  Script Date: 09/03/2012 19:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[INV_Floorinfo](
	[FID]            [uniqueidentifier]   NOT NULL,
        [FloorName]      [nvarchar] (100)     NOT NULL, 
        [BNID]           [uniqueidentifier]   NOT NULL,
        
        FOREIGN KEY (BNID)    REFERENCES INV_Buildinginfo      (BNID),
       
		
 CONSTRAINT [PK_INV_Floorinfo] PRIMARY KEY CLUSTERED 
([FID] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[INV_Floorinfo] ADD  CONSTRAINT [DF_INV_Floorinfo_FID]  DEFAULT (newid()) FOR [FID]
GO


