USE [NZWalksDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 17/11/2022 16:46:13 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Regions]    Script Date: 17/11/2022 16:46:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regions](
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Area] [float] NOT NULL,
	[lat] [float] NOT NULL,
	[Long] [float] NOT NULL,
	[Population] [bigint] NOT NULL,
 CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WalkDifficulties]    Script Date: 17/11/2022 16:46:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WalkDifficulties](
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_WalkDifficulties] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Walks]    Script Date: 17/11/2022 16:46:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Walks](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[length] [float] NOT NULL,
	[RegionId] [uniqueidentifier] NOT NULL,
	[WalkDifficultyId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Walks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221115142912_InitialMigration', N'6.0.0')
GO
INSERT [dbo].[Regions] ([Id], [Code], [Name], [Area], [lat], [Long], [Population]) VALUES (N'79e9872d-5a2f-413e-ac36-511036ccd3d4', N'WAIK', N'Waikato Region', 8971, -37.5144584, 174.5405128, 496700)
INSERT [dbo].[Regions] ([Id], [Code], [Name], [Area], [lat], [Long], [Population]) VALUES (N'b950ddf5-e9ad-47ff-9d2a-57259014fae6', N'NRTHL', N'Northland Region', 13789, -35.3708304, 172.5717825, 194600)
INSERT [dbo].[Regions] ([Id], [Code], [Name], [Area], [lat], [Long], [Population]) VALUES (N'907f54ba-2142-4719-aef9-6230c23bd7de', N'AUCK', N'Auckland Region', 4894, -36.5253207, 173.7785704, 1718982)
GO
INSERT [dbo].[WalkDifficulties] ([Id], [Code]) VALUES (N'30f96ef9-7b45-42f7-9fab-05a70e7fc394', N'Hard')
INSERT [dbo].[WalkDifficulties] ([Id], [Code]) VALUES (N'a1066e97-c7c8-4aee-905b-61bb31d82bfb', N'Medium')
INSERT [dbo].[WalkDifficulties] ([Id], [Code]) VALUES (N'4c2b95e0-2022-4a8f-b537-eb3a32786b06', N'Easy')
GO
INSERT [dbo].[Walks] ([Id], [Name], [length], [RegionId], [WalkDifficultyId]) VALUES (N'79e9872d-5a2f-413e-ac36-511036ccd3d4', N'One Tree Hill Walk', 3.5, N'907f54ba-2142-4719-aef9-6230c23bd7de', N'4c2b95e0-2022-4a8f-b537-eb3a32786b06')
INSERT [dbo].[Walks] ([Id], [Name], [length], [RegionId], [WalkDifficultyId]) VALUES (N'b950ddf5-e9ad-47ff-9d2a-57259014fae6', N'Waiotemarama Loop Track', 1.5, N'b950ddf5-e9ad-47ff-9d2a-57259014fae6', N'a1066e97-c7c8-4aee-905b-61bb31d82bfb')
INSERT [dbo].[Walks] ([Id], [Name], [length], [RegionId], [WalkDifficultyId]) VALUES (N'907f54ba-2142-4719-aef9-6230c23bd7de', N'Mt Eden Volcano Walk', 2, N'907f54ba-2142-4719-aef9-6230c23bd7de', N'4c2b95e0-2022-4a8f-b537-eb3a32786b06')
INSERT [dbo].[Walks] ([Id], [Name], [length], [RegionId], [WalkDifficultyId]) VALUES (N'68c2ab66-c5eb-40b6-81e0-954456d06bba', N'Lonely Bay', 1.2, N'79e9872d-5a2f-413e-ac36-511036ccd3d4', N'4c2b95e0-2022-4a8f-b537-eb3a32786b06')
GO
ALTER TABLE [dbo].[Walks]  WITH CHECK ADD  CONSTRAINT [FK_Walks_Regions_RegionId] FOREIGN KEY([RegionId])
REFERENCES [dbo].[Regions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Walks] CHECK CONSTRAINT [FK_Walks_Regions_RegionId]
GO
