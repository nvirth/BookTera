CREATE TABLE [dbo].[UserProfile](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserGroupID] [int] NOT NULL,
	[DefaultAddressID] [int] NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[EMail] [nvarchar](100) NOT NULL,
	[ImageUrl] [nvarchar](100) NULL,
	[FullName] [nvarchar](100) NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[FriendlyUrl] [nvarchar](100) NOT NULL,
	[LastLoginDate] [datetime2](3) NOT NULL,
	[PreviousLoginDate] [datetime2](3) NOT NULL,
	[RegistrationDate] [date] NOT NULL,
	[SumOfSells] [int] NOT NULL,
	[SumOfSellsInProgress] [int] NOT NULL,
	[SumOfBuys] [int] NOT NULL,
	[SumOfBuysInProgress] [int] NOT NULL,
	[SumOfNeededFeedbacks] [int] NOT NULL,
	[SumOfFeedbacks] [int] NOT NULL,
	[SumOfFeedbacksValue] [int] NOT NULL,
	[SumOfActiveProducts] [int] NOT NULL,
	[SumOfPassiveProducts] [int] NOT NULL,
	[IsAuthor] [bit] NOT NULL,
	[IsPublisher] [bit] NOT NULL,
	[Balance] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_UserProfile_EMail] UNIQUE NONCLUSTERED 
(
	[EMail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_UserProfile_FriendlyUrl] UNIQUE NONCLUSTERED 
(
	[FriendlyUrl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_UserProfile_UserName] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
GO
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [FK_User_DefaultUserAddress] FOREIGN KEY([DefaultAddressID])
REFERENCES [dbo].[UserAddress] ([ID])
GO

ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [FK_User_DefaultUserAddress]
GO
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [FK_User_UserGroup] FOREIGN KEY([UserGroupID])
REFERENCES [dbo].[UserGroup] ([ID])
GO

ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [FK_User_UserGroup]
GO
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [DF_UserProfile_LastLoginDate]  DEFAULT (getdate()) FOR [LastLoginDate]
GO
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [DF_UserProfile_PreviousLoginDate]  DEFAULT (getdate()) FOR [PreviousLoginDate]
GO
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [DF_UserProfile_RegistrationDate]  DEFAULT (getdate()) FOR [RegistrationDate]
GO
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [DF_UserProfile_NumOfSells]  DEFAULT ((0)) FOR [SumOfSells]
GO
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [DF_UserProfile_NumOfSellsInProgress]  DEFAULT ((0)) FOR [SumOfSellsInProgress]
GO
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [DF_UserProfile_NumOfBuys]  DEFAULT ((0)) FOR [SumOfBuys]
GO
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [DF_UserProfile_NumOfBuysInProgress]  DEFAULT ((0)) FOR [SumOfBuysInProgress]
GO
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [DF_UserProfile_NumOfNeededRatings]  DEFAULT ((0)) FOR [SumOfNeededFeedbacks]
GO
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [DF_UserProfile_SumOfRatings]  DEFAULT ((0)) FOR [SumOfFeedbacks]
GO
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [DF_UserProfile_SumOfRatingsValue]  DEFAULT ((0)) FOR [SumOfFeedbacksValue]
GO
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [DF_UserProfile_SumOfActiveProducts]  DEFAULT ((0)) FOR [SumOfActiveProducts]
GO
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [DF_UserProfile_SumOfPassiveProducts]  DEFAULT ((0)) FOR [SumOfPassiveProducts]
GO
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [DF_UserProfile_IsAuthor]  DEFAULT ((0)) FOR [IsAuthor]
GO
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [DF_UserProfile_IsPublisher]  DEFAULT ((0)) FOR [IsPublisher]
GO
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [DF_UserProfile_Amount]  DEFAULT ((0)) FOR [Balance]
GO
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [CK_UserProfile_IsAuthor_IsPublisher_Not_1_1] CHECK  ((([IsAuthor]&[IsPublisher])=(0)))
GO

ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [CK_UserProfile_IsAuthor_IsPublisher_Not_1_1]
GO
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [CK_UserProfile_SumOfActiveProducts_bte_0] CHECK  (([SumOfActiveProducts]>=(0)))
GO

ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [CK_UserProfile_SumOfActiveProducts_bte_0]
GO
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [CK_UserProfile_SumOfBuys_bte_0] CHECK  (([SumOfBuys]>=(0)))
GO

ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [CK_UserProfile_SumOfBuys_bte_0]
GO
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [CK_UserProfile_SumOfBuysInProgress_bte_0] CHECK  (([SumOfBuysInProgress]>=(0)))
GO

ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [CK_UserProfile_SumOfBuysInProgress_bte_0]
GO
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [CK_UserProfile_SumOfFeedbacks_bte_0] CHECK  (([SumOfFeedbacks]>=(0)))
GO

ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [CK_UserProfile_SumOfFeedbacks_bte_0]
GO
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [CK_UserProfile_SumOfFeedbacksValue_bte_0] CHECK  (([SumOfFeedbacksValue]>=(0)))
GO

ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [CK_UserProfile_SumOfFeedbacksValue_bte_0]
GO
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [CK_UserProfile_SumOfNeededFeedbacks_bte_0] CHECK  (([SumOfNeededFeedbacks]>=(0)))
GO

ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [CK_UserProfile_SumOfNeededFeedbacks_bte_0]
GO
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [CK_UserProfile_SumOfPassiveProducts_bte_0] CHECK  (([SumOfPassiveProducts]>=(0)))
GO

ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [CK_UserProfile_SumOfPassiveProducts_bte_0]
GO
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [CK_UserProfile_SumOfSells_bte_0] CHECK  (([SumOfSells]>=(0)))
GO

ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [CK_UserProfile_SumOfSells_bte_0]
GO
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [CK_UserProfile_SumOfSellsInProgress_bte_0] CHECK  (([SumOfSellsInProgress]>=(0)))
GO

ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [CK_UserProfile_SumOfSellsInProgress_bte_0]