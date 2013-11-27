

/****** Object:  Table [dbo].[INV_Stock]  Script Date: 06/06/2013 19:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[INV_Stock](
	[SID]            [uniqueidentifier]      NOT NULL,
        [ItemID]         [uniqueidentifier]      NOT NULL,
        [ModelID]        [uniqueidentifier]      NOT NULL,
        [SDate]          [nvarchar] (50)         NOT NULL,
        [IDate]          [nvarchar] (50)         NOT NULL,
        [IssueQty]       [int]                       NULL,
        [TOTALRQty]      [int]                       NULL, 
        [TOTALIQty]      [int]                       NULL, 
--        [LocID]          [uniqueidentifier]      NOT NULL,
        [BalanceQty]     [int]                       NULL, 
       
       
  
        FOREIGN KEY (ItemID) REFERENCES  INV_Items(ItemID),
        FOREIGN KEY (ModelID) REFERENCES INV_Models(ModelID),
--        FOREIGN KEY (LocID)  REFERENCES  INV_Location(LocID),

		
 CONSTRAINT [PK_INV_Stock] PRIMARY KEY CLUSTERED 
([SID] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[INV_Stock] ADD  CONSTRAINT [DF_INV_Stock_SID]  DEFAULT (newid()) FOR [SID]
GO


