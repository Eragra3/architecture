IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AspNetUsers] (
    [Id] nvarchar(450) NOT NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);

GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;

GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);

GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);

GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180630082604_InitialMigration', N'2.1.1-rtm-30846');

GO

CREATE TABLE [LearningProgram] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Specialization] nvarchar(max) NULL,
    [NumberOfSemesters] int NOT NULL,
    [Level] int NOT NULL,
    [Mode] int NOT NULL,
    [CnpsHours] int NOT NULL,
    CONSTRAINT [PK_LearningProgram] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Module] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Area] int NOT NULL,
    [LearningProgramId] int NOT NULL,
    CONSTRAINT [PK_Module] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Module_LearningProgram_LearningProgramId] FOREIGN KEY ([LearningProgramId]) REFERENCES [LearningProgram] ([Id]) ON DELETE CASCADE
);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CnpsHours', N'Level', N'Mode', N'Name', N'NumberOfSemesters', N'Specialization') AND [object_id] = OBJECT_ID(N'[LearningProgram]'))
    SET IDENTITY_INSERT [LearningProgram] ON;
INSERT INTO [LearningProgram] ([Id], [CnpsHours], [Level], [Mode], [Name], [NumberOfSemesters], [Specialization])
VALUES (1, 700, 1, 2, N'Informatyka', 8, N''),
(2, 700, 1, 1, N'Informatyka', 7, N''),
(3, 700, 3, 2, N'Informatyka', 4, N'Projektowanie Systemów Informatycznych'),
(4, 1200, 3, 1, N'Informatyka', 3, N'Danologia');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CnpsHours', N'Level', N'Mode', N'Name', N'NumberOfSemesters', N'Specialization') AND [object_id] = OBJECT_ID(N'[LearningProgram]'))
    SET IDENTITY_INSERT [LearningProgram] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Area', N'LearningProgramId', N'Name') AND [object_id] = OBJECT_ID(N'[Module]'))
    SET IDENTITY_INSERT [Module] ON;
INSERT INTO [Module] ([Id], [Area], [LearningProgramId], [Name])
VALUES (1, 5, 1, N'Aplikacje Webowe'),
(2, 2, 1, N'Przedmioty Humanistyczne'),
(3, 1, 1, N'Zajęcia Sportowe'),
(4, 5, 2, N'Aplikacje Webowe'),
(5, 2, 2, N'Przedmioty Humanistyczne'),
(6, 1, 2, N'Zajęcia Sportowe'),
(7, 5, 3, N'Aplikacje Webowe'),
(8, 2, 3, N'Przedmioty Humanistyczne'),
(9, 5, 4, N'Aplikacje Webowe'),
(10, 2, 4, N'Przedmioty Humanistyczne');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Area', N'LearningProgramId', N'Name') AND [object_id] = OBJECT_ID(N'[Module]'))
    SET IDENTITY_INSERT [Module] OFF;

GO

CREATE INDEX [IX_Module_LearningProgramId] ON [Module] ([LearningProgramId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180630222237_AddedLearningProgram', N'2.1.1-rtm-30846');

GO

CREATE TABLE [ResearchFellow] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NULL,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [Title] nvarchar(max) NULL,
    CONSTRAINT [PK_ResearchFellow] PRIMARY KEY ([Id])
);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'FirstName', N'LastName', N'Title', N'UserId') AND [object_id] = OBJECT_ID(N'[ResearchFellow]'))
    SET IDENTITY_INSERT [ResearchFellow] ON;
INSERT INTO [ResearchFellow] ([Id], [FirstName], [LastName], [Title], [UserId])
VALUES (1, N'Daniel', N'Bider', N'inż.', 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'FirstName', N'LastName', N'Title', N'UserId') AND [object_id] = OBJECT_ID(N'[ResearchFellow]'))
    SET IDENTITY_INSERT [ResearchFellow] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'FirstName', N'LastName', N'Title', N'UserId') AND [object_id] = OBJECT_ID(N'[ResearchFellow]'))
    SET IDENTITY_INSERT [ResearchFellow] ON;
