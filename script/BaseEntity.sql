USE [hms]
GO

/****** Object:  Table [dbo].[BaseEntity]    Script Date: 05-06-2021 16:23:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BaseEntity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UserName] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Address] [varchar](100) NULL
) ON [PRIMARY]
GO


