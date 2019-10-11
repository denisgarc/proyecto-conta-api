CREATE PROCEDURE [dbo].[Sys_GetUserByUser]
	@pUser varchar(200)
AS
	BEGIN
		SELECT [Id]
				, [Name]
				, [User]
				, [Password]
				, [CreationDate]
				, [RemovalDate]
				, [Status]
				, [RenewalPassDate]
				, [LoginAttemps]
				, [IdPerson]
		FROM SysUser
		WHERE [User] = @pUser
	END