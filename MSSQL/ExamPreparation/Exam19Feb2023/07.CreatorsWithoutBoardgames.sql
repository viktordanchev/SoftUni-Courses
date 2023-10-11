SELECT c.[Id]
	,CONCAT_WS(' ', c.[FirstName], c.[LastName]) AS [CreatorName]
	,c.[Email]
FROM [Creators] AS c
LEFT JOIN [CreatorsBoardgames] AS cb ON c.[Id] = cb.[CreatorId]
WHERE cb.[BoardgameId] IS NULL
ORDER BY c.[FirstName]