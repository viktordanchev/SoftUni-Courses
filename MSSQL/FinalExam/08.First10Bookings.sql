SELECT TOP(10)
	h.[Name]
	,d.[Name] AS [DestinationName]
	,c.[Name] AS [CountryName]
FROM [Bookings] AS b
JOIN [Hotels] AS h ON b.[HotelId] = h.[Id]
JOIN [Destinations] AS d ON h.[DestinationId] = d.[Id]
JOIN [Countries] AS c ON d.[CountryId] = c.[Id]
WHERE [ArrivalDate] < '2023-12-31' 
	AND h.[Id] % 2 = 1
ORDER BY [CountryName], [ArrivalDate]