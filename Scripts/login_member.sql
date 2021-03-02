CREATE OR ALTER PROCEDURE login_member
	@username NVARCHAR(50),
	@password NVARCHAR(20)
AS
	SELECT member_username, member_password
    FROM Member 
	WHERE member_username = @username
	    AND member_password = @password
GO

exec login_member 
    @username = 'ana', 
    @password = 'ana';
go