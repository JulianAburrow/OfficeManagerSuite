CREATE TABLE Person (
	PersonId INT NOT NULL IDENTITY (1, 1),
	FirstName NVARCHAR(100) NOT NULL,
	MiddleNames NVARCHAR(100) NULL,
	LastName NVARCHAR(100) NOT NULL,
	EmailAddress NVARCHAR(100) NULL,
	PhoneNumber NVARCHAR(20) NULL,
	PersonalPronounsId INT NULL,
	GenderId INT NULL,
	EmploymentStatusId INT NOT NULL,
	Photo VARBINARY(MAX) NULL,
	PhotoMimeType NVARCHAR(25) NULL,
	Pronunciation VARBINARY(MAX) NULL,
	PronunciationMimeType NVARCHAR(25) NULL,
	CONSTRAINT PK_Person PRIMARY KEY (PersonId),
	CONSTRAINT FK_Person_EmploymentStatus FOREIGN KEY (EmploymentStatusId)
		REFERENCES EmploymentStatus (EmploymentStatusId),
	CONSTRAINT FK_Person_PersonalPronouns FOREIGN KEY (PersonalPronounsId)
		REFERENCES PersonalPronouns (PersonalPronounsId),
	CONSTRAINT FK_Person_Gender FOREIGN KEY (GenderId)
		REFERENCES Gender (GenderId)
);