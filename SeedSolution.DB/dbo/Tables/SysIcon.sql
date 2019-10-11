CREATE TABLE [dbo].[SysIcon] (
    [Id]     INT          IDENTITY (1, 1) NOT NULL,
    [Name]   VARCHAR (50) NOT NULL,
    [Class]  VARCHAR (50) NOT NULL,
    [Status] BIT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

