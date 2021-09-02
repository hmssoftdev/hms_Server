USE [hms_db]
GO

/****** Object:  Table [dbo].[Dish]    Script Date: 02-09-2021 14:34:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Dish](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[Name] [varchar](100) NULL,
	[Description] [varchar](100) NULL,
	[HalfPrice] [int] NULL,
	[FullPrice] [int] NULL,
	[HotelId] [int] NULL,
	[MainCategoryId] [int] NULL,
	[IsVeg] [bit] NULL,
	[TimeForCook] [int] NULL,
	[NonVegCategory] [varchar](100) NULL,
	[Quantity] [int] NULL,
	[status] [varchar](100) NULL,
	[ImageUrl] [varchar](200) NULL,
	[files] [varchar](200) NULL,
	[IsFull] [bit] NULL
) ON [PRIMARY]
GO


