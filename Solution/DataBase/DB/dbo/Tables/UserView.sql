CREATE TABLE [dbo].[UserView](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[ProductID] [int] NULL,
	[ProductGroupID] [int] NULL,
	[LastDate] [datetime2](3) NOT NULL,
	[HowMany] [int] NOT NULL,
 CONSTRAINT [PK_UserViewProduct] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_UserViewProduct_UserID_AND_ProductID_AND_ProductGroupID] UNIQUE NONCLUSTERED 
(
	[ProductID] ASC,
	[UserID] ASC,
	[ProductGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
GO
ALTER TABLE [dbo].[UserView]  WITH CHECK ADD  CONSTRAINT [FK_UserView_ProductGroup] FOREIGN KEY([ProductGroupID])
REFERENCES [dbo].[ProductGroup] ([ID])
GO

ALTER TABLE [dbo].[UserView] CHECK CONSTRAINT [FK_UserView_ProductGroup]
GO
ALTER TABLE [dbo].[UserView]  WITH CHECK ADD  CONSTRAINT [FK_UserViewProduct_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO

ALTER TABLE [dbo].[UserView] CHECK CONSTRAINT [FK_UserViewProduct_Product]
GO
ALTER TABLE [dbo].[UserView]  WITH CHECK ADD  CONSTRAINT [FK_UserViewProduct_UserProfile] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserProfile] ([ID])
GO

ALTER TABLE [dbo].[UserView] CHECK CONSTRAINT [FK_UserViewProduct_UserProfile]
GO
ALTER TABLE [dbo].[UserView] ADD  CONSTRAINT [DF_UserView_LastDate]  DEFAULT (getdate()) FOR [LastDate]
GO
ALTER TABLE [dbo].[UserView]  WITH CHECK ADD  CONSTRAINT [CK_UserViewProduct_ProductID_XOR_ProductGroupID] CHECK  (([ProductID] IS NULL AND [ProductGroupID] IS NOT NULL OR [ProductID] IS NOT NULL AND [ProductGroupID] IS NULL))
GO

ALTER TABLE [dbo].[UserView] CHECK CONSTRAINT [CK_UserViewProduct_ProductID_XOR_ProductGroupID]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Adott user adott product/productGroup-t 1 UserViewProduct rekordban nézeget' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserView', @level2type=N'CONSTRAINT',@level2name=N'UK_UserViewProduct_UserID_AND_ProductID_AND_ProductGroupID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ez a tábla tárolja a UserView-kat a Product és a ProductGroup tábla rekordjaira is. A 2 külső kulcs közül egyszerre csak az egyik lehet érvényben' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserView', @level2type=N'CONSTRAINT',@level2name=N'CK_UserViewProduct_ProductID_XOR_ProductGroupID'