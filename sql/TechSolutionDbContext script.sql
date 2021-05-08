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

CREATE TABLE [Questions] (
    [Id] uniqueidentifier NOT NULL,
    [QuestionTitle] varchar(50) NOT NULL,
    [QuestionText] varchar(250) NOT NULL,
    [QuestionTags] varchar(20) NULL,
    [QuestionViewed] float default(0) NOT NULL,
    [CreationDate] datetime NOT NULL DEFAULT (getdate()),
    CONSTRAINT [PK_Questions] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Answers] (
    [Id] uniqueidentifier NOT NULL,
    [AnswerText] varchar(250) NOT NULL,
    [AcceptedAnswer] bit NOT NULL,
    [AnswerUpvotes] int NOT NULL,
    [AnswerDownvotes] int NOT NULL,
    [QuestionId] uniqueidentifier NOT NULL,
    [CreationDate] datetime NOT NULL DEFAULT (getdate()),
    CONSTRAINT [PK_Answers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Answers_Questions_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [Questions] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [QuestionComments] (
    [Id] uniqueidentifier NOT NULL,
    [QuestionCommentsText] varchar(200) NOT NULL,
    [QuestionCommentsUpvotes] int NOT NULL,
    [QuestionCommentsDownvotes] int NOT NULL,
    [QuestionId] uniqueidentifier NOT NULL,
    [CreationDate] datetime NOT NULL DEFAULT (getdate()),
    CONSTRAINT [PK_QuestionComments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_QuestionComments_Questions_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [Questions] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [AnswersComments] (
    [Id] uniqueidentifier NOT NULL,
    [AnswerCommentText] varchar(200) NOT NULL,
    [AnswerCommentUpvotes] int NOT NULL,
    [AnswerCommentDownvotes] int NOT NULL,
    [AnswerId] uniqueidentifier NOT NULL,
    [CreationDate] datetime NOT NULL DEFAULT (getdate()),
    CONSTRAINT [PK_AnswersComments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AnswersComments_Answers_AnswerId] FOREIGN KEY ([AnswerId]) REFERENCES [Answers] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Answers_QuestionId] ON [Answers] ([QuestionId]);
GO

CREATE INDEX [IX_AnswersComments_AnswerId] ON [AnswersComments] ([AnswerId]);
GO

CREATE INDEX [IX_QuestionComments_QuestionId] ON [QuestionComments] ([QuestionId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210422010034_Initial', N'5.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Questions]') AND [c].[name] = N'QuestionTitle');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Questions] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Questions] ALTER COLUMN [QuestionTitle] varchar(150) NOT NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Questions]') AND [c].[name] = N'QuestionText');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Questions] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Questions] ALTER COLUMN [QuestionText] varchar(1500) NOT NULL;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AnswersComments]') AND [c].[name] = N'AnswerCommentText');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [AnswersComments] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [AnswersComments] ALTER COLUMN [AnswerCommentText] varchar(1000) NOT NULL;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Answers]') AND [c].[name] = N'AnswerText');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Answers] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Answers] ALTER COLUMN [AnswerText] varchar(1500) NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210424192322_UpdateQuestionAndAnswerColumnSize', N'5.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Questions] ADD [UserId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
GO

ALTER TABLE [QuestionComments] ADD [UserId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
GO

ALTER TABLE [AnswersComments] ADD [UserId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
GO

ALTER TABLE [Answers] ADD [UserId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210427172814_Added Relationship with the user', N'5.0.5');
GO

COMMIT;
GO

