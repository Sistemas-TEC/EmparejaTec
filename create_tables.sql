-- Create the Gender table
CREATE TABLE Gender (
    idGender INT PRIMARY KEY,
    gender VARCHAR(255)
);

-- Create the UserStatus table
CREATE TABLE UserStatus (
    idUserStatus INT PRIMARY KEY,
    userStatus VARCHAR(255)
);

-- Create the AppUser table
CREATE TABLE AppUser (
    idAppUser INT PRIMARY KEY,
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

-- Create the AttractedTo table
CREATE TABLE AttractedTo (
    idAttractedTo INT PRIMARY KEY,
    idAppUser INT,
    idGender INT,
    FOREIGN KEY (idAppUser) REFERENCES AppUser(idAppUser),
    FOREIGN KEY (idGender) REFERENCES Gender(idGender)
);

-- Create the RelationshipType table
CREATE TABLE RelationshipType (
    idRelationshipType INT PRIMARY KEY,
    relationshipType VARCHAR(255)
);

-- Create the AppUserXRelationshipType table
CREATE TABLE AppUserXRelationshipType (
    idAppUserXRelationshipType INT PRIMARY KEY,
    idAppUser INT,
    idRelationshipType INT,
    FOREIGN KEY (idAppUser) REFERENCES AppUser(idAppUser),
    FOREIGN KEY (idRelationshipType) REFERENCES RelationshipType(idRelationshipType)
);

-- Create the RequestStatus table
CREATE TABLE RequestStatus (
    idRequestStatus INT PRIMARY KEY,
    requestStatus VARCHAR(255)
);

-- Create the Request table
CREATE TABLE Request (
    idRequest INT PRIMARY KEY,
    idRequestStatus INT,
    idSender INT,
    idReceiver INT,
    date DATE,
    time TIME,
    FOREIGN KEY (idRequestStatus) REFERENCES RequestStatus(idRequestStatus),
    FOREIGN KEY (idSender) REFERENCES AppUser(idAppUser),
    FOREIGN KEY (idReceiver) REFERENCES AppUser(idAppUser)
);

-- Create the ChatStatus table
CREATE TABLE ChatStatus (
    idChatStatus INT PRIMARY KEY,
    chatStatus VARCHAR(255)
);

-- Create the Chat table
CREATE TABLE Chat (
    idChat INT PRIMARY KEY,
    idRequest INT,
    idChatStatus INT,
    startDateChat DATE,
    isMediaActivated BIT,
    FOREIGN KEY (idRequest) REFERENCES Request(idRequest),
    FOREIGN KEY (idChatStatus) REFERENCES ChatStatus(idChatStatus)
);

-- Create the Message table
CREATE TABLE Message (
    idMessage INT PRIMARY KEY,
    idChat INT,
    idSender INT,
    idReceiver INT,
    textContent TEXT,
    date DATE,
    time TIME,
    FOREIGN KEY (idChat) REFERENCES Chat(idChat),
    FOREIGN KEY (idSender) REFERENCES AppUser(idAppUser),
    FOREIGN KEY (idReceiver) REFERENCES AppUser(idAppUser)
);

-- Create the ContentType table
CREATE TABLE ContentType (
    idContentType INT PRIMARY KEY,
    contentType VARCHAR(255)
);

-- Create the MediaContent table
CREATE TABLE MediaContent (
    idMediaContent INT PRIMARY KEY,
    idContentType INT,
    mediaPath VARCHAR(255),
    FOREIGN KEY (idContentType) REFERENCES ContentType(idContentType)
);

-- Create the ChatCategory table
CREATE TABLE ChatCategory (
    idChatCategory INT PRIMARY KEY,
    chatCategory VARCHAR(255)
);

-- Create the ChatCategoryPerUser table
CREATE TABLE ChatCategoryPerUser (
    idChatCategoryPerUser INT PRIMARY KEY,
    idChatCategory INT,
    idUser INT,
    idChat INT,
    FOREIGN KEY (idChatCategory) REFERENCES ChatCategory(idChatCategory),
    FOREIGN KEY (idUser) REFERENCES AppUser(idAppUser),
    FOREIGN KEY (idChat) REFERENCES Chat(idChat)
);

-- Create the Administrator table
CREATE TABLE Administrator (
    idAdministrator INT PRIMARY KEY,
    email VARCHAR(255),
    pass VARCHAR(255)
);

-- Create the ReportReason table
CREATE TABLE ReportReason (
    idReportReason INT PRIMARY KEY,
    reportReason VARCHAR(255)
);

-- Create the Report table
CREATE TABLE Report (
    idReport INT PRIMARY KEY,
    idReportedUser INT,
    idUserReporting INT,
    idChat INT,
    idReportReason INT,
    idReportStatus INT,
    idAdministrator INT,
    date DATE,
    notes TEXT,
    FOREIGN KEY (idReportedUser) REFERENCES AppUser(idAppUser),
    FOREIGN KEY (idUserReporting) REFERENCES AppUser(idAppUser),
    FOREIGN KEY (idChat) REFERENCES Chat(idChat),
    FOREIGN KEY (idReportReason) REFERENCES ReportReason(idReportReason),
    FOREIGN KEY (idReportStatus) REFERENCES RequestStatus(idRequestStatus),
    FOREIGN KEY (idAdministrator) REFERENCES Administrator(idAdministrator)
);
