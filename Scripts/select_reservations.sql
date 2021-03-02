
--No = reservation_id
--Name = member_first_name + ' ' + member_last_name
--Resource = resource_name
--Group = reservation_group
--Date start = reservation_day + '/' + reservation_month + '/' + reservation_year + ' ' + reservation_hour + ':' + reservation_minute
--Date end = reservation_day + '/' + reservation_month + '/' + reservation_year + ' ' + reservation_hour + ':' + reservation_minute

CREATE OR ALTER PROCEDURE select_reservations
AS
BEGIN

    SELECT 
        R.reservation_id,
        M.first_name + ' ' + M.last_name,
        A.resource_name,
        R.group_reservation,
        CAST(R.reservation_day AS VARCHAR(10)) + '/' + CAST(R.reservation_month AS VARCHAR(10)) + '/' + CAST(R.reservation_year AS VARCHAR(10)) + ' ' + CAST(R.reservation_hour AS VARCHAR(10)) + ':' + CAST(R.reservation_minute AS VARCHAR(10)),
        CAST(R.reservation_day AS VARCHAR(10)) + '/' + CAST(R.reservation_month AS VARCHAR(10)) + '/' + CAST(R.reservation_year AS VARCHAR(10)) + ' ' + CAST((R.reservation_hour + R.reservation_time) AS VARCHAR(10)) + ':' + CAST(R.reservation_minute AS VARCHAR(10)),
        R.reason_reservation
    FROM Reservation R, Resources A, Member M
    WHERE
        R.resource_id = A.resource_id AND
        M.member_id = R.member_id;

END
GO

exec select_reservations;
go

SELECT * FROM Reservation;


