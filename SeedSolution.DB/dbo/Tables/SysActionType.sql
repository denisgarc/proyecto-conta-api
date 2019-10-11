CREATE TABLE [dbo].[SysActionType]
(
	[Id] INT NOT NULL PRIMARY KEY Identity  (1,1)
	, [Description] varchar(max) not null 
	, [State] bit NOT NULL DEFAULT 1
)
