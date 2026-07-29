IF NOT EXISTS (SELECT 1 FROM PersonalPronouns)
BEGIN
	INSERT INTO PersonalPronouns
		( PronounNames )
	VALUES
		( 'He / Him / His' ),
		( 'She / Her / Hers' ),
		( 'They / Them / Theirs' )
END