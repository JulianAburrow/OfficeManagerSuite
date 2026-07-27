CREATE TABLE Model (
	ModelId INT NOT NULL IDENTITY (1, 1),
	ManufacturerId INT NOT NULL,
	ModelName NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_Model PRIMARY KEY (ModelId),
	CONSTRAINT FK_Model_Manufacturer FOREIGN KEY (ManufacturerId)
		REFERENCES Manufacturer (ManufacturerId)
);