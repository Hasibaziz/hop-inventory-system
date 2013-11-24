

/****** Object:  Table [dbo].[INV_Models]  Script Date: 05/06/2013 19:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[INV_Models](
	[ModelID]     [uniqueidentifier]      NOT NULL,
        [ItemID]      [uniqueidentifier]      NOT NULL,
        [ModelName]   [nvarchar] (MAX)        NOT NULL,
        [ModelDate]   [nvarchar] (50)         NOT NULL,
        [ExDate]      [nvarchar] (50)         NULL,
        [TPage]       [int]                       NULL, 
        [Description] [nvarchar] (MAX)            NULL,
       
       
  
        FOREIGN KEY (ItemID) REFERENCES INV_Items(ItemID),
		
 CONSTRAINT [PK_INV_Models] PRIMARY KEY CLUSTERED 
([ModelID] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[INV_Models] ADD  CONSTRAINT [DF_INV_Models_ModelID]  DEFAULT (newid()) FOR [ModelID]
GO


