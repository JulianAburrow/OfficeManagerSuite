CREATE TABLE PersonalPronouns (
	PersonalPronounsId INT NOT NULL IDENTITY (1, 1),
	PronounNames NVARCHAR(20) NOT NULL,
	CONSTRAINT PK_PersonalPronouns PRIMARY KEY (PersonalPronounsId)
);