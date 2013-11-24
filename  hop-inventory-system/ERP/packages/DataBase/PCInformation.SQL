use ITInventory

/****** Object:  Table [dbo].[INV_PCInformation]  Script Date: 09/03/2012 19:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[INV_PCInformation](
	[PCID] [uniqueidentifier] NOT NULL,
	[PCName] [nvarchar] (100) NOT NULL, 
	[Description] [nvarchar](100) NULL,
	
		
 CONSTRAINT [PK_INV_PCInformation] PRIMARY KEY CLUSTERED 
([PCID] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[INV_PCInformation] ADD  CONSTRAINT [DF_INV_PCInformation_PCID]  DEFAULT (newid()) FOR [PCID]
GO


