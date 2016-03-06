USE [HomemadeEats]

/****** Object:  Table [dbo].[CustomerContactInfo]    Script Date: 3/4/2016 10:30:37 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[CustomerContactInfo](
	[CustomerContactInfoID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerProfileID] [nvarchar](128) NOT NULL,
	[IsActive] [bit] NULL,
	[Street] [nvarchar](40) NULL,
	[City] [nvarchar](20) NULL,
	[StateOrProvince] [nvarchar](15) NULL,
	[ZipOrPostalCode] [nvarchar](12) NULL,
	[Country] [nvarchar](48) NULL,
	[DateCreatedUTC] [datetime] NULL,
	[LastUpdatedUTC] [datetime] NULL,
 CONSTRAINT [PK_dbo.CustomerContactInfo] PRIMARY KEY CLUSTERED 
(
	[CustomerContactInfoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]