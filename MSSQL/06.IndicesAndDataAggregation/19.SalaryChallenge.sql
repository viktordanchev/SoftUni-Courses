SELECT TOP(10) [FirstName], [LastName], e.[DepartmentID]
FROM (
	SELECT [DepartmentID]
		,AVG([Salary]) AS [AvgSalary]
	FROM [Employees]
	GROUP BY [DepartmentID]) AS t
JOIN [Employees] AS e ON t.[DepartmentID] = e.[DepartmentID]
WHERE [Salary] > [AvgSalary]
ORDER BY [DepartmentID]