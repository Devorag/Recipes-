--JF

-- Check if the login exists
USE master;
GO
SELECT * FROM sys.server_principals 
WHERE name = 'appadmin';
GO

drop login appadmin
drop user appadmin_user
drop role approle

-- Check if the user exists in the RecipeDB database
USE RecipeDB;
GO
SELECT name FROM sys.database_principals WHERE name = 'appadmin_user';
GO

USE RecipeDB;
GO
SELECT dp.name AS DatabaseRoleName, mp.name AS DatabaseUserName
FROM sys.database_role_members AS drm
JOIN sys.database_principals AS dp ON drm.role_principal_id = dp.principal_id
JOIN sys.database_principals AS mp ON drm.member_principal_id = mp.principal_id
WHERE dp.name = 'approle' 
AND mp.name = 'appadmin_user';
GO

--USE RecipeDB;
--GO
--GRANT SELECT, INSERT, UPDATE, DELETE TO approle;
--GO
