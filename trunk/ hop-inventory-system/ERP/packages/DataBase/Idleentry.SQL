USE [ITInventory]
GO
/****** Object:  Table [dbo].[Inv_Idleentry]    Script Date: 09/19/2012 13:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inv_Idleentry](
	[IID]                [uniqueidentifier] NOT NULL,
        [EID]                [uniqueidentifier] NOT NULL,
        [UnitID]             [uniqueidentifier] NOT NULL,
        [Years]              [nvarchar](100)    NOT NULL,
	[Months]             [nvarchar](50)     NOT NULL,
	[Idledays]           [int]                  NULL,
	
	
       
       
       

        FOREIGN KEY (EID)    REFERENCES Inv_Equipmentinfo        (EID),
        FOREIGN KEY (UnitID) REFERENCES INV_Unitentry            (UnitID),
       

 CONSTRAINT [PK_Inv_Idleentry] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Inv_Idleentry] ADD  CONSTRAINT [DF_Inv_Idleentry_IID]  DEFAULT (newid()) FOR [IID]
GO