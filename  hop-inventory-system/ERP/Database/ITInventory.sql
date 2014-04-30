USE [master]
GO
/****** Object:  Database [ITInventory]    Script Date: 02/27/2014 09:57:27 ******/
CREATE DATABASE [ITInventory] ON  PRIMARY 
( NAME = N'ITInventory', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\ITInventory.mdf' , SIZE = 6144KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ITInventory_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\ITInventory_1.ldf' , SIZE = 22144KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ITInventory] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ITInventory].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ITInventory] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [ITInventory] SET ANSI_NULLS OFF
GO
ALTER DATABASE [ITInventory] SET ANSI_PADDING OFF
GO
ALTER DATABASE [ITInventory] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [ITInventory] SET ARITHABORT OFF
GO
ALTER DATABASE [ITInventory] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [ITInventory] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [ITInventory] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [ITInventory] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [ITInventory] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [ITInventory] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [ITInventory] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [ITInventory] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [ITInventory] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [ITInventory] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [ITInventory] SET  DISABLE_BROKER
GO
ALTER DATABASE [ITInventory] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [ITInventory] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [ITInventory] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [ITInventory] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [ITInventory] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [ITInventory] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [ITInventory] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [ITInventory] SET  READ_WRITE
GO
ALTER DATABASE [ITInventory] SET RECOVERY FULL
GO
ALTER DATABASE [ITInventory] SET  MULTI_USER
GO
ALTER DATABASE [ITInventory] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [ITInventory] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'ITInventory', N'ON'
GO
USE [ITInventory]
GO
/****** Object:  Table [dbo].[UserPC]    Script Date: 02/27/2014 09:57:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPC](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Office] [nvarchar](255) NULL,
	[Department] [nvarchar](255) NULL,
	[Team] [nvarchar](255) NULL,
	[Status] [nvarchar](255) NULL,
	[Proposed] [nvarchar](255) NULL,
	[HostName] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[BrandModel] [nvarchar](255) NULL,
	[ITE No] [nvarchar](255) NULL,
	[Category] [nvarchar](255) NULL,
	[Configuration] [nvarchar](255) NULL,
	[SerialNo] [nvarchar](255) NULL,
	[Location] [nvarchar](255) NULL,
	[User] [nvarchar](255) NULL,
	[UserID] [nvarchar](255) NULL,
	[PurchDate] [datetime] NULL,
	[Remark] [nvarchar](255) NULL,
	[MSL] [nvarchar](255) NULL,
	[MACode] [nvarchar](255) NULL,
	[USL] [nvarchar](255) NULL,
	[UACode] [nvarchar](255) NULL,
	[Device] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Server01]    Script Date: 02/27/2014 09:57:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Server01](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Line #] [float] NULL,
	[Office] [nvarchar](255) NULL,
	[Department] [nvarchar](255) NULL,
	[Team] [nvarchar](255) NULL,
	[Status] [nvarchar](255) NULL,
	[Proposed] [nvarchar](255) NULL,
	[HostName] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[BrandModel] [nvarchar](255) NULL,
	[ITEMNo] [nvarchar](255) NULL,
	[Category] [nvarchar](255) NULL,
	[Configuration] [nvarchar](255) NULL,
	[SerialNo] [nvarchar](255) NULL,
	[Location] [nvarchar](255) NULL,
	[User] [nvarchar](255) NULL,
	[PurchDate] [datetime] NULL,
	[Remarks] [nvarchar](255) NULL,
	[DeviceID] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Printer]    Script Date: 02/27/2014 09:57:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Printer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Line] [float] NULL,
	[Office] [nvarchar](255) NULL,
	[Type] [nvarchar](255) NULL,
	[Department] [nvarchar](255) NULL,
	[Team] [nvarchar](255) NULL,
	[Status] [nvarchar](255) NULL,
	[Proposed] [nvarchar](255) NULL,
	[HostName] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[BrandModel] [nvarchar](255) NULL,
	[ITEMNo] [nvarchar](255) NULL,
	[Category] [nvarchar](255) NULL,
	[Configuration] [nvarchar](255) NULL,
	[SerialNo] [nvarchar](255) NULL,
	[Location] [nvarchar](255) NULL,
	[UserName] [nvarchar](255) NULL,
	[PurchDate] [datetime] NULL,
	[Totaluser] [float] NULL,
	[Dailyppage] [nvarchar](255) NULL,
	[Remarks] [nvarchar](255) NULL,
	[Device] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PC]    Script Date: 02/27/2014 09:57:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PC](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Office] [nvarchar](255) NULL,
	[Department] [nvarchar](255) NULL,
	[Team] [nvarchar](255) NULL,
	[Status] [nvarchar](255) NULL,
	[Proposed] [nvarchar](255) NULL,
	[HostName] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[BrandModel] [nvarchar](255) NULL,
	[ITEMNo] [nvarchar](255) NULL,
	[Category] [nvarchar](255) NULL,
	[Configuration] [nvarchar](255) NULL,
	[SerialNo] [nvarchar](255) NULL,
	[Location] [nvarchar](255) NULL,
	[User] [nvarchar](255) NULL,
	[PurchDate] [datetime] NULL,
	[Remark] [nvarchar](255) NULL,
	[MonitorSL] [nvarchar](255) NULL,
	[MonitorAccCode] [nvarchar](255) NULL,
	[UPSSL] [nvarchar](255) NULL,
	[UPSAccCode] [nvarchar](255) NULL,
	[EMPID] [nvarchar](255) NULL,
	[DEPTID] [nvarchar](255) NULL,
	[DeviceID] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logininfo]    Script Date: 02/27/2014 09:57:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logininfo](
	[UserID] [nvarchar](100) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[Usermail] [nvarchar](100) NOT NULL,
	[LocID] [uniqueidentifier] NOT NULL,
	[Createdate] [nvarchar](100) NOT NULL,
	[UsersStatus] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Logininfo] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login_info]    Script Date: 02/27/2014 09:57:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login_info](
	[UserID] [nvarchar](100) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[Usermail] [nvarchar](100) NOT NULL,
	[Location] [nvarchar](100) NOT NULL,
	[Createdate] [nvarchar](100) NOT NULL,
	[UsersStatus] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Login_info] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Laptop]    Script Date: 02/27/2014 09:57:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Laptop](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Line #] [nvarchar](255) NULL,
	[Office] [nvarchar](255) NULL,
	[Department] [nvarchar](255) NULL,
	[Team] [nvarchar](255) NULL,
	[Status] [nvarchar](255) NULL,
	[Proposed] [nvarchar](255) NULL,
	[HostName] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[BrandModel] [nvarchar](255) NULL,
	[ITENo] [nvarchar](255) NULL,
	[Category] [nvarchar](255) NULL,
	[Configuration] [nvarchar](255) NULL,
	[SerialNo] [nvarchar](255) NULL,
	[Location] [nvarchar](255) NULL,
	[User] [nvarchar](255) NULL,
	[PurchDate] [datetime] NULL,
	[Remarks] [nvarchar](255) NULL,
	[Field18] [nvarchar](255) NULL,
	[Field19] [nvarchar](255) NULL,
	[Device] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INV_Userinfo]    Script Date: 02/27/2014 09:57:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_Userinfo](
	[UserinfoID] [uniqueidentifier] NOT NULL,
	[AccountCode] [nvarchar](100) NOT NULL,
	[UserID] [nvarchar](100) NOT NULL,
	[Modifydate] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_INV_Userinfo] PRIMARY KEY CLUSTERED 
(
	[UserinfoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INV_Devices]    Script Date: 02/27/2014 09:57:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_Devices](
	[DeviceID] [uniqueidentifier] NOT NULL,
	[DeviceName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_INV_Devices] PRIMARY KEY CLUSTERED 
(
	[DeviceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INV_Department]    Script Date: 02/27/2014 09:57:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_Department](
	[DeptID] [uniqueidentifier] NOT NULL,
	[DeptNo] [nvarchar](100) NOT NULL,
	[DeptName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_INV_Department] PRIMARY KEY CLUSTERED 
(
	[DeptID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INV_Country]    Script Date: 02/27/2014 09:57:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_Country](
	[CID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_INV_Country] PRIMARY KEY CLUSTERED 
(
	[CID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INV_Buildinginfo]    Script Date: 02/27/2014 09:57:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_Buildinginfo](
	[BNID] [uniqueidentifier] NOT NULL,
	[BuildingName] [nvarchar](100) NOT NULL,
	[LocID] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_INV_Buildinginfo] PRIMARY KEY CLUSTERED 
(
	[BNID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HL_InventoryInfo]    Script Date: 02/27/2014 09:57:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HL_InventoryInfo](
	[AccountID] [uniqueidentifier] NOT NULL,
	[AccountCode] [nvarchar](100) NULL,
	[BrandModel] [nvarchar](50) NULL,
	[Category] [nvarchar](20) NULL,
	[Configuration] [nvarchar](200) NULL,
	[SerialNo] [nvarchar](50) NULL,
	[Location] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[PurchDate] [date] NULL,
	[Remark] [nvarchar](50) NULL,
	[MonitorSLNO] [nvarchar](50) NULL,
	[UpsSLNO] [nvarchar](50) NULL,
	[DeptNo] [nvarchar](50) NULL,
	[Team] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[HostName] [nvarchar](50) NULL,
	[ITemNo] [nvarchar](50) NULL,
 CONSTRAINT [PK_InventoryInfo] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EMPNT]    Script Date: 02/27/2014 09:57:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPNT](
	[EMPNO] [nvarchar](50) NULL,
	[EMPNAME] [nvarchar](50) NULL,
	[DEPTID] [uniqueidentifier] NOT NULL,
	[Designation] [nvarchar](50) NULL,
	[JOINDATE] [datetime] NULL,
	[Location] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EMPManager]    Script Date: 02/27/2014 09:57:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPManager](
	[EmpID] [nvarchar](50) NULL,
	[Ename] [nvarchar](50) NULL,
	[Fname] [nvarchar](50) NULL,
	[Per_Add] [ntext] NULL,
	[Pre_Add] [ntext] NULL,
	[Phone_No] [ntext] NULL,
	[BDate] [datetime] NULL,
	[Nationality] [ntext] NULL,
	[Religion] [ntext] NULL,
	[MStatus] [ntext] NULL,
	[Sex] [ntext] NULL,
	[NickName] [ntext] NULL,
	[Status] [ntext] NULL,
	[Designation] [nvarchar](50) NULL,
	[J_Date] [datetime] NULL,
	[Grade] [ntext] NULL,
	[code] [ntext] NULL,
	[Section] [nvarchar](50) NULL,
	[Line_No] [ntext] NULL,
	[Basic] [money] NULL,
	[HRent] [money] NULL,
	[Total] [money] NULL,
	[Add_Date] [datetime] NULL,
	[Add_Time] [datetime] NULL,
	[department] [nvarchar](50) NULL,
	[Designation_old] [ntext] NULL,
	[Medical] [money] NULL,
	[Transport] [money] NULL,
	[Tel_Bill] [money] NULL,
	[Bank_AC] [ntext] NULL,
	[Location] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EMPBD]    Script Date: 02/27/2014 09:57:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPBD](
	[EmpID] [nvarchar](50) NULL,
	[Ename] [nvarchar](50) NULL,
	[Fname] [ntext] NULL,
	[Per_Add] [ntext] NULL,
	[Pre_Add] [ntext] NULL,
	[Phone_No] [ntext] NULL,
	[BDate] [datetime] NULL,
	[Nationality] [ntext] NULL,
	[Religion] [ntext] NULL,
	[MStatus] [ntext] NULL,
	[Sex] [ntext] NULL,
	[NickName] [ntext] NULL,
	[Status] [ntext] NULL,
	[Designation] [nvarchar](50) NULL,
	[J_Date] [datetime] NULL,
	[Grade] [ntext] NULL,
	[code] [ntext] NULL,
	[Section] [nvarchar](50) NULL,
	[Line_No] [ntext] NULL,
	[Basic] [money] NULL,
	[HRent] [money] NULL,
	[Total] [money] NULL,
	[Add_Date] [datetime] NULL,
	[Add_Time] [datetime] NULL,
	[department] [ntext] NULL,
	[Designation_old] [ntext] NULL,
	[Medical] [money] NULL,
	[Transport] [money] NULL,
	[Tel_Bill] [money] NULL,
	[Bank_AC] [ntext] NULL,
	[Location] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EMPApp]    Script Date: 02/27/2014 09:57:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPApp](
	[EmpID] [nvarchar](50) NULL,
	[Ename] [nvarchar](50) NULL,
	[Fname] [ntext] NULL,
	[Per_Add] [ntext] NULL,
	[Pre_Add] [ntext] NULL,
	[Phone_No] [ntext] NULL,
	[BDate] [datetime] NULL,
	[Nationality] [ntext] NULL,
	[Religion] [ntext] NULL,
	[MStatus] [ntext] NULL,
	[Sex] [ntext] NULL,
	[NickName] [ntext] NULL,
	[Status] [ntext] NULL,
	[Designation] [nvarchar](50) NULL,
	[J_Date] [datetime] NULL,
	[Grade] [ntext] NULL,
	[code] [ntext] NULL,
	[Section] [nvarchar](50) NULL,
	[Line_No] [ntext] NULL,
	[Basic] [money] NULL,
	[HRent] [money] NULL,
	[Total] [money] NULL,
	[Add_Date] [datetime] NULL,
	[Add_Time] [datetime] NULL,
	[department] [ntext] NULL,
	[Designation_old] [ntext] NULL,
	[Medical] [money] NULL,
	[Transport] [money] NULL,
	[Tel_Bill] [money] NULL,
	[Bank_AC] [ntext] NULL,
	[Location] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INV_LeaveEntry]    Script Date: 02/27/2014 09:57:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_LeaveEntry](
	[LEntryID] [uniqueidentifier] NOT NULL,
	[LeaveDays] [int] NULL,
	[Months] [nvarchar](20) NOT NULL,
	[Years] [nvarchar](15) NOT NULL,
	[EntryDate] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_INV_LeaveEntry] PRIMARY KEY CLUSTERED 
(
	[LEntryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INV_Items]    Script Date: 02/27/2014 09:57:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_Items](
	[ItemID] [uniqueidentifier] NOT NULL,
	[ItemName] [nvarchar](max) NOT NULL,
	[ItemDate] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_INV_Items] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INV_Unitentry]    Script Date: 02/27/2014 09:57:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_Unitentry](
	[UnitID] [uniqueidentifier] NOT NULL,
	[UnitName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_INV_Unitentry] PRIMARY KEY CLUSTERED 
(
	[UnitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DEPT]    Script Date: 02/27/2014 09:57:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DEPT](
	[DeptID] [int] IDENTITY(1,1) NOT NULL,
	[DeptName] [nvarchar](35) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inv_OLDInfo]    Script Date: 02/27/2014 09:57:29 ******/
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
 CONSTRAINT [PK_Inv_OLDInfo] PRIMARY KEY CLUSTERED 
