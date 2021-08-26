USE [hms_db]
GO

/****** Object:  Table [dbo].[Hotel]    Script Date: 26-08-2021 13:09:58 ******/
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
	[Seat] [int] NULL,
	[IsAc] [bit] NULL,
	[Shape] [varchar](100) NULL,
	[BarcodeTest] [varchar](100) NULL
) ON [PRIMARY]
GO


