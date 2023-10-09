CREATE PROCEDURE usp_GetTownsStartingWith
	@Town NVARCHAR(30)
AS
	SELECT [Name] AS [Town]
	FROM [Towns]
	WHERE LEFT([Name], LEN(@Town)) = @Town
