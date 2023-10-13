SELECT a.[Name]
	,atp.[AnimalType]
	,FORMAT(a.[BirthDate],'dd.MM.yyyy') AS [BirthDate]
FROM [Animals] AS a
JOIN [AnimalTypes] AS atp ON a.[AnimalTypeId] = atp.[Id]
ORDER BY a.[Name]