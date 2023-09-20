CREATE TABLE [People] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] IMAGE,
	[Height] DECIMAL(3, 2),
	[Weight] DECIMAL(5, 2),
    [Gender] CHAR(1) NOT NULL,
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX)
)

INSERT INTO [People] ([Name], [Picture], [Height], [Weight], [Gender], [Birthdate], [Biography])
	VALUES
('Alex', NULL, 1.76, 60.00, 'm', '1999-12-21', NULL),
('Bob', NULL, 2.00, 80.00, 'm', '2000-06-07', NULL),
('Casandra', NULL, 1.65, 55.00, 'f', '2004-04-06', NULL),
('Katy', NULL, 1.80, 70.00, 'f', '1976-01-01', NULL),
('Gab', NULL, 1.82, 55.00, 'm', '2001-03-03', NULL)