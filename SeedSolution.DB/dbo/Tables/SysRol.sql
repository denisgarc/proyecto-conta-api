CREATE TABLE [dbo].[SysRol] (
    [Id]     INT           IDENTITY (1, 1) NOT NULL,
    [Name]   VARCHAR (150) NOT NULL,
    [Status] BIT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

