SELECT * FROM [dbo].[User];
SELECT * FROM [dbo].[Role];
SELECT * FROM [dbo].[City];
SELECT * FROM [dbo].[UserRole];


SELECT usr.Id as UserId, usr.[Name] as UserName, ct.Id as CityId, ct.[Name] as CityName, rl.Id as RoleId, rl.[Name] as RoleName, ur.Id as UserRoleId
FROM [USER] usr
INNER JOIN [UserRole] ur ON ur.UserId = usr.Id
INNER JOIN [City] ct ON ct.Id = ur.CityId
INNER JOIN [Role] rl ON rl.Id = ur.RoleId

--INSERT INTO [Role] ([Name], [Description])
--VALUES ('System', 'application users'),
--('PrimarySalesPerson', 'Main Salesman'),
--('SecondarySalesPerson', 'Salesman')

--delete from UserRole where id = 2


--INSERT INTO [City]
--([Name],[Description])
--VALUES ('Hovedstaden', 'Capital Region of Denmark'),
--('MidJutland', 'Central Denmark Region'),
--('NorthJutland', 'North Denmark Region'),
--('Zealand', 'Region Zealand')


--INSERT INTO [User] ([Name])
--VALUES ('John'), ('Martin'), ('User1'), ('User2')

--INSERT INTO [UserRole] ([UserId], [RoleId], [CityId]) VALUES (2, 3, 1), (1, 3, 1), (3, 2, 3), (4, 3, 3)
