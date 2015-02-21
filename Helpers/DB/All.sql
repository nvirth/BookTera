USE [master]
GO
/****** Object:  Database [BookTera]    Script Date: 2013.11.02. 18:49:20 ******/
CREATE DATABASE [BookTera]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookTera', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\BookTera_Primary.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BookTera_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\BookTera_Primary.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BookTera] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookTera].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookTera] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [BookTera] SET ANSI_NULLS ON 
GO
ALTER DATABASE [BookTera] SET ANSI_PADDING ON 
GO
ALTER DATABASE [BookTera] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [BookTera] SET ARITHABORT ON 
GO
ALTER DATABASE [BookTera] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookTera] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [BookTera] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookTera] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookTera] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookTera] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [BookTera] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [BookTera] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookTera] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [BookTera] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookTera] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BookTera] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookTera] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookTera] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookTera] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookTera] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookTera] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookTera] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookTera] SET RECOVERY FULL 
GO
ALTER DATABASE [BookTera] SET  MULTI_USER 
GO
ALTER DATABASE [BookTera] SET PAGE_VERIFY NONE  
GO
ALTER DATABASE [BookTera] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookTera] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookTera] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BookTera', N'ON'
GO
USE [BookTera]
GO
/****** Object:  StoredProcedure [dbo].[ELMAH_GetErrorsXml]    Script Date: 2013.11.02. 18:49:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ELMAH_GetErrorsXml]
(
    @Application NVARCHAR(60),
    @PageIndex INT = 0,
    @PageSize INT = 15,
    @TotalCount INT OUTPUT
)
AS 

    SET NOCOUNT ON

    DECLARE @FirstTimeUTC DATETIME
    DECLARE @FirstSequence INT
    DECLARE @StartRow INT
    DECLARE @StartRowIndex INT

    SELECT 
        @TotalCount = COUNT(1) 
    FROM 
        [ELMAH_Error]
    WHERE 
        [Application] = @Application

    -- Get the ID of the first error for the requested page

    SET @StartRowIndex = @PageIndex * @PageSize + 1

    IF @StartRowIndex <= @TotalCount
    BEGIN

        SET ROWCOUNT @StartRowIndex

        SELECT  
            @FirstTimeUTC = [TimeUtc],
            @FirstSequence = [Sequence]
        FROM 
            [ELMAH_Error]
        WHERE   
            [Application] = @Application
        ORDER BY 
            [TimeUtc] DESC, 
            [Sequence] DESC

    END
    ELSE
    BEGIN

        SET @PageSize = 0

    END

    -- Now set the row count to the requested page size and get
    -- all records below it for the pertaining application.

    SET ROWCOUNT @PageSize

    SELECT 
        errorId     = [ErrorId], 
        application = [Application],
        host        = [Host], 
        type        = [Type],
        source      = [Source],
        message     = [Message],
        [user]      = [User],
        statusCode  = [StatusCode], 
        time        = CONVERT(VARCHAR(50), [TimeUtc], 126) + 'Z'
    FROM 
        [ELMAH_Error] error
    WHERE
        [Application] = @Application
    AND
        [TimeUtc] <= @FirstTimeUTC
    AND 
        [Sequence] <= @FirstSequence
    ORDER BY
        [TimeUtc] DESC, 
        [Sequence] DESC
    FOR
        XML AUTO


GO
/****** Object:  StoredProcedure [dbo].[ELMAH_GetErrorXml]    Script Date: 2013.11.02. 18:49:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ELMAH_GetErrorXml]
(
    @Application NVARCHAR(60),
    @ErrorId UNIQUEIDENTIFIER
)
AS

    SET NOCOUNT ON

    SELECT 
        [AllXml]
    FROM 
        [ELMAH_Error]
    WHERE
        [ErrorId] = @ErrorId
    AND
        [Application] = @Application


GO
/****** Object:  StoredProcedure [dbo].[ELMAH_LogError]    Script Date: 2013.11.02. 18:49:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ELMAH_LogError]
(
    @ErrorId UNIQUEIDENTIFIER,
    @Application NVARCHAR(60),
    @Host NVARCHAR(30),
    @Type NVARCHAR(100),
    @Source NVARCHAR(60),
    @Message NVARCHAR(500),
    @User NVARCHAR(50),
    @AllXml NTEXT,
    @StatusCode INT,
    @TimeUtc DATETIME
)
AS

    SET NOCOUNT ON

    INSERT
    INTO
        [ELMAH_Error]
        (
            [ErrorId],
            [Application],
            [Host],
            [Type],
            [Source],
            [Message],
            [User],
            [AllXml],
            [StatusCode],
            [TimeUtc]
        )
    VALUES
        (
            @ErrorId,
            @Application,
            @Host,
            @Type,
            @Source,
            @Message,
            @User,
            @AllXml,
            @StatusCode,
            @TimeUtc
        )


GO
/****** Object:  Table [dbo].[Author]    Script Date: 2013.11.02. 18:49:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[DisplayName] [nvarchar](100) NOT NULL,
	[FriendlyUrl] [nvarchar](100) NOT NULL,
	[About] [nvarchar](max) NULL,
	[IsCheckedByAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Author_DisplayName_UserID] UNIQUE NONCLUSTERED 
(
	[DisplayName] ASC,
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Author_FriendlyUrl_UserID] UNIQUE NONCLUSTERED 
(
	[FriendlyUrl] ASC,
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 2013.11.02. 18:49:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParentCategoryID] [int] NULL,
	[DisplayName] [nvarchar](100) NOT NULL,
	[FullPath] [nvarchar](200) NOT NULL,
	[FriendlyUrl] [nvarchar](200) NOT NULL,
	[Sort] [nvarchar](50) NOT NULL,
	[IsParent] [bit] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Category_FriendlyUrl] UNIQUE NONCLUSTERED 
(
	[FriendlyUrl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Category_FullPath] UNIQUE NONCLUSTERED 
(
	[FullPath] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Comment]    Script Date: 2013.11.02. 18:49:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductGroupID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[ParentCommentID] [int] NULL,
	[CreatedDate] [datetime2](3) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ELMAH_Error]    Script Date: 2013.11.02. 18:49:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ELMAH_Error](
	[ErrorId] [uniqueidentifier] NOT NULL,
	[Application] [nvarchar](60) NOT NULL,
	[Host] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](100) NOT NULL,
	[Source] [nvarchar](60) NOT NULL,
	[Message] [nvarchar](500) NOT NULL,
	[User] [nvarchar](50) NOT NULL,
	[StatusCode] [int] NOT NULL,
	[TimeUtc] [datetime] NOT NULL,
	[Sequence] [int] IDENTITY(1,1) NOT NULL,
	[AllXml] [ntext] NOT NULL,
 CONSTRAINT [PK_ELMAH_Error] PRIMARY KEY NONCLUSTERED 
(
	[ErrorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 2013.11.02. 18:49:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HighlightedProduct]    Script Date: 2013.11.02. 18:49:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HighlightedProduct](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[HighlightTypeID] [int] NOT NULL,
	[FromDate] [date] NOT NULL,
	[ToDate] [date] NOT NULL,
 CONSTRAINT [PK_HighlightedProduct] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HighlightType]    Script Date: 2013.11.02. 18:49:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HighlightType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Price] [int] NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_HighlightType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Image]    Script Date: 2013.11.02. 18:49:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 2013.11.02. 18:49:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductGroupID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Language] [nvarchar](50) NOT NULL,
	[ImageUrl] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NOT NULL,
	[UploadedDate] [datetime2](3) NOT NULL,
	[ChangeHistory] [xml] NULL,
	[PublishYear] [int] NOT NULL,
	[PageNumber] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[SumOfViews] [int] NOT NULL,
	[HowMany] [int] NOT NULL,
	[Edition] [int] NOT NULL,
	[IsDownloadable] [bit] NOT NULL,
	[IsBook] [bit] NOT NULL,
	[IsAudio] [bit] NOT NULL,
	[IsVideo] [bit] NOT NULL,
	[IsUsed] [bit] NOT NULL,
	[IsCheckedByAdmin] [bit] NOT NULL,
	[ContainsOther] [bit] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductGroup]    Script Date: 2013.11.02. 18:49:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductGroup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PublisherID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[SubTitle] [nvarchar](100) NULL,
	[FriendlyUrl] [nvarchar](100) NOT NULL,
	[ImageUrl] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[AuthorNames] [nvarchar](100) NOT NULL,
	[PublisherName] [nvarchar](100) NOT NULL,
	[ChangeHistory] [xml] NULL,
	[MinPrice] [int] NOT NULL,
	[MaxPrice] [int] NOT NULL,
	[SumOfActiveProductsInGroup] [int] NOT NULL,
	[SumOfPassiveProductsInGroup] [int] NOT NULL,
	[SumOfViews] [int] NOT NULL,
	[SumOfBuys] [int] NOT NULL,
	[SumOfRatings] [int] NOT NULL,
	[SumOfRatingsValue] [int] NOT NULL,
	[SumOfComments] [int] NOT NULL,
	[IsCheckedByAdmin] [bit] NOT NULL,
	[UploadedDate] [datetime2](3) NOT NULL,
 CONSTRAINT [PK_ProductGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_ProductGroup_Author_Publisher_Title_Subtitle] UNIQUE NONCLUSTERED 
(
	[PublisherID] ASC,
	[Title] ASC,
	[SubTitle] ASC,
	[AuthorNames] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductGroupAuthor]    Script Date: 2013.11.02. 18:49:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductGroupAuthor](
	[AuthorID] [int] NOT NULL,
	[ProductGroupID] [int] NOT NULL,
 CONSTRAINT [PK_ProductGroupAuthor] PRIMARY KEY CLUSTERED 
(
	[AuthorID] ASC,
	[ProductGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductInOrder]    Script Date: 2013.11.02. 18:49:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Publisher]    Script Date: 2013.11.02. 18:49:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publisher](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[DisplayName] [nvarchar](100) NOT NULL,
	[FriendlyUrl] [nvarchar](100) NOT NULL,
	[About] [nvarchar](max) NULL,
	[IsCheckedByAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_Publisher] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Publisher_DisplayName_UserID] UNIQUE NONCLUSTERED 
(
	[DisplayName] ASC,
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Publisher_FriendlyUrl_UserID] UNIQUE NONCLUSTERED 
(
	[FriendlyUrl] ASC,
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rating]    Script Date: 2013.11.02. 18:49:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserAddress]    Script Date: 2013.11.02. 18:49:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserGroup]    Script Date: 2013.11.02. 18:49:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserOrder]    Script Date: 2013.11.02. 18:49:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 2013.11.02. 18:49:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserView]    Script Date: 2013.11.02. 18:49:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 2013.11.02. 18:49:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Membership](
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[ConfirmationToken] [nvarchar](128) NULL,
	[IsConfirmed] [bit] NULL,
	[LastPasswordFailureDate] [datetime] NULL,
	[PasswordFailuresSinceLastSuccess] [int] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordChangedDate] [datetime] NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[PasswordVerificationToken] [nvarchar](128) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 2013.11.02. 18:49:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_OAuthMembership](
	[Provider] [nvarchar](30) NOT NULL,
	[ProviderUserId] [nvarchar](100) NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Provider] ASC,
	[ProviderUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 2013.11.02. 18:49:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 2013.11.02. 18:49:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_UsersInRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ELMAH_Error_App_Time_Seq]    Script Date: 2013.11.02. 18:49:20 ******/
