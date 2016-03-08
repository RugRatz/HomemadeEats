USE [HomemadeEats]

/****** Object:  Table [dbo].[IngredientCategory]    Script Date: 3/4/2016 10:56:29 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[IngredientCategory](
	[IngredientCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsSystemDefault] [bit] NULL,
	[DateCreatedUTC] [datetime] NULL,
	[LastUpdatedUTC] [datetime] NULL,
 CONSTRAINT [PK_dbo.IngredientCategory] PRIMARY KEY CLUSTERED 
(
	[IngredientCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]