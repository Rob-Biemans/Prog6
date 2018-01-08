
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/03/2018 17:03:07
-- Generated from EDMX file: E:\Rob\Dropbox\Prive van rob\School\HBO\2e leerjaar\PROG6\Prog6\Tamagotchi.Domein\Models\Tamagotchi.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Tamagotchi];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[fk_hotelroom_tamagotchi]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Booking] DROP CONSTRAINT [fk_hotelroom_tamagotchi];
GO
IF OBJECT_ID(N'[dbo].[fk_tamagotchi_hotelroom]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Booking] DROP CONSTRAINT [fk_tamagotchi_hotelroom];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Booking]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Booking];
GO
IF OBJECT_ID(N'[dbo].[Hotelroom]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Hotelroom];
GO
IF OBJECT_ID(N'[dbo].[Tamagochi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tamagochi];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Bookings'
CREATE TABLE [dbo].[Bookings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Start] datetime  NOT NULL,
    [End] datetime  NULL,
    [TamagotchiId] int  NOT NULL,
    [HotelroomId] int  NOT NULL
);
GO

-- Creating table 'Hotelrooms'
CREATE TABLE [dbo].[Hotelrooms] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Beds] tinyint  NOT NULL,
    [Type] varchar(50)  NOT NULL,
    [Price] decimal(10,2)  NOT NULL
);
GO

-- Creating table 'Tamagochis'
CREATE TABLE [dbo].[Tamagochis] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(255)  NOT NULL,
    [Age] int  NOT NULL,
    [Currency] decimal(11,2)  NULL,
    [Level] int  NOT NULL,
    [Health] int  NOT NULL,
    [Hapinness] tinyint  NOT NULL,
    [Alive] tinyint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [PK_Bookings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Hotelrooms'
ALTER TABLE [dbo].[Hotelrooms]
ADD CONSTRAINT [PK_Hotelrooms]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tamagochis'
ALTER TABLE [dbo].[Tamagochis]
ADD CONSTRAINT [PK_Tamagochis]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [HotelroomId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [fk_hotelroom_tamagotchi]
    FOREIGN KEY ([HotelroomId])
    REFERENCES [dbo].[Hotelrooms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_hotelroom_tamagotchi'
CREATE INDEX [IX_fk_hotelroom_tamagotchi]
ON [dbo].[Bookings]
    ([HotelroomId]);
GO

-- Creating foreign key on [TamagotchiId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [fk_tamagotchi_hotelroom]
    FOREIGN KEY ([TamagotchiId])
    REFERENCES [dbo].[Tamagochis]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_tamagotchi_hotelroom'
CREATE INDEX [IX_fk_tamagotchi_hotelroom]
ON [dbo].[Bookings]
    ([TamagotchiId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------