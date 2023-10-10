CREATE FUNCTION udf_ProductWithClients (@Name NVARCHAR(35))
RETURNS INT
AS
BEGIN
	DECLARE @Count INT
	SET @Count = (SELECT COUNT(*)
		FROM [Clients] AS c
		JOIN [ProductsClients] AS pc ON c.[Id] = pc.[ClientId]
		JOIN [Products] AS p ON pc.[ProductId] = p.[Id]
		WHERE p.[Name] = @Name)
	RETURN @Count
END