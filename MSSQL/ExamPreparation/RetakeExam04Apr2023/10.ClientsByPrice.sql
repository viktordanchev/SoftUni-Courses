SELECT c.[Name]
	,FLOOR(AVG(p.[Price])) AS [Average Price]
FROM [Clients] AS c
JOIN [ProductsClients] AS pc ON c.[Id] = pc.[ClientId]
JOIN [Products] AS p ON pc.[ProductId] = p.[Id]
JOIN [Vendors] AS v ON p.[VendorId] = v.[Id]
WHERE CHARINDEX('FR', v.[NumberVAT]) > 0
GROUP BY c.[Name]
ORDER BY FLOOR(AVG(p.[Price])), c.[Name] DESC