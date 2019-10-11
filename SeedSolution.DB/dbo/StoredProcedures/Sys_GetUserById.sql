CREATE PROCEDURE [dbo].[Sys_GetUserById]
	@pIdUser int
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
		WHERE [Id] = @pIdUser
	END