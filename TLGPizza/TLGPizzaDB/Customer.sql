USE [TLGPizza]
GO

/****** Object:  Table [TLGPizza].[Customer]    Script Date: 9/13/2017 1:23:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TLGPizza].[Customer](
	[CustomerId] [int] NOT NULL,
	[AddressId] [int] NOT NULL,
	[Language] [varchar](50) NULL,
	[LastName] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[Notes] [varchar](max) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [TLGPizza].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Address] FOREIGN KEY([AddressId])
REFERENCES [TLGPizza].[Address] ([AddressId])
GO

ALTER TABLE [TLGPizza].[Customer] CHECK CONSTRAINT [FK_Customer_Address]
GO

