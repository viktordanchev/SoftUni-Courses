CREATE PROCEDURE usp_SearchByCountry (@Country VARCHAR(10)) 
AS
	SELECT v.[Name]
		,v.[NumberVAT]
		,CONCAT_WS(' ', a.[StreetName], a.[StreetNumber]) AS [Street Info]
		,CONCAT_WS(' ', a.[City], a.[PostCode]) AS [City Info]
	FROM [Vendors] AS v
		JOIN [Addresses] AS a ON v.[AddressId] = a.[Id]
		JOIN [Countries] AS c ON a.[CountryId] = c.[Id]
	WHERE c.[Name] = @Country
	ORDER BY v.[Name], a.[City]