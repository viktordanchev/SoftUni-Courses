SELECT v.[Name]
	,v.[PhoneNumber]
	,SUBSTRING(v.[Address], CHARINDEX(', ', v.[Address]) + 2, LEN(v.[Address])) AS [Address]
FROM [Volunteers] AS v
JOIN [VolunteersDepartments] AS vd ON v.[DepartmentId] = vd.[Id]
WHERE vd.[DepartmentName] = 'Education program assistant' 
	AND CHARINDEX('Sofia', v.[Address]) > 0
ORDER BY v.[Name]