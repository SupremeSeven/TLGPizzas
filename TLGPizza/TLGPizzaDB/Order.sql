USE [TLGPizza]
GO

/****** Object:  Table [TLGPizza].[Order]    Script Date: 9/13/2017 1:41:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TLGPizza].[Order](
	[OrderId] [int] NOT NULL,
	[AssemblyId] [int] NOT NULL,
	[OrderingStoreId] [int] NOT NULL,
	[ProducingStoreId] [int] NOT NULL,
	[ReadyTime] [datetime] NULL,
	[ReadyTimeSpecified] [bit] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [TLGPizza].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Assembly] FOREIGN KEY([AssemblyId])
REFERENCES [TLGPizza].[Assembly] ([AssemblyId])
GO

ALTER TABLE [TLGPizza].[Order] CHECK CONSTRAINT [FK_Order_Assembly]
GO

ALTER TABLE [TLGPizza].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Ordering_Store] FOREIGN KEY([OrderingStoreId])
REFERENCES [TLGPizza].[Store] ([StoreId])
GO

ALTER TABLE [TLGPizza].[Order] CHECK CONSTRAINT [FK_Order_Ordering_Store]
GO

ALTER TABLE [TLGPizza].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Producing_Store] FOREIGN KEY([ProducingStoreId])
REFERENCES [TLGPizza].[Store] ([StoreId])
GO

ALTER TABLE [TLGPizza].[Order] CHECK CONSTRAINT [FK_Order_Producing_Store]
GO

