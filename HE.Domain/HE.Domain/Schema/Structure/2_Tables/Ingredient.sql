USE [HomemadeEats]

/****** Object:  Table [dbo].[Ingredient]    Script Date: 3/4/2016 10:56:19 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Ingredient](
	[IngredientID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[IngredientCategoryID] [int] NOT NULL,
	[HomemadeItemID] [int] NOT NULL,
	[DateCreatedUTC] [datetime] NULL,
	[LastUpdatedUTC] [datetime] NULL,
 CONSTRAINT [PK_dbo.Ingredient] PRIMARY KEY CLUSTERED 
(
	[IngredientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]