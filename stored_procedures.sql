CREATE PROCEDURE sp_InsertAppUser 
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


CREATE PROCEDURE sp_InsertAppUserXInterest
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