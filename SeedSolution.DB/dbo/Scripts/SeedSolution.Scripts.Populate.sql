/*
Plantilla de script posterior a la implementación							
--------------------------------------------------------------------------------------
 Este archivo contiene instrucciones de SQL que se anexarán al script de compilación.		
 Use la sintaxis de SQLCMD para incluir un archivo en el script posterior a la implementación.			
 Ejemplo:      :r .\miArchivo.sql								
 Use la sintaxis de SQLCMD para hacer referencia a una variable en el script posterior a la implementación.		
 Ejemplo:      :setvar TableName miTabla							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

/* Creación de Usuario Administrador */
/*
INSERT INTO dbo.SysUser (Name, [User], Password, CreationDate, RemovalDate, Status, RenewalPassDate, LoginAttemps, IdPerson)
VALUES ('admin', 'admin', '123', '2018-07-29 20:54:20', NULL, 1, '2050-07-29', 3, 0)
GO
*/

/************************  Configuración de Log ************************/

DELETE SysActionType;
DELETE SysLogType;

DBCC CHECKIDENT ('SysActionType', RESEED,0);
DBCC CHECKIDENT ('SysLogType', RESEED,0);

INSERT INTO SysActionType VALUES ('Consulta',1);
INSERT INTO SysActionType VALUES ('Adición',1);
INSERT INTO SysActionType VALUES ('Editar',1);
INSERT INTO SysActionType VALUES ('Eliminar',1);

INSERT INTO SysLogType VALUES ('Informativo', 1);
INSERT INTO SysLogType VALUES ('Alerta', 1);
INSERT INTO SysLogType VALUES ('Error', 1);

GO

