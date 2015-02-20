CREATE TABLE [dbo].[ProductGroup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PublisherID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[SubTitle] [nvarchar](100) NULL,
	[FriendlyUrl] [nvarchar](100) NOT NULL,
	[ImageUrl] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[AuthorNames] [nvarchar](100) NOT NULL,
	[PublisherName] [nvarchar](100) NOT NULL,
	[ChangeHistory] [xml] NULL,
	[MinPrice] [int] NOT NULL,
	[MaxPrice] [int] NOT NULL,
	[SumOfActiveProductsInGroup] [int] NOT NULL,
	[SumOfPassiveProductsInGroup] [int] NOT NULL,
	[SumOfViews] [int] NOT NULL,
	[SumOfBuys] [int] NOT NULL,
	[SumOfRatings] [int] NOT NULL,
	[SumOfRatingsValue] [int] NOT NULL,
	[SumOfComments] [int] NOT NULL,
	[IsCheckedByAdmin] [bit] NOT NULL,
	[UploadedDate] [datetime2](3) NOT NULL,
 CONSTRAINT [PK_ProductGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_ProductGroup_Author_Publisher_Title_Subtitle] UNIQUE NONCLUSTERED 
(
	[PublisherID] ASC,
	[Title] ASC,
	[SubTitle] ASC,
	[AuthorNames] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProductGroup]  WITH CHECK ADD  CONSTRAINT [FK_ProductGroup_Category1] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
GO

ALTER TABLE [dbo].[ProductGroup] CHECK CONSTRAINT [FK_ProductGroup_Category1]
GO
ALTER TABLE [dbo].[ProductGroup]  WITH CHECK ADD  CONSTRAINT [FK_ProductGroup_Publisher1] FOREIGN KEY([PublisherID])
REFERENCES [dbo].[Publisher] ([ID])
GO

ALTER TABLE [dbo].[ProductGroup] CHECK CONSTRAINT [FK_ProductGroup_Publisher1]
GO
ALTER TABLE [dbo].[ProductGroup] ADD  CONSTRAINT [DF_ProductGroup_HowMany]  DEFAULT ((1)) FOR [SumOfActiveProductsInGroup]
GO
ALTER TABLE [dbo].[ProductGroup] ADD  CONSTRAINT [DF_ProductGroup_SumOfPassiveProductsInGroup]  DEFAULT ((0)) FOR [SumOfPassiveProductsInGroup]
GO
ALTER TABLE [dbo].[ProductGroup] ADD  CONSTRAINT [DF_ProductGroup_SumOfViews]  DEFAULT ((0)) FOR [SumOfViews]
GO
ALTER TABLE [dbo].[ProductGroup] ADD  CONSTRAINT [DF_ProductGroup_SumOfBuys]  DEFAULT ((0)) FOR [SumOfBuys]
GO
ALTER TABLE [dbo].[ProductGroup] ADD  CONSTRAINT [DF_ProductGroup_SumOfRating]  DEFAULT ((0)) FOR [SumOfRatings]
GO
ALTER TABLE [dbo].[ProductGroup] ADD  CONSTRAINT [DF_ProductGroup_SumOfRatingsValue]  DEFAULT ((0)) FOR [SumOfRatingsValue]
GO
ALTER TABLE [dbo].[ProductGroup] ADD  CONSTRAINT [DF_ProductGroup_SumOfComment]  DEFAULT ((0)) FOR [SumOfComments]
GO
ALTER TABLE [dbo].[ProductGroup] ADD  CONSTRAINT [DF_ProductGroup_IsCheckedByAdmin]  DEFAULT ((0)) FOR [IsCheckedByAdmin]
GO
ALTER TABLE [dbo].[ProductGroup] ADD  CONSTRAINT [DF_ProductGroup_UploadedDate]  DEFAULT (getdate()) FOR [UploadedDate]
GO
ALTER TABLE [dbo].[ProductGroup]  WITH CHECK ADD  CONSTRAINT [CK_ProductGroup_MaxPrice_bt_0] CHECK  (([MaxPrice]>(0)))
GO

ALTER TABLE [dbo].[ProductGroup] CHECK CONSTRAINT [CK_ProductGroup_MaxPrice_bt_0]
GO
ALTER TABLE [dbo].[ProductGroup]  WITH CHECK ADD  CONSTRAINT [CK_ProductGroup_MinPrice_bt_0] CHECK  (([MinPrice]>(0)))
GO

ALTER TABLE [dbo].[ProductGroup] CHECK CONSTRAINT [CK_ProductGroup_MinPrice_bt_0]
GO
ALTER TABLE [dbo].[ProductGroup]  WITH CHECK ADD  CONSTRAINT [CK_ProductGroup_SumOfActiveProductsInGroup_bte_0] CHECK  (([SumOfActiveProductsInGroup]>=(0)))
GO

ALTER TABLE [dbo].[ProductGroup] CHECK CONSTRAINT [CK_ProductGroup_SumOfActiveProductsInGroup_bte_0]
GO
ALTER TABLE [dbo].[ProductGroup]  WITH CHECK ADD  CONSTRAINT [CK_ProductGroup_SumOfBuys_bte_0] CHECK  (([SumOfBuys]>=(0)))
GO

ALTER TABLE [dbo].[ProductGroup] CHECK CONSTRAINT [CK_ProductGroup_SumOfBuys_bte_0]
GO
ALTER TABLE [dbo].[ProductGroup]  WITH CHECK ADD  CONSTRAINT [CK_ProductGroup_SumOfComments_bte_0] CHECK  (([SumOfComments]>=(0)))
GO

ALTER TABLE [dbo].[ProductGroup] CHECK CONSTRAINT [CK_ProductGroup_SumOfComments_bte_0]
GO
ALTER TABLE [dbo].[ProductGroup]  WITH CHECK ADD  CONSTRAINT [CK_ProductGroup_SumOfPassiveProductsInGroup_bte_0] CHECK  (([SumOfPassiveProductsInGroup]>=(0)))
GO

ALTER TABLE [dbo].[ProductGroup] CHECK CONSTRAINT [CK_ProductGroup_SumOfPassiveProductsInGroup_bte_0]
GO
ALTER TABLE [dbo].[ProductGroup]  WITH CHECK ADD  CONSTRAINT [CK_ProductGroup_SumOfRatings_bte_0] CHECK  (([SumOfRatings]>=(0)))
GO

ALTER TABLE [dbo].[ProductGroup] CHECK CONSTRAINT [CK_ProductGroup_SumOfRatings_bte_0]
GO
ALTER TABLE [dbo].[ProductGroup]  WITH CHECK ADD  CONSTRAINT [CK_ProductGroup_SumOfRatingsValue_bte_0] CHECK  (([SumOfRatingsValue]>=(0)))
GO

ALTER TABLE [dbo].[ProductGroup] CHECK CONSTRAINT [CK_ProductGroup_SumOfRatingsValue_bte_0]
GO
ALTER TABLE [dbo].[ProductGroup]  WITH CHECK ADD  CONSTRAINT [CK_ProductGroup_SumOfViews_bte_0] CHECK  (([SumOfViews]>=(0)))
GO

ALTER TABLE [dbo].[ProductGroup] CHECK CONSTRAINT [CK_ProductGroup_SumOfViews_bte_0]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ez alapán a 4 adat egyezése alapján tekintünk 2 könyvet azonosnak' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ProductGroup', @level2type=N'CONSTRAINT',@level2name=N'UK_ProductGroup_Author_Publisher_Title_Subtitle'