SELECT [FirstName], [LastName], [HireDate], d.[Name] AS [DeptName]
FROM [Employees] AS e
JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
	AND CAST(e.[HireDate] AS DATE) > '1999-1-1' 
	AND d.[Name] IN ('Sales', 'Finance')
ORDER BY [HireDate]

