use ITInventory

/****** Object:  Table [dbo].[INV_Lineinfo]  Script Date: 09/03/2012 19:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[INV_Lineinfo](
	[LID]            [uniqueidentifier]   NOT NULL,
        [LineName]       [nvarchar] (100)     NOT NULL, 
        [FID]            [uniqueidentifier]   NOT NULL,
        

       FOREIGN KEY (FID)    REFERENCES INV_Floorinfo      (FID), 
		
 CONSTRAINT [PK_INV_Lineinfo] PRIMARY KEY CLUSTERED 
([LID] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[INV_Lineinfo] ADD  CONSTRAINT [DF_INV_Lineinfo_LID]  DEFAULT (newid()) FOR [LID]
GO


