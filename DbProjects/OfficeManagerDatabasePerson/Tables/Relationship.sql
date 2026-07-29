CREATE TABLE Relationship (
	RelationshipId INT NOT NULL IDENTITY (1, 1),
	RelationshipName NVARCHAR(50),
	CONSTRAINT PK_Relationship PRIMARY KEY (RelationshipId)
);