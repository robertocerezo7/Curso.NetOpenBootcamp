CREATE TABLE [Category] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [CreatedBy] nvarchar(max) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdateBy] nvarchar(max) NOT NULL,
    [UpdateAt] datetime2 NULL,
    [DeleteBy] nvarchar(max) NOT NULL,
    [DeleteAt] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Course] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [ShortDescription] nvarchar(280) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [Level] int NOT NULL,
    [CreatedBy] nvarchar(max) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdateBy] nvarchar(max) NOT NULL,
    [UpdateAt] datetime2 NULL,
    [DeleteBy] nvarchar(max) NOT NULL,
    [DeleteAt] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Course] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [LastName] nvarchar(100) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [CreatedBy] nvarchar(max) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdateBy] nvarchar(max) NOT NULL,
    [UpdateAt] datetime2 NULL,
    [DeleteBy] nvarchar(max) NOT NULL,
    [DeleteAt] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO