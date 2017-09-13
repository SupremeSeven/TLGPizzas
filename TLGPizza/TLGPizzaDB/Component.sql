USE [TLGPizza]
GO

/****** Object:  Table [TLGPizza].[Component]    Script Date: 9/13/2017 1:22:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TLGPizza].[Component](
	[ComponentId] [int] NOT NULL,
	[ComponentSKU] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [decimal](18, 0) NOT NULL,
	[Taxable] [bit] NOT NULL,
	[Description] [varchar](max) NULL,
 CONSTRAINT [PK_DatagramTransactionOrderAssemblyItemComponent] PRIMARY KEY CLUSTERED 
(
	[ComponentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

