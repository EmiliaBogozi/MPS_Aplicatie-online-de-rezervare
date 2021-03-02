CREATE OR ALTER PROCEDURE select_favourite_classes
    @member_username NVARCHAR(50)
AS
BEGIN

    SELECT 
        C.resource_id,
        R.resource_name
    FROM Favorite_classes C, Resources R, Member M
    WHERE R.resource_id = C.resource_id AND
        M.member_username = @member_username AND
        M.member_id = C.member_id;

END
GO

exec select_favourite_classes @member_username='alin';
go

SELECT * from Favorite_classes;