CREATE PROCEDURE usp_AnnualRewardLottery(@TouristName VARCHAR(50))
AS
	SELECT t.[Name]
		,(CASE 
		WHEN COUNT(*) >= 100 THEN 'Gold badge'
		WHEN COUNT(*) >= 50 THEN 'Silver badge'
		WHEN COUNT(*) >= 25 THEN 'Bronze badge'
		END) AS [Reward]
	FROM [Tourists] AS t
	JOIN [SitesTourists] AS st ON t.[Id] = st.[TouristId]
	WHERE t.[Name] = @TouristName
	GROUP BY t.[Name]