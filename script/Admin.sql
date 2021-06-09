USE [hms]
GO

/****** Object:  Table [dbo].[Admin]    Script Date: 09-06-2021 12:07:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[BusinessName] [varchar](100) NULL,
	[Category] [varchar](100) NULL,
	[FoodLincNum] [int] NULL,
	[Address] [varchar](100) NULL,
	[Gst] [int] NULL,
	[AccountName] [varchar](100) NULL,
	[AccountNumber] [int] NULL,
	[BankName] [varchar](100) NULL,
	[IfscCode] [varchar](100) NULL,
	[PinCode] [int] NULL,
	[RestaurentLogo] [varchar](100) NULL,
	[Signature] [varchar](100) NULL,
	[TermAndCondition] [varchar](100) NULL
) ON [PRIMARY]
GO


