USE [hms]
GO

/****** Object:  Table [dbo].[UserConfig]    Script Date: 26-06-2021 13:35:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserConfig](
	[UserName] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Address] [varchar](100) NULL,
	[CityId] [int] NULL,
	[StateId] [int] NULL,
	[PinCode] [int] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL
) ON [PRIMARY]
GO


