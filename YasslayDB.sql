USE [master]
GO
/****** Object:  Database [Yasslay]    Script Date: 12/21/2022 2:58:56 PM ******/
CREATE DATABASE [Yasslay]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Yasslay', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Yasslay.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Yasslay_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Yasslay_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Yasslay] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Yasslay].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Yasslay] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Yasslay] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Yasslay] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Yasslay] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Yasslay] SET ARITHABORT OFF 
GO
ALTER DATABASE [Yasslay] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Yasslay] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Yasslay] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Yasslay] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Yasslay] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Yasslay] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Yasslay] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Yasslay] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Yasslay] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Yasslay] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Yasslay] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Yasslay] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Yasslay] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Yasslay] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Yasslay] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Yasslay] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Yasslay] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Yasslay] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Yasslay] SET  MULTI_USER 
GO
ALTER DATABASE [Yasslay] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Yasslay] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Yasslay] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Yasslay] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Yasslay] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Yasslay] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Yasslay] SET QUERY_STORE = ON
GO
ALTER DATABASE [Yasslay] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Yasslay]
GO
/****** Object:  Table [dbo].[ConfessionsTable]    Script Date: 12/21/2022 2:58:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfessionsTable](
	[ConfessID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[Relationship] [varchar](50) NULL,
	[Message] [varchar](50) NULL,
	[RecipientLN] [varchar](50) NULL,
	[RecipientFN] [varchar](50) NULL,
	[GiftID] [int] NULL,
	[Status] [varchar](50) NULL,
	[StatusID] [int] NULL,
 CONSTRAINT [PK_ConfessionsTable] PRIMARY KEY CLUSTERED 
(
	[ConfessID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiftsTable]    Script Date: 12/21/2022 2:58:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiftsTable](
	[GiftID] [int] IDENTITY(1,1) NOT NULL,
	[GiftName] [varchar](50) NULL,
	[Price] [varchar](50) NULL,
	[QuantityLeft] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_GiftsTable] PRIMARY KEY CLUSTERED 
(
	[GiftID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersTable]    Script Date: 12/21/2022 2:58:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersTable](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[UserType] [varchar](50) NULL,
	[State] [varchar](50) NULL,
 CONSTRAINT [PK_UsersTable] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ConfessionsTable] ON 

INSERT [dbo].[ConfessionsTable] ([ConfessID], [UserID], [Relationship], [Message], [RecipientLN], [RecipientFN], [GiftID], [Status], [StatusID]) VALUES (12, 19, N'Fan', N'I''m a fan of your music !!', N'Minaj', N'Nicki', 7, N'Accepted', 12)
INSERT [dbo].[ConfessionsTable] ([ConfessID], [UserID], [Relationship], [Message], [RecipientLN], [RecipientFN], [GiftID], [Status], [StatusID]) VALUES (13, 21, N'Friends', N'Hello napansin na kita', N'Curativo', N'Ernest', 12, N'Accepted', 1)
INSERT [dbo].[ConfessionsTable] ([ConfessID], [UserID], [Relationship], [Message], [RecipientLN], [RecipientFN], [GiftID], [Status], [StatusID]) VALUES (16, 24, N'Boyfriend', N'Some flowers for u', N'Spring', N'Charlie', 10, N'Accepted', 12)
INSERT [dbo].[ConfessionsTable] ([ConfessID], [UserID], [Relationship], [Message], [RecipientLN], [RecipientFN], [GiftID], [Status], [StatusID]) VALUES (17, 25, N'Boyfriend', N'I love you. Here are your gloves for the snow.', N'Nelson', N'Nick', 15, N'Accepted', 1)
INSERT [dbo].[ConfessionsTable] ([ConfessID], [UserID], [Relationship], [Message], [RecipientLN], [RecipientFN], [GiftID], [Status], [StatusID]) VALUES (18, 26, N'Ex', N'we never run out of style', N'Swift', N'Taylor', 12, N'Accepted', 12)
INSERT [dbo].[ConfessionsTable] ([ConfessID], [UserID], [Relationship], [Message], [RecipientLN], [RecipientFN], [GiftID], [Status], [StatusID]) VALUES (19, 5, N'besties', N'U GOT ME WALKING SIDE TO SIDE yuyuhhh', N'Minaj', N'Nicki', 16, N'Accepted', 12)
INSERT [dbo].[ConfessionsTable] ([ConfessID], [UserID], [Relationship], [Message], [RecipientLN], [RecipientFN], [GiftID], [Status], [StatusID]) VALUES (20, 29, N'Sister', N'WE NEVER TALK ABOUT U LOL', N'Madrigal', N'Bruno', 16, N'Accepted', 12)
INSERT [dbo].[ConfessionsTable] ([ConfessID], [UserID], [Relationship], [Message], [RecipientLN], [RecipientFN], [GiftID], [Status], [StatusID]) VALUES (21, 30, N'hookup partner', N'U FROZE LMFAOOOOO', N'Titanic', N'Jack', 8, N'Rejected', 33)
INSERT [dbo].[ConfessionsTable] ([ConfessID], [UserID], [Relationship], [Message], [RecipientLN], [RecipientFN], [GiftID], [Status], [StatusID]) VALUES (22, 31, N'Friends', N'hii', N'Curativo', N'Ernest', 16, N'Accepted', 12)
INSERT [dbo].[ConfessionsTable] ([ConfessID], [UserID], [Relationship], [Message], [RecipientLN], [RecipientFN], [GiftID], [Status], [StatusID]) VALUES (23, 32, N'Friend', N'hello harry styles, i am a fan', N'Styles', N'Harry', 9, N'Accepted', 12)
INSERT [dbo].[ConfessionsTable] ([ConfessID], [UserID], [Relationship], [Message], [RecipientLN], [RecipientFN], [GiftID], [Status], [StatusID]) VALUES (24, 34, N'friends', N'hi crushie', N'Pedrano', N'Janciel', 18, N'Accepted', 12)
SET IDENTITY_INSERT [dbo].[ConfessionsTable] OFF
GO
SET IDENTITY_INSERT [dbo].[GiftsTable] ON 

INSERT [dbo].[GiftsTable] ([GiftID], [GiftName], [Price], [QuantityLeft], [Status], [UserID]) VALUES (7, N'Picture Frame', N'350', N'65', N'Available', 12)
INSERT [dbo].[GiftsTable] ([GiftID], [GiftName], [Price], [QuantityLeft], [Status], [UserID]) VALUES (8, N'Jacket', N'890', N'35', N'Available', 12)
INSERT [dbo].[GiftsTable] ([GiftID], [GiftName], [Price], [QuantityLeft], [Status], [UserID]) VALUES (9, N'Teddy Bear', N'600', N'39', N'Available', 15)
INSERT [dbo].[GiftsTable] ([GiftID], [GiftName], [Price], [QuantityLeft], [Status], [UserID]) VALUES (10, N'Flowers', N'340', N'18', N'Available', 12)
INSERT [dbo].[GiftsTable] ([GiftID], [GiftName], [Price], [QuantityLeft], [Status], [UserID]) VALUES (11, N'Chocolate', N'50', N'0', N'Sold Out', 12)
INSERT [dbo].[GiftsTable] ([GiftID], [GiftName], [Price], [QuantityLeft], [Status], [UserID]) VALUES (12, N'Dress', N'999', N'5', N'Available', 12)
INSERT [dbo].[GiftsTable] ([GiftID], [GiftName], [Price], [QuantityLeft], [Status], [UserID]) VALUES (13, N'Ice cream', N'20', N'0', N'Sold Out', 12)
INSERT [dbo].[GiftsTable] ([GiftID], [GiftName], [Price], [QuantityLeft], [Status], [UserID]) VALUES (15, N'Winter Gloves', N'450', N'44', N'Available', 12)
INSERT [dbo].[GiftsTable] ([GiftID], [GiftName], [Price], [QuantityLeft], [Status], [UserID]) VALUES (16, N'Mug', N'70', N'55', N'Available', 12)
INSERT [dbo].[GiftsTable] ([GiftID], [GiftName], [Price], [QuantityLeft], [Status], [UserID]) VALUES (18, N'White Chocolate', N'100', N'40', N'Available', 33)
SET IDENTITY_INSERT [dbo].[GiftsTable] OFF
GO
SET IDENTITY_INSERT [dbo].[UsersTable] ON 

INSERT [dbo].[UsersTable] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [State]) VALUES (1, N'Nene', N'Nene', N'nene@gmail.com', N'nene', N'Seller', N'Active')
INSERT [dbo].[UsersTable] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [State]) VALUES (5, N'Ariana', N'Grande', N'agrande@gmail.com', N'agrande', N'Non-Seller', N'Active')
INSERT [dbo].[UsersTable] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [State]) VALUES (7, N'Lady', N'Aurora', N'ladyaurora@gmail.com', N'ladyaurora', N'Non-Seller', N'Active')
INSERT [dbo].[UsersTable] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [State]) VALUES (12, N'Lady', N'Gaga', N'ladygaga@gmail.com', N'ladygaga', N'Seller', N'Active')
INSERT [dbo].[UsersTable] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [State]) VALUES (14, N'Ernest', N'Curativo', N'ecurativo@gmail.com', N'ecurativo', N'Admin', N'Active')
INSERT [dbo].[UsersTable] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [State]) VALUES (15, N'Reene', N'Besanez', N'rbesanez@gmail.com', N'rbesanez', N'Seller', N'Active')
INSERT [dbo].[UsersTable] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [State]) VALUES (16, N'Reese', N'Besanez', N'reenebesanez@gmail.com', N'reenebesanez', N'Seller', N'Active')
INSERT [dbo].[UsersTable] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [State]) VALUES (17, N'Gimari', N'Baynosa', N'gbaynosa@gmail.com', N'gbaynosa', N'Non-Seller', N'Active')
INSERT [dbo].[UsersTable] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [State]) VALUES (21, N'Brandon', N'Flynn', N'bflynn@gmail.com', N'bflynn', N'Non-Seller', N'Active')
INSERT [dbo].[UsersTable] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [State]) VALUES (24, N'Nick', N'Nelson', N'nnelson@gmail.com', N'nnelson', N'Non-Seller', N'Disabled')
INSERT [dbo].[UsersTable] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [State]) VALUES (25, N'Charlie', N'Spring', N'cspring@gmail.com', N'cspring', N'Non-Seller', N'Active')
INSERT [dbo].[UsersTable] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [State]) VALUES (29, N'Isabella', N'Madrigal', N'madrigal@gmail.com', N'madrigal', N'Non-Seller', N'Active')
INSERT [dbo].[UsersTable] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [State]) VALUES (30, N'Rose', N'Titanic', N'rose@gmail.com', N'rose', N'Non-Seller', N'Active')
INSERT [dbo].[UsersTable] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [State]) VALUES (31, N'Ashton', N'Summers', N'asummers@gmail.com', N'asummers', N'Non-Seller', N'Active')
INSERT [dbo].[UsersTable] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [State]) VALUES (32, N'Billie', N'Eilish', N'beilish@gmail.com', N'password', N'Non-Seller', N'Disabled')
INSERT [dbo].[UsersTable] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [State]) VALUES (33, N'Adrian', N'Albino', N'albino@gmail.ocm', N'albino', N'Seller', N'Active')
INSERT [dbo].[UsersTable] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [State]) VALUES (34, N'Isabella', N'Adriatico', N'adriatico@gmail.com', N'adriatico', N'Non-Seller', N'Active')
SET IDENTITY_INSERT [dbo].[UsersTable] OFF
GO
ALTER TABLE [dbo].[ConfessionsTable]  WITH CHECK ADD  CONSTRAINT [FK_ConfessionsTable_UsersTable] FOREIGN KEY([GiftID])
REFERENCES [dbo].[GiftsTable] ([GiftID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ConfessionsTable] CHECK CONSTRAINT [FK_ConfessionsTable_UsersTable]
GO
ALTER TABLE [dbo].[ConfessionsTable]  WITH CHECK ADD  CONSTRAINT [FK_ConfessionsTable_UsersTable1] FOREIGN KEY([StatusID])
REFERENCES [dbo].[UsersTable] ([UserID])
GO
ALTER TABLE [dbo].[ConfessionsTable] CHECK CONSTRAINT [FK_ConfessionsTable_UsersTable1]
GO
ALTER TABLE [dbo].[GiftsTable]  WITH CHECK ADD  CONSTRAINT [FK_GiftsTable_UsersTable] FOREIGN KEY([UserID])
REFERENCES [dbo].[UsersTable] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GiftsTable] CHECK CONSTRAINT [FK_GiftsTable_UsersTable]
GO
USE [master]
GO
ALTER DATABASE [Yasslay] SET  READ_WRITE 
GO
