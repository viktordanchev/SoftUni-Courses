SELECT TOP(5)
	b.[Name]
	,b.[Rating]
	,c.[Name] AS [CategoryName]
FROM [Boardgames] AS b
JOIN [PlayersRanges] AS pr ON b.[PlayersRangeId] = pr.[Id]
JOIN [Categories] AS c ON b.[CategoryId] = c.[Id]
WHERE [Rating] > 7 AND CHARINDEX('a', b.[Name]) > 0
	OR [Rating] > 7.5 AND pr.[PlayersMin] > 2 AND pr.[PlayersMax] > 5
ORDER BY b.[Name], b.[Rating] DESC