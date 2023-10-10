UPDATE [Invoices]
SET [DueDate] = '2023-04-01'
WHERE YEAR([IssueDate]) = 2022 AND MONTH([IssueDate]) = 11 

UPDATE [Clients]
SET [AddressId] = 3
WHERE CHARINDEX('CO', [Name]) > 0