INSERT INTO [ResearchFellow] ([Id], [FirstName], [LastName], [Title], [UserId])
VALUES (2, N'Szymon', N'Barańczyk', N'inż.', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'FirstName', N'LastName', N'Title', N'UserId') AND [object_id] = OBJECT_ID(N'[ResearchFellow]'))
    SET IDENTITY_INSERT [ResearchFellow] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'FirstName', N'LastName', N'Title', N'UserId') AND [object_id] = OBJECT_ID(N'[ResearchFellow]'))
    SET IDENTITY_INSERT [ResearchFellow] ON;
INSERT INTO [ResearchFellow] ([Id], [FirstName], [LastName], [Title], [UserId])
VALUES (3, N'John', N'Doe', N'mgr inż.', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'FirstName', N'LastName', N'Title', N'UserId') AND [object_id] = OBJECT_ID(N'[ResearchFellow]'))
    SET IDENTITY_INSERT [ResearchFellow] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180701103939_AddedResearchFellow', N'2.1.1-rtm-30846');

GO

CREATE TABLE [Kek] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NULL,
    [Level] int NOT NULL,
    [Type] int NOT NULL,
    [LearningProgramId] int NOT NULL,
    CONSTRAINT [PK_Kek] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Kek_LearningProgram_LearningProgramId] FOREIGN KEY ([LearningProgramId]) REFERENCES [LearningProgram] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Subject] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [SupervisorId] int NULL,
    CONSTRAINT [PK_Subject] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Subject_ResearchFellow_SupervisorId] FOREIGN KEY ([SupervisorId]) REFERENCES [ResearchFellow] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Pek] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NULL,
    [Level] int NOT NULL,
    [Type] int NOT NULL,
    [SubjectId] int NOT NULL,
    [KekId] int NOT NULL,
    CONSTRAINT [PK_Pek] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pek_Kek_KekId] FOREIGN KEY ([KekId]) REFERENCES [Kek] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Pek_Subject_SubjectId] FOREIGN KEY ([SubjectId]) REFERENCES [Subject] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [SubjectKekJoinModel] (
    [SubjectId] int NOT NULL,
    [KekId] int NOT NULL,
    CONSTRAINT [PK_SubjectKekJoinModel] PRIMARY KEY ([KekId], [SubjectId]),
    CONSTRAINT [FK_SubjectKekJoinModel_Kek_KekId] FOREIGN KEY ([KekId]) REFERENCES [Kek] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_SubjectKekJoinModel_Subject_SubjectId] FOREIGN KEY ([SubjectId]) REFERENCES [Subject] ([Id]) ON DELETE CASCADE
);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'SupervisorId') AND [object_id] = OBJECT_ID(N'[Subject]'))
    SET IDENTITY_INSERT [Subject] ON;
INSERT INTO [Subject] ([Id], [Name], [SupervisorId])
VALUES (1, N'Teleinformatyka', 3),
(2, N'Algorytmy i Struktury Danych', 1),
(3, N'Projektowanie Systemów Informatycznych II', NULL),
(4, N'Analiza Matematyczna I', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'SupervisorId') AND [object_id] = OBJECT_ID(N'[Subject]'))
    SET IDENTITY_INSERT [Subject] OFF;

GO

CREATE INDEX [IX_Kek_LearningProgramId] ON [Kek] ([LearningProgramId]);

GO

CREATE INDEX [IX_Pek_KekId] ON [Pek] ([KekId]);

GO

CREATE INDEX [IX_Pek_SubjectId] ON [Pek] ([SubjectId]);

GO

CREATE INDEX [IX_Subject_SupervisorId] ON [Subject] ([SupervisorId]);

GO

CREATE INDEX [IX_SubjectKekJoinModel_SubjectId] ON [SubjectKekJoinModel] ([SubjectId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180701122356_AddedSubjectKekPek', N'2.1.1-rtm-30846');

GO


