use ITInventory

/****** Object:  Table [dbo].[INV_Department]  Script Date: 09/03/2012 19:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[INV_Department](
	[DeptID] [uniqueidentifier] NOT NULL,
        [DeptNo] [nvarchar] (100) NOT NULL, 
	[DeptName] [nvarchar] (100) NOT NULL, 
	[Description] [nvarchar](100) NULL,


        FOREIGN KEY (DeptID) REFERENCES INV_EmployeeInfo     (DeptID),
        FOREIGN KEY (DeptID) REFERENCES Inv_InventoryInfo    (DeptID),
        FOREIGN KEY (DeptID) REFERENCES INV_PrinterDetails   (DeptID), 
        FOREIGN KEY (DeptID) REFERENCES INV_MonitorDetails   (DeptID),
        FOREIGN KEY (DeptID) REFERENCES INV_UPSDetails       (DeptID),
        
	
		
 CONSTRAINT [PK_INV_Department] PRIMARY KEY CLUSTERED 
([DeptID] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[INV_Department] ADD  CONSTRAINT [DF_INV_Department_DeptID]  DEFAULT (newid()) FOR [DeptID]
GO


