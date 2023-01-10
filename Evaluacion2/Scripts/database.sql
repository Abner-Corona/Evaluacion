/*
 Navicat Premium Data Transfer

 Source Server         : localhost
 Source Server Type    : SQL Server
 Source Server Version : 16001000 (16.00.1000)
 Source Host           : localhost:1433
 Source Catalog        : Test
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 16001000 (16.00.1000)
 File Encoding         : 65001

 Date: 10/01/2023 15:12:45
*/


create database Test;
use Test;


-- ----------------------------
-- Table structure for clientes
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[clientes]') AND type IN ('U'))
	DROP TABLE [dbo].[clientes]
GO

CREATE TABLE [dbo].[clientes] (
  [Id] bigint  IDENTITY(1,1) NOT NULL,
  [Nombre] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Direccion] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Edad] int  NULL,
  [Telefono] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Sexo] int  NULL,
  [CuentaBancaria] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Activo] tinyint  NOT NULL,
  [FechaCreacion] datetime  NOT NULL,
  [FechaModificacion] datetime  NULL
)
GO

ALTER TABLE [dbo].[clientes] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of clientes
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[clientes] ON
GO

INSERT INTO [dbo].[clientes] ([Id], [Nombre], [Direccion], [Edad], [Telefono], [Sexo], [CuentaBancaria], [Activo], [FechaCreacion], [FechaModificacion]) VALUES (N'1', N'John', N'Mexico', N'30', N'7351183761', N'0', N'123', N'1', N'2023-01-10 14:52:03.830', NULL)
GO

SET IDENTITY_INSERT [dbo].[clientes] OFF
GO

COMMIT
GO


-- ----------------------------
-- Table structure for compras
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[compras]') AND type IN ('U'))
	DROP TABLE [dbo].[compras]
GO

CREATE TABLE [dbo].[compras] (
  [Id] bigint  IDENTITY(1,1) NOT NULL,
  [ClienteId] bigint  NOT NULL,
  [NumeroTarjeta] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Compra] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Monto] float(53)  NULL,
  [TipoTarjeta] int  NOT NULL,
  [TipoProduto] int  NOT NULL,
  [Activo] tinyint  NOT NULL,
  [FechaCreacion] datetime  NOT NULL,
  [FechaModificacion] datetime  NULL
)
GO

ALTER TABLE [dbo].[compras] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of compras
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[compras] ON
GO

INSERT INTO [dbo].[compras] ([Id], [ClienteId], [NumeroTarjeta], [Compra], [Monto], [TipoTarjeta], [TipoProduto], [Activo], [FechaCreacion], [FechaModificacion]) VALUES (N'1', N'1', N'123', N'ML', N'10000', N'1', N'0', N'1', N'2023-01-10 14:52:04.120', NULL)
GO

SET IDENTITY_INSERT [dbo].[compras] OFF
GO

COMMIT
GO


-- ----------------------------
-- Auto increment value for clientes
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[clientes]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table clientes
-- ----------------------------
ALTER TABLE [dbo].[clientes] ADD CONSTRAINT [PK_clientes] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for compras
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[compras]', RESEED, 1)
GO


-- ----------------------------
-- Indexes structure for table compras
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_compras_ClienteId]
ON [dbo].[compras] (
  [ClienteId] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table compras
-- ----------------------------
ALTER TABLE [dbo].[compras] ADD CONSTRAINT [PK_compras] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table compras
-- ----------------------------
ALTER TABLE [dbo].[compras] ADD CONSTRAINT [FK_compras_clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [dbo].[clientes] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO

