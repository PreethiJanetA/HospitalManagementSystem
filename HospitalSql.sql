USE [hospitaldb]
GO
ALTER TABLE [dbo].[Appointment] DROP CONSTRAINT [FK__Appointme__patie__3C69FB99]
GO
ALTER TABLE [dbo].[Appointment] DROP CONSTRAINT [FK__Appointme__docto__3D5E1FD2]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 27-06-2025 19:19:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Patient]') AND type in (N'U'))
DROP TABLE [dbo].[Patient]
GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 27-06-2025 19:19:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Doctor]') AND type in (N'U'))
DROP TABLE [dbo].[Doctor]
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 27-06-2025 19:19:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Appointment]') AND type in (N'U'))
DROP TABLE [dbo].[Appointment]
GO
USE [master]
GO
/****** Object:  Database [hospitaldb]    Script Date: 27-06-2025 19:19:37 ******/
DROP DATABASE [hospitaldb]
GO
/****** Object:  Database [hospitaldb]    Script Date: 27-06-2025 19:19:37 ******/
CREATE DATABASE [hospitaldb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'hospitaldb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\hospitaldb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'hospitaldb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\hospitaldb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [hospitaldb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [hospitaldb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [hospitaldb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [hospitaldb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [hospitaldb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [hospitaldb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [hospitaldb] SET ARITHABORT OFF 
GO
ALTER DATABASE [hospitaldb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [hospitaldb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [hospitaldb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [hospitaldb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [hospitaldb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [hospitaldb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [hospitaldb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [hospitaldb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [hospitaldb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [hospitaldb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [hospitaldb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [hospitaldb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [hospitaldb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [hospitaldb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [hospitaldb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [hospitaldb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [hospitaldb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [hospitaldb] SET RECOVERY FULL 
GO
ALTER DATABASE [hospitaldb] SET  MULTI_USER 
GO
ALTER DATABASE [hospitaldb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [hospitaldb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [hospitaldb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [hospitaldb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [hospitaldb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [hospitaldb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'hospitaldb', N'ON'
GO
ALTER DATABASE [hospitaldb] SET QUERY_STORE = ON
GO
ALTER DATABASE [hospitaldb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [hospitaldb]
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 27-06-2025 19:19:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[appointmentId] [int] IDENTITY(1,1) NOT NULL,
	[patientId] [int] NULL,
	[doctorId] [int] NULL,
	[appointmentDate] [datetime] NULL,
	[description] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[appointmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 27-06-2025 19:19:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor](
	[doctorId] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](50) NULL,
	[lastName] [nvarchar](50) NULL,
	[specialization] [nvarchar](100) NULL,
	[contactNumber] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[doctorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 27-06-2025 19:19:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[patientId] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](50) NULL,
	[lastName] [nvarchar](50) NULL,
	[dateOfBirth] [date] NULL,
	[gender] [nvarchar](10) NULL,
	[contactNumber] [nvarchar](15) NULL,
	[address] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[patientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Appointment] ON 

INSERT [dbo].[Appointment] ([appointmentId], [patientId], [doctorId], [appointmentDate], [description]) VALUES (3, NULL, 3, CAST(N'2025-07-02T11:30:00.000' AS DateTime), N'Child vaccination')
INSERT [dbo].[Appointment] ([appointmentId], [patientId], [doctorId], [appointmentDate], [description]) VALUES (4, NULL, 2, CAST(N'2025-07-03T14:00:00.000' AS DateTime), N'Skin rash consultation')
INSERT [dbo].[Appointment] ([appointmentId], [patientId], [doctorId], [appointmentDate], [description]) VALUES (5, NULL, 4, CAST(N'2025-07-04T09:15:00.000' AS DateTime), N'Neurological assessment')
INSERT [dbo].[Appointment] ([appointmentId], [patientId], [doctorId], [appointmentDate], [description]) VALUES (6, NULL, 5, CAST(N'2025-07-05T16:45:00.000' AS DateTime), N'Knee pain follow-up')
INSERT [dbo].[Appointment] ([appointmentId], [patientId], [doctorId], [appointmentDate], [description]) VALUES (7, 1, 1, CAST(N'2025-07-01T10:00:00.000' AS DateTime), N'Routine check-up')
INSERT [dbo].[Appointment] ([appointmentId], [patientId], [doctorId], [appointmentDate], [description]) VALUES (8, 2, 3, CAST(N'2025-07-02T11:30:00.000' AS DateTime), N'Child vaccination')
INSERT [dbo].[Appointment] ([appointmentId], [patientId], [doctorId], [appointmentDate], [description]) VALUES (9, 3, 2, CAST(N'2025-07-03T14:00:00.000' AS DateTime), N'Skin rash consultation')
INSERT [dbo].[Appointment] ([appointmentId], [patientId], [doctorId], [appointmentDate], [description]) VALUES (10, 4, 4, CAST(N'2025-07-04T09:15:00.000' AS DateTime), N'Neurological assessment')
INSERT [dbo].[Appointment] ([appointmentId], [patientId], [doctorId], [appointmentDate], [description]) VALUES (11, 5, 5, CAST(N'2025-07-05T16:45:00.000' AS DateTime), N'Knee pain follow-up')
INSERT [dbo].[Appointment] ([appointmentId], [patientId], [doctorId], [appointmentDate], [description]) VALUES (13, 1, 2, CAST(N'2025-08-09T00:00:00.000' AS DateTime), N'Fever')
SET IDENTITY_INSERT [dbo].[Appointment] OFF
GO
SET IDENTITY_INSERT [dbo].[Doctor] ON 

INSERT [dbo].[Doctor] ([doctorId], [firstName], [lastName], [specialization], [contactNumber]) VALUES (1, N'Dr. John', N'Doe', N'Cardiology', N'555-1000')
INSERT [dbo].[Doctor] ([doctorId], [firstName], [lastName], [specialization], [contactNumber]) VALUES (2, N'Dr. Emily', N'Clark', N'Dermatology', N'555-2000')
INSERT [dbo].[Doctor] ([doctorId], [firstName], [lastName], [specialization], [contactNumber]) VALUES (3, N'Dr. Michael', N'Lee', N'Pediatrics', N'555-3000')
INSERT [dbo].[Doctor] ([doctorId], [firstName], [lastName], [specialization], [contactNumber]) VALUES (4, N'Dr. Sarah', N'Nguyen', N'Neurology', N'555-4000')
INSERT [dbo].[Doctor] ([doctorId], [firstName], [lastName], [specialization], [contactNumber]) VALUES (5, N'Dr. Robert', N'Patel', N'Orthopedics', N'555-5000')
SET IDENTITY_INSERT [dbo].[Doctor] OFF
GO
SET IDENTITY_INSERT [dbo].[Patient] ON 

INSERT [dbo].[Patient] ([patientId], [firstName], [lastName], [dateOfBirth], [gender], [contactNumber], [address]) VALUES (1, N'Alice', N'Smith', CAST(N'1980-04-12' AS Date), N'F', N'555-0101', N'123 Main St')
INSERT [dbo].[Patient] ([patientId], [firstName], [lastName], [dateOfBirth], [gender], [contactNumber], [address]) VALUES (2, N'Bob', N'Jones', CAST(N'1975-09-30' AS Date), N'M', N'555-0202', N'456 Oak Rd')
INSERT [dbo].[Patient] ([patientId], [firstName], [lastName], [dateOfBirth], [gender], [contactNumber], [address]) VALUES (3, N'Carol', N'Williams', CAST(N'1990-01-05' AS Date), N'F', N'555-0303', N'789 Pine Ave')
INSERT [dbo].[Patient] ([patientId], [firstName], [lastName], [dateOfBirth], [gender], [contactNumber], [address]) VALUES (4, N'David', N'Taylor', CAST(N'2000-07-15' AS Date), N'M', N'555-0404', N'321 Maple Ln')
INSERT [dbo].[Patient] ([patientId], [firstName], [lastName], [dateOfBirth], [gender], [contactNumber], [address]) VALUES (5, N'Eva', N'Brown', CAST(N'1985-11-22' AS Date), N'F', N'555-0505', N'654 Birch Blvd')
SET IDENTITY_INSERT [dbo].[Patient] OFF
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD FOREIGN KEY([doctorId])
REFERENCES [dbo].[Doctor] ([doctorId])
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD FOREIGN KEY([patientId])
REFERENCES [dbo].[Patient] ([patientId])
GO
USE [master]
GO
ALTER DATABASE [hospitaldb] SET  READ_WRITE 
GO
