USE [TLGPizza]
GO

/****** Object:  Table [TLGPizza].[Addresses]    Script Date: 9/12/2017 3:15:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TLGPizza].[Addresses](
	[address_id] [int] NOT NULL,
	[address_type] [varchar](50) NOT NULL,
	[address_line1] [varchar](max) NOT NULL,
	[address_line2] [varchar](max) NOT NULL,
	[city] [varchar](50) NOT NULL,
	[state] [varchar](50) NOT NULL,
	[postal_code] [int] NOT NULL,
	[mobile_phone] [int] NOT NULL,
	[alt_phone] [int] NOT NULL,
	[address_notes] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[address_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

