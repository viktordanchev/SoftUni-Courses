SELECT TOP(3) e.[EmployeeID], [FirstName]
FROM [Employees] AS e
FULL OUTER JOIN [EmployeesProjects] AS ep ON e.[EmployeeID] = ep.[EmployeeID]
WHERE [ProjectID] IS NULL
ORDER BY [EmployeeID]

