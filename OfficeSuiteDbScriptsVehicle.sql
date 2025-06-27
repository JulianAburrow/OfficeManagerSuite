USE Master
GO

IF EXISTS (Select * From sys.databases Where name = 'OfficeManagerSuiteVehicle')
	Alter Database [OfficeManagerSuiteVehicle] Set Single_User With Rollback Immediate
GO

IF EXISTS (Select * From sys.databases Where name = 'OfficeManagerSuiteVehicle')
	Drop Database [OfficeManagerSuiteVehicle]
GO

Create Database [OfficeManagerSuiteVehicle]
GO

USE [OfficeManagerSuiteVehicle]
GO

CREATE TABLE Colour (
	ColourId INT NOT NULL IDENTITY (1, 1),
	ColourName NVARCHAR(20) NOT NULL,
	CONSTRAINT PK_COLOUR PRIMARY KEY (ColourId)
);

INSERT INTO Colour
	(ColourName)
VALUES
	( 'Red' ),
	( 'Orange' ),
	( 'Yellow' ),
	( 'Green' ),
	( 'Blue' ),
	( 'Indigo' ),
	( 'Violet' );
GO

CREATE TABLE Model (
	ModelId INT NOT NULL IDENTITY (1, 1),
	ModelName NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_Model PRIMARY KEY (ModelId)
);
GO

CREATE TABLE Manufacturer (
	ManufacturerId INT NOT NULL IDENTITY (1, 1),
	ManufacturerName NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_Manufacturer PRIMARY KEY (ManufacturerId)
);

INSERT INTO Manufacturer
	(ManufacturerName)
VALUES
	( 'Maserati' ),
	( 'Porsche' ),
	( 'BMW' ),
	( 'Mercedes-Benz' );
GO

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
GO