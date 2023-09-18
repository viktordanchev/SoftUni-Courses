CREATE DATABASE [Movies]

CREATE TABLE [Directors] (
	[Id] INT PRIMARY KEY IDENTITY,
	[DirectorName] NVARCHAR(70) NOT NULL,
	[Notes] NVARCHAR(MAX) 
)

INSERT INTO [Directors] ([DirectorName], [Notes])
	VALUES
('Alex', NULL),
('Dimitar', 'Something'),
('Marto', 'Something'),
('Asen', NULL),
('Viktor', 'Something')


CREATE TABLE [Genres] (
	[Id] INT PRIMARY KEY IDENTITY,
	[GenreName] NVARCHAR(70) NOT NULL,
	[Notes] NVARCHAR(MAX) 
)

INSERT INTO [Genres] ([GenreName], [Notes])
	VALUES
('Action', NULL),
('Adventure', 'Something'),
('Comedy', 'Something'),
('Drama', NULL),
('Fantasy', 'Something')

CREATE TABLE [Categories] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Categories] NVARCHAR(70) NOT NULL,
	[Notes] NVARCHAR(MAX) 
)

INSERT INTO [Categories] ([Categories], [Notes])
	VALUES
('Alex', NULL),
('Dimitar', 'Something'),
('Marto', 'Something'),
('Asen', NULL),
('Viktor', 'Something')

CREATE TABLE [Movies] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(50) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]) NOT NULL,
	[CopyrightYear] DATE NOT NULL,
	[Length] TIME(0) NOT NULL,
	[GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]) NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
	[Rating] DECIMAL(2, 1),
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Movies] ([Title], [DirectorId], [CopyrightYear], [Length], [GenreId], 
[CategoryId], [Rating], [Notes])
	VALUES
('Star Wars', 2, '2003-03-19', '01:45:32', 2, 2, 5.4, NULL),
('The Lord of the Rings', 1, '2003-03-19', '02:25:32', 1, 1, 2.4, 'Something'),
('Warcraft', 4, '2003-03-19', '01:15:52', 4, 4, 5.5, NULL),
('Back to the Future', 3, '2003-03-19', '02:05:00', 3, 3, 1.2, 'Something'),
('Pirates of the Caribbean', 5, '2003-03-19', '03:15:22', 5, 5, 3.2, NULL)