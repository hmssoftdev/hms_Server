USE [hms]
GO

/****** Object:  Table [dbo].[UserFeedback]    Script Date: 14-06-2021 13:26:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserFeedback](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[Rating] [int] NULL,
	[OpinionText] [varchar](100) NULL,
	[ReviewTitle] [varchar](100) NULL,
	[TermsAccept] [bit] NULL
) ON [PRIMARY]
GO


