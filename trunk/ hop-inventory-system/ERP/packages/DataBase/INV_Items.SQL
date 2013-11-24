

/****** Object:  Table [dbo].[INV_Items]  Script Date: 05/06/2013 19:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[INV_Items](
	[ItemID]  [uniqueidentifier]      NOT NULL,
        [ItemName]     [nvarchar] (MAX)   NOT NULL,
        [ItemDate]     [nvarchar] (50)    NOT NULL,
        [Description]  [nvarchar] (MAX)   NULL,
       
       
  
	
		
 CONSTRAINT [PK_INV_Items] PRIMARY KEY CLUSTERED 
([ItemID] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[INV_Items] ADD  CONSTRAINT [DF_INV_Items_ItemID]  DEFAULT (newid()) FOR [ItemID]
GO


