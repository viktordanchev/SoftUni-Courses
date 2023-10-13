SELECT a.[Name]
	,YEAR(a.[BirthDate]) AS [BirthYear]
	,atp.[AnimalType]
FROM [Animals] AS a
JOIN [AnimalTypes] AS atp ON a.[AnimalTypeId] = atp.[Id]
WHERE a.[OwnerId] IS NULL 
	AND a.[BirthDate] > '01-01-2018'
	AND atp.[AnimalType] != 'Birds'
ORDER BY a.[Name]