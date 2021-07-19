USE [hms]
GO

/****** Object:  Table [dbo].[Hotel]    Script Date: 19-07-2021 16:38:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Hotel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[Name] [varchar](100) NULL,
	[Size] [int] NULL,
	[IsAc] [bit] NULL,
	[Shape] [varchar](100) NULL,
	[BarcodeTest] [varchar](100) NULL
) ON [PRIMARY]
GO


