USE [hms_db]
GO

/****** Object:  Table [dbo].[DishOrder]    Script Date: 06-09-2021 15:32:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DishOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DeliveryTotal] [decimal](18, 0) NULL,
	[GrossTotal] [decimal](18, 0) NULL,
	[ItemCount] [decimal](18, 0) NULL,
	[ItemTotal] [decimal](18, 0) NULL,
	[AdminId] [int] NULL,
	[DeliveryOptionId] [int] NULL,
	[PaymentMode] [int] NULL,
	[UserId] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL
) ON [PRIMARY]
GO


