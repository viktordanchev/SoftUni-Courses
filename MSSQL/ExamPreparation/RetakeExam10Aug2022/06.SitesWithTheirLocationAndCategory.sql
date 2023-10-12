SELECT s.[Name] AS [Site]
	,l.[Name]
	,s.[Establishment]
	,c.[Name]
FROM [Sites] AS s
JOIN [Locations] AS l ON s.[LocationId] = l.[Id]
JOIN [Categories] AS c ON s.[CategoryId] = c.[Id]
ORDER BY c.[Name] DESC, l.[Name], s.[Name]