CREATE TABLE [People] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	[Birthdate] DATETIME2 NOT NULL
)

INSERT INTO [People]
	VALUES
('Viktor', '2000-12-07 00:00:00.000'),
('Steven', '1992-09-10 00:00:00.000'),
('Stephen', '1910-09-19 00:00:00.000'),
('John', '2010-01-06 00:00:00.000')

SELECT [Name], 
DATEDIFF(YEAR, [Birthdate], GETDATE()) AS [Age in Year],
DATEDIFF(MONTH, [Birthdate], GETDATE()) AS [Age in Months],
DATEDIFF(DAY, [Birthdate], GETDATE()) AS [Age in Days],
DATEDIFF(MINUTE, [Birthdate], GETDATE()) AS [Age in Minutes]
FROM [People]