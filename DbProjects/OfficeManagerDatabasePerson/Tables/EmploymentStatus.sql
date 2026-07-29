CREATE TABLE [dbo].[EmploymentStatus]
(
	EmploymentStatusId INT NOT NULL IDENTITY (1, 1),
	StatusName NVARCHAR(20) NOT NULL,
	CONSTRAINT PK_EmploymentStatus PRIMARY KEY (EmploymentStatusId),
);
