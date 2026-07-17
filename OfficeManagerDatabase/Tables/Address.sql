CREATE TABLE Address (
	AddressId INT NOT NULL IDENTITY (1, 1),
	PersonId INT NOT NULL,
	AddressLine1 NVARCHAR(100) NOT NULL,
	AddressLine2 NVARCHAR(100) NULL,
	City NVARCHAR(100) NOT NULL,
	Postcode NVARCHAR(20) NOT NULL,
	AddressTypeId INT NOT NULL,
	CONSTRAINT PK_Address PRIMARY KEY (AddressId),
	CONSTRAINT FK_Address_Person FOREIGN KEY (PersonId)
		REFERENCES Person (PersonId),
	CONSTRAINT FK_Address_AddressType FOREIGN KEY (AddressTypeId)
		REFERENCES AddressType (AddressTypeId),
);