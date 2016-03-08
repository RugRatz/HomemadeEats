USE [HomemadeEats]

/****** Object:  Table [dbo].[IngredientNote]    Script Date: 3/4/2016 10:56:37 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[IngredientNote](
	[IngredientNoteID] [int] IDENTITY(1,1) NOT NULL,
	[IngredientID] [int] NOT NULL,
	[Note] [nvarchar](250) NULL,
	[DateCreatedUTC] [datetime] NULL,
	[LastUpdatedUTC] [datetime] NULL,
 CONSTRAINT [PK_dbo.IngredientNote] PRIMARY KEY CLUSTERED 
(
	[IngredientNoteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]