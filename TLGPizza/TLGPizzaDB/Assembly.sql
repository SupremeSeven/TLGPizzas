USE [TLGPizza]
GO

/****** Object:  Table [TLGPizza].[Assembly]    Script Date: 9/13/2017 1:40:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TLGPizza].[Assembly](
	[AssemblyId] [int] NOT NULL,
	[ItemId] [int] NOT NULL,
	[SKU] [varchar](50) NOT NULL,
	[Description] [varchar](max) NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [decimal](18, 0) NOT NULL,
	[Taxable] [bit] NOT NULL,
 CONSTRAINT [PK_Assemblies] PRIMARY KEY CLUSTERED 
(
	[AssemblyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [TLGPizza].[Assembly]  WITH CHECK ADD  CONSTRAINT [FK_Assembly_Item] FOREIGN KEY([ItemId])
REFERENCES [TLGPizza].[Item] ([ItemId])
GO

ALTER TABLE [TLGPizza].[Assembly] CHECK CONSTRAINT [FK_Assembly_Item]
GO

