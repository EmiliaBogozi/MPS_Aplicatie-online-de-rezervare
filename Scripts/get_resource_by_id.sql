
CREATE FUNCTION get_resource_by_id(@resource_id INT)
RETURNS NVARCHAR(50)
AS
BEGIN
    DECLARE @resource_name NVARCHAR(50);

    SELECT @resource_name = resource_name
    FROM Resources
    WHERE @resource_id = resource_id;

    RETURN @resource_name;
END
GO