(
	[OLDID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INV_Machineinfo]    Script Date: 02/27/2014 09:57:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_Machineinfo](
	[MNID] [uniqueidentifier] NOT NULL,
	[MachineName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_INV_Machineinfo] PRIMARY KEY CLUSTERED 
(
	[MNID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INV_Models]    Script Date: 02/27/2014 09:57:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_Models](
	[ModelID] [uniqueidentifier] NOT NULL,
	[ItemID] [uniqueidentifier] NOT NULL,
	[ModelName] [nvarchar](max) NOT NULL,
	[ModelDate] [nvarchar](50) NOT NULL,
	[ExDate] [nvarchar](50) NULL,
	[TPage] [int] NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_INV_Models] PRIMARY KEY CLUSTERED 
(
	[ModelID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INV_Location]    Script Date: 02/27/2014 09:57:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_Location](
	[LocID] [uniqueidentifier] NOT NULL,
	[Location] [nvarchar](max) NOT NULL,
	[CountryID] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_INV_Location] PRIMARY KEY CLUSTERED 
(
	[LocID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INV_EmployeeInfo]    Script Date: 02/27/2014 09:57:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_EmployeeInfo](
	[EmpID] [uniqueidentifier] NOT NULL,
	[EmpNo] [nvarchar](100) NOT NULL,
	[EmpName] [nvarchar](100) NOT NULL,
	[DeptID] [uniqueidentifier] NOT NULL,
	[Location] [nvarchar](100) NOT NULL,
	[JoinDate] [datetime] NOT NULL,
 CONSTRAINT [PK_INV_EmployeeInfo] PRIMARY KEY CLUSTERED 
(
	[EmpID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[DEPT_VIEW]    Script Date: 02/27/2014 09:57:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[DEPT_VIEW] AS select *from DEPT;
GO
/****** Object:  Table [dbo].[Inv_Idleentry]    Script Date: 02/27/2014 09:57:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inv_Idleentry](
	[IID] [uniqueidentifier] NOT NULL,
	[EID] [uniqueidentifier] NOT NULL,
	[UnitID] [uniqueidentifier] NOT NULL,
	[Years] [nvarchar](100) NOT NULL,
	[Months] [nvarchar](50) NOT NULL,
	[Idledays] [int] NULL,
 CONSTRAINT [PK_Inv_Idleentry] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INV_FTYTransfer]    Script Date: 02/27/2014 09:57:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_FTYTransfer](
	[TRID] [int] IDENTITY(1,1) NOT NULL,
	[ItemID] [uniqueidentifier] NOT NULL,
	[IssueDate] [nvarchar](50) NOT NULL,
	[LocID] [uniqueidentifier] NOT NULL,
	[IsReceive] [bit] NOT NULL,
 CONSTRAINT [PK_INV_FTYTransfer] PRIMARY KEY CLUSTERED 
(
	[TRID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INV_Floorinfo]    Script Date: 02/27/2014 09:57:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_Floorinfo](
	[FID] [uniqueidentifier] NOT NULL,
	[FloorName] [nvarchar](100) NOT NULL,
	[BNID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_INV_Floorinfo] PRIMARY KEY CLUSTERED 
(
	[FID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INV_PrinterDetails]    Script Date: 02/27/2014 09:57:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_PrinterDetails](
	[PrinterID] [uniqueidentifier] NOT NULL,
	[AccountCode] [nvarchar](100) NULL,
	[PrinterName] [nvarchar](100) NULL,
	[ModelNo] [nvarchar](100) NULL,
	[SerialNo] [nvarchar](100) NULL,
	[IPMAC] [nvarchar](100) NULL,
	[PurchDate] [datetime] NULL,
	[DeptID] [uniqueidentifier] NOT NULL,
	[DistDate] [datetime] NULL,
	[Type] [nvarchar](100) NULL,
	[Totaluser] [nvarchar](100) NULL,
	[Dailyppage] [nvarchar](100) NULL,
	[DeviceID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_INV_PrinterDetails] PRIMARY KEY CLUSTERED 
(
	[PrinterID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spGetassettransBylocdate]    Script Date: 02/27/2014 09:57:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Hasib>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetassettransBylocdate]	
				   @ItemID AS nvarchar(100)
				  ,@IssueDate AS nvarchar(100)
				  ,@Location AS nvarchar(100)
				  ,@Userstatus as nvarchar(100)
				
AS
--IF((@Location='HLNT' and @Userstatus='Normal' OR (@Location='HLAP' and @Userstatus='Normal')OR (@Location='HLBD' and @Userstatus='Normal') OR (@Location='HLRC' and @Userstatus='Normal') OR (@Location='HLWF' and @Userstatus='Normal') OR (@Location='HYBD' and @Userstatus='Normal'))
--******** For only Location Selection
IF ((@Location='HLNT' and @Userstatus='Normal') OR (@Location='HLAP' and @Userstatus='Normal')OR (@Location='HLBD' and @Userstatus='Normal') OR (@Location='HLRC' and @Userstatus='Normal') OR (@Location='HLWF' and @Userstatus='Normal') OR (@Location='HYBD' and @Userstatus='Normal'))
BEGIN
IF((@ItemID!=' ') and (@IssueDate=' '))	
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
SELECT MAX(A.[TRID]) AS TRID, 
	       A.[ItemID] AS ItemID,	      
	       A.[IssueDate] AS IssueDate, 
	       A.[LocID] AS [LocID], 	      
	       A.[IsReceive] AS IsReceive   
	       FROM [ITInventory].[dbo].[INV_FTYTransfer] as A, [ITInventory].[dbo].[INV_Location] as B
	       WHERE 	
	       (A.LocID=B.LocID AND B.Location=@Location)       
	       AND
	       ItemID=@ItemID GROUP BY  A.IssueDate, A.ItemID, A.LocID, A.IsReceive ORDER BY A.IssueDate DESC	      
END	
 ELSE IF ((@ItemID=' ') and (@IssueDate!=' '))
BEGIN	
SELECT MAX(A.[TRID]) AS TRID, 
	       A.[ItemID] AS ItemID,	      
	       A.[IssueDate] AS IssueDate, 
	       A.[LocID] AS [LocID], 	      
	       A.[IsReceive] AS IsReceive   
	       FROM [ITInventory].[dbo].[INV_FTYTransfer] as A, [ITInventory].[dbo].[INV_Location] as B
	       WHERE 	
	       (A.LocID=B.LocID AND B.Location=@Location)       
	       AND	      
	       IssueDate=@IssueDate GROUP BY  A.IssueDate, A.ItemID, A.LocID, A.IsReceive ORDER BY A.IssueDate DESC
END
ELSE 
BEGIN	
SELECT MAX(A.[TRID]) AS TRID, 
	       A.[ItemID] AS ItemID,	      
	       A.[IssueDate] AS IssueDate, 
	       A.[LocID] AS [LocID], 	      
	       A.[IsReceive] AS IsReceive   
	       FROM [ITInventory].[dbo].[INV_FTYTransfer] as A, [ITInventory].[dbo].[INV_Location] as B
	       WHERE 	
	       (A.LocID=B.LocID AND B.Location=@Location)       
	       AND
	       (IssueDate=@IssueDate and  ItemID=@ItemID)	   GROUP BY  A.IssueDate, A.ItemID, A.LocID, A.IsReceive ORDER BY A.IssueDate DESC     
END
END
ELSE IF ((@Location='HLNT' and @Userstatus='OPEX') OR (@Location='HLAP' and @Userstatus='OPEX')OR (@Location='HLBD' and @Userstatus='OPEX') OR (@Location='HLRC' and @Userstatus='OPEX') OR (@Location='HLWF' and @Userstatus='OPEX') OR (@Location='HYBD' and @Userstatus='OPEX'))
BEGIN
IF((@ItemID!=' ') and (@IssueDate=' '))	
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
SELECT MAX(A.[TRID]) AS TRID, 
	       A.[ItemID] AS ItemID,	      
	       A.[IssueDate] AS IssueDate, 
	       A.[LocID] AS [LocID], 	      
	       A.[IsReceive] AS IsReceive   
	       FROM [ITInventory].[dbo].[INV_FTYTransfer] as A, [ITInventory].[dbo].[INV_Location] as B
	       WHERE 	
	       (A.LocID=B.LocID AND B.Location=@Location)       
	       AND
	       ItemID=@ItemID	 GROUP BY  A.IssueDate, A.ItemID, A.LocID, A.IsReceive ORDER BY A.IssueDate DESC     
END	
 ELSE IF ((@ItemID=' ') and (@IssueDate!=' '))
BEGIN	
SELECT MAX(A.[TRID]) AS TRID, 
	       A.[ItemID] AS ItemID,	      
	       A.[IssueDate] AS IssueDate, 
	       A.[LocID] AS [LocID], 	      
	       A.[IsReceive] AS IsReceive   
	       FROM [ITInventory].[dbo].[INV_FTYTransfer] as A, [ITInventory].[dbo].[INV_Location] as B
	       WHERE 	
	       (A.LocID=B.LocID AND B.Location=@Location)       
	       AND	      
	       IssueDate=@IssueDate GROUP BY  A.IssueDate, A.ItemID, A.LocID, A.IsReceive ORDER BY A.IssueDate DESC
END
ELSE 
BEGIN	
SELECT MAX(A.[TRID]) AS TRID, 
	       A.[ItemID] AS ItemID,	      
	       A.[IssueDate] AS IssueDate, 
	       A.[LocID] AS [LocID], 	      
	       A.[IsReceive] AS IsReceive   
	       FROM [ITInventory].[dbo].[INV_FTYTransfer] as A, [ITInventory].[dbo].[INV_Location] as B
	       WHERE 	
	       (A.LocID=B.LocID AND B.Location=@Location)       
	       AND
	       (IssueDate=@IssueDate and  ItemID=@ItemID)	GROUP BY  A.IssueDate, A.ItemID, A.LocID, A.IsReceive ORDER BY A.IssueDate DESC        
END
END

ELSE
BEGIN
IF((@ItemID!=' ') and (@IssueDate=' '))	
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
SELECT MAX(A.[TRID]) AS TRID, 
	       A.[ItemID] AS ItemID,	      
	       A.[IssueDate] AS IssueDate, 
	       A.[LocID] AS [LocID], 	      
	       A.[IsReceive] AS IsReceive   
	       FROM [ITInventory].[dbo].[INV_FTYTransfer] as A, [ITInventory].[dbo].[INV_Location] as B
	       WHERE 	
	       (A.LocID=B.LocID AND B.Location=LEFT(Location,4))       
	       AND
	       ItemID=@ItemID	    GROUP BY  A.IssueDate, A.ItemID, A.LocID, A.IsReceive ORDER BY A.IssueDate DESC  
END	
 ELSE IF ((@ItemID=' ') and (@IssueDate!=' '))
BEGIN	
SELECT MAX(A.[TRID]) AS TRID, 
	       A.[ItemID] AS ItemID,	      
	       A.[IssueDate] AS IssueDate, 
	       A.[LocID] AS [LocID], 	      
	       A.[IsReceive] AS IsReceive   
	       FROM [ITInventory].[dbo].[INV_FTYTransfer] as A, [ITInventory].[dbo].[INV_Location] as B
	       WHERE 	
	       (A.LocID=B.LocID AND B.Location=LEFT(Location,4))       
	       AND	      
	       IssueDate=@IssueDate GROUP BY  A.IssueDate, A.ItemID, A.LocID, A.IsReceive ORDER BY A.IssueDate DESC
END
ELSE 
BEGIN	
SELECT MAX(A.[TRID]) AS TRID, 
	       A.[ItemID] AS ItemID,	      
	       A.[IssueDate] AS IssueDate, 
	       A.[LocID] AS [LocID], 	      
	       A.[IsReceive] AS IsReceive   
	       FROM [ITInventory].[dbo].[INV_FTYTransfer] as A, [ITInventory].[dbo].[INV_Location] as B
	       WHERE 	
	       (A.LocID=B.LocID AND B.Location=LEFT(Location,4))       
	       AND
	       (IssueDate=@IssueDate and  ItemID=@ItemID)	 GROUP BY  A.IssueDate, A.ItemID, A.LocID, A.IsReceive ORDER BY A.IssueDate DESC       
END
END
GO
/****** Object:  StoredProcedure [dbo].[spSetFTYTransfer]    Script Date: 02/27/2014 09:57:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:        <Author,,Name>
-- Create date: <Create Date,,>
-- Description:    <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spSetFTYTransfer]
                  @ItemID AS Uniqueidentifier
                , @IssueDate AS nvarchar(100)
                , @LocID as Uniqueidentifier
               
AS

IF (NOT EXISTS(SELECT * FROM ITInventory.dbo.INV_FTYTransfer where IssueDate =@IssueDate))
BEGIN
  SET NOCOUNT ON;
    INSERT INTO ITInventory.dbo.INV_FTYTransfer ( ItemID, IssueDate, LocID, IsReceive) VALUES ( @ItemID, @IssueDate, @LocID, 'False' )
END
ELSE
BEGIN
    UPDATE ITInventory.dbo.INV_FTYTransfer SET ItemID=@ItemID, LocID=@LocID, IsReceive='True' where IssueDate=@IssueDate
END
GO
/****** Object:  Table [dbo].[INV_UPSDetails]    Script Date: 02/27/2014 09:57:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_UPSDetails](
	[UPSID] [uniqueidentifier] NOT NULL,
	[UPSName] [nvarchar](100) NULL,
	[ModelNo] [nvarchar](100) NULL,
	[SerialNo] [nvarchar](100) NULL,
	[PurchDate] [datetime] NULL,
	[DeptID] [uniqueidentifier] NOT NULL,
	[EmpID] [uniqueidentifier] NOT NULL,
	[DistDate] [datetime] NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_INV_UPSDetails] PRIMARY KEY CLUSTERED 
(
	[UPSID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INV_ReceiveNissue]    Script Date: 02/27/2014 09:57:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_ReceiveNissue](
	[RIssueID] [uniqueidentifier] NOT NULL,
	[ItemID] [uniqueidentifier] NOT NULL,
	[ModelID] [uniqueidentifier] NOT NULL,
	[ReceiveQty] [int] NULL,
	[IssueDate] [nvarchar](50) NOT NULL,
	[ReceiverName] [nvarchar](max) NOT NULL,
	[ReceiverEmail] [nvarchar](max) NOT NULL,
	[Transportno] [nvarchar](max) NOT NULL,
	[LocID] [uniqueidentifier] NOT NULL,
	[IssueQty] [int] NULL,
	[BalanceQty] [int] NULL,
 CONSTRAINT [PK_INV_ReceiveNissue] PRIMARY KEY CLUSTERED 
(
	[RIssueID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GetIdlesearchByuym]    Script Date: 02/27/2014 09:57:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Hasib>
-- Create date: <Create Date,,>
-- Description:	<Description,, Idle Days Search>
-- =============================================
CREATE PROCEDURE [dbo].[GetIdlesearchByuym] 
				 @UnitID AS nvarchar(100)
				,@Years  AS nvarchar(100)
				,@Months AS nvarchar(100)
		
AS
IF(@UnitID!=' ') AND (@Years=' ') AND (@Months=' ')
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT	 [IID]
			,[EID]
			,[UnitID]
			,[Years]
			,[Months]
			,[Idledays]
    FROM 
			[ITInventory].[dbo].[Inv_Idleentry] 
    WHERE
			UnitID=@UnitID
			--AND
			--Years=@Years 
			--AND
			--Months=@Months 	         
	     
END
ELSE IF(@UnitID!=' ') AND (@Years!=' ') AND (@Months=' ')
BEGIN
	
	SELECT   [IID]
			,[EID]
			,[UnitID]
			,[Years]
			,[Months]
			,[Idledays]
    FROM 
			[ITInventory].[dbo].[Inv_Idleentry] 
    WHERE
			UnitID=@UnitID
			AND
			Years=@Years 
			--AND
			--Months=@Months     
	     
END
ELSE IF (@UnitID!=' ') AND (@Years!=' ') AND (@Months!=' ')
BEGIN
	
	SELECT   [IID]
			,[EID]
			,[UnitID]
			,[Years]
			,[Months]
			,[Idledays]
    FROM 
			[ITInventory].[dbo].[Inv_Idleentry] 
    WHERE
			UnitID=@UnitID
			AND
			Years=@Years 
			AND
			Months=@Months  
	     
END
ELSE
BEGIN
	
	SELECT   [IID]
			,[EID]
			,[UnitID]
			,[Years]
			,[Months]
			,[Idledays]
    FROM 
			[ITInventory].[dbo].[Inv_Idleentry] 
    WHERE
			UnitID=@UnitID
			--AND
			--Years=@Years 
			--AND
			--Months=@Months  
	     
END
GO
/****** Object:  Table [dbo].[INV_Factorystock]    Script Date: 02/27/2014 09:57:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_Factorystock](
	[FSID] [uniqueidentifier] NOT NULL,
	[ItemID] [uniqueidentifier] NOT NULL,
	[ModelID] [uniqueidentifier] NOT NULL,
	[FSDate] [nvarchar](50) NOT NULL,
	[TFSRQty] [int] NULL,
	[TFSIQty] [int] NULL,
	[LocID] [uniqueidentifier] NOT NULL,
	[FSBalanceQty] [int] NULL,
 CONSTRAINT [PK_INV_Factorystock] PRIMARY KEY CLUSTERED 
(
	[FSID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INV_ItemReceive]    Script Date: 02/27/2014 09:57:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_ItemReceive](
	[IRID] [uniqueidentifier] NOT NULL,
	[LotNo] [int] IDENTITY(1,1) NOT NULL,
	[ItemID] [uniqueidentifier] NOT NULL,
	[ModelID] [uniqueidentifier] NOT NULL,
	[RDate] [nvarchar](50) NOT NULL,
	[Chlanno] [nvarchar](max) NOT NULL,
	[Suppliername] [nvarchar](max) NOT NULL,
	[LocID] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_INV_ItemReceive] PRIMARY KEY CLUSTERED 
(
	[IRID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INV_ItemIssue]    Script Date: 02/27/2014 09:57:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_ItemIssue](
	[IID] [uniqueidentifier] NOT NULL,
	[ItemID] [uniqueidentifier] NOT NULL,
	[ModelID] [uniqueidentifier] NOT NULL,
	[IDate] [nvarchar](50) NOT NULL,
	[ReceiverName] [nvarchar](max) NOT NULL,
	[LocID] [uniqueidentifier] NOT NULL,
	[IssueQty] [int] NULL,
 CONSTRAINT [PK_INV_ItemIssue] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inv_InventoryInfo]    Script Date: 02/27/2014 09:57:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inv_InventoryInfo](
	[AccountID] [uniqueidentifier] NOT NULL,
	[ENumber] [nvarchar](max) NOT NULL,
	[AccountCode] [nvarchar](100) NULL,
	[BrandModel] [nvarchar](100) NULL,
	[Category] [nvarchar](100) NULL,
	[Configuration] [nvarchar](200) NULL,
	[SerialNo] [nvarchar](100) NULL,
	[Location] [nvarchar](100) NULL,
	[EMPID] [uniqueidentifier] NOT NULL,
	[PurchDate] [nvarchar](50) NOT NULL,
	[Remark] [nvarchar](100) NULL,
	[MonitorID] [nvarchar](100) NULL,
	[UPSID] [nvarchar](100) NULL,
	[DeptID] [uniqueidentifier] NOT NULL,
	[Team] [nvarchar](100) NULL,
	[Status] [nvarchar](100) NULL,
	[HostName] [nvarchar](100) NULL,
	[ITemNo] [nvarchar](100) NULL,
	[Proposed] [nvarchar](max) NULL,
	[Office] [nvarchar](max) NULL,
	[DeviceID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Inv_InventoryInfo] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INV_Lineinfo]    Script Date: 02/27/2014 09:57:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_Lineinfo](
	[LID] [uniqueidentifier] NOT NULL,
	[LineName] [nvarchar](100) NOT NULL,
	[FID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_INV_Lineinfo] PRIMARY KEY CLUSTERED 
(
	[LID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INV_MonitorDetails]    Script Date: 02/27/2014 09:57:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_MonitorDetails](
	[MonitorID] [uniqueidentifier] NOT NULL,
	[MonitorName] [nvarchar](100) NULL,
	[ModelNo] [nvarchar](100) NULL,
	[SerialNo] [nvarchar](100) NULL,
	[PurchDate] [datetime] NULL,
	[DeptID] [uniqueidentifier] NOT NULL,
	[EmpID] [uniqueidentifier] NOT NULL,
	[DistDate] [datetime] NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_INV_MonitorDetails] PRIMARY KEY CLUSTERED 
(
	[MonitorID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INV_Stock]    Script Date: 02/27/2014 09:57:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_Stock](
	[SID] [uniqueidentifier] NOT NULL,
	[ItemID] [uniqueidentifier] NOT NULL,
	[ModelID] [uniqueidentifier] NOT NULL,
	[SDate] [nvarchar](50) NOT NULL,
	[IDate] [nvarchar](50) NOT NULL,
	[IssueQty] [int] NULL,
	[TOTALRQty] [int] NULL,
	[TOTALIQty] [int] NULL,
	[BalanceQty] [int] NULL,
 CONSTRAINT [PK_INV_Stock] PRIMARY KEY CLUSTERED 
(
	[SID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INV_Service]    Script Date: 02/27/2014 09:57:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_Service](
	[ServiceID] [uniqueidentifier] NOT NULL,
	[AccountID] [uniqueidentifier] NOT NULL,
	[LocID] [uniqueidentifier] NOT NULL,
	[Servicedate] [nvarchar](50) NULL,
	[Mlifetime] [nvarchar](20) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_INV_Service] PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inv_Equipmentinfo]    Script Date: 02/27/2014 09:57:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inv_Equipmentinfo](
	[EID] [uniqueidentifier] NOT NULL,
	[LocID] [uniqueidentifier] NOT NULL,
	[ENumber] [nvarchar](max) NOT NULL,
	[AccountCode] [nvarchar](100) NULL,
	[AssetCode] [nvarchar](100) NOT NULL,
	[Brand] [nvarchar](100) NULL,
	[Model] [nvarchar](100) NULL,
	[Serialno] [nvarchar](100) NULL,
	[Subserialno] [nvarchar](100) NULL,
	[MNID] [uniqueidentifier] NOT NULL,
	[Machineid] [nvarchar](200) NULL,
	[Lifetime] [nvarchar](100) NULL,
	[PurchDate] [nvarchar](50) NOT NULL,
	[UnitID] [uniqueidentifier] NOT NULL,
	[BNID] [uniqueidentifier] NOT NULL,
	[FID] [uniqueidentifier] NOT NULL,
	[LID] [uniqueidentifier] NOT NULL,
	[Status] [nvarchar](100) NULL,
	[Remarks] [nvarchar](100) NULL,
	[CID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Inv_Equipmentinfo] PRIMARY KEY CLUSTERED 
(
	[EID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INV_Userissue]    Script Date: 02/27/2014 09:57:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_Userissue](
	[UIssueID] [uniqueidentifier] NOT NULL,
	[ItemID] [uniqueidentifier] NOT NULL,
	[ModelID] [uniqueidentifier] NOT NULL,
	[DeptID] [uniqueidentifier] NOT NULL,
	[EmpID] [uniqueidentifier] NOT NULL,
	[LocID] [uniqueidentifier] NOT NULL,
	[UIssueDate] [nvarchar](50) NOT NULL,
	[UITRFNo] [nvarchar](max) NULL,
	[UIssueQty] [int] NULL,
 CONSTRAINT [PK_INV_Userissue] PRIMARY KEY CLUSTERED 
(
	[UIssueID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spGetstockinfoRecordByDate]    Script Date: 02/27/2014 09:57:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetstockinfoRecordByDate]
                    @StartDate AS nvarchar(100),
                    @EndDate   AS nvarchar(100),
                    @ItemID    AS nvarchar(100),
                    @ModelID   AS nvarchar(100)
                    
AS
IF ((@StartDate!=' ') and (@EndDate=' ') and (@ItemID=' ') and (@ModelID=' '))
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT a.ItemID, a.ModelID, a.LocID, a.IDate as SDate, a.IDate, a.IssueQty
       ,(SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=a.ModelID) as TOTALRQty
       ,(SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE CONVERT(DATE,b.IDate, 103) <= CONVERT(DATE,a.IDate, 103) AND b.ModelID=a.ModelID) as TOTALIQty
       ,((SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=a.ModelID)-(SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE CONVERT(DATE,b.IDate, 103) <= CONVERT(DATE,a.IDate, 103) AND b.ModelID=a.ModelID)) as BalanceQty
    FROM  dbo.INV_ItemIssue  a 
    WHERE convert(date,a.IDate,103)  >=convert(date,@StartDate,103) 
    --AND convert(date,IDate,103)<=convert(date,@EndDate,103)
    --AND a.ItemID=@ItemID and a.ModelID=@ModelID
    ORDER BY a.ModelID, CONVERT(DATE,a.IDate, 103) DESC
END
ELSE IF ((@StartDate!=' ') and (@EndDate!=' ') and (@ItemID=' ') and (@ModelID=' '))
BEGIN
    SELECT a.ItemID, a.ModelID, a.LocID, a.IDate as SDate, a.IDate, a.IssueQty
       ,(SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=a.ModelID) as TOTALRQty
       ,(SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE CONVERT(DATE,b.IDate, 103) <= CONVERT(DATE,a.IDate, 103) AND b.ModelID=a.ModelID) as TOTALIQty
       ,((SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=a.ModelID)-(SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE CONVERT(DATE,b.IDate, 103) <= CONVERT(DATE,a.IDate, 103) AND b.ModelID=a.ModelID)) as BalanceQty
    FROM  dbo.INV_ItemIssue  a 
    WHERE convert(date,a.IDate,103)  >=convert(date,@StartDate,103) AND convert(date,IDate,103)<=convert(date,@EndDate,103)
    --AND a.ItemID=@ItemID and a.ModelID=@ModelID
    ORDER BY a.ModelID, CONVERT(DATE,a.IDate, 103) DESC
END
ELSE IF ((@StartDate!=' ') and (@EndDate!=' ') and (@ItemID!=' ') and (@ModelID=' '))
BEGIN
    SELECT a.ItemID, a.ModelID, a.LocID, a.IDate as SDate, a.IDate, a.IssueQty
       ,(SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=a.ModelID) as TOTALRQty
       ,(SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE CONVERT(DATE,b.IDate, 103) <= CONVERT(DATE,a.IDate, 103) AND b.ModelID=a.ModelID) as TOTALIQty
       ,((SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=a.ModelID)-(SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE CONVERT(DATE,b.IDate, 103) <= CONVERT(DATE,a.IDate, 103) AND b.ModelID=a.ModelID)) as BalanceQty
    FROM  dbo.INV_ItemIssue  a 
    WHERE convert(date,a.IDate,103)  >=convert(date,@StartDate,103) AND convert(date,IDate,103)<=convert(date,@EndDate,103)
    AND a.ItemID=@ItemID 
    --and a.ModelID=@ModelID
    ORDER BY a.ModelID, CONVERT(DATE,a.IDate, 103) DESC
END
ELSE IF ((@StartDate=' ') and (@EndDate=' ') and (@ItemID=' ') and (@ModelID!=' '))
BEGIN
    SELECT a.ItemID, a.ModelID, a.LocID, a.IDate as SDate, a.IDate, a.IssueQty
       ,(SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=a.ModelID) as TOTALRQty
       ,(SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE CONVERT(DATE,b.IDate, 103) <= CONVERT(DATE,a.IDate, 103) AND b.ModelID=a.ModelID) as TOTALIQty
       ,((SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=a.ModelID)-(SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE CONVERT(DATE,b.IDate, 103) <= CONVERT(DATE,a.IDate, 103) AND b.ModelID=a.ModelID)) as BalanceQty
    FROM  dbo.INV_ItemIssue  a 
    WHERE a.ModelID=@ModelID
    ORDER BY a.ModelID, CONVERT(DATE,a.IDate, 103) DESC
END
ELSE IF ((@StartDate!=' ') and (@EndDate!=' ') and (@ItemID!=' ') and (@ModelID!=' '))
BEGIN
    SELECT a.ItemID, a.ModelID, a.LocID, a.IDate as SDate, a.IDate, a.IssueQty
       ,(SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=a.ModelID) as TOTALRQty
       ,(SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE CONVERT(DATE,b.IDate, 103) <= CONVERT(DATE,a.IDate, 103) AND b.ModelID=a.ModelID) as TOTALIQty
       ,((SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=a.ModelID)-(SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE CONVERT(DATE,b.IDate, 103) <= CONVERT(DATE,a.IDate, 103) AND b.ModelID=a.ModelID)) as BalanceQty
    FROM  dbo.INV_ItemIssue  a 
    WHERE convert(date,a.IDate,103)  >=convert(date,@StartDate,103) AND convert(date,IDate,103)<=convert(date,@EndDate,103)
    AND  a.ItemID=@ItemID and a.ModelID=@ModelID
    ORDER BY a.ModelID, CONVERT(DATE,a.IDate, 103) DESC
END
ELSE
BEGIN
   SELECT a.ItemID, a.ModelID, a.LocID, a.IDate as SDate, a.IDate, a.IssueQty
       ,(SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=a.ModelID) as TOTALRQty
       , (SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE CONVERT(DATE,b.IDate, 103) <= CONVERT(DATE,a.IDate, 103) AND b.ModelID=a.ModelID) as TOTALIQty
       ,((SELECT sum(Quantity) FROM dbo.INV_ItemReceive WHERE ModelID=a.ModelID)-(SELECT SUM(b.IssueQty) FROM dbo.INV_ItemIssue b   WHERE CONVERT(DATE,b.IDate, 103) <= CONVERT(DATE,a.IDate, 103) AND b.ModelID=a.ModelID)) as BalanceQty
   FROM  dbo.INV_ItemIssue  a 
   ORDER BY a.ModelID, CONVERT(DATE,a.IDate, 103) DESC
END
GO
/****** Object:  StoredProcedure [dbo].[spGetReciveRecordByDate]    Script Date: 02/27/2014 09:57:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetReciveRecordByDate]
                    @StartDate AS nvarchar(100),
                    @EndDate   AS nvarchar(100),
                    @ItemID    AS nvarchar(100),
                    @ModelID   AS nvarchar(100) 
AS
IF ((@StartDate!=' ') and (@EndDate=' ') and (@ItemID=' ') and (@ModelID=' '))
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT A.[IRID], A.[ItemID], A.[ModelID],CONVERT(DATE, A.[RDate],103), A.[Chlanno], A.[Suppliername], A.[LocID], A.[Quantity], 
    (SELECT SUM(B.[Quantity]) FROM [ITInventory].[dbo].[INV_ItemReceive] B WHERE CONVERT(DATE, B.[RDate], 103)<= CONVERT(DATE, A.[RDate], 103) AND A.ModelID=B.ModelID) AS RTotalQty 
    FROM [ITInventory].[dbo].[INV_ItemReceive] A  
    WHERE convert(date,RDate,103)  >=convert(date,@StartDate,103) 
    --AND convert(date,RDate,103)<=convert(date,@EndDate,103) 
    --and A.ModelID=@ModelID AND A.ItemID=@ItemID 
ORDER BY  A.ModelID, CONVERT(DATE, A.[RDate], 103) DESC
END
ELSE IF ((@StartDate!=' ') and (@EndDate!=' ') and (@ItemID=' ') and (@ModelID=' '))
BEGIN
   SELECT A.[IRID], A.[ItemID], A.[ModelID],CONVERT(DATE, A.[RDate],103), A.[Chlanno], A.[Suppliername], A.[LocID], A.[Quantity], 
   (SELECT SUM(B.[Quantity]) FROM [ITInventory].[dbo].[INV_ItemReceive] B WHERE CONVERT(DATE, B.[RDate], 103)<= CONVERT(DATE, A.[RDate], 103) AND A.ModelID=B.ModelID) AS RTotalQty 
   FROM [ITInventory].[dbo].[INV_ItemReceive] A  
   WHERE convert(date,RDate,103)  >=convert(date,@StartDate,103) AND convert(date,RDate,103)<=convert(date,@EndDate,103) 
   --and A.ModelID=@ModelID AND A.ItemID=@ItemID 
   ORDER BY  A.ModelID, CONVERT(DATE, A.[RDate], 103) DESC
END
ELSE IF ((@StartDate!=' ') and (@EndDate!=' ') and (@ItemID!=' ') and (@ModelID=' '))
BEGIN
    SELECT A.[IRID], A.[ItemID], A.[ModelID],CONVERT(DATE, A.[RDate],103), A.[Chlanno], A.[Suppliername], A.[LocID], A.[Quantity], 
    (SELECT SUM(B.[Quantity]) FROM [ITInventory].[dbo].[INV_ItemReceive] B WHERE CONVERT(DATE, B.[RDate], 103)<= CONVERT(DATE, A.[RDate], 103) AND A.ModelID=B.ModelID) AS RTotalQty 
    FROM [ITInventory].[dbo].[INV_ItemReceive] A  
    WHERE convert(date,RDate,103)  >=convert(date,@StartDate,103) AND convert(date,RDate,103)<=convert(date,@EndDate,103) and 
    A.ModelID=@ModelID 
 --   AND A.ItemID=@ItemID 
    ORDER BY  A.ModelID, CONVERT(DATE, A.[RDate], 103) DESC
END
ELSE IF ((@StartDate=' ') and (@EndDate=' ') and (@ItemID=' ') and (@ModelID!=' '))
BEGIN
    SELECT A.[IRID], A.[ItemID], A.[ModelID],CONVERT(DATE, A.[RDate],103), A.[Chlanno], A.[Suppliername], A.[LocID], A.[Quantity], 
    (SELECT SUM(B.[Quantity]) FROM [ITInventory].[dbo].[INV_ItemReceive] B WHERE CONVERT(DATE, B.[RDate], 103)<= CONVERT(DATE, A.[RDate], 103) AND A.ModelID=B.ModelID) AS RTotalQty 
    FROM [ITInventory].[dbo].[INV_ItemReceive] A  WHERE A.ModelID=@ModelID ORDER BY  A.ModelID, CONVERT(DATE, A.[RDate], 103) DESC
END
ELSE IF ((@StartDate!=' ') and (@EndDate!=' ') and (@ItemID!=' ') and (@ModelID!=' '))
BEGIN
   SELECT A.[IRID], A.[ItemID], A.[ModelID],CONVERT(DATE, A.[RDate],103), A.[Chlanno], A.[Suppliername], A.[LocID], A.[Quantity], 
   (SELECT SUM(B.[Quantity]) FROM [ITInventory].[dbo].[INV_ItemReceive] B WHERE CONVERT(DATE, B.[RDate], 103)<= CONVERT(DATE, A.[RDate], 103) AND A.ModelID=B.ModelID) AS RTotalQty 
   FROM [ITInventory].[dbo].[INV_ItemReceive] A  
   WHERE convert(date,RDate,103)  >=convert(date,@StartDate,103) AND convert(date,RDate,103)<=convert(date,@EndDate,103) and 
   A.ModelID=@ModelID AND A.ItemID=@ItemID ORDER BY  A.ModelID, CONVERT(DATE, A.[RDate], 103) DESC
END
ELSE
BEGIN
   SELECT A.[IRID], A.[ItemID], A.[ModelID],CONVERT(DATE, A.[RDate],103), A.[Chlanno], A.[Suppliername], A.[LocID], A.[Quantity], 
   (SELECT SUM(B.[Quantity]) FROM [ITInventory].[dbo].[INV_ItemReceive] B WHERE CONVERT(DATE, B.[RDate], 103)<= CONVERT(DATE, A.[RDate], 103) AND A.ModelID=B.ModelID) AS RTotalQty 
   FROM [ITInventory].[dbo].[INV_ItemReceive] A  ORDER BY  A.ModelID, CONVERT(DATE, A.[RDate], 103) DESC
END
GO
/****** Object:  StoredProcedure [dbo].[spGetLoctionDeptBySearch]    Script Date: 02/27/2014 09:57:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetLoctionDeptBySearch]	
				  @Location AS nvarchar(100)
				, @DeptName AS nvarchar(100)
				
AS
--IF((@Location='HLNT' OR @Location='HLAP' OR @Location='HLBD' OR @Location='HLRC' OR @Location='HLWF' OR @Location='HYBD') and @DeptName='Please Select...')
--******** For only Location Selection
IF(@Location!='Please Select...') and (@DeptName='Please Select...')
	
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
    SELECT    A.Office
			, A.Proposed
			, A.AccountID
			, A.AccountCode
			, A.BrandModel
			, A.Category
			, A.Configuration
			, A.SerialNo
			, A.Location
			, A.DeptID
			, A.EMPID
			, A.EMPID AS EMPNAME
			, convert(date, A.PurchDate,103) as PurchDate
			, A.Remark
			, B.SerialNo AS MonitorID
			, C.SerialNo AS UPSID
			, A.Team, A.Status
			, A.HostName
			, A.ITemNo
			, A.DeviceID 
			FROM ITInventory.dbo.INV_InventoryInfo as A 
				LEFT OUTER JOIN ITInventory.dbo.INV_MonitorDetails AS B ON A.EMPID=B.EMPID 
				LEFT OUTER JOIN ITInventory.dbo.INV_UPSDetails AS C ON A.EMPID=C.EMPID 
				LEFT OUTER JOIN ITInventory.dbo.INV_EmployeeInfo AS E ON A.EMPID=E.EMPID 
				LEFT OUTER JOIN ITInventory.dbo.INV_Department AS D ON A.DeptID=D.DeptID 
			WHERE  
			A.DeviceID='22fc4927-cf7c-4e72-8575-2780eec97126' 
				and 
			A.Location=@Location
END
--*******FOR All Selection
ELSE IF(@Location='Please Select...') AND (@DeptName='Please Select...')

   BEGIN
   SELECT    A.Office
			, A.Proposed
			, A.AccountID
			, A.AccountCode
			, A.BrandModel
			, A.Category
			, A.Configuration
			, A.SerialNo
			, A.Location
			, A.DeptID
			, A.EMPID
			, A.EMPID AS EMPNAME
			, convert(date, A.PurchDate,103) as PurchDate
			, A.Remark
			, B.SerialNo AS MonitorID
			, C.SerialNo AS UPSID
			, A.Team, A.Status
			, A.HostName
			, A.ITemNo
			, A.DeviceID 
			FROM ITInventory.dbo.INV_InventoryInfo as A 
				LEFT OUTER JOIN ITInventory.dbo.INV_MonitorDetails AS B ON A.EMPID=B.EMPID 
				LEFT OUTER JOIN ITInventory.dbo.INV_UPSDetails AS C ON A.EMPID=C.EMPID 
				LEFT OUTER JOIN ITInventory.dbo.INV_EmployeeInfo AS E ON A.EMPID=E.EMPID 
				LEFT OUTER JOIN ITInventory.dbo.INV_Department AS D ON A.DeptID=D.DeptID 
			WHERE  
			A.DeviceID='22fc4927-cf7c-4e72-8575-2780eec97126' 				
END
---******* For Only Department Selection
ELSE IF(@Location='Please Select...') AND (@DeptName!='Please Select...')

 BEGIN
   SELECT    A.Office
			, A.Proposed
			, A.AccountID
			, A.AccountCode
			, A.BrandModel
			, A.Category
			, A.Configuration
			, A.SerialNo
			, A.Location
			, A.DeptID
			, A.EMPID
			, A.EMPID AS EMPNAME
			, convert(date, A.PurchDate,103) as PurchDate
			, A.Remark
			, B.SerialNo AS MonitorID
			, C.SerialNo AS UPSID
			, A.Team, A.Status
			, A.HostName
			, A.ITemNo
			, A.DeviceID 
			FROM ITInventory.dbo.INV_InventoryInfo as A 
				LEFT OUTER JOIN ITInventory.dbo.INV_MonitorDetails AS B ON A.EMPID=B.EMPID 
				LEFT OUTER JOIN ITInventory.dbo.INV_UPSDetails AS C ON A.EMPID=C.EMPID 
				LEFT OUTER JOIN ITInventory.dbo.INV_EmployeeInfo AS E ON A.EMPID=E.EMPID 
				LEFT OUTER JOIN ITInventory.dbo.INV_Department AS D ON A.DeptID=D.DeptID 
			WHERE  
			A.DeviceID='22fc4927-cf7c-4e72-8575-2780eec97126' 
				and 
			D.DeptName=@DeptName
END
ELSE
--- For Location and Department Selection
BEGIN
   SELECT    A.Office
			, A.Proposed
			, A.AccountID
			, A.AccountCode
			, A.BrandModel
			, A.Category
			, A.Configuration
			, A.SerialNo
			, A.Location
			, A.DeptID
			, A.EMPID
			, A.EMPID AS EMPNAME
			, convert(date, A.PurchDate,103) as PurchDate
			, A.Remark
			, B.SerialNo AS MonitorID
			, C.SerialNo AS UPSID
			, A.Team, A.Status
			, A.HostName
			, A.ITemNo
			, A.DeviceID 
			FROM ITInventory.dbo.INV_InventoryInfo as A 
				LEFT OUTER JOIN ITInventory.dbo.INV_MonitorDetails AS B ON A.EMPID=B.EMPID 
				LEFT OUTER JOIN ITInventory.dbo.INV_UPSDetails AS C ON A.EMPID=C.EMPID 
				LEFT OUTER JOIN ITInventory.dbo.INV_EmployeeInfo AS E ON A.EMPID=E.EMPID 
				LEFT OUTER JOIN ITInventory.dbo.INV_Department AS D ON A.DeptID=D.DeptID 
			WHERE  
			A.DeviceID='22fc4927-cf7c-4e72-8575-2780eec97126' 
				and 
			(A.Location=@Location AND D.DeptName=@DeptName)
END
GO
/****** Object:  StoredProcedure [dbo].[spMEfficincy]    Script Date: 02/27/2014 09:57:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spMEfficincy]
                --@YEARS AS VARCHAR(20)	
AS
DECLARE @Totaldays DECIMAL (18, 2)
DECLARE @Years     VARCHAR(20)
--SET @Totaldays=(datediff(day,DATEADD(YEAR, DATEDIFF(YEAR, 0,DATEADD(YEAR, 0,GETDATE())), 0),GETDATE())+1)
SET @Totaldays=(datediff(day,DATEADD(YEAR, DATEDIFF(YEAR, 0,DATEADD(YEAR, 0,CONVERT(DATE, '08/31/2013'))), 0),CONVERT(DATE, '08/31/2013'))+1)
SET @Years='2013'


BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
 SELECT 
    A.ENumber
    ,SUM(B.Idledays) AS Idledays
    ,CAST(((@Totaldays-SUM(B.Idledays))/@Totaldays)*100 as DECIMAL (18, 2)) as Efficiency
    ,B.YEARS
 from 
    dbo.Inv_Equipmentinfo AS A
    ,dbo.Inv_Idleentry AS B 
 where 
     B.YEARS=@Years
 AND 
     A.EID=B.EID  
 GROUP BY 
     A.ENumber
    ,B.YEARS
END
GO
/****** Object:  StoredProcedure [dbo].[spGetEquipmentBySearch]    Script Date: 02/27/2014 09:57:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetEquipmentBySearch]	
				  @location AS nvarchar(100)				
				
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
     
    SELECT A.EID
          ,A.LocID
          ,A.ENumber
		  ,A.AccountCode
          ,A.AssetCode
          ,A.Brand
          ,A.Model
          ,A.Serialno
          ,A.Subserialno
          ,A.MNID
          ,A.Machineid
          ,A.Lifetime
          ,A.PurchDate
          ,A.UnitID
          ,A.BNID
          ,A.FID
          ,A.LID
		  ,A.Status
		  ,A.Remarks
		  ,A.CID
  FROM [ITInventory].[dbo].[Inv_Equipmentinfo] A
  WHERE A.LocID=@location
   
END
GO
/****** Object:  Default [DF_Logininfo_UserID]    Script Date: 02/27/2014 09:57:29 ******/
ALTER TABLE [dbo].[Logininfo] ADD  CONSTRAINT [DF_Logininfo_UserID]  DEFAULT (newid()) FOR [UserID]
GO
/****** Object:  Default [DF_Login_info_UserID]    Script Date: 02/27/2014 09:57:29 ******/
ALTER TABLE [dbo].[Login_info] ADD  CONSTRAINT [DF_Login_info_UserID]  DEFAULT (newid()) FOR [UserID]
GO
/****** Object:  Default [DF_INV_Userinfo_UserinfoID]    Script Date: 02/27/2014 09:57:29 ******/
ALTER TABLE [dbo].[INV_Userinfo] ADD  CONSTRAINT [DF_INV_Userinfo_UserinfoID]  DEFAULT (newid()) FOR [UserinfoID]
GO
/****** Object:  Default [DF_INV_Devices_DeviceID]    Script Date: 02/27/2014 09:57:29 ******/
ALTER TABLE [dbo].[INV_Devices] ADD  CONSTRAINT [DF_INV_Devices_DeviceID]  DEFAULT (newid()) FOR [DeviceID]
GO
/****** Object:  Default [DF_INV_Department_DeptID]    Script Date: 02/27/2014 09:57:29 ******/
ALTER TABLE [dbo].[INV_Department] ADD  CONSTRAINT [DF_INV_Department_DeptID]  DEFAULT (newid()) FOR [DeptID]
GO
/****** Object:  Default [DF_INV_Country_CID]    Script Date: 02/27/2014 09:57:29 ******/
ALTER TABLE [dbo].[INV_Country] ADD  CONSTRAINT [DF_INV_Country_CID]  DEFAULT (newid()) FOR [CID]
GO
/****** Object:  Default [DF_INV_Buildinginfo_BNID]    Script Date: 02/27/2014 09:57:29 ******/
ALTER TABLE [dbo].[INV_Buildinginfo] ADD  CONSTRAINT [DF_INV_Buildinginfo_BNID]  DEFAULT (newid()) FOR [BNID]
GO
/****** Object:  Default [DF_INV_LeaveEntry_LEntryID]    Script Date: 02/27/2014 09:57:29 ******/
ALTER TABLE [dbo].[INV_LeaveEntry] ADD  CONSTRAINT [DF_INV_LeaveEntry_LEntryID]  DEFAULT (newid()) FOR [LEntryID]
GO
/****** Object:  Default [DF_INV_Items_ItemID]    Script Date: 02/27/2014 09:57:29 ******/
ALTER TABLE [dbo].[INV_Items] ADD  CONSTRAINT [DF_INV_Items_ItemID]  DEFAULT (newid()) FOR [ItemID]
GO
/****** Object:  Default [DF_INV_Unitentry_UnitID]    Script Date: 02/27/2014 09:57:29 ******/
ALTER TABLE [dbo].[INV_Unitentry] ADD  CONSTRAINT [DF_INV_Unitentry_UnitID]  DEFAULT (newid()) FOR [UnitID]
GO
/****** Object:  Default [DF_Inv_OLDInfo_OLDID]    Script Date: 02/27/2014 09:57:29 ******/
ALTER TABLE [dbo].[Inv_OLDInfo] ADD  CONSTRAINT [DF_Inv_OLDInfo_OLDID]  DEFAULT (newid()) FOR [OLDID]
GO
/****** Object:  Default [DF_INV_Machineinfo_MNID]    Script Date: 02/27/2014 09:57:29 ******/
ALTER TABLE [dbo].[INV_Machineinfo] ADD  CONSTRAINT [DF_INV_Machineinfo_MNID]  DEFAULT (newid()) FOR [MNID]
GO
/****** Object:  Default [DF_INV_Models_ModelID]    Script Date: 02/27/2014 09:57:29 ******/
ALTER TABLE [dbo].[INV_Models] ADD  CONSTRAINT [DF_INV_Models_ModelID]  DEFAULT (newid()) FOR [ModelID]
GO
/****** Object:  Default [DF_INV_Location_LocID]    Script Date: 02/27/2014 09:57:29 ******/
ALTER TABLE [dbo].[INV_Location] ADD  CONSTRAINT [DF_INV_Location_LocID]  DEFAULT (newid()) FOR [LocID]
GO
/****** Object:  Default [DF_INV_EmployeeInfo_EmpID]    Script Date: 02/27/2014 09:57:29 ******/
ALTER TABLE [dbo].[INV_EmployeeInfo] ADD  CONSTRAINT [DF_INV_EmployeeInfo_EmpID]  DEFAULT (newid()) FOR [EmpID]
GO
/****** Object:  Default [DF_Inv_Idleentry_IID]    Script Date: 02/27/2014 09:57:30 ******/
ALTER TABLE [dbo].[Inv_Idleentry] ADD  CONSTRAINT [DF_Inv_Idleentry_IID]  DEFAULT (newid()) FOR [IID]
GO
/****** Object:  Default [DF_INV_Floorinfo_FID]    Script Date: 02/27/2014 09:57:30 ******/
ALTER TABLE [dbo].[INV_Floorinfo] ADD  CONSTRAINT [DF_INV_Floorinfo_FID]  DEFAULT (newid()) FOR [FID]
GO
/****** Object:  Default [DF_INV_PrinterDetails_PrinterID]    Script Date: 02/27/2014 09:57:30 ******/
ALTER TABLE [dbo].[INV_PrinterDetails] ADD  CONSTRAINT [DF_INV_PrinterDetails_PrinterID]  DEFAULT (newid()) FOR [PrinterID]
GO
/****** Object:  Default [DF_INV_UPSDetails_UPSID]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_UPSDetails] ADD  CONSTRAINT [DF_INV_UPSDetails_UPSID]  DEFAULT (newid()) FOR [UPSID]
GO
/****** Object:  Default [DF_INV_ReceiveNissue_RIssueID]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_ReceiveNissue] ADD  CONSTRAINT [DF_INV_ReceiveNissue_RIssueID]  DEFAULT (newid()) FOR [RIssueID]
GO
/****** Object:  Default [DF_INV_Factorystock_FSID]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_Factorystock] ADD  CONSTRAINT [DF_INV_Factorystock_FSID]  DEFAULT (newid()) FOR [FSID]
GO
/****** Object:  Default [DF_INV_ItemReceive_IRID]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_ItemReceive] ADD  CONSTRAINT [DF_INV_ItemReceive_IRID]  DEFAULT (newid()) FOR [IRID]
GO
/****** Object:  Default [DF_INV_ItemIssue_IID]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_ItemIssue] ADD  CONSTRAINT [DF_INV_ItemIssue_IID]  DEFAULT (newid()) FOR [IID]
GO
/****** Object:  Default [DF_Inv_InventoryInfo_AccountID]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[Inv_InventoryInfo] ADD  CONSTRAINT [DF_Inv_InventoryInfo_AccountID]  DEFAULT (newid()) FOR [AccountID]
GO
/****** Object:  Default [DF_INV_Lineinfo_LID]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_Lineinfo] ADD  CONSTRAINT [DF_INV_Lineinfo_LID]  DEFAULT (newid()) FOR [LID]
GO
/****** Object:  Default [DF_INV_MonitorDetails_MonitorID]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_MonitorDetails] ADD  CONSTRAINT [DF_INV_MonitorDetails_MonitorID]  DEFAULT (newid()) FOR [MonitorID]
GO
/****** Object:  Default [DF_INV_Stock_SID]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_Stock] ADD  CONSTRAINT [DF_INV_Stock_SID]  DEFAULT (newid()) FOR [SID]
GO
/****** Object:  Default [DF_INV_Service_ServiceID]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_Service] ADD  CONSTRAINT [DF_INV_Service_ServiceID]  DEFAULT (newid()) FOR [ServiceID]
GO
/****** Object:  Default [DF_Inv_Equipmentinfo_EID]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[Inv_Equipmentinfo] ADD  CONSTRAINT [DF_Inv_Equipmentinfo_EID]  DEFAULT (newid()) FOR [EID]
GO
/****** Object:  Default [DF_INV_Userissue_UIssueID]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_Userissue] ADD  CONSTRAINT [DF_INV_Userissue_UIssueID]  DEFAULT (newid()) FOR [UIssueID]
GO
/****** Object:  ForeignKey [FK__INV_Model__ItemI__4EDDB18F]    Script Date: 02/27/2014 09:57:29 ******/
ALTER TABLE [dbo].[INV_Models]  WITH CHECK ADD FOREIGN KEY([ItemID])
REFERENCES [dbo].[INV_Items] ([ItemID])
GO
/****** Object:  ForeignKey [FK__INV_Locat__Count__592635D8]    Script Date: 02/27/2014 09:57:29 ******/
ALTER TABLE [dbo].[INV_Location]  WITH CHECK ADD FOREIGN KEY([CountryID])
REFERENCES [dbo].[INV_Country] ([CID])
GO
/****** Object:  ForeignKey [FK__INV_Emplo__DeptI__1209AD79]    Script Date: 02/27/2014 09:57:29 ******/
ALTER TABLE [dbo].[INV_EmployeeInfo]  WITH CHECK ADD FOREIGN KEY([DeptID])
REFERENCES [dbo].[INV_Department] ([DeptID])
GO
/****** Object:  ForeignKey [FK__Inv_Idlee__UnitI__48EFCE0F]    Script Date: 02/27/2014 09:57:30 ******/
ALTER TABLE [dbo].[Inv_Idleentry]  WITH CHECK ADD FOREIGN KEY([UnitID])
REFERENCES [dbo].[INV_Unitentry] ([UnitID])
GO
/****** Object:  ForeignKey [FK__INV_FTYTr__ItemI__52AE4273]    Script Date: 02/27/2014 09:57:30 ******/
ALTER TABLE [dbo].[INV_FTYTransfer]  WITH CHECK ADD FOREIGN KEY([ItemID])
REFERENCES [dbo].[INV_Items] ([ItemID])
GO
/****** Object:  ForeignKey [FK__INV_Floori__BNID__62AFA012]    Script Date: 02/27/2014 09:57:30 ******/
ALTER TABLE [dbo].[INV_Floorinfo]  WITH CHECK ADD FOREIGN KEY([BNID])
REFERENCES [dbo].[INV_Buildinginfo] ([BNID])
GO
/****** Object:  ForeignKey [FK__INV_Print__DeptI__7B264821]    Script Date: 02/27/2014 09:57:30 ******/
ALTER TABLE [dbo].[INV_PrinterDetails]  WITH CHECK ADD FOREIGN KEY([DeptID])
REFERENCES [dbo].[INV_Department] ([DeptID])
GO
/****** Object:  ForeignKey [FK__INV_Print__Devic__7C1A6C5A]    Script Date: 02/27/2014 09:57:30 ******/
ALTER TABLE [dbo].[INV_PrinterDetails]  WITH CHECK ADD FOREIGN KEY([DeviceID])
REFERENCES [dbo].[INV_Devices] ([DeviceID])
GO
/****** Object:  ForeignKey [FK__INV_UPSDe__DeptI__6EC0713C]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_UPSDetails]  WITH CHECK ADD FOREIGN KEY([DeptID])
REFERENCES [dbo].[INV_Department] ([DeptID])
GO
/****** Object:  ForeignKey [FK_INV_UPSDetails_INV_EmployeeInfo]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_UPSDetails]  WITH CHECK ADD  CONSTRAINT [FK_INV_UPSDetails_INV_EmployeeInfo] FOREIGN KEY([EmpID])
REFERENCES [dbo].[INV_EmployeeInfo] ([EmpID])
GO
ALTER TABLE [dbo].[INV_UPSDetails] CHECK CONSTRAINT [FK_INV_UPSDetails_INV_EmployeeInfo]
GO
/****** Object:  ForeignKey [FK__INV_Recei__ItemI__61F08603]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_ReceiveNissue]  WITH CHECK ADD FOREIGN KEY([ItemID])
REFERENCES [dbo].[INV_Items] ([ItemID])
GO
/****** Object:  ForeignKey [FK__INV_Recei__Model__62E4AA3C]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_ReceiveNissue]  WITH CHECK ADD FOREIGN KEY([ModelID])
REFERENCES [dbo].[INV_Models] ([ModelID])
GO
/****** Object:  ForeignKey [FK__INV_Facto__ItemI__035179CE]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_Factorystock]  WITH CHECK ADD FOREIGN KEY([ItemID])
REFERENCES [dbo].[INV_Items] ([ItemID])
GO
/****** Object:  ForeignKey [FK__INV_Facto__Model__04459E07]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_Factorystock]  WITH CHECK ADD FOREIGN KEY([ModelID])
REFERENCES [dbo].[INV_Models] ([ModelID])
GO
/****** Object:  ForeignKey [FK__INV_ItemR__ItemI__567ED357]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_ItemReceive]  WITH CHECK ADD FOREIGN KEY([ItemID])
REFERENCES [dbo].[INV_Items] ([ItemID])
GO
/****** Object:  ForeignKey [FK__INV_ItemR__Model__5772F790]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_ItemReceive]  WITH CHECK ADD FOREIGN KEY([ModelID])
REFERENCES [dbo].[INV_Models] ([ModelID])
GO
/****** Object:  ForeignKey [FK__INV_ItemI__ItemI__5C37ACAD]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_ItemIssue]  WITH CHECK ADD FOREIGN KEY([ItemID])
REFERENCES [dbo].[INV_Items] ([ItemID])
GO
/****** Object:  ForeignKey [FK__INV_ItemI__Model__5D2BD0E6]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_ItemIssue]  WITH CHECK ADD FOREIGN KEY([ModelID])
REFERENCES [dbo].[INV_Models] ([ModelID])
GO
/****** Object:  ForeignKey [FK__Inv_Inven__DeptI__184C96B4]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[Inv_InventoryInfo]  WITH CHECK ADD FOREIGN KEY([DeptID])
REFERENCES [dbo].[INV_Department] ([DeptID])
GO
/****** Object:  ForeignKey [FK__Inv_Inven__Devic__1A34DF26]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[Inv_InventoryInfo]  WITH CHECK ADD FOREIGN KEY([DeviceID])
REFERENCES [dbo].[INV_Devices] ([DeviceID])
GO
/****** Object:  ForeignKey [FK__Inv_Inven__EMPID__1940BAED]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[Inv_InventoryInfo]  WITH CHECK ADD FOREIGN KEY([EMPID])
REFERENCES [dbo].[INV_EmployeeInfo] ([EmpID])
GO
/****** Object:  ForeignKey [FK__INV_Lineinf__FID__668030F6]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_Lineinfo]  WITH CHECK ADD FOREIGN KEY([FID])
REFERENCES [dbo].[INV_Floorinfo] ([FID])
GO
/****** Object:  ForeignKey [FK__INV_Monit__DeptI__69FBBC1F]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_MonitorDetails]  WITH CHECK ADD FOREIGN KEY([DeptID])
REFERENCES [dbo].[INV_Department] ([DeptID])
GO
/****** Object:  ForeignKey [FK_INV_MonitorDetails_INV_EmployeeInfo]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_MonitorDetails]  WITH CHECK ADD  CONSTRAINT [FK_INV_MonitorDetails_INV_EmployeeInfo] FOREIGN KEY([EmpID])
REFERENCES [dbo].[INV_EmployeeInfo] ([EmpID])
GO
ALTER TABLE [dbo].[INV_MonitorDetails] CHECK CONSTRAINT [FK_INV_MonitorDetails_INV_EmployeeInfo]
GO
/****** Object:  ForeignKey [FK__INV_Stock__ItemI__71F1E3A2]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_Stock]  WITH CHECK ADD FOREIGN KEY([ItemID])
REFERENCES [dbo].[INV_Items] ([ItemID])
GO
/****** Object:  ForeignKey [FK__INV_Stock__Model__72E607DB]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_Stock]  WITH CHECK ADD FOREIGN KEY([ModelID])
REFERENCES [dbo].[INV_Models] ([ModelID])
GO
/****** Object:  ForeignKey [FK__INV_Servi__Accou__21D600EE]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_Service]  WITH CHECK ADD FOREIGN KEY([AccountID])
REFERENCES [dbo].[Inv_InventoryInfo] ([AccountID])
GO
/****** Object:  ForeignKey [FK__Inv_Equip__LocID__01342732]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[Inv_Equipmentinfo]  WITH CHECK ADD FOREIGN KEY([LocID])
REFERENCES [dbo].[INV_Location] ([LocID])
GO
/****** Object:  ForeignKey [FK__Inv_Equip__UnitI__004002F9]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[Inv_Equipmentinfo]  WITH CHECK ADD FOREIGN KEY([UnitID])
REFERENCES [dbo].[INV_Unitentry] ([UnitID])
GO
/****** Object:  ForeignKey [FK__Inv_Equipm__BNID__041093DD]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[Inv_Equipmentinfo]  WITH CHECK ADD FOREIGN KEY([BNID])
REFERENCES [dbo].[INV_Buildinginfo] ([BNID])
GO
/****** Object:  ForeignKey [FK__Inv_Equipm__MNID__031C6FA4]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[Inv_Equipmentinfo]  WITH CHECK ADD FOREIGN KEY([MNID])
REFERENCES [dbo].[INV_Machineinfo] ([MNID])
GO
/****** Object:  ForeignKey [FK__Inv_Equipme__CID__02284B6B]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[Inv_Equipmentinfo]  WITH CHECK ADD FOREIGN KEY([CID])
REFERENCES [dbo].[INV_Country] ([CID])
GO
/****** Object:  ForeignKey [FK__Inv_Equipme__FID__0504B816]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[Inv_Equipmentinfo]  WITH CHECK ADD FOREIGN KEY([FID])
REFERENCES [dbo].[INV_Floorinfo] ([FID])
GO
/****** Object:  ForeignKey [FK__Inv_Equipme__LID__05F8DC4F]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[Inv_Equipmentinfo]  WITH CHECK ADD FOREIGN KEY([LID])
REFERENCES [dbo].[INV_Lineinfo] ([LID])
GO
/****** Object:  ForeignKey [FK__INV_Useri__DeptI__6A85CC04]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_Userissue]  WITH CHECK ADD FOREIGN KEY([DeptID])
REFERENCES [dbo].[INV_Department] ([DeptID])
GO
/****** Object:  ForeignKey [FK__INV_Useri__EmpID__6991A7CB]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_Userissue]  WITH CHECK ADD FOREIGN KEY([EmpID])
REFERENCES [dbo].[INV_EmployeeInfo] ([EmpID])
GO
/****** Object:  ForeignKey [FK__INV_Useri__ItemI__67A95F59]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_Userissue]  WITH CHECK ADD FOREIGN KEY([ItemID])
REFERENCES [dbo].[INV_Items] ([ItemID])
GO
/****** Object:  ForeignKey [FK__INV_Useri__Model__689D8392]    Script Date: 02/27/2014 09:57:35 ******/
ALTER TABLE [dbo].[INV_Userissue]  WITH CHECK ADD FOREIGN KEY([ModelID])
REFERENCES [dbo].[INV_Models] ([ModelID])
GO
