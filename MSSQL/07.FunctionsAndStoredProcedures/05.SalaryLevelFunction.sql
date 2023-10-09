CREATE FUNCTION ufn_GetSalaryLevel (@Salary DECIMAL(18,4))
RETURNS NVARCHAR(30)
AS
BEGIN
	DECLARE @SalaryLevel NVARCHAR(30)
	SET @SalaryLevel = (CASE
		WHEN @Salary < 30000 THEN 'Low'
		WHEN @Salary >= 30000 AND @Salary <= 50000 THEN 'Average'
		WHEN @Salary > 50000 THEN 'High'
	END)
	RETURN @SalaryLevel
END