USE [master]
GO
/****** Object:  Database [LibraryManagementDb]    Script Date: 8/24/2026 2:50:13 PM ******/
CREATE DATABASE [LibraryManagementDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibraryManagementDb', FILENAME = N'E:\SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\LibraryManagementDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LibraryManagementDb_log', FILENAME = N'E:\SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\LibraryManagementDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [LibraryManagementDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibraryManagementDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibraryManagementDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibraryManagementDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibraryManagementDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibraryManagementDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibraryManagementDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibraryManagementDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LibraryManagementDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibraryManagementDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibraryManagementDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibraryManagementDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibraryManagementDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibraryManagementDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibraryManagementDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibraryManagementDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibraryManagementDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LibraryManagementDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibraryManagementDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibraryManagementDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibraryManagementDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibraryManagementDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibraryManagementDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [LibraryManagementDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibraryManagementDb] SET RECOVERY FULL 
GO
ALTER DATABASE [LibraryManagementDb] SET  MULTI_USER 
GO
ALTER DATABASE [LibraryManagementDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibraryManagementDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibraryManagementDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibraryManagementDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LibraryManagementDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LibraryManagementDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'LibraryManagementDb', N'ON'
GO
ALTER DATABASE [LibraryManagementDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [LibraryManagementDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [LibraryManagementDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/24/2026 2:50:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 8/24/2026 2:50:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 8/24/2026 2:50:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 8/24/2026 2:50:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 8/24/2026 2:50:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 8/24/2026 2:50:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 8/24/2026 2:50:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](150) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 8/24/2026 2:50:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [int] NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 8/24/2026 2:50:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookAuthors]    Script Date: 8/24/2026 2:50:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookAuthors](
	[BookId] [int] NOT NULL,
	[AuthorId] [int] NOT NULL,
 CONSTRAINT [PK_BookAuthors] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC,
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 8/24/2026 2:50:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[ISBN] [nvarchar](20) NOT NULL,
	[Edition] [nvarchar](50) NULL,
	[Summary] [nvarchar](max) NULL,
	[Language] [nvarchar](50) NOT NULL,
	[PublicationYear] [int] NOT NULL,
	[CoverImage] [nvarchar](500) NULL,
	[Status] [int] NOT NULL,
	[PublisherId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Borrowings]    Script Date: 8/24/2026 2:50:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Borrowings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NOT NULL,
	[MemberId] [int] NOT NULL,
	[BorrowedByUserId] [int] NOT NULL,
	[BorrowedAt] [datetime2](7) NOT NULL,
	[DueDate] [datetime2](7) NOT NULL,
	[ReturnedAt] [datetime2](7) NULL,
	[ReturnedByUserId] [int] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Borrowings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 8/24/2026 2:50:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[ParentCategoryId] [int] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Members]    Script Date: 8/24/2026 2:50:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberCode] [nvarchar](20) NOT NULL,
	[FullName] [nvarchar](150) NOT NULL,
	[Email] [nvarchar](150) NULL,
	[Phone] [nvarchar](20) NULL,
	[Address] [nvarchar](250) NULL,
	[JoinDate] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products]    Script Date: 8/24/2026 2:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products](
	[productId] [int] IDENTITY(1,1) NOT NULL,
	[productName] [nvarchar](500) NULL,
	[productDescription] [nvarchar](1000) NULL,
	[productImage] [varbinary](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publishers]    Script Date: 8/24/2026 2:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publishers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Address] [nvarchar](250) NULL,
	[Phone] [nvarchar](20) NULL,
	[Email] [nvarchar](150) NULL,
 CONSTRAINT [PK_Publishers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserActivityLogs]    Script Date: 8/24/2026 2:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserActivityLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Action] [nvarchar](100) NOT NULL,
	[EntityName] [nvarchar](100) NULL,
	[EntityId] [int] NULL,
	[Timestamp] [datetime2](7) NOT NULL,
	[IpAddress] [nvarchar](45) NULL,
 CONSTRAINT [PK_UserActivityLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20260822073510_InitialCreateDB', N'8.0.0')
GO
SET IDENTITY_INSERT [dbo].[AspNetRoles] ON 
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (1, N'Administrator', N'ADMINISTRATOR', NULL)
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (2, N'Librarian', N'LIBRARIAN', NULL)
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (3, N'Staff', N'STAFF', NULL)
GO
SET IDENTITY_INSERT [dbo].[AspNetRoles] OFF
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (1, 1)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (2, 2)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (3, 3)
GO
SET IDENTITY_INSERT [dbo].[AspNetUsers] ON 
GO
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [IsActive], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (1, N'System Administrator', 1, N'admin@library.com', N'ADMIN@LIBRARY.COM', N'admin@library.com', N'ADMIN@LIBRARY.COM', 1, N'AQAAAAIAAYagAAAAENZMEGgbQXBFfQu0cj3WA7mX0WGDtmDTsytUY3q8yPj5AMXWUyc7CrQydaQ0yVlVag==', N'C7UP5AB3WTSZEZELYGYLGYBKJM6WZTTQ', N'a3e5bb14-d3a1-4d99-8de1-c819538576f6', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [IsActive], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (2, N'Ahmed Librarian', 1, N'Ahmed@library.com', N'AHMED@LIBRARY.COM', N'Ahmed@library.com', N'AHMED@LIBRARY.COM', 1, N'AQAAAAIAAYagAAAAECk5fP5VuP5kOIlj63OGcRxJfHbOQZE4Th7iPkF+kAwVLOcrNYtN6jBQLnwQgFUy2w==', N'TUDJCGBGC2TCO22KWIRTMGO22L22ADX3', N'76ae3db2-5750-4756-a435-ec72a3835ad4', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [IsActive], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (3, N'Marwa Staff', 1, N'Marwa@library.com', N'MARWA@LIBRARY.COM', N'Marwa@library.com', N'MARWA@LIBRARY.COM', 1, N'AQAAAAIAAYagAAAAEGamVigN03Plp6PCma7GVpAeeh34qiekd+rQ/5qrQuKkxkiPvmoK2K7dCGasOlHldA==', N'2YH5MZ567FRBQ44C77DSOAR7M4LSR532', N'2da8bea2-1de6-4c85-b700-a46f3c7ba1f1', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 
GO
INSERT [dbo].[Authors] ([Id], [Name]) VALUES (1, N'Robert C. Martin')
GO
INSERT [dbo].[Authors] ([Id], [Name]) VALUES (2, N'Martin Fowler')
GO
INSERT [dbo].[Authors] ([Id], [Name]) VALUES (4, N'Andrew Hunt')
GO
INSERT [dbo].[Authors] ([Id], [Name]) VALUES (5, N'David Thomas')
GO
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO
INSERT [dbo].[BookAuthors] ([BookId], [AuthorId]) VALUES (1, 1)
GO
INSERT [dbo].[BookAuthors] ([BookId], [AuthorId]) VALUES (2, 2)
GO
INSERT [dbo].[BookAuthors] ([BookId], [AuthorId]) VALUES (3, 2)
GO
INSERT [dbo].[BookAuthors] ([BookId], [AuthorId]) VALUES (4, 2)
GO
INSERT [dbo].[BookAuthors] ([BookId], [AuthorId]) VALUES (2, 4)
GO
INSERT [dbo].[BookAuthors] ([BookId], [AuthorId]) VALUES (4, 5)
GO
SET IDENTITY_INSERT [dbo].[Books] ON 
GO
INSERT [dbo].[Books] ([Id], [Title], [ISBN], [Edition], [Summary], [Language], [PublicationYear], [CoverImage], [Status], [PublisherId], [CategoryId]) VALUES (1, N'Clean Code', N'9780132350884', N'1st Edition', N'A handbook of agile software craftsmanship.', N'English', 2008, N'clean-code.jpg', 1, 1, 1)
GO
INSERT [dbo].[Books] ([Id], [Title], [ISBN], [Edition], [Summary], [Language], [PublicationYear], [CoverImage], [Status], [PublisherId], [CategoryId]) VALUES (2, N'The Pragmatic Programmer', N'9780135957059', N'2nd Edition', N'Your journey to mastery in software development.', N'English', 2019, N'pragmatic-programmer.jpg', 2, 2, 1)
GO
INSERT [dbo].[Books] ([Id], [Title], [ISBN], [Edition], [Summary], [Language], [PublicationYear], [CoverImage], [Status], [PublisherId], [CategoryId]) VALUES (3, N'Refactoring', N'9780134757599', N'2nd Edition', N'Improving the design of existing code.', N'English', 2018, N'refactoring.jpg', 1, 2, 1)
GO
INSERT [dbo].[Books] ([Id], [Title], [ISBN], [Edition], [Summary], [Language], [PublicationYear], [CoverImage], [Status], [PublisherId], [CategoryId]) VALUES (4, N'The Pragmatic Programmer', N'9780135957080', N'2', N'Your journey to mastery in software development', N'English', 2019, N'0c343695-8917-49a0-8dbd-ff3145a68626.jpg', 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[Borrowings] ON 
GO
INSERT [dbo].[Borrowings] ([Id], [BookId], [MemberId], [BorrowedByUserId], [BorrowedAt], [DueDate], [ReturnedAt], [ReturnedByUserId], [Status]) VALUES (1, 1, 1, 1, CAST(N'2026-08-23T18:47:42.1161931' AS DateTime2), CAST(N'2026-09-05T23:59:59.0000000' AS DateTime2), CAST(N'2026-08-23T18:49:17.9443682' AS DateTime2), 1, 2)
GO
INSERT [dbo].[Borrowings] ([Id], [BookId], [MemberId], [BorrowedByUserId], [BorrowedAt], [DueDate], [ReturnedAt], [ReturnedByUserId], [Status]) VALUES (2, 2, 1, 1, CAST(N'2026-08-24T03:26:42.0796250' AS DateTime2), CAST(N'2026-08-25T03:26:13.0930000' AS DateTime2), NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Borrowings] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([Id], [Name], [ParentCategoryId]) VALUES (1, N'Software Engineering', NULL)
GO
INSERT [dbo].[Categories] ([Id], [Name], [ParentCategoryId]) VALUES (2, N'Programming', 1)
GO
INSERT [dbo].[Categories] ([Id], [Name], [ParentCategoryId]) VALUES (3, N'Clean Code', 1)
GO
INSERT [dbo].[Categories] ([Id], [Name], [ParentCategoryId]) VALUES (4, N'Web Development', 1)
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Members] ON 
GO
INSERT [dbo].[Members] ([Id], [MemberCode], [FullName], [Email], [Phone], [Address], [JoinDate], [IsActive]) VALUES (1, N'MEM-00001', N'Ahmed Hassan', N'ahmed.hassan@example.com', N'01012345678', N'Cairo, Egypt', CAST(N'2026-08-23T18:01:21.0984339' AS DateTime2), 1)
GO
INSERT [dbo].[Members] ([Id], [MemberCode], [FullName], [Email], [Phone], [Address], [JoinDate], [IsActive]) VALUES (2, N'MEM-00002', N'Sara Mohamed', N'sara.mohamed@example.com', N'01198765432', N'Giza, Egypt', CAST(N'2026-08-23T18:01:50.3990704' AS DateTime2), 0)
GO
SET IDENTITY_INSERT [dbo].[Members] OFF
GO
SET IDENTITY_INSERT [dbo].[Publishers] ON 
GO
INSERT [dbo].[Publishers] ([Id], [Name], [Address], [Phone], [Email]) VALUES (1, N'Prentice Hall', N'New Jersey, USA', N'+1-555-100-1000', N'contact@prenticehall.com')
GO
INSERT [dbo].[Publishers] ([Id], [Name], [Address], [Phone], [Email]) VALUES (2, N'Addison-Wesley', N'Boston, USA', N'+1-555-200-2000', N'contact@aw.com')
GO
SET IDENTITY_INSERT [dbo].[Publishers] OFF
GO
SET IDENTITY_INSERT [dbo].[UserActivityLogs] ON 
GO
INSERT [dbo].[UserActivityLogs] ([Id], [UserId], [Action], [EntityName], [EntityId], [Timestamp], [IpAddress]) VALUES (1, 1, N'Login', N'ApplicationUser', 1, CAST(N'2026-08-24T03:25:43.4265888' AS DateTime2), N'::1')
GO
INSERT [dbo].[UserActivityLogs] ([Id], [UserId], [Action], [EntityName], [EntityId], [Timestamp], [IpAddress]) VALUES (2, 1, N'Borrow Book', N'Borrowing', 2, CAST(N'2026-08-24T03:26:42.4256530' AS DateTime2), N'::1')
GO
INSERT [dbo].[UserActivityLogs] ([Id], [UserId], [Action], [EntityName], [EntityId], [Timestamp], [IpAddress]) VALUES (3, 3, N'Login', N'ApplicationUser', 3, CAST(N'2026-08-24T06:25:16.0967878' AS DateTime2), N'::1')
GO
INSERT [dbo].[UserActivityLogs] ([Id], [UserId], [Action], [EntityName], [EntityId], [Timestamp], [IpAddress]) VALUES (4, 3, N'Logout', N'ApplicationUser', 3, CAST(N'2026-08-24T06:25:40.1029810' AS DateTime2), N'::1')
GO
INSERT [dbo].[UserActivityLogs] ([Id], [UserId], [Action], [EntityName], [EntityId], [Timestamp], [IpAddress]) VALUES (5, 1, N'Login', N'ApplicationUser', 1, CAST(N'2026-08-24T06:26:09.0289606' AS DateTime2), N'::1')
GO
INSERT [dbo].[UserActivityLogs] ([Id], [UserId], [Action], [EntityName], [EntityId], [Timestamp], [IpAddress]) VALUES (6, 1, N'Login', N'ApplicationUser', 1, CAST(N'2026-08-24T06:39:30.1577555' AS DateTime2), N'::1')
GO
SET IDENTITY_INSERT [dbo].[UserActivityLogs] OFF
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 8/24/2026 2:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 8/24/2026 2:50:14 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 8/24/2026 2:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 8/24/2026 2:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 8/24/2026 2:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 8/24/2026 2:50:14 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 8/24/2026 2:50:14 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BookAuthors_AuthorId]    Script Date: 8/24/2026 2:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_BookAuthors_AuthorId] ON [dbo].[BookAuthors]
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Books_CategoryId]    Script Date: 8/24/2026 2:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Books_CategoryId] ON [dbo].[Books]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Books_ISBN]    Script Date: 8/24/2026 2:50:14 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Books_ISBN] ON [dbo].[Books]
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Books_PublisherId]    Script Date: 8/24/2026 2:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Books_PublisherId] ON [dbo].[Books]
(
	[PublisherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Borrowings_BookId]    Script Date: 8/24/2026 2:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Borrowings_BookId] ON [dbo].[Borrowings]
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Borrowings_BorrowedByUserId]    Script Date: 8/24/2026 2:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Borrowings_BorrowedByUserId] ON [dbo].[Borrowings]
(
	[BorrowedByUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Borrowings_MemberId]    Script Date: 8/24/2026 2:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Borrowings_MemberId] ON [dbo].[Borrowings]
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Borrowings_ReturnedByUserId]    Script Date: 8/24/2026 2:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Borrowings_ReturnedByUserId] ON [dbo].[Borrowings]
(
	[ReturnedByUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Categories_ParentCategoryId]    Script Date: 8/24/2026 2:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Categories_ParentCategoryId] ON [dbo].[Categories]
