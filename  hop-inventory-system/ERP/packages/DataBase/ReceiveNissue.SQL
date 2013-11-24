

/****** Object:  Table [dbo].[INV_ItemReceive]  Script Date: 06/06/2013 19:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[INV_ReceiveNissue](
	[RIssueID]       [uniqueidentifier]      NOT NULL,
        [ItemID]         [uniqueidentifier]      NOT NULL,
        [ModelID]        [uniqueidentifier]      NOT NULL,
        [ReceiveQty]     [int]                       NULL, 
        [IssueDate]      [nvarchar] (50)         NOT NULL,
        [ReceiverName]   [nvarchar] (MAX)        NOT NULL,
        [ReceiverEmail]  [nvarchar] (MAX)        NOT NULL,
        [Transportno]    [nvarchar] (MAX)        NOT NULL,
        [LocID]          [uniqueidentifier]      NOT NULL,
        [IssueQty]       [int]                       NULL, 
        [BalanceQty]     [int]                       NULL, 
       
       
  
        FOREIGN KEY (ItemID) REFERENCES INV_Items(ItemID),
        FOREIGN KEY (ModelID) REFERENCES INV_Models(ModelID),
        FOREIGN KEY (LocID)  REFERENCES   [INV_Location](LocID),

		
 CONSTRAINT [PK_INV_ReceiveNissue] PRIMARY KEY CLUSTERED 
([RIssueID] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[INV_ReceiveNissue] ADD  CONSTRAINT [DF_INV_ReceiveNissue_RIssueID]  DEFAULT (newid()) FOR [RIssueID]
GO


