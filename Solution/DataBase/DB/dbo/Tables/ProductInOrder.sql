CREATE TABLE [dbo].[ProductInOrder](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[UserOrderID] [int] NOT NULL,
	[HowMany] [int] NOT NULL,
	[UnitPrice] [int] NOT NULL,
	[IsForExchange] [bit] NOT NULL,
 CONSTRAINT [PK_ProductInOrder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_ProductInOrder_ProductID_UserOrderID] UNIQUE NONCLUSTERED 
(
	[ProductID] ASC,
	[UserOrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
GO
ALTER TABLE [dbo].[ProductInOrder]  WITH CHECK ADD  CONSTRAINT [FK_ProductInOrder_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO

ALTER TABLE [dbo].[ProductInOrder] CHECK CONSTRAINT [FK_ProductInOrder_Product]
GO
ALTER TABLE [dbo].[ProductInOrder]  WITH CHECK ADD  CONSTRAINT [FK_ProductInOrder_UserOrder] FOREIGN KEY([UserOrderID])
REFERENCES [dbo].[UserOrder] ([ID])
GO

ALTER TABLE [dbo].[ProductInOrder] CHECK CONSTRAINT [FK_ProductInOrder_UserOrder]
GO
ALTER TABLE [dbo].[ProductInOrder] ADD  CONSTRAINT [DF_ProductInOrder_HowMany]  DEFAULT ((1)) FOR [HowMany]
GO
ALTER TABLE [dbo].[ProductInOrder] ADD  CONSTRAINT [DF_ProductInOrder_IsForExchange]  DEFAULT ((0)) FOR [IsForExchange]
GO
ALTER TABLE [dbo].[ProductInOrder]  WITH CHECK ADD  CONSTRAINT [CK_ProductInOrder_HowMany_bte_1] CHECK  (([HowMany]>=(1)))
GO

ALTER TABLE [dbo].[ProductInOrder] CHECK CONSTRAINT [CK_ProductInOrder_HowMany_bte_1]
GO
ALTER TABLE [dbo].[ProductInOrder]  WITH CHECK ADD  CONSTRAINT [CK_ProductInOrder_UnitPrice_bt_0] CHECK  (([UnitPrice]>(0)))
GO

ALTER TABLE [dbo].[ProductInOrder] CHECK CONSTRAINT [CK_ProductInOrder_UnitPrice_bt_0]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Egy konkrét megrendelésben egy product csak egyszer szerepelhet, a HowMany írja le, hány példányban' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ProductInOrder', @level2type=N'CONSTRAINT',@level2name=N'UK_ProductInOrder_ProductID_UserOrderID'