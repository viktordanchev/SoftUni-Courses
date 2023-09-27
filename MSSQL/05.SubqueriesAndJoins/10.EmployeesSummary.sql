SELECT TOP(50)
	e.[EmployeeID], 
	CONCAT_WS(' ', e.[FirstName], e.[LastName]) AS [EmployeeName],
	CONCAT_WS(' ', em.[FirstName], em.[LastName]) AS [ManagerName],
	d.[Name] AS [DepartmentName]
FROM [Employees] AS e
JOIN [Employees] AS em ON e.[ManagerID] = em.[EmployeeID]
JOIN [Departments] AS d ON d.[DepartmentID] = e.[DepartmentID]
ORDER BY [EmployeeID]