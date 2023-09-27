SELECT 
	e.[EmployeeID], 
	[FirstName], 
	IIF(YEAR(p.[StartDate]) >= 2005, NULL, p.[Name]) AS [ProjectName]
FROM [Employees] AS e
JOIN [EmployeesProjects] AS ep ON ep.[EmployeeID] = e.[EmployeeID]
JOIN [Projects] AS p ON p.[ProjectID] = ep.[ProjectID]
WHERE e.[EmployeeID] = 24