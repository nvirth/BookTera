CREATE TABLE [dbo].[UserAddress](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[ZipCode] [nvarchar](100) NOT NULL,
	[City] [nvarchar](100) NOT NULL,
	[StreetAndHouseNumber] [nvarchar](100) NOT NULL,
	[Country] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_UserAddress] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_UserAddress] UNIQUE NONCLUSTERED 
(
	[City] ASC,
	[Country] ASC,
	[StreetAndHouseNumber] ASC,
	[UserID] ASC,
	[ZipCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
GO
ALTER TABLE [dbo].[UserAddress]  WITH CHECK ADD  CONSTRAINT [FK_UserAddress_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserProfile] ([ID])
GO

ALTER TABLE [dbo].[UserAddress] CHECK CONSTRAINT [FK_UserAddress_User]
GO
ALTER TABLE [dbo].[UserAddress] ADD  CONSTRAINT [DF_UserAddress_Country]  DEFAULT (N'Magyarország') FOR [Country]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dettó ua címet ua user nem vehet fel többször' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserAddress', @level2type=N'CONSTRAINT',@level2name=N'UK_UserAddress'