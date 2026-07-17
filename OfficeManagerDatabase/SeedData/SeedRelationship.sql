IF NOT EXISTS (SELECT 1 FROM Relationship)
BEGIN
	INSERT INTO Relationship
		( RelationshipName )
	VALUES
		( 'Spouse' )
END