CREATE NONCLUSTERED INDEX [IX_ELMAH_Error_App_Time_Seq] ON [dbo].[ELMAH_Error]
(
	[Application] ASC,
	[TimeUtc] DESC,
	[Sequence] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Author] ADD  CONSTRAINT [DF_Author_IsCheckedByAdmin]  DEFAULT ((0)) FOR [IsCheckedByAdmin]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_IsParent]  DEFAULT ((0)) FOR [IsParent]
GO
ALTER TABLE [dbo].[Comment] ADD  CONSTRAINT [DF_Comment_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[ELMAH_Error] ADD  CONSTRAINT [DF_ELMAH_Error_ErrorId]  DEFAULT (newid()) FOR [ErrorId]
GO
ALTER TABLE [dbo].[Feedback] ADD  CONSTRAINT [DF_Feedback_Date]  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[HighlightedProduct] ADD  CONSTRAINT [DF_HighlightedProduct_FromDate]  DEFAULT (getdate()) FOR [FromDate]
GO
ALTER TABLE [dbo].[Image] ADD  CONSTRAINT [DF_Image_IsCover]  DEFAULT ((0)) FOR [IsDefault]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Language]  DEFAULT (N'magyar') FOR [Language]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_UploadedDate]  DEFAULT (getdate()) FOR [UploadedDate]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_SumOfViews]  DEFAULT ((0)) FOR [SumOfViews]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_IsCheckedByAdmin]  DEFAULT ((0)) FOR [IsCheckedByAdmin]
GO
ALTER TABLE [dbo].[ProductGroup] ADD  CONSTRAINT [DF_ProductGroup_HowMany]  DEFAULT ((1)) FOR [SumOfActiveProductsInGroup]
GO
ALTER TABLE [dbo].[ProductGroup] ADD  CONSTRAINT [DF_ProductGroup_SumOfPassiveProductsInGroup]  DEFAULT ((0)) FOR [SumOfPassiveProductsInGroup]
GO
ALTER TABLE [dbo].[ProductGroup] ADD  CONSTRAINT [DF_ProductGroup_SumOfViews]  DEFAULT ((0)) FOR [SumOfViews]
GO
ALTER TABLE [dbo].[ProductGroup] ADD  CONSTRAINT [DF_ProductGroup_SumOfBuys]  DEFAULT ((0)) FOR [SumOfBuys]
GO
ALTER TABLE [dbo].[ProductGroup] ADD  CONSTRAINT [DF_ProductGroup_SumOfRating]  DEFAULT ((0)) FOR [SumOfRatings]
GO
ALTER TABLE [dbo].[ProductGroup] ADD  CONSTRAINT [DF_ProductGroup_SumOfRatingsValue]  DEFAULT ((0)) FOR [SumOfRatingsValue]
GO
ALTER TABLE [dbo].[ProductGroup] ADD  CONSTRAINT [DF_ProductGroup_SumOfComment]  DEFAULT ((0)) FOR [SumOfComments]
GO
ALTER TABLE [dbo].[ProductGroup] ADD  CONSTRAINT [DF_ProductGroup_IsCheckedByAdmin]  DEFAULT ((0)) FOR [IsCheckedByAdmin]
GO
ALTER TABLE [dbo].[ProductGroup] ADD  CONSTRAINT [DF_ProductGroup_UploadedDate]  DEFAULT (getdate()) FOR [UploadedDate]
GO
ALTER TABLE [dbo].[ProductInOrder] ADD  CONSTRAINT [DF_ProductInOrder_HowMany]  DEFAULT ((1)) FOR [HowMany]
GO
ALTER TABLE [dbo].[ProductInOrder] ADD  CONSTRAINT [DF_ProductInOrder_IsForExchange]  DEFAULT ((0)) FOR [IsForExchange]
GO
ALTER TABLE [dbo].[Publisher] ADD  CONSTRAINT [DF_Publisher_IsCheckedByAdmin]  DEFAULT ((0)) FOR [IsCheckedByAdmin]
GO
ALTER TABLE [dbo].[Rating] ADD  CONSTRAINT [DF_Rating_Date]  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[UserAddress] ADD  CONSTRAINT [DF_UserAddress_Country]  DEFAULT (N'Magyarország') FOR [Country]
GO
ALTER TABLE [dbo].[UserOrder] ADD  CONSTRAINT [DF_UserOrder_SumPrice]  DEFAULT ((0)) FOR [SumBookPrice]
GO
ALTER TABLE [dbo].[UserOrder] ADD  CONSTRAINT [DF_UserOrder_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[UserOrder] ADD  CONSTRAINT [DF_UserOrder_IsRated]  DEFAULT ((1)) FOR [RatingState]
GO
ALTER TABLE [dbo].[UserOrder] ADD  CONSTRAINT [DF_UserOrder_Date]  DEFAULT (getdate()) FOR [Date]
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
ALTER TABLE [dbo].[UserView] ADD  CONSTRAINT [DF_UserView_LastDate]  DEFAULT (getdate()) FOR [LastDate]
GO
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [IsConfirmed]
GO
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [PasswordFailuresSinceLastSuccess]
GO
ALTER TABLE [dbo].[Author]  WITH CHECK ADD  CONSTRAINT [FK_Author_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserProfile] ([ID])
GO
ALTER TABLE [dbo].[Author] CHECK CONSTRAINT [FK_Author_User]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_Category] FOREIGN KEY([ParentCategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_Category]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_ParentComment] FOREIGN KEY([ParentCommentID])
REFERENCES [dbo].[Comment] ([ID])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_ParentComment]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_ProductGroup] FOREIGN KEY([ProductGroupID])
REFERENCES [dbo].[ProductGroup] ([ID])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_ProductGroup]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_UserProfile] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserProfile] ([ID])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_UserProfile]
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
ALTER TABLE [dbo].[HighlightedProduct]  WITH CHECK ADD  CONSTRAINT [FK_HighlightedProduct_HighlightType] FOREIGN KEY([HighlightTypeID])
REFERENCES [dbo].[HighlightType] ([ID])
GO
ALTER TABLE [dbo].[HighlightedProduct] CHECK CONSTRAINT [FK_HighlightedProduct_HighlightType]
GO
ALTER TABLE [dbo].[HighlightedProduct]  WITH CHECK ADD  CONSTRAINT [FK_HighlightedProduct_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[HighlightedProduct] CHECK CONSTRAINT [FK_HighlightedProduct_Product]
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
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductGroup] FOREIGN KEY([ProductGroupID])
REFERENCES [dbo].[ProductGroup] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductGroup]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserProfile] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_User]
GO
ALTER TABLE [dbo].[ProductGroup]  WITH CHECK ADD  CONSTRAINT [FK_ProductGroup_Category1] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[ProductGroup] CHECK CONSTRAINT [FK_ProductGroup_Category1]
GO
ALTER TABLE [dbo].[ProductGroup]  WITH CHECK ADD  CONSTRAINT [FK_ProductGroup_Publisher1] FOREIGN KEY([PublisherID])
REFERENCES [dbo].[Publisher] ([ID])
GO
ALTER TABLE [dbo].[ProductGroup] CHECK CONSTRAINT [FK_ProductGroup_Publisher1]
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
ALTER TABLE [dbo].[Publisher]  WITH CHECK ADD  CONSTRAINT [FK_Publisher_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserProfile] ([ID])
GO
ALTER TABLE [dbo].[Publisher] CHECK CONSTRAINT [FK_Publisher_User]
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
ALTER TABLE [dbo].[UserAddress]  WITH CHECK ADD  CONSTRAINT [FK_UserAddress_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserProfile] ([ID])
GO
ALTER TABLE [dbo].[UserAddress] CHECK CONSTRAINT [FK_UserAddress_User]
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
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_RoleId]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([ID])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_UserId]
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
ALTER TABLE [dbo].[HighlightedProduct]  WITH CHECK ADD  CONSTRAINT [CK_HighlightedProduct_ToDate_bt_FromDate] CHECK  (([FromDate]<[ToDate]))
GO
ALTER TABLE [dbo].[HighlightedProduct] CHECK CONSTRAINT [CK_HighlightedProduct_ToDate_bt_FromDate]
GO
ALTER TABLE [dbo].[Image]  WITH CHECK ADD  CONSTRAINT [CK_Image_3ForeignKeys] CHECK  (([ProductID] IS NOT NULL AND [ProductGroupID] IS NULL AND [UserID] IS NULL OR [ProductID] IS NULL AND [ProductGroupID] IS NOT NULL AND [UserID] IS NULL OR [ProductID] IS NULL AND [ProductGroupID] IS NULL AND [UserID] IS NOT NULL))
GO
ALTER TABLE [dbo].[Image] CHECK CONSTRAINT [CK_Image_3ForeignKeys]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [CK_Product_DownloadableProductCannotBeUsed] CHECK  ((([IsUsed]&[IsDownloadable])=(0)))
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [CK_Product_DownloadableProductCannotBeUsed]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [CK_Product_DownloadableQuantity_0_1] CHECK  (([IsDownloadable]=(0) OR [IsDownloadable]=(1) AND ([HowMany]=(1) OR [HowMany]=(0))))
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [CK_Product_DownloadableQuantity_0_1]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [CK_Product_Edition_bte_1] CHECK  (([Edition]>=(1)))
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [CK_Product_Edition_bte_1]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [CK_Product_HowMany_bte_0] CHECK  (([HowMany]>=(0)))
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [CK_Product_HowMany_bte_0]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [CK_Product_IsBook_IsAudio_IsVideo_Not_0_0_0] CHECK  (((([IsBook]|[IsAudio])|[IsVideo])=(1)))
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [CK_Product_IsBook_IsAudio_IsVideo_Not_0_0_0]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [CK_Product_PageNumber_bt_0] CHECK  (([PageNumber]>(0)))
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [CK_Product_PageNumber_bt_0]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [CK_Product_Price_bt_0] CHECK  (([Price]>(0)))
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [CK_Product_Price_bt_0]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [CK_Product_PublishYear_bt_0] CHECK  (([PublishYear]>(0)))
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [CK_Product_PublishYear_bt_0]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [CK_Product_SumOfViews_bte_0] CHECK  (([SumOfViews]>=(0)))
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [CK_Product_SumOfViews_bte_0]
GO
ALTER TABLE [dbo].[ProductGroup]  WITH CHECK ADD  CONSTRAINT [CK_ProductGroup_MaxPrice_bt_0] CHECK  (([MaxPrice]>(0)))
GO
ALTER TABLE [dbo].[ProductGroup] CHECK CONSTRAINT [CK_ProductGroup_MaxPrice_bt_0]
GO
ALTER TABLE [dbo].[ProductGroup]  WITH CHECK ADD  CONSTRAINT [CK_ProductGroup_MinPrice_bt_0] CHECK  (([MinPrice]>(0)))
GO
ALTER TABLE [dbo].[ProductGroup] CHECK CONSTRAINT [CK_ProductGroup_MinPrice_bt_0]
GO
ALTER TABLE [dbo].[ProductGroup]  WITH CHECK ADD  CONSTRAINT [CK_ProductGroup_SumOfActiveProductsInGroup_bte_0] CHECK  (([SumOfActiveProductsInGroup]>=(0)))
GO
ALTER TABLE [dbo].[ProductGroup] CHECK CONSTRAINT [CK_ProductGroup_SumOfActiveProductsInGroup_bte_0]
GO
ALTER TABLE [dbo].[ProductGroup]  WITH CHECK ADD  CONSTRAINT [CK_ProductGroup_SumOfBuys_bte_0] CHECK  (([SumOfBuys]>=(0)))
GO
ALTER TABLE [dbo].[ProductGroup] CHECK CONSTRAINT [CK_ProductGroup_SumOfBuys_bte_0]
GO
ALTER TABLE [dbo].[ProductGroup]  WITH CHECK ADD  CONSTRAINT [CK_ProductGroup_SumOfComments_bte_0] CHECK  (([SumOfComments]>=(0)))
GO
ALTER TABLE [dbo].[ProductGroup] CHECK CONSTRAINT [CK_ProductGroup_SumOfComments_bte_0]
GO
ALTER TABLE [dbo].[ProductGroup]  WITH CHECK ADD  CONSTRAINT [CK_ProductGroup_SumOfPassiveProductsInGroup_bte_0] CHECK  (([SumOfPassiveProductsInGroup]>=(0)))
GO
ALTER TABLE [dbo].[ProductGroup] CHECK CONSTRAINT [CK_ProductGroup_SumOfPassiveProductsInGroup_bte_0]
GO
ALTER TABLE [dbo].[ProductGroup]  WITH CHECK ADD  CONSTRAINT [CK_ProductGroup_SumOfRatings_bte_0] CHECK  (([SumOfRatings]>=(0)))
GO
ALTER TABLE [dbo].[ProductGroup] CHECK CONSTRAINT [CK_ProductGroup_SumOfRatings_bte_0]
GO
ALTER TABLE [dbo].[ProductGroup]  WITH CHECK ADD  CONSTRAINT [CK_ProductGroup_SumOfRatingsValue_bte_0] CHECK  (([SumOfRatingsValue]>=(0)))
GO
ALTER TABLE [dbo].[ProductGroup] CHECK CONSTRAINT [CK_ProductGroup_SumOfRatingsValue_bte_0]
GO
ALTER TABLE [dbo].[ProductGroup]  WITH CHECK ADD  CONSTRAINT [CK_ProductGroup_SumOfViews_bte_0] CHECK  (([SumOfViews]>=(0)))
GO
ALTER TABLE [dbo].[ProductGroup] CHECK CONSTRAINT [CK_ProductGroup_SumOfViews_bte_0]
GO
ALTER TABLE [dbo].[ProductInOrder]  WITH CHECK ADD  CONSTRAINT [CK_ProductInOrder_HowMany_bte_1] CHECK  (([HowMany]>=(1)))
GO
ALTER TABLE [dbo].[ProductInOrder] CHECK CONSTRAINT [CK_ProductInOrder_HowMany_bte_1]
GO
ALTER TABLE [dbo].[ProductInOrder]  WITH CHECK ADD  CONSTRAINT [CK_ProductInOrder_UnitPrice_bt_0] CHECK  (([UnitPrice]>(0)))
GO
ALTER TABLE [dbo].[ProductInOrder] CHECK CONSTRAINT [CK_ProductInOrder_UnitPrice_bt_0]
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [CK_Rating_Value_1_10] CHECK  (([Value]>=(1) AND [Value]<=(10)))
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [CK_Rating_Value_1_10]
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
GO
ALTER TABLE [dbo].[UserOrder]  WITH CHECK ADD  CONSTRAINT [CK_UserOrder_CantByFromSelf] CHECK  (([CustomerUserProfileID]<>[VendorUserProfileID]))
GO
ALTER TABLE [dbo].[UserOrder] CHECK CONSTRAINT [CK_UserOrder_CantByFromSelf]
GO
ALTER TABLE [dbo].[UserOrder]  WITH CHECK ADD  CONSTRAINT [CK_UserOrder_SumBookPrice_bte_0] CHECK  (([SumBookPrice]>=(0)))
GO
ALTER TABLE [dbo].[UserOrder] CHECK CONSTRAINT [CK_UserOrder_SumBookPrice_bte_0]
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
GO
ALTER TABLE [dbo].[UserView]  WITH CHECK ADD  CONSTRAINT [CK_UserViewProduct_ProductID_XOR_ProductGroupID] CHECK  (([ProductID] IS NULL AND [ProductGroupID] IS NOT NULL OR [ProductID] IS NOT NULL AND [ProductGroupID] IS NULL))
GO
ALTER TABLE [dbo].[UserView] CHECK CONSTRAINT [CK_UserViewProduct_ProductID_XOR_ProductGroupID]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Visszajelzés 3 típusa:
Pozitív: 1
Semleges: null
Negatív: 0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Feedback', @level2type=N'COLUMN',@level2name=N'IsPositive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 felhasználó 1 felhasználót 1 adásvételben csak egyszer értékelhet!' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Feedback', @level2type=N'CONSTRAINT',@level2name=N'UK_Feedback'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ha adatbázis szinten egyedivé tesszük a fájlneveket, mindenképp törölhetők a fájl rendszerből is, ha a rekordjukat töröljük az adatbázisból' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Image', @level2type=N'CONSTRAINT',@level2name=N'UK_Image_Url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Minden feltöltött kép bekerül ebbe a táblába (Image). Ezek 3 másik táblához tartozhatnak, de csak az egyikhez; valamelyikhez viszont mindenképp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Image', @level2type=N'CONSTRAINT',@level2name=N'CK_Image_3ForeignKeys'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Elektronikus termék nem lehet használt (pl pdf)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'CONSTRAINT',@level2name=N'CK_Product_DownloadableProductCannotBeUsed'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Letölthető termék mennyisége mindig 1; vagy 0, ha törölte a terméket a felhasználó' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'CONSTRAINT',@level2name=N'CK_Product_DownloadableQuantity_0_1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ez alapán a 4 adat egyezése alapján tekintünk 2 könyvet azonosnak' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ProductGroup', @level2type=N'CONSTRAINT',@level2name=N'UK_ProductGroup_Author_Publisher_Title_Subtitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Egy konkrét megrendelésben egy product csak egyszer szerepelhet, a HowMany írja le, hány példányban' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ProductInOrder', @level2type=N'CONSTRAINT',@level2name=N'UK_ProductInOrder_ProductID_UserOrderID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Egy user egy product-ot csak egyszer véleményezhet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Rating', @level2type=N'CONSTRAINT',@level2name=N'UK_Rating_ProductID_UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dettó ua címet ua user nem vehet fel többször' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserAddress', @level2type=N'CONSTRAINT',@level2name=N'UK_UserAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Adott user adott product/productGroup-t 1 UserViewProduct rekordban nézeget' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserView', @level2type=N'CONSTRAINT',@level2name=N'UK_UserViewProduct_UserID_AND_ProductID_AND_ProductGroupID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ez a tábla tárolja a UserView-kat a Product és a ProductGroup tábla rekordjaira is. A 2 külső kulcs közül egyszerre csak az egyik lehet érvényben' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserView', @level2type=N'CONSTRAINT',@level2name=N'CK_UserViewProduct_ProductID_XOR_ProductGroupID'
GO
USE [master]
GO
ALTER DATABASE [BookTera] SET  READ_WRITE 
GO
