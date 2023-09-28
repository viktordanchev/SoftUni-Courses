SELECT TOP(5) [CountryName],
	IIF(p.[Elevation] != 0, p.[PeakName], '(no highest peak)') AS [Highest Peak Name],
	IIF(p.[Elevation] != 0, p.[Elevation], 0) AS [Highest Peak Elevation],
	IIF(p.[MountainId] IS NOT NULL, m.[MountainRange], '(no mountain)') AS [Mountain]
FROM [Countries] AS c
LEFT JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode] 
LEFT JOIN [Mountains] AS m ON m.[Id] = mc.[MountainId]
LEFT JOIN [Peaks] AS p ON p.[MountainId] = m.[Id]
GROUP BY [CountryName], p.[Elevation], p.[PeakName], p.[MountainId], m.[MountainRange]
ORDER BY [CountryName], [Highest Peak Name]