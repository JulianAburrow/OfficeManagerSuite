IF NOT EXISTS (SELECT 1 FROM Manufacturer)
BEGIN
	INSERT INTO Manufacturer
		(ManufacturerName)
	VALUES
		( 'Maserati' ),
		( 'Porsche' ),
		( 'BMW' ),
		( 'Mercedes-Benz' )
END