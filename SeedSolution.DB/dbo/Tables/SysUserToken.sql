CREATE TABLE [dbo].[SysUserToken] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [IdUser]         INT           NULL,
    [Token]          VARCHAR (MAX) NULL,
    [CreationDate]   DATETIME      NULL,
    [LastUpdateDate] DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([IdUser]) REFERENCES [dbo].[SysUser] ([Id])
);

