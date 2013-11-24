use ITInventory

/****** Object:  Table [dbo].[INV_EmployeeInfo]  Script Date: 09/03/2012 19:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[INV_EmployeeInfo](
	[EmpID] [uniqueidentifier] NOT NULL,
        [EmpNo] [nvarchar] (100) NOT NULL, 
	[EmpName] [nvarchar] (100) NOT NULL, 
	[DeptID] [uniqueidentifier] NOT NULL,
        [Location][nvarchar] (100) NOT NULL, 
        [JoinDate] [datetime] NOT NULL,

        FOREIGN KEY (DeptID) REFERENCES INV_Department (DeptID),
	FOREIGN KEY (EmpID)  REFERENCES Inv_InventoryInfo(EmpID),
        FOREIGN KEY (EmpID)  REFERENCES INV_MonitorDetails(EmpID),
        FOREIGN KEY (EmpID)  REFERENCES INV_UPSDetails(EmpID),
	
	
 CONSTRAINT [PK_INV_EmployeeInfo] PRIMARY KEY CLUSTERED 
([EmpID] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[INV_EmployeeInfo] ADD  CONSTRAINT [DF_INV_EmployeeInfo_EmpID]  DEFAULT (newid()) FOR [EmpID]
GO


