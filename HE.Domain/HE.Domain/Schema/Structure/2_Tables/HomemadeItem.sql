USE [HomemadeEats]

/****** Object:  Table [dbo].[HomemadeItem]    Script Date: 3/4/2016 10:56:09 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[HomemadeItem](
	[HomemadeItemID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerProfileID] [int] NOT NULL,
	[MealTypeID] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[ImageTitle] [nvarchar](256) NULL,
	[ImageFilePath] [nvarchar](256) NULL,
	[DidCook] [bit] NULL,
	[IsFav] [bit] NULL,
	[IsShared] [bit] NULL,
	[AdditionalComments] [nvarchar](300) NULL,
	[DateCreatedUTC] [datetime] NULL,
	[LastUpdatedUTC] [datetime] NULL,
 CONSTRAINT [PK_dbo.HomemadeItem] PRIMARY KEY CLUSTERED 
(
	[HomemadeItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]