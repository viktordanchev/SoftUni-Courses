SELECT 
	h.[Name] AS [HotelName]
	,r.[Price] AS [RoomPrice]
FROM [Tourists] AS t
JOIN [Bookings] AS b ON t.[Id] = b.[TouristId]
JOIN [Rooms] AS r ON b.[RoomId] = r.[Id]
JOIN [Hotels] AS h ON b.[HotelId] = h.[Id]
WHERE RIGHT(t.[Name], 2) != 'EZ'
ORDER BY [RoomPrice] DESC
