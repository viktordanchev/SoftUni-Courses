CREATE TABLE [Users] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	CHECK (DATALENGTH([ProfilePicture]) <= 921600),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT
)

INSERT INTO [Users] ([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
	VALUES
('Alex', '123', NULL, '1999-12-21 11:32:32', 1),
('Bob', '456', NULL, '2000-06-07 11:32:32', 0),
('Casandra', '789', NULL, '2004-04-06 11:32:32', 0),
('Katy', '101', NULL, '1976-01-01 11:32:32', 1),
('Gab', '112', NULL, '2001-03-03 11:32:32', 1)