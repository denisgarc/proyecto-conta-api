CREATE TABLE [dbo].[SysRolAccess] (
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    [IdRol]       INT NULL,
    [IdMenu]      INT NULL,
    [AllowCreate] BIT NULL,
    [AllowModify] BIT NULL,
    [AllowDelete] BIT NULL,
    [AllowView]   BIT NULL,
    [Status]      BIT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([IdMenu]) REFERENCES [dbo].[SysMenu] ([Id]),
    FOREIGN KEY ([IdRol]) REFERENCES [dbo].[SysRol] ([Id])
);

