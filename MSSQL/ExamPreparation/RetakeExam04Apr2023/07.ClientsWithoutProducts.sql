SELECT c.[Id]
	,c.[Name] AS [Client]
	,CONCAT_WS(', ' 
		,CONCAT_WS(' ', a.[StreetName], a.[StreetNumber])
		,a.[City]
		,a.[PostCode]
		,cr.[Name]) AS [Address]
FROM [Clients] AS c
LEFT JOIN [ProductsClients] AS pc ON c.[Id] = pc.[ClientId]
JOIN [Addresses] AS a ON a.[Id] = c.[AddressId]
JOIN [Countries] AS cr ON cr.[Id] = a.[CountryId]
WHERE [ClientId] IS NULL