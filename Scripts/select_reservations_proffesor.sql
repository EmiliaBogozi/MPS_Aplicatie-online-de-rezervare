CREATE OR ALTER PROCEDURE select_reservations_proffesor
    @username VARCHAR(50)
AS
BEGIN
    DECLARE
        @group NVARCHAR(10);

    SELECT @group = member_group
    FROM Member
    WHERE member_username = @username;

    SELECT 
        R.reservation_id,
        M.first_name + ' ' + M.last_name,
        A.resource_name,
        R.group_reservation,
        CAST(R.reservation_day AS VARCHAR(10)) + '/' + CAST(R.reservation_month AS VARCHAR(10)) + '/' + CAST(R.reservation_year AS VARCHAR(10)) + ' ' + CAST(R.reservation_hour AS VARCHAR(10)) + ':' + CAST(R.reservation_minute AS VARCHAR(10)),
        CAST(R.reservation_day AS VARCHAR(10)) + '/' + CAST(R.reservation_month AS VARCHAR(10)) + '/' + CAST(R.reservation_year AS VARCHAR(10)) + ' ' + CAST((R.reservation_hour + R.reservation_time) AS VARCHAR(10)) + ':' + CAST(R.reservation_minute AS VARCHAR(10))
    FROM Reservation R, Resources A, Member M
    WHERE
        R.resource_id = A.resource_id AND
        M.member_id = R.member_id AND
        M.member_username = @username;

END
GO

exec select_reservations_proffesor @username = 'ion';
go
