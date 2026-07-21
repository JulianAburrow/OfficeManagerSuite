IF NOT EXISTS (SELECT 1 FROM Colour)
BEGIN

	INSERT INTO Colour
		(ColourName)
	VALUES
		( 'Red' ),
		( 'Orange' ),
		( 'Yellow' ),
		( 'Green' ),
		( 'Blue' ),
		( 'Indigo' ),
		( 'Violet' )
END