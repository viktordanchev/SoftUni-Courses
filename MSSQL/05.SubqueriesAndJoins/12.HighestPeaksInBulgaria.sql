SELECT c.[CountryCode], [MountainRange], [PeakName], [Elevation] 
FROM [Countries] AS c
JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode] 
	AND [CountryName] = 'Bulgaria'
JOIN [Mountains] AS m ON m.[Id] = mc.[MountainId]
JOIN [Peaks] AS p ON p.[MountainId] = m.[Id]
	AND [Elevation] > 2835
ORDER BY [Elevation] DESC