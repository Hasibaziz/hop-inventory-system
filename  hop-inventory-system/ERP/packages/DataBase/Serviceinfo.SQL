

/****** Object:  Table [dbo].[INV_Service]  Script Date: 10/10/2013 19:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[INV_Service](
	[ServiceID]     [uniqueidentifier]      NOT NULL, 
        [AccountID]     [uniqueidentifier]      NOT NULL, 
        [LocID]         [uniqueidentifier]      NOT NULL,      
        [Servicedate]   [nvarchar] (50)             NULL,
        [Mlifetime]     [nvarchar] (20)             NULL,
        [Description]   [nvarchar] (MAX)            NULL,
       
        FOREIGN KEY (AccountID) REFERENCES Inv_InventoryInfo     (AccountID),
        FOREIGN KEY (LocID)     REFERENCES INV_Location          (LocID),
        
		
 CONSTRAINT [PK_INV_Service] PRIMARY KEY CLUSTERED 
([ServiceID] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[INV_Service] ADD  CONSTRAINT [DF_INV_Service_ServiceID]  DEFAULT (newid()) FOR [ServiceID]
GO