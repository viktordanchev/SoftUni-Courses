CREATE FUNCTION udf_RoomsWithTourists(@Name VARCHAR(40))
RETURNS INT
AS
BEGIN
	DECLARE @Count INT = (
		SELECT SUM([AdultsCount] + [ChildrenCount])
		FROM [Rooms] AS r
		JOIN [Bookings] AS b ON r.[Id] = b.[RoomId]
		WHERE [Type] = @Name
		GROUP BY [Type]
		)
	RETURN @Count
END