SELECT TOP(5)
	o.[Name] AS [Owner]
	,COUNT(*) AS [CountOfAnimals]
FROM [Owners] AS o
JOIN [Animals] AS a ON o.[Id] = a.[OwnerId]
GROUP BY o.[Name]
ORDER BY [CountOfAnimals] DESC, [Owner]