CREATE FUNCTION udf_CreatorWithBoardgames(@Name NVARCHAR(30)) 
RETURNS INT
AS
BEGIN
	DECLARE @Count INT
	SET @Count = (SELECT COUNT(*)
	FROM [Creators] AS c
	JOIN [CreatorsBoardgames] AS cb ON c.[Id] = cb.[CreatorId]
	WHERE c.[FirstName] = @Name)
	RETURN @Count
END