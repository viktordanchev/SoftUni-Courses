CREATE FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(100)) 
RETURNS INT
AS
BEGIN
	DECLARE @Count INT = (
		SELECT COUNT(*)
		FROM [Sites] AS s
		JOIN [SitesTourists] AS st ON s.[Id] = st.[SiteId]
		WHERE s.[Name] = @Site
	)
	RETURN @Count
END