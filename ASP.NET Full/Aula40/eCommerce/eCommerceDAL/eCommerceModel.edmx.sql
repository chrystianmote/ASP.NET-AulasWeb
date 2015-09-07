
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 02/16/2011 12:29:48
-- Generated from EDMX file: D:\Servidor\Aula40\eCommerce\eCommerceDAL\eCommerceModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [eCommerce];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ItemPedido_Pedido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ItensPedido] DROP CONSTRAINT [FK_ItemPedido_Pedido];
GO
IF OBJECT_ID(N'[dbo].[FK_ItemPedido_Produto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ItensPedido] DROP CONSTRAINT [FK_ItemPedido_Produto];
GO
IF OBJECT_ID(N'[dbo].[FK_Pedido_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pedidos] DROP CONSTRAINT [FK_Pedido_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_Produto_Categoria]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Produtos] DROP CONSTRAINT [FK_Produto_Categoria];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Categorias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categorias];
GO
IF OBJECT_ID(N'[dbo].[ItensPedido]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ItensPedido];
GO
IF OBJECT_ID(N'[dbo].[Pedidos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pedidos];
GO
IF OBJECT_ID(N'[dbo].[Produtos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Produtos];
GO
IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Categorias'
CREATE TABLE [dbo].[Categorias] (
    [IdCategoria] int IDENTITY(1,1) NOT NULL,
    [Descricao] varchar(50)  NOT NULL
);
GO

-- Creating table 'ItensPedido'
CREATE TABLE [dbo].[ItensPedido] (
    [IdPedido] int  NOT NULL,
    [IdProduto] int  NOT NULL,
    [PrecoUnitario] decimal(19,4)  NOT NULL,
    [Quantidade] int  NOT NULL
);
GO

-- Creating table 'Pedidos'
CREATE TABLE [dbo].[Pedidos] (
    [IdPedido] int IDENTITY(1,1) NOT NULL,
    [DataHora] datetime  NOT NULL,
    [Status] varchar(20)  NOT NULL,
    [IdUsuario] int  NOT NULL,
    [RefPagSeguro] varchar(100)  NULL
);
GO

-- Creating table 'Produtos'
CREATE TABLE [dbo].[Produtos] (
    [IdProduto] int IDENTITY(1,1) NOT NULL,
    [Nome] varchar(50)  NOT NULL,
    [Descricao] varchar(max)  NULL,
    [Preco] decimal(19,4)  NOT NULL,
    [IdCategoria] int  NOT NULL,
    [EmDestaque] bit  NOT NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [IdUsuario] int IDENTITY(1,1) NOT NULL,
    [Nome] varchar(50)  NOT NULL,
    [Email] varchar(50)  NOT NULL,
    [Senha] varchar(100)  NOT NULL,
    [CPF] char(14)  NOT NULL,
    [DataNascimento] datetime  NOT NULL,
    [TelefoneFixo] varchar(20)  NOT NULL,
    [TelefoneMovel] varchar(20)  NOT NULL,
    [EndLogradouro] varchar(50)  NOT NULL,
    [EndNumero] varchar(10)  NOT NULL,
    [EndComplemento] varchar(20)  NULL,
    [EndBairro] varchar(50)  NOT NULL,
    [EndCidade] varchar(50)  NOT NULL,
    [EndUF] char(2)  NOT NULL,
    [DataCadastro] datetime  NOT NULL,
    [EndCEP] char(8)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdCategoria] in table 'Categorias'
ALTER TABLE [dbo].[Categorias]
ADD CONSTRAINT [PK_Categorias]
    PRIMARY KEY CLUSTERED ([IdCategoria] ASC);
GO

-- Creating primary key on [IdPedido], [IdProduto] in table 'ItensPedido'
ALTER TABLE [dbo].[ItensPedido]
ADD CONSTRAINT [PK_ItensPedido]
    PRIMARY KEY CLUSTERED ([IdPedido], [IdProduto] ASC);
GO

-- Creating primary key on [IdPedido] in table 'Pedidos'
ALTER TABLE [dbo].[Pedidos]
ADD CONSTRAINT [PK_Pedidos]
    PRIMARY KEY CLUSTERED ([IdPedido] ASC);
GO

-- Creating primary key on [IdProduto] in table 'Produtos'
ALTER TABLE [dbo].[Produtos]
ADD CONSTRAINT [PK_Produtos]
    PRIMARY KEY CLUSTERED ([IdProduto] ASC);
GO

-- Creating primary key on [IdUsuario] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([IdUsuario] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdCategoria] in table 'Produtos'
ALTER TABLE [dbo].[Produtos]
ADD CONSTRAINT [FK_Produto_Categoria]
    FOREIGN KEY ([IdCategoria])
    REFERENCES [dbo].[Categorias]
        ([IdCategoria])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Produto_Categoria'
CREATE INDEX [IX_FK_Produto_Categoria]
ON [dbo].[Produtos]
    ([IdCategoria]);
GO

-- Creating foreign key on [IdPedido] in table 'ItensPedido'
ALTER TABLE [dbo].[ItensPedido]
ADD CONSTRAINT [FK_ItemPedido_Pedido]
    FOREIGN KEY ([IdPedido])
    REFERENCES [dbo].[Pedidos]
        ([IdPedido])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdProduto] in table 'ItensPedido'
ALTER TABLE [dbo].[ItensPedido]
ADD CONSTRAINT [FK_ItemPedido_Produto]
    FOREIGN KEY ([IdProduto])
    REFERENCES [dbo].[Produtos]
        ([IdProduto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ItemPedido_Produto'
CREATE INDEX [IX_FK_ItemPedido_Produto]
ON [dbo].[ItensPedido]
    ([IdProduto]);
GO

-- Creating foreign key on [IdUsuario] in table 'Pedidos'
ALTER TABLE [dbo].[Pedidos]
ADD CONSTRAINT [FK_Pedido_Usuario]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[Usuarios]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pedido_Usuario'
CREATE INDEX [IX_FK_Pedido_Usuario]
ON [dbo].[Pedidos]
    ([IdUsuario]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------