USE [TLGPizza]
GO

/****** Object:  Table [TLGPizza].[Datagram]    Script Date: 9/13/2017 1:23:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TLGPizza].[Datagram](
	[DatagramId] [int] NOT NULL,
	[TransactionId] [int] NOT NULL,
	[Timestamp] [datetime] NOT NULL,
 CONSTRAINT [PK_Datagrams] PRIMARY KEY CLUSTERED 
(
	[DatagramId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [TLGPizza].[Datagram]  WITH CHECK ADD  CONSTRAINT [FK_Datagram_Transaction] FOREIGN KEY([TransactionId])
REFERENCES [TLGPizza].[Transaction] ([TransactionId])
GO

ALTER TABLE [TLGPizza].[Datagram] CHECK CONSTRAINT [FK_Datagram_Transaction]
GO

