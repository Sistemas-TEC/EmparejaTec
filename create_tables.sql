-- Create the Gender table
CREATE TABLE Gender (
    idGender INT PRIMARY KEY IDENTITY(1,1),
    gender VARCHAR(255)
);

-- Create the UserStatus table
CREATE TABLE UserStatus (
    idUserStatus INT PRIMARY KEY IDENTITY(1,1),
    userStatus VARCHAR(255)
);

-- Create the AppUser table
CREATE TABLE AppUser (
    email VARCHAR(255) PRIMARY KEY,
    username VARCHAR(255),
    summary TEXT,
    age INT,
    idGender INT,
    idUserStatus INT,
    avatarPath VARCHAR(255),
    bannerPath VARCHAR(255),
    FOREIGN KEY (idGender) REFERENCES Gender(idGender),
    FOREIGN KEY (idUserStatus) REFERENCES UserStatus(idUserStatus)
);

-- Create the Interest table
CREATE TABLE Interest(
	idInterest INT PRIMARY KEY IDENTITY(1,1),
	interest VARCHAR(255)
);

-- Create the AppUserXInterest table
CREATE TABLE AppUserXInterest (
    idAppUserXInterest INT PRIMARY KEY IDENTITY(1,1),
    email VARCHAR(255),
    idInterest INT,
    FOREIGN KEY (email) REFERENCES AppUser(email),
    FOREIGN KEY (idInterest) REFERENCES Interest(idInterest)
);

-- Create the AttractedTo table
CREATE TABLE AttractedTo (
    idAttractedTo INT PRIMARY KEY IDENTITY(1,1),
    email VARCHAR(255),
    idGender INT,
    FOREIGN KEY (email) REFERENCES AppUser(email),
    FOREIGN KEY (idGender) REFERENCES Gender(idGender)
);

-- Create the RelationshipType table
CREATE TABLE RelationshipType (
    idRelationshipType INT PRIMARY KEY IDENTITY(1,1),
    relationshipType VARCHAR(255)
);

-- Create the AppUserXRelationshipType table
CREATE TABLE AppUserXRelationshipType (
    idAppUserXRelationshipType INT PRIMARY KEY IDENTITY(1,1),
    email VARCHAR(255),
    idRelationshipType INT,
    FOREIGN KEY (email) REFERENCES AppUser(email),
    FOREIGN KEY (idRelationshipType) REFERENCES RelationshipType(idRelationshipType)
);

-- Create the UserPossibleMatches table
CREATE TABLE UserPossibleMatch (
    idUserPossibleMatch INT PRIMARY KEY IDENTITY(1,1),
    idUserLogged VARCHAR(255),
    idPossibleMatch VARCHAR(255),
    FOREIGN KEY (idUserLogged) REFERENCES AppUser(email),
    FOREIGN KEY (idPossibleMatch) REFERENCES AppUser(email)
);

-- Create the RequestStatus table
CREATE TABLE RequestStatus (
    idRequestStatus INT PRIMARY KEY IDENTITY(1,1),
    requestStatus VARCHAR(255)
);

-- Create the Request table
CREATE TABLE Request (
    idRequest INT PRIMARY KEY IDENTITY(1,1),
    idRequestStatus INT,
    idSender VARCHAR(255),
    idReceiver VARCHAR(255),
    date DATE,
    time TIME,
    FOREIGN KEY (idRequestStatus) REFERENCES RequestStatus(idRequestStatus),
    FOREIGN KEY (idSender) REFERENCES AppUser(email),
    FOREIGN KEY (idReceiver) REFERENCES AppUser(email)
);

-- Create the ChatStatus table
CREATE TABLE ChatStatus (
    idChatStatus INT PRIMARY KEY IDENTITY(1,1),
    chatStatus VARCHAR(255)
);

-- Create the Chat table
CREATE TABLE Chat (
    idChat INT PRIMARY KEY IDENTITY(1,1),
    idRequest INT,
    idChatStatus INT,
    startDateChat DATE,
    isMediaActivated BIT,
    FOREIGN KEY (idRequest) REFERENCES Request(idRequest),
    FOREIGN KEY (idChatStatus) REFERENCES ChatStatus(idChatStatus)
);

-- Create the Message table
CREATE TABLE Message (
    idMessage INT PRIMARY KEY IDENTITY(1,1),
    idChat INT,
    idSender VARCHAR(255),
    idReceiver VARCHAR(255),
    textContent TEXT,
    date DATE,
    time TIME,
    FOREIGN KEY (idChat) REFERENCES Chat(idChat),
    FOREIGN KEY (idSender) REFERENCES AppUser(email),
    FOREIGN KEY (idReceiver) REFERENCES AppUser(email)
);

-- Create the ContentType table
CREATE TABLE ContentType (
    idContentType INT PRIMARY KEY IDENTITY(1,1),
    contentType VARCHAR(255)
);

-- Create the MediaContent table
CREATE TABLE MediaContent (
    idMediaContent INT PRIMARY KEY IDENTITY(1,1),
    idContentType INT,
    mediaPath VARCHAR(255),
    FOREIGN KEY (idContentType) REFERENCES ContentType(idContentType)
);

-- Create the ChatCategory table
CREATE TABLE ChatCategory (
    idChatCategory INT PRIMARY KEY IDENTITY(1,1),
    chatCategory VARCHAR(255)
);

-- Create the ChatCategoryPerUser table
CREATE TABLE ChatCategoryPerUser (
    idChatCategoryPerUser INT PRIMARY KEY IDENTITY(1,1),
    idChatCategory INT,
    idUser VARCHAR(255),
    idChat INT,
    FOREIGN KEY (idChatCategory) REFERENCES ChatCategory(idChatCategory),
    FOREIGN KEY (idUser) REFERENCES AppUser(email),
    FOREIGN KEY (idChat) REFERENCES Chat(idChat)
);

-- Create the Administrator table
CREATE TABLE Administrator (
    idAdministrator INT PRIMARY KEY IDENTITY(1,1),
    email VARCHAR(255),
    pass VARCHAR(255)
);

-- Create the ReportReason table
CREATE TABLE ReportReason (
    idReportReason INT PRIMARY KEY IDENTITY(1,1),
    reportReason VARCHAR(255)
);

-- Create the Report table
CREATE TABLE Report (
    idReport INT PRIMARY KEY IDENTITY(1,1),
    idReportedUser VARCHAR(255),
    idUserReporting VARCHAR(255),
    idChat INT,
    idReportReason INT,
    idReportStatus INT,
    idAdministrator INT,
    date DATE,
    notes TEXT,
    FOREIGN KEY (idReportedUser) REFERENCES AppUser(email),
    FOREIGN KEY (idUserReporting) REFERENCES AppUser(email),
    FOREIGN KEY (idChat) REFERENCES Chat(idChat),
    FOREIGN KEY (idReportReason) REFERENCES ReportReason(idReportReason),
    FOREIGN KEY (idReportStatus) REFERENCES RequestStatus(idRequestStatus),
    FOREIGN KEY (idAdministrator) REFERENCES Administrator(idAdministrator)
);
