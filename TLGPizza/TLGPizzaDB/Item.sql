USE [TLGPizza]
GO

/****** Object:  Table [TLGPizza].[Item]    Script Date: 9/13/2017 1:40:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TLGPizza].[Item](
	[ItemId] [int] NOT NULL,
	[ComponentId] [int] NOT NULL,
	[Notes] [varchar](max) NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [TLGPizza].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Component] FOREIGN KEY([ComponentId])
REFERENCES [TLGPizza].[Component] ([ComponentId])
GO

ALTER TABLE [TLGPizza].[Item] CHECK CONSTRAINT [FK_Item_Component]
GO

