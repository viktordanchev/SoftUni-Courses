SELECT t.[LastName]
	,CEILING(t.[AverageRating]) AS [AverageRating]
	,t.[Name]
FROM (
	SELECT c.[LastName]
		,AVG(b.[Rating]) AS [AverageRating]
		,p.[Name]
	FROM [Creators] AS c
	JOIN [CreatorsBoardgames] AS cb ON c.[Id] = cb.[CreatorId]
	JOIN [Boardgames] AS b ON cb.[BoardgameId] = b.[Id]
	JOIN [Publishers] AS p ON b.[PublisherId] = p.[Id]
	WHERE p.[Name] = 'Stonemaier Games'
	GROUP BY c.[LastName], p.[Name]
) AS t
ORDER BY t.[AverageRating] DESC
