

/****** Object:  Table [dbo].[INV_Userissue]  Script Date: 06/06/2013 19:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[INV_Userissue](
	[UIssueID]     [uniqueidentifier]      NOT NULL,
        [ItemID]       [uniqueidentifier]      NOT NULL,
        [ModelID]      [uniqueidentifier]      NOT NULL,
        [DeptID]       [uniqueidentifier]      NOT NULL,
        [EmpID]        [uniqueidentifier]      NOT NULL,        
        [LocID]        [uniqueidentifier]      NOT NULL,              
        [UIssueDate]   [nvarchar] (50)         NOT NULL, 
        [uITRFNo]      [nvarchar] (MAX)            NULL,
        [UIssueQty]    [int]                       NULL, 
    
       
       
  
        FOREIGN KEY (ItemID)  REFERENCES   INV_Items(ItemID),
        FOREIGN KEY (ModelID) REFERENCES   INV_Models(ModelID),
        FOREIGN KEY (EmpID)   REFERENCES   INV_EmployeeInfo(EmpID),
        FOREIGN KEY (DeptID)  REFERENCES   INV_Department(DeptID),
        FOREIGN KEY (LocID)   REFERENCES   [INV_Location](LocID),
		
 CONSTRAINT [PK_INV_Userissue] PRIMARY KEY CLUSTERED 
([UIssueID] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[INV_Userissue] ADD  CONSTRAINT [DF_INV_Userissue_UIssueID]  DEFAULT (newid()) FOR [UIssueID]
GO


