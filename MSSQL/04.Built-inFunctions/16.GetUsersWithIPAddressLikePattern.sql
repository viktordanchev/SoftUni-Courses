SELECT [Username], [IpAddress]
FROM [Users]
WHERE CHARINDEX('.', LEFT([IpAddress], 3)) = 0 AND
	CHARINDEX('.', RIGHT([IpAddress], 3)) = 0 AND
	SUBSTRING([IpAddress], 5, 1) = '1' AND
	CHARINDEX('.', SUBSTRING([IpAddress], 6, 1)) = 0 AND
	CHARINDEX('.', SUBSTRING([IpAddress], 9, 1)) = 0
ORDER BY [Username]

SELECT SUBSTRING([IpAddress], 5, 3) AS IME
FROM [Users]