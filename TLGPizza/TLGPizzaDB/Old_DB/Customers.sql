USE [TLGPizza]
GO

/****** Object:  Table [TLGPizza].[Customers]    Script Date: 9/12/2017 3:15:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TLGPizza].[Customers](
	[customer_id] [int] NOT NULL,
	[language] [varchar](50) NOT NULL,
	[last_name] [varchar](50) NOT NULL,
	[first_name] [varchar](50) NOT NULL,
	[address_id] [int] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [TLGPizza].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Addresses] FOREIGN KEY([address_id])
REFERENCES [TLGPizza].[Addresses] ([address_id])
GO

ALTER TABLE [TLGPizza].[Customers] CHECK CONSTRAINT [FK_Customers_Addresses]
GO

