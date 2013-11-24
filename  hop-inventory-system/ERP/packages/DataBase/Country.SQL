use ITInventory

/****** Object:  Table [dbo].[INV_Country]  Script Date: 09/03/2012 19:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[INV_Country](
	[CID]         [uniqueidentifier] NOT NULL,
        [Name]        [nvarchar] (MAX)   NOT NULL, 	
	[Description] [nvarchar](100)        NULL,       
        
	
		
 CONSTRAINT [PK_INV_Country] PRIMARY KEY CLUSTERED 
([CID] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[INV_Country] ADD  CONSTRAINT [DF_INV_Country_CID]  DEFAULT (newid()) FOR [CID]
GO


