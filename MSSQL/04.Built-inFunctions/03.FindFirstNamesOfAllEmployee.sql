SELECT [FirstName]
FROM Employees 
WHERE [DepartmentID] = 3 OR [DepartmentID] = 10
	AND [HireDate] >= '1995' AND [HireDate] <= '2005'