SELECT COUNT(*) - COUNT(c.MountainId) AS [Count]
FROM (
	SELECT [MountainId] 
	FROM [Countries] AS c
	LEFT JOIN [MountainsCountries] AS mc ON mc.[CountryCode] = c.[CountryCode]
) AS c