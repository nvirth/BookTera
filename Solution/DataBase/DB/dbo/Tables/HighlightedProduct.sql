CREATE TABLE [dbo].[HighlightedProduct](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[HighlightTypeID] [int] NOT NULL,
	[FromDate] [date] NOT NULL,
	[ToDate] [date] NOT NULL,
 CONSTRAINT [PK_HighlightedProduct] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
GO
ALTER TABLE [dbo].[HighlightedProduct]  WITH CHECK ADD  CONSTRAINT [FK_HighlightedProduct_HighlightType] FOREIGN KEY([HighlightTypeID])
REFERENCES [dbo].[HighlightType] ([ID])
GO

ALTER TABLE [dbo].[HighlightedProduct] CHECK CONSTRAINT [FK_HighlightedProduct_HighlightType]
GO
ALTER TABLE [dbo].[HighlightedProduct]  WITH CHECK ADD  CONSTRAINT [FK_HighlightedProduct_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO

ALTER TABLE [dbo].[HighlightedProduct] CHECK CONSTRAINT [FK_HighlightedProduct_Product]
GO
ALTER TABLE [dbo].[HighlightedProduct] ADD  CONSTRAINT [DF_HighlightedProduct_FromDate]  DEFAULT (getdate()) FOR [FromDate]
GO
ALTER TABLE [dbo].[HighlightedProduct]  WITH CHECK ADD  CONSTRAINT [CK_HighlightedProduct_ToDate_bt_FromDate] CHECK  (([FromDate]<[ToDate]))
GO

ALTER TABLE [dbo].[HighlightedProduct] CHECK CONSTRAINT [CK_HighlightedProduct_ToDate_bt_FromDate]