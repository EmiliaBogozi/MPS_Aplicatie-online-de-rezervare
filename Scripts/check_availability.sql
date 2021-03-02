
DROP FUNCTION check_availability;
GO

CREATE FUNCTION check_availability(@resource_id INT)
RETURNS INT
AS
    BEGIN
        DECLARE
            @check INT,
            @offset INT,

            @current_date DATE,
            @current_time TIME,

            @year NVARCHAR(10),
            @month NVARCHAR(10),
            @day NVARCHAR(10),
            @hour NVARCHAR(10),
            @minute NVARCHAR(10);

        SET @check = 0; --libera
        SET @Offset = 2; --Europa de est

        --Data si ora curente
        SET @current_date = (SELECT convert(DATETIME2, GETUTCDATE() + @offset/24.0, 103));
        SET @current_time = (SELECT convert(DATETIME, GETDATE() + @offset/24.0, 24));

        SET @year = (SELECT YEAR(@current_date));
        SET @month = (SELECT MONTH(@current_date));
        SET @day = (select DAY(@current_date));

        SET @hour = (select DATEPART(hour, @current_time));
        SET @minute = (select DATEPART(minute, @current_time));

        --SELECT @check = COUNT(reservation_id)
        --FROM Reservation
        --WHERE resource_id = @resource_id;

        SELECT 
            @check = count(resource_id)
        FROM Reservation
        WHERE 
            resource_id = @resource_id AND
            @year = reservation_year AND 
            @month = reservation_month AND 
            @day = reservation_day AND
            reservation_hour * 100 + reservation_minute <= @hour * 100 + @minute AND
            @hour * 100 + @minute <= (reservation_hour + reservation_time) * 100 + reservation_minute;

        RETURN @check;
    END
GO

select [dbo].check_availability(5);
go

SELECT * from Reservation;
SELECT * FROM Favorite_classes;

