USE [HomemadeEats]

/****** Object:  Table [dbo].[GroceryGroup]    Script Date: 3/4/2016 10:55:47 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[GroceryGroup](
	[GroceryGroupID] [int] IDENTITY(1,1) NOT NULL,
	[IsDone] [bit] NULL,
	[IngredientCategoryID] [int] NOT NULL,
	[GroceryID] [int] NOT NULL,
	[DateCreatedUTC] [datetime] NULL,
	[LastUpdatedUTC] [datetime] NULL,
 CONSTRAINT [PK_dbo.GroceryGroup] PRIMARY KEY CLUSTERED 
(
	[GroceryGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]