USE [hms]
GO

/****** Object:  Table [dbo].[StateMaster]    Script Date: 10-06-2021 18:35:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StateMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[Name] [varchar](100) NULL
) ON [PRIMARY]
GO