(
	[ParentCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Members_MemberCode]    Script Date: 8/24/2026 2:50:14 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Members_MemberCode] ON [dbo].[Members]
(
	[MemberCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserActivityLogs_UserId]    Script Date: 8/24/2026 2:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserActivityLogs_UserId] ON [dbo].[UserActivityLogs]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[BookAuthors]  WITH CHECK ADD  CONSTRAINT [FK_BookAuthors_Authors_AuthorId] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BookAuthors] CHECK CONSTRAINT [FK_BookAuthors_Authors_AuthorId]
GO
ALTER TABLE [dbo].[BookAuthors]  WITH CHECK ADD  CONSTRAINT [FK_BookAuthors_Books_BookId] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BookAuthors] CHECK CONSTRAINT [FK_BookAuthors_Books_BookId]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Publishers_PublisherId] FOREIGN KEY([PublisherId])
REFERENCES [dbo].[Publishers] ([Id])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Publishers_PublisherId]
GO
ALTER TABLE [dbo].[Borrowings]  WITH CHECK ADD  CONSTRAINT [FK_Borrowings_AspNetUsers_BorrowedByUserId] FOREIGN KEY([BorrowedByUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Borrowings] CHECK CONSTRAINT [FK_Borrowings_AspNetUsers_BorrowedByUserId]
GO
ALTER TABLE [dbo].[Borrowings]  WITH CHECK ADD  CONSTRAINT [FK_Borrowings_AspNetUsers_ReturnedByUserId] FOREIGN KEY([ReturnedByUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Borrowings] CHECK CONSTRAINT [FK_Borrowings_AspNetUsers_ReturnedByUserId]
GO
ALTER TABLE [dbo].[Borrowings]  WITH CHECK ADD  CONSTRAINT [FK_Borrowings_Books_BookId] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([Id])
GO
ALTER TABLE [dbo].[Borrowings] CHECK CONSTRAINT [FK_Borrowings_Books_BookId]
GO
ALTER TABLE [dbo].[Borrowings]  WITH CHECK ADD  CONSTRAINT [FK_Borrowings_Members_MemberId] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[Borrowings] CHECK CONSTRAINT [FK_Borrowings_Members_MemberId]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories_ParentCategoryId] FOREIGN KEY([ParentCategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Categories_ParentCategoryId]
GO
ALTER TABLE [dbo].[UserActivityLogs]  WITH CHECK ADD  CONSTRAINT [FK_UserActivityLogs_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserActivityLogs] CHECK CONSTRAINT [FK_UserActivityLogs_AspNetUsers_UserId]
GO
USE [master]
GO
ALTER DATABASE [LibraryManagementDb] SET  READ_WRITE 
GO
