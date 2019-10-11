CREATE TABLE [dbo].[SysUserRol] (
    [RolId]  INT NOT NULL,
    [UserId] INT NOT NULL,
    CONSTRAINT [PK_SysUserRol] PRIMARY KEY CLUSTERED ([RolId] ASC, [UserId] ASC),
    CONSTRAINT [FK_SysUserRol_Rol] FOREIGN KEY ([RolId]) REFERENCES [dbo].[SysRol] ([Id]),
    CONSTRAINT [FK_SysUserRol_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[SysUser] ([Id])
);

