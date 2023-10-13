CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN (
		SELECT COUNT(*)
		FROM [Volunteers] AS v
		JOIN [VolunteersDepartments] AS vd ON v.[DepartmentId] = vd.[Id]
		WHERE vd.[DepartmentName] = @VolunteersDepartment
		)
END