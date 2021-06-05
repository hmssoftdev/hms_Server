USE [hms]
GO

/****** Object:  Table [dbo].[Dish]    Script Date: 05-06-2021 14:02:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Dish](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsActiv] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[Name] [varchar](100) NULL,
	[Description] [int] NULL,
	[HalfPrice] [int] NULL,
	[FullPrice] [int] NULL,
	[HotelId] [int] NULL,
	[MainCategoryId] [int] NULL,
	[IsVeg] [bit] NULL,
	[IsHalf] [bit] NULL,
	[IsFull] [bit] NULL
) ON [PRIMARY]
GO


