USE [master]
GO
/****** Object:  Database [Education]    Script Date: 12/6/2016 10:42:05 PM ******/
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
/****** Object:  Table [dbo].[AppUsers]    Script Date: 12/6/2016 10:42:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[DateCreated] [datetime] NULL,
	[LastActivityDate] [datetime] NULL,
	[SecurityStamp] [nvarchar](50) NULL,
	[FullName] [nvarchar](50) NULL,
	[Birthday] [datetime] NULL,
	[Sex] [bit] NULL,
	[ImageUrl] [nvarchar](100) NULL,
	[Description] [nvarchar](200) NULL,
	[Modified] [datetime] NULL,
	[IsActive] [bit] NULL,
	[Address] [nvarchar](200) NULL,
 CONSTRAINT [PK_AppUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/6/2016 10:42:07 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/6/2016 10:42:07 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/6/2016 10:42:07 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/6/2016 10:42:07 PM ******/
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
/****** Object:  Table [dbo].[Category]    Script Date: 12/6/2016 10:42:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
	[CategoryTypeID] [int] NULL,
	[Alias] [nvarchar](100) NULL,
	[Created] [datetime] NULL,
	[Modified] [datetime] NULL,
	[Status] [bit] NULL,
	[ImageUrl] [nvarchar](200) NULL,
	[ForAdminPost] [bit] NULL,
	[IsHighLight] [bit] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClassInfo]    Script Date: 12/6/2016 10:42:07 PM ******/
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
/****** Object:  Table [dbo].[CommentLession]    Script Date: 12/6/2016 10:42:07 PM ******/
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
/****** Object:  Table [dbo].[CommentPost]    Script Date: 12/6/2016 10:42:07 PM ******/
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
/****** Object:  Table [dbo].[District]    Script Date: 12/6/2016 10:42:07 PM ******/
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
/****** Object:  Table [dbo].[Feedback]    Script Date: 12/6/2016 10:42:07 PM ******/
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
	[State] [bit] NULL,
	[ImageUrl] [nvarchar](200) NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FileUpload]    Script Date: 12/6/2016 10:42:07 PM ******/
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
	[OldVersionID] [int] NULL,
	[LessionID] [int] NULL,
 CONSTRAINT [PK_File] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lession]    Script Date: 12/6/2016 10:42:07 PM ******/
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
	[SubjectClassID] [int] NULL,
	[DownloadCount] [int] NULL,
 CONSTRAINT [PK_Lession] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LevelEducation]    Script Date: 12/6/2016 10:42:07 PM ******/
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
/****** Object:  Table [dbo].[LikePost]    Script Date: 12/6/2016 10:42:07 PM ******/
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
/****** Object:  Table [dbo].[Post]    Script Date: 12/6/2016 10:42:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Alias] [nvarchar](50) NULL,
	[CategoryID] [int] NULL,
	[Created] [datetime] NULL,
	[Modified] [datetime] NULL,
	[Status] [bit] NULL,
	[Description] [nvarchar](200) NULL,
	[ImageUrl] [nvarchar](100) NULL,
	[UserID] [int] NULL,
	[Content] [nvarchar](max) NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Province]    Script Date: 12/6/2016 10:42:07 PM ******/
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
/****** Object:  Table [dbo].[RateLession]    Script Date: 12/6/2016 10:42:07 PM ******/
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
/****** Object:  Table [dbo].[Report]    Script Date: 12/6/2016 10:42:07 PM ******/
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
	[State] [bit] NULL,
	[ImageUrl] [nvarchar](200) NULL,
 CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReportType]    Script Date: 12/6/2016 10:42:08 PM ******/
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
/****** Object:  Table [dbo].[School]    Script Date: 12/6/2016 10:42:08 PM ******/
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
	[Status] [bit] NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_School] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SchoolType]    Script Date: 12/6/2016 10:42:08 PM ******/
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
/****** Object:  Table [dbo].[Student]    Script Date: 12/6/2016 10:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[ClassInfoID] [int] NULL,
	[ClassName] [nvarchar](50) NULL,
	[SchoolID] [int] NULL,
	[SchoolName] [nvarchar](100) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subject]    Script Date: 12/6/2016 10:42:08 PM ******/
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
/****** Object:  Table [dbo].[SubjectClass]    Script Date: 12/6/2016 10:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectClass](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectID] [int] NULL,
	[ClassInfoID] [int] NULL,
 CONSTRAINT [PK_SubjectClass] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 12/6/2016 10:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[ExperienceYear] [int] NULL,
	[MainSubjectID] [int] NULL,
	[SchoolID] [int] NULL,
	[SchoolName] [nvarchar](100) NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Town]    Script Date: 12/6/2016 10:42:08 PM ******/
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

