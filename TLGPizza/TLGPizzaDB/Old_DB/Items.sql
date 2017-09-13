USE [TLGPizza]
GO

/****** Object:  Table [TLGPizza].[Items]    Script Date: 9/12/2017 3:16:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TLGPizza].[Items](
	[item_id] [int] NOT NULL,
	[description] [varchar](max) NOT NULL,
	[quantity] [int] NOT NULL,
	[unit_price] [decimal](18, 0) NOT NULL,
	[taxable] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

