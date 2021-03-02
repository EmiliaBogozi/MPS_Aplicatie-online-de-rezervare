CREATE OR ALTER FUNCTION get_role_member(@username NVARCHAR(50))
RETURNS NVARCHAR(20)
AS
    BEGIN
        DECLARE
            @member_role NVARCHAR(20);
            
        SELECT @member_role = member_role
        FROM Member
        WHERE member_username = @userName

        RETURN @member_role;
    END
GO

exec get_role_member @username = "ana"
GO
