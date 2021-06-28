USE [hms]
GO

/****** Object:  Table [dbo].[Dish]    Script Date: 26-06-2021 13:34:43 ******/
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
	[Quantity] [int] NULL,
	[TimeForCook] [int] NULL,
	[IsVeg] [bit] NULL,
	[NonVegCategory] [varchar](100) NULL,
	[status] [varchar](100) NULL,
	[ImageUrl] [varchar](100) NULL
) ON [PRIMARY]
GO


