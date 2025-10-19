IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name=N'BankSystemDb')
BEGIN
    CREATE DATABASE [BankSystemDb];
END
GO

USE [BankSystemDb]
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Personas] (
    [PersonaId] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [Genero] nvarchar(max) NOT NULL,
    [Edad] int NOT NULL,
    [Identificacion] int NOT NULL,
    [Direccion] nvarchar(max) NOT NULL,
    [Telefono] int NOT NULL,
    [Discriminator] nvarchar(8) NOT NULL,
    [ClienteId] int NULL,
    [Contraseña] nvarchar(max) NULL,
    [Estado] bit NULL,
    CONSTRAINT [PK_Personas] PRIMARY KEY ([PersonaId])
);
GO

CREATE TABLE [Cuentas] (
    [CuentaId] int NOT NULL IDENTITY,
    [NumeroCuenta] int NOT NULL,
    [Tipo] nvarchar(max) NOT NULL,
    [SaldoInicial] int NOT NULL,
    [Estado] bit NOT NULL,
    [ClienteId] int NOT NULL,
    CONSTRAINT [PK_Cuentas] PRIMARY KEY ([CuentaId]),
    CONSTRAINT [FK_Cuentas_Personas_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Personas] ([PersonaId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Movimientos] (
    [MovimientoId] int NOT NULL IDENTITY,
    [Fecha] datetime2 NOT NULL,
    [Tipo] nvarchar(max) NOT NULL,
    [Valor] int NOT NULL,
    [Saldo] int NOT NULL,
    [CuentaId] int NOT NULL,
    CONSTRAINT [PK_Movimientos] PRIMARY KEY ([MovimientoId]),
    CONSTRAINT [FK_Movimientos_Cuentas_CuentaId] FOREIGN KEY ([CuentaId]) REFERENCES [Cuentas] ([CuentaId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Cuentas_ClienteId] ON [Cuentas] ([ClienteId]);
GO

CREATE UNIQUE INDEX [IX_Cuentas_NumeroCuenta] ON [Cuentas] ([NumeroCuenta]);
GO

CREATE INDEX [IX_Movimientos_CuentaId] ON [Movimientos] ([CuentaId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251019154313_InitialCreate', N'8.0.21');
GO

INSERT INTO Personas (Nombre, Genero, Edad, Identificacion, Direccion, Telefono, Contraseña, Estado, Discriminator)
VALUES
('Jose Lema', 'Masculino', 24, 21241, 'Otavalo sn y principal', 098254785, 1234, 1, 'Cliente'),
('Marianela Montalvo', 'Femenino', 34, 521240,  'Amazonas y NNUU', 097548965, 5678, 1, 'Cliente'),
('Juan Osorio', 'Masculino', 24, 789875,  '13 junio y Equinoccial', 098874587, 1245, 1, 'Cliente')
GO

INSERT INTO Cuentas (NumeroCuenta, Tipo, SaldoInicial, Estado, ClienteId)
VALUES
(478758, 'Ahorro', 2000, 1, 1),
(225487, 'Corriente', 100, 1, 2),
(495878, 'Ahorro', 0, 1, 3),
(496825, 'Ahorro', 540, 1, 2)
GO

COMMIT;
GO

