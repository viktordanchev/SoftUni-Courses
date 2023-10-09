CREATE PROCEDURE usp_GetEmployeesFromTown 
	@TownName NVARCHAR(30)
AS
	SELECT [FirstName], [LastName]
	FROM [Employees] AS e
	JOIN [Addresses] AS a ON e.[AddressID] = a.[AddressID]
	JOIN [Towns] AS t ON a.[TownID] = t.[TownID]
	WHERE t.[Name] = @TownName