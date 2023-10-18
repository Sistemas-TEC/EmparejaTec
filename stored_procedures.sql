CREATE OR ALTER PROCEDURE sp_InsertAppUser 
    @email VARCHAR(255),
    @username VARCHAR(255),
    @summary TEXT,
    @age INT,
    @idGender INT,
    @idUserStatus INT,
    @avatarPath VARCHAR(255) = NULL,
    @bannerPath VARCHAR(255) = NULL
AS
BEGIN
    -- Check for duplicate email
    IF EXISTS (SELECT 1 FROM AppUser WHERE email = @email)
    BEGIN
        RAISERROR('Email already exists.', 16, 1);
        RETURN;
    END

    -- Inserting the record
    INSERT INTO AppUser (email, username, summary, age, idGender, idUserStatus, avatarPath, bannerPath)
    VALUES (@email, @username, @summary, @age, @idGender, @idUserStatus, @avatarPath, @bannerPath);
    
    PRINT 'Record inserted successfully.';
END;
GO


CREATE OR ALTER PROCEDURE sp_InsertAppUserXInterest
    @email VARCHAR(255),
    @idInterest INT
AS
BEGIN
    -- Check if the user and interest combination already exists
    IF EXISTS (SELECT 1 FROM AppUserXInterest WHERE email = @email AND idInterest = @idInterest)
    BEGIN
        RAISERROR('The user and interest combination already exists.', 16, 1); 
        RETURN;
    END

    -- Inserting the record
    INSERT INTO AppUserXInterest (email, idInterest)
    VALUES (@email, @idInterest);
    
    PRINT 'Record inserted successfully.';
END;
GO

CREATE OR ALTER PROCEDURE sp_EditAppUser
    @email VARCHAR(255), -- Usado para identificar el registro a editar
    @username VARCHAR(255) = NULL,
    @summary TEXT = NULL,
    @age INT = NULL,
    @idGender INT = NULL,
    @idUserStatus INT = NULL,
    @avatarPath VARCHAR(255) = NULL,
    @bannerPath VARCHAR(255) = NULL
AS
BEGIN
    -- Verificar si el usuario existe
    IF NOT EXISTS (SELECT 1 FROM AppUser WHERE email = @email)
    BEGIN
        RAISERROR('El usuario con el correo especificado no existe.', 16, 1); 
        RETURN;
    END

    -- Editar el registro
    UPDATE AppUser 
    SET 
        username = ISNULL(@username, username),
        summary = ISNULL(@summary, summary),
        age = ISNULL(@age, age),
        idGender = ISNULL(@idGender, idGender),
        idUserStatus = ISNULL(@idUserStatus, idUserStatus),
        avatarPath = ISNULL(@avatarPath, avatarPath),
        bannerPath = ISNULL(@bannerPath, bannerPath)
    WHERE email = @email;
    
    PRINT 'Registro actualizado con éxito.';
END;
GO

CREATE OR ALTER PROCEDURE sp_DeleteAppUserXInterestByEmail
    @email VARCHAR(255)
AS
BEGIN
    -- Borrar registros con el email especificado
    DELETE FROM AppUserXInterest 
    WHERE email = @email;
    
    PRINT 'Registros borrados con éxito.';
END;
GO

CREATE OR ALTER PROCEDURE sp_DeleteUserPossibleMatch
    @email VARCHAR(255)
AS
BEGIN
    -- Borrar registros con el email especificado
    DELETE FROM UserPossibleMatch 
    WHERE idPossibleMatch = @email;
    
    PRINT 'Registros borrados con éxito.';
END;
GO

CREATE OR ALTER PROCEDURE sp_InsertUserPossibleMatches
    @idUserLogged VARCHAR(255)
AS
BEGIN
    INSERT INTO UserPossibleMatch (idUserLogged, idPossibleMatch)
    SELECT 
        @idUserLogged, 
        u.email
    FROM 
        AppUser u
    LEFT JOIN 
        UserPossibleMatch upm ON u.email = upm.idPossibleMatch AND upm.idUserLogged = @idUserLogged
    WHERE 
        u.email <> @idUserLogged AND
        upm.idPossibleMatch IS NULL;
END;
