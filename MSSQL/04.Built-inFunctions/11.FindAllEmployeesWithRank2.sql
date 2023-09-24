SELECT *
FROM (
	SELECT [EmployeeID], [FirstName], [LastName], [Salary], 
	DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
	FROM [Employees]
	WHERE [Salary] BETWEEN 10000 AND 50000) AS [Table]
WHERE [Rank] = 2
ORDER BY [Salary] DESC

--CREATE VIEW V_View AS 
--SELECT [EmployeeID], [FirstName], [LastName], [Salary], 
--DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
--FROM [Employees]
--WHERE [Salary] BETWEEN 10000 AND 50000

--SELECT * FROM V_VIEW 
--WHERE [Rank] = 2
--ORDER BY [Salary] DESC