SELECT [CountryName], [ISOCode] FROM [Countries]
WHERE LEN([CountryName]) - LEN(REPLACE([CountryName], 'a', '')) >= 3
ORDER BY [ISOCode]