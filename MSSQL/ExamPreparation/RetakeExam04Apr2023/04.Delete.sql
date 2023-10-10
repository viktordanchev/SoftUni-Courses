DELETE
FROM [Invoices]
WHERE [Id] IN (11, 30)

DELETE
FROM [ProductsClients]
WHERE [ClientId] = 11

DELETE
FROM [Clients]
WHERE LEFT([NumberVAT], 2) = 'IT'