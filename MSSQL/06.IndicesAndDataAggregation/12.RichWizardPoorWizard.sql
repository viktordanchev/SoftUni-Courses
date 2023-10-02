SELECT SUM(t.[Host] - t.[Guest]) AS [SumDifference]
FROM (
	SELECT t.[DepositAmount] AS [Host], wd.[DepositAmount] AS [Guest]
	FROM (
		SELECT [Id], [DepositAmount]
		FROM [WizzardDeposits]) AS t
	JOIN [WizzardDeposits] AS wd ON wd.[Id] = t.[Id] + 1) AS t