CREATE PROCEDURE usp_SearchByCountry(@Country NVARCHAR(50))
AS
	SELECT t.[Name]
		,t.[PhoneNumber]
		,t.[Email]
		,COUNT(*) AS [CountOfBookings]
	FROM [Tourists] AS t
	JOIN [Countries] AS c ON t.[CountryId] = c.[Id]
	JOIN [Bookings] AS b ON t.[Id] = b.[TouristId]
	WHERE c.[Name] = @Country
	GROUP BY t.[Name], t.[PhoneNumber], t.[Email]
	ORDER BY t.[Name], [CountOfBookings] DESC
