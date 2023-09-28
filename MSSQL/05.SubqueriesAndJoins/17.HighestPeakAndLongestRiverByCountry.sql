SELECT TOP(5) [CountryName], 
	MAX(p.[Elevation]) AS [HighestPeakElevation], 
	MAX(r.[Length]) AS [LongestRiverLength]
FROM [Countries] AS c
LEFT JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode] 
LEFT JOIN [Mountains] AS m ON m.[Id] = mc.[MountainId]
LEFT JOIN [Peaks] AS p ON p.[MountainId] = m.[Id]
LEFT JOIN [CountriesRivers] AS cr ON c.[CountryCode] = cr.[CountryCode] 
LEFT JOIN [Rivers] AS r ON r.[Id] = cr.[RiverId]
GROUP BY [CountryName]
ORDER BY [HighestPeakElevation] DESC, 
	[LongestRiverLength] DESC,
	[CountryName]