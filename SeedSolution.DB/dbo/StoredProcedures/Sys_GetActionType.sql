CREATE PROCEDURE [dbo].[Sys_GetActionType]
AS
BEGIN
	SELECT
		 [Id]
		,[Description]
		,[State]
	FROM [SysActionType];

	RETURN 0;
END