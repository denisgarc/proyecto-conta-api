CREATE PROCEDURE [dbo].[Sys_SaveLog]
	@Id INT = 0,
	@UserId INT,
	@LogTypeId INT,
	@ActionTypeId INT,
	@FileName VARCHAR(MAX),
	@MethodName VARCHAR(MAX),
	@Description VARCHAR(MAX),
	@DTOIn VARCHAR(MAX),
	@DTOOut VARCHAR(MAX),
	@Date DATETIME
AS
BEGIN 
	INSERT INTO SysLog ([UserId],[LogTypeId],[ActionTypeId],[FileName],[MethodName],[Description],[DTOIn],[DTOOut],[Date])
		VALUES (@UserId,@LogTypeId,@ActionTypeId,@FileName,@MethodName,@Description,@DTOIn,@DTOOut,@Date);
END 
