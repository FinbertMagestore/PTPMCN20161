USE [master]
GO
/****** Object:  Database [Education]    Script Date: 12/3/2016 10:02:13 AM ******/
CREATE DATABASE [Education]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Education', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SUCCESS\MSSQL\DATA\Education.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Education_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SUCCESS\MSSQL\DATA\Education_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Education] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Education].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Education] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Education] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Education] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Education] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Education] SET ARITHABORT OFF 
GO
ALTER DATABASE [Education] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Education] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Education] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Education] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Education] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Education] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Education] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Education] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Education] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Education] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Education] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Education] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Education] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Education] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Education] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Education] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Education] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Education] SET RECOVERY FULL 
GO
ALTER DATABASE [Education] SET  MULTI_USER 
GO
ALTER DATABASE [Education] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Education] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Education] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Education] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Education] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Education', N'ON'
GO
USE [Education]
GO
/****** Object:  Table [dbo].[AppUsers]    Script Date: 12/3/2016 10:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[LastActivityDate] [datetime] NULL,
	[SecurityStamp] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AppUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/3/2016 10:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/3/2016 10:02:15 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/3/2016 10:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/3/2016 10:02:15 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 12/3/2016 10:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
	[CategoryTypeID] [int] NULL,
	[Alias] [nvarchar](100) NULL,
	[Created] [datetime] NULL,
	[Modified] [datetime] NULL,
	[Status] [bit] NULL,
	[ImagePath] [nvarchar](200) NULL,
	[ForAdminPost] [bit] NULL,
	[IsHighLight] [bit] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClassInfo]    Script Date: 12/3/2016 10:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [nvarchar](50) NULL,
	[LevelID] [int] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CommentLession]    Script Date: 12/3/2016 10:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommentLession](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[LessionID] [int] NULL,
	[Content] [nvarchar](200) NULL,
	[Created] [datetime] NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_CommentLession] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CommentPost]    Script Date: 12/3/2016 10:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommentPost](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[PostID] [int] NULL,
	[Content] [nvarchar](200) NULL,
	[Created] [datetime] NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_CommentPost] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[District]    Script Date: 12/3/2016 10:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProvinceID] [int] NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_District] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 12/3/2016 10:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime] NULL,
	[Content] [nvarchar](200) NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FileUpload]    Script Date: 12/3/2016 10:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileUpload](
	[ID] [int] NOT NULL,
	[FileName] [nvarchar](50) NULL,
	[FileExtension] [nvarchar](10) NULL,
	[Created] [datetime] NULL,
	[Modified] [datetime] NULL,
	[Status] [bit] NULL,
	[FileUrl] [nvarchar](200) NULL,
	[FileSize] [int] NULL,
	[DownloadCount] [int] NULL,
	[IsDownload] [bit] NULL,
	[OldVersion] [int] NULL,
	[LessionID] [int] NULL,
 CONSTRAINT [PK_File] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lession]    Script Date: 12/3/2016 10:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lession](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
	[Created] [datetime] NULL,
	[Modified] [datetime] NULL,
	[Alias] [nvarchar](100) NULL,
	[Status] [bit] NULL,
	[ImageUrl] [nvarchar](200) NULL,
	[TeacherID] [int] NULL,
	[RateAverage] [float] NULL,
	[SubjectID] [int] NULL,
 CONSTRAINT [PK_Lession] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LevelEducation]    Script Date: 12/3/2016 10:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LevelEducation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_LevelEducation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LikePost]    Script Date: 12/3/2016 10:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LikePost](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PostID] [int] NULL,
	[UserID] [int] NULL,
	[Created] [datetime] NULL,
 CONSTRAINT [PK_LikePost] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Post]    Script Date: 12/3/2016 10:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[Alias] [nvarchar](50) NULL,
	[CategoryID] [int] NULL,
	[Created] [datetime] NULL,
	[Modified] [datetime] NULL,
	[Status] [bit] NULL,
	[Description] [nvarchar](200) NULL,
	[ImageUrl] [nvarchar](100) NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Province]    Script Date: 12/3/2016 10:02:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Province](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Province] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RateLession]    Script Date: 12/3/2016 10:02:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RateLession](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[LessionID] [int] NULL,
	[Point] [int] NULL,
	[Created] [datetime] NULL,
 CONSTRAINT [PK_RateLession] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Report]    Script Date: 12/3/2016 10:02:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[Content] [nvarchar](200) NULL,
	[Created] [datetime] NULL,
	[ReportTypeID] [int] NULL,
 CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReportType]    Script Date: 12/3/2016 10:02:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_ReportType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[School]    Script Date: 12/3/2016 10:02:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[School](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TownID] [int] NULL,
	[SchoolTypeID] [int] NULL,
	[Address] [nvarchar](200) NULL,
	[LevelID] [int] NULL,
 CONSTRAINT [PK_School] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SchoolType]    Script Date: 12/3/2016 10:02:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchoolType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_SchoolType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 12/3/2016 10:02:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[CurrentClass] [int] NULL,
	[ClassName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subject]    Script Date: 12/3/2016 10:02:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubjectClass]    Script Date: 12/3/2016 10:02:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectClass](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectID] [int] NULL,
	[ClassID] [int] NULL,
 CONSTRAINT [PK_SubjectClass] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 12/3/2016 10:02:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[ExperienceYear] [int] NULL,
	[MainSubjectID] [int] NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Town]    Script Date: 12/3/2016 10:02:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Town](
	[ID] [int] NOT NULL,
	[DistrictID] [int] NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Town] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[AppUsers] ON 

INSERT [dbo].[AppUsers] ([Id], [Username], [Password], [Email], [DateCreated], [LastActivityDate], [SecurityStamp]) VALUES (1, N'root', N'c4ca4238a0b923820dcc509a6f75849b', N'root@gmail.com', CAST(N'2016-05-25 10:21:27.900' AS DateTime), CAST(N'2016-05-25 10:21:27.900' AS DateTime), N'1a22727f-1512-4d10-84ad-4433789ed18f')
INSERT [dbo].[AppUsers] ([Id], [Username], [Password], [Email], [DateCreated], [LastActivityDate], [SecurityStamp]) VALUES (2, N'student', N'c4ca4238a0b923820dcc509a6f75849b', N'student@gmail.com', CAST(N'2016-05-25 14:23:08.820' AS DateTime), CAST(N'2016-05-25 14:23:08.820' AS DateTime), N'e228fa43-0e2f-46f7-81e5-83a2dec2c8ac')
INSERT [dbo].[AppUsers] ([Id], [Username], [Password], [Email], [DateCreated], [LastActivityDate], [SecurityStamp]) VALUES (3, N'teacher', N'c4ca4238a0b923820dcc509a6f75849b', N'teacher@gmail.com', CAST(N'2016-05-25 14:23:08.820' AS DateTime), CAST(N'2016-05-25 14:23:08.820' AS DateTime), N'e228fa43-0e2f-46f7-81e5-83a2dec2c8ac')
SET IDENTITY_INSERT [dbo].[AppUsers] OFF
SET IDENTITY_INSERT [dbo].[AspNetRoles] ON 

INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (2, N'Student')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (3, N'Teacher')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (4, N'Client')
SET IDENTITY_INSERT [dbo].[AspNetRoles] OFF
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (1, 1)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (2, 2)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (2, 4)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (3, 3)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (3, 4)
SET IDENTITY_INSERT [dbo].[LevelEducation] ON 

INSERT [dbo].[LevelEducation] ([ID], [Code], [Name]) VALUES (1, N'th', N'Tiểu học')
INSERT [dbo].[LevelEducation] ([ID], [Code], [Name]) VALUES (2, N'thcs', N'Trung học cơ sở')
INSERT [dbo].[LevelEducation] ([ID], [Code], [Name]) VALUES (3, N'thpt', N'Trung học phổ thông')
SET IDENTITY_INSERT [dbo].[LevelEducation] OFF
SET IDENTITY_INSERT [dbo].[Province] ON 

INSERT [dbo].[Province] ([ID], [Name]) VALUES (1, N'Hà Nội')
INSERT [dbo].[Province] ([ID], [Name]) VALUES (2, N'TP HCM')
SET IDENTITY_INSERT [dbo].[Province] OFF
SET IDENTITY_INSERT [dbo].[ReportType] ON 

INSERT [dbo].[ReportType] ([ID], [Code], [Name], [Description], [Status]) VALUES (1, N'report_post', N'Báo cáo bài viết', NULL, 1)
INSERT [dbo].[ReportType] ([ID], [Code], [Name], [Description], [Status]) VALUES (2, N'report_user', N'Báo cáo tài khoản', NULL, 1)
INSERT [dbo].[ReportType] ([ID], [Code], [Name], [Description], [Status]) VALUES (3, N'report_lession', N'Báo cáo bài giảng', NULL, 1)
SET IDENTITY_INSERT [dbo].[ReportType] OFF
SET IDENTITY_INSERT [dbo].[SchoolType] ON 

INSERT [dbo].[SchoolType] ([ID], [Code], [Name], [Description]) VALUES (1, N'chuyen_huyen', N'Trường chuyên cấp huyện', NULL)
INSERT [dbo].[SchoolType] ([ID], [Code], [Name], [Description]) VALUES (2, N'chuyen_tinh', N'Trường chuyên cấp tỉnh/thành phố', NULL)
SET IDENTITY_INSERT [dbo].[SchoolType] OFF
ALTER TABLE [dbo].[AppUsers] ADD  CONSTRAINT [DF_AppUsers_SecurityStamp]  DEFAULT ('') FOR [SecurityStamp]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AppUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AppUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AppUsers]
GO
ALTER TABLE [dbo].[ClassInfo]  WITH CHECK ADD  CONSTRAINT [FK_Class_LevelEducation] FOREIGN KEY([LevelID])
REFERENCES [dbo].[LevelEducation] ([ID])
GO
ALTER TABLE [dbo].[ClassInfo] CHECK CONSTRAINT [FK_Class_LevelEducation]
GO
ALTER TABLE [dbo].[CommentLession]  WITH CHECK ADD  CONSTRAINT [FK_CommentLession_AppUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[AppUsers] ([Id])
GO
ALTER TABLE [dbo].[CommentLession] CHECK CONSTRAINT [FK_CommentLession_AppUsers]
GO
ALTER TABLE [dbo].[CommentLession]  WITH CHECK ADD  CONSTRAINT [FK_CommentLession_Lession] FOREIGN KEY([LessionID])
REFERENCES [dbo].[Lession] ([ID])
GO
ALTER TABLE [dbo].[CommentLession] CHECK CONSTRAINT [FK_CommentLession_Lession]
GO
ALTER TABLE [dbo].[CommentPost]  WITH CHECK ADD  CONSTRAINT [FK_CommentPost_AppUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[AppUsers] ([Id])
GO
ALTER TABLE [dbo].[CommentPost] CHECK CONSTRAINT [FK_CommentPost_AppUsers]
GO
ALTER TABLE [dbo].[CommentPost]  WITH CHECK ADD  CONSTRAINT [FK_CommentPost_Post] FOREIGN KEY([PostID])
REFERENCES [dbo].[Post] ([ID])
GO
ALTER TABLE [dbo].[CommentPost] CHECK CONSTRAINT [FK_CommentPost_Post]
GO
ALTER TABLE [dbo].[District]  WITH CHECK ADD  CONSTRAINT [FK_District_Province] FOREIGN KEY([ProvinceID])
REFERENCES [dbo].[Province] ([ID])
GO
ALTER TABLE [dbo].[District] CHECK CONSTRAINT [FK_District_Province]
GO
ALTER TABLE [dbo].[FileUpload]  WITH CHECK ADD  CONSTRAINT [FK_FileUpload_FileUpload1] FOREIGN KEY([OldVersion])
REFERENCES [dbo].[FileUpload] ([ID])
GO
ALTER TABLE [dbo].[FileUpload] CHECK CONSTRAINT [FK_FileUpload_FileUpload1]
GO
ALTER TABLE [dbo].[FileUpload]  WITH CHECK ADD  CONSTRAINT [FK_FileUpload_Lession] FOREIGN KEY([LessionID])
REFERENCES [dbo].[Lession] ([ID])
GO
ALTER TABLE [dbo].[FileUpload] CHECK CONSTRAINT [FK_FileUpload_Lession]
GO
ALTER TABLE [dbo].[Lession]  WITH CHECK ADD  CONSTRAINT [FK_Lession_Subject] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subject] ([ID])
GO
ALTER TABLE [dbo].[Lession] CHECK CONSTRAINT [FK_Lession_Subject]
GO
ALTER TABLE [dbo].[Lession]  WITH CHECK ADD  CONSTRAINT [FK_Lession_Teacher] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([ID])
GO
ALTER TABLE [dbo].[Lession] CHECK CONSTRAINT [FK_Lession_Teacher]
GO
ALTER TABLE [dbo].[LikePost]  WITH CHECK ADD  CONSTRAINT [FK_LikePost_AppUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[AppUsers] ([Id])
GO
ALTER TABLE [dbo].[LikePost] CHECK CONSTRAINT [FK_LikePost_AppUsers]
GO
ALTER TABLE [dbo].[LikePost]  WITH CHECK ADD  CONSTRAINT [FK_LikePost_Post] FOREIGN KEY([PostID])
REFERENCES [dbo].[Post] ([ID])
GO
ALTER TABLE [dbo].[LikePost] CHECK CONSTRAINT [FK_LikePost_Post]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_AppUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[AppUsers] ([Id])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_AppUsers]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_Category]
GO
ALTER TABLE [dbo].[RateLession]  WITH CHECK ADD  CONSTRAINT [FK_RateLession_AppUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[AppUsers] ([Id])
GO
ALTER TABLE [dbo].[RateLession] CHECK CONSTRAINT [FK_RateLession_AppUsers]
GO
ALTER TABLE [dbo].[RateLession]  WITH CHECK ADD  CONSTRAINT [FK_RateLession_Lession] FOREIGN KEY([LessionID])
REFERENCES [dbo].[Lession] ([ID])
GO
ALTER TABLE [dbo].[RateLession] CHECK CONSTRAINT [FK_RateLession_Lession]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_AppUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[AppUsers] ([Id])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_Report_AppUsers]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_ReportType] FOREIGN KEY([ReportTypeID])
REFERENCES [dbo].[ReportType] ([ID])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_Report_ReportType]
GO
ALTER TABLE [dbo].[School]  WITH CHECK ADD  CONSTRAINT [FK_School_LevelEducation] FOREIGN KEY([LevelID])
REFERENCES [dbo].[LevelEducation] ([ID])
GO
ALTER TABLE [dbo].[School] CHECK CONSTRAINT [FK_School_LevelEducation]
GO
ALTER TABLE [dbo].[School]  WITH CHECK ADD  CONSTRAINT [FK_School_SchoolType] FOREIGN KEY([SchoolTypeID])
REFERENCES [dbo].[SchoolType] ([ID])
GO
ALTER TABLE [dbo].[School] CHECK CONSTRAINT [FK_School_SchoolType]
GO
ALTER TABLE [dbo].[School]  WITH CHECK ADD  CONSTRAINT [FK_School_Town] FOREIGN KEY([TownID])
REFERENCES [dbo].[Town] ([ID])
GO
ALTER TABLE [dbo].[School] CHECK CONSTRAINT [FK_School_Town]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_AppUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[AppUsers] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_AppUsers]
GO
ALTER TABLE [dbo].[SubjectClass]  WITH CHECK ADD  CONSTRAINT [FK_SubjectClass_Class] FOREIGN KEY([ClassID])
REFERENCES [dbo].[ClassInfo] ([ID])
GO
ALTER TABLE [dbo].[SubjectClass] CHECK CONSTRAINT [FK_SubjectClass_Class]
GO
ALTER TABLE [dbo].[SubjectClass]  WITH CHECK ADD  CONSTRAINT [FK_SubjectClass_Subject] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subject] ([ID])
GO
ALTER TABLE [dbo].[SubjectClass] CHECK CONSTRAINT [FK_SubjectClass_Subject]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_AppUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[AppUsers] ([Id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_AppUsers]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Subject] FOREIGN KEY([MainSubjectID])
REFERENCES [dbo].[Subject] ([ID])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Subject]
GO
ALTER TABLE [dbo].[Town]  WITH CHECK ADD  CONSTRAINT [FK_Town_District] FOREIGN KEY([DistrictID])
REFERENCES [dbo].[District] ([ID])
GO
ALTER TABLE [dbo].[Town] CHECK CONSTRAINT [FK_Town_District]
GO
USE [master]
GO
ALTER DATABASE [Education] SET  READ_WRITE 
GO
