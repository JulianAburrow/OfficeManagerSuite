IF NOT EXISTS (Select 1 FROM EmploymentStatus)
BEGIN
	INSERT INTO EmploymentStatus
		( StatusName )
	VALUES
		( 'Accepted' ),
		( 'Left' ),
		( 'Offered' ),
		( 'Permanent' ),
		( 'Probation' )
END