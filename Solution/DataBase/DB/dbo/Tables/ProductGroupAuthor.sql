CREATE TABLE [dbo].[ProductGroupAuthor](
	[AuthorID] [int] NOT NULL,
	[ProductGroupID] [int] NOT NULL,
 CONSTRAINT [PK_ProductGroupAuthor] PRIMARY KEY CLUSTERED 
(
	[AuthorID] ASC,
	[ProductGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
GO
ALTER TABLE [dbo].[ProductGroupAuthor]  WITH CHECK ADD  CONSTRAINT [FK_ProductGroupAuthor_ProductGroup] FOREIGN KEY([ProductGroupID])
REFERENCES [dbo].[ProductGroup] ([ID])
GO

ALTER TABLE [dbo].[ProductGroupAuthor] CHECK CONSTRAINT [FK_ProductGroupAuthor_ProductGroup]
GO
ALTER TABLE [dbo].[ProductGroupAuthor]  WITH CHECK ADD  CONSTRAINT [FK_SwitchAuthorProduct_Author] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Author] ([ID])
GO

ALTER TABLE [dbo].[ProductGroupAuthor] CHECK CONSTRAINT [FK_SwitchAuthorProduct_Author]