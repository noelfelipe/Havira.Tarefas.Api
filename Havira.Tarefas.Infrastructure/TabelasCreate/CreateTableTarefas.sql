IF NOT EXISTS (
    SELECT [name]
    FROM sys.databases
    WHERE [name] = N'Tarefas'
)
BEGIN
    CREATE DATABASE [Tarefas];
END
GO

USE [Tarefas];
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuarios]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Usuarios] (
        Id UNIQUEIDENTIFIER PRIMARY KEY,
        Email NVARCHAR(200) NOT NULL UNIQUE,
        Password NVARCHAR(200) NOT NULL
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Todos]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Todos] (
        Id UNIQUEIDENTIFIER PRIMARY KEY,
        Title NVARCHAR(200) NOT NULL,
        Description NVARCHAR(MAX) NULL,
        CreationDate DATETIME2 NOT NULL,
        CompletionDate DATETIME2 NULL,
        UserId UNIQUEIDENTIFIER NOT NULL,
        FOREIGN KEY (UserId) REFERENCES [dbo].[Usuarios](Id)
    );
END
GO
