USE [hms_db]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 14-09-2021 15:12:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedOn] [date] NULL,
	[UpdatedBy] [int] NULL,
	[Name] [varchar](50) NULL,
	[UserType] [int] NULL,
	[UserName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Contact] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Address] [varchar](100) NULL,
	[CityId] [int] NULL,
	[StateId] [int] NULL,
	[PinCode] [varchar](50) NULL
) ON [PRIMARY]
GO


