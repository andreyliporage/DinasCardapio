CREATE DATABASE [Dinas]
GO

USE [Dinas]
GO

CREATE TABLE [Product](
    [Id] UNIQUEIDENTIFIER PRIMARY KEY,
    [Name] NVARCHAR(30) NOT NULL,
    [Price] DECIMAL NOT NULL,
    [Url] NVARCHAR(255) NOT NULL,
    [Type] VARCHAR(10) NOT NULL,
    [Size] VARCHAR(10),
)