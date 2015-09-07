
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/23/2011 22:13:23
-- Generated from EDMX file: D:\Saulo\Aulas ASP.NET\Aula35 - Saulo\RedeSocialEF4\RedeSocialEF4\RedeSocialModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RedeSocial];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Album_Tema]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Album] DROP CONSTRAINT [FK_Album_Tema];
GO
IF OBJECT_ID(N'[dbo].[FK_Album_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Album] DROP CONSTRAINT [FK_Album_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_Amizade_Convidado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Amizade] DROP CONSTRAINT [FK_Amizade_Convidado];
GO
IF OBJECT_ID(N'[dbo].[FK_Amizade_Solicitante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Amizade] DROP CONSTRAINT [FK_Amizade_Solicitante];
GO
IF OBJECT_ID(N'[dbo].[FK_Comentario_Foto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comentario] DROP CONSTRAINT [FK_Comentario_Foto];
GO
IF OBJECT_ID(N'[dbo].[FK_Comentario_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comentario] DROP CONSTRAINT [FK_Comentario_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_Foto_Album]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Foto] DROP CONSTRAINT [FK_Foto_Album];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Album]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Album];
GO
IF OBJECT_ID(N'[dbo].[Amizade]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Amizade];
GO
IF OBJECT_ID(N'[dbo].[Comentario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comentario];
GO
IF OBJECT_ID(N'[dbo].[Foto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Foto];
GO
IF OBJECT_ID(N'[dbo].[Tema]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tema];
GO
IF OBJECT_ID(N'[dbo].[Usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Albuns'
CREATE TABLE [dbo].[Albuns] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] varchar(50)  NOT NULL,
    [Descricao] varchar(max)  NOT NULL,
    [DataCriacao] datetime  NOT NULL,
    [IdTema] int  NOT NULL,
    [IdPessoa] int  NOT NULL
);
GO

-- Creating table 'Comentarios'
CREATE TABLE [dbo].[Comentarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdFoto] int  NOT NULL,
    [IdPessoa] int  NOT NULL,
    [Texto] varchar(max)  NOT NULL,
    [DataCadastro] datetime  NOT NULL,
    [Aprovado] bit  NOT NULL
);
GO

-- Creating table 'Fotos'
CREATE TABLE [dbo].[Fotos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descricao] varchar(max)  NOT NULL,
    [DataCadastro] datetime  NOT NULL,
    [IdAlbum] int  NOT NULL
);
GO

-- Creating table 'Temas'
CREATE TABLE [dbo].[Temas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] varchar(50)  NOT NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] varchar(50)  NOT NULL,
    [Email] varchar(50)  NOT NULL,
    [DataNascimento] datetime  NOT NULL,
    [Senha] varchar(100)  NOT NULL,
    [DataCadastro] datetime  NOT NULL,
    [DataAcesso] datetime  NOT NULL
);
GO

-- Creating table 'Amizade'
CREATE TABLE [dbo].[Amizade] (
    [Convidados_Id] int  NOT NULL,
    [Solicitantes_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Albuns'
ALTER TABLE [dbo].[Albuns]
ADD CONSTRAINT [PK_Albuns]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comentarios'
ALTER TABLE [dbo].[Comentarios]
ADD CONSTRAINT [PK_Comentarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Fotos'
ALTER TABLE [dbo].[Fotos]
ADD CONSTRAINT [PK_Fotos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Temas'
ALTER TABLE [dbo].[Temas]
ADD CONSTRAINT [PK_Temas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Convidados_Id], [Solicitantes_Id] in table 'Amizade'
ALTER TABLE [dbo].[Amizade]
ADD CONSTRAINT [PK_Amizade]
    PRIMARY KEY NONCLUSTERED ([Convidados_Id], [Solicitantes_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdTema] in table 'Albuns'
ALTER TABLE [dbo].[Albuns]
ADD CONSTRAINT [FK_Album_Tema]
    FOREIGN KEY ([IdTema])
    REFERENCES [dbo].[Temas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Album_Tema'
CREATE INDEX [IX_FK_Album_Tema]
ON [dbo].[Albuns]
    ([IdTema]);
GO

-- Creating foreign key on [IdPessoa] in table 'Albuns'
ALTER TABLE [dbo].[Albuns]
ADD CONSTRAINT [FK_Album_Usuario]
    FOREIGN KEY ([IdPessoa])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Album_Usuario'
CREATE INDEX [IX_FK_Album_Usuario]
ON [dbo].[Albuns]
    ([IdPessoa]);
GO

-- Creating foreign key on [IdAlbum] in table 'Fotos'
ALTER TABLE [dbo].[Fotos]
ADD CONSTRAINT [FK_Foto_Album]
    FOREIGN KEY ([IdAlbum])
    REFERENCES [dbo].[Albuns]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Foto_Album'
CREATE INDEX [IX_FK_Foto_Album]
ON [dbo].[Fotos]
    ([IdAlbum]);
GO

-- Creating foreign key on [IdFoto] in table 'Comentarios'
ALTER TABLE [dbo].[Comentarios]
ADD CONSTRAINT [FK_Comentario_Foto]
    FOREIGN KEY ([IdFoto])
    REFERENCES [dbo].[Fotos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Comentario_Foto'
CREATE INDEX [IX_FK_Comentario_Foto]
ON [dbo].[Comentarios]
    ([IdFoto]);
GO

-- Creating foreign key on [IdPessoa] in table 'Comentarios'
ALTER TABLE [dbo].[Comentarios]
ADD CONSTRAINT [FK_Comentario_Usuario]
    FOREIGN KEY ([IdPessoa])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Comentario_Usuario'
CREATE INDEX [IX_FK_Comentario_Usuario]
ON [dbo].[Comentarios]
    ([IdPessoa]);
GO

-- Creating foreign key on [Convidados_Id] in table 'Amizade'
ALTER TABLE [dbo].[Amizade]
ADD CONSTRAINT [FK_Amizade_Usuario]
    FOREIGN KEY ([Convidados_Id])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Solicitantes_Id] in table 'Amizade'
ALTER TABLE [dbo].[Amizade]
ADD CONSTRAINT [FK_Amizade_Usuario1]
    FOREIGN KEY ([Solicitantes_Id])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Amizade_Usuario1'
CREATE INDEX [IX_FK_Amizade_Usuario1]
ON [dbo].[Amizade]
    ([Solicitantes_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------