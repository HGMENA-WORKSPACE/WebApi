CREATE DATABASE [Test];
GO

USE [Test]
GO

/******  Schema [test]   ******/
CREATE SCHEMA [test]
GO

/******  Table [test].[Users]    ******/
CREATE TABLE [test].[RolTask] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [Guid]      NVARCHAR (36)       NOT NULL,
    [Type]      NVARCHAR (1)        NOT NULL,
    [DescType]  NVARCHAR (7)        NOT NULL,
    [CreatedBy] NVARCHAR (28)       NULL,
    [CreatedAt] DATETIME2 (7)       NULL,
    [ChangedBy] NVARCHAR (28)       NULL,
    [ChangedAt] DATETIME2 (7)       NULL,
    CONSTRAINT [PK_RolTask] PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Type] ASC),
    UNIQUE NONCLUSTERED ([Guid] ASC)
);

/******  Table [test].[Users]    ******/
CREATE TABLE [test].[Users] (
    [Id]        INT            IDENTITY (1, 1)  NOT NULL,
    [Guid]      NVARCHAR (36)                   NOT NULL,
    [Name]      NVARCHAR (28)                   NOT NULL,
    [SureName]  NVARCHAR (28)                   NOT NULL,
    [Mail]      NVARCHAR (28)                   NOT NULL,
    [BirthDay]  DATETIME2 (7)                   NULL,
    [TelePhone] NVARCHAR (9)                    NULL,
    [UserName]  NVARCHAR (28)                   NOT NULL,
    [PassWord]  NVARCHAR (512)                  NOT NULL,
    [CreatedBy] NVARCHAR (28)                   NULL,
    [CreatedAt] DATETIME2 (7)                   NULL,
    [ChangedBy] NVARCHAR (28)                   NULL,
    [ChangedAt] DATETIME2 (7)                   NULL,
    [IdRolTask] INT                              NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_Key] UNIQUE NONCLUSTERED ([Guid] ASC, [TelePhone] ASC, [UserName] ASC),
    UNIQUE NONCLUSTERED ([UserName] ASC),
    UNIQUE NONCLUSTERED ([TelePhone] ASC),
    UNIQUE NONCLUSTERED ([Mail] ASC),
    UNIQUE NONCLUSTERED ([Guid] ASC),
    CONSTRAINT [FK_RolTask] FOREIGN KEY ([IdRolTask]) REFERENCES [test].[RolTask] ([Id])
);
