SELECT [ContinentCode], [CurrencyCode] , [CurrencyUsage] 
FROM (
	SELECT [ContinentCode], 
		[CurrencyCode], 
		COUNT(*) AS [CurrencyUsage],
	    DENSE_RANK() OVER (PARTITION BY [ContinentCode] ORDER BY COUNT(*) DESC) AS [Rank]
	FROM [Countries]
	GROUP BY [ContinentCode],  [CurrencyCode]
	HAVING COUNT(*) > 1
	) AS c
WHERE [Rank] = 1
ORDER BY [ContinentCode]