SELECT [DepartmentID], [Salary]
FROM (
	SELECT [DepartmentID]
		,[Salary]
		,DENSE_RANK() OVER (PARTITION BY [DepartmentId] ORDER BY [Salary] DESC) AS [Rank]
	FROM [Employees]
	GROUP BY [DepartmentID], [Salary]) AS t
WHERE [Rank] = 3