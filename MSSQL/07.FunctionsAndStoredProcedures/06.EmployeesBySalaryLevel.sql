CREATE PROCEDURE usp_EmployeesBySalaryLevel 
	@SalaryLevel NVARCHAR(30)
AS
	SELECT [FirstName], [LastName]
	FROM [Employees]
	WHERE dbo.ufn_GetSalaryLevel([Salary]) = @SalaryLevel