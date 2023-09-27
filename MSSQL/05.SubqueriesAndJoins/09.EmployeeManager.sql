SELECT e.[EmployeeID], e.[FirstName], e.[ManagerID], em.[FirstName] AS [ManagerName]
FROM [Employees] AS e
JOIN [Employees] AS em ON e.[ManagerID] = em.[EmployeeID] 
	AND e.[ManagerID] IN (3, 7)
ORDER BY [EmployeeID]