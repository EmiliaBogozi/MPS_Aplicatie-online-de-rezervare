--neterminata

CREATE OR ALTER PROCEDURE get_classes_for_students
    @username NVARCHAR(50)
AS
    SELECT re.resource_name, rez.reservation_start, rez.reservation_end, prof.first_name, prof.last_name
    FROM Member stud, Member prof, Reservation rez, Resources re
    WHERE @username = stud.member_username AND
        re.resource_id = rez.resource_id AND
        prof.member_id = rez.member_id;
GO

exec get_classes_for_students @username = "ana";
GO