USE [TLGPizza]
GO

/****** Object:  Table [TLGPizza].[Transactions]    Script Date: 9/12/2017 3:17:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TLGPizza].[Transactions](
	[transaction_id] [int] NOT NULL,
	[timestamp] [datetime] NOT NULL,
	[customer_id] [int] NOT NULL,
	[order_id] [int] NOT NULL,
	[payment_id] [int] NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[transaction_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [TLGPizza].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Customers] FOREIGN KEY([customer_id])
REFERENCES [TLGPizza].[Customers] ([customer_id])
GO

ALTER TABLE [TLGPizza].[Transactions] CHECK CONSTRAINT [FK_Transactions_Customers]
GO

ALTER TABLE [TLGPizza].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Orders] FOREIGN KEY([order_id])
REFERENCES [TLGPizza].[Orders] ([order_id])
GO

ALTER TABLE [TLGPizza].[Transactions] CHECK CONSTRAINT [FK_Transactions_Orders]
GO

ALTER TABLE [TLGPizza].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Payments] FOREIGN KEY([payment_id])
REFERENCES [TLGPizza].[Payments] ([payment_id])
GO

ALTER TABLE [TLGPizza].[Transactions] CHECK CONSTRAINT [FK_Transactions_Payments]
GO

