

/****** Object:  Table [dbo].[INV_ItemReceive]  Script Date: 06/06/2013 19:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[INV_ItemReceive](
	[IRID]            [uniqueidentifier]      NOT NULL,
        [LotNo]           [int] IDENTITY(1,1)     NOT NULL,
        [ItemID]          [uniqueidentifier]      NOT NULL,
        [ModelID]         [uniqueidentifier]      NOT NULL,
        [RDate]           [nvarchar] (50)         NOT NULL,
        [Chlanno]         [nvarchar] (MAX)        NOT NULL,
        [Suppliername]    [nvarchar] (MAX)        NOT NULL,
        [LocID]           [uniqueidentifier]      NOT NULL, 
        [Quantity]        [int]                       NULL, 
       
       
  
        FOREIGN KEY (ItemID) REFERENCES INV_Items(ItemID),
        FOREIGN KEY (ModelID) REFERENCES INV_Models(ModelID),
        FOREIGN KEY (LocID)   REFERENCES   [INV_Location](LocID),
		
 CONSTRAINT [PK_INV_ItemReceive] PRIMARY KEY CLUSTERED 
([IRID] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[INV_ItemReceive] ADD  CONSTRAINT [DF_INV_ItemReceive_IRID]  DEFAULT (newid()) FOR [IRID]
GO


