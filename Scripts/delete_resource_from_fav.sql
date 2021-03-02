
CREATE OR ALTER PROCEDURE delete_resource_from_fav
    @resource_id INT,
    @member_username NVARCHAR(50)
AS
    DECLARE @member_id INT;

    SELECT @member_id = member_id
    FROM Member
    WHERE @member_username = member_username;

    DELETE FROM [dbo].Favorite_classes 
    WHERE @resource_id = resource_id AND
        @member_id = member_id;
GO

--exec delete_resource_from_fav @resource_id = 5, @member_id = 1;
--GO

select * from Favorite_classes;
