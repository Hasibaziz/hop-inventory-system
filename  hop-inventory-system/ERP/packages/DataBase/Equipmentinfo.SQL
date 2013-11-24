USE [ITInventory]
GO
/****** Object:  Table [dbo].[Inv_Equipmentinfo]    Script Date: 09/19/2012 13:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inv_Equipmentinfo](
	[EID]                [uniqueidentifier] NOT NULL,
        [LocID]              [uniqueidentifier] NOT NULL,
        [ENumber]            [nvarchar](MAX)    NOT NULL,
        [AccountCode]        [nvarchar](100)        NULL,
        [AssetCode]          [nvarchar](100)    NOT NULL,
        [Brand]              [nvarchar](100)        NULL,
	[Model]              [nvarchar](100)        NULL,
	[Serialno]           [nvarchar](100)        NULL,
        [Subserialno]        [nvarchar](100)        NULL,
	[MNID]               [uniqueidentifier] NOT NULL,
        [Machineid]          [nvarchar](200)        NULL,
	[Lifetime]           [nvarchar](100)        NULL,	
	[PurchDate]          [nvarchar](50)     NOT NULL,	
        [UnitID]             [uniqueidentifier] NOT NULL,
        [BNID]               [uniqueidentifier] NOT NULL,
        [Floorno]            [nvarchar](50)         NULL,
        [Lineno]             [nvarchar](50)         NULL,
	[Status]             [nvarchar](100)        NULL,
        [Remarks]            [nvarchar](100)        NULL,
        [CID]                [uniqueidentifier] NOT NULL,
	
       
       
       

        FOREIGN KEY (UnitID)  REFERENCES INV_Unitentry         (UnitID),
        FOREIGN KEY (LocID)   REFERENCES INV_Location          (LocID),
        FOREIGN KEY (CID)     REFERENCES INV_Country           (CID),
        FOREIGN KEY (MNID)    REFERENCES INV_Machinename       (MNID),
        FOREIGN KEY (BNID)    REFERENCES INV_Buildinginfo      (BNID),

       

 CONSTRAINT [PK_Inv_Equipmentinfo] PRIMARY KEY CLUSTERED 
(
	[EID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Inv_Equipmentinfo] ADD  CONSTRAINT [DF_Inv_Equipmentinfo_EID]  DEFAULT (newid()) FOR [EID]
GO