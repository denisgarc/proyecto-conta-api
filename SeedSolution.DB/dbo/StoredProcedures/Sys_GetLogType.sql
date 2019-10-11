CREATE PROCEDURE [dbo].[Sys_GetLogType]
AS
BEGIN
	SELECT
		 [Id]
		,[Description]
		,[State]
	FROM [SysLogType];
	
	RETURN 0;
END
