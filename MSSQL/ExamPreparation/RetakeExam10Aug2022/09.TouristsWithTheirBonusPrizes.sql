SELECT t.[Name]
	,t.[Age]
	,t.[PhoneNumber]
	,t.[Nationality]
	,IIF(bp.[Name] IS NULL, '(no bonus prize)', bp.[Name]) AS [Reward]
FROM [Tourists] AS t
LEFT JOIN [TouristsBonusPrizes] AS tbp ON t.[Id] = tbp.[TouristId]
LEFT JOIN [BonusPrizes] AS bp ON tbp.[BonusPrizeId] = bp.[Id]
ORDER BY t.[Name]