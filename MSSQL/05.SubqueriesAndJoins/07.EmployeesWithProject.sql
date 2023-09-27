SELECT TOP(5) e.[EmployeeID], [FirstName], p.[Name] AS [ProjectName]
FROM [Employees] AS e
JOIN [EmployeesProjects] AS ep ON ep.[EmployeeID] = e.[EmployeeID]
JOIN [Projects] AS p ON p.[ProjectID] = ep.[ProjectID] 
	AND CAST(p.[StartDate] AS DATE) > '2002-08-13'
ORDER BY [EmployeeID]