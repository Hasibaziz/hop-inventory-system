

/****** Object:  Table [dbo].[INV_LeaveEntry]  Script Date: 10/10/2013 19:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[INV_LeaveEntry](
	[LEntryID]     [uniqueidentifier]      NOT NULL,        
        [LeaveDays]    [int]                       NULL,
        [Months]       [nvarchar] (20)         NOT NULL,
        [Years]        [nvarchar] (15)         NOT NULL,
        [EntryDate]    [nvarchar] (50)             NULL, 
        [Description]  [nvarchar] (MAX)            NULL,
       
   
        
		
 CONSTRAINT [PK_INV_LeaveEntry] PRIMARY KEY CLUSTERED 
([LEntryID] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[INV_LeaveEntry] ADD  CONSTRAINT [DF_INV_LeaveEntry_LEntryID]  DEFAULT (newid()) FOR [LEntryID]
GO


