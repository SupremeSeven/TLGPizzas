USE [TLGPizza]
GO

/****** Object:  Table [TLGPizza].[Payments]    Script Date: 9/12/2017 3:16:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TLGPizza].[Payments](
	[payment_id] [int] NOT NULL,
	[purchase_total] [decimal](18, 0) NOT NULL,
	[sales_tax_id] [int] NOT NULL,
	[VAT_id] [int] NOT NULL,
	[prepayment_id] [int] NOT NULL,
	[amount] [decimal](18, 0) NOT NULL,
	[due_date] [datetime] NOT NULL,
	[notes] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[payment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [TLGPizza].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Prepayments] FOREIGN KEY([prepayment_id])
REFERENCES [TLGPizza].[Prepayments] ([prepayment_id])
GO

ALTER TABLE [TLGPizza].[Payments] CHECK CONSTRAINT [FK_Payments_Prepayments]
GO

ALTER TABLE [TLGPizza].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Sales_Taxes] FOREIGN KEY([sales_tax_id])
REFERENCES [TLGPizza].[Taxes] ([tax_id])
GO

ALTER TABLE [TLGPizza].[Payments] CHECK CONSTRAINT [FK_Payments_Sales_Taxes]
GO

ALTER TABLE [TLGPizza].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_VAT] FOREIGN KEY([VAT_id])
REFERENCES [TLGPizza].[Taxes] ([tax_id])
GO

ALTER TABLE [TLGPizza].[Payments] CHECK CONSTRAINT [FK_Payments_VAT]
GO

