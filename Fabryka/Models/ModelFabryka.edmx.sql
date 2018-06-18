
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/18/2018 19:21:23
-- Generated from EDMX file: C:\Users\Wojtek2\source\repos\Fabryka\Fabryka\Models\ModelFabryka.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FabrykaSPTI2018];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'HalaSet'
CREATE TABLE [dbo].[HalaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nazwa] nvarchar(max)  NOT NULL,
    [Adres] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MaszynaSet'
CREATE TABLE [dbo].[MaszynaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Numer_ewidencyjny] nvarchar(max)  NOT NULL,
    [Nazwa] nvarchar(max)  NOT NULL,
    [Data_uru] datetime  NULL,
    [Operatorzy] nvarchar(max)  NOT NULL,
    [HalaId] int  NOT NULL
);
GO

-- Creating table 'OperatorSet'
CREATE TABLE [dbo].[OperatorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Imie] nvarchar(max)  NOT NULL,
    [Nazwisko] nvarchar(max)  NOT NULL,
    [Placa] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MaszynaOperator'
CREATE TABLE [dbo].[MaszynaOperator] (
    [Maszyna_Id] int  NOT NULL,
    [Operator_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'HalaSet'
ALTER TABLE [dbo].[HalaSet]
ADD CONSTRAINT [PK_HalaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MaszynaSet'
ALTER TABLE [dbo].[MaszynaSet]
ADD CONSTRAINT [PK_MaszynaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OperatorSet'
ALTER TABLE [dbo].[OperatorSet]
ADD CONSTRAINT [PK_OperatorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Maszyna_Id], [Operator_Id] in table 'MaszynaOperator'
ALTER TABLE [dbo].[MaszynaOperator]
ADD CONSTRAINT [PK_MaszynaOperator]
    PRIMARY KEY CLUSTERED ([Maszyna_Id], [Operator_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [HalaId] in table 'MaszynaSet'
ALTER TABLE [dbo].[MaszynaSet]
ADD CONSTRAINT [FK_HalaMaszyna]
    FOREIGN KEY ([HalaId])
    REFERENCES [dbo].[HalaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HalaMaszyna'
CREATE INDEX [IX_FK_HalaMaszyna]
ON [dbo].[MaszynaSet]
    ([HalaId]);
GO

-- Creating foreign key on [Maszyna_Id] in table 'MaszynaOperator'
ALTER TABLE [dbo].[MaszynaOperator]
ADD CONSTRAINT [FK_MaszynaOperator_Maszyna]
    FOREIGN KEY ([Maszyna_Id])
    REFERENCES [dbo].[MaszynaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Operator_Id] in table 'MaszynaOperator'
ALTER TABLE [dbo].[MaszynaOperator]
ADD CONSTRAINT [FK_MaszynaOperator_Operator]
    FOREIGN KEY ([Operator_Id])
    REFERENCES [dbo].[OperatorSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MaszynaOperator_Operator'
CREATE INDEX [IX_FK_MaszynaOperator_Operator]
ON [dbo].[MaszynaOperator]
    ([Operator_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------