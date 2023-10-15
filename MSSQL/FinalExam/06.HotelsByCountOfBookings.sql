SELECT t.[Id]
	,t.[Name]
FROM (
	SELECT h.[Id]
		,h.[Name]
		,COUNT(*) AS [AllBookings]
	FROM [Bookings] AS b
	JOIN [Hotels] AS h ON b.[HotelId] = h.[Id]
	JOIN [Rooms] AS r ON b.[RoomId] = r.[Id]
	GROUP BY h.[Id], h.[Name]
) AS t
JOIN [HotelsRooms] AS hr ON t.[Id] = hr.[HotelId]
WHERE hr.[RoomId] = 8
ORDER BY t.[AllBookings] DESC