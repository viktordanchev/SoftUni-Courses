CREATE VIEW V_EmployeeNameJobTitle AS
	SELECT CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName]) AS 'Full Name', [JobTitle] AS 'Job Title'
	FROM [Employees]