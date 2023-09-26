SELECT TOP(5) [EmployeeId], [JobTitle], a.[AddressId], [AddressText] 
FROM [Employees] AS e
JOIN [Addresses] AS a ON e.AddressID = a.AddressID
ORDER BY [AddressId]