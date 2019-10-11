CREATE TABLE [dbo].[SysLogType]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1)
	, [Description] varchar(max) not null
	, [State] bit not null default 1
)
