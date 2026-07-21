CREATE TABLE Vehicle (
	VehicleId INT NOT NULL IDENTITY (1, 1),
	ManufacturerId INT NOT NULL,
	ModelId INT NOT NULL,
	RegistrationNumber NVARCHAR(20) NOT NULL,
	ColourId INT NOT NULL,
	YearOfManufacture INT NULL,
	CONSTRAINT PK_Vehicle PRIMARY KEY (VehicleId),
	CONSTRAINT FK_Vehicle_Manufacturer FOREIGN KEY (ManufacturerId)
		REFERENCES Manufacturer (ManufacturerId),
	CONSTRAINT FK_Vehicle_Colour FOREIGN KEY (ColourId)
		REFERENCES Colour (ColourId),
	CONSTRAINT FK_Vehicle_Model FOREIGN KEY (ModelId)
		REFERENCES Model (ModelId)
);