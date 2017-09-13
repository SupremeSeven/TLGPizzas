USE [TLGPizza]
GO

/****** Object:  Table [TLGPizza].[Assemblies]    Script Date: 9/12/2017 3:15:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TLGPizza].[Assemblies](
	[assembly_id] [int] NOT NULL,
	[item_id] [int] NOT NULL,
	[description] [varchar](max) NOT NULL,
	[quantity] [int] NOT NULL,
	[unit_price] [decimal](18, 0) NOT NULL,
	[taxable] [decimal](18, 0) NOT NULL,
	[notes] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Assemblies] PRIMARY KEY CLUSTERED 
(
	[assembly_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [TLGPizza].[Assemblies]  WITH CHECK ADD  CONSTRAINT [FK_Assemblies_Items] FOREIGN KEY([item_id])
REFERENCES [TLGPizza].[Items] ([item_id])
GO

ALTER TABLE [TLGPizza].[Assemblies] CHECK CONSTRAINT [FK_Assemblies_Items]
GO

