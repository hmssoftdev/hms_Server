USE [hms]
GO

/****** Object:  Table [dbo].[Admin]    Script Date: 02-08-2021 13:23:13 ******/
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
	[CategoryId] [int] NULL,
	[FoodLincNum] [varchar](50) NULL,
	[Address] [varchar](100) NULL,
	[Gst] [varchar](50) NULL,
	[AccountName] [varchar](100) NULL,
	[AccountNumber] [varchar](50) NULL,
	[BankName] [varchar](100) NULL,
	[IfscCode] [varchar](100) NULL,
	[PinCode] [varchar](50) NULL,
	[RestaurentLogo] [varchar](100) NULL,
	[Signature] [varchar](100) NULL,
	[TermAndCondition] [varchar](100) NULL,
	[BankAddress] [varchar](100) NULL,
	[CodeImage] [varchar](100) NULL,
	[CodeNumber] [varchar](100) NULL,
	[CityId] [int] NULL,
	[StateId] [int] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[SubscriptionStatus] [int] NULL,
	[Contact] [varchar](100) NULL,
	[Email] [varchar](100) NULL
) ON [PRIMARY]
GO


