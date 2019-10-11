CREATE TABLE [dbo].[SysUser] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Name]            VARCHAR (200) NOT NULL,
    [User]            VARCHAR (20)  NOT NULL,
    [Password]        VARCHAR (500) NOT NULL,
    [CreationDate]    DATETIME      NULL,
    [RemovalDate]     DATETIME      NULL,
    [Status]          BIT           NULL,
    [RenewalPassDate] DATETIME      NULL,
    [LoginAttemps]    TINYINT       NULL,
    [IdPerson]        INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

