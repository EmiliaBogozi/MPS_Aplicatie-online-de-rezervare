CREATE OR ALTER FUNCTION get_id_member(@username NVARCHAR(50))
RETURNS INT
AS
    BEGIN
        DECLARE
            @member_id INT;
            
        SELECT @member_id = member_id
        FROM Member
        WHERE member_username = @username

        RETURN @member_id;
    END
GO

exec get_id_member @username='ana';
GO