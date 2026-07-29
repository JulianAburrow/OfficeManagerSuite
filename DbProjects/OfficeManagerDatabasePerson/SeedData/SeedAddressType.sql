IF NOT EXISTS (SELECT 1 FROM AddressType)
BEGIN

	INSERT INTO AddressType
		( TypeName )
	VALUES
		( 'Home' ),
		( 'Correspondence' ),
		( 'Holiday' )
END