USE [hms]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 24-07-2021 16:23:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[Name] [varchar](100) NULL,
	[UserType] [int] NULL,
	[UserName] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Mobile] [varchar](100) NULL,
	[Password] [varchar](100) NULL
) ON [PRIMARY]
GO


