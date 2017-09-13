USE [TLGPizza]
GO

/****** Object:  Table [TLGPizza].[Payment]    Script Date: 9/13/2017 1:23:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TLGPizza].[Payment](
	[PaymentId] [int] NOT NULL,
	[SalesTaxId] [int] NOT NULL,
	[VATId] [int] NULL,
	[PrepaymentId] [int] NULL,
	[PaymentDueId] [int] NOT NULL,
	[PurchaseTotal] [decimal](18, 0) NOT NULL,
	[Notes] [varchar](max) NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [TLGPizza].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_PaymentDue] FOREIGN KEY([PaymentDueId])
REFERENCES [TLGPizza].[PaymentDue] ([PaymentDueId])
GO

ALTER TABLE [TLGPizza].[Payment] CHECK CONSTRAINT [FK_Payment_PaymentDue]
GO

ALTER TABLE [TLGPizza].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Prepayments] FOREIGN KEY([PrepaymentId])
REFERENCES [TLGPizza].[Prepayments] ([PrepaymentId])
GO

ALTER TABLE [TLGPizza].[Payment] CHECK CONSTRAINT [FK_Payment_Prepayments]
GO

ALTER TABLE [TLGPizza].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Sales_Tax] FOREIGN KEY([SalesTaxId])
REFERENCES [TLGPizza].[Tax] ([TaxId])
GO

ALTER TABLE [TLGPizza].[Payment] CHECK CONSTRAINT [FK_Payment_Sales_Tax]
GO

ALTER TABLE [TLGPizza].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_VAT] FOREIGN KEY([VATId])
REFERENCES [TLGPizza].[Tax] ([TaxId])
GO

ALTER TABLE [TLGPizza].[Payment] CHECK CONSTRAINT [FK_Payment_VAT]
GO

