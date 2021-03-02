CREATE OR ALTER PROCEDURE select_all_resources
AS
BEGIN

    SELECT 
        resource_id,
        resource_name
    FROM Resources;

END
GO

exec select_all_resources;
go