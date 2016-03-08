USE [HomemadeEats]

/****** Object:  Table [dbo].[GroceryGroupIngredient]    Script Date: 3/4/2016 10:56:00 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[GroceryGroupIngredient](
	[GroceryGroupIngredientID] [int] IDENTITY(1,1) NOT NULL,
	[GroceryGroupID] [int] NOT NULL,
	[IngredientID] [int] NOT NULL,
	[IsDone] [bit] NULL,
 CONSTRAINT [PK_dbo.GroceryGroupIngredient] PRIMARY KEY CLUSTERED 
(
	[GroceryGroupIngredientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]