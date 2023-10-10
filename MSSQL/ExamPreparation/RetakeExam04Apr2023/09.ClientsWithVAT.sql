SELECT c.[Name]
	,MAX(p.[Price]) AS [Price]
	,[NumberVAT] AS [VAT Number]
FROM [Clients] AS c
JOIN [ProductsClients] AS pc ON c.[Id] = pc.[ClientId] 
JOIN [Products] AS p ON pc.[ProductId] = p.[Id] 
WHERE CHARINDEX('KG', c.[Name]) != LEN(c.[Name]) - 1
GROUP BY c.[Name], [NumberVAT]
ORDER BY MAX(p.[Price]) DESC