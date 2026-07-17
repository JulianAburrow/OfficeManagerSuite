CREATE TABLE EmergencyContact (
	EmergencyContactId INT NOT NULL IDENTITY (1, 1),
	PersonId INT NOT NULL,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	PhoneNumber NVARCHAR(20) NOT NULL,
	RelationshipId INT NOT NULL,
	CONSTRAINT PK_EmergencyContact PRIMARY KEY (EmergencyContactId),
	CONSTRAINT FK_EmergencyContact_Person FOREIGN KEY (PersonId)
		REFERENCES Person (PersonId),
	CONSTRAINT FK_EmergencyContact_Relationship FOREIGN KEY (RelationshipId)
		REFERENCES Relationship (RelationshipId)
);