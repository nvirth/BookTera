CREATE TABLE [dbo].[UserOrder](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerUserProfileID] [int] NOT NULL,
	[CustomerAddressID] [int] NULL,
	[CustomersBuyFeePercent] [int] NOT NULL,
	[VendorUserProfileID] [int] NOT NULL,
	[VendorAddressID] [int] NULL,
	[VendorsSellFeePercent] [int] NOT NULL,
	[SumBookPrice] [int] NOT NULL,
	[SumOtherPrices] [xml] NULL,
	[Status] [tinyint] NOT NULL,
	[RatingState] [tinyint] NOT NULL,
	[Date] [datetime2](3) NOT NULL,
 CONSTRAINT [PK_UserOrder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserOrder]  WITH CHECK ADD  CONSTRAINT [FK_UserOrder_UserAddress_Customer] FOREIGN KEY([CustomerAddressID])
REFERENCES [dbo].[UserAddress] ([ID])
GO

ALTER TABLE [dbo].[UserOrder] CHECK CONSTRAINT [FK_UserOrder_UserAddress_Customer]
GO
ALTER TABLE [dbo].[UserOrder]  WITH CHECK ADD  CONSTRAINT [FK_UserOrder_UserAddress_Vendor] FOREIGN KEY([VendorAddressID])
REFERENCES [dbo].[UserAddress] ([ID])
GO

ALTER TABLE [dbo].[UserOrder] CHECK CONSTRAINT [FK_UserOrder_UserAddress_Vendor]
GO
ALTER TABLE [dbo].[UserOrder]  WITH CHECK ADD  CONSTRAINT [FK_UserOrder_UserProfile_Customer] FOREIGN KEY([CustomerUserProfileID])
REFERENCES [dbo].[UserProfile] ([ID])
GO

ALTER TABLE [dbo].[UserOrder] CHECK CONSTRAINT [FK_UserOrder_UserProfile_Customer]
GO
ALTER TABLE [dbo].[UserOrder]  WITH CHECK ADD  CONSTRAINT [FK_UserOrder_UserProfile_Vendor] FOREIGN KEY([VendorUserProfileID])
REFERENCES [dbo].[UserProfile] ([ID])
GO

ALTER TABLE [dbo].[UserOrder] CHECK CONSTRAINT [FK_UserOrder_UserProfile_Vendor]
GO
ALTER TABLE [dbo].[UserOrder] ADD  CONSTRAINT [DF_UserOrder_SumPrice]  DEFAULT ((0)) FOR [SumBookPrice]
GO
ALTER TABLE [dbo].[UserOrder] ADD  CONSTRAINT [DF_UserOrder_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[UserOrder] ADD  CONSTRAINT [DF_UserOrder_IsRated]  DEFAULT ((1)) FOR [RatingState]
GO
ALTER TABLE [dbo].[UserOrder] ADD  CONSTRAINT [DF_UserOrder_Date]  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[UserOrder]  WITH CHECK ADD  CONSTRAINT [CK_UserOrder_CantByFromSelf] CHECK  (([CustomerUserProfileID]<>[VendorUserProfileID]))
GO

ALTER TABLE [dbo].[UserOrder] CHECK CONSTRAINT [CK_UserOrder_CantByFromSelf]
GO
ALTER TABLE [dbo].[UserOrder]  WITH CHECK ADD  CONSTRAINT [CK_UserOrder_SumBookPrice_bte_0] CHECK  (([SumBookPrice]>=(0)))
GO

ALTER TABLE [dbo].[UserOrder] CHECK CONSTRAINT [CK_UserOrder_SumBookPrice_bte_0]