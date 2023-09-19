CREATE DATABASE [Hotel]

CREATE TABLE [Employees] (
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(20) NOT NULL,
	[LastName] NVARCHAR(20) NOT NULL,
	[Title] NVARCHAR(20),
	[Notes] NVARCHAR(MAX) 
)

INSERT INTO [Employees] ([FirstName], [LastName], [Title], [Notes])
	VALUES
('Martin', 'Dimitrov', 'Something', NULL),
('Alex', 'Nikolov', 'Something', NULL),
('Viktor', 'Ivanov', 'Something', 'Something')

CREATE TABLE [Customers] (
	[AccountNumber] INT PRIMARY KEY NOT NULL,
	[FirstName] NVARCHAR(20) NOT NULL,
	[LastName] NVARCHAR(20) NOT NULL,
	[PhoneNumber] INT NOT NULL, 
	[EmergencyName] NVARCHAR(20), 
	[EmergencyNumber] INT,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Customers]
	VALUES
(53245, 'Martin', 'Dimitrov', 0868568, NULL, NULL, NULL),
(34743, 'Alex', 'Nikolov', 0856474, NULL, NULL, NULL),
(15226, 'Viktor', 'Ivanov', 0857347, NULL, NULL, NULL)

CREATE TABLE [RoomStatus] (
	[RoomStatus] VARCHAR(10) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [RoomStatus]
	VALUES
('Dirty', NULL),
('Clean', NULL),
('Clean', NULL)

CREATE TABLE [RoomTypes] (
	[RoomType] VARCHAR(10) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [RoomTypes]
	VALUES
('Room', NULL),
('Room', NULL),
('Room', NULL)

CREATE TABLE [BedTypes] (
	[BedType] VARCHAR(10) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [BedTypes]
	VALUES
('King', NULL),
('King', NULL),
('King', NULL)

CREATE TABLE [Rooms] (
	[RoomNumber] INT PRIMARY KEY NOT NULL,
	[RoomType] VARCHAR(10) NOT NULL,
	[BedType] VARCHAR(10) NOT NULL,
	[Rate] DECIMAL(2,1),
	[RoomStatus] VARCHAR(10) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Rooms]
	VALUES
(131, 'Room', 'King', 3.2, 'Dirty', NULL),
(132, 'Room', 'King', 4.5, 'Clean', NULL),
(133, 'Room', 'King', 5.4, 'Clean', NULL)

CREATE TABLE [Payments](
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]), 
	[PaymentDate] DATE NOT NULL, 
	[AccountNumber] INT FOREIGN KEY REFERENCES [Customers]([AccountNumber]), 
	[FirstDateOccupied] DATE NOT NULL, 
	[LastDateOccupied] DATE NOT NULL, 
	[TotalDays] INT NOT NULL, 
	[AmountCharged] DECIMAL(6, 2) NOT NULL, 
	[TaxRate] DECIMAL(3, 2), 
	[TaxAmount] DECIMAL(6, 2),
	[PaymentTotal] DECIMAL(6, 2),
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Payments]
	VALUES
(3, '2023-01-02', 53245, '2023-01-01', '2023-01-02', 1, 75.00, NULL, NULL, NULL, NULL),
(1, '2023-02-02', 34743, '2023-02-01', '2023-02-02', 1, 95.00, NULL, NULL, NULL, NULL),	
(2, '2023-03-02', 15226, '2023-03-01', '2023-03-02', 1, 110.00, NULL, NULL, NULL, NULL)

CREATE TABLE [Occupancies](
	[Id] INT PRIMARY KEY IDENTITY, 
	[EmployeeId] INT REFERENCES [Employees]([Id]), 
	[DateOccupied] DATE, 
	[AccountNumber] INT REFERENCES [Customers]([AccountNumber]), 
	[RoomNumber] INT REFERENCES [Rooms]([RoomNumber]), 
	[RateApplied] Decimal(3, 2), 
	[PhoneCharge] VARCHAR(12), 
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Occupancies] 
	VALUES
(2, '2023-01-01', 53245, 131, NULL, NULL, NULL),
(3, '2023-02-01', 34743, 132, NULL, NULL, NULL),
(1, '2023-03-01', 15226, 133, NULL, NULL, NULL)