ALTER PROCEDURE [dbo].[spUser_Upsert]
	@Name VARCHAR(1000),
	@Id INT = NULL
AS
BEGIN

	DECLARE @ret INT;
	SET @ret = 0;
	BEGIN TRAN; 
		IF EXISTS(SELECT 1 FROM [dbo].[User] WHERE Id = @Id) BEGIN
			UPDATE [dbo].[User]
			SET	[Name] = @Name,
				[UpdateDateUTC] = GETUTCDATE()
			WHERE Id = @Id;
			SELECT @Id
		      
		END ELSE BEGIN

			INSERT INTO [dbo].[User]([Name])
			OUTPUT	ISNULL(INSERTED.[Id],-1)
			VALUES(@Name);
		END;
	COMMIT;
RETURN @ret;
END
--exec [spUser_Upsert] 'Admin1'
--drop procedure [spUser_Upsert]
--SELECT * FROM [User]
--delete from [User] WHERE Id = 8
------------------------------------------------------------------------------------------------------------------------------------------------------------------

ALTER PROCEDURE [dbo].[spUser_GetAll]
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
    SET NOCOUNT ON;

	BEGIN TRY
	
        SELECT 
				Id,
				[Name],
				CreateDateUTC,
				UpdateDateUTC				
        FROM dbo.[User]  
		ORDER BY Id

    END TRY
    BEGIN CATCH
    END CATCH
END
GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Stored procedure used to get all User.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'spUser_GetAll';
GO
-- exec [spUser_GetAll]

------------------------------------------------------------------------------------------------------------------------------------------------------------------

Create PROCEDURE [dbo].[spCity_GetAll]
AS
BEGIN
    SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
    SET NOCOUNT ON;

	BEGIN TRY
        SELECT 
				Id,
				[Name],
				CreateDateUTC,
				UpdateDateUTC,
				[Description]
        FROM dbo.[City]  
		ORDER BY Id

    END TRY
    BEGIN CATCH
    END CATCH
END
GO

------------------------------------------------------------------------------------------------------------------------------------------------------------------

Alter PROCEDURE [dbo].[spUser_GetAllByCityId](
	@CityId INT
)
AS
BEGIN
    SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
    SET NOCOUNT ON;

	BEGIN TRY
        SELECT usr.Id as UserId, usr.[Name] as UserName, ct.Id as CityId, ct.[Name] as CityName, rl.Id as RoleId, rl.[Name] as RoleName, ur.Id as UserRoleId
		FROM [USER] usr
		INNER JOIN [UserRole] ur ON ur.UserId = usr.Id
		INNER JOIN [City] ct ON ct.Id = ur.CityId
		INNER JOIN [Role] rl ON rl.Id = ur.RoleId
		WHERE ur.CityId = @CityId

    END TRY
    BEGIN CATCH
    END CATCH
END
GO
------------------------------------------------------------------------------------------------------------------------------------------------------------------

ALTER PROCEDURE [dbo].[spStore_GetAllByCityId](
	@CityId INT
)
AS
BEGIN
    SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
    SET NOCOUNT ON;

	BEGIN TRY
        SELECT st.Id as StoreId, st.[Name] as StoreName, st.[Description], ct.Id as CityId, ct.[Name] as CityName
		FROM Store st
		INNER JOIN [City] ct ON st.CityId = ct.Id
		WHERE ct.Id = @CityId

    END TRY
    BEGIN CATCH
    END CATCH
END
GO

------------------------------------------------------------------------------------------------------------------------------------------------------------------

Create PROCEDURE [dbo].[spStore_Upsert](
	@StoreName VARCHAR(1000),
	@CityId INT,
	@StoreId INT = NULL,
	@Description VARCHAR(1000) = null
) AS
BEGIN

	DECLARE @ret INT;
	SET @ret = 0;
	BEGIN TRAN; 
		IF EXISTS(SELECT 1 FROM [dbo].[Store] WHERE Id = @StoreId) BEGIN
			UPDATE [dbo].[Store]
			SET	[Name] = @StoreName,
				[Description] = ISNUll(@Description, [Description]),
				[UpdateDateUTC] = GETUTCDATE()
			WHERE Id = @StoreId;
			SELECT @StoreId
		      
		END ELSE BEGIN

			INSERT INTO [dbo].[Store]([Name], [Description], [CityId])
			OUTPUT	ISNULL(INSERTED.[Id],-1)
			VALUES(@StoreName, @Description, @CityId);
		END;
	COMMIT;
RETURN @ret;
END
------------------------------------------------------------------------------------------------------------------------------------------------------------------

ALTER PROCEDURE [dbo].[spUserRole_Upsert]
	@UserId INT,
	@RoleId INT,
	@CityId INT
AS
BEGIN

	DECLARE @ret int;
	SET @ret = -1;
	BEGIN TRAN; 

	IF EXISTS( SELECT 1 FROM UserRole WHERE CityId = @CityId AND RoleId = @RoleId)
	BEGIN
		IF @RoleId = 2
		BEGIN
			SET @ret = -2;
		END ELSE BEGIN
			INSERT INTO [UserRole] ([UserId], [RoleId], [CityId])
			OUTPUT	ISNULL(INSERTED.[Id],-1)
			VALUES (@UserId, @RoleId, @CityId);
		END
	
	END ELSE BEGIN
		INSERT INTO [UserRole] ([UserId], [RoleId], [CityId])
		OUTPUT	ISNULL(INSERTED.[Id],-1)
		VALUES (@UserId, @RoleId, @CityId);
	END

	COMMIT;
	SELECT @ret;
RETURN @ret;
END
--exec [spUser_Upsert] 'Admin1'
--drop procedure [spUser_Upsert]
--SELECT * FROM [User]
--delete from [User] WHERE Id = 8
------------------------------------------------------------------------------------------------------------------------------------------------------------------

Create PROCEDURE [dbo].[spUserRoles_GetAll]
AS
BEGIN
    SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
    SET NOCOUNT ON;

	BEGIN TRY
        SELECT 
				Id,
				[Name],
				CreateDateUTC,
				UpdateDateUTC,
				[Description]
        FROM dbo.[Role]  
		ORDER BY Id

    END TRY
    BEGIN CATCH
    END CATCH
END
GO