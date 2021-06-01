IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210524091917_InitialMigration')
BEGIN
    CREATE TABLE [Cards] (
        [Id] int NOT NULL IDENTITY,
        [Front] nvarchar(max) NOT NULL,
        [Back] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Cards] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210524091917_InitialMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210524091917_InitialMigration', N'5.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210525051906_InitialMigratioTwo')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210525051906_InitialMigratioTwo', N'5.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210525053113_InitialMigratioThree')
BEGIN
    ALTER TABLE [Cards] ADD [DeskId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210525053113_InitialMigratioThree')
BEGIN
    CREATE TABLE [Users] (
        [Id] int NOT NULL IDENTITY,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210525053113_InitialMigratioThree')
BEGIN
    CREATE TABLE [Desks] (
        [Id] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_Desks] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Desks_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210525053113_InitialMigratioThree')
BEGIN
    CREATE INDEX [IX_Cards_DeskId] ON [Cards] ([DeskId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210525053113_InitialMigratioThree')
BEGIN
    CREATE INDEX [IX_Desks_UserId] ON [Desks] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210525053113_InitialMigratioThree')
BEGIN
    ALTER TABLE [Cards] ADD CONSTRAINT [FK_Cards_Desks_DeskId] FOREIGN KEY ([DeskId]) REFERENCES [Desks] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210525053113_InitialMigratioThree')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210525053113_InitialMigratioThree', N'5.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210525055911_InitialMigrationBack')
BEGIN
    ALTER TABLE [Cards] DROP CONSTRAINT [FK_Cards_Desks_DeskId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210525055911_InitialMigrationBack')
BEGIN
    DROP TABLE [Desks];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210525055911_InitialMigrationBack')
BEGIN
    DROP TABLE [Users];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210525055911_InitialMigrationBack')
BEGIN
    DROP INDEX [IX_Cards_DeskId] ON [Cards];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210525055911_InitialMigrationBack')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Cards]') AND [c].[name] = N'DeskId');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Cards] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Cards] DROP COLUMN [DeskId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210525055911_InitialMigrationBack')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210525055911_InitialMigrationBack', N'5.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210525061816_InitialFirstTry')
BEGIN
    ALTER TABLE [Cards] ADD [DeskId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210525061816_InitialFirstTry')
BEGIN
    CREATE TABLE [Desks] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Desks] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210525061816_InitialFirstTry')
BEGIN
    CREATE INDEX [IX_Cards_DeskId] ON [Cards] ([DeskId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210525061816_InitialFirstTry')
BEGIN
    ALTER TABLE [Cards] ADD CONSTRAINT [FK_Cards_Desks_DeskId] FOREIGN KEY ([DeskId]) REFERENCES [Desks] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210525061816_InitialFirstTry')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210525061816_InitialFirstTry', N'5.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210525063323_InitialSecondTry')
BEGIN
    ALTER TABLE [Desks] ADD [UserId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210525063323_InitialSecondTry')
BEGIN
    CREATE TABLE [Users] (
        [Id] int NOT NULL IDENTITY,
        [TgId] int NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210525063323_InitialSecondTry')
BEGIN
    CREATE INDEX [IX_Desks_UserId] ON [Desks] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210525063323_InitialSecondTry')
BEGIN
    ALTER TABLE [Desks] ADD CONSTRAINT [FK_Desks_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210525063323_InitialSecondTry')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210525063323_InitialSecondTry', N'5.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210531170948_FavouriteMigration')
BEGIN
    ALTER TABLE [Cards] ADD [Favorite] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210531170948_FavouriteMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210531170948_FavouriteMigration', N'5.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210601103913_LangMigration')
BEGIN
    ALTER TABLE [Users] ADD [Lang] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210601103913_LangMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210601103913_LangMigration', N'5.0.6');
END;
GO

COMMIT;
GO

