USE [TLGPizza]
GO

/****** Object:  Table [TLGPizza].[Prepayments]    Script Date: 9/12/2017 3:16:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TLGPizza].[Prepayments](
	[prepayment_id] [int] NOT NULL,
	[amount] [decimal](18, 0) NOT NULL,
	[date_paid] [datetime] NOT NULL,
	[transaction_id] [int] NOT NULL,
	[auth_code] [int] NOT NULL,
 CONSTRAINT [PK_Prepayments] PRIMARY KEY CLUSTERED 
(
	[prepayment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [TLGPizza].[Prepayments]  WITH CHECK ADD  CONSTRAINT [FK_Prepayments_Transactions] FOREIGN KEY([transaction_id])
REFERENCES [TLGPizza].[Transactions] ([transaction_id])
GO

ALTER TABLE [TLGPizza].[Prepayments] CHECK CONSTRAINT [FK_Prepayments_Transactions]
GO

