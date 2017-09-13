USE [TLGPizza]
GO

/****** Object:  Table [TLGPizza].[Taxes]    Script Date: 9/12/2017 3:16:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TLGPizza].[Taxes](
	[tax_id] [int] NOT NULL,
	[amount] [decimal](18, 0) NOT NULL,
	[rate] [int] NOT NULL,
	[jurisdiction] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Taxes] PRIMARY KEY CLUSTERED 
(
	[tax_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

