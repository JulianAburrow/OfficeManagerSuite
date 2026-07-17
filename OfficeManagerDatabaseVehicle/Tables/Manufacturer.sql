CREATE TABLE Manufacturer (
	ManufacturerId INT NOT NULL IDENTITY (1, 1),
	ManufacturerName NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_Manufacturer PRIMARY KEY (ManufacturerId)
);