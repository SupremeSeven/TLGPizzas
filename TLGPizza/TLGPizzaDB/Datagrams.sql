USE [TLGPizza]
GO

/****** Object:  Table [TLGPizza].[Datagrams]    Script Date: 9/12/2017 3:16:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TLGPizza].[Datagrams](
	[datagram_id] [int] NOT NULL,
	[timestamp] [datetime] NOT NULL,
	[transaction_id] [int] NOT NULL,
 CONSTRAINT [PK_Datagrams] PRIMARY KEY CLUSTERED 
(
	[datagram_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [TLGPizza].[Datagrams]  WITH CHECK ADD  CONSTRAINT [FK_Datagrams_Transactions] FOREIGN KEY([transaction_id])
REFERENCES [TLGPizza].[Transactions] ([transaction_id])
GO

ALTER TABLE [TLGPizza].[Datagrams] CHECK CONSTRAINT [FK_Datagrams_Transactions]
GO

