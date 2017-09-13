USE [TLGPizza]
GO

/****** Object:  Table [TLGPizza].[Prepayment]    Script Date: 9/13/2017 1:41:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TLGPizza].[Prepayment](
	[PrepaymentId] [int] NOT NULL,
	[TransactionId] [int] NOT NULL,
	[AuthorizationCode] [varchar](50) NOT NULL,
	[Amount] [decimal](18, 0) NOT NULL,
	[DatePaid] [datetime] NOT NULL,
 CONSTRAINT [PK_Prepayments] PRIMARY KEY CLUSTERED 
(
	[PrepaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [TLGPizza].[Prepayment]  WITH CHECK ADD  CONSTRAINT [FK_Prepayments_Transaction] FOREIGN KEY([TransactionId])
REFERENCES [TLGPizza].[Transaction] ([TransactionId])
GO

ALTER TABLE [TLGPizza].[Prepayment] CHECK CONSTRAINT [FK_Prepayments_Transaction]
GO

