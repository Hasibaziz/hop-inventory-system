

/****** Object:  Table [dbo].[INV_ItemIssue]  Script Date: 06/06/2013 19:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[INV_ItemIssue](
	[IID]            [uniqueidentifier]      NOT NULL,
        [ItemID]         [uniqueidentifier]      NOT NULL,
        [ModelID]        [uniqueidentifier]      NOT NULL,
        [IDate]          [nvarchar] (50)         NOT NULL,
        [ReceiverName]   [nvarchar] (MAX)        NOT NULL,
        [LocID]          [uniqueidentifier]      NOT NULL, 
        [IssueQty]       [int]                       NULL, 
       
       
  
        FOREIGN KEY (ItemID) REFERENCES INV_Items(ItemID),
        FOREIGN KEY (ModelID) REFERENCES INV_Models(ModelID),
        FOREIGN KEY (LocID)   REFERENCES   [INV_Location](LocID),
		
 CONSTRAINT [PK_INV_ItemIssue] PRIMARY KEY CLUSTERED 
([IID] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[INV_ItemIssue] ADD  CONSTRAINT [DF_INV_ItemIssue_IID]  DEFAULT (newid()) FOR [IID]
GO


