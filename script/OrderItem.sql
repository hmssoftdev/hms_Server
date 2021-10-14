USE [hms_db]
GO

/****** Object:  Table [dbo].[OrderItem]    Script Date: 14-10-2021 02:32:55 PM ******/
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
	[UpdatedBy] [int] NULL,
	[GstTotal] [numeric](18, 0) NULL,
	[KotPrinted] [bit] NULL
) ON [PRIMARY]
GO


