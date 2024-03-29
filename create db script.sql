IF NOT EXISTS
  (SELECT *
   FROM sys.databases
   WHERE name = 'CrudApp') BEGIN
CREATE DATABASE [CrudApp] END GO USE [CrudApp] GO USE [CrudApp] GO /****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/8/2021 10:43:23 AM ******/
SET ANSI_NULLS ON GO
SET QUOTED_IDENTIFIER ON GO
CREATE TABLE [dbo].[__EFMigrationsHistory]([MigrationId] [nvarchar](150) NOT NULL,
                                                                         [ProductVersion] [nvarchar](32) NOT NULL,
                                                                                                         CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED ([MigrationId] ASC)WITH (PAD_INDEX = OFF,
                                                                                                                                                                                                          STATISTICS_NORECOMPUTE = OFF,
                                                                                                                                                                                                                                   IGNORE_DUP_KEY = OFF,
                                                                                                                                                                                                                                                    ALLOW_ROW_LOCKS = ON,
                                                                                                                                                                                                                                                                      ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] GO /****** Object:  Table [dbo].[Inventories]    Script Date: 5/8/2021 10:43:23 AM ******/
SET ANSI_NULLS ON GO
SET QUOTED_IDENTIFIER ON GO
CREATE TABLE [dbo].[Inventories]([Id] [uniqueidentifier] NOT NULL,
                                                         [Name] [nvarchar](MAX) NOT NULL,
                                                                                [Price] [decimal](18, 4) NULL,
                                                                                                         [Description] [nvarchar](MAX) NULL,
                                                                                                                                       [CreatedOn] [datetime2](7) NOT NULL,
                                                                                                                                                                  CONSTRAINT [PK_Inventories] PRIMARY KEY CLUSTERED ([Id] ASC)WITH (PAD_INDEX = OFF,
                                                                                                                                                                                                                                                STATISTICS_NORECOMPUTE = OFF,
                                                                                                                                                                                                                                                                         IGNORE_DUP_KEY = OFF,
                                                                                                                                                                                                                                                                                          ALLOW_ROW_LOCKS = ON,
                                                                                                                                                                                                                                                                                                            ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY] GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId],
                                      [ProductVersion])
VALUES (N'20210507090429_InitialCreate', N'5.0.5') GO INSERT [dbo].[Inventories] ([Id], [Name], [Price], [Description], [CreatedOn]) VALUES (N'6a26536e-cba6-4c36-a717-255dfe91c67c', N'Internet', CAST(25001.0000 AS Decimal(18, 4)), N'Telenor monthly', CAST(N'2021-05-08T04:49:52.4517211' AS DateTime2)) INSERT [dbo].[Inventories] ([Id], [Name], [Price], [Description], [CreatedOn]) VALUES (N'8c2af2f2-ac2b-4df9-ace3-390a8c8c7931', N'Mobile pckage', CAST(300.0000 AS Decimal(18, 4)), N'Monthly Telenor package', CAST(N'2021-05-08T04:34:57.6154596' AS DateTime2)) GO USE [master] GO
ALTER DATABASE [CrudApp]
SET READ_WRITE GO