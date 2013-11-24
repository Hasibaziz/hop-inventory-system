USE [ITInventory]
GO
/****** Object:  Table [dbo].[Inv_INVServer]    Script Date: 09/19/2012 13:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inv_INVServer](
	[AccountID] [uniqueidentifier] NOT NULL,
	[AccountCode] [nvarchar](100) NULL,
	[BrandModel] [nvarchar](100) NULL,
	[Category] [nvarchar](100) NULL,
	[Configuration] [nvarchar](200) NULL,
	[SerialNo] [nvarchar](100) NULL,
	[Location] [nvarchar](100) NULL,
	[PurchDate] [date] NULL,
	[Remark] [nvarchar](100) NULL,
	[MonitorID] [nvarchar](100) NULL,
	[UPSID] [nvarchar](100) NULL,
	[DeptID] [uniqueidentifier] NOT NULL,
	[Team] [nvarchar](100) NULL,
	[Status] [nvarchar](100) NULL,
	[HostName] [nvarchar](100) NULL,
	[ITENo] [nvarchar](100) NULL,

        FOREIGN KEY (DeptID) REFERENCES INV_Department     (DeptID),
                

 CONSTRAINT [PK_Inv_INVServer] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Inv_INVServer] ADD  CONSTRAINT [DF_Inv_INVServer_AccountID]  DEFAULT (newid()) FOR [AccountID]
GO