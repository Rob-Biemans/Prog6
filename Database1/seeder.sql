USE [Tamagotchi]
GO

SET IDENTITY_INSERT [dbo].[Tamagochis] ON
GO

INSERT INTO [dbo].[Tamagochis]
           ([Id]
           ,[Name]
		   ,[Age]
		   ,[Currency]
		   ,[Level]
		   ,[Health]
		   ,[Hapinness]
		   ,[Alive])
     VALUES
           (1,'Test 1', 0, 100.00, 0, 100, 100, 1)
GO

INSERT INTO [dbo].[Tamagochis]
           ([Id]
           ,[Name]
		   ,[Age]
		   ,[Currency]
		   ,[Level]
		   ,[Health]
		   ,[Hapinness]
		   ,[Alive])
     VALUES
           (2,'Test 2', 0, 100.00, 0, 100, 100, 1)
GO

INSERT INTO [dbo].[Tamagochis]
           ([Id]
           ,[Name]
		   ,[Age]
		   ,[Currency]
		   ,[Level]
		   ,[Health]
		   ,[Hapinness]
		   ,[Alive])
     VALUES
           (3,'Test 3', 0, 100.00, 0, 100, 100, 1)
GO

INSERT INTO [dbo].[Tamagochis]
           ([Id]
           ,[Name]
		   ,[Age]
		   ,[Currency]
		   ,[Level]
		   ,[Health]
		   ,[Hapinness]
		   ,[Alive])
     VALUES
           (4,'Test 4', 0, 100.00, 0, 100, 100, 1)
GO

SET IDENTITY_INSERT [dbo].[Tamagochis] OFF
GO

USE [Tamagotchi]
GO

SET IDENTITY_INSERT [dbo].[Hotelrooms] ON
GO

INSERT INTO [dbo].[Hotelrooms]
           ([Id]
           ,[Beds]
		   ,[Type]
		   ,[Price])
     VALUES
           (1, 2, 'REST', 10)
GO

INSERT INTO [dbo].[Hotelrooms]
           ([Id]
           ,[Beds]
		   ,[Type]
		   ,[Price])
     VALUES
           (2, 3, 'GAME', 20)
GO

INSERT INTO [dbo].[Hotelrooms]
           ([Id]
           ,[Beds]
		   ,[Type]
		   ,[Price])
     VALUES
           (3, 5, 'WORK', 0)
GO

INSERT INTO [dbo].[Hotelrooms]
           ([Id]
           ,[Beds]
		   ,[Type]
		   ,[Price])
     VALUES
           (4, 2, 'FIGHT', 0)
GO

INSERT INTO [dbo].[Hotelrooms]
           ([Id]
           ,[Beds]
		   ,[Type]
		   ,[Price])
     VALUES
           (5, 2, 'MISC', 66)
GO

SET IDENTITY_INSERT [dbo].[Hotelrooms] OFF
GO