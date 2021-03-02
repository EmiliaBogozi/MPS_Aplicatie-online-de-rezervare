CREATE OR ALTER PROCEDURE register
    @first_name NVARCHAR(25),
    @last_name NVARCHAR(25),
    @group NVARCHAR(10),
    @role NVARCHAR(20),
    @username NVARCHAR(50),
    @password NVARCHAR(20)
AS
BEGIN
    IF NOT EXISTS (
        SELECT * 
        FROM Member
        WHERE member_username = @username
    )

    INSERT INTO Member(first_name, last_name, member_group, member_role, member_username, member_password)
    VALUES (@first_name, @last_name, @group, @role, @username, @password)
END
GO

exec register @first_name = 'ana', 
    @last_name = 'popescu', 
    @group = '341C2', 
    @role = 'student',
    @username = 'ana', 
    @password = 'ana';
go

SELECT * FROM Member;