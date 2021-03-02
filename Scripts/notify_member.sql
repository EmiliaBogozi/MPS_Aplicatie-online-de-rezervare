CREATE OR ALTER PROCEDURE notify_member
    @username NVARCHAR(50),
    @resource_name NVARCHAR(50)
AS
BEGIN
    DECLARE
        @date_end DATE,
        @current_date DATE;
        @current_time TIME;

    --SELECT @current_date = SYSDATETIME();

    SET @current_date = CAST(SYSDATETIME() AS NVARCHAR(200)) 

    print @current_date;
END    
GO

exec notify_member @username='ion', @resource_name='PR001'
GO

