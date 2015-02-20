CREATE TABLE [dbo].[Feedback](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserOrderID] [int] NOT NULL,
	[RateGiverUserID] [int] NOT NULL,
	[RatedUserID] [int] NOT NULL,
	[IsCustomers] [bit] NOT NULL,
	[IsPositive] [bit] NULL,
	[WasSuccessful] [bit] NOT NULL,
	[ProductsQuality] [tinyint] NOT NULL,
	[SellerContact] [tinyint] NOT NULL,
	[TransactionQuality] [tinyint] NOT NULL,
	[TransportAndBoxing] [tinyint] NOT NULL,
	[Date] [date] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Feedback] UNIQUE NONCLUSTERED 
(
	[RatedUserID] ASC,
	[RateGiverUserID] ASC,
	[UserOrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_UserOrder] FOREIGN KEY([UserOrderID])
REFERENCES [dbo].[UserOrder] ([ID])
GO

ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_UserOrder]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_UserProfile_RateGiver] FOREIGN KEY([RateGiverUserID])
REFERENCES [dbo].[UserProfile] ([ID])
GO

ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_UserProfile_RateGiver]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_UserProfile_RateReciever] FOREIGN KEY([RatedUserID])
REFERENCES [dbo].[UserProfile] ([ID])
GO

ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_UserProfile_RateReciever]
GO
ALTER TABLE [dbo].[Feedback] ADD  CONSTRAINT [DF_Feedback_Date]  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [CK_Feedback_ProductsQuality_1_10] CHECK  (([ProductsQuality]>=(1) AND [ProductsQuality]<=(10)))
GO

ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [CK_Feedback_ProductsQuality_1_10]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [CK_Feedback_RateGiverUserID_not_equal_RatedUserID] CHECK  (([RateGiverUserID]<>[RatedUserID]))
GO

ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [CK_Feedback_RateGiverUserID_not_equal_RatedUserID]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [CK_Feedback_SellerContact_1_10] CHECK  (([SellerContact]>=(1) AND [SellerContact]<=(10)))
GO

ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [CK_Feedback_SellerContact_1_10]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [CK_Feedback_TransactionQuality_1_10] CHECK  (([TransactionQuality]>=(1) AND [TransactionQuality]<=(10)))
GO

ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [CK_Feedback_TransactionQuality_1_10]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [CK_Feedback_TransportAndBoxing_1_10] CHECK  (([TransportAndBoxing]>=(1) AND [TransportAndBoxing]<=(10)))
GO

ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [CK_Feedback_TransportAndBoxing_1_10]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Visszajelzés 3 típusa:
Pozitív: 1
Semleges: null
Negatív: 0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Feedback', @level2type=N'COLUMN',@level2name=N'IsPositive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 felhasználó 1 felhasználót 1 adásvételben csak egyszer értékelhet!' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Feedback', @level2type=N'CONSTRAINT',@level2name=N'UK_Feedback'