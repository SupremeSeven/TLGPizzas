USE [TLGPizza]
GO

/****** Object:  Table [TLGPizza].[Orders]    Script Date: 9/12/2017 3:16:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TLGPizza].[Orders](
	[order_id] [int] NOT NULL,
	[ordering_store_id] [int] NOT NULL,
	[producing_store_id] [int] NOT NULL,
	[ready_time] [datetime] NOT NULL,
	[assembly_id] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [TLGPizza].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Assemblies] FOREIGN KEY([assembly_id])
REFERENCES [TLGPizza].[Assemblies] ([assembly_id])
GO

ALTER TABLE [TLGPizza].[Orders] CHECK CONSTRAINT [FK_Orders_Assemblies]
GO

ALTER TABLE [TLGPizza].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Stores_Ordering] FOREIGN KEY([ordering_store_id])
REFERENCES [TLGPizza].[Stores] ([store_id])
GO

ALTER TABLE [TLGPizza].[Orders] CHECK CONSTRAINT [FK_Orders_Stores_Ordering]
GO

ALTER TABLE [TLGPizza].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Stores_Producing] FOREIGN KEY([producing_store_id])
REFERENCES [TLGPizza].[Stores] ([store_id])
GO

ALTER TABLE [TLGPizza].[Orders] CHECK CONSTRAINT [FK_Orders_Stores_Producing]
GO

