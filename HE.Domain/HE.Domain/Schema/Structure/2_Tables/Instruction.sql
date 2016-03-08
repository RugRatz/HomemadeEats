USE [HomemadeEats]

/****** Object:  Table [dbo].[Instruction]    Script Date: 3/4/2016 10:56:46 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Instruction](
	[InstructionID] [int] IDENTITY(1,1) NOT NULL,
	[Notes] [nvarchar](max) NOT NULL,
	[HomemadeItemID] [int] NOT NULL,
	[IngredientID] [int] NOT NULL,
	[DateCreatedUTC] [datetime] NULL,
	[LastUpdatedUTC] [datetime] NULL,
 CONSTRAINT [PK_dbo.Instruction] PRIMARY KEY CLUSTERED 
(
	[InstructionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]