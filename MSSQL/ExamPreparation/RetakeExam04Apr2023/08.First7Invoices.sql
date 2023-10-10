SELECT TOP(7) [Number]
	,[Amount]
	,c.[Name]
FROM [Invoices] AS i
JOIN [Clients] AS c ON i.[ClientId] = c.[Id]
WHERE [IssueDate] < '2023-01-01' 
	AND [Currency] = 'EUR'
	OR [Amount] > 500
	AND LEFT(c.[NumberVAT], 2) = 'DE' 
ORDER BY [Number], [Amount] DESC