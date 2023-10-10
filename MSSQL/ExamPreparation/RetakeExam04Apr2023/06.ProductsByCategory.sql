SELECT p.[Id]
	,p.[Name]
	,[Price]
	,c.[Name] AS [CategoryName]
FROM [Products] AS p
JOIN [Categories] AS c ON p.[CategoryId] = c.[Id]
WHERE c.[Name] IN ('ADR', 'Others')
ORDER BY [Price] DESC