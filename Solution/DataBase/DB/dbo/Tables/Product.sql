CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductGroupID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Language] [nvarchar](50) NOT NULL,
	[ImageUrl] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NOT NULL,
	[UploadedDate] [datetime2](3) NOT NULL,
	[ChangeHistory] [xml] NULL,
	[PublishYear] [int] NOT NULL,
	[PageNumber] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[SumOfViews] [int] NOT NULL,
	[HowMany] [int] NOT NULL,
	[Edition] [int] NOT NULL,
	[IsDownloadable] [bit] NOT NULL,
	[IsBook] [bit] NOT NULL,
	[IsAudio] [bit] NOT NULL,
	[IsVideo] [bit] NOT NULL,
	[IsUsed] [bit] NOT NULL,
	[IsCheckedByAdmin] [bit] NOT NULL,
	[ContainsOther] [bit] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductGroup] FOREIGN KEY([ProductGroupID])
REFERENCES [dbo].[ProductGroup] ([ID])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductGroup]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserProfile] ([ID])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_User]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Language]  DEFAULT (N'magyar') FOR [Language]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_UploadedDate]  DEFAULT (getdate()) FOR [UploadedDate]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_SumOfViews]  DEFAULT ((0)) FOR [SumOfViews]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_IsCheckedByAdmin]  DEFAULT ((0)) FOR [IsCheckedByAdmin]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [CK_Product_DownloadableProductCannotBeUsed] CHECK  ((([IsUsed]&[IsDownloadable])=(0)))
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [CK_Product_DownloadableProductCannotBeUsed]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [CK_Product_DownloadableQuantity_0_1] CHECK  (([IsDownloadable]=(0) OR [IsDownloadable]=(1) AND ([HowMany]=(1) OR [HowMany]=(0))))
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [CK_Product_DownloadableQuantity_0_1]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [CK_Product_Edition_bte_1] CHECK  (([Edition]>=(1)))
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [CK_Product_Edition_bte_1]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [CK_Product_HowMany_bte_0] CHECK  (([HowMany]>=(0)))
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [CK_Product_HowMany_bte_0]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [CK_Product_IsBook_IsAudio_IsVideo_Not_0_0_0] CHECK  (((([IsBook]|[IsAudio])|[IsVideo])=(1)))
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [CK_Product_IsBook_IsAudio_IsVideo_Not_0_0_0]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [CK_Product_PageNumber_bt_0] CHECK  (([PageNumber]>(0)))
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [CK_Product_PageNumber_bt_0]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [CK_Product_Price_bt_0] CHECK  (([Price]>(0)))
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [CK_Product_Price_bt_0]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [CK_Product_PublishYear_bt_0] CHECK  (([PublishYear]>(0)))
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [CK_Product_PublishYear_bt_0]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [CK_Product_SumOfViews_bte_0] CHECK  (([SumOfViews]>=(0)))
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [CK_Product_SumOfViews_bte_0]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Elektronikus termék nem lehet használt (pl pdf)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'CONSTRAINT',@level2name=N'CK_Product_DownloadableProductCannotBeUsed'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Letölthető termék mennyisége mindig 1; vagy 0, ha törölte a terméket a felhasználó' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'CONSTRAINT',@level2name=N'CK_Product_DownloadableQuantity_0_1'