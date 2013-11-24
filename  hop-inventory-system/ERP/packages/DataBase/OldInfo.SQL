USE [ITInventory]
GO
/****** Object:  Table [dbo].[Inv_OLDInfo]    Script Date: 09/19/2012 13:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inv_OLDInfo](
	[OLDID] [uniqueidentifier] NOT NULL,
	[CPUID] [nvarchar](100) NULL,
	[CPUCONFIG] [nvarchar](100) NULL,
	[MONITORID] [nvarchar](100) NULL,
	[UPSID] [nvarchar](200) NULL,
	[EMPID] [uniqueidentifier] NOT NULL,
	[Dateofplace] [date] NULL,
	
        FOREIGN KEY (EmpID)  REFERENCES INV_EmployeeInfo   (EmpID),
        

 CONSTRAINT [PK_Inv_OLDInfo] PRIMARY KEY CLUSTERED 
(
	[OLDID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Inv_OLDInfo]   ADD  CONSTRAINT [DF_Inv_OLDInfo_OLDID]  DEFAULT (newid()) FOR [OLDID]
GO