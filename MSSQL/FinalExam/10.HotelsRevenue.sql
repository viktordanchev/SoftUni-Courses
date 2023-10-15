SELECT 
	h.[Name]
	,SUM(r.[Price] * DATEDIFF(DAY, b.[ArrivalDate], b.[DepartureDate])) AS [TotalRevenue]
FROM [Bookings] AS b
JOIN [Hotels] AS h ON b.[HotelId] = h.[Id]
JOIN [Rooms] AS r ON b.[RoomId] = r.[Id]
GROUP BY h.[Name]
ORDER BY [TotalRevenue] DESC