INSERT [dbo].[AppUsers] ([Id], [Username], [Password], [Email], [DateCreated], [LastActivityDate], [SecurityStamp], [FullName], [Birthday], [Sex], [ImageUrl], [Description], [Modified], [IsActive], [Address]) VALUES (1, N'root', N'c4ca4238a0b923820dcc509a6f75849b', N'root@gmail.com', CAST(N'2016-05-25 10:21:27.000' AS DateTime), CAST(N'2016-05-25 10:21:27.000' AS DateTime), N'1a22727f-1512-4d10-84ad-4433789ed18f', NULL, NULL, NULL, NULL, NULL, CAST(N'2016-12-06 10:46:43.833' AS DateTime), 0, NULL)
INSERT [dbo].[AppUsers] ([Id], [Username], [Password], [Email], [DateCreated], [LastActivityDate], [SecurityStamp], [FullName], [Birthday], [Sex], [ImageUrl], [Description], [Modified], [IsActive], [Address]) VALUES (2, N'student', N'c4ca4238a0b923820dcc509a6f75849b', N'student@gmail.com', CAST(N'2016-05-25 14:23:08.820' AS DateTime), CAST(N'2016-05-25 14:23:08.820' AS DateTime), N'e228fa43-0e2f-46f7-81e5-83a2dec2c8ac', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[AppUsers] ([Id], [Username], [Password], [Email], [DateCreated], [LastActivityDate], [SecurityStamp], [FullName], [Birthday], [Sex], [ImageUrl], [Description], [Modified], [IsActive], [Address]) VALUES (3, N'teacher', N'', N'teacher@gmail.com', CAST(N'2016-05-25 14:23:08.000' AS DateTime), CAST(N'2016-05-25 14:23:08.000' AS DateTime), N'e228fa43-0e2f-46f7-81e5-83a2dec2c8ac', NULL, NULL, NULL, NULL, NULL, CAST(N'2016-12-05 23:08:18.603' AS DateTime), 1, NULL)
INSERT [dbo].[AppUsers] ([Id], [Username], [Password], [Email], [DateCreated], [LastActivityDate], [SecurityStamp], [FullName], [Birthday], [Sex], [ImageUrl], [Description], [Modified], [IsActive], [Address]) VALUES (5, N'huynhnd', N'c4ca4238a0b923820dcc509a6f75849b', N'huynhnd@gmail.com', CAST(N'2016-12-05 18:32:50.683' AS DateTime), CAST(N'2016-12-05 18:32:50.683' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2016-12-05 18:32:50.683' AS DateTime), 1, NULL)
INSERT [dbo].[AppUsers] ([Id], [Username], [Password], [Email], [DateCreated], [LastActivityDate], [SecurityStamp], [FullName], [Birthday], [Sex], [ImageUrl], [Description], [Modified], [IsActive], [Address]) VALUES (6, N'loctv', N'', N'loctv@gmail.com', CAST(N'2016-12-05 18:34:31.000' AS DateTime), CAST(N'2016-12-05 18:34:31.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2016-12-05 22:41:23.377' AS DateTime), 1, NULL)
INSERT [dbo].[AppUsers] ([Id], [Username], [Password], [Email], [DateCreated], [LastActivityDate], [SecurityStamp], [FullName], [Birthday], [Sex], [ImageUrl], [Description], [Modified], [IsActive], [Address]) VALUES (7, N'client1', N'', N'client@gmail.com', CAST(N'2016-12-05 18:34:51.000' AS DateTime), CAST(N'2016-12-05 18:34:51.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2016-12-05 21:42:43.117' AS DateTime), 1, NULL)
INSERT [dbo].[AppUsers] ([Id], [Username], [Password], [Email], [DateCreated], [LastActivityDate], [SecurityStamp], [FullName], [Birthday], [Sex], [ImageUrl], [Description], [Modified], [IsActive], [Address]) VALUES (8, N'test', N'', N'test@gmail.com', CAST(N'2016-12-05 22:03:56.137' AS DateTime), CAST(N'2016-12-05 22:03:56.137' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2016-12-05 22:03:56.137' AS DateTime), 1, NULL)
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
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (5, 3)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (5, 4)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (6, 3)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (6, 4)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (7, 1)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (8, 1)
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID], [Name], [Description], [CategoryTypeID], [Alias], [Created], [Modified], [Status], [ImageUrl], [ForAdminPost], [IsHighLight]) VALUES (1, N'bài giảng môn toán', N'bài giảng môn toán', 0, N'bai-giang-mon-toan', CAST(N'2016-12-04 18:37:34.987' AS DateTime), CAST(N'2016-12-04 18:37:35.343' AS DateTime), 1, NULL, 1, 1)
INSERT [dbo].[Category] ([ID], [Name], [Description], [CategoryTypeID], [Alias], [Created], [Modified], [Status], [ImageUrl], [ForAdminPost], [IsHighLight]) VALUES (2, N'1234', N'1234', 0, N'1234', CAST(N'2016-12-04 18:45:27.000' AS DateTime), CAST(N'2016-12-04 21:01:13.397' AS DateTime), 0, N'~/Assets/Admin/Upload/Categories/2/2013-05-20 08.45.18.jpg', 1, 1)
INSERT [dbo].[Category] ([ID], [Name], [Description], [CategoryTypeID], [Alias], [Created], [Modified], [Status], [ImageUrl], [ForAdminPost], [IsHighLight]) VALUES (3, N'12345', N'12345', 0, N'12345', CAST(N'2016-12-04 18:47:29.000' AS DateTime), CAST(N'2016-12-06 07:05:21.667' AS DateTime), 1, N'~/Assets/Admin/Upload/Categories/3/2013-05-20 10.22.52.jpg', 1, 0)
INSERT [dbo].[Category] ([ID], [Name], [Description], [CategoryTypeID], [Alias], [Created], [Modified], [Status], [ImageUrl], [ForAdminPost], [IsHighLight]) VALUES (4, N'12345', N'12345', 0, N'123', CAST(N'2016-12-04 18:50:20.223' AS DateTime), CAST(N'2016-12-04 18:50:20.223' AS DateTime), 1, NULL, 0, 0)
INSERT [dbo].[Category] ([ID], [Name], [Description], [CategoryTypeID], [Alias], [Created], [Modified], [Status], [ImageUrl], [ForAdminPost], [IsHighLight]) VALUES (5, N'123456', N'123456', 0, N'123456', CAST(N'2016-12-04 18:58:10.163' AS DateTime), CAST(N'2016-12-04 18:58:10.163' AS DateTime), 1, NULL, 0, 0)
INSERT [dbo].[Category] ([ID], [Name], [Description], [CategoryTypeID], [Alias], [Created], [Modified], [Status], [ImageUrl], [ForAdminPost], [IsHighLight]) VALUES (6, N'123456789', N'123456789', 0, N'123456789', CAST(N'2016-12-04 19:02:16.000' AS DateTime), CAST(N'2016-12-06 06:34:54.610' AS DateTime), 1, N'~/Assets/Admin/Upload/Categories/6/2013-05-20 08.45.18.jpg', 1, 1)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[ClassInfo] ON 

INSERT [dbo].[ClassInfo] ([ID], [ClassName], [LevelID], [Status]) VALUES (1, N'Lớp 1', 1, 1)
INSERT [dbo].[ClassInfo] ([ID], [ClassName], [LevelID], [Status]) VALUES (2, N'Lớp 2', 1, 1)
INSERT [dbo].[ClassInfo] ([ID], [ClassName], [LevelID], [Status]) VALUES (3, N'Lớp 3', 1, 1)
INSERT [dbo].[ClassInfo] ([ID], [ClassName], [LevelID], [Status]) VALUES (4, N'Lớp 4', 1, 1)
INSERT [dbo].[ClassInfo] ([ID], [ClassName], [LevelID], [Status]) VALUES (5, N'Lớp 5', 1, 1)
INSERT [dbo].[ClassInfo] ([ID], [ClassName], [LevelID], [Status]) VALUES (6, N'Lớp 6', 2, 1)
INSERT [dbo].[ClassInfo] ([ID], [ClassName], [LevelID], [Status]) VALUES (7, N'Lớp 7', 2, 1)
INSERT [dbo].[ClassInfo] ([ID], [ClassName], [LevelID], [Status]) VALUES (8, N'Lớp 8', 2, 1)
INSERT [dbo].[ClassInfo] ([ID], [ClassName], [LevelID], [Status]) VALUES (9, N'Lớp 9', 2, 1)
INSERT [dbo].[ClassInfo] ([ID], [ClassName], [LevelID], [Status]) VALUES (10, N'Lớp 10', 3, 1)
INSERT [dbo].[ClassInfo] ([ID], [ClassName], [LevelID], [Status]) VALUES (11, N'Lớp 11', 3, 1)
INSERT [dbo].[ClassInfo] ([ID], [ClassName], [LevelID], [Status]) VALUES (12, N'Lớp 12', 3, 1)
SET IDENTITY_INSERT [dbo].[ClassInfo] OFF
SET IDENTITY_INSERT [dbo].[Feedback] ON 

INSERT [dbo].[Feedback] ([ID], [Created], [Content], [Name], [Email], [State], [ImageUrl]) VALUES (2, CAST(N'2016-05-25 14:23:08.000' AS DateTime), N'Hệ thống giao diện cần chỉnh sửa ở trang Home cho đẹp hơn', N'Yêu cầu sửa trang chủ', N'student@gmail.com', 1, NULL)
INSERT [dbo].[Feedback] ([ID], [Created], [Content], [Name], [Email], [State], [ImageUrl]) VALUES (3, CAST(N'2016-07-10 14:23:08.820' AS DateTime), N'Cần update phần tạo bài giảng', N'Yêu cầu sửa giao diện', N'teacher@gmail.com', 0, NULL)
SET IDENTITY_INSERT [dbo].[Feedback] OFF
SET IDENTITY_INSERT [dbo].[Lession] ON 

INSERT [dbo].[Lession] ([ID], [Name], [Description], [Created], [Modified], [Alias], [Status], [ImageUrl], [TeacherID], [RateAverage], [SubjectClassID], [DownloadCount]) VALUES (3, N'bai giang 2', N'bai giang 2', CAST(N'2016-12-04 23:35:34.000' AS DateTime), CAST(N'2016-12-06 10:14:13.287' AS DateTime), N'bai-giang-2', 1, NULL, 2, 0, 3, 0)
INSERT [dbo].[Lession] ([ID], [Name], [Description], [Created], [Modified], [Alias], [Status], [ImageUrl], [TeacherID], [RateAverage], [SubjectClassID], [DownloadCount]) VALUES (4, N'bai giang mon tona', N'bài giảng môn toán', CAST(N'2016-12-04 23:35:34.000' AS DateTime), CAST(N'2016-12-04 23:35:34.000' AS DateTime), N'bai-giang-mon-toan', 0, NULL, 2, 0, 2, 0)
SET IDENTITY_INSERT [dbo].[Lession] OFF
SET IDENTITY_INSERT [dbo].[LevelEducation] ON 

INSERT [dbo].[LevelEducation] ([ID], [Code], [Name]) VALUES (1, N'th', N'Tiểu học')
INSERT [dbo].[LevelEducation] ([ID], [Code], [Name]) VALUES (2, N'thcs', N'Trung học cơ sở')
INSERT [dbo].[LevelEducation] ([ID], [Code], [Name]) VALUES (3, N'thpt', N'Trung học phổ thông')
SET IDENTITY_INSERT [dbo].[LevelEducation] OFF
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([ID], [Name], [Alias], [CategoryID], [Created], [Modified], [Status], [Description], [ImageUrl], [UserID], [Content]) VALUES (3, N'1234', N'1234', 1, CAST(N'2016-12-04 23:20:18.000' AS DateTime), CAST(N'2016-12-05 22:43:17.083' AS DateTime), 1, N'1234', N'~/Assets/Admin/Upload/Posts/3/2013-05-20 08.45.18.jpg', 1, NULL)
INSERT [dbo].[Post] ([ID], [Name], [Alias], [CategoryID], [Created], [Modified], [Status], [Description], [ImageUrl], [UserID], [Content]) VALUES (4, N'Hướng dẫn sử dụng diễn đàn', N'huong-dan-su-dung-dien-dan', 6, CAST(N'2016-12-04 23:35:34.000' AS DateTime), CAST(N'2016-12-06 21:00:00.033' AS DateTime), 1, N'toan1', N'~/Assets/Admin/Upload/Posts/4/2013-05-22 08.30.29.jpg', 1, N'<p>dsfdasgdd</p>

<p>fdsa</p>

<p>dsa</p>

<p>fds</p>
')
INSERT [dbo].[Post] ([ID], [Name], [Alias], [CategoryID], [Created], [Modified], [Status], [Description], [ImageUrl], [UserID], [Content]) VALUES (7, N'123456', N'123456', 1, CAST(N'2016-12-06 16:36:47.000' AS DateTime), CAST(N'2016-12-06 20:15:58.473' AS DateTime), 1, N'123456', N'~/Assets/Admin/Upload/Posts/7/2013-05-22 10.04.52.jpg', 1, N'<p>123456</p>
')
SET IDENTITY_INSERT [dbo].[Post] OFF
SET IDENTITY_INSERT [dbo].[Province] ON 

INSERT [dbo].[Province] ([ID], [Name]) VALUES (1, N'Hà Nội')
INSERT [dbo].[Province] ([ID], [Name]) VALUES (2, N'TP HCM')
SET IDENTITY_INSERT [dbo].[Province] OFF
SET IDENTITY_INSERT [dbo].[Report] ON 

INSERT [dbo].[Report] ([ID], [UserID], [Content], [Created], [ReportTypeID], [State], [ImageUrl]) VALUES (1, 2, N'báo cáo người dùng đăng ảnh không hợp nội dung', CAST(N'2016-05-25 10:21:27.000' AS DateTime), 2, 1, NULL)
INSERT [dbo].[Report] ([ID], [UserID], [Content], [Created], [ReportTypeID], [State], [ImageUrl]) VALUES (2, 3, N'báo cáo bài viết vi phạm quy định', CAST(N'2016-05-25 10:21:27.900' AS DateTime), 1, 0, NULL)
SET IDENTITY_INSERT [dbo].[Report] OFF
SET IDENTITY_INSERT [dbo].[ReportType] ON 

INSERT [dbo].[ReportType] ([ID], [Code], [Name], [Description], [Status]) VALUES (1, N'report_post', N'Báo cáo bài viết', NULL, 1)
INSERT [dbo].[ReportType] ([ID], [Code], [Name], [Description], [Status]) VALUES (2, N'report_user', N'Báo cáo tài khoản', NULL, 1)
INSERT [dbo].[ReportType] ([ID], [Code], [Name], [Description], [Status]) VALUES (3, N'report_lession', N'Báo cáo bài giảng', NULL, 1)
SET IDENTITY_INSERT [dbo].[ReportType] OFF
SET IDENTITY_INSERT [dbo].[School] ON 

INSERT [dbo].[School] ([ID], [TownID], [SchoolTypeID], [Address], [LevelID], [Status], [Name]) VALUES (1, NULL, 1, N'Phú Lâm, Tiên Du, Bắc Ninh', 1, 1, N'TH Phú Lâm 1')
INSERT [dbo].[School] ([ID], [TownID], [SchoolTypeID], [Address], [LevelID], [Status], [Name]) VALUES (2, NULL, 2, N'Hoài Đức, Hà Nội', 2, 1, N'THCS Tiên Du')
INSERT [dbo].[School] ([ID], [TownID], [SchoolTypeID], [Address], [LevelID], [Status], [Name]) VALUES (3, NULL, 2, N'Hà Nội', 3, 1, N'THPT CSP')
INSERT [dbo].[School] ([ID], [TownID], [SchoolTypeID], [Address], [LevelID], [Status], [Name]) VALUES (4, NULL, 3, N'TP HCM 1', 1, 0, N'THPT Cần Giuộc 1')
INSERT [dbo].[School] ([ID], [TownID], [SchoolTypeID], [Address], [LevelID], [Status], [Name]) VALUES (5, NULL, NULL, N'test', 1, 0, N'test')
SET IDENTITY_INSERT [dbo].[School] OFF
SET IDENTITY_INSERT [dbo].[SchoolType] ON 

INSERT [dbo].[SchoolType] ([ID], [Code], [Name], [Description]) VALUES (1, N'chuyen_huyen', N'Trường chuyên cấp huyện', NULL)
INSERT [dbo].[SchoolType] ([ID], [Code], [Name], [Description]) VALUES (2, N'chuyen_tinh', N'Trường chuyên cấp tỉnh/thành phố', NULL)
INSERT [dbo].[SchoolType] ([ID], [Code], [Name], [Description]) VALUES (3, N'binh_thuong', N'Trường bình thường', NULL)
SET IDENTITY_INSERT [dbo].[SchoolType] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([ID], [UserID], [ClassInfoID], [ClassName], [SchoolID], [SchoolName]) VALUES (1, 2, 1, N'A', NULL, N'TH Tiên Lãng')
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[Subject] ON 

INSERT [dbo].[Subject] ([ID], [SubjectName]) VALUES (1, N'Toán')
INSERT [dbo].[Subject] ([ID], [SubjectName]) VALUES (2, N'Văn')
INSERT [dbo].[Subject] ([ID], [SubjectName]) VALUES (3, N'Anh')
INSERT [dbo].[Subject] ([ID], [SubjectName]) VALUES (4, N'Lý')
INSERT [dbo].[Subject] ([ID], [SubjectName]) VALUES (5, N'Hóa')
INSERT [dbo].[Subject] ([ID], [SubjectName]) VALUES (6, N'Sinh')
INSERT [dbo].[Subject] ([ID], [SubjectName]) VALUES (7, N'Sử')
INSERT [dbo].[Subject] ([ID], [SubjectName]) VALUES (8, N'Địa')
INSERT [dbo].[Subject] ([ID], [SubjectName]) VALUES (9, N'Khoa học')
SET IDENTITY_INSERT [dbo].[Subject] OFF
SET IDENTITY_INSERT [dbo].[SubjectClass] ON 

INSERT [dbo].[SubjectClass] ([ID], [SubjectID], [ClassInfoID]) VALUES (1, 1, 1)
INSERT [dbo].[SubjectClass] ([ID], [SubjectID], [ClassInfoID]) VALUES (2, 2, 1)
INSERT [dbo].[SubjectClass] ([ID], [SubjectID], [ClassInfoID]) VALUES (3, 1, 2)
INSERT [dbo].[SubjectClass] ([ID], [SubjectID], [ClassInfoID]) VALUES (4, 2, 2)
SET IDENTITY_INSERT [dbo].[SubjectClass] OFF
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([ID], [UserID], [ExperienceYear], [MainSubjectID], [SchoolID], [SchoolName]) VALUES (2, 3, 1, 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[Teacher] OFF
ALTER TABLE [dbo].[AppUsers] ADD  CONSTRAINT [DF_AppUsers_SecurityStamp]  DEFAULT ('') FOR [SecurityStamp]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AppUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AppUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AppUsers]
GO
ALTER TABLE [dbo].[ClassInfo]  WITH CHECK ADD  CONSTRAINT [FK_ClassInfo_LevelEducation] FOREIGN KEY([LevelID])
REFERENCES [dbo].[LevelEducation] ([ID])
GO
ALTER TABLE [dbo].[ClassInfo] CHECK CONSTRAINT [FK_ClassInfo_LevelEducation]
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
ALTER TABLE [dbo].[FileUpload]  WITH CHECK ADD  CONSTRAINT [FK_FileUpload_FileUpload1] FOREIGN KEY([OldVersionID])
REFERENCES [dbo].[FileUpload] ([ID])
GO
ALTER TABLE [dbo].[FileUpload] CHECK CONSTRAINT [FK_FileUpload_FileUpload1]
GO
ALTER TABLE [dbo].[FileUpload]  WITH CHECK ADD  CONSTRAINT [FK_FileUpload_Lession] FOREIGN KEY([LessionID])
REFERENCES [dbo].[Lession] ([ID])
GO
ALTER TABLE [dbo].[FileUpload] CHECK CONSTRAINT [FK_FileUpload_Lession]
GO
ALTER TABLE [dbo].[Lession]  WITH CHECK ADD  CONSTRAINT [FK_Lession_SubjectClass] FOREIGN KEY([SubjectClassID])
REFERENCES [dbo].[SubjectClass] ([ID])
GO
ALTER TABLE [dbo].[Lession] CHECK CONSTRAINT [FK_Lession_SubjectClass]
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
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_ClassInfo] FOREIGN KEY([ClassInfoID])
REFERENCES [dbo].[ClassInfo] ([ID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_ClassInfo]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_School] FOREIGN KEY([SchoolID])
REFERENCES [dbo].[School] ([ID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_School]
GO
ALTER TABLE [dbo].[SubjectClass]  WITH CHECK ADD  CONSTRAINT [FK_SubjectClass_ClassInfo] FOREIGN KEY([ClassInfoID])
REFERENCES [dbo].[ClassInfo] ([ID])
GO
ALTER TABLE [dbo].[SubjectClass] CHECK CONSTRAINT [FK_SubjectClass_ClassInfo]
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
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_School] FOREIGN KEY([SchoolID])
REFERENCES [dbo].[School] ([ID])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_School]
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
