

/****** Object:  Table [dbo].[INV_FTYTransfer]  Script Date: 06/06/2013 19:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[INV_FTYTransfer](
	[TRID]        [int]   IDENTITY(1,1)   NOT NULL,
        [ItemID]      [uniqueidentifier]      NOT NULL,              
        [IssueDate]   [nvarchar] (50)         NOT NULL,        
        [LocID]       [uniqueidentifier]      NOT NULL,      
        [IsReceive]   [bit]                   NOT NULL,
       
  
        FOREIGN KEY (ItemID) REFERENCES INV_Items(ItemID),       
        FOREIGN KEY (LocID)  REFERENCES   [INV_Location](LocID),

		
 CONSTRAINT [PK_INV_FTYTransfer] PRIMARY KEY CLUSTERED 
([TRID] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[INV_FTYTransfer] ADD  CONSTRAINT [DF_INV_FTYTransfer_TRID]  DEFAULT (newid()) FOR [TRID]
GO


