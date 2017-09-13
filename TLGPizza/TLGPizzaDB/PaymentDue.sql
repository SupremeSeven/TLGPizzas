USE [TLGPizza]
GO

/****** Object:  Table [TLGPizza].[PaymentDue]    Script Date: 9/13/2017 1:24:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TLGPizza].[PaymentDue](
	[PaymentDueId] [int] NOT NULL,
	[Amount] [decimal](18, 0) NOT NULL,
	[DueDate] [datetime] NOT NULL,
	[DueDateSpecified] [bit] NOT NULL,
 CONSTRAINT [PK_PaymentDue] PRIMARY KEY CLUSTERED 
(
	[PaymentDueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

