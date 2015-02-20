CREATE TABLE [dbo].[Rating](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductGroupID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[Value] [tinyint] NOT NULL,
	[Date] [datetime2](3) NOT NULL,
 CONSTRAINT [PK_Rating] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Rating_ProductID_UserID] UNIQUE NONCLUSTERED 
(
	[ProductGroupID] ASC,
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [FK_Rating_ProductGroup] FOREIGN KEY([ProductGroupID])
REFERENCES [dbo].[ProductGroup] ([ID])
GO

ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [FK_Rating_ProductGroup]
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [FK_Rating_UserProfile] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserProfile] ([ID])
GO

ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [FK_Rating_UserProfile]
GO
ALTER TABLE [dbo].[Rating] ADD  CONSTRAINT [DF_Rating_Date]  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [CK_Rating_Value_1_10] CHECK  (([Value]>=(1) AND [Value]<=(10)))
GO

ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [CK_Rating_Value_1_10]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Egy user egy product-ot csak egyszer véleményezhet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Rating', @level2type=N'CONSTRAINT',@level2name=N'UK_Rating_ProductID_UserID'