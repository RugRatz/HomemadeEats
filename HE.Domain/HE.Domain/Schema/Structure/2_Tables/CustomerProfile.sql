USE [HomemadeEats]

/****** Object:  Table [dbo].[CustomerProfile]    Script Date: 3/4/2016 10:32:31 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[CustomerProfile](
	[CustomerProfileID] [nvarchar](128) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[AvatarTitle] [nvarchar](150) NULL,
	[AvatarFilePath] [nvarchar](256) NULL,
	[DateCreatedUtc] [datetime] NULL,
	[LastUpdatedUtc] [datetime] NULL,
	[EmailAddress] [nvarchar](100) NULL,
	[EmailAddressConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorAuthEnabled] [bit] NOT NULL,
	[LockoutEndDateUTC] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.CustomerProfile] PRIMARY KEY CLUSTERED 
(
	[CustomerProfileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]