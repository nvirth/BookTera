CREATE TABLE [dbo].[UserGroup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Price] [int] NOT NULL,
	[BuyFeePercent] [tinyint] NOT NULL,
	[SellFeePercent] [tinyint] NOT NULL,
	[MonthsToKeepBooks] [tinyint] NOT NULL,
	[GroupName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UserGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_UserGroup_GroupName] UNIQUE NONCLUSTERED 
(
	[GroupName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
GO
ALTER TABLE [dbo].[UserGroup]  WITH CHECK ADD  CONSTRAINT [CK_UserGroup_BuyFeePercent_bte_0] CHECK  (([BuyFeePercent]>=(0)))
GO

ALTER TABLE [dbo].[UserGroup] CHECK CONSTRAINT [CK_UserGroup_BuyFeePercent_bte_0]
GO
ALTER TABLE [dbo].[UserGroup]  WITH CHECK ADD  CONSTRAINT [CK_UserGroup_MonthsToKeepBooks_bte_0] CHECK  (([MonthsToKeepBooks]>=(0)))
GO

ALTER TABLE [dbo].[UserGroup] CHECK CONSTRAINT [CK_UserGroup_MonthsToKeepBooks_bte_0]
GO
ALTER TABLE [dbo].[UserGroup]  WITH CHECK ADD  CONSTRAINT [CK_UserGroup_Price_bte_0] CHECK  (([Price]>=(0)))
GO

ALTER TABLE [dbo].[UserGroup] CHECK CONSTRAINT [CK_UserGroup_Price_bte_0]
GO
ALTER TABLE [dbo].[UserGroup]  WITH CHECK ADD  CONSTRAINT [CK_UserGroup_SellFeePercent_bte_0] CHECK  (([SellFeePercent]>=(0)))
GO

ALTER TABLE [dbo].[UserGroup] CHECK CONSTRAINT [CK_UserGroup_SellFeePercent_bte_0]