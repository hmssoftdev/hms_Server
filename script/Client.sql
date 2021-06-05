USE [hms]
GO

/****** Object:  Table [dbo].[Client]    Script Date: 05-06-2021 16:11:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[Business] [varchar](100) NULL,
	[CategoryId] [int] NULL,
	[CategoryName] [varchar](100) NULL,
	[Address] [varchar](100) NULL,
	[Gst] [int] NULL
) ON [PRIMARY]
GO


