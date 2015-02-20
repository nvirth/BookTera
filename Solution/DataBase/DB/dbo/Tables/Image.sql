CREATE TABLE [dbo].[Image](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[ProductID] [int] NULL,
	[ProductGroupID] [int] NULL,
	[IsDefault] [bit] NOT NULL,
	[Url] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Image_Url] UNIQUE NONCLUSTERED 
(
	[Url] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
GO
ALTER TABLE [dbo].[Image]  WITH CHECK ADD  CONSTRAINT [FK_Image_ProductGroup] FOREIGN KEY([ProductGroupID])
REFERENCES [dbo].[ProductGroup] ([ID])
GO

ALTER TABLE [dbo].[Image] CHECK CONSTRAINT [FK_Image_ProductGroup]
GO
ALTER TABLE [dbo].[Image]  WITH CHECK ADD  CONSTRAINT [FK_Image_UserProfile] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserProfile] ([ID])
GO

ALTER TABLE [dbo].[Image] CHECK CONSTRAINT [FK_Image_UserProfile]
GO
ALTER TABLE [dbo].[Image]  WITH CHECK ADD  CONSTRAINT [FK_ImageProduct_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO

ALTER TABLE [dbo].[Image] CHECK CONSTRAINT [FK_ImageProduct_Product]
GO
ALTER TABLE [dbo].[Image] ADD  CONSTRAINT [DF_Image_IsCover]  DEFAULT ((0)) FOR [IsDefault]
GO
ALTER TABLE [dbo].[Image]  WITH CHECK ADD  CONSTRAINT [CK_Image_3ForeignKeys] CHECK  (([ProductID] IS NOT NULL AND [ProductGroupID] IS NULL AND [UserID] IS NULL OR [ProductID] IS NULL AND [ProductGroupID] IS NOT NULL AND [UserID] IS NULL OR [ProductID] IS NULL AND [ProductGroupID] IS NULL AND [UserID] IS NOT NULL))
GO

ALTER TABLE [dbo].[Image] CHECK CONSTRAINT [CK_Image_3ForeignKeys]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ha adatbázis szinten egyedivé tesszük a fájlneveket, mindenképp törölhetők a fájl rendszerből is, ha a rekordjukat töröljük az adatbázisból' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Image', @level2type=N'CONSTRAINT',@level2name=N'UK_Image_Url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Minden feltöltött kép bekerül ebbe a táblába (Image). Ezek 3 másik táblához tartozhatnak, de csak az egyikhez; valamelyikhez viszont mindenképp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Image', @level2type=N'CONSTRAINT',@level2name=N'CK_Image_3ForeignKeys'