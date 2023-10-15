DELETE
FROM [Bookings]
WHERE [TouristId] IN (6, 16, 25)

DELETE
FROM [Tourists]
WHERE CHARINDEX('Smith', [Name]) > 0
