USE [HomemadeEats]

/****** Object:  Table [dbo].[Grocery]    Script Date: 3/4/2016 10:55:37 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Grocery](
	[GroceryID] [int] IDENTITY(1,1) NOT NULL,
	[HomemadeItemID] [int] NOT NULL,
	[IsCompleted] [bit] NULL,
	[DateCreatedUTC] [datetime] NULL,
	[LastUpdatedUTC] [datetime] NULL,
 CONSTRAINT [PK_dbo.Grocery] PRIMARY KEY CLUSTERED 
(
	[GroceryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]