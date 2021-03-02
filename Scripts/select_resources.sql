CREATE OR ALTER PROCEDURE select_resources
AS
BEGIN

    SELECT 
        R.resource_id,
        R.resource_name,
        A.group_reservation,
        M.first_name + ' ' + M.last_name as name, 
        R.resource_status
    FROM Resources R
    LEFT JOIN Reservation A ON A.resource_id = R.resource_id
    LEFT JOIN Member M ON A.member_id = M.member_id;

END
GO

exec select_resources;
go


