use ITInventory

/****** Object:  Table [dbo].[INV_Location]  Script Date: 09/03/2012 19:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[INV_Location](
	[LocID]         [uniqueidentifier]    NOT NULL,
        [Location]      [nvarchar] (MAX)      NOT NULL, 
        [CountryID]	[uniqueidentifier]    NOT NULL,
	[Description]   [nvarchar](100)           NULL,  

        FOREIGN KEY (CountryID)  REFERENCES INV_Country    (CID),     
        
	
		
 CONSTRAINT [PK_INV_Location] PRIMARY KEY CLUSTERED 
([LocID] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[INV_Location] ADD  CONSTRAINT [DF_INV_Location_LocID]  DEFAULT (newid()) FOR [LocID]
GO


