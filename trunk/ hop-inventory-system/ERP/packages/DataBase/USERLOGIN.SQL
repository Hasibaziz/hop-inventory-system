

/****** Object:  Table [dbo].[Login_info]  Script Date: 09/03/2012 19:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].   [Login_info](
	[UserID]      [nvarchar] (100)    NOT NULL, 
        [UserName]    [nvarchar] (100)    NOT NULL, 
	[Password]    [nvarchar] (100)    NOT NULL,
        [Usermail]    [nvarchar] (100)    NOT NULL,
	[LocID]       [uniqueidentifier]  NOT NULL, 
        [Createdate]  [nvarchar] (100)    NOT NULL,
        [UsersStatus] [nvarchar] (100)    NOT NULL,
  
	
		
 CONSTRAINT [PK_Login_info] PRIMARY KEY CLUSTERED 
([UserID] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Login_info] ADD  CONSTRAINT [DF_Login_info_UserID]  DEFAULT (newid()) FOR [UserID]
GO


