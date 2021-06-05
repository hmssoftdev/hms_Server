USE [hms]
GO

/****** Object:  Table [dbo].[ClientBankDetail]    Script Date: 05-06-2021 15:55:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ClientBankDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[AccountName] [varchar](100) NULL,
	[AccountNumber] [int] NULL,
	[BankName] [varchar](100) NULL,
	[IfscCode] [varchar](100) NULL,
	[Address] [varchar](100) NULL
) ON [PRIMARY]
GO


