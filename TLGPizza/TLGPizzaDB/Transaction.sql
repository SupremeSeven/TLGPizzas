USE [TLGPizza]
GO

/****** Object:  Table [TLGPizza].[Transaction]    Script Date: 9/13/2017 1:24:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TLGPizza].[Transaction](
	[TransactionId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[PaymentId] [int] NOT NULL,
	[Timestamp] [datetime] NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [TLGPizza].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Customer] FOREIGN KEY([CustomerId])
REFERENCES [TLGPizza].[Customer] ([CustomerId])
GO

ALTER TABLE [TLGPizza].[Transaction] CHECK CONSTRAINT [FK_Transaction_Customer]
GO

ALTER TABLE [TLGPizza].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Order] FOREIGN KEY([OrderId])
REFERENCES [TLGPizza].[Order] ([OrderId])
GO

ALTER TABLE [TLGPizza].[Transaction] CHECK CONSTRAINT [FK_Transaction_Order]
GO

ALTER TABLE [TLGPizza].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Payment] FOREIGN KEY([PaymentId])
REFERENCES [TLGPizza].[Payment] ([PaymentId])
GO

ALTER TABLE [TLGPizza].[Transaction] CHECK CONSTRAINT [FK_Transaction_Payment]
GO

