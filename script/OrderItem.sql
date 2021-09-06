USE [hms_db]
GO

/****** Object:  Table [dbo].[OrderItem]    Script Date: 06-09-2021 15:33:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrderItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NULL,
	[ProductId] [int] NULL,
	[Price] [numeric](18, 0) NULL,
	[GstCompliance] [numeric](18, 0) NULL,
	[GstPrice] [numeric](18, 0) NULL,
	[IsFull] [bit] NULL,
	[OrderID] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL
) ON [PRIMARY]
GO


