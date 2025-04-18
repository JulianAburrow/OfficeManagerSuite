USE Master
GO

IF EXISTS (Select * From sys.databases Where name = 'OfficeManagerSuitePerson')
	Alter Database [OfficeManagerSuitePerson] Set Single_User With Rollback Immediate
GO
IF EXISTS (Select * From sys.databases Where name = 'OfficeManagerSuitePerson')
	Drop Database [OfficeManagerSuitePerson]
GO
Create Database [OfficeManagerSuitePerson]
GO

USE [OfficeManagerSuitePerson]
GO

CREATE TABLE EmploymentStatus (
	EmploymentStatusId INT NOT NULL IDENTITY (1, 1),
	StatusName NVARCHAR(20) NOT NULL,
	CONSTRAINT PK_EmploymentStatus PRIMARY KEY (EmploymentStatusId)
);
GO

CREATE TABLE Gender (
	GenderId INT NOT NULL IDENTITY (1, 1),
	GenderName NVARCHAR(20) NOT NULL,
	CONSTRAINT PK_Gender PRIMARY KEY (GenderId)
);

CREATE TABLE PersonalPronouns (
	PersonalPronounsId INT NOT NULL IDENTITY (1, 1),
	PronounNames NVARCHAR(20) NOT NULL,
	CONSTRAINT PK_PersonalPronouns PRIMARY KEY (PersonalPronounsId)
);

CREATE TABLE Person (
	PersonId INT NOT NULL IDENTITY (1, 1),
	FirstName NVARCHAR(100) NOT NULL,
	MiddleNames NVARCHAR(100) NULL,
	LastName NVARCHAR(100) NOT NULL,
	EmailAddress NVARCHAR(100) NULL,
	Phone NVARCHAR(20) NULL,
	PersonalPronounsId INT NULL,
	GenderId INT NULL,
	EmploymentStatusId INT NOT NULL,
	Photo VARBINARY(MAX) NULL,
	Pronunciation VARBINARY(MAX) NULL,
	CONSTRAINT PK_Person PRIMARY KEY (PersonId),
	CONSTRAINT FK_Person_EmploymentStatus FOREIGN KEY (EmploymentStatusId)
		REFERENCES EmploymentStatus (EmploymentStatusId),
	CONSTRAINT FK_Person_PersonalPronouns FOREIGN KEY (PersonalPronounsId)
		REFERENCES PersonalPronouns (PersonalPronounsId),
	CONSTRAINT FK_Person_Gender FOREIGN KEY (GenderId)
		REFERENCES Gender (GenderId)

);
GO

CREATE TABLE EmergencyContact (
	EmergencyContactId INT NOT NULL IDENTITY (1, 1),
	PersonId INT NOT NULL,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	Phone NVARCHAR(20) NOT NULL,
	Relationship NVARCHAR(50) NULL,
	CONSTRAINT PK_EmergencyContact PRIMARY KEY (EmergencyContactId),
	CONSTRAINT FK_EmergencyContact_Person FOREIGN KEY (PersonId)
		REFERENCES Person (PersonId)
);
GO

CREATE TABLE AddressType (
	AddressTypeId INT NOT NULL IDENTITY (1, 1),
	TypeName NVARCHAR(20) NOT NULL,
	CONSTRAINT PK_AddressType PRIMARY KEY (AddressTypeId)
);
GO

CREATE TABLE Address (
	AddressId INT NOT NULL IDENTITY (1, 1),
	PersonId INT NOT NULL,
	AddressLine1 NVARCHAR(100) NOT NULL,
	AddressLine2 NVARCHAR(100) NOT NULL,
	City NVARCHAR(100) NOT NULL,
	PostCode NVARCHAR(20) NOT NULL,
	AddressTypeId INT NOT NULL,
	CONSTRAINT PK_Address PRIMARY KEY (AddressId),
	CONSTRAINT FK_Address_Person FOREIGN KEY (PersonId)
		REFERENCES Person (PersonId),
	CONSTRAINT FK_Address_AddressType FOREIGN KEY (AddressTypeId)
		REFERENCES AddressType (AddressTypeId)
);
GO