CREATE OR ALTER PROCEDURE insert_favourite_classes
    @member_username NVARCHAR(50),
    @resource_name NVARCHAR(50)
AS
BEGIN
    DECLARE
        @member_id INT,
        @resource_id INT

    SELECT @member_id = member_id
    FROM Member
    WHERE @member_username = member_username;

    SELECT @resource_id = resource_id
    FROM Resources
    WHERE @resource_name = resource_name;

    IF NOT EXISTS 
        (SELECT * FROM Favorite_classes
        WHERE member_id = @member_id AND
            resource_id = @resource_id)

    INSERT INTO Favorite_classes(member_id, resource_id)
    VALUES (@member_id, @resource_id)

END
GO

exec insert_favourite_classes @member_username='ion', @resource_name='EG201';
GO

select * from Member;
select * from Resources;
select * from Favorite_classes;
