CREATE OR ALTER FUNCTION get_id_resource(@resource_name NVARCHAR(50))
RETURNS INT
AS
    BEGIN
        DECLARE
            @resource_id INT;
            
        SELECT @resource_id = resource_id
        FROM Resources
        WHERE resource_name = @resource_name

        RETURN @resource_id;
    END
GO

exec get_id_resource @resource_name = 'EC004';
GO
