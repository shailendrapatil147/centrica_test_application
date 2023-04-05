
--TRUNCATE TABLE [dbo].[UserRole]
--ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_UserRole_User_UserId]
--ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_UserRole_City_CityId]
--ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_UserRole_Role_RoleId]
--DROP TABLE [dbo].[UserRole]
--DROP TABLE [dbo].[User]
--DROP TABLE [dbo].[City]
--DROP TABLE [dbo].[Role]

CREATE TABLE [dbo].[Role]
(
	[Id]										[INT]				NOT NULL	CONSTRAINT [PK_Role] PRIMARY KEY IDENTITY,
	[Name]										[VARCHAR](100)		NOT NULL	CONSTRAINT [UK_Role_Name] UNIQUE,
	[CreateDateUTC]								[DATETIME2]			NOT NULL	CONSTRAINT [DF_Role_CreateDateUTC] DEFAULT GETUTCDATE(),
	[UpdateDateUTC]								[DATETIME2]			NOT NULL	CONSTRAINT [DF_Role_UpdateDateUTC] DEFAULT GETUTCDATE(),
	[Description]								[VARCHAR](1000)		NULL,	
);
GO

CREATE TABLE [dbo].[City]
(
	[Id]										[INT]				NOT NULL	CONSTRAINT [PK_City] PRIMARY KEY IDENTITY,
	[Name]										[VARCHAR](100)		NOT NULL	CONSTRAINT [UK_City_Name] UNIQUE,
	[CreateDateUTC]								[DATETIME2]			NOT NULL	CONSTRAINT [DF_City_CreateDateUTC] DEFAULT GETUTCDATE(),
	[UpdateDateUTC]								[DATETIME2]			NOT NULL	CONSTRAINT [DF_City_UpdateDateUTC] DEFAULT GETUTCDATE(),
	[Description]								[VARCHAR](1000)		NULL	
);
GO

CREATE TABLE [dbo].[User]
(
	[Id]										[INT]				NOT NULL	CONSTRAINT [PK_User] PRIMARY KEY IDENTITY,
	[Name]										[VARCHAR](1000)		NOT NULL,
	[CreateDateUTC]								[DATETIME2]			NOT NULL	CONSTRAINT [DF_User_CreateDateUTC] DEFAULT GETUTCDATE(),
	[UpdateDateUTC]								[DATETIME2]			NOT NULL	CONSTRAINT [DF_User_UpdateDateUTC] DEFAULT GETUTCDATE()
);
GO

--drop table Store
--drop PROCEDURE [dbo].[spStore_GetAllByCityId]

CREATE TABLE [dbo].[Store]
(
	[Id]										[INT]				NOT NULL	CONSTRAINT [PK_Store] PRIMARY KEY IDENTITY,
	[Name]										[VARCHAR](1000)		NOT NULL,
	[Description]								[VARCHAR](1000)		NULL,
	[CityId]									INT					NOT NULL	CONSTRAINT [FK_Store_City_CityId] FOREIGN KEY ([CityId]) REFERENCES [dbo].[City]([Id]),
	[CreateDateUTC]								[DATETIME2]			NOT NULL	CONSTRAINT [DF_Store_CreateDateUTC] DEFAULT GETUTCDATE(),
	[UpdateDateUTC]								[DATETIME2]			NOT NULL	CONSTRAINT [DF_Store_UpdateDateUTC] DEFAULT GETUTCDATE()
);
GO

CREATE TABLE [dbo].[UserRole]
(
	[Id]										[INT]				NOT NULL	CONSTRAINT [PK_UserRole] PRIMARY KEY IDENTITY,
	[CreateDateUTC]								[DATETIME2]			NOT NULL	CONSTRAINT [DF_UserRole_CreateDateUTC] DEFAULT GETUTCDATE(),
	[UpdateDateUTC]								[DATETIME2]			NOT NULL	CONSTRAINT [DF_UserRole_UpdateDateUTC] DEFAULT GETUTCDATE(),
	[UserId]									[INT]				NOT NULL	CONSTRAINT [FK_UserRole_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User]([Id]),
	[CityId]									[INT]				NOT NULL	CONSTRAINT [FK_UserRole_City_CityId] FOREIGN KEY ([CityId]) REFERENCES [dbo].[City]([Id]),
	[RoleId]									[INT]				NOT NULL	CONSTRAINT [FK_UserRole_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role]([Id]),
);
GO