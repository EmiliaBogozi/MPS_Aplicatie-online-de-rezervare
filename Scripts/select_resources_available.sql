CREATE OR ALTER PROCEDURE select_resources_available
    @year INT,
    @month INT,
    @day INT,
    @hour INT,
    @minute INT,
    @time INT
AS
BEGIN

    SELECT 
        R.resource_id,
        R.resource_name,
        R.resource_description
    FROM Resources R
    WHERE R.resource_id NOT IN
        (SELECT 
            R.resource_id
        FROM Resources R
        LEFT JOIN Reservation A ON A.resource_id = R.resource_id
        WHERE @year = A.reservation_year AND 
            @month = A.reservation_month AND 
            @day = A.reservation_day AND
            (
                (@hour <= A.reservation_hour  AND 
                A.reservation_hour < @hour + @time AND
                @hour + @time <= A.reservation_hour + A.reservation_time) OR
                (A.reservation_hour <= @hour AND
                @hour < A.reservation_hour + A.reservation_time AND
                A.reservation_hour + A.reservation_time <= @hour + @time)
            )
        );

END
GO

exec select_resources_available @year=2021, @month=1, @day=22, @hour=19, @minute=37, @time=1;
GO

SELECT * FROM Resources;
SELECT * FROM Reservation;

