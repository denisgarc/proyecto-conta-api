CREATE TABLE [dbo].[SysMenu] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Name]       VARCHAR (100) NOT NULL,
    [Action]     VARCHAR (25)  NULL,
    [Controller] VARCHAR (25)  NULL,
    [Url]        VARCHAR (300) NULL,
    [IdIcon]     INT           NULL,
    [IdTop]      INT           NULL,
    [Status]     BIT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([IdIcon]) REFERENCES [dbo].[SysIcon] ([Id])
);

