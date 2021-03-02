
CREATE OR ALTER PROCEDURE book_classroom
    @resource_id INT,
    @member_id INT,
    @group_reservation NVARCHAR(10),
    @reservation_year INT,
    @reservation_month INT,
    @reservation_day INT,
    @reservation_hour INT,
    @reservation_minute INT,
    @reservation_time INT,
    @reservation_reason NVARCHAR(100)
AS
BEGIN
    INSERT INTO Reservation(
        resource_id, 
        member_id, 
        group_reservation, 
        reservation_year,
        reservation_month,
        reservation_day,
        reservation_hour,
        reservation_minute,
        reservation_time,
        reason_reservation)
    VALUES(
        @resource_id, 
        @member_id, 
        @group_reservation, 
        @reservation_year,
        @reservation_month,
        @reservation_day,
        @reservation_hour,
        @reservation_minute,
        @reservation_time,
        @reservation_reason);
END
GO